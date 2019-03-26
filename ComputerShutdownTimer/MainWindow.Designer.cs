namespace ComputerShutdownTimer
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.hourDropdown = new System.Windows.Forms.ComboBox();
            this.minuteDropdown = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AmPm = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.statusText = new System.Windows.Forms.RichTextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // hourDropdown
            // 
            this.hourDropdown.FormattingEnabled = true;
            this.hourDropdown.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.hourDropdown.Location = new System.Drawing.Point(56, 30);
            this.hourDropdown.Name = "hourDropdown";
            this.hourDropdown.Size = new System.Drawing.Size(97, 21);
            this.hourDropdown.Sorted = true;
            this.hourDropdown.TabIndex = 0;
            // 
            // minuteDropdown
            // 
            this.minuteDropdown.FormattingEnabled = true;
            this.minuteDropdown.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.minuteDropdown.Location = new System.Drawing.Point(229, 30);
            this.minuteDropdown.Name = "minuteDropdown";
            this.minuteDropdown.Size = new System.Drawing.Size(97, 21);
            this.minuteDropdown.Sorted = true;
            this.minuteDropdown.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hour";
            // 
            // AmPm
            // 
            this.AmPm.FormattingEnabled = true;
            this.AmPm.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.AmPm.Location = new System.Drawing.Point(402, 30);
            this.AmPm.Name = "AmPm";
            this.AmPm.Size = new System.Drawing.Size(97, 21);
            this.AmPm.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Minute";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(352, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "AM/PM";
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(56, 83);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(200, 20);
            this.datePicker.TabIndex = 6;
            // 
            // statusText
            // 
            this.statusText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusText.Location = new System.Drawing.Point(312, 86);
            this.statusText.Name = "statusText";
            this.statusText.ReadOnly = true;
            this.statusText.Size = new System.Drawing.Size(273, 136);
            this.statusText.TabIndex = 8;
            this.statusText.Text = "";
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(56, 134);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(167, 88);
            this.startButton.TabIndex = 9;
            this.startButton.Text = "Start Timer";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.startButton_MouseClick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 251);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.statusText);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AmPm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.minuteDropdown);
            this.Controls.Add(this.hourDropdown);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox hourDropdown;
        private System.Windows.Forms.ComboBox minuteDropdown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox AmPm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.RichTextBox statusText;
        private System.Windows.Forms.Button startButton;
    }
}

