using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Microsoft.Win32;
using System.Management.Instrumentation;
using System.Text;
using System.Windows.Forms;

namespace ADVallignment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Make the window Dragable..
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            int WM_NCHITTEST = 0x84;
            if (m.Msg != WM_NCHITTEST) return;
            int HTCLIENT = 1;
            int HTCAPTION = 2;
            if (m.Result.ToInt32() == HTCLIENT)
                m.Result = (IntPtr)HTCAPTION;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            tweaks tweaks = new tweaks();
            panel2.Controls.Add(tweaks);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            tweaks2 tweaks2 = new tweaks2();
            panel2.Controls.Add(tweaks2);
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Startupmanager startupmanager = new Startupmanager();
            panel2.Controls.Clear();
            panel2.Controls.Add(startupmanager);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            InformationCenter informationcenter = new InformationCenter();
            panel2.Controls.Add(informationcenter);


        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        //minimize
        private void button9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Display Processor information on status bar
            toolStripStatusLabel2.Text = System.Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER");
            RegistryKey processor_name = Registry.LocalMachine.OpenSubKey(@"Hardware\Description\System\CentralProcessor\0", RegistryKeyPermissionCheck.ReadSubTree);   //This registry entry contains entry for processor info.
            if (processor_name != null)
            {

                if (processor_name.GetValue("ProcessorNameString") != null)
                {
                    //Display processor information.
                    toolStripStatusLabel1.Text = processor_name.GetValue("ProcessorNameString").ToString();
                }

            }

        }
    }
}
