namespace SILO
{
    partial class ListInstanceForm
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
            this.listInstanceTopPanel = new System.Windows.Forms.Panel();
            this.posLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.groupLabel = new System.Windows.Forms.Label();
            this.listInstanceBottomPanel = new System.Windows.Forms.Panel();
            this.eraseListButton = new System.Windows.Forms.Button();
            this.printListButton = new System.Windows.Forms.Button();
            this.listInstanceMainPanel = new System.Windows.Forms.Panel();
            this.listInstanceTopPanel.SuspendLayout();
            this.listInstanceBottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // listInstanceTopPanel
            // 
            this.listInstanceTopPanel.BackColor = System.Drawing.Color.White;
            this.listInstanceTopPanel.Controls.Add(this.posLabel);
            this.listInstanceTopPanel.Controls.Add(this.dateLabel);
            this.listInstanceTopPanel.Controls.Add(this.groupLabel);
            this.listInstanceTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.listInstanceTopPanel.Location = new System.Drawing.Point(0, 0);
            this.listInstanceTopPanel.Name = "listInstanceTopPanel";
            this.listInstanceTopPanel.Size = new System.Drawing.Size(273, 67);
            this.listInstanceTopPanel.TabIndex = 2;
            // 
            // posLabel
            // 
            this.posLabel.AutoSize = true;
            this.posLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.posLabel.Location = new System.Drawing.Point(91, 45);
            this.posLabel.Name = "posLabel";
            this.posLabel.Size = new System.Drawing.Size(69, 19);
            this.posLabel.TabIndex = 2;
            this.posLabel.Text = "DOTA-E";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLabel.Location = new System.Drawing.Point(65, 24);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(135, 19);
            this.dateLabel.TabIndex = 1;
            this.dateLabel.Text = "JUEV-18/11/2018";
            // 
            // groupLabel
            // 
            this.groupLabel.AutoSize = true;
            this.groupLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupLabel.Location = new System.Drawing.Point(95, 5);
            this.groupLabel.Name = "groupLabel";
            this.groupLabel.Size = new System.Drawing.Size(68, 19);
            this.groupLabel.TabIndex = 0;
            this.groupLabel.Text = "NOCHE";
            // 
            // listInstanceBottomPanel
            // 
            this.listInstanceBottomPanel.BackColor = System.Drawing.Color.White;
            this.listInstanceBottomPanel.Controls.Add(this.eraseListButton);
            this.listInstanceBottomPanel.Controls.Add(this.printListButton);
            this.listInstanceBottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listInstanceBottomPanel.Location = new System.Drawing.Point(0, 472);
            this.listInstanceBottomPanel.Name = "listInstanceBottomPanel";
            this.listInstanceBottomPanel.Size = new System.Drawing.Size(273, 38);
            this.listInstanceBottomPanel.TabIndex = 1;
            // 
            // eraseListButton
            // 
            this.eraseListButton.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eraseListButton.Location = new System.Drawing.Point(28, 6);
            this.eraseListButton.Name = "eraseListButton";
            this.eraseListButton.Size = new System.Drawing.Size(84, 23);
            this.eraseListButton.TabIndex = 100;
            this.eraseListButton.Text = "Limpiar";
            this.eraseListButton.UseVisualStyleBackColor = true;
            this.eraseListButton.Click += new System.EventHandler(this.eraseListButton_Click);
            // 
            // printListButton
            // 
            this.printListButton.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printListButton.Location = new System.Drawing.Point(160, 6);
            this.printListButton.Name = "printListButton";
            this.printListButton.Size = new System.Drawing.Size(84, 23);
            this.printListButton.TabIndex = 99;
            this.printListButton.Text = "Imprimir";
            this.printListButton.UseVisualStyleBackColor = true;
            this.printListButton.Click += new System.EventHandler(this.printListButton_Click);
            // 
            // listInstanceMainPanel
            // 
            this.listInstanceMainPanel.BackColor = System.Drawing.Color.White;
            this.listInstanceMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listInstanceMainPanel.Location = new System.Drawing.Point(0, 67);
            this.listInstanceMainPanel.Name = "listInstanceMainPanel";
            this.listInstanceMainPanel.Size = new System.Drawing.Size(273, 405);
            this.listInstanceMainPanel.TabIndex = 0;
            // 
            // ListInstanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 510);
            this.Controls.Add(this.listInstanceMainPanel);
            this.Controls.Add(this.listInstanceBottomPanel);
            this.Controls.Add(this.listInstanceTopPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListInstanceForm";
            this.Text = "Ingreso de Venta";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ListInstanceForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListInstanceForm_KeyDown);
            this.listInstanceTopPanel.ResumeLayout(false);
            this.listInstanceTopPanel.PerformLayout();
            this.listInstanceBottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel listInstanceBottomPanel;
        private System.Windows.Forms.Button printListButton;
        private System.Windows.Forms.Panel listInstanceTopPanel;
        private System.Windows.Forms.Label groupLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label posLabel;
        private System.Windows.Forms.Panel listInstanceMainPanel;
        private System.Windows.Forms.Button eraseListButton;
    }
}