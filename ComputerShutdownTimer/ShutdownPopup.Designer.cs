namespace ComputerShutdownTimer
{
    partial class ShutdownPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShutdownPopup));
            this.ShutdownTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // ShutdownTextBox
            // 
            this.ShutdownTextBox.Location = new System.Drawing.Point(12, 12);
            this.ShutdownTextBox.Name = "ShutdownTextBox";
            this.ShutdownTextBox.Size = new System.Drawing.Size(285, 104);
            this.ShutdownTextBox.TabIndex = 0;
            this.ShutdownTextBox.Text = "";
            this.ShutdownTextBox.TextChanged += new System.EventHandler(this.ShutdownTextBox_TextChanged);
            // 
            // ShutdownPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 132);
            this.Controls.Add(this.ShutdownTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShutdownPopup";
            this.Text = "Shutdown Alert!";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox ShutdownTextBox;
    }
}