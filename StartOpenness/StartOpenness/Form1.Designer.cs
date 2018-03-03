using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Reflection;
using System.IO;

namespace StartOpenness
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_Dispose = new System.Windows.Forms.Button();
            this.btn_SearchProject = new System.Windows.Forms.Button();
            this.txt_Status = new System.Windows.Forms.TextBox();
            this.btn_CloseProject = new System.Windows.Forms.Button();
            this.btn_CompileHW = new System.Windows.Forms.Button();
            this.txt_Device = new System.Windows.Forms.TextBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.grp_TIA = new System.Windows.Forms.GroupBox();
            this.rdb_WithoutUI = new System.Windows.Forms.RadioButton();
            this.rdb_WithUI = new System.Windows.Forms.RadioButton();
            this.grp_Compile = new System.Windows.Forms.GroupBox();
            this.grp_Project = new System.Windows.Forms.GroupBox();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.btn_AddHW = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Version = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_OrderNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_AddDevice = new System.Windows.Forms.TextBox();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.lblProjectName = new System.Windows.Forms.Label();
            this.btnCreateProject = new System.Windows.Forms.Button();
            this.btnExportBlocks = new System.Windows.Forms.Button();
            this.btnImportBlock = new System.Windows.Forms.Button();
            this.lblEXPIMP = new System.Windows.Forms.Label();
            this.btnExportTagTables = new System.Windows.Forms.Button();
            this.btnImportTagTables = new System.Windows.Forms.Button();
            this.btnImportUDT = new System.Windows.Forms.Button();
            this.btnExportUDT = new System.Windows.Forms.Button();
            this.btnHWConfig = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblNastaveniStanic = new System.Windows.Forms.Label();
            this.lblPocetStanic = new System.Windows.Forms.Label();
            this.btnGenerujStanice = new System.Windows.Forms.Button();
            this.lblUmisteniBlokuStanic = new System.Windows.Forms.Label();
            this.txtBoxUmisteniBlokuStanic = new System.Windows.Forms.TextBox();
            this.numBoxPocetStanic = new System.Windows.Forms.NumericUpDown();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.grp_TIA.SuspendLayout();
            this.grp_Compile.SuspendLayout();
            this.grp_Project.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBoxPocetStanic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(36, 85);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(115, 36);
            this.btn_Start.TabIndex = 0;
            this.btn_Start.Text = "Start TIA";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.StartTIA);
            // 
            // btn_Dispose
            // 
            this.btn_Dispose.Enabled = false;
            this.btn_Dispose.Location = new System.Drawing.Point(36, 140);
            this.btn_Dispose.Name = "btn_Dispose";
            this.btn_Dispose.Size = new System.Drawing.Size(115, 36);
            this.btn_Dispose.TabIndex = 4;
            this.btn_Dispose.Text = "Dispose TIA";
            this.btn_Dispose.UseVisualStyleBackColor = true;
            this.btn_Dispose.Click += new System.EventHandler(this.DisposeTIA);
            // 
            // btn_SearchProject
            // 
            this.btn_SearchProject.Enabled = false;
            this.btn_SearchProject.Location = new System.Drawing.Point(38, 23);
            this.btn_SearchProject.Name = "btn_SearchProject";
            this.btn_SearchProject.Size = new System.Drawing.Size(115, 36);
            this.btn_SearchProject.TabIndex = 5;
            this.btn_SearchProject.Text = "Open Project";
            this.btn_SearchProject.UseVisualStyleBackColor = true;
            this.btn_SearchProject.Click += new System.EventHandler(this.SearchProject);
            // 
            // txt_Status
            // 
            this.txt_Status.BackColor = System.Drawing.SystemColors.Menu;
            this.txt_Status.Location = new System.Drawing.Point(12, 697);
            this.txt_Status.Name = "txt_Status";
            this.txt_Status.Size = new System.Drawing.Size(761, 20);
            this.txt_Status.TabIndex = 7;
            // 
            // btn_CloseProject
            // 
            this.btn_CloseProject.Enabled = false;
            this.btn_CloseProject.Location = new System.Drawing.Point(38, 152);
            this.btn_CloseProject.Name = "btn_CloseProject";
            this.btn_CloseProject.Size = new System.Drawing.Size(115, 36);
            this.btn_CloseProject.TabIndex = 8;
            this.btn_CloseProject.Text = "Close Project";
            this.btn_CloseProject.UseVisualStyleBackColor = true;
            this.btn_CloseProject.Click += new System.EventHandler(this.CloseProject);
            // 
            // btn_CompileHW
            // 
            this.btn_CompileHW.Enabled = false;
            this.btn_CompileHW.Location = new System.Drawing.Point(37, 85);
            this.btn_CompileHW.Name = "btn_CompileHW";
            this.btn_CompileHW.Size = new System.Drawing.Size(115, 36);
            this.btn_CompileHW.TabIndex = 12;
            this.btn_CompileHW.Text = "Compile";
            this.btn_CompileHW.UseVisualStyleBackColor = true;
            this.btn_CompileHW.Click += new System.EventHandler(this.Compile);
            // 
            // txt_Device
            // 
            this.txt_Device.Location = new System.Drawing.Point(37, 41);
            this.txt_Device.Name = "txt_Device";
            this.txt_Device.Size = new System.Drawing.Size(115, 20);
            this.txt_Device.TabIndex = 13;
            this.txt_Device.Text = "PLC_1";
            // 
            // btn_Save
            // 
            this.btn_Save.Enabled = false;
            this.btn_Save.Location = new System.Drawing.Point(38, 108);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(115, 36);
            this.btn_Save.TabIndex = 14;
            this.btn_Save.Text = "Save Project";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.SaveProject);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Type Device name";
            // 
            // grp_TIA
            // 
            this.grp_TIA.Controls.Add(this.rdb_WithoutUI);
            this.grp_TIA.Controls.Add(this.rdb_WithUI);
            this.grp_TIA.Controls.Add(this.btn_Dispose);
            this.grp_TIA.Controls.Add(this.btn_Start);
            this.grp_TIA.Location = new System.Drawing.Point(12, 12);
            this.grp_TIA.Name = "grp_TIA";
            this.grp_TIA.Size = new System.Drawing.Size(185, 203);
            this.grp_TIA.TabIndex = 16;
            this.grp_TIA.TabStop = false;
            this.grp_TIA.Text = "TIA Portal";
            // 
            // rdb_WithoutUI
            // 
            this.rdb_WithoutUI.AutoSize = true;
            this.rdb_WithoutUI.Location = new System.Drawing.Point(36, 51);
            this.rdb_WithoutUI.Name = "rdb_WithoutUI";
            this.rdb_WithoutUI.Size = new System.Drawing.Size(132, 17);
            this.rdb_WithoutUI.TabIndex = 2;
            this.rdb_WithoutUI.Text = "Without User Interface";
            this.rdb_WithoutUI.UseVisualStyleBackColor = true;
            // 
            // rdb_WithUI
            // 
            this.rdb_WithUI.AutoSize = true;
            this.rdb_WithUI.Checked = true;
            this.rdb_WithUI.Location = new System.Drawing.Point(36, 28);
            this.rdb_WithUI.Name = "rdb_WithUI";
            this.rdb_WithUI.Size = new System.Drawing.Size(117, 17);
            this.rdb_WithUI.TabIndex = 1;
            this.rdb_WithUI.TabStop = true;
            this.rdb_WithUI.Text = "With User Interface";
            this.rdb_WithUI.UseVisualStyleBackColor = true;
            // 
            // grp_Compile
            // 
            this.grp_Compile.Controls.Add(this.label1);
            this.grp_Compile.Controls.Add(this.txt_Device);
            this.grp_Compile.Controls.Add(this.btn_CompileHW);
            this.grp_Compile.Location = new System.Drawing.Point(751, 12);
            this.grp_Compile.Name = "grp_Compile";
            this.grp_Compile.Size = new System.Drawing.Size(185, 203);
            this.grp_Compile.TabIndex = 17;
            this.grp_Compile.TabStop = false;
            this.grp_Compile.Text = "Compile";
            // 
            // grp_Project
            // 
            this.grp_Project.Controls.Add(this.btn_Connect);
            this.grp_Project.Controls.Add(this.btn_Save);
            this.grp_Project.Controls.Add(this.btn_CloseProject);
            this.grp_Project.Controls.Add(this.btn_SearchProject);
            this.grp_Project.Location = new System.Drawing.Point(203, 12);
            this.grp_Project.Name = "grp_Project";
            this.grp_Project.Size = new System.Drawing.Size(185, 203);
            this.grp_Project.TabIndex = 18;
            this.grp_Project.TabStop = false;
            this.grp_Project.Text = "Project";
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(38, 65);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(115, 36);
            this.btn_Connect.TabIndex = 5;
            this.btn_Connect.Text = "Connect to open TIA Project";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_ConnectTIA);
            // 
            // btn_AddHW
            // 
            this.btn_AddHW.Enabled = false;
            this.btn_AddHW.Location = new System.Drawing.Point(604, 159);
            this.btn_AddHW.Name = "btn_AddHW";
            this.btn_AddHW.Size = new System.Drawing.Size(116, 36);
            this.btn_AddHW.TabIndex = 12;
            this.btn_AddHW.Text = "Add Device";
            this.btn_AddHW.UseVisualStyleBackColor = true;
            this.btn_AddHW.Click += new System.EventHandler(this.btn_AddHW_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_Version);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_OrderNo);
            this.groupBox1.Location = new System.Drawing.Point(568, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 203);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Type Version";
            // 
            // txt_Version
            // 
            this.txt_Version.Location = new System.Drawing.Point(35, 122);
            this.txt_Version.Name = "txt_Version";
            this.txt_Version.Size = new System.Drawing.Size(115, 20);
            this.txt_Version.TabIndex = 21;
            this.txt_Version.Text = "V2.1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Type Order Nr";
            // 
            // txt_OrderNo
            // 
            this.txt_OrderNo.Location = new System.Drawing.Point(36, 82);
            this.txt_OrderNo.Name = "txt_OrderNo";
            this.txt_OrderNo.Size = new System.Drawing.Size(115, 20);
            this.txt_OrderNo.TabIndex = 19;
            this.txt_OrderNo.Text = "6ES7 516-3AN01-0AB0";
            this.txt_OrderNo.TextChanged += new System.EventHandler(this.txt_OrderNo_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(604, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Type Device name";
            // 
            // txt_AddDevice
            // 
            this.txt_AddDevice.Location = new System.Drawing.Point(604, 54);
            this.txt_AddDevice.Name = "txt_AddDevice";
            this.txt_AddDevice.Size = new System.Drawing.Size(116, 20);
            this.txt_AddDevice.TabIndex = 13;
            this.txt_AddDevice.Text = "PLC_1";
            this.txt_AddDevice.TextChanged += new System.EventHandler(this.txt_AddDevice_TextChanged);
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(362, 54);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(115, 20);
            this.txtProjectName.TabIndex = 19;
            this.txtProjectName.Text = "NewProject";
            this.txtProjectName.TextChanged += new System.EventHandler(this.txtProjectName_TextChanged);
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Location = new System.Drawing.Point(362, 36);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(69, 13);
            this.lblProjectName.TabIndex = 20;
            this.lblProjectName.Text = "Project name";
            this.lblProjectName.Click += new System.EventHandler(this.label5_Click);
            // 
            // btnCreateProject
            // 
            this.btnCreateProject.Enabled = false;
            this.btnCreateProject.Location = new System.Drawing.Point(362, 79);
            this.btnCreateProject.Name = "btnCreateProject";
            this.btnCreateProject.Size = new System.Drawing.Size(115, 34);
            this.btnCreateProject.TabIndex = 21;
            this.btnCreateProject.Text = "Create Project";
            this.btnCreateProject.UseVisualStyleBackColor = true;
            this.btnCreateProject.Click += new System.EventHandler(this.btnCreateProject_Click);
            // 
            // btnExportBlocks
            // 
            this.btnExportBlocks.Enabled = false;
            this.btnExportBlocks.Location = new System.Drawing.Point(48, 283);
            this.btnExportBlocks.Name = "btnExportBlocks";
            this.btnExportBlocks.Size = new System.Drawing.Size(115, 34);
            this.btnExportBlocks.TabIndex = 22;
            this.btnExportBlocks.Text = "Export Block";
            this.btnExportBlocks.UseVisualStyleBackColor = true;
            this.btnExportBlocks.Click += new System.EventHandler(this.btnExportBlocks_Click);
            // 
            // btnImportBlock
            // 
            this.btnImportBlock.Enabled = false;
            this.btnImportBlock.Location = new System.Drawing.Point(48, 332);
            this.btnImportBlock.Name = "btnImportBlock";
            this.btnImportBlock.Size = new System.Drawing.Size(115, 34);
            this.btnImportBlock.TabIndex = 24;
            this.btnImportBlock.Text = "Import Block";
            this.btnImportBlock.UseVisualStyleBackColor = true;
            this.btnImportBlock.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lblEXPIMP
            // 
            this.lblEXPIMP.AutoSize = true;
            this.lblEXPIMP.Location = new System.Drawing.Point(25, 255);
            this.lblEXPIMP.Name = "lblEXPIMP";
            this.lblEXPIMP.Size = new System.Drawing.Size(71, 13);
            this.lblEXPIMP.TabIndex = 25;
            this.lblEXPIMP.Text = "Export/Import";
            this.lblEXPIMP.Click += new System.EventHandler(this.label5_Click_1);
            // 
            // btnExportTagTables
            // 
            this.btnExportTagTables.Enabled = false;
            this.btnExportTagTables.Location = new System.Drawing.Point(184, 283);
            this.btnExportTagTables.Name = "btnExportTagTables";
            this.btnExportTagTables.Size = new System.Drawing.Size(115, 34);
            this.btnExportTagTables.TabIndex = 26;
            this.btnExportTagTables.Text = "Export Tag Tables";
            this.btnExportTagTables.UseVisualStyleBackColor = true;
            this.btnExportTagTables.Click += new System.EventHandler(this.btnExportTagTables_Click);
            // 
            // btnImportTagTables
            // 
            this.btnImportTagTables.Enabled = false;
            this.btnImportTagTables.Location = new System.Drawing.Point(184, 332);
            this.btnImportTagTables.Name = "btnImportTagTables";
            this.btnImportTagTables.Size = new System.Drawing.Size(115, 34);
            this.btnImportTagTables.TabIndex = 27;
            this.btnImportTagTables.Text = "Import Tag Tables";
            this.btnImportTagTables.UseVisualStyleBackColor = true;
            this.btnImportTagTables.Click += new System.EventHandler(this.btnImportTagTables_Click);
            // 
            // btnImportUDT
            // 
            this.btnImportUDT.Enabled = false;
            this.btnImportUDT.Location = new System.Drawing.Point(321, 332);
            this.btnImportUDT.Name = "btnImportUDT";
            this.btnImportUDT.Size = new System.Drawing.Size(115, 34);
            this.btnImportUDT.TabIndex = 29;
            this.btnImportUDT.Text = "Import UDT";
            this.btnImportUDT.UseVisualStyleBackColor = true;
            this.btnImportUDT.Click += new System.EventHandler(this.btnImportUDT_Click);
            // 
            // btnExportUDT
            // 
            this.btnExportUDT.Enabled = false;
            this.btnExportUDT.Location = new System.Drawing.Point(321, 283);
            this.btnExportUDT.Name = "btnExportUDT";
            this.btnExportUDT.Size = new System.Drawing.Size(115, 34);
            this.btnExportUDT.TabIndex = 28;
            this.btnExportUDT.Text = "Export UDT";
            this.btnExportUDT.UseVisualStyleBackColor = true;
            this.btnExportUDT.Click += new System.EventHandler(this.btnExportUDT_Click);
            // 
            // btnHWConfig
            // 
            this.btnHWConfig.Enabled = false;
            this.btnHWConfig.Location = new System.Drawing.Point(603, 283);
            this.btnHWConfig.Name = "btnHWConfig";
            this.btnHWConfig.Size = new System.Drawing.Size(115, 34);
            this.btnHWConfig.TabIndex = 30;
            this.btnHWConfig.Text = "Nahrej Hardwarovku";
            this.btnHWConfig.UseVisualStyleBackColor = true;
            this.btnHWConfig.Click += new System.EventHandler(this.btnHWConfig_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(577, 255);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Hardwarova konfigurace";
            this.label5.Click += new System.EventHandler(this.label5_Click_2);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::StartOpenness.Properties.Resources.rozdelovac;
            this.pictureBox2.Location = new System.Drawing.Point(-4, 374);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1114, 19);
            this.pictureBox2.TabIndex = 32;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::StartOpenness.Properties.Resources.acam200x80;
            this.pictureBox1.Location = new System.Drawing.Point(881, 643);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(229, 88);
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblNastaveniStanic
            // 
            this.lblNastaveniStanic.AutoSize = true;
            this.lblNastaveniStanic.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblNastaveniStanic.Location = new System.Drawing.Point(466, 396);
            this.lblNastaveniStanic.Name = "lblNastaveniStanic";
            this.lblNastaveniStanic.Size = new System.Drawing.Size(145, 24);
            this.lblNastaveniStanic.TabIndex = 34;
            this.lblNastaveniStanic.Text = "Nastaveni stanic";
            this.lblNastaveniStanic.Click += new System.EventHandler(this.label6_Click);
            // 
            // lblPocetStanic
            // 
            this.lblPocetStanic.AutoSize = true;
            this.lblPocetStanic.Location = new System.Drawing.Point(25, 429);
            this.lblPocetStanic.Name = "lblPocetStanic";
            this.lblPocetStanic.Size = new System.Drawing.Size(68, 13);
            this.lblPocetStanic.TabIndex = 35;
            this.lblPocetStanic.Text = "Pocet Stanic";
            // 
            // btnGenerujStanice
            // 
            this.btnGenerujStanice.Location = new System.Drawing.Point(48, 634);
            this.btnGenerujStanice.Name = "btnGenerujStanice";
            this.btnGenerujStanice.Size = new System.Drawing.Size(115, 34);
            this.btnGenerujStanice.TabIndex = 36;
            this.btnGenerujStanice.Text = "Generuj Stanice";
            this.btnGenerujStanice.UseVisualStyleBackColor = true;
            this.btnGenerujStanice.Click += new System.EventHandler(this.btnGenerujStanice_Click);
            // 
            // lblUmisteniBlokuStanic
            // 
            this.lblUmisteniBlokuStanic.AutoSize = true;
            this.lblUmisteniBlokuStanic.Location = new System.Drawing.Point(25, 504);
            this.lblUmisteniBlokuStanic.Name = "lblUmisteniBlokuStanic";
            this.lblUmisteniBlokuStanic.Size = new System.Drawing.Size(107, 13);
            this.lblUmisteniBlokuStanic.TabIndex = 37;
            this.lblUmisteniBlokuStanic.Text = "Umisteni bloku stanic";
            // 
            // txtBoxUmisteniBlokuStanic
            // 
            this.txtBoxUmisteniBlokuStanic.Location = new System.Drawing.Point(48, 520);
            this.txtBoxUmisteniBlokuStanic.Name = "txtBoxUmisteniBlokuStanic";
            this.txtBoxUmisteniBlokuStanic.Size = new System.Drawing.Size(251, 20);
            this.txtBoxUmisteniBlokuStanic.TabIndex = 38;
            // 
            // numBoxPocetStanic
            // 
            this.numBoxPocetStanic.Location = new System.Drawing.Point(48, 445);
            this.numBoxPocetStanic.Name = "numBoxPocetStanic";
            this.numBoxPocetStanic.Size = new System.Drawing.Size(120, 20);
            this.numBoxPocetStanic.TabIndex = 39;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(305, 520);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 20);
            this.btnBrowse.TabIndex = 40;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::StartOpenness.Properties.Resources.rozdelovac;
            this.pictureBox3.Location = new System.Drawing.Point(-2, 205);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(1114, 19);
            this.pictureBox3.TabIndex = 41;
            this.pictureBox3.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label6.Location = new System.Drawing.Point(384, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(351, 24);
            this.label6.TabIndex = 42;
            this.label6.Text = "Import, Export a Hardwarova konfigurace";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1110, 729);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.numBoxPocetStanic);
            this.Controls.Add(this.txtBoxUmisteniBlokuStanic);
            this.Controls.Add(this.lblUmisteniBlokuStanic);
            this.Controls.Add(this.btnGenerujStanice);
            this.Controls.Add(this.lblPocetStanic);
            this.Controls.Add(this.lblNastaveniStanic);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnHWConfig);
            this.Controls.Add(this.btnImportUDT);
            this.Controls.Add(this.btnExportUDT);
            this.Controls.Add(this.btnImportTagTables);
            this.Controls.Add(this.btnExportTagTables);
            this.Controls.Add(this.lblEXPIMP);
            this.Controls.Add(this.btnImportBlock);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnExportBlocks);
            this.Controls.Add(this.btnCreateProject);
            this.Controls.Add(this.lblProjectName);
            this.Controls.Add(this.txtProjectName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_AddDevice);
            this.Controls.Add(this.grp_Project);
            this.Controls.Add(this.btn_AddHW);
            this.Controls.Add(this.grp_Compile);
            this.Controls.Add(this.grp_TIA);
            this.Controls.Add(this.txt_Status);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Acam Solution - Tia Portal Openess application";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grp_TIA.ResumeLayout(false);
            this.grp_TIA.PerformLayout();
            this.grp_Compile.ResumeLayout(false);
            this.grp_Compile.PerformLayout();
            this.grp_Project.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBoxPocetStanic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btn_Dispose;
        private System.Windows.Forms.Button btn_SearchProject;
        private System.Windows.Forms.TextBox txt_Status;
        private System.Windows.Forms.Button btn_CloseProject;
        private System.Windows.Forms.Button btn_CompileHW;
        private System.Windows.Forms.TextBox txt_Device;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grp_TIA;
        private System.Windows.Forms.RadioButton rdb_WithoutUI;
        private System.Windows.Forms.RadioButton rdb_WithUI;
        private System.Windows.Forms.GroupBox grp_Compile;
        private System.Windows.Forms.GroupBox grp_Project;
        private System.Windows.Forms.Button btn_AddHW;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_AddDevice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_OrderNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Version;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.Button btnCreateProject;
        private System.Windows.Forms.Button btnExportBlocks;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnImportBlock;
        private System.Windows.Forms.Label lblEXPIMP;
        private System.Windows.Forms.Button btnExportTagTables;
        private System.Windows.Forms.Button btnImportTagTables;
        private System.Windows.Forms.Button btnImportUDT;
        private System.Windows.Forms.Button btnExportUDT;
        private System.Windows.Forms.Button btnHWConfig;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblNastaveniStanic;
        private System.Windows.Forms.Label lblPocetStanic;
        private System.Windows.Forms.Button btnGenerujStanice;
        private System.Windows.Forms.Label lblUmisteniBlokuStanic;
        private System.Windows.Forms.TextBox txtBoxUmisteniBlokuStanic;
        private System.Windows.Forms.NumericUpDown numBoxPocetStanic;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label6;
    }
}

