using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ComputerShutdownTimer
{
    public partial class MainWindow : Form
    {
        DateTime currentTime;
        DateTime selectedDate;
        DateTime shutdownTime;
        int selectedHour, selectedMinute;
        string selectedAmPm;

        public MainWindow()
        {
            InitializeComponent();
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

            statusText.Text = "Shutdown set for \n" + shutdownTime.ToString();

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

        private void StartTimer()
        {
            while (true)
            {
                if (shutdownTime.Subtract(currentTime).Ticks < 0)
                {
                    Process.Start("shutdown", "/s /t 0");
                }
            }
        }
    }
}