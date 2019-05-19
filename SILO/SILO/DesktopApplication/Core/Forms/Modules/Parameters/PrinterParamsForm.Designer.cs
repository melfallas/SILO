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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrinterParamsForm));
            this.printerBox = new System.Windows.Forms.ComboBox();
            this.savePrinterButton = new System.Windows.Forms.Button();
            this.cbxEnablePrint = new System.Windows.Forms.CheckBox();
            this.printIndicationLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // printerBox
            // 
            this.printerBox.FormattingEnabled = true;
            resources.ApplyResources(this.printerBox, "printerBox");
            this.printerBox.Name = "printerBox";
            // 
            // savePrinterButton
            // 
            resources.ApplyResources(this.savePrinterButton, "savePrinterButton");
            this.savePrinterButton.Name = "savePrinterButton";
            this.savePrinterButton.UseVisualStyleBackColor = true;
            this.savePrinterButton.Click += new System.EventHandler(this.savePrinterButton_Click);
            // 
            // cbxEnablePrint
            // 
            resources.ApplyResources(this.cbxEnablePrint, "cbxEnablePrint");
            this.cbxEnablePrint.Checked = true;
            this.cbxEnablePrint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxEnablePrint.Name = "cbxEnablePrint";
            this.cbxEnablePrint.UseVisualStyleBackColor = true;
            // 
            // printIndicationLabel
            // 
            resources.ApplyResources(this.printIndicationLabel, "printIndicationLabel");
            this.printIndicationLabel.ForeColor = System.Drawing.Color.Black;
            this.printIndicationLabel.Name = "printIndicationLabel";
            // 
            // PrinterParamsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.printIndicationLabel);
            this.Controls.Add(this.cbxEnablePrint);
            this.Controls.Add(this.savePrinterButton);
            this.Controls.Add(this.printerBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrinterParamsForm";
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