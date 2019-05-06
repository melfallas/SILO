﻿using SILO.Core.Constants;
using SILO.DesktopApplication.Core.Constants;
using SILO.DesktopApplication.Core.Forms.Start;
using SILO.DesktopApplication.Core.Model;
using SILO.DesktopApplication.Core.Repositories;
using SILO.DesktopApplication.Core.Services;
using SILO.DesktopApplication.Core.SystemConfig;
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
            this.posNameLabel.Text = "";
            this.showSalePointName();
            this.versionLabel.Text = UtilityService.getApplicationVersion();
        }

        private void showSalePointName()
        {
            LPS_LotteryPointSale posInstance = ParameterService.getSystemSalePoint();
            if (posInstance != null)
            {
                this.posNameLabel.Text = "SUCURSAL " + posInstance.LPS_DisplayName;
            }
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
                // Guardar en sesión la compañía
                CompanyRepository companyRepository = new CompanyRepository();
                SystemSession.sessionCompany = companyRepository.getById(long.Parse(companyId));
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

            //bool[] synStatusArray = new bool[4];
            bool[] synStatusArray = new bool[6];
            LoginForm.waitHandle.WaitOne();
            this.updateProgressBar(25);
            this.changeStatusLegend("Iniciando la carga...");
            SynchronizeService syncService = new SynchronizeService();
            
            synStatusArray[0] = syncService.syncCompany_ServerToLocal();
            this.updateProgressBar(40);
            this.changeStatusLegend("Cargando sucursales...");
            synStatusArray[1] = syncService.syncSalePoint_ServerToLocal();
            this.updateProgressBar(75);
            this.changeStatusLegend("Cargando roles...");
            synStatusArray[2] = syncService.syncRole_ServerToLocal();
            this.updateProgressBar(80);
            this.changeStatusLegend("Cargando usuarios...");
            synStatusArray[3] = syncService.syncAppUsers_ServerToLocal();
            this.updateProgressBar(90);
            this.changeStatusLegend("Cargando factores de premio...");
            synStatusArray[4] = syncService.syncPrizeFactor_ServerToLocal();
            this.changeStatusLegend("Cargando sorteos re-abiertos...");
            synStatusArray[5] = syncService.syncDraw_ServerToLocal();
            this.updateProgressBar(100);
            this.changeStatusLegend(GeneralConstants.EMPTY_STRING);
            // Verificar si falló algún proceso de sincronización
            this.verifySynStatus(synStatusArray);
            
        }

        private void updateProgressBar(int pProgressValue)
        {
            if (this.splashScreen != null)
            {
                this.splashScreen.updateProgressBar(pProgressValue);
            }
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

        private int requestUserAuthetication(string pUser, string pPassword)
        {
            LoginService loginService = new LoginService();
            return loginService.doLogin(pUser.Trim(), pPassword.Trim());
        }

        private void cleanFields()
        {
            this.txbPass.Text = GeneralConstants.EMPTY_STRING;
            this.txbUser.Text = this.txbUser.Text.Trim();
            this.txbUser.Focus();
        }

        private void notifySyncProcessStep(string pMessage)
        {
            Console.WriteLine(pMessage);
        }

        private void verifySynStatus(bool[] pSynStatusArray)
        {
            if (!UtilityService.verifySynStatusFromArray(pSynStatusArray))
            {
                MessageService.displayErrorMessage(GeneralConstants.INITIAL_SYNCHRONIZATION_ERROR, GeneralConstants.INITIAL_SYNCHRONIZATION_TITLE);
                //MessageService.displayErrorMessage(GeneralConstants.INITIAL_SYNCHRONIZATION_ERROR, GeneralConstants.INITIAL_SYNCHRONIZATION_TITLE, this.splashScreen.getForm());
            }
        }

        private void initDataSync()
        {
            bool[] synStatusArray = new bool[2];
            this.notifySyncProcessStep("Iniciando sincronización del sistema...");
            SynchronizeService syncService = new SynchronizeService();
            // Sincronizar usuarios al servidor
            //synStatusArray[0] = syncService.syncAppUsers_LocalToServer();
            // Enviar sincronización de números al servidor
            this.notifySyncProcessStep("Sincronizando datos numéricos...");
            synStatusArray[0] = syncService.syncNumbers_LocalToServer();
            this.notifySyncProcessStep("Sincronizando tipos de sorteo...");
            synStatusArray[1] = syncService.syncDrawType_LocalToServer();

            // Verificar si falló algún proceso de sincronización
            this.verifySynStatus(synStatusArray);
            // Lanzar aplicación tras la sincronización
            this.launchApplication();
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

        private void validateLogin()
        {
            if (!this.isValidLoginForm(this.txbUser.Text, this.txbPass.Text))
            {
                this.cleanFields();
            }
            else
            {
                // Realizar autenticación del usuario
                int authResult = this.requestUserAuthetication(this.txbUser.Text, this.txbPass.Text);
                if (authResult == SystemConstants.LOGIN_FAIL)
                {
                    // Mensaje de error para credenciales inválidas
                    MessageService.displayErrorMessage(
                            GeneralConstants.BAD_USER_OR_PASS_ERROR,
                            GeneralConstants.BAD_USER_OR_PASS_TITLE
                            );
                    this.cleanFields();
                }
                else
                {
                    // Validar si la autenticación fue exitosa
                    if (authResult == SystemConstants.LOGIN_SUCCESS)
                    {
                        // Si la autenticación es exitosa, probar la inicialización de la instancia
                        ProgramInitializationService programInicializer = new ProgramInitializationService();
                        if (programInicializer.setInstancePointSale())
                        {
                            // Iniciar sincronización de datos
                            this.initDataSync();
                        }
                        else
                        {
                            // Si la instancia no está inicializada, volver al inicio
                            this.cleanFields();
                        }
                    }
                    else
                    {
                        this.cleanFields();
                    }
                }
            }
        }


        //--------------------------------------- Eventos de controles principales --------------------------------------//

        // Acción que controla el evento de Login al Ingresar
        private void loginButton_Click(object sender, EventArgs e)
        {
            this.validateLogin();
        }
        // Acción que controla el evento de Login al Ingresar
        private void txbPass_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    this.validateLogin();
                    break;
                default:
                    break;
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

        private void txbUser_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    txbPass.Focus();
                    break;
                default:
                    break;
            }
        }
    }
}
