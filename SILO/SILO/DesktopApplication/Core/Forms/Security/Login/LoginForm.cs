using SILO.Core.Constants;
using SILO.DesktopApplication.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SILO.DesktopApplication.Core.Forms.Security.Login
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
            if (pUser.Trim() == "" || pPassword.Trim() == "")
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
            bool validCredentials = false;
            LoginService loginService = new LoginService();
            if (loginService.doLogin(pUser.Trim(), pPassword.Trim()))
            {
                validCredentials = true;
            }
            return validCredentials;
        }

        private void cleanFields()
        {
            this.txbPass.Text = "";
            this.txbUser.Text = this.txbUser.Text.Trim();
            this.txbUser.Focus();
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


        //--------------------------------------- Eventos de controles principales --------------------------------------//

        // Acción que controla el evento de Login al Ingresar
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
                    // Si la autenticación es exitosa, probar la inicializació de la instancia
                    ProgramInitializationService programInicializer = new ProgramInitializationService();
                    if (programInicializer.setInstancePointSale())
                    {
                        // Lanzar aplicación si la instancia está inicializada
                        this.launchApplication();
                    }
                    else {
                        // Si la instancia no está inicializada, cerrar el programa
                        this.cleanFields();
                    }

                }
                else
                {
                    // Mensaje de error para credenciales inválidas
                    MessageService.displayErrorMessage(
                            GeneralConstants.BAD_USER_OR_PASS_ERROR,
                            GeneralConstants.BAD_USER_OR_PASS_TITLE
                            );
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
