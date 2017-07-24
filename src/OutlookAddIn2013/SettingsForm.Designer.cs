namespace OutlookAddIn2013
{
    partial class SettingsForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_UserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Server = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox_AutosyncAllowed = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_TimeElapse = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(33, 254);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(497, 254);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(590, 223);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.textBox_Password);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.textBox_UserName);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.textBox_Server);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(582, 197);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Connection";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.checkBox_AutosyncAllowed);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.textBox_TimeElapse);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(582, 197);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Timer";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(83, 146);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "Test";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // textBox_Password
            // 
            this.textBox_Password.Location = new System.Drawing.Point(83, 100);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.PasswordChar = '*';
            this.textBox_Password.ShortcutsEnabled = false;
            this.textBox_Password.Size = new System.Drawing.Size(473, 20);
            this.textBox_Password.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Password";
            // 
            // textBox_UserName
            // 
            this.textBox_UserName.Location = new System.Drawing.Point(82, 59);
            this.textBox_UserName.Name = "textBox_UserName";
            this.textBox_UserName.Size = new System.Drawing.Size(473, 20);
            this.textBox_UserName.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "User name";
            // 
            // textBox_Server
            // 
            this.textBox_Server.Location = new System.Drawing.Point(82, 22);
            this.textBox_Server.Name = "textBox_Server";
            this.textBox_Server.Size = new System.Drawing.Size(473, 20);
            this.textBox_Server.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Server URL";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(172, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "every";
            // 
            // checkBox_AutosyncAllowed
            // 
            this.checkBox_AutosyncAllowed.AutoSize = true;
            this.checkBox_AutosyncAllowed.Location = new System.Drawing.Point(151, 17);
            this.checkBox_AutosyncAllowed.Name = "checkBox_AutosyncAllowed";
            this.checkBox_AutosyncAllowed.Size = new System.Drawing.Size(15, 14);
            this.checkBox_AutosyncAllowed.TabIndex = 26;
            this.checkBox_AutosyncAllowed.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(290, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "minutes.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Auto JIRA issue download";
            // 
            // textBox_TimeElapse
            // 
            this.textBox_TimeElapse.Location = new System.Drawing.Point(225, 14);
            this.textBox_TimeElapse.Name = "textBox_TimeElapse";
            this.textBox_TimeElapse.Size = new System.Drawing.Size(59, 20);
            this.textBox_TimeElapse.TabIndex = 23;
            this.textBox_TimeElapse.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_TimeElapse_Validating);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 298);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SettingsForm";
            this.Text = "Sync.Today for Outlook and JIRA Settings";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_UserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Server;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox_AutosyncAllowed;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_TimeElapse;
    }
}