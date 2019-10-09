namespace CSWork.Interface.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.AreaIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.AreaIconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.bCSWork = new System.Windows.Forms.ToolStripMenuItem();
            this.bCurrentUser = new System.Windows.Forms.ToolStripMenuItem();
            this.bReLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.bLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.mClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.mRegisterTask = new System.Windows.Forms.ToolStripMenuItem();
            this.mStartWork = new System.Windows.Forms.ToolStripMenuItem();
            this.mStartWorkWithoutName = new System.Windows.Forms.ToolStripMenuItem();
            this.mStartWorkSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mWorking = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mLinks = new System.Windows.Forms.ToolStripMenuItem();
            this.mAlarmas = new System.Windows.Forms.ToolStripMenuItem();
            this.mAlarmasStartAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mAlarmasStopAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mAmbientes = new System.Windows.Forms.ToolStripMenuItem();
            this.MAmbientesConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.mMemory = new System.Windows.Forms.ToolStripMenuItem();
            this.mMemoryConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mToolGenerarPasswordWeb = new System.Windows.Forms.ToolStripMenuItem();
            this.mToolGeneraroAuth = new System.Windows.Forms.ToolStripMenuItem();
            this.mConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            this.AreaIconMenuDisconnected = new System.Windows.Forms.NotifyIcon(this.components);
            this.AreaIconDisconectedMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mLogIn = new System.Windows.Forms.ToolStripMenuItem();
            this.bObtenerTokenJira = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.mCloseDisconnected = new System.Windows.Forms.ToolStripMenuItem();
            this.AreaIconMenu.SuspendLayout();
            this.AreaIconDisconectedMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // AreaIcon
            // 
            this.AreaIcon.ContextMenuStrip = this.AreaIconMenu;
            this.AreaIcon.Text = "CS Work";
            this.AreaIcon.DoubleClick += new System.EventHandler(this.MRegisterTask_Click);
            // 
            // AreaIconMenu
            // 
            this.AreaIconMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.AreaIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bCSWork,
            this.toolStripMenuItem4,
            this.mRegisterTask,
            this.mStartWork,
            this.mWorking,
            this.toolStripMenuItem1,
            this.mLinks,
            this.mAlarmas,
            this.mAmbientes,
            this.mMemory,
            this.toolsToolStripMenuItem,
            this.mConfiguration});
            this.AreaIconMenu.Name = "notifyIconMenu";
            this.AreaIconMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.AreaIconMenu.Size = new System.Drawing.Size(185, 298);
            // 
            // bCSWork
            // 
            this.bCSWork.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bCurrentUser,
            this.bReLogin,
            this.bLogout,
            this.toolStripMenuItem9,
            this.mClose});
            this.bCSWork.Image = ((System.Drawing.Image)(resources.GetObject("bCSWork.Image")));
            this.bCSWork.Name = "bCSWork";
            this.bCSWork.Size = new System.Drawing.Size(184, 26);
            this.bCSWork.Text = "CS Work";
            // 
            // bCurrentUser
            // 
            this.bCurrentUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.bCurrentUser.Image = ((System.Drawing.Image)(resources.GetObject("bCurrentUser.Image")));
            this.bCurrentUser.Name = "bCurrentUser";
            this.bCurrentUser.Size = new System.Drawing.Size(221, 26);
            this.bCurrentUser.Text = "grodriguez";
            // 
            // bReLogin
            // 
            this.bReLogin.Image = ((System.Drawing.Image)(resources.GetObject("bReLogin.Image")));
            this.bReLogin.Name = "bReLogin";
            this.bReLogin.Size = new System.Drawing.Size(221, 26);
            this.bReLogin.Text = "Ingresar Otras Credenciales";
            this.bReLogin.Click += new System.EventHandler(this.MLogIn_Click);
            // 
            // bLogout
            // 
            this.bLogout.Image = ((System.Drawing.Image)(resources.GetObject("bLogout.Image")));
            this.bLogout.Name = "bLogout";
            this.bLogout.Size = new System.Drawing.Size(221, 26);
            this.bLogout.Text = "Cerrar Session";
            this.bLogout.Click += new System.EventHandler(this.BLogout_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(218, 6);
            // 
            // mClose
            // 
            this.mClose.Image = ((System.Drawing.Image)(resources.GetObject("mClose.Image")));
            this.mClose.Name = "mClose";
            this.mClose.Size = new System.Drawing.Size(221, 26);
            this.mClose.Text = "Cerrar";
            this.mClose.Click += new System.EventHandler(this.MClose_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(181, 6);
            // 
            // mRegisterTask
            // 
            this.mRegisterTask.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mRegisterTask.Image = ((System.Drawing.Image)(resources.GetObject("mRegisterTask.Image")));
            this.mRegisterTask.Name = "mRegisterTask";
            this.mRegisterTask.Size = new System.Drawing.Size(184, 26);
            this.mRegisterTask.Text = "Registrar Trabajo";
            this.mRegisterTask.Click += new System.EventHandler(this.MRegisterTask_Click);
            // 
            // mStartWork
            // 
            this.mStartWork.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mStartWorkWithoutName,
            this.mStartWorkSearch,
            this.toolStripMenuItem3});
            this.mStartWork.Image = ((System.Drawing.Image)(resources.GetObject("mStartWork.Image")));
            this.mStartWork.Name = "mStartWork";
            this.mStartWork.Size = new System.Drawing.Size(184, 26);
            this.mStartWork.Text = "Iniciar Nueva Tarea";
            // 
            // mStartWorkWithoutName
            // 
            this.mStartWorkWithoutName.Image = ((System.Drawing.Image)(resources.GetObject("mStartWorkWithoutName.Image")));
            this.mStartWorkWithoutName.Name = "mStartWorkWithoutName";
            this.mStartWorkWithoutName.Size = new System.Drawing.Size(184, 26);
            this.mStartWorkWithoutName.Text = "Sin Issue";
            // 
            // mStartWorkSearch
            // 
            this.mStartWorkSearch.Image = ((System.Drawing.Image)(resources.GetObject("mStartWorkSearch.Image")));
            this.mStartWorkSearch.Name = "mStartWorkSearch";
            this.mStartWorkSearch.Size = new System.Drawing.Size(184, 26);
            this.mStartWorkSearch.Text = "Buscar Issue";
            this.mStartWorkSearch.Click += new System.EventHandler(this.MStartWorkSearch_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(181, 6);
            // 
            // mWorking
            // 
            this.mWorking.Image = ((System.Drawing.Image)(resources.GetObject("mWorking.Image")));
            this.mWorking.Name = "mWorking";
            this.mWorking.Size = new System.Drawing.Size(184, 26);
            this.mWorking.Text = "Working";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(181, 6);
            // 
            // mLinks
            // 
            this.mLinks.Name = "mLinks";
            this.mLinks.Size = new System.Drawing.Size(184, 26);
            this.mLinks.Text = "Accesos Directos";
            // 
            // mAlarmas
            // 
            this.mAlarmas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mAlarmasStartAll,
            this.mAlarmasStopAll,
            this.toolStripMenuItem2});
            this.mAlarmas.Image = ((System.Drawing.Image)(resources.GetObject("mAlarmas.Image")));
            this.mAlarmas.Name = "mAlarmas";
            this.mAlarmas.Size = new System.Drawing.Size(184, 26);
            this.mAlarmas.Text = "Alarmas";
            // 
            // mAlarmasStartAll
            // 
            this.mAlarmasStartAll.Image = ((System.Drawing.Image)(resources.GetObject("mAlarmasStartAll.Image")));
            this.mAlarmasStartAll.Name = "mAlarmasStartAll";
            this.mAlarmasStartAll.Size = new System.Drawing.Size(184, 26);
            this.mAlarmasStartAll.Text = "Activar Todas";
            // 
            // mAlarmasStopAll
            // 
            this.mAlarmasStopAll.Image = ((System.Drawing.Image)(resources.GetObject("mAlarmasStopAll.Image")));
            this.mAlarmasStopAll.Name = "mAlarmasStopAll";
            this.mAlarmasStopAll.Size = new System.Drawing.Size(184, 26);
            this.mAlarmasStopAll.Text = "Silencio Total";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(181, 6);
            // 
            // mAmbientes
            // 
            this.mAmbientes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MAmbientesConfig,
            this.toolStripMenuItem8});
            this.mAmbientes.Image = ((System.Drawing.Image)(resources.GetObject("mAmbientes.Image")));
            this.mAmbientes.Name = "mAmbientes";
            this.mAmbientes.Size = new System.Drawing.Size(184, 26);
            this.mAmbientes.Text = "Ambientes";
            // 
            // MAmbientesConfig
            // 
            this.MAmbientesConfig.Image = ((System.Drawing.Image)(resources.GetObject("MAmbientesConfig.Image")));
            this.MAmbientesConfig.Name = "MAmbientesConfig";
            this.MAmbientesConfig.Size = new System.Drawing.Size(184, 26);
            this.MAmbientesConfig.Text = "Administrar";
            this.MAmbientesConfig.Click += new System.EventHandler(this.MAmbientesConfig_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(181, 6);
            // 
            // mMemory
            // 
            this.mMemory.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mMemoryConfig,
            this.toolStripMenuItem7});
            this.mMemory.Image = ((System.Drawing.Image)(resources.GetObject("mMemory.Image")));
            this.mMemory.Name = "mMemory";
            this.mMemory.Size = new System.Drawing.Size(184, 26);
            this.mMemory.Text = "Memory";
            // 
            // mMemoryConfig
            // 
            this.mMemoryConfig.Image = ((System.Drawing.Image)(resources.GetObject("mMemoryConfig.Image")));
            this.mMemoryConfig.Name = "mMemoryConfig";
            this.mMemoryConfig.Size = new System.Drawing.Size(184, 26);
            this.mMemoryConfig.Text = "Administrar";
            this.mMemoryConfig.Click += new System.EventHandler(this.MMemoryConfig_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(181, 6);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mToolGenerarPasswordWeb,
            this.mToolGeneraroAuth});
            this.toolsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("toolsToolStripMenuItem.Image")));
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // mToolGenerarPasswordWeb
            // 
            this.mToolGenerarPasswordWeb.Image = ((System.Drawing.Image)(resources.GetObject("mToolGenerarPasswordWeb.Image")));
            this.mToolGenerarPasswordWeb.Name = "mToolGenerarPasswordWeb";
            this.mToolGenerarPasswordWeb.Size = new System.Drawing.Size(199, 26);
            this.mToolGenerarPasswordWeb.Text = "Generar Password Web";
            this.mToolGenerarPasswordWeb.Click += new System.EventHandler(this.MToolGenerarPasswordWeb_Click);
            // 
            // mToolGeneraroAuth
            // 
            this.mToolGeneraroAuth.Image = ((System.Drawing.Image)(resources.GetObject("mToolGeneraroAuth.Image")));
            this.mToolGeneraroAuth.Name = "mToolGeneraroAuth";
            this.mToolGeneraroAuth.Size = new System.Drawing.Size(199, 26);
            this.mToolGeneraroAuth.Text = "Generar oAuth";
            this.mToolGeneraroAuth.Click += new System.EventHandler(this.MToolGeneraroAuth_Click);
            // 
            // mConfiguration
            // 
            this.mConfiguration.Image = ((System.Drawing.Image)(resources.GetObject("mConfiguration.Image")));
            this.mConfiguration.Name = "mConfiguration";
            this.mConfiguration.Size = new System.Drawing.Size(184, 26);
            this.mConfiguration.Text = "Configuración";
            this.mConfiguration.Click += new System.EventHandler(this.MConfiguration_Click);
            // 
            // AreaIconMenuDisconnected
            // 
            this.AreaIconMenuDisconnected.ContextMenuStrip = this.AreaIconDisconectedMenu;
            this.AreaIconMenuDisconnected.Text = "CS Work - Disconnected";
            this.AreaIconMenuDisconnected.Visible = true;
            this.AreaIconMenuDisconnected.DoubleClick += new System.EventHandler(this.MLogIn_Click);
            this.AreaIconMenuDisconnected.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AreaIconMenuDisconnected_MouseClick);
            // 
            // AreaIconDisconectedMenu
            // 
            this.AreaIconDisconectedMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.AreaIconDisconectedMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mLogIn,
            this.bObtenerTokenJira,
            this.toolStripMenuItem5,
            this.mCloseDisconnected});
            this.AreaIconDisconectedMenu.Name = "AreaIconDisconectedMenu";
            this.AreaIconDisconectedMenu.Size = new System.Drawing.Size(193, 88);
            // 
            // mLogIn
            // 
            this.mLogIn.Image = ((System.Drawing.Image)(resources.GetObject("mLogIn.Image")));
            this.mLogIn.Name = "mLogIn";
            this.mLogIn.Size = new System.Drawing.Size(192, 26);
            this.mLogIn.Text = "Log In";
            this.mLogIn.Click += new System.EventHandler(this.MLogIn_Click);
            // 
            // bObtenerTokenJira
            // 
            this.bObtenerTokenJira.Image = ((System.Drawing.Image)(resources.GetObject("bObtenerTokenJira.Image")));
            this.bObtenerTokenJira.Name = "bObtenerTokenJira";
            this.bObtenerTokenJira.Size = new System.Drawing.Size(192, 26);
            this.bObtenerTokenJira.Text = "Obtener Token de Jira";
            this.bObtenerTokenJira.Click += new System.EventHandler(this.BObtenerTokenJira_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(189, 6);
            // 
            // mCloseDisconnected
            // 
            this.mCloseDisconnected.Image = ((System.Drawing.Image)(resources.GetObject("mCloseDisconnected.Image")));
            this.mCloseDisconnected.Name = "mCloseDisconnected";
            this.mCloseDisconnected.Size = new System.Drawing.Size(192, 26);
            this.mCloseDisconnected.Text = "Cerrar";
            this.mCloseDisconnected.Click += new System.EventHandler(this.MClose_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 80);
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.Text = "CS Work";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.AreaIconMenu.ResumeLayout(false);
            this.AreaIconDisconectedMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon AreaIcon;
        private System.Windows.Forms.ContextMenuStrip AreaIconMenu;
        private System.Windows.Forms.ToolStripMenuItem mRegisterTask;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mAlarmas;
        private System.Windows.Forms.ToolStripMenuItem mAlarmasStartAll;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mAlarmasStopAll;
        private System.Windows.Forms.ToolStripMenuItem bCSWork;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem bLogout;
        private System.Windows.Forms.ToolStripMenuItem mConfiguration;
        private System.Windows.Forms.NotifyIcon AreaIconMenuDisconnected;
        private System.Windows.Forms.ContextMenuStrip AreaIconDisconectedMenu;
        private System.Windows.Forms.ToolStripMenuItem mLogIn;
        private System.Windows.Forms.ToolStripMenuItem bObtenerTokenJira;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem mCloseDisconnected;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mToolGenerarPasswordWeb;
        private System.Windows.Forms.ToolStripMenuItem mToolGeneraroAuth;
        private System.Windows.Forms.ToolStripMenuItem mMemory;
        private System.Windows.Forms.ToolStripMenuItem mMemoryConfig;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem mAmbientes;
        private System.Windows.Forms.ToolStripMenuItem MAmbientesConfig;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem bCurrentUser;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem mClose;
        private System.Windows.Forms.ToolStripMenuItem bReLogin;
        private System.Windows.Forms.ToolStripMenuItem mStartWork;
        private System.Windows.Forms.ToolStripMenuItem mWorking;
        private System.Windows.Forms.ToolStripMenuItem mStartWorkWithoutName;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mStartWorkSearch;
        private System.Windows.Forms.ToolStripMenuItem mLinks;
    }
}

