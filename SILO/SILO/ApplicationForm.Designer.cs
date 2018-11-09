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
            this.boxRightPanel = new System.Windows.Forms.Panel();
            this.lateralLeftPanel = new System.Windows.Forms.Panel();
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
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.mainPanel.Controls.Add(this.boxRightPanel);
            this.mainPanel.Controls.Add(this.lateralLeftPanel);
            this.mainPanel.Location = new System.Drawing.Point(0, 27);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(824, 405);
            this.mainPanel.TabIndex = 1;
            // 
            // boxRightPanel
            // 
            this.boxRightPanel.BackColor = System.Drawing.SystemColors.Control;
            this.boxRightPanel.Location = new System.Drawing.Point(206, 0);
            this.boxRightPanel.Name = "boxRightPanel";
            this.boxRightPanel.Size = new System.Drawing.Size(615, 405);
            this.boxRightPanel.TabIndex = 1;
            // 
            // lateralLeftPanel
            // 
            this.lateralLeftPanel.BackColor = System.Drawing.SystemColors.Control;
            this.lateralLeftPanel.Location = new System.Drawing.Point(0, 0);
            this.lateralLeftPanel.Name = "lateralLeftPanel";
            this.lateralLeftPanel.Size = new System.Drawing.Size(200, 405);
            this.lateralLeftPanel.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(824, 434);
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
        private System.Windows.Forms.Panel boxRightPanel;
        private System.Windows.Forms.Panel lateralLeftPanel;
    }
}

