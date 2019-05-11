namespace SILO
{
    partial class LotteryListControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.listView = new System.Windows.Forms.DataGridView();
            this.listNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listImport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalTextLabel = new System.Windows.Forms.Label();
            this.txbTotalImport = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.listView)).BeginInit();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.listView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.listView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.listNumber,
            this.listImport});
            this.listView.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.listView.DefaultCellStyle = dataGridViewCellStyle2;
            this.listView.EnableHeadersVisualStyles = false;
            this.listView.Location = new System.Drawing.Point(30, 3);
            this.listView.Name = "listView";
            this.listView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.listView.RowHeadersWidth = 60;
            this.listView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.listView.Size = new System.Drawing.Size(222, 362);
            this.listView.TabIndex = 0;
            this.listView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.listView_CellBeginEdit);
            this.listView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listView_CellClick);
            this.listView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.listView_CellEndEdit);
            this.listView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.listView_CellEnter);
            this.listView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.listView_CellValueChanged);
            this.listView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView_KeyDown);
            // 
            // listNumber
            // 
            this.listNumber.FillWeight = 60F;
            this.listNumber.HeaderText = "No.";
            this.listNumber.MaxInputLength = 2;
            this.listNumber.MinimumWidth = 60;
            this.listNumber.Name = "listNumber";
            this.listNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.listNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.listNumber.Width = 60;
            // 
            // listImport
            // 
            this.listImport.HeaderText = "Monto";
            this.listImport.MinimumWidth = 100;
            this.listImport.Name = "listImport";
            this.listImport.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // totalTextLabel
            // 
            this.totalTextLabel.AutoSize = true;
            this.totalTextLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalTextLabel.Location = new System.Drawing.Point(44, 374);
            this.totalTextLabel.Name = "totalTextLabel";
            this.totalTextLabel.Size = new System.Drawing.Size(82, 22);
            this.totalTextLabel.TabIndex = 3;
            this.totalTextLabel.Text = "TOTAL:";
            // 
            // txbTotalImport
            // 
            this.txbTotalImport.Enabled = false;
            this.txbTotalImport.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTotalImport.Location = new System.Drawing.Point(132, 371);
            this.txbTotalImport.Name = "txbTotalImport";
            this.txbTotalImport.Size = new System.Drawing.Size(98, 26);
            this.txbTotalImport.TabIndex = 5;
            this.txbTotalImport.Text = "0";
            this.txbTotalImport.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LotteryListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txbTotalImport);
            this.Controls.Add(this.totalTextLabel);
            this.Controls.Add(this.listView);
            this.Name = "LotteryListControl";
            this.Size = new System.Drawing.Size(277, 405);
            ((System.ComponentModel.ISupportInitialize)(this.listView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView listView;
        private System.Windows.Forms.DataGridViewTextBoxColumn listNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn listImport;
        private System.Windows.Forms.Label totalTextLabel;
        private System.Windows.Forms.TextBox txbTotalImport;
    }
}
