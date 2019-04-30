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
            this.prohibedNumberLabel = new System.Windows.Forms.Label();
            this.prohibitedBottomPanel = new System.Windows.Forms.Panel();
            this.entryProhibitedButtom = new System.Windows.Forms.Button();
            this.prohibitedMainPanel = new System.Windows.Forms.Panel();
            this.prohibitedTopPanel.SuspendLayout();
            this.prohibitedBottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // prohibitedTopPanel
            // 
            this.prohibitedTopPanel.Controls.Add(this.prohibedNumberLabel);
            this.prohibitedTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.prohibitedTopPanel.Location = new System.Drawing.Point(0, 0);
            this.prohibitedTopPanel.Name = "prohibitedTopPanel";
            this.prohibitedTopPanel.Size = new System.Drawing.Size(587, 64);
            this.prohibitedTopPanel.TabIndex = 0;
            // 
            // prohibedNumberLabel
            // 
            this.prohibedNumberLabel.AutoSize = true;
            this.prohibedNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prohibedNumberLabel.Location = new System.Drawing.Point(40, 19);
            this.prohibedNumberLabel.Name = "prohibedNumberLabel";
            this.prohibedNumberLabel.Size = new System.Drawing.Size(276, 24);
            this.prohibedNumberLabel.TabIndex = 0;
            this.prohibedNumberLabel.Text = "Ingrese los números prohibidos";
            // 
            // prohibitedBottomPanel
            // 
            this.prohibitedBottomPanel.Controls.Add(this.entryProhibitedButtom);
            this.prohibitedBottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.prohibitedBottomPanel.Location = new System.Drawing.Point(0, 353);
            this.prohibitedBottomPanel.Name = "prohibitedBottomPanel";
            this.prohibitedBottomPanel.Size = new System.Drawing.Size(587, 60);
            this.prohibitedBottomPanel.TabIndex = 1;
            // 
            // entryProhibitedButtom
            // 
            this.entryProhibitedButtom.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.entryProhibitedButtom.Location = new System.Drawing.Point(244, 25);
            this.entryProhibitedButtom.Name = "entryProhibitedButtom";
            this.entryProhibitedButtom.Size = new System.Drawing.Size(75, 23);
            this.entryProhibitedButtom.TabIndex = 0;
            this.entryProhibitedButtom.Text = "Ingresar";
            this.entryProhibitedButtom.UseVisualStyleBackColor = false;
            this.entryProhibitedButtom.Click += new System.EventHandler(this.entryProhibitedButtom_Click);
            // 
            // prohibitedMainPanel
            // 
            this.prohibitedMainPanel.BackColor = System.Drawing.SystemColors.Control;
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProhibitedNumberForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingreso de números prohibidos";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProhibitedNumberForm_KeyDown);
            this.prohibitedTopPanel.ResumeLayout(false);
            this.prohibitedTopPanel.PerformLayout();
            this.prohibitedBottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel prohibitedTopPanel;
        private System.Windows.Forms.Panel prohibitedBottomPanel;
        private System.Windows.Forms.Panel prohibitedMainPanel;
        private System.Windows.Forms.Button entryProhibitedButtom;
        private System.Windows.Forms.Label prohibedNumberLabel;
    }
}