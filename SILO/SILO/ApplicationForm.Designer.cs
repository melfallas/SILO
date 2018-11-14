namespace SILO
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
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.ventasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventaDePapelesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.centerBoxPanel = new System.Windows.Forms.Panel();
            this.lateralLeftPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.mainMenu.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.BackColor = System.Drawing.SystemColors.ControlDark;
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ventasToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(824, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // ventasToolStripMenuItem
            // 
            this.ventasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ventaDePapelesToolStripMenuItem});
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
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.Controls.Add(this.centerBoxPanel);
            this.mainPanel.Controls.Add(this.panel3);
            this.mainPanel.Controls.Add(this.panel2);
            this.mainPanel.Controls.Add(this.panel1);
            this.mainPanel.Controls.Add(this.lateralLeftPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 24);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(824, 443);
            this.mainPanel.TabIndex = 1;
            // 
            // centerBoxPanel
            // 
            this.centerBoxPanel.BackColor = System.Drawing.SystemColors.Control;
            this.centerBoxPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.centerBoxPanel.Location = new System.Drawing.Point(200, 41);
            this.centerBoxPanel.Name = "centerBoxPanel";
            this.centerBoxPanel.Size = new System.Drawing.Size(574, 361);
            this.centerBoxPanel.TabIndex = 1;
            // 
            // lateralLeftPanel
            // 
            this.lateralLeftPanel.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.lateralLeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.lateralLeftPanel.Location = new System.Drawing.Point(0, 0);
            this.lateralLeftPanel.Name = "lateralLeftPanel";
            this.lateralLeftPanel.Size = new System.Drawing.Size(200, 443);
            this.lateralLeftPanel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(200, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(624, 41);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(200, 402);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(624, 41);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(774, 41);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(50, 361);
            this.panel3.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(824, 467);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "Sistema Informático para Control de Lotería";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.mainPanel.ResumeLayout(false);
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
    }
}

