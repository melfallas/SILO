namespace SILO
{
    partial class ProhibitedNumberForm
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
            this.prohibitedTopPanel = new System.Windows.Forms.Panel();
            this.prohibitedBottomPanel = new System.Windows.Forms.Panel();
            this.prohibitedMainPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // prohibitedTopPanel
            // 
            this.prohibitedTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.prohibitedTopPanel.Location = new System.Drawing.Point(0, 0);
            this.prohibitedTopPanel.Name = "prohibitedTopPanel";
            this.prohibitedTopPanel.Size = new System.Drawing.Size(587, 64);
            this.prohibitedTopPanel.TabIndex = 0;
            // 
            // prohibitedBottomPanel
            // 
            this.prohibitedBottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.prohibitedBottomPanel.Location = new System.Drawing.Point(0, 353);
            this.prohibitedBottomPanel.Name = "prohibitedBottomPanel";
            this.prohibitedBottomPanel.Size = new System.Drawing.Size(587, 60);
            this.prohibitedBottomPanel.TabIndex = 1;
            // 
            // prohibitedMainPanel
            // 
            this.prohibitedMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prohibitedMainPanel.Location = new System.Drawing.Point(0, 64);
            this.prohibitedMainPanel.Name = "prohibitedMainPanel";
            this.prohibitedMainPanel.Size = new System.Drawing.Size(587, 289);
            this.prohibitedMainPanel.TabIndex = 2;
            // 
            // ProhibitedNumberForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 413);
            this.Controls.Add(this.prohibitedMainPanel);
            this.Controls.Add(this.prohibitedBottomPanel);
            this.Controls.Add(this.prohibitedTopPanel);
            this.Name = "ProhibitedNumberForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Números Prohibidos";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel prohibitedTopPanel;
        private System.Windows.Forms.Panel prohibitedBottomPanel;
        private System.Windows.Forms.Panel prohibitedMainPanel;
    }
}