namespace SILO.DesktopApplication.Core.Forms.Modules.Parameters
{
    partial class PrinterParamsForm
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
            this.printerBox = new System.Windows.Forms.ComboBox();
            this.savePrinterButton = new System.Windows.Forms.Button();
            this.cbxEnablePrint = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // printerBox
            // 
            this.printerBox.FormattingEnabled = true;
            this.printerBox.Location = new System.Drawing.Point(106, 57);
            this.printerBox.Name = "printerBox";
            this.printerBox.Size = new System.Drawing.Size(189, 21);
            this.printerBox.TabIndex = 0;
            // 
            // savePrinterButton
            // 
            this.savePrinterButton.Location = new System.Drawing.Point(162, 180);
            this.savePrinterButton.Name = "savePrinterButton";
            this.savePrinterButton.Size = new System.Drawing.Size(75, 23);
            this.savePrinterButton.TabIndex = 1;
            this.savePrinterButton.Text = "Guardar";
            this.savePrinterButton.UseVisualStyleBackColor = true;
            this.savePrinterButton.Click += new System.EventHandler(this.savePrinterButton_Click);
            // 
            // cbxEnablePrint
            // 
            this.cbxEnablePrint.AutoSize = true;
            this.cbxEnablePrint.Location = new System.Drawing.Point(146, 108);
            this.cbxEnablePrint.Name = "cbxEnablePrint";
            this.cbxEnablePrint.Size = new System.Drawing.Size(112, 17);
            this.cbxEnablePrint.TabIndex = 2;
            this.cbxEnablePrint.Text = "Habilitar Impresión";
            this.cbxEnablePrint.UseVisualStyleBackColor = true;
            // 
            // PrinterParamsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 261);
            this.Controls.Add(this.cbxEnablePrint);
            this.Controls.Add(this.savePrinterButton);
            this.Controls.Add(this.printerBox);
            this.Name = "PrinterParamsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrinterParamsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox printerBox;
        private System.Windows.Forms.Button savePrinterButton;
        private System.Windows.Forms.CheckBox cbxEnablePrint;
    }
}