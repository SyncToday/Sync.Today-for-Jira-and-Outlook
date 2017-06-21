using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutlookAddIn2013
{
    public partial class SettingsForm : Form
    {
        public static SettingsForm Instance = null;

        public SettingsForm()
        {
            InitializeComponent();

            var s = Settings.Default;
            textBox_Server.Text = s.ServerUrl;
            textBox_UserName.Text = s.UserName;
            textBox_Password.Text = s.Password;

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

            s.Save();

            button2_Click(sender, e);
        }
    }
}
