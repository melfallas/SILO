namespace SILO.DesktopApplication.Core.Forms.Modules.Parameters
{
    partial class SyncParamForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SyncParamForm));
            this.txtSyncPeriod = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxEnableSync = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSyncPeriod
            // 
            this.txtSyncPeriod.Location = new System.Drawing.Point(233, 62);
            this.txtSyncPeriod.Name = "txtSyncPeriod";
            this.txtSyncPeriod.Size = new System.Drawing.Size(72, 20);
            this.txtSyncPeriod.TabIndex = 15;
            this.txtSyncPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(24, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 23);
            this.label3.TabIndex = 14;
            this.label3.Text = "Período de Sincronización:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxEnableSync
            // 
            this.cbxEnableSync.AutoSize = true;
            this.cbxEnableSync.Checked = true;
            this.cbxEnableSync.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxEnableSync.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxEnableSync.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbxEnableSync.Location = new System.Drawing.Point(27, 102);
            this.cbxEnableSync.Name = "cbxEnableSync";
            this.cbxEnableSync.Size = new System.Drawing.Size(238, 21);
            this.cbxEnableSync.TabIndex = 16;
            this.cbxEnableSync.Text = "Habilitar Sincronización Periódica";
            this.cbxEnableSync.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.ForeColor = System.Drawing.Color.MidnightBlue;
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.saveButton.Location = new System.Drawing.Point(122, 158);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(84, 67);
            this.saveButton.TabIndex = 21;
            this.saveButton.Text = "Guardar";
            this.saveButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // SyncParamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 261);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cbxEnableSync);
            this.Controls.Add(this.txtSyncPeriod);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SyncParamForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parámetros de Sincronización";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LocalParamForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSyncPeriod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbxEnableSync;
        private System.Windows.Forms.Button saveButton;
    }
}