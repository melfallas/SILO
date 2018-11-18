namespace SILO
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.datePickerList = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.drawTypeBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Listado de Números";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // datePickerList
            // 
            this.datePickerList.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePickerList.CustomFormat = "dd/MM/yyyy";
            this.datePickerList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePickerList.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerList.Location = new System.Drawing.Point(80, 39);
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
            this.label3.Location = new System.Drawing.Point(202, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Grupo:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // drawTypeBox
            // 
            this.drawTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drawTypeBox.FormattingEnabled = true;
            this.drawTypeBox.Location = new System.Drawing.Point(271, 44);
            this.drawTypeBox.Name = "drawTypeBox";
            this.drawTypeBox.Size = new System.Drawing.Size(218, 21);
            this.drawTypeBox.TabIndex = 4;
            this.drawTypeBox.SelectedIndexChanged += new System.EventHandler(this.drawTypeBox_SelectedIndexChanged);
            this.drawTypeBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.drawTypeBox_KeyPress);
            // 
            // NumberBoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 356);
            this.Controls.Add(this.drawTypeBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.datePickerList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NumberBoxForm";
            this.Text = "NumberBoxForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker datePickerList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox drawTypeBox;
    }
}