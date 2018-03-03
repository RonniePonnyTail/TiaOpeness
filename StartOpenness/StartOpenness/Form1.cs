using Microsoft.Win32;
using Siemens.Engineering;
using Siemens.Engineering.Compiler;
using Siemens.Engineering.Hmi;
using Siemens.Engineering.HW;
using Siemens.Engineering.HW.Features;
using Siemens.Engineering.SW;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Siemens.Engineering.SW.Blocks;
using Siemens.Engineering.SW.ExternalSources;
using Siemens.Engineering.SW.Tags;
using Siemens.Engineering.SW.Types;
using HmiTarget = Siemens.Engineering.Hmi.HmiTarget;
using Siemens.Engineering.Hmi.Tag;
using Siemens.Engineering.Hmi.Screen;
using Siemens.Engineering.Hmi.Cycle;
using Siemens.Engineering.Hmi.Communication;
using Siemens.Engineering.Hmi.Globalization;
using Siemens.Engineering.Hmi.TextGraphicList;
using Siemens.Engineering.Hmi.RuntimeScripting;
using Siemens.Engineering.Library;
using Siemens.Engineering.Cax;

namespace StartOpenness
{
    public partial class Form1 : Form
    {

        private static TiaPortalProcess _tiaProcess;

        public TiaPortal MyTiaPortal
        {
            get; set;
        }
        public Project MyProject
        {
            get; set;
        }


        public Form1()
        {
            InitializeComponent();
            AppDomain CurrentDomain = AppDomain.CurrentDomain;
            CurrentDomain.AssemblyResolve += new ResolveEventHandler(MyResolver);
        }

        private static Assembly MyResolver(object sender, ResolveEventArgs args)
        {
            int index = args.Name.IndexOf(',');
            if (index == -1)
            {
                return null;
            }
            string name = args.Name.Substring(0, index);

            RegistryKey filePathReg = Registry.LocalMachine.OpenSubKey(
                "SOFTWARE\\Siemens\\Automation\\Openness\\14.0\\PublicAPI\\14.0.1.0");

            object oRegKeyValue = filePathReg?.GetValue(name);
            if (oRegKeyValue != null)
            {
                string filePath = oRegKeyValue.ToString();

                string path = filePath;
                string fullPath = Path.GetFullPath(path);
                if (File.Exists(fullPath))
                {
                    return Assembly.LoadFrom(fullPath);
                }
            }

            return null;
        }


        private void StartTIA(object sender, EventArgs e)
        {
            if (rdb_WithoutUI.Checked == true)
            {
                MyTiaPortal = new TiaPortal(TiaPortalMode.WithoutUserInterface);
                txt_Status.Text = "TIA Portal started without user interface";
                _tiaProcess = TiaPortal.GetProcesses()[0];
            }
            else
            {
                MyTiaPortal = new TiaPortal(TiaPortalMode.WithUserInterface);
                txt_Status.Text = "TIA Portal started with user interface";
            }

            btn_SearchProject.Enabled = true;
            btn_Dispose.Enabled = true;
            btn_Start.Enabled = false;
            btnCreateProject.Enabled = true;

        }

        private void DisposeTIA(object sender, EventArgs e)
        {
            MyTiaPortal.Dispose();
            txt_Status.Text = "TIA Portal disposed";

            btn_Start.Enabled = true;
            btn_Dispose.Enabled = false;
            btn_CloseProject.Enabled = false;
            btn_SearchProject.Enabled = false;
            btn_CompileHW.Enabled = false;
            btn_Save.Enabled = false;
            btnCreateProject.Enabled = false;
            btnExportBlocks.Enabled = false;
            btnExportTagTables.Enabled = false;
            btnImportBlock.Enabled = false;
            btnImportTagTables.Enabled = false;
            btnImportUDT.Enabled = false;
            btnExportUDT.Enabled = false;
            btnHWConfig.Enabled = false;


        }

        private void SearchProject(object sender, EventArgs e)
        {

            OpenFileDialog fileSearch = new OpenFileDialog();

            fileSearch.Filter = "*.ap14|*.ap14";
            fileSearch.RestoreDirectory = true;
            fileSearch.ShowDialog();

            string ProjectPath = fileSearch.FileName.ToString();

            if (string.IsNullOrEmpty(ProjectPath) == false)
            {
                OpenProject(ProjectPath);
            }
        }

        private void OpenProject(string ProjectPath)
        {
            try
            {
                MyProject = MyTiaPortal.Projects.Open(new FileInfo(ProjectPath));
                txt_Status.Text = "Project " + ProjectPath + " opened";

            }
            catch (Exception ex)
            {
                txt_Status.Text = "Error while opening project" + ex.Message;
            }

            btn_CompileHW.Enabled = true;
            btn_CloseProject.Enabled = true;
            btn_SearchProject.Enabled = false;
            btn_Save.Enabled = true;
            btn_AddHW.Enabled = true;
            btnCreateProject.Enabled = false;
            btnExportBlocks.Enabled = true;
            btnExportTagTables.Enabled = true;
            btnImportBlock.Enabled = true;
            btnImportTagTables.Enabled = true;
            btnImportUDT.Enabled = true;
            btnExportUDT.Enabled = true;
            btnHWConfig.Enabled = true;
        }

        private void SaveProject(object sender, EventArgs e)
        {
            MyProject.Save();
            txt_Status.Text = "Project saved";
        }


        private void CloseProject(object sender, EventArgs e)
        {
            MyProject.Close();

            txt_Status.Text = "Project closed";

            btn_SearchProject.Enabled = true;
            btn_CloseProject.Enabled = false;
            btn_Save.Enabled = false;
            btn_CompileHW.Enabled = false;
            btnCreateProject.Enabled = true;
            btnExportBlocks.Enabled = false;
            btnExportTagTables.Enabled = false;
            btnImportBlock.Enabled = false;
            btnImportTagTables.Enabled = false;
            btnImportUDT.Enabled = false;
            btnExportUDT.Enabled = false;
            btnHWConfig.Enabled = false;


        }

        private void Compile(object sender, EventArgs e)
        {
            btn_CompileHW.Enabled = false;

            string devname = txt_Device.Text;
            bool found = false;

            foreach (Device device in MyProject.Devices)
            {
                DeviceItemComposition deviceItemAggregation = device.DeviceItems;
                foreach (DeviceItem deviceItem in deviceItemAggregation)
                {
                    if (deviceItem.Name == devname || device.Name == devname)
                    {
                        SoftwareContainer softwareContainer = deviceItem.GetService<SoftwareContainer>();
                        if (softwareContainer != null)
                        {
                            if (softwareContainer.Software is PlcSoftware)
                            {
                                PlcSoftware controllerTarget = softwareContainer.Software as PlcSoftware;
                                if (controllerTarget != null)
                                {
                                    found = true;
                                    ICompilable compiler = controllerTarget.GetService<ICompilable>();

                                    CompilerResult result = compiler.Compile();
                                    txt_Status.Text = "Compiling of " + controllerTarget.Name + ": State: " + result.State + " / Warning Count: " + result.WarningCount + " / Error Count: " + result.ErrorCount;

                                }
                            }
                            if (softwareContainer.Software is HmiTarget)
                            {
                                HmiTarget hmitarget = softwareContainer.Software as HmiTarget;
                                if (hmitarget != null)
                                {
                                    found = true;
                                    ICompilable compiler = hmitarget.GetService<ICompilable>();
                                    CompilerResult result = compiler.Compile();
                                    txt_Status.Text = "Compiling of " + hmitarget.Name + ": State: " + result.State + " / Warning Count: " + result.WarningCount + " / Error Count: " + result.ErrorCount;
                                }

                            }
                        }
                    }
                }
            }
            if (found == false)
            {
                txt_Status.Text = "Found no device with name " + txt_Device.Text;
            }

            btn_CompileHW.Enabled = true;
        }

        private void btn_AddHW_Click(object sender, EventArgs e)
        {
            btn_AddHW.Enabled = false;
            string MLFB = "OrderNumber:" + txt_OrderNo.Text + "/" + txt_Version.Text;

            string name = txt_AddDevice.Text;
            string devname = "station" + txt_AddDevice.Text;
            bool found = false;
            foreach (Device device in MyProject.Devices)
            {
                DeviceItemComposition deviceItemAggregation = device.DeviceItems;
                foreach (DeviceItem deviceItem in deviceItemAggregation)
                {
                    if (deviceItem.Name == devname || device.Name == devname)
                    {
                        SoftwareContainer softwareContainer = deviceItem.GetService<SoftwareContainer>();
                        if (softwareContainer != null)
                        {
                            if (softwareContainer.Software is PlcSoftware)
                            {
                                PlcSoftware controllerTarget = softwareContainer.Software as PlcSoftware;
                                if (controllerTarget != null)
                                {
                                    found = true;

                                }
                            }
                            if (softwareContainer.Software is HmiTarget)
                            {
                                HmiTarget hmitarget = softwareContainer.Software as HmiTarget;
                                if (hmitarget != null)
                                {
                                    found = true;

                                }

                            }
                        }
                    }
                }
            }
            if (found == true)
            {
                txt_Status.Text = "Device " + txt_Device.Text + " already exists";
            }
            else
            {
                Device deviceName = MyProject.Devices.CreateWithItem(MLFB, name, devname);

                txt_Status.Text = "Add Device Name: " + name + " with Order Number: " + txt_OrderNo.Text + " and Firmware Version: " + txt_Version.Text;
            }

            btn_AddHW.Enabled = true;

        }

        private Software GetDevice(Project project, string MLFB, string name, string devname)
        {
            foreach (Device device in project.Devices)
            {
                DeviceItemComposition deviceItemAggregation = device.DeviceItems;
                foreach (DeviceItem deviceItem in deviceItemAggregation)
                {
                    if (deviceItem.Name == devname || device.Name == devname)
                    {
                        SoftwareContainer softwareContainer = deviceItem.GetService<SoftwareContainer>();
                        if (softwareContainer != null)
                        {
                            if (softwareContainer.Software is PlcSoftware)
                            {
                                return softwareContainer.Software as PlcSoftware;
                            }
                            if (softwareContainer.Software is HmiTarget)
                            {
                                return softwareContainer.Software as HmiTarget;
                            }
                        }
                    }
                }
            }
            return null;

        }

        private void btn_ConnectTIA(object sender, EventArgs e)
        {
            btn_Connect.Enabled = false;
            IList<TiaPortalProcess> processes = TiaPortal.GetProcesses();
            switch (processes.Count)
            {
                case 1:
                    _tiaProcess = processes[0];
                    MyTiaPortal = _tiaProcess.Attach();
                    if (MyTiaPortal.GetCurrentProcess().Mode == TiaPortalMode.WithUserInterface)
                    {
                        rdb_WithUI.Checked = true;
                    }
                    else
                    {
                        rdb_WithoutUI.Checked = true;
                    }


                    if (MyTiaPortal.Projects.Count <= 0)
                    {
                        txt_Status.Text = "No TIA Portal Project was found!";
                        btn_Connect.Enabled = true;
                        return;
                    }
                    MyProject = MyTiaPortal.Projects[0];
                    break;
                case 0:
                    txt_Status.Text = "No running instance of TIA Portal was found!";
                    btn_Connect.Enabled = true;
                    return;
                default:
                    txt_Status.Text = "More than one running instance of TIA Portal was found!";
                    btn_Connect.Enabled = true;
                    return;
            }
            txt_Status.Text = _tiaProcess.ProjectPath.ToString();
            btn_Start.Enabled = false;
            btn_Connect.Enabled = true;
            btn_Dispose.Enabled = true;
            btn_CompileHW.Enabled = true;
            btn_CloseProject.Enabled = true;
            btn_SearchProject.Enabled = false;
            btn_Save.Enabled = true;
            btn_AddHW.Enabled = true;
            btnCreateProject.Enabled = false;
            btnExportBlocks.Enabled = true;
            btnExportTagTables.Enabled = true;
            btnImportBlock.Enabled = true;
            btnImportTagTables.Enabled = true;
            btnImportUDT.Enabled = true;
            btnExportUDT.Enabled = true;
            btnHWConfig.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txt_AddDevice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProjectName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_OrderNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateProject_Click(object sender, EventArgs e)
        {
            try
            {
                TiaPortal tiaPortal = MyTiaPortal;
                ProjectComposition projectComposition = tiaPortal.Projects;
                DirectoryInfo targetDirectory = new DirectoryInfo(@"C:\TiaProjects");
                Project project = projectComposition.Create(targetDirectory, txtProjectName.Text);
                txt_Status.Text = "Project created !";
            }
            catch (Exception ex)
            {
                txt_Status.Text = "Error while creating project, make sure you closed all projects before creating new one" + ex.Message;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        //****************************Export_Import_block**********************************************

        private void btnExportBlocks_Click(object sender, EventArgs e)
        {
            string MLFB = "OrderNumber:" + txt_OrderNo.Text + "/" + txt_Version.Text;

            string name = txt_AddDevice.Text;
            string devname = "station" + txt_AddDevice.Text;
   
            var plc = GetDevice(MyProject, MLFB, name, devname) as PlcSoftware;
            ExportRegularBlock(plc);
        }


        private static void ExportSystemBlocks(PlcSoftware plcsoftware)
        {
            try
            {
                PlcBlockGroup sbSystemGroup = plcsoftware.BlockGroup;
                foreach (PlcBlockGroup group in sbSystemGroup.Groups)
                {
                    foreach (PlcBlock block in group.Blocks)
                    {
                        block.Export(new FileInfo(string.Format(@"C:\test\" + block.Name + ".xml")), ExportOptions.WithDefaults);
                    }
                }
            }
           catch(Exception ex)
            {
                MessageBox.Show("Chyba: " + ex);
            }
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        
        //Exports a regular block
        private static void ExportRegularBlock(PlcSoftware plcSoftware)
        {
            try
            {
                foreach (PlcBlock block in plcSoftware.BlockGroup.Blocks)
                {
                    block.Export(new FileInfo(string.Format(@"C:\test\" + block.Name + ".xml")), ExportOptions.WithDefaults);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba: " + ex.Message);
            }
        }

        //Import blocks
        private static void ImportBlocks(PlcSoftware plcSoftware,string path)
        {
            try
            {
                // PlcBlockGroup blockGroup = plcSoftware.BlockGroup;
                // IList<PlcBlock> blocks = blockGroup.Blocks.Import(new FileInfo(path), ImportOptions.Override);
                PlcBlockGroup blockGroup = plcSoftware.BlockGroup;
                string[] files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);

                foreach (var block in files)
                {
                    IList<PlcBlock> blocks = blockGroup.Blocks.Import(new FileInfo(block), ImportOptions.Override);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba: " + ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string MLFB = "OrderNumber:" + txt_OrderNo.Text + "/" + txt_Version.Text;

            string name = txt_AddDevice.Text;
            string devname = "station" + txt_AddDevice.Text;

            var plc = GetDevice(MyProject, MLFB, name, devname) as PlcSoftware;
            ImportBlocks(plc, @"C:\test\");
        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        //****************************Export_IMport_tags**********************************************

        private void btnExportTagTables_Click(object sender, EventArgs e)
        {
            string MLFB = "OrderNumber:" + txt_OrderNo.Text + "/" + txt_Version.Text;

            string name = txt_AddDevice.Text;
            string devname = "station" + txt_AddDevice.Text;

            var plc = GetDevice(MyProject, MLFB, name, devname) as PlcSoftware;
            ExportAllTagTables(plc);
        }

        private static void ExportAllTagTables(PlcSoftware plcSoftware)
        {
            PlcTagTableSystemGroup plcTagTableSystemGroup = plcSoftware.TagTableGroup;
            // Export all tables in the system group
            ExportTagTables(plcTagTableSystemGroup.TagTables);
            // Export the tables in underlying user groups
            foreach (PlcTagTableUserGroup userGroup in plcTagTableSystemGroup.Groups)
            {
                ExportUserGroupDeep(userGroup);
            }
        }

        private static void ExportTagTables(PlcTagTableComposition tagTables)
        {
            try
            {
                foreach (PlcTagTable table in tagTables)
                {
                    table.Export(new FileInfo(string.Format(@"C:\testTables\" + table.Name + ".xml", table.Name)), ExportOptions.WithDefaults);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba: " + ex.Message);
            }
        }

        private static void ExportUserGroupDeep(PlcTagTableUserGroup group)
        {
            ExportTagTables(group.TagTables);
            foreach (PlcTagTableUserGroup userGroup in group.Groups)
            {
                ExportUserGroupDeep(userGroup);
            }
        }

        private void btnImportTagTables_Click(object sender, EventArgs e)
        {
            string MLFB = "OrderNumber:" + txt_OrderNo.Text + "/" + txt_Version.Text;

            string name = txt_AddDevice.Text;
            string devname = "station" + txt_AddDevice.Text;

            var plc = GetDevice(MyProject, MLFB, name, devname) as PlcSoftware;
            ImportTagTable(plc);
        }

        //Imports tag tables to the tag system group
        private static void ImportTagTable(PlcSoftware plcSoftware)
        {
            try
            {
                PlcTagTableSystemGroup plcTagTableSystemGroup = plcSoftware.TagTableGroup;
                PlcTagTableComposition tagTables = plcTagTableSystemGroup.TagTables;
                string[] files = Directory.GetFiles(@"C:\testTables\", "*", SearchOption.AllDirectories);

                foreach (var file in files)
                {
                    tagTables.Import(new FileInfo(file), ImportOptions.Override);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba: " + ex.Message);
            }

        }

        //****************************Export_IMport_UDT**********************************************
        //Exports a user defined type
        private static void ExportUserDefinedType(PlcSoftware plcSoftware)
        {
            try
            {
                string udtname = "udt";
                PlcTypeComposition types = plcSoftware.TypeGroup.Types;
                PlcType udt = types.Find(udtname);
                udt.Export(new FileInfo(string.Format(@"C:\testUDT\" + udt.Name + ".xml")), ExportOptions.WithDefaults);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba: " + ex.Message);
            }
        }

        private void btnExportUDT_Click(object sender, EventArgs e)
        {
            string MLFB = "OrderNumber:" + txt_OrderNo.Text + "/" + txt_Version.Text;

            string name = txt_AddDevice.Text;
            string devname = "station" + txt_AddDevice.Text;

            var plc = GetDevice(MyProject, MLFB, name, devname) as PlcSoftware;
            ExportUserDefinedType(plc);
        }

        //Imports user data type
        private static void ImportUserDataType(PlcSoftware plcSoftware)
        {
            try
            {
                FileInfo fullFilePath = new FileInfo(@"C:\testUDT\udt.xml");
                PlcTypeComposition types = plcSoftware.TypeGroup.Types;
                IList<PlcType> importedTypes = types.Import(fullFilePath, ImportOptions.Override);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba: " + ex.Message);
            }
        }

        private void btnImportUDT_Click(object sender, EventArgs e)
        {
            string MLFB = "OrderNumber:" + txt_OrderNo.Text + "/" + txt_Version.Text;

            string name = txt_AddDevice.Text;
            string devname = "station" + txt_AddDevice.Text;

            var plc = GetDevice(MyProject, MLFB, name, devname) as PlcSoftware;
            ImportUserDataType(plc);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //****************************Import HW config z AML - Selection tool**********************************************

        private void btnHWConfig_Click(object sender, EventArgs e)
        {
            try
            {
                CaxProvider caxProvider = MyProject.GetService<CaxProvider>();
                if (caxProvider != null)
                {
                    // Perform Cax export and import operation
                    caxProvider.Import(new FileInfo(@"C:\testHwConfig\Project.aml"), new FileInfo(@"C:\testHwConfig\Project.log"), CaxImportOptions.MoveToParkingLot);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Chyba: " + ex.Message);
            }
        }

        private void label5_Click_2(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private static void CreateBlockGroup(PlcSoftware plcsoftware, string nameofgroup)
        //Creates a block group
        {
            PlcBlockSystemGroup systemGroup = plcsoftware.BlockGroup;
            PlcBlockUserGroupComposition groupComposition = systemGroup.Groups;
            PlcBlockUserGroup myCreatedGroup = groupComposition.Create(nameofgroup);
        }

        private void btnGenerujStanice_Click(object sender, EventArgs e)
        {
            try
            {
                var pocetStanic = numBoxPocetStanic.Value;
                string MLFB = "OrderNumber:" + txt_OrderNo.Text + "/" + txt_Version.Text;
                string name = txt_AddDevice.Text;
                string devname = "station" + txt_AddDevice.Text;
                var plc = GetDevice(MyProject, MLFB, name, devname) as PlcSoftware;

                for (int i = 0; i < pocetStanic; i++)
                {
                    CreateBlockGroup(plc, "Stanice" + (i + 1));
                    ImportBlocks(plc, @""+txtBoxUmisteniBlokuStanic.Text);

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Chyba: " + ex);
            }
        }

        private void txtBoxPocetStanic_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            string folderPath = "";
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folderPath = folderBrowserDialog1.SelectedPath;
            }
            txtBoxUmisteniBlokuStanic.Text = folderPath;
        }
    }
}

