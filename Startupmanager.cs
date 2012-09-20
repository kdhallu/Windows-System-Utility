using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.IO;
using System.Windows.Forms;

namespace ADVallignment
{
    public partial class Startupmanager : UserControl
    {
        public Startupmanager()
        {
            InitializeComponent();
        }

        private void Startupmanager_Load(object sender, EventArgs e)
        {
            listView1.Clear();



            RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", false);
            foreach (string appName in key.GetValueNames())
            {
                try
                {
                    ListViewItem item1 = new ListViewItem();
                    item1.SubItems.Add(key.GetValue(appName).ToString());
                    item1.SubItems.Add(appName.ToString());
                    item1.SubItems.Add(key.Name);

                    listView1.Items.Add(item1);



                   /* listView1.Items[i].SubItems.Add("" + key.GetValue(appName));
                    ListViewItem item = listView1.Items.Add("" + appName.ToString());
                    listView1.Items[i].SubItems.Add("" + key.Name);
                    i++;*/
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            }

        }
    }
}
