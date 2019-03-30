namespace SILO.DesktopApplication.Core.Forms.Modules.List
{
    partial class DisplayListForm
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
            this.titlePanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.drawTypeBox = new System.Windows.Forms.ComboBox();
            this.datePickerList = new System.Windows.Forms.DateTimePicker();
            this.groupSelectorLabel = new System.Windows.Forms.Label();
            this.dateSelectorLabel = new System.Windows.Forms.Label();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.numberBoxPanel = new System.Windows.Forms.Panel();
            this.titlePanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // titlePanel
            // 
            this.titlePanel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.titlePanel.Controls.Add(this.label1);
            this.titlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlePanel.Location = new System.Drawing.Point(0, 0);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(551, 37);
            this.titlePanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione los Parámetros de la Lista";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.headerPanel.Controls.Add(this.drawTypeBox);
            this.headerPanel.Controls.Add(this.datePickerList);
            this.headerPanel.Controls.Add(this.groupSelectorLabel);
            this.headerPanel.Controls.Add(this.dateSelectorLabel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 37);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(551, 63);
            this.headerPanel.TabIndex = 2;
            // 
            // drawTypeBox
            // 
            this.drawTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drawTypeBox.FormattingEnabled = true;
            this.drawTypeBox.Location = new System.Drawing.Point(307, 21);
            this.drawTypeBox.Name = "drawTypeBox";
            this.drawTypeBox.Size = new System.Drawing.Size(218, 21);
            this.drawTypeBox.TabIndex = 4;
            this.drawTypeBox.SelectedIndexChanged += new System.EventHandler(this.drawTypeBox_SelectedIndexChanged);
            // 
            // datePickerList
            // 
            this.datePickerList.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePickerList.CustomFormat = "dd/MM/yyyy";
            this.datePickerList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePickerList.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerList.Location = new System.Drawing.Point(116, 19);
            this.datePickerList.Name = "datePickerList";
            this.datePickerList.Size = new System.Drawing.Size(88, 23);
            this.datePickerList.TabIndex = 2;
            this.datePickerList.ValueChanged += new System.EventHandler(this.datePickerList_ValueChanged);
            // 
            // groupSelectorLabel
            // 
            this.groupSelectorLabel.AutoSize = true;
            this.groupSelectorLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupSelectorLabel.ForeColor = System.Drawing.Color.Navy;
            this.groupSelectorLabel.Location = new System.Drawing.Point(238, 23);
            this.groupSelectorLabel.Name = "groupSelectorLabel";
            this.groupSelectorLabel.Size = new System.Drawing.Size(63, 19);
            this.groupSelectorLabel.TabIndex = 3;
            this.groupSelectorLabel.Text = "Grupo:";
            this.groupSelectorLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dateSelectorLabel
            // 
            this.dateSelectorLabel.AutoSize = true;
            this.dateSelectorLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateSelectorLabel.ForeColor = System.Drawing.Color.Navy;
            this.dateSelectorLabel.Location = new System.Drawing.Point(48, 23);
            this.dateSelectorLabel.Name = "dateSelectorLabel";
            this.dateSelectorLabel.Size = new System.Drawing.Size(62, 19);
            this.dateSelectorLabel.TabIndex = 1;
            this.dateSelectorLabel.Text = "Fecha:";
            this.dateSelectorLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // footerPanel
            // 
            this.footerPanel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 280);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(551, 47);
            this.footerPanel.TabIndex = 3;
            // 
            // numberBoxPanel
            // 
            this.numberBoxPanel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.numberBoxPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numberBoxPanel.Location = new System.Drawing.Point(0, 100);
            this.numberBoxPanel.Name = "numberBoxPanel";
            this.numberBoxPanel.Size = new System.Drawing.Size(551, 180);
            this.numberBoxPanel.TabIndex = 4;
            // 
            // DisplayListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 327);
            this.Controls.Add(this.numberBoxPanel);
            this.Controls.Add(this.footerPanel);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.titlePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DisplayListForm";
            this.Text = "Seleccione los parámetros";
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel titlePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.ComboBox drawTypeBox;
        private System.Windows.Forms.DateTimePicker datePickerList;
        private System.Windows.Forms.Label groupSelectorLabel;
        private System.Windows.Forms.Label dateSelectorLabel;
        private System.Windows.Forms.Panel footerPanel;
        private System.Windows.Forms.Panel numberBoxPanel;
    }
}