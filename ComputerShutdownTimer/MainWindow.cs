using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Remoting;
using System.Threading.Tasks;
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

        public MainWindow()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private async void startButton_MouseClick(object sender, MouseEventArgs e)
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
                remainingMinutes = GetRemainingMinutes(currentTime, shutdownTime);

                //If time remaining is less than 5 minutes, create popup saying shutdown in X minutes.
                if (remainingMinutes <= 5 && remainingMinutes > 0)
                {
                    MessageBox.Show("Computer shutting down in " + remainingMinutes + "minutes. Please save all work now!");
                }
                else if (remainingMinutes <= 0)
                {
                    MessageBox.Show("Shutting down computer in 10 seconds! Have a good night!");
                    System.Threading.Thread.Sleep(10 * 1000); //Wait 10 seconds before shutting down the computer
                    CommenceShutdown();
                }
                // Delay loop by one minute
                System.Threading.Thread.Sleep(1 * 60 * 1000); //1 minute * 60 seconds * 1000 milliseconds
            }
        }
        
        private double GetRemainingMinutes(DateTime currentTime, DateTime shutdownTime)
        {
            // Subtract the difference between the current time and shutdown time. Return the TimeSpan difference.
            TimeSpan span = shutdownTime - currentTime;
            return remainingMinutes = span.TotalMinutes;
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
    }
}