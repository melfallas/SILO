namespace SILO.DesktopApplication.Core.Forms.Start
{
    partial class ApplicationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicationForm));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.ventasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventaDePapelesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reimpresiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borradoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catálogosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresarGanadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prohibidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parámetrosGeneralesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parámetrosGeneralesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.parámetrosDeImpresiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parámetrosDeSucursalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parámetrosDeSistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sincronizaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transaccionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enviarAlServidorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirDelSistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.centerBoxPanel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.syncStatusLabel = new System.Windows.Forms.Label();
            this.syncStatusProgressBar = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.posContentLabel = new System.Windows.Forms.Label();
            this.posLabel = new System.Windows.Forms.Label();
            this.companyContentLabel = new System.Windows.Forms.Label();
            this.companyLabel = new System.Windows.Forms.Label();
            this.userContentLabel = new System.Windows.Forms.Label();
            this.userLabel = new System.Windows.Forms.Label();
            this.lateralLeftPanel = new System.Windows.Forms.Panel();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.copyListButton = new System.Windows.Forms.Button();
            this.displayQRMenuButton = new System.Windows.Forms.Button();
            this.eraseButton = new System.Windows.Forms.Button();
            this.aboutButton = new System.Windows.Forms.Button();
            this.printMenuButton = new System.Windows.Forms.Button();
            this.saleMenuButton = new System.Windows.Forms.Button();
            this.syncTimer = new System.Windows.Forms.Timer(this.components);
            this.closeDrawMenuButton = new System.Windows.Forms.Button();
            this.mainMenu.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.lateralLeftPanel.SuspendLayout();
            this.menuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.BackColor = System.Drawing.SystemColors.ControlLight;
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ventasToolStripMenuItem,
            this.catálogosToolStripMenuItem,
            this.configuraciónToolStripMenuItem,
            this.sincronizaciónToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(967, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // ventasToolStripMenuItem
            // 
            this.ventasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ventaDePapelesToolStripMenuItem,
            this.reimpresiónToolStripMenuItem,
            this.borradoToolStripMenuItem});
            this.ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            this.ventasToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ventasToolStripMenuItem.Text = "Ventas";
            // 
            // ventaDePapelesToolStripMenuItem
            // 
            this.ventaDePapelesToolStripMenuItem.Name = "ventaDePapelesToolStripMenuItem";
            this.ventaDePapelesToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.ventaDePapelesToolStripMenuItem.Text = "Venta de Papeles";
            this.ventaDePapelesToolStripMenuItem.Click += new System.EventHandler(this.ventaDePapelesToolStripMenuItem_Click);
            // 
            // reimpresiónToolStripMenuItem
            // 
            this.reimpresiónToolStripMenuItem.Name = "reimpresiónToolStripMenuItem";
            this.reimpresiónToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.reimpresiónToolStripMenuItem.Text = "Reimpresión";
            // 
            // borradoToolStripMenuItem
            // 
            this.borradoToolStripMenuItem.Name = "borradoToolStripMenuItem";
            this.borradoToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.borradoToolStripMenuItem.Text = "Borrado";
            // 
            // catálogosToolStripMenuItem
            // 
            this.catálogosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ingresarGanadoresToolStripMenuItem,
            this.prohibidosToolStripMenuItem});
            this.catálogosToolStripMenuItem.Name = "catálogosToolStripMenuItem";
            this.catálogosToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.catálogosToolStripMenuItem.Text = "Mantenimiento";
            // 
            // ingresarGanadoresToolStripMenuItem
            // 
            this.ingresarGanadoresToolStripMenuItem.Name = "ingresarGanadoresToolStripMenuItem";
            this.ingresarGanadoresToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.ingresarGanadoresToolStripMenuItem.Text = "Ingresar Ganadores";
            this.ingresarGanadoresToolStripMenuItem.Click += new System.EventHandler(this.ingresarGanadoresToolStripMenuItem_Click);
            // 
            // prohibidosToolStripMenuItem
            // 
            this.prohibidosToolStripMenuItem.Name = "prohibidosToolStripMenuItem";
            this.prohibidosToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.prohibidosToolStripMenuItem.Text = "Números Prohibidos";
            this.prohibidosToolStripMenuItem.Click += new System.EventHandler(this.prohibidosToolStripMenuItem_Click);
            // 
            // configuraciónToolStripMenuItem
            // 
            this.configuraciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.parámetrosGeneralesToolStripMenuItem,
            this.parámetrosDeSucursalToolStripMenuItem,
            this.parámetrosDeSistemaToolStripMenuItem});
            this.configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            this.configuraciónToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.configuraciónToolStripMenuItem.Text = "Configuración";
            // 
            // parámetrosGeneralesToolStripMenuItem
            // 
            this.parámetrosGeneralesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.parámetrosGeneralesToolStripMenuItem1,
            this.parámetrosDeImpresiónToolStripMenuItem});
            this.parámetrosGeneralesToolStripMenuItem.Name = "parámetrosGeneralesToolStripMenuItem";
            this.parámetrosGeneralesToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.parámetrosGeneralesToolStripMenuItem.Text = "Parámetros";
            // 
            // parámetrosGeneralesToolStripMenuItem1
            // 
            this.parámetrosGeneralesToolStripMenuItem1.Name = "parámetrosGeneralesToolStripMenuItem1";
            this.parámetrosGeneralesToolStripMenuItem1.Size = new System.Drawing.Size(206, 22);
            this.parámetrosGeneralesToolStripMenuItem1.Text = "Parámetros Generales";
            // 
            // parámetrosDeImpresiónToolStripMenuItem
            // 
            this.parámetrosDeImpresiónToolStripMenuItem.Name = "parámetrosDeImpresiónToolStripMenuItem";
            this.parámetrosDeImpresiónToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.parámetrosDeImpresiónToolStripMenuItem.Text = "Parámetros de Impresión";
            this.parámetrosDeImpresiónToolStripMenuItem.Click += new System.EventHandler(this.parámetrosDeImpresiónToolStripMenuItem_Click);
            // 
            // parámetrosDeSucursalToolStripMenuItem
            // 
            this.parámetrosDeSucursalToolStripMenuItem.Name = "parámetrosDeSucursalToolStripMenuItem";
            this.parámetrosDeSucursalToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.parámetrosDeSucursalToolStripMenuItem.Text = "Parámetros de Sucursal";
            // 
            // parámetrosDeSistemaToolStripMenuItem
            // 
            this.parámetrosDeSistemaToolStripMenuItem.Name = "parámetrosDeSistemaToolStripMenuItem";
            this.parámetrosDeSistemaToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.parámetrosDeSistemaToolStripMenuItem.Text = "Parámetros de Sistema";
            // 
            // sincronizaciónToolStripMenuItem
            // 
            this.sincronizaciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transaccionesToolStripMenuItem});
            this.sincronizaciónToolStripMenuItem.Name = "sincronizaciónToolStripMenuItem";
            this.sincronizaciónToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.sincronizaciónToolStripMenuItem.Text = "Sincronización";
            // 
            // transaccionesToolStripMenuItem
            // 
            this.transaccionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enviarAlServidorToolStripMenuItem});
            this.transaccionesToolStripMenuItem.Name = "transaccionesToolStripMenuItem";
            this.transaccionesToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.transaccionesToolStripMenuItem.Text = "Transacciones";
            // 
            // enviarAlServidorToolStripMenuItem
            // 
            this.enviarAlServidorToolStripMenuItem.Name = "enviarAlServidorToolStripMenuItem";
            this.enviarAlServidorToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.enviarAlServidorToolStripMenuItem.Text = "Enviar al Servidor";
            this.enviarAlServidorToolStripMenuItem.Click += new System.EventHandler(this.enviarAlServidorToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirDelSistemaToolStripMenuItem});
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.salirToolStripMenuItem.Text = "Salir";
            // 
            // salirDelSistemaToolStripMenuItem
            // 
            this.salirDelSistemaToolStripMenuItem.Name = "salirDelSistemaToolStripMenuItem";
            this.salirDelSistemaToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.salirDelSistemaToolStripMenuItem.Text = "Salir del Sistema";
            this.salirDelSistemaToolStripMenuItem.Click += new System.EventHandler(this.salirDelSistemaToolStripMenuItem_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.mainPanel.Controls.Add(this.centerBoxPanel);
            this.mainPanel.Controls.Add(this.panel3);
            this.mainPanel.Controls.Add(this.panel2);
            this.mainPanel.Controls.Add(this.panel1);
            this.mainPanel.Controls.Add(this.lateralLeftPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 24);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(967, 589);
            this.mainPanel.TabIndex = 1;
            // 
            // centerBoxPanel
            // 
            this.centerBoxPanel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.centerBoxPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.centerBoxPanel.Location = new System.Drawing.Point(220, 30);
            this.centerBoxPanel.Name = "centerBoxPanel";
            this.centerBoxPanel.Size = new System.Drawing.Size(697, 537);
            this.centerBoxPanel.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(917, 30);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(50, 537);
            this.panel3.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.Controls.Add(this.syncStatusLabel);
            this.panel2.Controls.Add(this.syncStatusProgressBar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(220, 567);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(747, 22);
            this.panel2.TabIndex = 2;
            // 
            // syncStatusLabel
            // 
            this.syncStatusLabel.AutoSize = true;
            this.syncStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.syncStatusLabel.Location = new System.Drawing.Point(559, 3);
            this.syncStatusLabel.Name = "syncStatusLabel";
            this.syncStatusLabel.Size = new System.Drawing.Size(119, 13);
            this.syncStatusLabel.TabIndex = 1;
            this.syncStatusLabel.Text = "Sincronización completa";
            // 
            // syncStatusProgressBar
            // 
            this.syncStatusProgressBar.Location = new System.Drawing.Point(456, 6);
            this.syncStatusProgressBar.MarqueeAnimationSpeed = 40;
            this.syncStatusProgressBar.Minimum = 20;
            this.syncStatusProgressBar.Name = "syncStatusProgressBar";
            this.syncStatusProgressBar.Size = new System.Drawing.Size(97, 10);
            this.syncStatusProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.syncStatusProgressBar.TabIndex = 0;
            this.syncStatusProgressBar.UseWaitCursor = true;
            this.syncStatusProgressBar.Value = 20;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.posContentLabel);
            this.panel1.Controls.Add(this.posLabel);
            this.panel1.Controls.Add(this.companyContentLabel);
            this.panel1.Controls.Add(this.companyLabel);
            this.panel1.Controls.Add(this.userContentLabel);
            this.panel1.Controls.Add(this.userLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(220, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(747, 30);
            this.panel1.TabIndex = 0;
            // 
            // posContentLabel
            // 
            this.posContentLabel.AutoSize = true;
            this.posContentLabel.Location = new System.Drawing.Point(328, 11);
            this.posContentLabel.Name = "posContentLabel";
            this.posContentLabel.Size = new System.Drawing.Size(26, 13);
            this.posContentLabel.TabIndex = 5;
            this.posContentLabel.Text = "Suc";
            this.posContentLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // posLabel
            // 
            this.posLabel.AutoSize = true;
            this.posLabel.Location = new System.Drawing.Point(271, 11);
            this.posLabel.Name = "posLabel";
            this.posLabel.Size = new System.Drawing.Size(51, 13);
            this.posLabel.TabIndex = 4;
            this.posLabel.Text = "Sucursal:";
            // 
            // companyContentLabel
            // 
            this.companyContentLabel.AutoSize = true;
            this.companyContentLabel.Location = new System.Drawing.Point(71, 11);
            this.companyContentLabel.Name = "companyContentLabel";
            this.companyContentLabel.Size = new System.Drawing.Size(28, 13);
            this.companyContentLabel.TabIndex = 3;
            this.companyContentLabel.Text = "Cmp";
            // 
            // companyLabel
            // 
            this.companyLabel.AutoSize = true;
            this.companyLabel.Location = new System.Drawing.Point(6, 11);
            this.companyLabel.Name = "companyLabel";
            this.companyLabel.Size = new System.Drawing.Size(59, 13);
            this.companyLabel.TabIndex = 2;
            this.companyLabel.Text = "Compañía:";
            // 
            // userContentLabel
            // 
            this.userContentLabel.AutoSize = true;
            this.userContentLabel.Location = new System.Drawing.Point(659, 11);
            this.userContentLabel.Name = "userContentLabel";
            this.userContentLabel.Size = new System.Drawing.Size(29, 13);
            this.userContentLabel.TabIndex = 1;
            this.userContentLabel.Text = "User";
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Location = new System.Drawing.Point(615, 11);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(49, 13);
            this.userLabel.TabIndex = 0;
            this.userLabel.Text = "Usuario: ";
            // 
            // lateralLeftPanel
            // 
            this.lateralLeftPanel.BackColor = System.Drawing.Color.White;
            this.lateralLeftPanel.Controls.Add(this.menuPanel);
            this.lateralLeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.lateralLeftPanel.Location = new System.Drawing.Point(0, 0);
            this.lateralLeftPanel.Name = "lateralLeftPanel";
            this.lateralLeftPanel.Size = new System.Drawing.Size(220, 589);
            this.lateralLeftPanel.TabIndex = 0;
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.menuPanel.Controls.Add(this.closeDrawMenuButton);
            this.menuPanel.Controls.Add(this.copyListButton);
            this.menuPanel.Controls.Add(this.displayQRMenuButton);
            this.menuPanel.Controls.Add(this.eraseButton);
            this.menuPanel.Controls.Add(this.aboutButton);
            this.menuPanel.Controls.Add(this.printMenuButton);
            this.menuPanel.Controls.Add(this.saleMenuButton);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(220, 589);
            this.menuPanel.TabIndex = 0;
            // 
            // copyListButton
            // 
            this.copyListButton.FlatAppearance.BorderSize = 0;
            this.copyListButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copyListButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyListButton.ForeColor = System.Drawing.Color.White;
            this.copyListButton.Image = ((System.Drawing.Image)(resources.GetObject("copyListButton.Image")));
            this.copyListButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.copyListButton.Location = new System.Drawing.Point(2, 116);
            this.copyListButton.Name = "copyListButton";
            this.copyListButton.Size = new System.Drawing.Size(217, 54);
            this.copyListButton.TabIndex = 1;
            this.copyListButton.Text = "   Copiar Lista";
            this.copyListButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.copyListButton.UseVisualStyleBackColor = true;
            this.copyListButton.Click += new System.EventHandler(this.copyListButton_Click);
            // 
            // displayQRMenuButton
            // 
            this.displayQRMenuButton.FlatAppearance.BorderSize = 0;
            this.displayQRMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.displayQRMenuButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayQRMenuButton.ForeColor = System.Drawing.Color.White;
            this.displayQRMenuButton.Image = ((System.Drawing.Image)(resources.GetObject("displayQRMenuButton.Image")));
            this.displayQRMenuButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.displayQRMenuButton.Location = new System.Drawing.Point(2, 293);
            this.displayQRMenuButton.Name = "displayQRMenuButton";
            this.displayQRMenuButton.Size = new System.Drawing.Size(217, 54);
            this.displayQRMenuButton.TabIndex = 4;
            this.displayQRMenuButton.Text = "Generar QR";
            this.displayQRMenuButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.displayQRMenuButton.UseVisualStyleBackColor = true;
            this.displayQRMenuButton.Click += new System.EventHandler(this.displayQRMenuButton_Click);
            // 
            // eraseButton
            // 
            this.eraseButton.FlatAppearance.BorderSize = 0;
            this.eraseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eraseButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eraseButton.ForeColor = System.Drawing.Color.White;
            this.eraseButton.Image = ((System.Drawing.Image)(resources.GetObject("eraseButton.Image")));
            this.eraseButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.eraseButton.Location = new System.Drawing.Point(3, 236);
            this.eraseButton.Name = "eraseButton";
            this.eraseButton.Size = new System.Drawing.Size(217, 54);
            this.eraseButton.TabIndex = 3;
            this.eraseButton.Text = "Borrado de Papeles";
            this.eraseButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.eraseButton.UseVisualStyleBackColor = true;
            this.eraseButton.Click += new System.EventHandler(this.eraseButton_Click);
            // 
            // aboutButton
            // 
            this.aboutButton.FlatAppearance.BorderSize = 0;
            this.aboutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aboutButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutButton.ForeColor = System.Drawing.Color.White;
            this.aboutButton.Image = ((System.Drawing.Image)(resources.GetObject("aboutButton.Image")));
            this.aboutButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.aboutButton.Location = new System.Drawing.Point(3, 413);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(217, 54);
            this.aboutButton.TabIndex = 5;
            this.aboutButton.Text = "Acerca de";
            this.aboutButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // printMenuButton
            // 
            this.printMenuButton.FlatAppearance.BorderSize = 0;
            this.printMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.printMenuButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printMenuButton.ForeColor = System.Drawing.Color.White;
            this.printMenuButton.Image = ((System.Drawing.Image)(resources.GetObject("printMenuButton.Image")));
            this.printMenuButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.printMenuButton.Location = new System.Drawing.Point(3, 176);
            this.printMenuButton.Name = "printMenuButton";
            this.printMenuButton.Size = new System.Drawing.Size(217, 54);
            this.printMenuButton.TabIndex = 2;
            this.printMenuButton.Text = "Reimpresión de Tickets";
            this.printMenuButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.printMenuButton.UseVisualStyleBackColor = true;
            this.printMenuButton.Click += new System.EventHandler(this.printMenuButton_Click);
            // 
            // saleMenuButton
            // 
            this.saleMenuButton.FlatAppearance.BorderSize = 0;
            this.saleMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saleMenuButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saleMenuButton.ForeColor = System.Drawing.Color.White;
            this.saleMenuButton.Image = ((System.Drawing.Image)(resources.GetObject("saleMenuButton.Image")));
            this.saleMenuButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.saleMenuButton.Location = new System.Drawing.Point(3, 56);
            this.saleMenuButton.Name = "saleMenuButton";
            this.saleMenuButton.Size = new System.Drawing.Size(217, 54);
            this.saleMenuButton.TabIndex = 0;
            this.saleMenuButton.Text = "          Venta de Papeles";
            this.saleMenuButton.UseVisualStyleBackColor = true;
            this.saleMenuButton.Click += new System.EventHandler(this.saleMenuButton_Click);
            // 
            // syncTimer
            // 
            this.syncTimer.Interval = 300000;
            this.syncTimer.Tick += new System.EventHandler(this.syncTimer_Tick);
            // 
            // closeDrawMenuButton
            // 
            this.closeDrawMenuButton.FlatAppearance.BorderSize = 0;
            this.closeDrawMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeDrawMenuButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeDrawMenuButton.ForeColor = System.Drawing.Color.White;
            this.closeDrawMenuButton.Image = ((System.Drawing.Image)(resources.GetObject("closeDrawMenuButton.Image")));
            this.closeDrawMenuButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.closeDrawMenuButton.Location = new System.Drawing.Point(3, 353);
            this.closeDrawMenuButton.Name = "closeDrawMenuButton";
            this.closeDrawMenuButton.Size = new System.Drawing.Size(217, 54);
            this.closeDrawMenuButton.TabIndex = 6;
            this.closeDrawMenuButton.Text = "Envío y Cierre";
            this.closeDrawMenuButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.closeDrawMenuButton.UseVisualStyleBackColor = true;
            this.closeDrawMenuButton.Click += new System.EventHandler(this.closeDrawMenuButton_Click);
            // 
            // ApplicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(967, 613);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.mainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mainMenu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ApplicationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema Informático para Control de Lotería";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ApplicationForm_FormClosed);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.lateralLeftPanel.ResumeLayout(false);
            this.menuPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventaDePapelesToolStripMenuItem;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel centerBoxPanel;
        private System.Windows.Forms.Panel lateralLeftPanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Button saleMenuButton;
        private System.Windows.Forms.Button printMenuButton;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Button eraseButton;
        private System.Windows.Forms.ToolStripMenuItem catálogosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prohibidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingresarGanadoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parámetrosGeneralesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parámetrosDeSucursalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parámetrosDeSistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reimpresiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borradoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirDelSistemaToolStripMenuItem;
        private System.Windows.Forms.Button displayQRMenuButton;
        private System.Windows.Forms.Label userContentLabel;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Label companyContentLabel;
        private System.Windows.Forms.Label companyLabel;
        private System.Windows.Forms.Label posContentLabel;
        private System.Windows.Forms.Label posLabel;
        private System.Windows.Forms.Button copyListButton;
        private System.Windows.Forms.ToolStripMenuItem sincronizaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transaccionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enviarAlServidorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parámetrosGeneralesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem parámetrosDeImpresiónToolStripMenuItem;
        private System.Windows.Forms.ProgressBar syncStatusProgressBar;
        private System.Windows.Forms.Label syncStatusLabel;
        private System.Windows.Forms.Timer syncTimer;
        private System.Windows.Forms.Button closeDrawMenuButton;
    }
}

