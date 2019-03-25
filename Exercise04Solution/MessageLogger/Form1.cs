using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessageLogger
{
    public partial class MessageLoggerApplicationForm : Form
    {
        EventHandler sendTextToLeftOutputEventHandler;
        EventHandler sendTextToRightOutputEventHandler;

        public MessageLoggerApplicationForm()
        {
            InitializeComponent();
            sendTextToLeftOutputEventHandler = new EventHandler((SendTextToLeftOutput));
            sendTextToRightOutputEventHandler = new EventHandler((SendTextToRightOutput));
            Text = Properties.Resources.ApplicationTitle;
        }

        private void SendBtnClick(object sender, EventArgs e)
        {
            if (RightPanelCheckBox.Checked)
                RightOutputTextBox.Text += InputMessageEditControl.Text + "\r\n";
        }

        private void SendTextToLeftOutput(object sender, EventArgs e)
        {
            LeftOutputTextBox.Text += InputMessageEditControl.Text + "\r\n";
        }
        private void SendTextToRightOutput(object sender, EventArgs e)
        {
            RightOutputTextBox.Text += InputMessageEditControl.Text + "\r\n";
        }
        private void OutputEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            EventHandler checkedChangedEventHandler = null;
            if (sender == LeftPanelCheckBox)
                checkedChangedEventHandler = sendTextToLeftOutputEventHandler;
            else if (sender == RightPanelCheckBox)
                checkedChangedEventHandler = sendTextToRightOutputEventHandler;

            if ((sender as CheckBox).Checked)
                SendBtn.Click += checkedChangedEventHandler;
            else
                SendBtn.Click -= checkedChangedEventHandler;
        }
    }
}
