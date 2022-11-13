using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerShutdownTimer
{
    public partial class ShutdownPopup : Form
    {
        public ShutdownPopup()
        {
            InitializeComponent();
        }

        public ShutdownPopup(String shutdownText)
        {
            this.ShutdownTextBox.Text = shutdownText;
        }

        private void ShutdownTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
