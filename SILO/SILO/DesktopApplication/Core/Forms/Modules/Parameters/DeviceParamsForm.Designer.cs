namespace SILO.DesktopApplication.Core.Forms.Modules.Parameters
{
    partial class DeviceParamsForm
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
            this.devicesListBox = new System.Windows.Forms.ComboBox();
            this.saveDeviceButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // devicesListBox
            // 
            this.devicesListBox.FormattingEnabled = true;
            this.devicesListBox.Location = new System.Drawing.Point(135, 64);
            this.devicesListBox.Name = "devicesListBox";
            this.devicesListBox.Size = new System.Drawing.Size(165, 21);
            this.devicesListBox.TabIndex = 1;
            // 
            // saveDeviceButton
            // 
            this.saveDeviceButton.Location = new System.Drawing.Point(182, 162);
            this.saveDeviceButton.Name = "saveDeviceButton";
            this.saveDeviceButton.Size = new System.Drawing.Size(75, 23);
            this.saveDeviceButton.TabIndex = 2;
            this.saveDeviceButton.Text = "Guardar";
            this.saveDeviceButton.UseVisualStyleBackColor = true;
            this.saveDeviceButton.Click += new System.EventHandler(this.saveDeviceButton_Click);
            // 
            // DeviceParamsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 261);
            this.Controls.Add(this.saveDeviceButton);
            this.Controls.Add(this.devicesListBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeviceParamsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control de Dispositivos";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox devicesListBox;
        private System.Windows.Forms.Button saveDeviceButton;
    }
}