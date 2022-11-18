using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Timers;
using System.Windows.Forms;

namespace ComputerShutdownTimer
{
    public partial class MainWindow : Form
    {
        DateTime currentTime;
        DateTime selectedDate;
        DateTime shutdownTime;
        double remainingMinutes;
        int selectedHour, selectedMinute;
        string selectedAmPm;
        string shutdownText;
        ShutdownPopup shutdownPopup;
        bool exitFlag = false;

        public MainWindow()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.ShowInTaskbar= false;
            this.TopMost = true;
            this.ShowDialog();
            this.BringToFront();
            this.Activate();
            this.Focus();
        }

        private void startButton_MouseClick(object sender, MouseEventArgs e)
        {
            currentTime = DateTime.Now;
            selectedDate = datePicker.Value;
            selectedHour = Int32.Parse(hourDropdown.Text);
            selectedMinute = Int32.Parse(minuteDropdown.Text);
            selectedAmPm = AmPm.Text;

            if (selectedAmPm == "PM" && selectedHour != 12) // Any time after 1 PM
            {
                selectedHour += 12;
            }
            else if (selectedAmPm == "AM" && selectedHour == 12) // Midnight
            {
                selectedHour = 00;
            }

            shutdownTime = CreateShutdownTime();

            if (!ValidTime(currentTime, shutdownTime))
            {
                statusText.Text = "Shutdown time is set before current time. Enter another time.";
                return;
            }
            else
            {
                shutdownText = "Shutdown set for \n" + shutdownTime.ToString();
                statusText.Text = shutdownText;

                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += new DoWorkEventHandler(worker_BeginShutdownTimer);
                worker.RunWorkerAsync();

                this.WindowState = FormWindowState.Minimized;
                this.Visible = false;
            }

        }

        private bool ValidTime(DateTime currentTime, DateTime shutdownTime)
        {
            if (currentTime < shutdownTime)
            {
                return true;
            }
            return false;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            // Set default values
            hourDropdown.SelectedItem = "11";
            minuteDropdown.SelectedItem = "00";
            AmPm.SelectedItem = "PM";
            statusText.Text = "Enter a shutdown time then press \"Start Timer\"";
        }

        private DateTime CreateShutdownTime()
        {
            return new DateTime(
                selectedDate.Year,
                selectedDate.Month,
                selectedDate.Day,
                selectedHour,
                selectedMinute,
                00,
                00);
        }

        private void worker_BeginShutdownTimer(object sender, EventArgs e)
        {
            // Every minute, check to see how much time is left
            while (true)
            {
                currentTime = DateTime.Now;

                // Retrieve the remaining amount of time
                remainingMinutes = GetRemainingMinutes_Double(currentTime, shutdownTime);

                //If time remaining is less than 5 minutes, create popup saying shutdown in X minutes.
                if (remainingMinutes <= 5 && remainingMinutes > 0)
                {
                    //Create a popup, alerting the user
                    //CreatePopup();
                    BackgroundWorker worker = new BackgroundWorker();
                    worker.DoWork += new DoWorkEventHandler(CreatePopup);
                    worker.RunWorkerAsync();
                    // Delay loop by one minute
                    System.Threading.Thread.Sleep(1 * 45 * 1000); //1 minute * 60 seconds * 1000 milliseconds
                }
                else if (remainingMinutes <= 0)
                {
                    shutdownPopup.Text = "Shutting down computer in 10 seconds! Have a good night!";
                    System.Threading.Thread.Sleep(10 * 1000); //Wait 10 seconds before shutting down the computer
                    CommenceShutdown();
                }
            }
        }
        
        private double GetRemainingMinutes_Double(DateTime currentTime, DateTime shutdownTime)
        {
            // Subtract the difference between the current time and shutdown time. Return the TimeSpan difference.
            TimeSpan span = shutdownTime - currentTime;
            return remainingMinutes = span.TotalMinutes;
        }

        private TimeSpan GetRemainingMinutes_TimeSpan(DateTime currentTime, DateTime shutdownTime)
        {
            // Subtract the difference between the current time and shutdown time. Return the TimeSpan difference.
            TimeSpan span = shutdownTime - currentTime;
            return span;
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(3000, "Computer Shutdown Timer", shutdownText, ToolTipIcon.None);
                this.ShowInTaskbar = false;
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            notifyIcon.Visible = false;
        }

        private void CommenceShutdown()
        {
            Process.Start("shutdown", "/s /t 0");
        }

        private void CreatePopup(object sender, EventArgs e)
        {
            //Create new timer that ticks every 1 second
            System.Windows.Forms.Timer newTimer = new System.Windows.Forms.Timer();
            newTimer.Tick += new EventHandler(newTimer_Tick);
            newTimer.Interval = 1000; //1 second
            newTimer.Start();

            //Create a popup window to display the time remaining
            shutdownPopup = new ShutdownPopup();
            shutdownPopup.Show();
            shutdownPopup.ControlBox = false;
            shutdownPopup.ShowInTaskbar = false;
            shutdownPopup.TopMost = true;
            shutdownPopup.BringToFront();
            shutdownPopup.Activate();
            shutdownPopup.Focus();


            while (exitFlag == false)
            {
                Application.DoEvents();
            }
        }

        private void newTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan remainingTime = GetRemainingMinutes_TimeSpan(DateTime.Now, shutdownTime);
            if (remainingTime <= TimeSpan.Zero)
            {
                CommenceShutdown();
            }
            else
            {
                string remainingMinutes = new DateTime(remainingTime.Ticks).ToString("mm:ss");
                string shutdownMessage = "Computer will shutdown in " + remainingMinutes + ". Please save all work now!";

                shutdownPopup.shutdownLabel.Text = shutdownMessage;
            }

        }
    }
}