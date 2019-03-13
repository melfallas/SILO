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

        private bool isValidLoginForm(string pUser, string pPassword)
        {
            bool validFields = false;
            if (pUser == "" || pPassword == "")
            {
                MessageBox.Show(GeneralConstants.USER_AND_PASS_REQUIRED_VALIDATION);
            }
            else
            {
                validFields = true;
            }
            return validFields;
        }

        private bool requestUserAuthetication(string pUser, string pPassword)
        {
            bool validFields = false;
            if (pUser == "fsandi" && pPassword == "fsandi")
            {
                validFields = true;
            }
            return validFields;
        }

        private void cleanFields()
        {
            this.txbPass.Text = "";
        }

        private void launchApplication() {
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

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (!this.isValidLoginForm(this.txbUser.Text, this.txbPass.Text))
            {
                this.cleanFields();
            }
            else
            {
                // Realizar autenticación del usuario
                if (this.requestUserAuthetication(this.txbUser.Text, this.txbPass.Text))
                {
                    // Lanzar aplicación si la autenticación es exitosa
                    this.launchApplication();
                }
                else
                {
                    // Mensaje de error para credenciales inválidas
                    MessageBox.Show(GeneralConstants.BAD_USER_OR_PASS);
                    this.cleanFields();
                }
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
