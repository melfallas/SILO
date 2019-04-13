﻿namespace SILO.DesktopApplication.Core.Forms.Modules.Sale
{
    partial class NumberBoxForm
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
            this.numberBoxMainPanel = new System.Windows.Forms.Panel();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.numberBoxPanel = new System.Windows.Forms.Panel();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txbPendingImport = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txbMaxToReceive = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbSyncImport = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbTotalImport = new System.Windows.Forms.TextBox();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.drawTypeBox = new System.Windows.Forms.ComboBox();
            this.datePickerList = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.titlePanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.numberBoxMainPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.footerPanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.titlePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // numberBoxMainPanel
            // 
            this.numberBoxMainPanel.Controls.Add(this.contentPanel);
            this.numberBoxMainPanel.Controls.Add(this.titlePanel);
            this.numberBoxMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numberBoxMainPanel.Location = new System.Drawing.Point(0, 0);
            this.numberBoxMainPanel.Name = "numberBoxMainPanel";
            this.numberBoxMainPanel.Size = new System.Drawing.Size(567, 420);
            this.numberBoxMainPanel.TabIndex = 5;
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.contentPanel.Controls.Add(this.numberBoxPanel);
            this.contentPanel.Controls.Add(this.footerPanel);
            this.contentPanel.Controls.Add(this.headerPanel);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 37);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(567, 383);
            this.contentPanel.TabIndex = 1;
            // 
            // numberBoxPanel
            // 
            this.numberBoxPanel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.numberBoxPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numberBoxPanel.Location = new System.Drawing.Point(0, 63);
            this.numberBoxPanel.Name = "numberBoxPanel";
            this.numberBoxPanel.Size = new System.Drawing.Size(567, 237);
            this.numberBoxPanel.TabIndex = 2;
            // 
            // footerPanel
            // 
            this.footerPanel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.footerPanel.Controls.Add(this.label7);
            this.footerPanel.Controls.Add(this.txbPendingImport);
            this.footerPanel.Controls.Add(this.label6);
            this.footerPanel.Controls.Add(this.txbMaxToReceive);
            this.footerPanel.Controls.Add(this.label5);
            this.footerPanel.Controls.Add(this.txbSyncImport);
            this.footerPanel.Controls.Add(this.label4);
            this.footerPanel.Controls.Add(this.txbTotalImport);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 300);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(567, 83);
            this.footerPanel.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(387, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Total Pend.";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txbPendingImport
            // 
            this.txbPendingImport.Location = new System.Drawing.Point(455, 59);
            this.txbPendingImport.Name = "txbPendingImport";
            this.txbPendingImport.ReadOnly = true;
            this.txbPendingImport.Size = new System.Drawing.Size(100, 20);
            this.txbPendingImport.TabIndex = 6;
            this.txbPendingImport.Text = "0";
            this.txbPendingImport.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(36, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Max. Recibir";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txbMaxToReceive
            // 
            this.txbMaxToReceive.Location = new System.Drawing.Point(104, 7);
            this.txbMaxToReceive.Name = "txbMaxToReceive";
            this.txbMaxToReceive.ReadOnly = true;
            this.txbMaxToReceive.Size = new System.Drawing.Size(100, 20);
            this.txbMaxToReceive.TabIndex = 4;
            this.txbMaxToReceive.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(387, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Sincronizado";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txbSyncImport
            // 
            this.txbSyncImport.Location = new System.Drawing.Point(455, 33);
            this.txbSyncImport.Name = "txbSyncImport";
            this.txbSyncImport.ReadOnly = true;
            this.txbSyncImport.Size = new System.Drawing.Size(100, 20);
            this.txbSyncImport.TabIndex = 2;
            this.txbSyncImport.Text = "0";
            this.txbSyncImport.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(387, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Total Venta";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txbTotalImport
            // 
            this.txbTotalImport.Location = new System.Drawing.Point(455, 7);
            this.txbTotalImport.Name = "txbTotalImport";
            this.txbTotalImport.ReadOnly = true;
            this.txbTotalImport.Size = new System.Drawing.Size(100, 20);
            this.txbTotalImport.TabIndex = 0;
            this.txbTotalImport.Text = "0";
            this.txbTotalImport.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.headerPanel.Controls.Add(this.drawTypeBox);
            this.headerPanel.Controls.Add(this.datePickerList);
            this.headerPanel.Controls.Add(this.label3);
            this.headerPanel.Controls.Add(this.label2);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(567, 63);
            this.headerPanel.TabIndex = 0;
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
            this.drawTypeBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.drawTypeBox_KeyPress);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(238, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Grupo:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(48, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // titlePanel
            // 
            this.titlePanel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.titlePanel.Controls.Add(this.label1);
            this.titlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlePanel.Location = new System.Drawing.Point(0, 0);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(567, 37);
            this.titlePanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Listado de Números";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // NumberBoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 420);
            this.Controls.Add(this.numberBoxMainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NumberBoxForm";
            this.Text = "NumberBoxForm";
            this.numberBoxMainPanel.ResumeLayout(false);
            this.contentPanel.ResumeLayout(false);
            this.footerPanel.ResumeLayout(false);
            this.footerPanel.PerformLayout();
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel numberBoxMainPanel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel footerPanel;
        private System.Windows.Forms.Panel numberBoxPanel;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.ComboBox drawTypeBox;
        private System.Windows.Forms.DateTimePicker datePickerList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel titlePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbTotalImport;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbSyncImport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbMaxToReceive;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbPendingImport;
    }
}