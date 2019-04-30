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
        delegate void UpdateProgressBarCallback(int pValue);

        public SplashScreenForm()
        {
            InitializeComponent();
            this.initializeComponent();
            this.TopMost = true;
        }

        public void initializeComponent()
        {
            this.versionAppLabel.Text = UtilityService.getApplicationVersion();
        }

        public SplashScreenForm getForm()
        {
            SplashScreenForm thisForm = null;
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate {
                    thisForm = this;
                }));
            }
            else
            {
                thisForm = this;
            }
            return thisForm;
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

        public void updateProgressBar(int pValue)
        {
            if (this.loadStatusLabel.InvokeRequired)
            {
                UpdateProgressBarCallback d = new UpdateProgressBarCallback(updateProgressBar);
                this.Invoke(d, new object[] { pValue });
            }
            else
            {
                this.splashProgressBar.Value = pValue;
            }
        }

    }
}
