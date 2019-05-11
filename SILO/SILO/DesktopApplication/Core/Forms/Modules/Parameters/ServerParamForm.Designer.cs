namespace SILO.DesktopApplication.Core.Forms.Modules.Parameters
{
    partial class ServerParamForm
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
            this.printIndicationLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txbServiceName = new System.Windows.Forms.TextBox();
            this.txbServiceURL = new System.Windows.Forms.TextBox();
            this.txbServicePath = new System.Windows.Forms.TextBox();
            this.txtProhibitedMargin = new System.Windows.Forms.TextBox();
            this.txtMaxLineCount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // printIndicationLabel
            // 
            this.printIndicationLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.printIndicationLabel.ForeColor = System.Drawing.Color.Black;
            this.printIndicationLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.printIndicationLabel.Location = new System.Drawing.Point(12, 30);
            this.printIndicationLabel.Name = "printIndicationLabel";
            this.printIndicationLabel.Size = new System.Drawing.Size(175, 23);
            this.printIndicationLabel.TabIndex = 4;
            this.printIndicationLabel.Text = "Nombre del servicio:";
            this.printIndicationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(12, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "URL:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(12, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ruta";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(12, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Máximo de líneas:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(12, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Margen prohibidos:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbServiceName
            // 
            this.txbServiceName.Location = new System.Drawing.Point(183, 33);
            this.txbServiceName.Name = "txbServiceName";
            this.txbServiceName.Size = new System.Drawing.Size(238, 20);
            this.txbServiceName.TabIndex = 9;
            // 
            // txbServiceURL
            // 
            this.txbServiceURL.Location = new System.Drawing.Point(183, 65);
            this.txbServiceURL.Name = "txbServiceURL";
            this.txbServiceURL.Size = new System.Drawing.Size(238, 20);
            this.txbServiceURL.TabIndex = 10;
            // 
            // txbServicePath
            // 
            this.txbServicePath.Location = new System.Drawing.Point(183, 96);
            this.txbServicePath.Name = "txbServicePath";
            this.txbServicePath.Size = new System.Drawing.Size(238, 20);
            this.txbServicePath.TabIndex = 11;
            // 
            // txtProhibitedMargin
            // 
            this.txtProhibitedMargin.Location = new System.Drawing.Point(183, 133);
            this.txtProhibitedMargin.Name = "txtProhibitedMargin";
            this.txtProhibitedMargin.Size = new System.Drawing.Size(238, 20);
            this.txtProhibitedMargin.TabIndex = 12;
            // 
            // txtMaxLineCount
            // 
            this.txtMaxLineCount.Location = new System.Drawing.Point(183, 168);
            this.txtMaxLineCount.Name = "txtMaxLineCount";
            this.txtMaxLineCount.Size = new System.Drawing.Size(238, 20);
            this.txtMaxLineCount.TabIndex = 13;
            // 
            // ServerParamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 261);
            this.Controls.Add(this.txtMaxLineCount);
            this.Controls.Add(this.txtProhibitedMargin);
            this.Controls.Add(this.txbServicePath);
            this.Controls.Add(this.txbServiceURL);
            this.Controls.Add(this.txbServiceName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.printIndicationLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServerParamForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parámetros de servidor";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label printIndicationLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbServiceName;
        private System.Windows.Forms.TextBox txbServiceURL;
        private System.Windows.Forms.TextBox txbServicePath;
        private System.Windows.Forms.TextBox txtProhibitedMargin;
        private System.Windows.Forms.TextBox txtMaxLineCount;
    }
}