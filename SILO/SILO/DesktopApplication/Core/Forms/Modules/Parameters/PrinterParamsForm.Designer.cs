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
            this.printIndicationLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // printerBox
            // 
            this.printerBox.FormattingEnabled = true;
            this.printerBox.Location = new System.Drawing.Point(105, 83);
            this.printerBox.Name = "printerBox";
            this.printerBox.Size = new System.Drawing.Size(189, 21);
            this.printerBox.TabIndex = 0;
            // 
            // savePrinterButton
            // 
            this.savePrinterButton.Location = new System.Drawing.Point(155, 188);
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
            this.cbxEnablePrint.Checked = true;
            this.cbxEnablePrint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxEnablePrint.Location = new System.Drawing.Point(141, 126);
            this.cbxEnablePrint.Name = "cbxEnablePrint";
            this.cbxEnablePrint.Size = new System.Drawing.Size(112, 17);
            this.cbxEnablePrint.TabIndex = 2;
            this.cbxEnablePrint.Text = "Habilitar Impresión";
            this.cbxEnablePrint.UseVisualStyleBackColor = true;
            // 
            // printIndicationLabel
            // 
            this.printIndicationLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printIndicationLabel.ForeColor = System.Drawing.Color.Black;
            this.printIndicationLabel.Location = new System.Drawing.Point(3, 33);
            this.printIndicationLabel.Name = "printIndicationLabel";
            this.printIndicationLabel.Size = new System.Drawing.Size(399, 23);
            this.printIndicationLabel.TabIndex = 3;
            this.printIndicationLabel.Text = "Seleccione la impresora a establecer:";
            this.printIndicationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PrinterParamsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 261);
            this.Controls.Add(this.printIndicationLabel);
            this.Controls.Add(this.cbxEnablePrint);
            this.Controls.Add(this.savePrinterButton);
            this.Controls.Add(this.printerBox);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrinterParamsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Establecimiento de la impresora";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PrinterParamsForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox printerBox;
        private System.Windows.Forms.Button savePrinterButton;
        private System.Windows.Forms.CheckBox cbxEnablePrint;
        private System.Windows.Forms.Label printIndicationLabel;
    }
}