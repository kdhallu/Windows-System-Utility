using System;
using Microsoft.Win32;
using System.Management.Instrumentation;
using System.Management;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace ADVallignment
{
    public partial class InformationCenter : UserControl
    {
        public InformationCenter()
        {
            InitializeComponent();
        }
        

        private void tabPage1_Click(object sender, EventArgs e)
        {
         
 
        }


        

        private void InformationCenter_Load(object sender, EventArgs e)
        {
            //Thread to refresh Processor values
            Thread Loadrefresh = new Thread(new ThreadStart(LoadUpdate));
            Loadrefresh.Start();

            


            Control.CheckForIllegalCrossThreadCalls = false;
            ToolTip proarchitecture = new ToolTip();

            //Operating system description
            ManagementObjectSearcher searcheros = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
            foreach (ManagementObject os in searcheros.Get())
            {
                label2.Text = os["Caption"].ToString();
                label4.Text = os["BuildNumber"].ToString();
                label6.Text = os["OSArchitecture"].ToString();
                label8.Text = os["BuildType"].ToString();
                label10.Text = os["Manufacturer"].ToString();
                label12.Text = os["NumberOfUsers"].ToString();
                label14.Text = os["RegisteredUser"].ToString();
                label16.Text = os["SerialNumber"].ToString();
            }

            //Processor goes here
            ManagementObjectSearcher searcherpros = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            foreach (ManagementObject os in searcherpros.Get())
            {
                label18.Text = os["Name"].ToString();
                label20.Text = os["Architecture"].ToString();
                proarchitecture.ToolTipTitle = "Description";
                proarchitecture.UseAnimation = true;
                proarchitecture.SetToolTip(label20,"0 means X86,1 means MIPS,2 Means Alpha,3 is PowerPc,5 is ARM,6 is Itanium-Based, 9 means X64");

                label22.Text = os["Availability"].ToString();
                label28.Text = os["DataWidth"].ToString();
                label30.Text = os["L2CacheSize"].ToString() + "KB";
                try { label32.Text = os["L2CacheSpeed"].ToString(); }
                catch (NullReferenceException)
                { label32.Text = "NA"; }
                label34.Text = os["L3CacheSize"].ToString() + "KB";
                try { label36.Text = os["L2CacheSpeed"].ToString(); }
                catch (NullReferenceException)
                { label36.Text = "NA"; }
                label38.Text = os["MaxClockSpeed"].ToString();
                label42.Text = os["NumberOfLogicalProcessors"].ToString();
                label44.Text = os["NumberOfCores"].ToString();
                try { label46.Text = os["Stepping"].ToString(); }
                catch (NullReferenceException) { label46.Text = "N/A"; }
            }

            //Ram Goes here

            ConnectionOptions connection = new ConnectionOptions();
            connection.Impersonation = ImpersonationLevel.Impersonate;

            ManagementScope scope = new ManagementScope("\\\\.\\root\\CIMV2", connection);

            scope.Connect();
            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_PhysicalMemory");

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
            foreach(ManagementObject queryObj in searcher.Get())

            {
                     double ram;
                ram = Convert.ToDouble(queryObj["Capacity"].ToString());

                label48.Text = (ram/1048576).ToString()+"Gb";

                
                label50.Text = queryObj["BankLabel"].ToString();
                label52.Text = queryObj["DataWidth"].ToString();
                label54.Text = queryObj["DeviceLocator"].ToString();
            label56.Text = queryObj["Manufacturer"].ToString();
            label58.Text = queryObj["PartNumber"].ToString();
            label60.Text = queryObj["SerialNumber"].ToString();
            label62.Text = queryObj["Speed"].ToString()+"MHz";
            try
            { label64.Text = queryObj["Version"].ToString(); }
            catch (Exception)
            { label64.Text = "Error Getting Values"; }

            }

             ManagementObjectSearcher displayinfo = new ManagementObjectSearcher("SELECT * FROM Win32_DisplayConfiguration");
             foreach (ManagementObject dpinfo in displayinfo.Get())
             {
                 

                 label66.Text = dpinfo["DeviceName"].ToString();
                 label68.Text = dpinfo["DisplayFrequency"].ToString()+"Hz";
                 label72.Text = dpinfo["DriverVersion"].ToString();

                
             }
             ManagementObjectSearcher displayinfocontroller = new ManagementObjectSearcher("SELECT AdapterRAM FROM Win32_VideoController");
             foreach (ManagementObject dispcont in displayinfocontroller.Get())
             {
                 int _ram = 0;
                 var ram =  dispcont.Properties["AdapterRAM"].Value as UInt32?;
                 if (ram.HasValue)
                 {
                     label70.Text = ((int)ram / 1048576).ToString() +"MB";
                 }
             }
            
            label74.Text = Screen.PrimaryScreen.Bounds.Width.ToString() + "X" + Screen.PrimaryScreen.Bounds.Height.ToString();


            ManagementObjectSearcher mc = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapter");
            foreach (ManagementObject mo in mc.Get())
            {
            
                
            }

                 
           



        }


        //Function to update the values....
        public void LoadUpdate()
        {
            while (true)
            {
                ManagementObjectSearcher searcherpros = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
                foreach (ManagementObject os in searcherpros.Get())
                {
                    try
                    {
                        label40.Text = os["LoadPercentage"].ToString() + "%";
                        label24.Text = os["CurrentClockSpeed"].ToString();
                        label26.Text = os["CurrentVoltage"].ToString();
                        Thread.Sleep(20);
                    }
                    catch (Exception)
                    { }
                   

                }

                
            }

        }

        private void label63_Click(object sender, EventArgs e)
        {

        }

        private void label64_Click(object sender, EventArgs e)
        {

        }
    }
}
