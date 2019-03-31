namespace SILO
{
    partial class ListSelectorForm
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
            this.listSelectorPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // listSelectorPanel
            // 
            this.listSelectorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listSelectorPanel.Location = new System.Drawing.Point(0, 0);
            this.listSelectorPanel.Name = "listSelectorPanel";
            this.listSelectorPanel.Size = new System.Drawing.Size(560, 376);
            this.listSelectorPanel.TabIndex = 0;
            // 
            // ListSelectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 376);
            this.Controls.Add(this.listSelectorPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListSelectorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Seleccione una Lista";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ListSelectorForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListSelectorForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel listSelectorPanel;
    }
}