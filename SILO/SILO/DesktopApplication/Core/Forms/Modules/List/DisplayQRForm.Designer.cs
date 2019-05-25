namespace SILO
{
    partial class DisplayQRForm
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
            this.displayQRPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.countLabel = new System.Windows.Forms.Label();
            this.drawLabel = new System.Windows.Forms.Label();
            this.posLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.copyQRButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // displayQRPanel
            // 
            this.displayQRPanel.Location = new System.Drawing.Point(25, 23);
            this.displayQRPanel.Name = "displayQRPanel";
            this.displayQRPanel.Size = new System.Drawing.Size(372, 344);
            this.displayQRPanel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.countLabel);
            this.panel1.Controls.Add(this.displayQRPanel);
            this.panel1.Location = new System.Drawing.Point(33, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(423, 396);
            this.panel1.TabIndex = 1;
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Location = new System.Drawing.Point(188, 379);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(34, 13);
            this.countLabel.TabIndex = 2;
            this.countLabel.Text = "count";
            // 
            // drawLabel
            // 
            this.drawLabel.AutoSize = true;
            this.drawLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drawLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.drawLabel.Location = new System.Drawing.Point(284, 27);
            this.drawLabel.Name = "drawLabel";
            this.drawLabel.Size = new System.Drawing.Size(66, 19);
            this.drawLabel.TabIndex = 2;
            this.drawLabel.Text = "Sorteo:";
            this.drawLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // posLabel
            // 
            this.posLabel.AutoSize = true;
            this.posLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.posLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.posLabel.Location = new System.Drawing.Point(42, 27);
            this.posLabel.Name = "posLabel";
            this.posLabel.Size = new System.Drawing.Size(83, 19);
            this.posLabel.TabIndex = 3;
            this.posLabel.Text = "Sucursal:";
            this.posLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dateLabel.Location = new System.Drawing.Point(164, 9);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(55, 18);
            this.dateLabel.TabIndex = 3;
            this.dateLabel.Text = "Fecha:";
            this.dateLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // copyQRButton
            // 
            this.copyQRButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.copyQRButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyQRButton.ForeColor = System.Drawing.Color.Navy;
            this.copyQRButton.Location = new System.Drawing.Point(129, 451);
            this.copyQRButton.Name = "copyQRButton";
            this.copyQRButton.Size = new System.Drawing.Size(232, 25);
            this.copyQRButton.TabIndex = 0;
            this.copyQRButton.Text = "Copiar para envío por Whatsapp";
            this.copyQRButton.UseVisualStyleBackColor = true;
            this.copyQRButton.Click += new System.EventHandler(this.copyQRButton_Click);
            // 
            // DisplayQRForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(485, 486);
            this.Controls.Add(this.copyQRButton);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.posLabel);
            this.Controls.Add(this.drawLabel);
            this.Controls.Add(this.panel1);
            this.Name = "DisplayQRForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Despliegue de código QR";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel displayQRPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label countLabel;
        private System.Windows.Forms.Label drawLabel;
        private System.Windows.Forms.Label posLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Button copyQRButton;
    }
}