namespace SILO.DesktopApplication.Core.Forms.Modules.Number
{
    partial class PrizeTicketPanelForm
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
            this.prizeTicketPanel = new System.Windows.Forms.Panel();
            this.prizeTextBox = new System.Windows.Forms.TextBox();
            this.prizeTicketPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // prizeTicketPanel
            // 
            this.prizeTicketPanel.Controls.Add(this.prizeTextBox);
            this.prizeTicketPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prizeTicketPanel.Location = new System.Drawing.Point(0, 0);
            this.prizeTicketPanel.Name = "prizeTicketPanel";
            this.prizeTicketPanel.Size = new System.Drawing.Size(284, 432);
            this.prizeTicketPanel.TabIndex = 0;
            // 
            // prizeTextBox
            // 
            this.prizeTextBox.Location = new System.Drawing.Point(12, 12);
            this.prizeTextBox.Multiline = true;
            this.prizeTextBox.Name = "prizeTextBox";
            this.prizeTextBox.Size = new System.Drawing.Size(260, 408);
            this.prizeTextBox.TabIndex = 0;
            // 
            // PrizeTicketPanelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 432);
            this.Controls.Add(this.prizeTicketPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrizeTicketPanelForm";
            this.Text = "Listado de números ganadores";
            this.prizeTicketPanel.ResumeLayout(false);
            this.prizeTicketPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel prizeTicketPanel;
        private System.Windows.Forms.TextBox prizeTextBox;
    }
}