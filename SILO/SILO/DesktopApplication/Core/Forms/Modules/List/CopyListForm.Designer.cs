namespace SILO.DesktopApplication.Core.Forms.Modules.List
{
    partial class CopyListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CopyListForm));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.datePickerDate = new System.Windows.Forms.DateTimePicker();
            this.topPanel = new System.Windows.Forms.Panel();
            this.centerPanel = new System.Windows.Forms.Panel();
            this.topCenterPanel = new System.Windows.Forms.Panel();
            this.bottomCenterPanel = new System.Windows.Forms.Panel();
            this.centerMainPanel = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.copyButton = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.centerPanel.SuspendLayout();
            this.topCenterPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.centerPanel);
            this.mainPanel.Controls.Add(this.bottomPanel);
            this.mainPanel.Controls.Add(this.topPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(533, 343);
            this.mainPanel.TabIndex = 0;
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.cancelButton);
            this.bottomPanel.Controls.Add(this.copyButton);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 262);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(533, 81);
            this.bottomPanel.TabIndex = 2;
            // 
            // datePickerDate
            // 
            this.datePickerDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePickerDate.CustomFormat = "dd/MM/yyyy";
            this.datePickerDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePickerDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerDate.Location = new System.Drawing.Point(218, 6);
            this.datePickerDate.Name = "datePickerDate";
            this.datePickerDate.Size = new System.Drawing.Size(88, 23);
            this.datePickerDate.TabIndex = 3;
            // 
            // topPanel
            // 
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(533, 34);
            this.topPanel.TabIndex = 0;
            // 
            // centerPanel
            // 
            this.centerPanel.Controls.Add(this.centerMainPanel);
            this.centerPanel.Controls.Add(this.bottomCenterPanel);
            this.centerPanel.Controls.Add(this.topCenterPanel);
            this.centerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.centerPanel.Location = new System.Drawing.Point(0, 34);
            this.centerPanel.Name = "centerPanel";
            this.centerPanel.Size = new System.Drawing.Size(533, 228);
            this.centerPanel.TabIndex = 3;
            // 
            // topCenterPanel
            // 
            this.topCenterPanel.Controls.Add(this.datePickerDate);
            this.topCenterPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topCenterPanel.Location = new System.Drawing.Point(0, 0);
            this.topCenterPanel.Name = "topCenterPanel";
            this.topCenterPanel.Size = new System.Drawing.Size(533, 39);
            this.topCenterPanel.TabIndex = 0;
            // 
            // bottomCenterPanel
            // 
            this.bottomCenterPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomCenterPanel.Location = new System.Drawing.Point(0, 218);
            this.bottomCenterPanel.Name = "bottomCenterPanel";
            this.bottomCenterPanel.Size = new System.Drawing.Size(533, 10);
            this.bottomCenterPanel.TabIndex = 1;
            // 
            // centerMainPanel
            // 
            this.centerMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.centerMainPanel.Location = new System.Drawing.Point(0, 39);
            this.centerMainPanel.Name = "centerMainPanel";
            this.centerMainPanel.Size = new System.Drawing.Size(533, 179);
            this.centerMainPanel.TabIndex = 2;
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cancelButton.Image = ((System.Drawing.Image)(resources.GetObject("cancelButton.Image")));
            this.cancelButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cancelButton.Location = new System.Drawing.Point(281, 7);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(80, 67);
            this.cancelButton.TabIndex = 28;
            this.cancelButton.Text = "Cancelar";
            this.cancelButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // copyButton
            // 
            this.copyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyButton.ForeColor = System.Drawing.Color.MidnightBlue;
            this.copyButton.Image = ((System.Drawing.Image)(resources.GetObject("copyButton.Image")));
            this.copyButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.copyButton.Location = new System.Drawing.Point(172, 7);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(84, 67);
            this.copyButton.TabIndex = 27;
            this.copyButton.Text = "Copiar";
            this.copyButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // CopyListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 343);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CopyListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CopyListForm";
            this.mainPanel.ResumeLayout(false);
            this.bottomPanel.ResumeLayout(false);
            this.centerPanel.ResumeLayout(false);
            this.topCenterPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.DateTimePicker datePickerDate;
        private System.Windows.Forms.Panel centerPanel;
        private System.Windows.Forms.Panel centerMainPanel;
        private System.Windows.Forms.Panel bottomCenterPanel;
        private System.Windows.Forms.Panel topCenterPanel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button copyButton;
    }
}