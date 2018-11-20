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
            this.listInstanceMainPanel = new System.Windows.Forms.Panel();
            this.listInstanceBottomPanel = new System.Windows.Forms.Panel();
            this.printListButton = new System.Windows.Forms.Button();
            this.listInstanceMainPanel.SuspendLayout();
            this.listInstanceBottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // listInstanceMainPanel
            // 
            this.listInstanceMainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.listInstanceMainPanel.Controls.Add(this.listInstanceBottomPanel);
            this.listInstanceMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listInstanceMainPanel.Location = new System.Drawing.Point(0, 0);
            this.listInstanceMainPanel.Name = "listInstanceMainPanel";
            this.listInstanceMainPanel.Size = new System.Drawing.Size(273, 497);
            this.listInstanceMainPanel.TabIndex = 0;
            // 
            // listInstanceBottomPanel
            // 
            this.listInstanceBottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.listInstanceBottomPanel.Controls.Add(this.printListButton);
            this.listInstanceBottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listInstanceBottomPanel.Location = new System.Drawing.Point(0, 441);
            this.listInstanceBottomPanel.Name = "listInstanceBottomPanel";
            this.listInstanceBottomPanel.Size = new System.Drawing.Size(273, 56);
            this.listInstanceBottomPanel.TabIndex = 1;
            // 
            // printListButton
            // 
            this.printListButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printListButton.Location = new System.Drawing.Point(95, 13);
            this.printListButton.Name = "printListButton";
            this.printListButton.Size = new System.Drawing.Size(84, 29);
            this.printListButton.TabIndex = 99;
            this.printListButton.Text = "Imprimir";
            this.printListButton.UseVisualStyleBackColor = true;
            this.printListButton.Click += new System.EventHandler(this.printListButton_Click);
            // 
            // ListInstanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 497);
            this.Controls.Add(this.listInstanceMainPanel);
            this.Name = "ListInstanceForm";
            this.Text = "ListInstanceForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ListInstanceForm_FormClosing);
            this.listInstanceMainPanel.ResumeLayout(false);
            this.listInstanceBottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel listInstanceMainPanel;
        private System.Windows.Forms.Panel listInstanceBottomPanel;
        private System.Windows.Forms.Button printListButton;
    }
}