namespace SILO
{
    partial class ListBoxSelector
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
            this.listSelectorGrid = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectListButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.listSelectorGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // listSelectorGrid
            // 
            this.listSelectorGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listSelectorGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.date,
            this.group,
            this.name});
            this.listSelectorGrid.Location = new System.Drawing.Point(29, 31);
            this.listSelectorGrid.Name = "listSelectorGrid";
            this.listSelectorGrid.Size = new System.Drawing.Size(511, 150);
            this.listSelectorGrid.TabIndex = 0;
            // 
            // id
            // 
            this.id.HeaderText = "TICKET";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // date
            // 
            this.date.HeaderText = "FECHA";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            // 
            // group
            // 
            this.group.HeaderText = "GRUPO";
            this.group.Name = "group";
            this.group.ReadOnly = true;
            // 
            // name
            // 
            this.name.HeaderText = "A NOMBRE DE";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 150;
            // 
            // selectListButton
            // 
            this.selectListButton.Location = new System.Drawing.Point(240, 214);
            this.selectListButton.Name = "selectListButton";
            this.selectListButton.Size = new System.Drawing.Size(75, 23);
            this.selectListButton.TabIndex = 1;
            this.selectListButton.Text = "Seleccionar";
            this.selectListButton.UseVisualStyleBackColor = true;
            this.selectListButton.Click += new System.EventHandler(this.selectListButton_Click);
            // 
            // ListBoxSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.selectListButton);
            this.Controls.Add(this.listSelectorGrid);
            this.Name = "ListBoxSelector";
            this.Size = new System.Drawing.Size(566, 328);
            ((System.ComponentModel.ISupportInitialize)(this.listSelectorGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView listSelectorGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn group;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.Button selectListButton;
    }
}
