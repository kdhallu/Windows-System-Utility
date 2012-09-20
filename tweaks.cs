using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;


namespace ADVallignment
{
    public partial class tweaks : UserControl
    {
        public tweaks()
        {
            InitializeComponent();
            label1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ///Open cmd from here code starts here....
            if (checkBox1.Checked == true)
            {
                try
                {
                    label1.Text = "Working....";
                    Registry.ClassesRoot.CreateSubKey("Directory\\shell\\Command Prompt Here");
                    RegistryKey testkey = Registry.ClassesRoot.OpenSubKey("Directory\\shell\\Command Prompt Here", true);
                    testkey.SetValue("", "Open Command Prompt here", RegistryValueKind.String);
                    Registry.ClassesRoot.CreateSubKey("Directory\\shell\\Command Prompt Here\\command");
                    testkey = Registry.ClassesRoot.OpenSubKey("Directory\\shell\\Command Prompt Here\\command", true);
                    testkey.SetValue("", "cmd.exe /k cd %1 ", RegistryValueKind.String);
                }
                catch (ArgumentException)
                { }


                catch (Exception opncmd)
                {
                    label1.Text = "" + opncmd.ToString();               
                }
            }
            label1.Text = "";

            if (checkBox1.Checked == false)
            {
                try
                {
                    label1.ForeColor = Color.Green;
                    label1.Text = "Working....";
                    RegistryKey testkey = Registry.ClassesRoot.OpenSubKey("Directory\\shell", true);
                    testkey.DeleteSubKeyTree("Command Prompt Here");
                }
                catch (ArgumentException)
                { }

                catch (Exception opencmd)
                {

                    label1.Text = "" + opencmd.ToString();
                }
            }
            label1.Text = "";
            /////Open cmd from here ends here


            if (checkBox2.Checked == true)
            {
                try
                {
                    label1.ForeColor = Color.Green;
                    label1.Text = "Working....";
                    Registry.ClassesRoot.CreateSubKey("*\\shell\\Open with Notepad");
                    RegistryKey testkey = Registry.ClassesRoot.OpenSubKey("\\*\\shell\\Open with Notepad", true);
                    testkey.SetValue("Default", "notepad.exe %1", RegistryValueKind.String);
                }
                catch (ArgumentException)
                { }
                //Err or exception goes here
                catch (Exception opwntp)
                {
                      MessageBox.Show("" + opwntp);
                }
            }

            if (checkBox2.Checked == false)
            {
                try
                {
                    label1.ForeColor = Color.Green;
                    label1.Text = "Working....";
                    RegistryKey testkey = Registry.ClassesRoot.OpenSubKey("\\*\\shell", true);
                    testkey.DeleteSubKeyTree("Open with Notepad");

                }
                catch (ArgumentException)
                { }
                //Err or exception goes here
                catch (Exception opwntp)
                {
                    MessageBox.Show("" + opwntp);
                }
            }
            //Open with notepad finishes here

            


            //Code to disable taskmanager....

            if (checkBox3.Checked == true)
            {
                RegistryKey taskmankey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies", true);
                taskmankey.CreateSubKey("System");
                taskmankey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true);
                try
                {
                    taskmankey.SetValue("DisableTaskMgr", "1", RegistryValueKind.DWord);
                }
                catch (ArgumentException)
                { }
                catch (Exception taskmandis)
                {
                    label1.Text = "" + taskmandis.ToString();
                }
            }


            if (checkBox3.Checked == false)
            {
                RegistryKey taskmankey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true);
                try
                {
                    taskmankey.SetValue("DisableTaskMgr", "0", RegistryValueKind.DWord);
                }
                catch (ArgumentException)
                { }
                catch (Exception taskmandis)
                {
                    label1.Text = "" + taskmandis.ToString();
                }
            }
            /*
             
            //Add UserPasswords2 in control panel
            if (checkBox4.Checked == true)
            {
                RegistryKey usercp2 = Registry.ClassesRoot.OpenSubKey("CLSID", true);
                try
                {
                    usercp2.CreateSubKey("{98641F47-8C25-4936-BEE4-C2CE1298969D}");
                    usercp2 = Registry.ClassesRoot.OpenSubKey("CLSID\\{98641F47-8C25-4936-BEE4-C2CE1298969D}", true);
                    usercp2.SetValue("", "User Accounts2 ");
                    usercp2.SetValue("InfoTip", "Starts The Windows 2000 style User Accounts dialog");
                    usercp2.CreateSubKey("DefaultIcon");
                    usercp2.CreateSubKey("Shell");
                    usercp2 = Registry.ClassesRoot.OpenSubKey("CLSID\\{98641F47-8C25-4936-BEE4-C2CE1298969D}\\Shell", true);
                    usercp2.CreateSubKey("Open");
                    usercp2 = Registry.ClassesRoot.OpenSubKey("CLSID\\{98641F47-8C25-4936-BEE4-C2CE1298969D}\\Shell\\Open", true);
                    usercp2.CreateSubKey("command");
                    usercp2 = Registry.ClassesRoot.OpenSubKey("CLSID\\{98641F47-8C25-4936-BEE4-C2CE1298969D}\\Shell\\Open\\command", true);
                    usercp2.SetValue("", "Control Userpasswords2");
                    usercp2 = Registry.ClassesRoot.OpenSubKey("CLSID\\{98641F47-8C25-4936-BEE4-C2CE1298969D}\\DefaultIcon", true);
                    usercp2.SetValue("", "%SystemRoot%\\\\System32\\\\nusrwerdmgr.cpl,1");
                }

                catch (Exception usercp2exec)
                {
                    // MessageBox.Show(usercp2exec.ToString());
                }
            }

            if (checkBox4.Checked == false)
            {
                RegistryKey usercp2 = Registry.ClassesRoot.OpenSubKey("CLSID", true);
                try
                {
                    usercp2.CreateSubKey("{98641F47-8C25-4936-BEE4-C2CE1298969D}");
                    usercp2 = Registry.ClassesRoot.OpenSubKey("CLSID\\{98641F47-8C25-4936-BEE4-C2CE1298969D}", true);
                    usercp2.SetValue("", "");
                    usercp2.SetValue("", "");
                    usercp2.CreateSubKey("DefaultIcon");
                    usercp2.CreateSubKey("Shell");
                    usercp2 = Registry.ClassesRoot.OpenSubKey("CLSID\\{98641F47-8C25-4936-BEE4-C2CE1298969D}\\Shell", true);
                    usercp2.CreateSubKey("Open");
                    usercp2 = Registry.ClassesRoot.OpenSubKey("CLSID\\{98641F47-8C25-4936-BEE4-C2CE1298969D}\\Shell\\Open", true);
                    usercp2.CreateSubKey("command");
                    usercp2 = Registry.ClassesRoot.OpenSubKey("CLSID\\{98641F47-8C25-4936-BEE4-C2CE1298969D}\\Shell\\Open\\command", true);
                    usercp2.SetValue("", "");
                    usercp2 = Registry.ClassesRoot.OpenSubKey("CLSID\\{98641F47-8C25-4936-BEE4-C2CE1298969D}\\DefaultIcon", true);
                    usercp2.SetValue("", "");
                }
                catch (Exception usercp2exec)
                {
                    //MessageBox.Show(usercp2exec.ToString());
                }
            }

            */


            //Ballon tip code
            if (checkBox5.Checked == true)
            {
                try
                {
                    RegistryKey boltip = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true);
                    //MessageBox.Show(boltip.GetValueKind("EnableBalloonTips").ToString());
                    boltip.SetValue("EnableBalloonTips", "0", RegistryValueKind.DWord);
                }
                catch (ArgumentException)
                { }
                catch (Exception btiperr)
                {
                    //MessageBox.Show("Boo erro occured" + btiperr);
                }

            }
           
            if (checkBox5.Checked == false)
            {
                try
                {
                    RegistryKey boltip = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true);
                    boltip.SetValue("EnableBalloonTips", "1", RegistryValueKind.DWord);
                }
                catch (ArgumentException)
                { }
                catch (Exception btiperr)
                {
                    // MessageBox.Show("Boo erro occured" + btiperr);
                }
            }

            //disable ballon tip code finishes here

            //code to add registry editor in control panel
            if (checkBox6.Checked == true)
            {
                try
                {
                    RegistryKey regedcp = Registry.ClassesRoot.OpenSubKey("CLSID", true);
                    regedcp.CreateSubKey("{77708248-f839-436b-8919-527c410f48b9}");
                    regedcp = Registry.ClassesRoot.OpenSubKey("CLSID\\{77708248-f839-436b-8919-527c410f48b9}", true);
                    regedcp.SetValue("", "Registry Editor", RegistryValueKind.String);
                    regedcp.SetValue("InfoTip", "Starts the Registry Editor", RegistryValueKind.String);
                    regedcp.SetValue("System.ControlPanel.Category", "5", RegistryValueKind.String);
                    regedcp = Registry.ClassesRoot.OpenSubKey("CLSID\\{77708248-f839-436b-8919-527c410f48b9}", true);
                    regedcp.CreateSubKey("DefaultIcon");
                    regedcp.CreateSubKey("Shell");
                    regedcp = Registry.ClassesRoot.OpenSubKey("CLSID\\{77708248-f839-436b-8919-527c410f48b9}\\DefaultIcon", true);
                    regedcp.SetValue("", "%SYSTEMROOT%\\regedit.exe", RegistryValueKind.String);
                    regedcp = Registry.ClassesRoot.OpenSubKey("CLSID\\{77708248-f839-436b-8919-527c410f48b9}\\Shell", true);
                    regedcp.CreateSubKey("Open");
                    regedcp = Registry.ClassesRoot.OpenSubKey("CLSID\\{77708248-f839-436b-8919-527c410f48b9}\\Shell\\Open", true);
                    regedcp.CreateSubKey("Command");
                    regedcp = Registry.ClassesRoot.OpenSubKey("CLSID\\{77708248-f839-436b-8919-527c410f48b9}\\Shell\\Open\\Command", true);
                    // MessageBox.Show(""+regedcp.GetValueKind(""));
                    regedcp.SetValue("", "%SystemRoot%\\regedit.exe", RegistryValueKind.ExpandString);
                    regedcp = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\ControlPanel\\NameSpace", true);
                    regedcp.CreateSubKey("{77708248-f839-436b-8919-527c410f48b9}");
                    regedcp = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\ControlPanel\\NameSpace\\{77708248-f839-436b-8919-527c410f48b9}", true);
                    regedcp.SetValue("", "Add Registry Editor to Control Panel", RegistryValueKind.String);
                }
                catch (Exception regedcperr)
                {
                    MessageBox.Show("" + regedcperr);
                }

            }

            if (checkBox6.Checked == false)
            {
                try
                {
                    RegistryKey regedcp = Registry.ClassesRoot.OpenSubKey("CLSID", true);
                    regedcp.DeleteSubKeyTree("{77708248-f839-436b-8919-527c410f48b9}");
                    /* regedcp = Registry.ClassesRoot.OpenSubKey("CLSID\\{77708248-f839-436b-8919-527c410f48b9}", true);
                        regedcp.SetValue("", "Registry Editor", RegistryValueKind.String);
                regedcp.SetValue("InfoTip", "Starts the Registry Editor", RegistryValueKind.String);
                regedcp.SetValue("System.ControlPanel.Category", "5", RegistryValueKind.String);
                regedcp = Registry.ClassesRoot.OpenSubKey("CLSID\\{77708248-f839-436b-8919-527c410f48b9}", true);
                regedcp.CreateSubKey("DefaultIcon");
                regedcp.CreateSubKey("Shell");
                regedcp = Registry.ClassesRoot.OpenSubKey("CLSID\\{77708248-f839-436b-8919-527c410f48b9}\\DefaultIcon", true);
                regedcp.SetValue("", "%SYSTEMROOT%\\regedit.exe", RegistryValueKind.String);
                regedcp = Registry.ClassesRoot.OpenSubKey("CLSID\\{77708248-f839-436b-8919-527c410f48b9}\\Shell", true);
                regedcp.CreateSubKey("Open");
                regedcp = Registry.ClassesRoot.OpenSubKey("CLSID\\{77708248-f839-436b-8919-527c410f48b9}\\Shell\\Open", true);
                regedcp.CreateSubKey("Command");
                regedcp = Registry.ClassesRoot.OpenSubKey("CLSID\\{77708248-f839-436b-8919-527c410f48b9}\\Shell\\Open\\Command", true);
                // MessageBox.Show(""+regedcp.GetValueKind(""));
                regedcp.SetValue("", "%SystemRoot%\\regedit.exe", RegistryValueKind.ExpandString);*/
                    regedcp = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\ControlPanel\\NameSpace", true);
                    regedcp.DeleteSubKeyTree("{77708248-f839-436b-8919-527c410f48b9}");
                }
                catch (Exception regedcperr)
                {// MessageBox.Show("" + regedcperr); 
                }
            }


            //Add ownership code goes 
            if (checkBox7.Checked == true)
            {

                RegistryKey takonsmycom = Registry.ClassesRoot.OpenSubKey("*\\shell\\", true);
                takonsmycom.CreateSubKey("runas");
                takonsmycom = Registry.ClassesRoot.OpenSubKey("*\\shell\\runas", true);
                takonsmycom.SetValue("", "Take Ownership", RegistryValueKind.String);
                takonsmycom.SetValue("NoWorkingDirectory", "", RegistryValueKind.String);
                takonsmycom.CreateSubKey("command");
                takonsmycom = Registry.ClassesRoot.OpenSubKey("*\\shell\\runas\\command", true);
                takonsmycom.SetValue("", "cmd.exe /c takeown /f \"%1\" && icacls \"%1\" /grant administrators:F", RegistryValueKind.String);
                takonsmycom.SetValue("IsolatedCommand", "cmd.exe /c takeown /f \"%1\" && icacls \"%1\" /grant administrators:F", RegistryValueKind.String);

                takonsmycom = Registry.ClassesRoot.OpenSubKey("Directory\\shell", true);
                takonsmycom.CreateSubKey("runas");
                takonsmycom = Registry.ClassesRoot.OpenSubKey("Directory\\shell\\runas", true);
                takonsmycom.SetValue("", "Take Ownership", RegistryValueKind.String);
                takonsmycom.SetValue("NoWorkingDirectory", "", RegistryValueKind.String);
                takonsmycom.CreateSubKey("command");
                takonsmycom = Registry.ClassesRoot.OpenSubKey("Directory\\shell\\runas\\command", true);
                takonsmycom.SetValue("", "cmd.exe /c takeown /f \"%1\" /r /d y && icacls \"%1\" /grant administrators:F /t", RegistryValueKind.String);
                takonsmycom.SetValue("IsolatedCommand", "cmd.exe /c takeown /f \"%1\" /r /d y && icacls \"%1\" /grant administrators:F /t", RegistryValueKind.String);
                takonsmycom.Close();


            }

            if (checkBox7.Checked == false)
            {
                try
                {

                    RegistryKey takonsmycom = Registry.ClassesRoot.OpenSubKey("*\\shell", true);
                    takonsmycom.DeleteSubKeyTree("runas");


                   
                    takonsmycom.Close();
                }
                catch (Exception)
                { }
            }




            //add recycle bin in my computer

            if (checkBox8.Checked == true)
            {
                try
                {
                    RegistryKey recbinmc = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace", true);
                    recbinmc.CreateSubKey("{645FF040-5081-101B-9F08-00AA002F954E}");
                }

                catch (Exception recbinmc)
                { //MessageBox.Show(recbinmc.ToString()); }

                }
            }
                if (checkBox8.Checked == false)
                {
                    try
                    {
                        RegistryKey recbinmc2 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace", true);
                        recbinmc2.DeleteSubKeyTree("{645FF040-5081-101B-9F08-00AA002F954E}");
                    }

                    catch (Exception recbinmc)
                    { //MessageBox.Show(recbinmc.ToString()); 
                    }
                }


                //add encrypt in right click context
                if (checkBox9.Checked == true)
                {
                    try
                    {
                        RegistryKey encrghtc = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true);
                        encrghtc.SetValue("EncryptionContextMenu", "1", RegistryValueKind.DWord);
                    }
                    catch
                    { }
                }

                if (checkBox9.Checked == false)
                {
                    try
                    {
                        RegistryKey encrghtc = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true);
                        encrghtc.SetValue("EncryptionContextMenu", "0", RegistryValueKind.DWord);
                    }
                    catch { }

                }

            //add encrypt in right click is gone now...

                if (checkBox10.Checked == true)
                {
                    RegistryKey Adcptandmt = Registry.ClassesRoot.OpenSubKey("AllFilesystemObjects\\shellex\\ContextMenuHandlers", true);
                    Adcptandmt.CreateSubKey("Copy To");
                    Adcptandmt = Registry.ClassesRoot.OpenSubKey("AllFilesystemObjects\\shellex\\ContextMenuHandlers\\Copy To",true);
                    Adcptandmt.SetValue("", "{C2FBB630-2971-11D1-A18C-00C04FD75D13}", RegistryValueKind.String);

                    Adcptandmt = Registry.ClassesRoot.OpenSubKey("AllFilesystemObjects\\shellex\\ContextMenuHandlers", true);
                    Adcptandmt.CreateSubKey("Move To");
                    Adcptandmt = Registry.ClassesRoot.OpenSubKey("AllFilesystemObjects\\shellex\\ContextMenuHandlers\\Move To",true);
                    Adcptandmt.SetValue("", "{C2FBB631-2971-11D1-A18C-00C04FD75D13}", RegistryValueKind.String);
                    Adcptandmt.Close();
                }

                if (checkBox10.Checked == false)
                {
                    RegistryKey Adcptandmt = Registry.ClassesRoot.OpenSubKey("AllFilesystemObjects\\shellex\\ContextMenuHandlers", true);
                    try
                    {
                        Adcptandmt.DeleteSubKey("Copy To");
                        Adcptandmt.DeleteSubKey("Move To");
                    }
                    catch
                    {

                    }
                    Adcptandmt.Close();
                }

                if (checkBox11.Checked == true)
                {
                    RegistryKey simpcntwin = Registry.ClassesRoot.OpenSubKey("CLSID", true);
                    simpcntwin.CreateSubKey("{FD4DF9E0-E3DE-11CE-BFCF-ABCD1DE12345}");
                    simpcntwin = Registry.ClassesRoot.OpenSubKey("CLSID\\{FD4DF9E0-E3DE-11CE-BFCF-ABCD1DE12345}", true);
                    simpcntwin.CreateSubKey("DefaultIcon");
                    simpcntwin.CreateSubKey("InProcServer32");
                    simpcntwin.CreateSubKey("Shell");
                    simpcntwin.CreateSubKey("ShellEx");
                    simpcntwin.CreateSubKey("ShellFolder");
                    simpcntwin = Registry.ClassesRoot.OpenSubKey("CLSID\\{FD4DF9E0-E3DE-11CE-BFCF-ABCD1DE12345}\\DefaultIcon", true);
                    simpcntwin.SetValue("", "shell32.dll,1", RegistryValueKind.String);
                    simpcntwin.SetValue("ThreadingModel", "Apartment", RegistryValueKind.String);
                    simpcntwin = Registry.ClassesRoot.OpenSubKey("CLSID\\{FD4DF9E0-E3DE-11CE-BFCF-ABCD1DE12345}\\Shell", true);
                    simpcntwin.CreateSubKey("Open My Folder");
                    simpcntwin = Registry.ClassesRoot.OpenSubKey("CLSID\\{FD4DF9E0-E3DE-11CE-BFCF-ABCD1DE12345}\\Shell\\Open My Folder", true);
                    simpcntwin.CreateSubKey("Command");
                    simpcntwin = Registry.ClassesRoot.OpenSubKey("CLSID\\{FD4DF9E0-E3DE-11CE-BFCF-ABCD1DE12345}\\Shell\\Open My Folder\\Command", true);
                    simpcntwin.SetValue("", "explorer /root,c:\\advt.{ED7BA470-8E54-465E-825C-99712043E01C}", RegistryValueKind.String);
                    simpcntwin = Registry.ClassesRoot.OpenSubKey("CLSID\\{FD4DF9E0-E3DE-11CE-BFCF-ABCD1DE12345}\\ShellEx", true);
                    simpcntwin.CreateSubKey("PropertySheetHandlers");
                    simpcntwin = Registry.ClassesRoot.OpenSubKey("CLSID\\{FD4DF9E0-E3DE-11CE-BFCF-ABCD1DE12345}\\ShellEx\\PropertySheetHandlers", true);
                    simpcntwin.CreateSubKey("{FD4DF9E0-E3DE-11CE-BFCF-ABCD1DE12345}");
                    simpcntwin = Registry.ClassesRoot.OpenSubKey("CLSID\\{FD4DF9E0-E3DE-11CE-BFCF-ABCD1DE12345}\\ShellFolder", true);
                    simpcntwin.SetValue("", new byte[] { 0, 0, 0, 0 }, RegistryValueKind.Binary);
                    simpcntwin = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace", true);
                    simpcntwin.CreateSubKey("{FD4DF9E0-E3DE-11CE-BFCF-ABCD1DE12345}");
                    }


                if (checkBox11.Checked == false)
                {
                    try
                    {

                        RegistryKey simpcntwin = Registry.ClassesRoot.OpenSubKey("CLSID", true);
                        simpcntwin.DeleteSubKeyTree("{FD4DF9E0-E3DE-11CE-BFCF-ABCD1DE12345}");
                        simpcntwin = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace", true);
                        simpcntwin.DeleteSubKey("{FD4DF9E0-E3DE-11CE-BFCF-ABCD1DE12345}");
                    }
                    catch (Exception)
                    { }
                }

            ///




















            label1.ForeColor = Color.Green;
            label1.Text = "Idle....";
        }
        
    }
}
