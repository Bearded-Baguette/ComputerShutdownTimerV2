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
        static Timer myTimer;

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


                    //Create a popup, alerting the user
                    CreatePopup();
                    // Delay loop by one minute
                    System.Threading.Thread.Sleep(1 * 45 * 1000); //1 minute * 60 seconds * 1000 milliseconds
                }
                else if (remainingMinutes <= 0)
                {
                    MessageBox.Show("Shutting down computer in 10 seconds! Have a good night!");
                    System.Threading.Thread.Sleep(10 * 1000); //Wait 10 seconds before shutting down the computer
                    CommenceShutdown();
                }
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

        //public void CreatePopup()
        //{
        //    bool exitFlag = false;
        //    myTimer = new Timer();

        //    /* Adds the event and the event handler for the method that will 
        //    process the timer event to the timer. */
        //    myTimer.Tick += new EventHandler(TimerEventProcessor);

        //    // Sets the timer interval to 15 seconds.
        //    myTimer.Interval = 15 * 1000; //15 seconds * 1000 milliseconds;
        //    myTimer.Start();

        //    // Runs the timer, and raises the event.
        //    while (exitFlag == false)
        //    {
        //        // Processes all the events in the queue.
        //        Application.DoEvents();
        //    }
        //}

        //private static void TimerEventProcessor(Object myObject,
        //                                EventArgs myEventArgs)
        //{
        //    myTimer.Stop();

        //    // Displays a message box asking whether to continue running the timer.
        //    if (MessageBox.Show("Continue running?", "Count is: " + alarmCounter,
        //       MessageBoxButtons.YesNo) == DialogResult.Yes)
        //    {
        //        // Restarts the timer and increments the counter.
        //        alarmCounter += 1;
        //        myTimer.Enabled = true;
        //    }
        //    else
        //    {
        //        // Stops the timer.
        //        exitFlag = true;
        //    }
        //}


        //public void testc()
        //{
        //    // This function creates a timer object that will tick down.
        //    // The timer will handle the event of creating the popup box.
        //    // When the timer ends, the box closes.
        //    // Very nice.
        //    Timer t = new Timer();
        //    t.Interval = 15 * 1000; //15 seconds * 1000 milliseconds
        //    t.Tick += new EventHandler(timer_CreatePopup);
        //    t.Start();

        //}

        //public void timer_CreatePopup(object sender, EventArgs e)
        //{
        //    String shutdownMessage = "Computer shutting down in " + remainingMinutes.ToString("0.") + " minutes. Please save all work now!";
        //    ShutdownPopup popup = new ShutdownPopup(shutdownMessage);
        //    popup.Show();
        //    popup.BringToFront();
        //    popup.Activate();
        //    popup.Focus();

        //}

        //private void timer_Tick(object sender, EventArgs e)
        //{
        //    MessageBox.Show("Tick");
        //    this.Close();
        //}

    }
}