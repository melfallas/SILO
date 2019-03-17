using SILO.Core.Constants;
using SILO.DesktopApplication.Core.Forms.Start;
using SILO.DesktopApplication.Core.Model;
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

namespace SILO.DesktopApplication.Core.Forms.Security.Login
{
    public partial class LoginForm : Form
    {
        public static EventWaitHandle waitHandle = new AutoResetEvent(false);

        public bool displayLogin { get; set; }
        public SplashScreenForm splashScreen { get; set; }

        public LoginForm()
        {
            this.displayLogin = true;
            this.splashScreen = null;
            this.launchSplashThread();
            InitializeComponent();
            this.versionLabel.Text = UtilityService.getApplicationVersion();
        }

        private void launchSplashThread()
        {
            // Lanzar el Thread para el Splash Screen
            Thread splashThread = new Thread(new ThreadStart(launchSplashScreen));
            splashThread.Start();
            string companyId = UtilityService.getCompanyId();
            // Verificar si la compañía está especificada y es válida
            if(ValidationService.isValidId(companyId))
            {
                // Realizar sincronización inicial
                this.startInitialSynchronization();
                //splashThread.Abort();
            }
            else
            {
                // Mensaje de error para compañía no especificada
                MessageService.displayErrorMessage(
                        GeneralConstants.UNINITIALIZED_COMPANY_ERROR,
                        GeneralConstants.UNINITIALIZED_COMPANY_TITLE
                        );
                this.displayLogin = false;
            }
            this.closeSplashScreen();
        }

        private void launchSplashScreen()
        {
            this.splashScreen = new SplashScreenForm();
            LoginForm.waitHandle.Set();
            Application.Run(this.splashScreen);
        }

        private void closeSplashScreen()
        {
            this.splashScreen.DisposeForm();
            this.splashScreen = null;
        }

        private void startInitialSynchronization()
        {
            ServiceResponseResult responseResult = null;
            SynchronizeService syncService = new SynchronizeService();
            LoginForm.waitHandle.WaitOne();
            ServerConnectionService connection = new ServerConnectionService();
            this.changeStatusLegend("Iniciando la carga...");
            syncService.syncCompany_ServerToLocal();
            //ServiceResponseResult responseResult = connection.getCompaniesFromServer();
            this.changeStatusLegend("Cargando sucursales...");
            responseResult = connection.getSalePointsFromServer();
            this.changeStatusLegend("Cargando roles...");
            responseResult = connection.getSalePointsFromServer();
            this.changeStatusLegend("Cargando usuarios...");
            responseResult = connection.getSalePointsFromServer();
            this.changeStatusLegend(GeneralConstants.EMPTY_STRING);
        }

        private void changeStatusLegend(string plegendText)
        {
            if (this.splashScreen != null)
            {
                this.splashScreen.SetText(plegendText);
            }
        }

        private bool isValidLoginForm(string pUser, string pPassword)
        {
            bool validFields = false;
            if (pUser.Trim() == GeneralConstants.EMPTY_STRING || pPassword.Trim() == GeneralConstants.EMPTY_STRING)
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
            this.txbPass.Text = GeneralConstants.EMPTY_STRING;
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

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (!this.displayLogin)
            {
                this.Dispose();
            }
        }
    }
}
