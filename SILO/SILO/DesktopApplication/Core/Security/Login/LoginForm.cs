using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SILO.DesktopApplication.Core.Security.Login
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                ApplicationForm appForm = new ApplicationForm(this);
                appForm.Show();
                this.Hide();
            }
            catch (Exception)
            {
                // LogService
                //throw;
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
