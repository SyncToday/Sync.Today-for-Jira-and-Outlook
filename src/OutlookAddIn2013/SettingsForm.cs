using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutlookAddIn2013
{

    public partial class SettingsForm : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);
        const int EM_SETCUEBANNER = 0x1501;

        public static SettingsForm Instance = null;

        public SettingsForm()
        {
            InitializeComponent();

            SendMessage(textBox_Server.Handle, EM_SETCUEBANNER, 1, "https://jira.company.com");
            SendMessage(textBox_UserName.Handle, EM_SETCUEBANNER, 1, "a_blemba");
            SendMessage(textBox_Password.Handle, EM_SETCUEBANNER, 1, "Secret123");

            var s = Settings.Default;
            textBox_Server.Text = s.ServerUrl;
            textBox_UserName.Text = s.UserName;
            textBox_Password.Text = s.Password;

            checkBox_AutosyncAllowed.Checked = s.TimerEnabled;
            textBox_TimeElapse.Text = String.Empty + s.TimerInterval;

            Instance = this;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Instance = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var s = Settings.Default;
            s.ServerUrl = textBox_Server.Text;
            s.UserName = textBox_UserName.Text;
            s.Password = textBox_Password.Text;

            s.TimerEnabled = checkBox_AutosyncAllowed.Checked;

            int val = 0;
            Int32.TryParse(this.textBox_TimeElapse.Text, out val);
            s.TimerInterval = val;

            s.Save();

            if (s.TimerEnabled) Globals.ThisAddIn.StartAutomaticSync();

            button2_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OutlookAddin.Func.UI.Button_Test_Click(textBox_Server.Text, textBox_UserName.Text, textBox_Password.Text);
        }

        private void Message_TimeElapseNotValid()
        {
            MessageBox.Show("Please enter number of minutes", "Wrong number", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void textBox_TimeElapse_Validating(object sender, CancelEventArgs e)
        {
            int i = 0;
            if (!Int32.TryParse(textBox_TimeElapse.Text, out i) || i <= 0)
            {
                Message_TimeElapseNotValid();
                e.Cancel = true;
            }
        }
    }
}
