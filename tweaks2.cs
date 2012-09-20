using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;

namespace ADVallignment
{
    public partial class tweaks2 : UserControl
    {
        public tweaks2()
        {
            InitializeComponent();
        }

        private void tweaks2_Load(object sender, EventArgs e)
        {
            label3.Text = "";
            label4.Text = "";
            label6.Text = "";
            RegistryKey menushowdelay = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop");
            numericUpDown1.Value = Convert.ToInt64(menushowdelay.GetValue("MenuShowDelay").ToString());
            RegistryKey regto = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion", true);
            textBox1.Text = regto.GetValue("RegisteredOwner", "Not Found").ToString();

            RegistryKey processor = Registry.LocalMachine.OpenSubKey(@"HARDWARE\DESCRIPTION\System\CentralProcessor\0",true);
            textBox2.Text = processor.GetValue("ProcessorNameString").ToString();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistryKey regto = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion", true);
            regto.SetValue("RegisteredOwner", textBox1.Text, RegistryValueKind.String);
            label4.ForeColor = Color.Green;
            label4.Text = "Success...!!";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistryKey menushowdelay = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop",true);
            menushowdelay.SetValue("MenuShowDelay", numericUpDown1.Value);
            label3.ForeColor = Color.Red;
            label3.Text = "Reboot Required..!!";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RegistryKey processor = Registry.LocalMachine.OpenSubKey(@"HARDWARE\DESCRIPTION\System\CentralProcessor\0", true);
            processor.SetValue("ProcessorNameString", textBox2.Text);
            label6.ForeColor = Color.Green;
            label6.Text = "Sucess..!!";
        }
    }
}
