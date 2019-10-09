namespace CSWork.Interface.Forms
{
    partial class Configuration
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuration));
            this.tab = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.pModulos = new System.Windows.Forms.GroupBox();
            this.cbGeneralModuloLink = new System.Windows.Forms.CheckBox();
            this.cbGeneralModuloAlarmas = new System.Windows.Forms.CheckBox();
            this.cbGeneralModuloMemory = new System.Windows.Forms.CheckBox();
            this.cbGeneralModuloAmbiente = new System.Windows.Forms.CheckBox();
            this.pGeneralApps = new System.Windows.Forms.GroupBox();
            this.bAppsWebNone = new System.Windows.Forms.Button();
            this.bAppsWebSearch = new System.Windows.Forms.Button();
            this.tAppsWeb = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.pGCBARed = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tGeneralGCBARedPass = new System.Windows.Forms.TextBox();
            this.tGeneralGCBARedUser = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pGeneralWindows = new System.Windows.Forms.GroupBox();
            this.cbGeneralStartWithWindows = new System.Windows.Forms.CheckBox();
            this.tabJira = new System.Windows.Forms.TabPage();
            this.pJiraAutenticacion = new System.Windows.Forms.GroupBox();
            this.bJiraLogin = new System.Windows.Forms.Button();
            this.bJiraDisconnect = new System.Windows.Forms.Button();
            this.tJiraUser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabWork = new System.Windows.Forms.TabPage();
            this.pWorkFiltros = new System.Windows.Forms.GroupBox();
            this.pWorkFiltrosSys = new System.Windows.Forms.GroupBox();
            this.bWorkFiltersRemove = new System.Windows.Forms.Button();
            this.gWorkFilters = new System.Windows.Forms.DataGridView();
            this.pWorkFiltrosJira = new System.Windows.Forms.GroupBox();
            this.tWorkJiraFiltersFilter = new System.Windows.Forms.TextBox();
            this.bWorkJiraFiltersAdd = new System.Windows.Forms.Button();
            this.gWorkJiraFilters = new System.Windows.Forms.DataGridView();
            this.bWorkRefreshJiraFilters = new System.Windows.Forms.Button();
            this.pWorkGeneral = new System.Windows.Forms.GroupBox();
            this.cbWorkWithoutIssue = new System.Windows.Forms.CheckBox();
            this.tabAlarmas = new System.Windows.Forms.TabPage();
            this.pAlarmTempo = new System.Windows.Forms.GroupBox();
            this.cbAlarmTempoAtEndPeriod = new System.Windows.Forms.CheckBox();
            this.cbAlarmTempoAtEndWeek = new System.Windows.Forms.CheckBox();
            this.cbAlarmTempoAtEndDay = new System.Windows.Forms.CheckBox();
            this.pAlarmaIssues = new System.Windows.Forms.GroupBox();
            this.cbAlarmIssueAlarmEnabled = new System.Windows.Forms.CheckBox();
            this.cbAlarmIssueCommentChanged = new System.Windows.Forms.CheckBox();
            this.cbAlarmIssueAdjuntoChanged = new System.Windows.Forms.CheckBox();
            this.cbAlarmIssuePriorityChanged = new System.Windows.Forms.CheckBox();
            this.pAlarmaApariencia = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cbAlarmasAnimacion = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cbAlarmasPosicion = new System.Windows.Forms.ComboBox();
            this.bAlarmasMonitorFind = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.cbAlarmasMonitor = new System.Windows.Forms.ComboBox();
            this.tabMemory = new System.Windows.Forms.TabPage();
            this.pMemoryEdit = new System.Windows.Forms.GroupBox();
            this.bMemorySaveChanges = new System.Windows.Forms.Button();
            this.cbMemoryEntityGroup = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tMemoryEntityValue = new System.Windows.Forms.TextBox();
            this.tMemoryEntityKey = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bMemoryDelete = new System.Windows.Forms.Button();
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.bMemoryAddNew = new System.Windows.Forms.Button();
            this.pMemoryData = new System.Windows.Forms.GroupBox();
            this.gMemoryData = new System.Windows.Forms.DataGridView();
            this.pMemoryFilter = new System.Windows.Forms.GroupBox();
            this.cbMemoryFilterGroup = new System.Windows.Forms.ComboBox();
            this.tMemoryFilterKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabGCBA = new System.Windows.Forms.TabPage();
            this.pGCBAAmbientes = new System.Windows.Forms.GroupBox();
            this.bGCBAAmbienteDelete = new System.Windows.Forms.Button();
            this.bGCBAAmbienteNew = new System.Windows.Forms.Button();
            this.tGCBAFilter = new System.Windows.Forms.TextBox();
            this.lbGCBAAmbientes = new System.Windows.Forms.ListBox();
            this.pGCBAData = new System.Windows.Forms.GroupBox();
            this.pGCBAWebs = new System.Windows.Forms.GroupBox();
            this.bGCBAWebsDelete = new System.Windows.Forms.Button();
            this.bGCBAWebsNew = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.tGCBAWebsName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tGCBAWebsUrl = new System.Windows.Forms.TextBox();
            this.lbGCBAWebsList = new System.Windows.Forms.ListBox();
            this.bGCBADataSave = new System.Windows.Forms.Button();
            this.pGCBADataWeb = new System.Windows.Forms.GroupBox();
            this.cbGCBAWebAllowRemote = new System.Windows.Forms.CheckBox();
            this.cbGCBAWebAllowExplorer = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tGCBACustomPass = new System.Windows.Forms.TextBox();
            this.tGCBACustomUser = new System.Windows.Forms.TextBox();
            this.cbGCBAUseCustomUser = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tGCBAWebIP = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tGCBADataName = new System.Windows.Forms.TextBox();
            this.tabLinks = new System.Windows.Forms.TabPage();
            this.gLinkData = new System.Windows.Forms.GroupBox();
            this.bLinkSave = new System.Windows.Forms.Button();
            this.gLinkFolder = new System.Windows.Forms.GroupBox();
            this.cbLinkShowSubFolders = new System.Windows.Forms.CheckBox();
            this.tLinkFolderFileFilter = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cbLinkShowFolderContent = new System.Windows.Forms.CheckBox();
            this.tLinkEditPathFind = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.tLinkEditPath = new System.Windows.Forms.TextBox();
            this.tLinkEditName = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.gLinkDataImage = new System.Windows.Forms.GroupBox();
            this.bLinkImgCustomFind = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.tLinkImgCustom = new System.Windows.Forms.TextBox();
            this.gLinkDataImageDiv = new System.Windows.Forms.Panel();
            this.gLinks = new System.Windows.Forms.GroupBox();
            this.tLinksFilter = new System.Windows.Forms.TextBox();
            this.tvLinks = new System.Windows.Forms.TreeView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cbLinkShowOpen = new System.Windows.Forms.CheckBox();
            this.codeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jqlDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jiraFilterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jqlDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gMemoryDataSource = new System.Windows.Forms.BindingSource(this.components);
            this.tab.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.pModulos.SuspendLayout();
            this.pGeneralApps.SuspendLayout();
            this.pGCBARed.SuspendLayout();
            this.pGeneralWindows.SuspendLayout();
            this.tabJira.SuspendLayout();
            this.pJiraAutenticacion.SuspendLayout();
            this.tabWork.SuspendLayout();
            this.pWorkFiltros.SuspendLayout();
            this.pWorkFiltrosSys.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gWorkFilters)).BeginInit();
            this.pWorkFiltrosJira.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gWorkJiraFilters)).BeginInit();
            this.pWorkGeneral.SuspendLayout();
            this.tabAlarmas.SuspendLayout();
            this.pAlarmTempo.SuspendLayout();
            this.pAlarmaIssues.SuspendLayout();
            this.pAlarmaApariencia.SuspendLayout();
            this.tabMemory.SuspendLayout();
            this.pMemoryEdit.SuspendLayout();
            this.pMemoryData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gMemoryData)).BeginInit();
            this.pMemoryFilter.SuspendLayout();
            this.tabGCBA.SuspendLayout();
            this.pGCBAAmbientes.SuspendLayout();
            this.pGCBAData.SuspendLayout();
            this.pGCBAWebs.SuspendLayout();
            this.pGCBADataWeb.SuspendLayout();
            this.tabLinks.SuspendLayout();
            this.gLinkData.SuspendLayout();
            this.gLinkFolder.SuspendLayout();
            this.gLinkDataImage.SuspendLayout();
            this.gLinks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jiraFilterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gMemoryDataSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tab
            // 
            this.tab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tab.Controls.Add(this.tabGeneral);
            this.tab.Controls.Add(this.tabJira);
            this.tab.Controls.Add(this.tabWork);
            this.tab.Controls.Add(this.tabAlarmas);
            this.tab.Controls.Add(this.tabMemory);
            this.tab.Controls.Add(this.tabGCBA);
            this.tab.Controls.Add(this.tabLinks);
            this.tab.HotTrack = true;
            this.tab.ImageList = this.images;
            this.tab.Location = new System.Drawing.Point(16, 15);
            this.tab.Margin = new System.Windows.Forms.Padding(4);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(798, 591);
            this.tab.TabIndex = 0;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.pModulos);
            this.tabGeneral.Controls.Add(this.pGeneralApps);
            this.tabGeneral.Controls.Add(this.pGCBARed);
            this.tabGeneral.Controls.Add(this.pGeneralWindows);
            this.tabGeneral.Location = new System.Drawing.Point(4, 25);
            this.tabGeneral.Margin = new System.Windows.Forms.Padding(4);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(4);
            this.tabGeneral.Size = new System.Drawing.Size(790, 562);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // pModulos
            // 
            this.pModulos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pModulos.Controls.Add(this.cbGeneralModuloLink);
            this.pModulos.Controls.Add(this.cbGeneralModuloAlarmas);
            this.pModulos.Controls.Add(this.cbGeneralModuloMemory);
            this.pModulos.Controls.Add(this.cbGeneralModuloAmbiente);
            this.pModulos.Location = new System.Drawing.Point(7, 224);
            this.pModulos.Name = "pModulos";
            this.pModulos.Size = new System.Drawing.Size(776, 133);
            this.pModulos.TabIndex = 3;
            this.pModulos.TabStop = false;
            this.pModulos.Text = "Módulos";
            // 
            // cbGeneralModuloLink
            // 
            this.cbGeneralModuloLink.AutoSize = true;
            this.cbGeneralModuloLink.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbGeneralModuloLink.Location = new System.Drawing.Point(6, 99);
            this.cbGeneralModuloLink.Name = "cbGeneralModuloLink";
            this.cbGeneralModuloLink.Size = new System.Drawing.Size(133, 20);
            this.cbGeneralModuloLink.TabIndex = 5;
            this.cbGeneralModuloLink.Text = "Accesos Directos";
            this.cbGeneralModuloLink.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cbGeneralModuloLink.UseVisualStyleBackColor = true;
            // 
            // cbGeneralModuloAlarmas
            // 
            this.cbGeneralModuloAlarmas.AutoSize = true;
            this.cbGeneralModuloAlarmas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbGeneralModuloAlarmas.Location = new System.Drawing.Point(6, 21);
            this.cbGeneralModuloAlarmas.Name = "cbGeneralModuloAlarmas";
            this.cbGeneralModuloAlarmas.Size = new System.Drawing.Size(77, 20);
            this.cbGeneralModuloAlarmas.TabIndex = 4;
            this.cbGeneralModuloAlarmas.Text = "Alarmas";
            this.cbGeneralModuloAlarmas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cbGeneralModuloAlarmas.UseVisualStyleBackColor = true;
            // 
            // cbGeneralModuloMemory
            // 
            this.cbGeneralModuloMemory.AutoSize = true;
            this.cbGeneralModuloMemory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbGeneralModuloMemory.Location = new System.Drawing.Point(6, 47);
            this.cbGeneralModuloMemory.Name = "cbGeneralModuloMemory";
            this.cbGeneralModuloMemory.Size = new System.Drawing.Size(76, 20);
            this.cbGeneralModuloMemory.TabIndex = 3;
            this.cbGeneralModuloMemory.Text = "Memory";
            this.cbGeneralModuloMemory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cbGeneralModuloMemory.UseVisualStyleBackColor = true;
            // 
            // cbGeneralModuloAmbiente
            // 
            this.cbGeneralModuloAmbiente.AutoSize = true;
            this.cbGeneralModuloAmbiente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbGeneralModuloAmbiente.Location = new System.Drawing.Point(6, 73);
            this.cbGeneralModuloAmbiente.Name = "cbGeneralModuloAmbiente";
            this.cbGeneralModuloAmbiente.Size = new System.Drawing.Size(91, 20);
            this.cbGeneralModuloAmbiente.TabIndex = 2;
            this.cbGeneralModuloAmbiente.Text = "Ambientes";
            this.cbGeneralModuloAmbiente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cbGeneralModuloAmbiente.UseVisualStyleBackColor = true;
            // 
            // pGeneralApps
            // 
            this.pGeneralApps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pGeneralApps.Controls.Add(this.bAppsWebNone);
            this.pGeneralApps.Controls.Add(this.bAppsWebSearch);
            this.pGeneralApps.Controls.Add(this.tAppsWeb);
            this.pGeneralApps.Controls.Add(this.label15);
            this.pGeneralApps.Location = new System.Drawing.Point(7, 158);
            this.pGeneralApps.Name = "pGeneralApps";
            this.pGeneralApps.Size = new System.Drawing.Size(776, 60);
            this.pGeneralApps.TabIndex = 2;
            this.pGeneralApps.TabStop = false;
            this.pGeneralApps.Text = "Programas Default";
            // 
            // bAppsWebNone
            // 
            this.bAppsWebNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bAppsWebNone.Image = ((System.Drawing.Image)(resources.GetObject("bAppsWebNone.Image")));
            this.bAppsWebNone.Location = new System.Drawing.Point(745, 21);
            this.bAppsWebNone.Name = "bAppsWebNone";
            this.bAppsWebNone.Size = new System.Drawing.Size(25, 25);
            this.bAppsWebNone.TabIndex = 3;
            this.bAppsWebNone.UseVisualStyleBackColor = true;
            // 
            // bAppsWebSearch
            // 
            this.bAppsWebSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bAppsWebSearch.Image = ((System.Drawing.Image)(resources.GetObject("bAppsWebSearch.Image")));
            this.bAppsWebSearch.Location = new System.Drawing.Point(714, 20);
            this.bAppsWebSearch.Name = "bAppsWebSearch";
            this.bAppsWebSearch.Size = new System.Drawing.Size(25, 25);
            this.bAppsWebSearch.TabIndex = 2;
            this.bAppsWebSearch.UseVisualStyleBackColor = true;
            // 
            // tAppsWeb
            // 
            this.tAppsWeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tAppsWeb.Location = new System.Drawing.Point(102, 21);
            this.tAppsWeb.Name = "tAppsWeb";
            this.tAppsWeb.ReadOnly = true;
            this.tAppsWeb.Size = new System.Drawing.Size(606, 22);
            this.tAppsWeb.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(90, 16);
            this.label15.TabIndex = 0;
            this.label15.Text = "Páginas Web";
            // 
            // pGCBARed
            // 
            this.pGCBARed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pGCBARed.Controls.Add(this.label8);
            this.pGCBARed.Controls.Add(this.tGeneralGCBARedPass);
            this.pGCBARed.Controls.Add(this.tGeneralGCBARedUser);
            this.pGCBARed.Controls.Add(this.label7);
            this.pGCBARed.Location = new System.Drawing.Point(7, 71);
            this.pGCBARed.Name = "pGCBARed";
            this.pGCBARed.Size = new System.Drawing.Size(776, 81);
            this.pGCBARed.TabIndex = 1;
            this.pGCBARed.TabStop = false;
            this.pGCBARed.Text = "Red GCBA";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 16);
            this.label8.TabIndex = 6;
            this.label8.Text = "Password";
            // 
            // tGeneralGCBARedPass
            // 
            this.tGeneralGCBARedPass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tGeneralGCBARedPass.Location = new System.Drawing.Point(80, 49);
            this.tGeneralGCBARedPass.Name = "tGeneralGCBARedPass";
            this.tGeneralGCBARedPass.Size = new System.Drawing.Size(690, 22);
            this.tGeneralGCBARedPass.TabIndex = 5;
            // 
            // tGeneralGCBARedUser
            // 
            this.tGeneralGCBARedUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tGeneralGCBARedUser.Location = new System.Drawing.Point(80, 21);
            this.tGeneralGCBARedUser.Name = "tGeneralGCBARedUser";
            this.tGeneralGCBARedUser.Size = new System.Drawing.Size(690, 22);
            this.tGeneralGCBARedUser.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "Usuario";
            // 
            // pGeneralWindows
            // 
            this.pGeneralWindows.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pGeneralWindows.Controls.Add(this.cbGeneralStartWithWindows);
            this.pGeneralWindows.Location = new System.Drawing.Point(7, 7);
            this.pGeneralWindows.Name = "pGeneralWindows";
            this.pGeneralWindows.Size = new System.Drawing.Size(776, 58);
            this.pGeneralWindows.TabIndex = 0;
            this.pGeneralWindows.TabStop = false;
            this.pGeneralWindows.Text = "Windows";
            // 
            // cbGeneralStartWithWindows
            // 
            this.cbGeneralStartWithWindows.AutoSize = true;
            this.cbGeneralStartWithWindows.Location = new System.Drawing.Point(6, 21);
            this.cbGeneralStartWithWindows.Name = "cbGeneralStartWithWindows";
            this.cbGeneralStartWithWindows.Size = new System.Drawing.Size(145, 20);
            this.cbGeneralStartWithWindows.TabIndex = 0;
            this.cbGeneralStartWithWindows.Text = "Iniciar con Windows";
            this.cbGeneralStartWithWindows.UseVisualStyleBackColor = true;
            // 
            // tabJira
            // 
            this.tabJira.Controls.Add(this.pJiraAutenticacion);
            this.tabJira.Location = new System.Drawing.Point(4, 25);
            this.tabJira.Margin = new System.Windows.Forms.Padding(4);
            this.tabJira.Name = "tabJira";
            this.tabJira.Padding = new System.Windows.Forms.Padding(4);
            this.tabJira.Size = new System.Drawing.Size(790, 562);
            this.tabJira.TabIndex = 1;
            this.tabJira.Text = "Atlassian";
            this.tabJira.UseVisualStyleBackColor = true;
            // 
            // pJiraAutenticacion
            // 
            this.pJiraAutenticacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pJiraAutenticacion.Controls.Add(this.bJiraLogin);
            this.pJiraAutenticacion.Controls.Add(this.bJiraDisconnect);
            this.pJiraAutenticacion.Controls.Add(this.tJiraUser);
            this.pJiraAutenticacion.Controls.Add(this.label1);
            this.pJiraAutenticacion.Location = new System.Drawing.Point(7, 7);
            this.pJiraAutenticacion.Name = "pJiraAutenticacion";
            this.pJiraAutenticacion.Size = new System.Drawing.Size(776, 94);
            this.pJiraAutenticacion.TabIndex = 1;
            this.pJiraAutenticacion.TabStop = false;
            this.pJiraAutenticacion.Text = "Autenticación";
            // 
            // bJiraLogin
            // 
            this.bJiraLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bJiraLogin.Location = new System.Drawing.Point(560, 59);
            this.bJiraLogin.Name = "bJiraLogin";
            this.bJiraLogin.Size = new System.Drawing.Size(210, 29);
            this.bJiraLogin.TabIndex = 3;
            this.bJiraLogin.Text = "Ingresar Otras Credenciales";
            this.bJiraLogin.UseVisualStyleBackColor = true;
            // 
            // bJiraDisconnect
            // 
            this.bJiraDisconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bJiraDisconnect.Location = new System.Drawing.Point(446, 59);
            this.bJiraDisconnect.Name = "bJiraDisconnect";
            this.bJiraDisconnect.Size = new System.Drawing.Size(108, 29);
            this.bJiraDisconnect.TabIndex = 2;
            this.bJiraDisconnect.Text = "Desconectar";
            this.bJiraDisconnect.UseVisualStyleBackColor = true;
            // 
            // tJiraUser
            // 
            this.tJiraUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tJiraUser.Location = new System.Drawing.Point(70, 21);
            this.tJiraUser.Name = "tJiraUser";
            this.tJiraUser.ReadOnly = true;
            this.tJiraUser.Size = new System.Drawing.Size(700, 22);
            this.tJiraUser.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario:";
            // 
            // tabWork
            // 
            this.tabWork.Controls.Add(this.pWorkFiltros);
            this.tabWork.Controls.Add(this.pWorkGeneral);
            this.tabWork.Location = new System.Drawing.Point(4, 25);
            this.tabWork.Name = "tabWork";
            this.tabWork.Padding = new System.Windows.Forms.Padding(3);
            this.tabWork.Size = new System.Drawing.Size(790, 562);
            this.tabWork.TabIndex = 5;
            this.tabWork.Text = "Working";
            this.tabWork.UseVisualStyleBackColor = true;
            // 
            // pWorkFiltros
            // 
            this.pWorkFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pWorkFiltros.Controls.Add(this.pWorkFiltrosSys);
            this.pWorkFiltros.Controls.Add(this.pWorkFiltrosJira);
            this.pWorkFiltros.Location = new System.Drawing.Point(6, 58);
            this.pWorkFiltros.Name = "pWorkFiltros";
            this.pWorkFiltros.Size = new System.Drawing.Size(778, 498);
            this.pWorkFiltros.TabIndex = 4;
            this.pWorkFiltros.TabStop = false;
            this.pWorkFiltros.Text = "Filtros";
            // 
            // pWorkFiltrosSys
            // 
            this.pWorkFiltrosSys.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pWorkFiltrosSys.Controls.Add(this.bWorkFiltersRemove);
            this.pWorkFiltrosSys.Controls.Add(this.gWorkFilters);
            this.pWorkFiltrosSys.Location = new System.Drawing.Point(6, 332);
            this.pWorkFiltrosSys.Name = "pWorkFiltrosSys";
            this.pWorkFiltrosSys.Size = new System.Drawing.Size(766, 160);
            this.pWorkFiltrosSys.TabIndex = 1;
            this.pWorkFiltrosSys.TabStop = false;
            this.pWorkFiltrosSys.Text = "Filtros del Sistema";
            // 
            // bWorkFiltersRemove
            // 
            this.bWorkFiltersRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bWorkFiltersRemove.Location = new System.Drawing.Point(657, 127);
            this.bWorkFiltersRemove.Name = "bWorkFiltersRemove";
            this.bWorkFiltersRemove.Size = new System.Drawing.Size(103, 27);
            this.bWorkFiltersRemove.TabIndex = 3;
            this.bWorkFiltersRemove.Text = "Quitar";
            this.bWorkFiltersRemove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bWorkFiltersRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bWorkFiltersRemove.UseVisualStyleBackColor = true;
            // 
            // gWorkFilters
            // 
            this.gWorkFilters.AllowUserToAddRows = false;
            this.gWorkFilters.AllowUserToDeleteRows = false;
            this.gWorkFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gWorkFilters.AutoGenerateColumns = false;
            this.gWorkFilters.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gWorkFilters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gWorkFilters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn1,
            this.nameDataGridViewTextBoxColumn1,
            this.jqlDataGridViewTextBoxColumn1});
            this.gWorkFilters.DataSource = this.jiraFilterBindingSource;
            this.gWorkFilters.Location = new System.Drawing.Point(6, 21);
            this.gWorkFilters.MultiSelect = false;
            this.gWorkFilters.Name = "gWorkFilters";
            this.gWorkFilters.ReadOnly = true;
            this.gWorkFilters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gWorkFilters.Size = new System.Drawing.Size(754, 100);
            this.gWorkFilters.TabIndex = 2;
            // 
            // pWorkFiltrosJira
            // 
            this.pWorkFiltrosJira.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pWorkFiltrosJira.Controls.Add(this.tWorkJiraFiltersFilter);
            this.pWorkFiltrosJira.Controls.Add(this.bWorkJiraFiltersAdd);
            this.pWorkFiltrosJira.Controls.Add(this.gWorkJiraFilters);
            this.pWorkFiltrosJira.Controls.Add(this.bWorkRefreshJiraFilters);
            this.pWorkFiltrosJira.Location = new System.Drawing.Point(6, 21);
            this.pWorkFiltrosJira.Name = "pWorkFiltrosJira";
            this.pWorkFiltrosJira.Size = new System.Drawing.Size(766, 305);
            this.pWorkFiltrosJira.TabIndex = 0;
            this.pWorkFiltrosJira.TabStop = false;
            this.pWorkFiltrosJira.Text = "Filtros en Jira";
            // 
            // tWorkJiraFiltersFilter
            // 
            this.tWorkJiraFiltersFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tWorkJiraFiltersFilter.Location = new System.Drawing.Point(182, 23);
            this.tWorkJiraFiltersFilter.Name = "tWorkJiraFiltersFilter";
            this.tWorkJiraFiltersFilter.Size = new System.Drawing.Size(578, 22);
            this.tWorkJiraFiltersFilter.TabIndex = 3;
            // 
            // bWorkJiraFiltersAdd
            // 
            this.bWorkJiraFiltersAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bWorkJiraFiltersAdd.Location = new System.Drawing.Point(657, 272);
            this.bWorkJiraFiltersAdd.Name = "bWorkJiraFiltersAdd";
            this.bWorkJiraFiltersAdd.Size = new System.Drawing.Size(103, 27);
            this.bWorkJiraFiltersAdd.TabIndex = 2;
            this.bWorkJiraFiltersAdd.Text = "Agregar";
            this.bWorkJiraFiltersAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bWorkJiraFiltersAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bWorkJiraFiltersAdd.UseVisualStyleBackColor = true;
            // 
            // gWorkJiraFilters
            // 
            this.gWorkJiraFilters.AllowUserToAddRows = false;
            this.gWorkJiraFilters.AllowUserToDeleteRows = false;
            this.gWorkJiraFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gWorkJiraFilters.AutoGenerateColumns = false;
            this.gWorkJiraFilters.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gWorkJiraFilters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gWorkJiraFilters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.jqlDataGridViewTextBoxColumn});
            this.gWorkJiraFilters.DataSource = this.jiraFilterBindingSource;
            this.gWorkJiraFilters.Location = new System.Drawing.Point(6, 54);
            this.gWorkJiraFilters.MultiSelect = false;
            this.gWorkJiraFilters.Name = "gWorkJiraFilters";
            this.gWorkJiraFilters.ReadOnly = true;
            this.gWorkJiraFilters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gWorkJiraFilters.Size = new System.Drawing.Size(754, 212);
            this.gWorkJiraFilters.TabIndex = 1;
            // 
            // bWorkRefreshJiraFilters
            // 
            this.bWorkRefreshJiraFilters.Location = new System.Drawing.Point(6, 21);
            this.bWorkRefreshJiraFilters.Name = "bWorkRefreshJiraFilters";
            this.bWorkRefreshJiraFilters.Size = new System.Drawing.Size(170, 27);
            this.bWorkRefreshJiraFilters.TabIndex = 0;
            this.bWorkRefreshJiraFilters.Text = "Obtener desde Jira";
            this.bWorkRefreshJiraFilters.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bWorkRefreshJiraFilters.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bWorkRefreshJiraFilters.UseVisualStyleBackColor = true;
            // 
            // pWorkGeneral
            // 
            this.pWorkGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pWorkGeneral.Controls.Add(this.cbWorkWithoutIssue);
            this.pWorkGeneral.Location = new System.Drawing.Point(6, 6);
            this.pWorkGeneral.Name = "pWorkGeneral";
            this.pWorkGeneral.Size = new System.Drawing.Size(778, 46);
            this.pWorkGeneral.TabIndex = 0;
            this.pWorkGeneral.TabStop = false;
            this.pWorkGeneral.Text = "General";
            // 
            // cbWorkWithoutIssue
            // 
            this.cbWorkWithoutIssue.AutoSize = true;
            this.cbWorkWithoutIssue.Location = new System.Drawing.Point(6, 21);
            this.cbWorkWithoutIssue.Name = "cbWorkWithoutIssue";
            this.cbWorkWithoutIssue.Size = new System.Drawing.Size(176, 20);
            this.cbWorkWithoutIssue.TabIndex = 0;
            this.cbWorkWithoutIssue.Text = "Permitir trabajar sin Issue";
            this.cbWorkWithoutIssue.UseVisualStyleBackColor = true;
            // 
            // tabAlarmas
            // 
            this.tabAlarmas.Controls.Add(this.pAlarmTempo);
            this.tabAlarmas.Controls.Add(this.pAlarmaIssues);
            this.tabAlarmas.Controls.Add(this.pAlarmaApariencia);
            this.tabAlarmas.Location = new System.Drawing.Point(4, 25);
            this.tabAlarmas.Name = "tabAlarmas";
            this.tabAlarmas.Padding = new System.Windows.Forms.Padding(3);
            this.tabAlarmas.Size = new System.Drawing.Size(790, 562);
            this.tabAlarmas.TabIndex = 6;
            this.tabAlarmas.Text = "Alarmas";
            this.tabAlarmas.UseVisualStyleBackColor = true;
            // 
            // pAlarmTempo
            // 
            this.pAlarmTempo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pAlarmTempo.Controls.Add(this.cbAlarmTempoAtEndPeriod);
            this.pAlarmTempo.Controls.Add(this.cbAlarmTempoAtEndWeek);
            this.pAlarmTempo.Controls.Add(this.cbAlarmTempoAtEndDay);
            this.pAlarmTempo.Location = new System.Drawing.Point(6, 261);
            this.pAlarmTempo.Name = "pAlarmTempo";
            this.pAlarmTempo.Size = new System.Drawing.Size(778, 102);
            this.pAlarmTempo.TabIndex = 2;
            this.pAlarmTempo.TabStop = false;
            this.pAlarmTempo.Text = "Carga de Horas";
            // 
            // cbAlarmTempoAtEndPeriod
            // 
            this.cbAlarmTempoAtEndPeriod.AutoSize = true;
            this.cbAlarmTempoAtEndPeriod.Location = new System.Drawing.Point(6, 73);
            this.cbAlarmTempoAtEndPeriod.Name = "cbAlarmTempoAtEndPeriod";
            this.cbAlarmTempoAtEndPeriod.Size = new System.Drawing.Size(194, 20);
            this.cbAlarmTempoAtEndPeriod.TabIndex = 6;
            this.cbAlarmTempoAtEndPeriod.Text = "Verificar y Avisar los días 24";
            this.cbAlarmTempoAtEndPeriod.UseVisualStyleBackColor = true;
            // 
            // cbAlarmTempoAtEndWeek
            // 
            this.cbAlarmTempoAtEndWeek.AutoSize = true;
            this.cbAlarmTempoAtEndWeek.Location = new System.Drawing.Point(6, 47);
            this.cbAlarmTempoAtEndWeek.Name = "cbAlarmTempoAtEndWeek";
            this.cbAlarmTempoAtEndWeek.Size = new System.Drawing.Size(228, 20);
            this.cbAlarmTempoAtEndWeek.TabIndex = 5;
            this.cbAlarmTempoAtEndWeek.Text = "Verificar y Avisar al fin de semana";
            this.cbAlarmTempoAtEndWeek.UseVisualStyleBackColor = true;
            // 
            // cbAlarmTempoAtEndDay
            // 
            this.cbAlarmTempoAtEndDay.AutoSize = true;
            this.cbAlarmTempoAtEndDay.Location = new System.Drawing.Point(6, 21);
            this.cbAlarmTempoAtEndDay.Name = "cbAlarmTempoAtEndDay";
            this.cbAlarmTempoAtEndDay.Size = new System.Drawing.Size(201, 20);
            this.cbAlarmTempoAtEndDay.TabIndex = 4;
            this.cbAlarmTempoAtEndDay.Text = "Verificar y Avisar al fin del día";
            this.cbAlarmTempoAtEndDay.UseVisualStyleBackColor = true;
            // 
            // pAlarmaIssues
            // 
            this.pAlarmaIssues.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pAlarmaIssues.Controls.Add(this.cbAlarmIssueAlarmEnabled);
            this.pAlarmaIssues.Controls.Add(this.cbAlarmIssueCommentChanged);
            this.pAlarmaIssues.Controls.Add(this.cbAlarmIssueAdjuntoChanged);
            this.pAlarmaIssues.Controls.Add(this.cbAlarmIssuePriorityChanged);
            this.pAlarmaIssues.Location = new System.Drawing.Point(6, 124);
            this.pAlarmaIssues.Name = "pAlarmaIssues";
            this.pAlarmaIssues.Size = new System.Drawing.Size(778, 131);
            this.pAlarmaIssues.TabIndex = 1;
            this.pAlarmaIssues.TabStop = false;
            this.pAlarmaIssues.Text = "Issues";
            // 
            // cbAlarmIssueAlarmEnabled
            // 
            this.cbAlarmIssueAlarmEnabled.AutoSize = true;
            this.cbAlarmIssueAlarmEnabled.Location = new System.Drawing.Point(6, 21);
            this.cbAlarmIssueAlarmEnabled.Name = "cbAlarmIssueAlarmEnabled";
            this.cbAlarmIssueAlarmEnabled.Size = new System.Drawing.Size(290, 20);
            this.cbAlarmIssueAlarmEnabled.TabIndex = 3;
            this.cbAlarmIssueAlarmEnabled.Text = "Activar notificaciones de Issues en progreso";
            this.cbAlarmIssueAlarmEnabled.UseVisualStyleBackColor = true;
            // 
            // cbAlarmIssueCommentChanged
            // 
            this.cbAlarmIssueCommentChanged.AutoSize = true;
            this.cbAlarmIssueCommentChanged.Enabled = false;
            this.cbAlarmIssueCommentChanged.Location = new System.Drawing.Point(28, 99);
            this.cbAlarmIssueCommentChanged.Name = "cbAlarmIssueCommentChanged";
            this.cbAlarmIssueCommentChanged.Size = new System.Drawing.Size(309, 20);
            this.cbAlarmIssueCommentChanged.TabIndex = 2;
            this.cbAlarmIssueCommentChanged.Text = "Notificar al agregarse o eliminarse comentarios";
            this.cbAlarmIssueCommentChanged.UseVisualStyleBackColor = true;
            // 
            // cbAlarmIssueAdjuntoChanged
            // 
            this.cbAlarmIssueAdjuntoChanged.AutoSize = true;
            this.cbAlarmIssueAdjuntoChanged.Enabled = false;
            this.cbAlarmIssueAdjuntoChanged.Location = new System.Drawing.Point(28, 73);
            this.cbAlarmIssueAdjuntoChanged.Name = "cbAlarmIssueAdjuntoChanged";
            this.cbAlarmIssueAdjuntoChanged.Size = new System.Drawing.Size(261, 20);
            this.cbAlarmIssueAdjuntoChanged.TabIndex = 1;
            this.cbAlarmIssueAdjuntoChanged.Text = "Notificar Cambios en Archivos Adjuntos";
            this.cbAlarmIssueAdjuntoChanged.UseVisualStyleBackColor = true;
            // 
            // cbAlarmIssuePriorityChanged
            // 
            this.cbAlarmIssuePriorityChanged.AutoSize = true;
            this.cbAlarmIssuePriorityChanged.Enabled = false;
            this.cbAlarmIssuePriorityChanged.Location = new System.Drawing.Point(28, 47);
            this.cbAlarmIssuePriorityChanged.Name = "cbAlarmIssuePriorityChanged";
            this.cbAlarmIssuePriorityChanged.Size = new System.Drawing.Size(208, 20);
            this.cbAlarmIssuePriorityChanged.TabIndex = 0;
            this.cbAlarmIssuePriorityChanged.Text = "Notificar cambios de Prioridad";
            this.cbAlarmIssuePriorityChanged.UseVisualStyleBackColor = true;
            // 
            // pAlarmaApariencia
            // 
            this.pAlarmaApariencia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pAlarmaApariencia.Controls.Add(this.label18);
            this.pAlarmaApariencia.Controls.Add(this.cbAlarmasAnimacion);
            this.pAlarmaApariencia.Controls.Add(this.label17);
            this.pAlarmaApariencia.Controls.Add(this.cbAlarmasPosicion);
            this.pAlarmaApariencia.Controls.Add(this.bAlarmasMonitorFind);
            this.pAlarmaApariencia.Controls.Add(this.label16);
            this.pAlarmaApariencia.Controls.Add(this.cbAlarmasMonitor);
            this.pAlarmaApariencia.Location = new System.Drawing.Point(6, 6);
            this.pAlarmaApariencia.Name = "pAlarmaApariencia";
            this.pAlarmaApariencia.Size = new System.Drawing.Size(778, 112);
            this.pAlarmaApariencia.TabIndex = 0;
            this.pAlarmaApariencia.TabStop = false;
            this.pAlarmaApariencia.Text = "Apariencia";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 84);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(71, 16);
            this.label18.TabIndex = 7;
            this.label18.Text = "Animación";
            // 
            // cbAlarmasAnimacion
            // 
            this.cbAlarmasAnimacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAlarmasAnimacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAlarmasAnimacion.FormattingEnabled = true;
            this.cbAlarmasAnimacion.Location = new System.Drawing.Point(83, 81);
            this.cbAlarmasAnimacion.Name = "cbAlarmasAnimacion";
            this.cbAlarmasAnimacion.Size = new System.Drawing.Size(689, 24);
            this.cbAlarmasAnimacion.TabIndex = 6;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 55);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(60, 16);
            this.label17.TabIndex = 5;
            this.label17.Text = "Posición";
            // 
            // cbAlarmasPosicion
            // 
            this.cbAlarmasPosicion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAlarmasPosicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAlarmasPosicion.FormattingEnabled = true;
            this.cbAlarmasPosicion.Location = new System.Drawing.Point(83, 51);
            this.cbAlarmasPosicion.Name = "cbAlarmasPosicion";
            this.cbAlarmasPosicion.Size = new System.Drawing.Size(689, 24);
            this.cbAlarmasPosicion.TabIndex = 3;
            // 
            // bAlarmasMonitorFind
            // 
            this.bAlarmasMonitorFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bAlarmasMonitorFind.Image = ((System.Drawing.Image)(resources.GetObject("bAlarmasMonitorFind.Image")));
            this.bAlarmasMonitorFind.Location = new System.Drawing.Point(748, 21);
            this.bAlarmasMonitorFind.Name = "bAlarmasMonitorFind";
            this.bAlarmasMonitorFind.Size = new System.Drawing.Size(24, 24);
            this.bAlarmasMonitorFind.TabIndex = 2;
            this.bAlarmasMonitorFind.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 25);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(52, 16);
            this.label16.TabIndex = 1;
            this.label16.Text = "Monitor";
            // 
            // cbAlarmasMonitor
            // 
            this.cbAlarmasMonitor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAlarmasMonitor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAlarmasMonitor.FormattingEnabled = true;
            this.cbAlarmasMonitor.Location = new System.Drawing.Point(83, 21);
            this.cbAlarmasMonitor.Name = "cbAlarmasMonitor";
            this.cbAlarmasMonitor.Size = new System.Drawing.Size(659, 24);
            this.cbAlarmasMonitor.TabIndex = 0;
            // 
            // tabMemory
            // 
            this.tabMemory.Controls.Add(this.pMemoryEdit);
            this.tabMemory.Controls.Add(this.pMemoryData);
            this.tabMemory.Controls.Add(this.pMemoryFilter);
            this.tabMemory.Location = new System.Drawing.Point(4, 25);
            this.tabMemory.Name = "tabMemory";
            this.tabMemory.Padding = new System.Windows.Forms.Padding(3);
            this.tabMemory.Size = new System.Drawing.Size(790, 562);
            this.tabMemory.TabIndex = 2;
            this.tabMemory.Text = "Memory";
            this.tabMemory.UseVisualStyleBackColor = true;
            // 
            // pMemoryEdit
            // 
            this.pMemoryEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pMemoryEdit.Controls.Add(this.bMemorySaveChanges);
            this.pMemoryEdit.Controls.Add(this.cbMemoryEntityGroup);
            this.pMemoryEdit.Controls.Add(this.label6);
            this.pMemoryEdit.Controls.Add(this.tMemoryEntityValue);
            this.pMemoryEdit.Controls.Add(this.tMemoryEntityKey);
            this.pMemoryEdit.Controls.Add(this.label4);
            this.pMemoryEdit.Controls.Add(this.label5);
            this.pMemoryEdit.Controls.Add(this.bMemoryDelete);
            this.pMemoryEdit.Controls.Add(this.bMemoryAddNew);
            this.pMemoryEdit.Location = new System.Drawing.Point(6, 366);
            this.pMemoryEdit.Name = "pMemoryEdit";
            this.pMemoryEdit.Size = new System.Drawing.Size(778, 190);
            this.pMemoryEdit.TabIndex = 2;
            this.pMemoryEdit.TabStop = false;
            this.pMemoryEdit.Text = "Edición";
            // 
            // bMemorySaveChanges
            // 
            this.bMemorySaveChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bMemorySaveChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bMemorySaveChanges.ImageKey = "note_edit.ICO";
            this.bMemorySaveChanges.Location = new System.Drawing.Point(696, 156);
            this.bMemorySaveChanges.Name = "bMemorySaveChanges";
            this.bMemorySaveChanges.Size = new System.Drawing.Size(74, 27);
            this.bMemorySaveChanges.TabIndex = 8;
            this.bMemorySaveChanges.Text = "Guardar";
            this.bMemorySaveChanges.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bMemorySaveChanges.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bMemorySaveChanges.UseVisualStyleBackColor = true;
            // 
            // cbMemoryEntityGroup
            // 
            this.cbMemoryEntityGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMemoryEntityGroup.FormattingEnabled = true;
            this.cbMemoryEntityGroup.Location = new System.Drawing.Point(69, 21);
            this.cbMemoryEntityGroup.Name = "cbMemoryEntityGroup";
            this.cbMemoryEntityGroup.Size = new System.Drawing.Size(703, 24);
            this.cbMemoryEntityGroup.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Valor";
            // 
            // tMemoryEntityValue
            // 
            this.tMemoryEntityValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tMemoryEntityValue.Location = new System.Drawing.Point(69, 79);
            this.tMemoryEntityValue.Multiline = true;
            this.tMemoryEntityValue.Name = "tMemoryEntityValue";
            this.tMemoryEntityValue.Size = new System.Drawing.Size(703, 71);
            this.tMemoryEntityValue.TabIndex = 5;
            // 
            // tMemoryEntityKey
            // 
            this.tMemoryEntityKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tMemoryEntityKey.Location = new System.Drawing.Point(69, 51);
            this.tMemoryEntityKey.Name = "tMemoryEntityKey";
            this.tMemoryEntityKey.Size = new System.Drawing.Size(703, 22);
            this.tMemoryEntityKey.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nombre";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Grupo";
            // 
            // bMemoryDelete
            // 
            this.bMemoryDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bMemoryDelete.ImageList = this.images;
            this.bMemoryDelete.Location = new System.Drawing.Point(81, 156);
            this.bMemoryDelete.Name = "bMemoryDelete";
            this.bMemoryDelete.Size = new System.Drawing.Size(71, 27);
            this.bMemoryDelete.TabIndex = 7;
            this.bMemoryDelete.Text = "Eliminar";
            this.bMemoryDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bMemoryDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bMemoryDelete.UseVisualStyleBackColor = true;
            // 
            // images
            // 
            this.images.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.images.ImageSize = new System.Drawing.Size(16, 16);
            this.images.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // bMemoryAddNew
            // 
            this.bMemoryAddNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bMemoryAddNew.Location = new System.Drawing.Point(9, 156);
            this.bMemoryAddNew.Name = "bMemoryAddNew";
            this.bMemoryAddNew.Size = new System.Drawing.Size(66, 27);
            this.bMemoryAddNew.TabIndex = 6;
            this.bMemoryAddNew.Text = "Nuevo";
            this.bMemoryAddNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bMemoryAddNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bMemoryAddNew.UseVisualStyleBackColor = true;
            // 
            // pMemoryData
            // 
            this.pMemoryData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pMemoryData.Controls.Add(this.gMemoryData);
            this.pMemoryData.Location = new System.Drawing.Point(6, 91);
            this.pMemoryData.Name = "pMemoryData";
            this.pMemoryData.Size = new System.Drawing.Size(778, 269);
            this.pMemoryData.TabIndex = 1;
            this.pMemoryData.TabStop = false;
            this.pMemoryData.Text = "Datos";
            // 
            // gMemoryData
            // 
            this.gMemoryData.AllowUserToAddRows = false;
            this.gMemoryData.AllowUserToDeleteRows = false;
            this.gMemoryData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gMemoryData.AutoGenerateColumns = false;
            this.gMemoryData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gMemoryData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.groupDataGridViewTextBoxColumn,
            this.keyDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn});
            this.gMemoryData.DataSource = this.gMemoryDataSource;
            this.gMemoryData.Location = new System.Drawing.Point(6, 21);
            this.gMemoryData.MultiSelect = false;
            this.gMemoryData.Name = "gMemoryData";
            this.gMemoryData.ReadOnly = true;
            this.gMemoryData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gMemoryData.ShowEditingIcon = false;
            this.gMemoryData.ShowRowErrors = false;
            this.gMemoryData.Size = new System.Drawing.Size(766, 242);
            this.gMemoryData.TabIndex = 2;
            // 
            // pMemoryFilter
            // 
            this.pMemoryFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pMemoryFilter.Controls.Add(this.cbMemoryFilterGroup);
            this.pMemoryFilter.Controls.Add(this.tMemoryFilterKey);
            this.pMemoryFilter.Controls.Add(this.label3);
            this.pMemoryFilter.Controls.Add(this.label2);
            this.pMemoryFilter.Location = new System.Drawing.Point(6, 6);
            this.pMemoryFilter.Name = "pMemoryFilter";
            this.pMemoryFilter.Size = new System.Drawing.Size(778, 79);
            this.pMemoryFilter.TabIndex = 0;
            this.pMemoryFilter.TabStop = false;
            this.pMemoryFilter.Text = "Filtro";
            // 
            // cbMemoryFilterGroup
            // 
            this.cbMemoryFilterGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMemoryFilterGroup.FormattingEnabled = true;
            this.cbMemoryFilterGroup.Location = new System.Drawing.Point(69, 21);
            this.cbMemoryFilterGroup.Name = "cbMemoryFilterGroup";
            this.cbMemoryFilterGroup.Size = new System.Drawing.Size(703, 24);
            this.cbMemoryFilterGroup.TabIndex = 0;
            // 
            // tMemoryFilterKey
            // 
            this.tMemoryFilterKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tMemoryFilterKey.Location = new System.Drawing.Point(69, 51);
            this.tMemoryFilterKey.Name = "tMemoryFilterKey";
            this.tMemoryFilterKey.Size = new System.Drawing.Size(703, 22);
            this.tMemoryFilterKey.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Grupo";
            // 
            // tabGCBA
            // 
            this.tabGCBA.Controls.Add(this.pGCBAAmbientes);
            this.tabGCBA.Controls.Add(this.pGCBAData);
            this.tabGCBA.Location = new System.Drawing.Point(4, 25);
            this.tabGCBA.Name = "tabGCBA";
            this.tabGCBA.Padding = new System.Windows.Forms.Padding(3);
            this.tabGCBA.Size = new System.Drawing.Size(790, 562);
            this.tabGCBA.TabIndex = 4;
            this.tabGCBA.Text = "Ambientes GCBA";
            this.tabGCBA.UseVisualStyleBackColor = true;
            // 
            // pGCBAAmbientes
            // 
            this.pGCBAAmbientes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pGCBAAmbientes.Controls.Add(this.bGCBAAmbienteDelete);
            this.pGCBAAmbientes.Controls.Add(this.bGCBAAmbienteNew);
            this.pGCBAAmbientes.Controls.Add(this.tGCBAFilter);
            this.pGCBAAmbientes.Controls.Add(this.lbGCBAAmbientes);
            this.pGCBAAmbientes.Location = new System.Drawing.Point(6, 6);
            this.pGCBAAmbientes.Name = "pGCBAAmbientes";
            this.pGCBAAmbientes.Size = new System.Drawing.Size(203, 550);
            this.pGCBAAmbientes.TabIndex = 3;
            this.pGCBAAmbientes.TabStop = false;
            this.pGCBAAmbientes.Text = "Ambientes";
            // 
            // bGCBAAmbienteDelete
            // 
            this.bGCBAAmbienteDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bGCBAAmbienteDelete.ImageList = this.images;
            this.bGCBAAmbienteDelete.Location = new System.Drawing.Point(106, 49);
            this.bGCBAAmbienteDelete.Name = "bGCBAAmbienteDelete";
            this.bGCBAAmbienteDelete.Size = new System.Drawing.Size(91, 27);
            this.bGCBAAmbienteDelete.TabIndex = 8;
            this.bGCBAAmbienteDelete.Text = "Eliminar";
            this.bGCBAAmbienteDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bGCBAAmbienteDelete.UseVisualStyleBackColor = true;
            // 
            // bGCBAAmbienteNew
            // 
            this.bGCBAAmbienteNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bGCBAAmbienteNew.Location = new System.Drawing.Point(6, 49);
            this.bGCBAAmbienteNew.Name = "bGCBAAmbienteNew";
            this.bGCBAAmbienteNew.Size = new System.Drawing.Size(91, 27);
            this.bGCBAAmbienteNew.TabIndex = 7;
            this.bGCBAAmbienteNew.Text = "Nuevo";
            this.bGCBAAmbienteNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bGCBAAmbienteNew.UseVisualStyleBackColor = true;
            // 
            // tGCBAFilter
            // 
            this.tGCBAFilter.Location = new System.Drawing.Point(6, 21);
            this.tGCBAFilter.Name = "tGCBAFilter";
            this.tGCBAFilter.Size = new System.Drawing.Size(191, 22);
            this.tGCBAFilter.TabIndex = 0;
            // 
            // lbGCBAAmbientes
            // 
            this.lbGCBAAmbientes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbGCBAAmbientes.FormattingEnabled = true;
            this.lbGCBAAmbientes.ItemHeight = 16;
            this.lbGCBAAmbientes.Location = new System.Drawing.Point(6, 82);
            this.lbGCBAAmbientes.Name = "lbGCBAAmbientes";
            this.lbGCBAAmbientes.Size = new System.Drawing.Size(191, 436);
            this.lbGCBAAmbientes.TabIndex = 1;
            // 
            // pGCBAData
            // 
            this.pGCBAData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pGCBAData.Controls.Add(this.pGCBAWebs);
            this.pGCBAData.Controls.Add(this.bGCBADataSave);
            this.pGCBAData.Controls.Add(this.pGCBADataWeb);
            this.pGCBAData.Controls.Add(this.label9);
            this.pGCBAData.Controls.Add(this.tGCBADataName);
            this.pGCBAData.Location = new System.Drawing.Point(215, 6);
            this.pGCBAData.Name = "pGCBAData";
            this.pGCBAData.Size = new System.Drawing.Size(569, 550);
            this.pGCBAData.TabIndex = 2;
            this.pGCBAData.TabStop = false;
            this.pGCBAData.Text = "Datos";
            // 
            // pGCBAWebs
            // 
            this.pGCBAWebs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pGCBAWebs.Controls.Add(this.bGCBAWebsDelete);
            this.pGCBAWebs.Controls.Add(this.bGCBAWebsNew);
            this.pGCBAWebs.Controls.Add(this.label14);
            this.pGCBAWebs.Controls.Add(this.tGCBAWebsName);
            this.pGCBAWebs.Controls.Add(this.label13);
            this.pGCBAWebs.Controls.Add(this.tGCBAWebsUrl);
            this.pGCBAWebs.Controls.Add(this.lbGCBAWebsList);
            this.pGCBAWebs.Location = new System.Drawing.Point(6, 253);
            this.pGCBAWebs.Name = "pGCBAWebs";
            this.pGCBAWebs.Size = new System.Drawing.Size(557, 258);
            this.pGCBAWebs.TabIndex = 10;
            this.pGCBAWebs.TabStop = false;
            this.pGCBAWebs.Text = "Webs";
            // 
            // bGCBAWebsDelete
            // 
            this.bGCBAWebsDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bGCBAWebsDelete.ImageList = this.images;
            this.bGCBAWebsDelete.Location = new System.Drawing.Point(71, 21);
            this.bGCBAWebsDelete.Name = "bGCBAWebsDelete";
            this.bGCBAWebsDelete.Size = new System.Drawing.Size(55, 27);
            this.bGCBAWebsDelete.TabIndex = 12;
            this.bGCBAWebsDelete.Text = "Eliminar";
            this.bGCBAWebsDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bGCBAWebsDelete.UseVisualStyleBackColor = true;
            // 
            // bGCBAWebsNew
            // 
            this.bGCBAWebsNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bGCBAWebsNew.Location = new System.Drawing.Point(6, 21);
            this.bGCBAWebsNew.Name = "bGCBAWebsNew";
            this.bGCBAWebsNew.Size = new System.Drawing.Size(55, 27);
            this.bGCBAWebsNew.TabIndex = 11;
            this.bGCBAWebsNew.Text = "Nuevo";
            this.bGCBAWebsNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bGCBAWebsNew.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(132, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 16);
            this.label14.TabIndex = 10;
            this.label14.Text = "Nombre";
            // 
            // tGCBAWebsName
            // 
            this.tGCBAWebsName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tGCBAWebsName.Location = new System.Drawing.Point(195, 21);
            this.tGCBAWebsName.Name = "tGCBAWebsName";
            this.tGCBAWebsName.Size = new System.Drawing.Size(356, 22);
            this.tGCBAWebsName.TabIndex = 9;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(132, 52);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(25, 16);
            this.label13.TabIndex = 8;
            this.label13.Text = "Url";
            // 
            // tGCBAWebsUrl
            // 
            this.tGCBAWebsUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tGCBAWebsUrl.Location = new System.Drawing.Point(195, 49);
            this.tGCBAWebsUrl.Name = "tGCBAWebsUrl";
            this.tGCBAWebsUrl.Size = new System.Drawing.Size(356, 22);
            this.tGCBAWebsUrl.TabIndex = 7;
            // 
            // lbGCBAWebsList
            // 
            this.lbGCBAWebsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbGCBAWebsList.FormattingEnabled = true;
            this.lbGCBAWebsList.ItemHeight = 16;
            this.lbGCBAWebsList.Location = new System.Drawing.Point(6, 54);
            this.lbGCBAWebsList.Name = "lbGCBAWebsList";
            this.lbGCBAWebsList.Size = new System.Drawing.Size(120, 164);
            this.lbGCBAWebsList.TabIndex = 0;
            // 
            // bGCBADataSave
            // 
            this.bGCBADataSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bGCBADataSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bGCBADataSave.ImageList = this.images;
            this.bGCBADataSave.Location = new System.Drawing.Point(472, 517);
            this.bGCBADataSave.Name = "bGCBADataSave";
            this.bGCBADataSave.Size = new System.Drawing.Size(91, 27);
            this.bGCBADataSave.TabIndex = 9;
            this.bGCBADataSave.Text = "Guardar";
            this.bGCBADataSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bGCBADataSave.UseVisualStyleBackColor = true;
            // 
            // pGCBADataWeb
            // 
            this.pGCBADataWeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pGCBADataWeb.Controls.Add(this.cbGCBAWebAllowRemote);
            this.pGCBADataWeb.Controls.Add(this.cbGCBAWebAllowExplorer);
            this.pGCBADataWeb.Controls.Add(this.label12);
            this.pGCBADataWeb.Controls.Add(this.label11);
            this.pGCBADataWeb.Controls.Add(this.tGCBACustomPass);
            this.pGCBADataWeb.Controls.Add(this.tGCBACustomUser);
            this.pGCBADataWeb.Controls.Add(this.cbGCBAUseCustomUser);
            this.pGCBADataWeb.Controls.Add(this.label10);
            this.pGCBADataWeb.Controls.Add(this.tGCBAWebIP);
            this.pGCBADataWeb.Location = new System.Drawing.Point(6, 63);
            this.pGCBADataWeb.Name = "pGCBADataWeb";
            this.pGCBADataWeb.Size = new System.Drawing.Size(557, 184);
            this.pGCBADataWeb.TabIndex = 4;
            this.pGCBADataWeb.TabStop = false;
            this.pGCBADataWeb.Text = "Servidor Web";
            // 
            // cbGCBAWebAllowRemote
            // 
            this.cbGCBAWebAllowRemote.AutoSize = true;
            this.cbGCBAWebAllowRemote.Location = new System.Drawing.Point(6, 75);
            this.cbGCBAWebAllowRemote.Name = "cbGCBAWebAllowRemote";
            this.cbGCBAWebAllowRemote.Size = new System.Drawing.Size(239, 20);
            this.cbGCBAWebAllowRemote.TabIndex = 9;
            this.cbGCBAWebAllowRemote.Text = "Permite Abrir con Escritorio Remoto";
            this.cbGCBAWebAllowRemote.UseVisualStyleBackColor = true;
            // 
            // cbGCBAWebAllowExplorer
            // 
            this.cbGCBAWebAllowExplorer.AutoSize = true;
            this.cbGCBAWebAllowExplorer.Location = new System.Drawing.Point(6, 49);
            this.cbGCBAWebAllowExplorer.Name = "cbGCBAWebAllowExplorer";
            this.cbGCBAWebAllowExplorer.Size = new System.Drawing.Size(175, 20);
            this.cbGCBAWebAllowExplorer.TabIndex = 8;
            this.cbGCBAWebAllowExplorer.Text = "Permite Abrir en Explorer";
            this.cbGCBAWebAllowExplorer.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 158);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 16);
            this.label12.TabIndex = 7;
            this.label12.Text = "Password";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 130);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 16);
            this.label11.TabIndex = 6;
            this.label11.Text = "Usuario";
            // 
            // tGCBACustomPass
            // 
            this.tGCBACustomPass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tGCBACustomPass.Enabled = false;
            this.tGCBACustomPass.Location = new System.Drawing.Point(77, 155);
            this.tGCBACustomPass.Name = "tGCBACustomPass";
            this.tGCBACustomPass.Size = new System.Drawing.Size(474, 22);
            this.tGCBACustomPass.TabIndex = 5;
            // 
            // tGCBACustomUser
            // 
            this.tGCBACustomUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tGCBACustomUser.Enabled = false;
            this.tGCBACustomUser.Location = new System.Drawing.Point(77, 127);
            this.tGCBACustomUser.Name = "tGCBACustomUser";
            this.tGCBACustomUser.Size = new System.Drawing.Size(474, 22);
            this.tGCBACustomUser.TabIndex = 4;
            // 
            // cbGCBAUseCustomUser
            // 
            this.cbGCBAUseCustomUser.AutoSize = true;
            this.cbGCBAUseCustomUser.Location = new System.Drawing.Point(6, 101);
            this.cbGCBAUseCustomUser.Name = "cbGCBAUseCustomUser";
            this.cbGCBAUseCustomUser.Size = new System.Drawing.Size(210, 20);
            this.cbGCBAUseCustomUser.TabIndex = 3;
            this.cbGCBAUseCustomUser.Text = "Usar Credenciales Especiales";
            this.cbGCBAUseCustomUser.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 16);
            this.label10.TabIndex = 2;
            this.label10.Text = "IP";
            // 
            // tGCBAWebIP
            // 
            this.tGCBAWebIP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tGCBAWebIP.Location = new System.Drawing.Point(77, 21);
            this.tGCBAWebIP.Name = "tGCBAWebIP";
            this.tGCBAWebIP.Size = new System.Drawing.Size(474, 22);
            this.tGCBAWebIP.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 16);
            this.label9.TabIndex = 1;
            this.label9.Text = "Ambiente";
            // 
            // tGCBADataName
            // 
            this.tGCBADataName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tGCBADataName.Location = new System.Drawing.Point(77, 21);
            this.tGCBADataName.Name = "tGCBADataName";
            this.tGCBADataName.Size = new System.Drawing.Size(486, 22);
            this.tGCBADataName.TabIndex = 0;
            // 
            // tabLinks
            // 
            this.tabLinks.Controls.Add(this.gLinkData);
            this.tabLinks.Controls.Add(this.gLinks);
            this.tabLinks.Location = new System.Drawing.Point(4, 25);
            this.tabLinks.Name = "tabLinks";
            this.tabLinks.Padding = new System.Windows.Forms.Padding(3);
            this.tabLinks.Size = new System.Drawing.Size(790, 562);
            this.tabLinks.TabIndex = 8;
            this.tabLinks.Text = "Accesos Directos";
            this.tabLinks.UseVisualStyleBackColor = true;
            // 
            // gLinkData
            // 
            this.gLinkData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gLinkData.Controls.Add(this.bLinkSave);
            this.gLinkData.Controls.Add(this.gLinkFolder);
            this.gLinkData.Controls.Add(this.tLinkEditPathFind);
            this.gLinkData.Controls.Add(this.label20);
            this.gLinkData.Controls.Add(this.tLinkEditPath);
            this.gLinkData.Controls.Add(this.tLinkEditName);
            this.gLinkData.Controls.Add(this.label19);
            this.gLinkData.Controls.Add(this.gLinkDataImage);
            this.gLinkData.Location = new System.Drawing.Point(336, 6);
            this.gLinkData.Name = "gLinkData";
            this.gLinkData.Size = new System.Drawing.Size(448, 550);
            this.gLinkData.TabIndex = 3;
            this.gLinkData.TabStop = false;
            this.gLinkData.Text = "Edición";
            // 
            // bLinkSave
            // 
            this.bLinkSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bLinkSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bLinkSave.ImageList = this.images;
            this.bLinkSave.Location = new System.Drawing.Point(351, 517);
            this.bLinkSave.Name = "bLinkSave";
            this.bLinkSave.Size = new System.Drawing.Size(91, 27);
            this.bLinkSave.TabIndex = 10;
            this.bLinkSave.Text = "Guardar";
            this.bLinkSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bLinkSave.UseVisualStyleBackColor = true;
            // 
            // gLinkFolder
            // 
            this.gLinkFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gLinkFolder.Controls.Add(this.cbLinkShowOpen);
            this.gLinkFolder.Controls.Add(this.cbLinkShowSubFolders);
            this.gLinkFolder.Controls.Add(this.tLinkFolderFileFilter);
            this.gLinkFolder.Controls.Add(this.label21);
            this.gLinkFolder.Controls.Add(this.cbLinkShowFolderContent);
            this.gLinkFolder.Location = new System.Drawing.Point(6, 378);
            this.gLinkFolder.Name = "gLinkFolder";
            this.gLinkFolder.Size = new System.Drawing.Size(436, 133);
            this.gLinkFolder.TabIndex = 8;
            this.gLinkFolder.TabStop = false;
            this.gLinkFolder.Text = "Opciones de Carpeta";
            // 
            // cbLinkShowSubFolders
            // 
            this.cbLinkShowSubFolders.AutoSize = true;
            this.cbLinkShowSubFolders.Enabled = false;
            this.cbLinkShowSubFolders.Location = new System.Drawing.Point(25, 73);
            this.cbLinkShowSubFolders.Name = "cbLinkShowSubFolders";
            this.cbLinkShowSubFolders.Size = new System.Drawing.Size(230, 20);
            this.cbLinkShowSubFolders.TabIndex = 9;
            this.cbLinkShowSubFolders.Text = "Mostrar SubCarpetas en Cascada";
            this.cbLinkShowSubFolders.UseVisualStyleBackColor = true;
            // 
            // tLinkFolderFileFilter
            // 
            this.tLinkFolderFileFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tLinkFolderFileFilter.Location = new System.Drawing.Point(49, 99);
            this.tLinkFolderFileFilter.Name = "tLinkFolderFileFilter";
            this.tLinkFolderFileFilter.Size = new System.Drawing.Size(381, 22);
            this.tLinkFolderFileFilter.TabIndex = 8;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(6, 102);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(37, 16);
            this.label21.TabIndex = 7;
            this.label21.Text = "Filtro";
            // 
            // cbLinkShowFolderContent
            // 
            this.cbLinkShowFolderContent.AutoSize = true;
            this.cbLinkShowFolderContent.Location = new System.Drawing.Point(6, 21);
            this.cbLinkShowFolderContent.Name = "cbLinkShowFolderContent";
            this.cbLinkShowFolderContent.Size = new System.Drawing.Size(220, 20);
            this.cbLinkShowFolderContent.TabIndex = 0;
            this.cbLinkShowFolderContent.Text = "Mostrar Contenido de la Carpeta";
            this.cbLinkShowFolderContent.UseVisualStyleBackColor = true;
            // 
            // tLinkEditPathFind
            // 
            this.tLinkEditPathFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tLinkEditPathFind.Image = ((System.Drawing.Image)(resources.GetObject("tLinkEditPathFind.Image")));
            this.tLinkEditPathFind.Location = new System.Drawing.Point(417, 49);
            this.tLinkEditPathFind.Name = "tLinkEditPathFind";
            this.tLinkEditPathFind.Size = new System.Drawing.Size(25, 25);
            this.tLinkEditPathFind.TabIndex = 7;
            this.tLinkEditPathFind.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 53);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(36, 16);
            this.label20.TabIndex = 6;
            this.label20.Text = "Ruta";
            // 
            // tLinkEditPath
            // 
            this.tLinkEditPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tLinkEditPath.Location = new System.Drawing.Point(69, 50);
            this.tLinkEditPath.Name = "tLinkEditPath";
            this.tLinkEditPath.ReadOnly = true;
            this.tLinkEditPath.Size = new System.Drawing.Size(346, 22);
            this.tLinkEditPath.TabIndex = 5;
            // 
            // tLinkEditName
            // 
            this.tLinkEditName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tLinkEditName.Location = new System.Drawing.Point(69, 21);
            this.tLinkEditName.Name = "tLinkEditName";
            this.tLinkEditName.Size = new System.Drawing.Size(373, 22);
            this.tLinkEditName.TabIndex = 4;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 24);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(57, 16);
            this.label19.TabIndex = 3;
            this.label19.Text = "Nombre";
            // 
            // gLinkDataImage
            // 
            this.gLinkDataImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gLinkDataImage.Controls.Add(this.bLinkImgCustomFind);
            this.gLinkDataImage.Controls.Add(this.label22);
            this.gLinkDataImage.Controls.Add(this.tLinkImgCustom);
            this.gLinkDataImage.Controls.Add(this.gLinkDataImageDiv);
            this.gLinkDataImage.Location = new System.Drawing.Point(6, 78);
            this.gLinkDataImage.Name = "gLinkDataImage";
            this.gLinkDataImage.Size = new System.Drawing.Size(436, 294);
            this.gLinkDataImage.TabIndex = 2;
            this.gLinkDataImage.TabStop = false;
            this.gLinkDataImage.Text = "Imagen";
            // 
            // bLinkImgCustomFind
            // 
            this.bLinkImgCustomFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bLinkImgCustomFind.Image = ((System.Drawing.Image)(resources.GetObject("bLinkImgCustomFind.Image")));
            this.bLinkImgCustomFind.Location = new System.Drawing.Point(405, 263);
            this.bLinkImgCustomFind.Name = "bLinkImgCustomFind";
            this.bLinkImgCustomFind.Size = new System.Drawing.Size(25, 25);
            this.bLinkImgCustomFind.TabIndex = 10;
            this.bLinkImgCustomFind.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 267);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(53, 16);
            this.label22.TabIndex = 9;
            this.label22.Text = "Custom";
            // 
            // tLinkImgCustom
            // 
            this.tLinkImgCustom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tLinkImgCustom.Location = new System.Drawing.Point(65, 264);
            this.tLinkImgCustom.Name = "tLinkImgCustom";
            this.tLinkImgCustom.ReadOnly = true;
            this.tLinkImgCustom.Size = new System.Drawing.Size(338, 22);
            this.tLinkImgCustom.TabIndex = 8;
            // 
            // gLinkDataImageDiv
            // 
            this.gLinkDataImageDiv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gLinkDataImageDiv.AutoScroll = true;
            this.gLinkDataImageDiv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gLinkDataImageDiv.Location = new System.Drawing.Point(6, 21);
            this.gLinkDataImageDiv.Name = "gLinkDataImageDiv";
            this.gLinkDataImageDiv.Size = new System.Drawing.Size(424, 236);
            this.gLinkDataImageDiv.TabIndex = 0;
            // 
            // gLinks
            // 
            this.gLinks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gLinks.Controls.Add(this.tLinksFilter);
            this.gLinks.Controls.Add(this.tvLinks);
            this.gLinks.Location = new System.Drawing.Point(6, 6);
            this.gLinks.Name = "gLinks";
            this.gLinks.Size = new System.Drawing.Size(324, 550);
            this.gLinks.TabIndex = 2;
            this.gLinks.TabStop = false;
            this.gLinks.Text = "Accesos Directos";
            // 
            // tLinksFilter
            // 
            this.tLinksFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tLinksFilter.Location = new System.Drawing.Point(6, 21);
            this.tLinksFilter.Name = "tLinksFilter";
            this.tLinksFilter.Size = new System.Drawing.Size(312, 22);
            this.tLinksFilter.TabIndex = 1;
            // 
            // tvLinks
            // 
            this.tvLinks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvLinks.FullRowSelect = true;
            this.tvLinks.Location = new System.Drawing.Point(6, 49);
            this.tvLinks.Name = "tvLinks";
            this.tvLinks.Size = new System.Drawing.Size(312, 495);
            this.tvLinks.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cbLinkShowOpen
            // 
            this.cbLinkShowOpen.AutoSize = true;
            this.cbLinkShowOpen.Enabled = false;
            this.cbLinkShowOpen.Location = new System.Drawing.Point(25, 47);
            this.cbLinkShowOpen.Name = "cbLinkShowOpen";
            this.cbLinkShowOpen.Size = new System.Drawing.Size(164, 20);
            this.cbLinkShowOpen.TabIndex = 12;
            this.cbLinkShowOpen.Text = "Mostrar \"Abrir Carpeta\"";
            this.cbLinkShowOpen.UseVisualStyleBackColor = true;
            // 
            // codeDataGridViewTextBoxColumn1
            // 
            this.codeDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.codeDataGridViewTextBoxColumn1.DataPropertyName = "Code";
            this.codeDataGridViewTextBoxColumn1.HeaderText = "Code";
            this.codeDataGridViewTextBoxColumn1.Name = "codeDataGridViewTextBoxColumn1";
            this.codeDataGridViewTextBoxColumn1.ReadOnly = true;
            this.codeDataGridViewTextBoxColumn1.Width = 80;
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            this.nameDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // jqlDataGridViewTextBoxColumn1
            // 
            this.jqlDataGridViewTextBoxColumn1.DataPropertyName = "Jql";
            this.jqlDataGridViewTextBoxColumn1.HeaderText = "Jql";
            this.jqlDataGridViewTextBoxColumn1.Name = "jqlDataGridViewTextBoxColumn1";
            this.jqlDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // jiraFilterBindingSource
            // 
            this.jiraFilterBindingSource.DataSource = typeof(CSWork.DTO.GlobalConfigs.JiraFilter);
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
            this.codeDataGridViewTextBoxColumn.FillWeight = 62.87201F;
            this.codeDataGridViewTextBoxColumn.HeaderText = "Code";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.ReadOnly = true;
            this.codeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.codeDataGridViewTextBoxColumn.Width = 80;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.FillWeight = 92.42186F;
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // jqlDataGridViewTextBoxColumn
            // 
            this.jqlDataGridViewTextBoxColumn.DataPropertyName = "Jql";
            this.jqlDataGridViewTextBoxColumn.FillWeight = 92.42186F;
            this.jqlDataGridViewTextBoxColumn.HeaderText = "Jql";
            this.jqlDataGridViewTextBoxColumn.Name = "jqlDataGridViewTextBoxColumn";
            this.jqlDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // groupDataGridViewTextBoxColumn
            // 
            this.groupDataGridViewTextBoxColumn.DataPropertyName = "Group";
            this.groupDataGridViewTextBoxColumn.HeaderText = "Grupo";
            this.groupDataGridViewTextBoxColumn.Name = "groupDataGridViewTextBoxColumn";
            this.groupDataGridViewTextBoxColumn.ReadOnly = true;
            this.groupDataGridViewTextBoxColumn.Width = 150;
            // 
            // keyDataGridViewTextBoxColumn
            // 
            this.keyDataGridViewTextBoxColumn.DataPropertyName = "Key";
            this.keyDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.keyDataGridViewTextBoxColumn.Name = "keyDataGridViewTextBoxColumn";
            this.keyDataGridViewTextBoxColumn.ReadOnly = true;
            this.keyDataGridViewTextBoxColumn.Width = 170;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "Valor";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            this.valueDataGridViewTextBoxColumn.ReadOnly = true;
            this.valueDataGridViewTextBoxColumn.Width = 400;
            // 
            // gMemoryDataSource
            // 
            this.gMemoryDataSource.DataSource = typeof(CSWork.DTO.GlobalConfigs.Memory);
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 619);
            this.Controls.Add(this.tab);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(405, 505);
            this.Name = "Configuration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración";
            this.tab.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.pModulos.ResumeLayout(false);
            this.pModulos.PerformLayout();
            this.pGeneralApps.ResumeLayout(false);
            this.pGeneralApps.PerformLayout();
            this.pGCBARed.ResumeLayout(false);
            this.pGCBARed.PerformLayout();
            this.pGeneralWindows.ResumeLayout(false);
            this.pGeneralWindows.PerformLayout();
            this.tabJira.ResumeLayout(false);
            this.pJiraAutenticacion.ResumeLayout(false);
            this.pJiraAutenticacion.PerformLayout();
            this.tabWork.ResumeLayout(false);
            this.pWorkFiltros.ResumeLayout(false);
            this.pWorkFiltrosSys.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gWorkFilters)).EndInit();
            this.pWorkFiltrosJira.ResumeLayout(false);
            this.pWorkFiltrosJira.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gWorkJiraFilters)).EndInit();
            this.pWorkGeneral.ResumeLayout(false);
            this.pWorkGeneral.PerformLayout();
            this.tabAlarmas.ResumeLayout(false);
            this.pAlarmTempo.ResumeLayout(false);
            this.pAlarmTempo.PerformLayout();
            this.pAlarmaIssues.ResumeLayout(false);
            this.pAlarmaIssues.PerformLayout();
            this.pAlarmaApariencia.ResumeLayout(false);
            this.pAlarmaApariencia.PerformLayout();
            this.tabMemory.ResumeLayout(false);
            this.pMemoryEdit.ResumeLayout(false);
            this.pMemoryEdit.PerformLayout();
            this.pMemoryData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gMemoryData)).EndInit();
            this.pMemoryFilter.ResumeLayout(false);
            this.pMemoryFilter.PerformLayout();
            this.tabGCBA.ResumeLayout(false);
            this.pGCBAAmbientes.ResumeLayout(false);
            this.pGCBAAmbientes.PerformLayout();
            this.pGCBAData.ResumeLayout(false);
            this.pGCBAData.PerformLayout();
            this.pGCBAWebs.ResumeLayout(false);
            this.pGCBAWebs.PerformLayout();
            this.pGCBADataWeb.ResumeLayout(false);
            this.pGCBADataWeb.PerformLayout();
            this.tabLinks.ResumeLayout(false);
            this.gLinkData.ResumeLayout(false);
            this.gLinkData.PerformLayout();
            this.gLinkFolder.ResumeLayout(false);
            this.gLinkFolder.PerformLayout();
            this.gLinkDataImage.ResumeLayout(false);
            this.gLinkDataImage.PerformLayout();
            this.gLinks.ResumeLayout(false);
            this.gLinks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jiraFilterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gMemoryDataSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabJira;
        private System.Windows.Forms.TabPage tabMemory;
        private System.Windows.Forms.GroupBox pGeneralWindows;
        private System.Windows.Forms.CheckBox cbGeneralStartWithWindows;
        private System.Windows.Forms.GroupBox pJiraAutenticacion;
        private System.Windows.Forms.TextBox tJiraUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bJiraLogin;
        private System.Windows.Forms.Button bJiraDisconnect;
        private System.Windows.Forms.GroupBox pMemoryData;
        private System.Windows.Forms.GroupBox pMemoryFilter;
        private System.Windows.Forms.TextBox tMemoryFilterKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bMemoryAddNew;
        private System.Windows.Forms.DataGridView gMemoryData;
        private System.Windows.Forms.GroupBox pMemoryEdit;
        private System.Windows.Forms.Button bMemoryDelete;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tMemoryEntityValue;
        private System.Windows.Forms.TextBox tMemoryEntityKey;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbMemoryEntityGroup;
        private System.Windows.Forms.ComboBox cbMemoryFilterGroup;
        private System.Windows.Forms.Button bMemorySaveChanges;
        private System.Windows.Forms.ImageList images;
        private System.Windows.Forms.BindingSource gMemoryDataSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.TabPage tabGCBA;
        private System.Windows.Forms.GroupBox pGCBARed;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tGeneralGCBARedPass;
        private System.Windows.Forms.TextBox tGeneralGCBARedUser;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox pGCBAData;
        private System.Windows.Forms.ListBox lbGCBAAmbientes;
        private System.Windows.Forms.TextBox tGCBAFilter;
        private System.Windows.Forms.TextBox tGCBADataName;
        private System.Windows.Forms.GroupBox pGCBADataWeb;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tGCBAWebIP;
        private System.Windows.Forms.GroupBox pGCBAAmbientes;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button bGCBAAmbienteDelete;
        private System.Windows.Forms.Button bGCBAAmbienteNew;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tGCBACustomPass;
        private System.Windows.Forms.TextBox tGCBACustomUser;
        private System.Windows.Forms.CheckBox cbGCBAUseCustomUser;
        private System.Windows.Forms.Button bGCBADataSave;
        private System.Windows.Forms.GroupBox pGCBAWebs;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tGCBAWebsName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tGCBAWebsUrl;
        private System.Windows.Forms.ListBox lbGCBAWebsList;
        private System.Windows.Forms.Button bGCBAWebsDelete;
        private System.Windows.Forms.Button bGCBAWebsNew;
        private System.Windows.Forms.GroupBox pGeneralApps;
        private System.Windows.Forms.Button bAppsWebSearch;
        private System.Windows.Forms.TextBox tAppsWeb;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button bAppsWebNone;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox cbGCBAWebAllowRemote;
        private System.Windows.Forms.CheckBox cbGCBAWebAllowExplorer;
        private System.Windows.Forms.GroupBox pModulos;
        private System.Windows.Forms.CheckBox cbGeneralModuloAlarmas;
        private System.Windows.Forms.CheckBox cbGeneralModuloMemory;
        private System.Windows.Forms.CheckBox cbGeneralModuloAmbiente;
        private System.Windows.Forms.TabPage tabWork;
        private System.Windows.Forms.GroupBox pWorkGeneral;
        private System.Windows.Forms.CheckBox cbWorkWithoutIssue;
        private System.Windows.Forms.GroupBox pWorkFiltros;
        private System.Windows.Forms.GroupBox pWorkFiltrosJira;
        private System.Windows.Forms.Button bWorkJiraFiltersAdd;
        private System.Windows.Forms.DataGridView gWorkJiraFilters;
        private System.Windows.Forms.Button bWorkRefreshJiraFilters;
        private System.Windows.Forms.GroupBox pWorkFiltrosSys;
        private System.Windows.Forms.Button bWorkFiltersRemove;
        private System.Windows.Forms.DataGridView gWorkFilters;
        private System.Windows.Forms.BindingSource jiraFilterBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn jqlDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jqlDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox tWorkJiraFiltersFilter;
        private System.Windows.Forms.TabPage tabAlarmas;
        private System.Windows.Forms.GroupBox pAlarmaApariencia;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cbAlarmasMonitor;
        private System.Windows.Forms.Button bAlarmasMonitorFind;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cbAlarmasPosicion;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbAlarmasAnimacion;
        private System.Windows.Forms.GroupBox pAlarmaIssues;
        private System.Windows.Forms.CheckBox cbAlarmIssuePriorityChanged;
        private System.Windows.Forms.CheckBox cbAlarmIssueAdjuntoChanged;
        private System.Windows.Forms.CheckBox cbAlarmIssueCommentChanged;
        private System.Windows.Forms.CheckBox cbAlarmIssueAlarmEnabled;
        private System.Windows.Forms.GroupBox pAlarmTempo;
        private System.Windows.Forms.CheckBox cbAlarmTempoAtEndPeriod;
        private System.Windows.Forms.CheckBox cbAlarmTempoAtEndWeek;
        private System.Windows.Forms.CheckBox cbAlarmTempoAtEndDay;
        private System.Windows.Forms.CheckBox cbGeneralModuloLink;
        private System.Windows.Forms.TabPage tabLinks;
        private System.Windows.Forms.GroupBox gLinkData;
        private System.Windows.Forms.GroupBox gLinks;
        private System.Windows.Forms.TextBox tLinksFilter;
        private System.Windows.Forms.TreeView tvLinks;
        private System.Windows.Forms.GroupBox gLinkDataImage;
        private System.Windows.Forms.Panel gLinkDataImageDiv;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tLinkEditPath;
        private System.Windows.Forms.TextBox tLinkEditName;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox gLinkFolder;
        private System.Windows.Forms.Button tLinkEditPathFind;
        private System.Windows.Forms.TextBox tLinkFolderFileFilter;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox cbLinkShowFolderContent;
        private System.Windows.Forms.Button bLinkImgCustomFind;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox tLinkImgCustom;
        private System.Windows.Forms.Button bLinkSave;
        private System.Windows.Forms.CheckBox cbLinkShowSubFolders;
        private System.Windows.Forms.CheckBox cbLinkShowOpen;
    }
}