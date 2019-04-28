namespace SILO
{
    partial class MainOptionMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainOptionMenu));
            this.printButton = new System.Windows.Forms.Button();
            this.reprintButton = new System.Windows.Forms.Button();
            this.draw1Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // printButton
            // 
            this.printButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printButton.ForeColor = System.Drawing.Color.Navy;
            this.printButton.Image = ((System.Drawing.Image)(resources.GetObject("printButton.Image")));
            this.printButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.printButton.Location = new System.Drawing.Point(28, 22);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(118, 104);
            this.printButton.TabIndex = 0;
            this.printButton.Text = "Imprimir Papel";
            this.printButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // reprintButton
            // 
            this.reprintButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reprintButton.ForeColor = System.Drawing.Color.Navy;
            this.reprintButton.Image = ((System.Drawing.Image)(resources.GetObject("reprintButton.Image")));
            this.reprintButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.reprintButton.Location = new System.Drawing.Point(190, 22);
            this.reprintButton.Name = "reprintButton";
            this.reprintButton.Size = new System.Drawing.Size(118, 104);
            this.reprintButton.TabIndex = 1;
            this.reprintButton.Text = "Reimprimir";
            this.reprintButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.reprintButton.UseVisualStyleBackColor = true;
            this.reprintButton.Click += new System.EventHandler(this.reprintButton_Click);
            // 
            // draw1Button
            // 
            this.draw1Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.draw1Button.ForeColor = System.Drawing.Color.Navy;
            this.draw1Button.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.draw1Button.Location = new System.Drawing.Point(28, 210);
            this.draw1Button.Name = "draw1Button";
            this.draw1Button.Size = new System.Drawing.Size(118, 104);
            this.draw1Button.TabIndex = 2;
            this.draw1Button.Text = "TicaDía";
            this.draw1Button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.draw1Button.UseVisualStyleBackColor = true;
            this.draw1Button.Click += new System.EventHandler(this.draw1Button_Click);
            // 
            // MainOptionMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 344);
            this.Controls.Add(this.draw1Button);
            this.Controls.Add(this.reprintButton);
            this.Controls.Add(this.printButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "MainOptionMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Opciones Principales";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainOptionMenu_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.Button reprintButton;
        private System.Windows.Forms.Button draw1Button;
    }
}