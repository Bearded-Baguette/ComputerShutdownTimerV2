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
            this.shutdownLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // shutdownLabel
            // 
            this.shutdownLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shutdownLabel.Location = new System.Drawing.Point(0, 0);
            this.shutdownLabel.Name = "shutdownLabel";
            this.shutdownLabel.Size = new System.Drawing.Size(309, 138);
            this.shutdownLabel.TabIndex = 1;
            this.shutdownLabel.Text = "Shutdown Incoming!";
            this.shutdownLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.shutdownLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // ShutdownPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 138);
            this.Controls.Add(this.shutdownLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShutdownPopup";
            this.Text = "Shutdown Alert!";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label shutdownLabel;
    }
}