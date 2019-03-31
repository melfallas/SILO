namespace SILO.DesktopApplication.Core.Forms.Start
{
    partial class SplashScreenForm
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
            this.versionAppLabel = new System.Windows.Forms.Label();
            this.userLabel = new System.Windows.Forms.Label();
            this.splashProgressBar = new System.Windows.Forms.ProgressBar();
            this.loadStatusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // versionAppLabel
            // 
            this.versionAppLabel.AutoSize = true;
            this.versionAppLabel.ForeColor = System.Drawing.Color.White;
            this.versionAppLabel.Location = new System.Drawing.Point(261, 9);
            this.versionAppLabel.Name = "versionAppLabel";
            this.versionAppLabel.Size = new System.Drawing.Size(49, 13);
            this.versionAppLabel.TabIndex = 0;
            this.versionAppLabel.Text = "v 0.1.1.1";
            this.versionAppLabel.UseWaitCursor = true;
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userLabel.ForeColor = System.Drawing.Color.White;
            this.userLabel.Location = new System.Drawing.Point(110, 85);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(117, 25);
            this.userLabel.TabIndex = 1;
            this.userLabel.Text = "Iniciando...";
            this.userLabel.UseWaitCursor = true;
            // 
            // splashProgressBar
            // 
            this.splashProgressBar.Location = new System.Drawing.Point(115, 139);
            this.splashProgressBar.MarqueeAnimationSpeed = 50;
            this.splashProgressBar.Name = "splashProgressBar";
            this.splashProgressBar.Size = new System.Drawing.Size(104, 23);
            this.splashProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.splashProgressBar.TabIndex = 2;
            this.splashProgressBar.UseWaitCursor = true;
            this.splashProgressBar.Value = 10;
            // 
            // loadStatusLabel
            // 
            this.loadStatusLabel.AutoSize = true;
            this.loadStatusLabel.ForeColor = System.Drawing.Color.White;
            this.loadStatusLabel.Location = new System.Drawing.Point(115, 169);
            this.loadStatusLabel.Name = "loadStatusLabel";
            this.loadStatusLabel.Size = new System.Drawing.Size(131, 13);
            this.loadStatusLabel.TabIndex = 3;
            this.loadStatusLabel.Text = "Cargando datos iniciales...";
            this.loadStatusLabel.UseWaitCursor = true;
            // 
            // SplashScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(336, 216);
            this.Controls.Add(this.loadStatusLabel);
            this.Controls.Add(this.splashProgressBar);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.versionAppLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashScreenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Silo Application";
            this.UseWaitCursor = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label versionAppLabel;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.ProgressBar splashProgressBar;
        public System.Windows.Forms.Label loadStatusLabel;
    }
}