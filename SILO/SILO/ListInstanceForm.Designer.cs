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
            this.listInstancePanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // listInstancePanel
            // 
            this.listInstancePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.listInstancePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listInstancePanel.Location = new System.Drawing.Point(0, 0);
            this.listInstancePanel.Name = "listInstancePanel";
            this.listInstancePanel.Size = new System.Drawing.Size(273, 497);
            this.listInstancePanel.TabIndex = 0;
            // 
            // ListInstanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 497);
            this.Controls.Add(this.listInstancePanel);
            this.Name = "ListInstanceForm";
            this.Text = "ListInstanceForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ListInstanceForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel listInstancePanel;
    }
}