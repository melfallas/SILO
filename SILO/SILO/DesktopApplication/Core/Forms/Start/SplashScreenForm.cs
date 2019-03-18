using SILO.DesktopApplication.Core.Forms.Security.Login;
using SILO.DesktopApplication.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SILO.DesktopApplication.Core.Forms.Start
{
    public partial class SplashScreenForm : Form
    {
        delegate void CloseFormCallback();
        delegate void SetTextCallback(string text);

        public SplashScreenForm()
        {
            InitializeComponent();
            this.initializeComponent();
        }

        public void initializeComponent()
        {
            this.versionAppLabel.Text = UtilityService.getApplicationVersion();
        }

        public void DisposeForm()
        {
            if (this.InvokeRequired)
            {
                CloseFormCallback d = new CloseFormCallback(DisposeForm);
                this.Invoke(d);
            }
            else
            {
                this.Dispose();
            }
        }

        public void SetText(string text)
        {
            if (this.loadStatusLabel.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.loadStatusLabel.Text = text;
            }
        }
    }
}
