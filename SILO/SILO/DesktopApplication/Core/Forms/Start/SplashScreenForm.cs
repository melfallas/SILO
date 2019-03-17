using SILO.DesktopApplication.Core.Forms.Security.Login;
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
        public SplashScreenForm()
        {
            InitializeComponent();
            this.initializeComponent();
        }

        public void initializeComponent()
        {
            this.versionAppLabel.Text = UtilityService.getApplicationVersion();
        }
    }
}
