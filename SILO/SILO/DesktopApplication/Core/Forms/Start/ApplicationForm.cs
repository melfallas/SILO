﻿using Newtonsoft.Json.Linq;
using SILO.DesktopApplication.Core.Constants;
using SILO.DesktopApplication.Core.Forms.Modules.Closing;
using SILO.DesktopApplication.Core.Forms.Modules.List;
using SILO.DesktopApplication.Core.Forms.Modules.ModuleForm;
using SILO.DesktopApplication.Core.Forms.Modules.Number;
using SILO.DesktopApplication.Core.Forms.Modules.Parameters;
using SILO.DesktopApplication.Core.Forms.Modules.Sale;
using SILO.DesktopApplication.Core.Forms.UX;
using SILO.DesktopApplication.Core.Integration;
using SILO.DesktopApplication.Core.Services;
using SILO.DesktopApplication.Core.SystemConfig;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SILO.DesktopApplication.Core.Forms.Start
{
    public partial class ApplicationForm : Form
    {
        private ApplicationMediator mediator;        
        public Form parentForm { get; set; }
        public MainOptionMenu mainOptionMenu { get; set; }

        private DateTime? lastSyncTick;

        private int activeFormType = -1;

        public ApplicationForm(Form pParentForm)
        {
            this.lastSyncTick = null;
            InitializeComponent();
            this.parentForm = pParentForm;
            this.initializeControls();
            this.hidePanels();
            this.hideToolStripMenuItems();
            // Crear el objeto mediador para los distintos componentes
            mediator = new ApplicationMediator();
            mediator.appForm = this;
            //this.printMenuButton.BackColor = Color.FromArgb(12, 61, 92);
        }

        public ApplicationMediator getMediator
        {
            get
            {
                return this.mediator;
            }
        }

        public void setApplicationFocus()
        {
            this.saleMenuButton.Focus();
        }

        public void hidePanels()
        {
            this.topAppPanel.Hide();
        }

        public void hideToolStripMenuItems()
        {
            if (SystemSession.sessionUser != null && SystemSession.sessionUser.USR_UserRole != SystemConstants.ROLE_SA_ID)
            {
                this.topAppPanel.Hide();
                string firstMenuItemName = "configuraciónToolStripMenuItem";
                string secondMenuItemName = "parámetrosDeSistemaToolStripMenuItem";
                string thirdMenuItemName = "dispositivosToolStripMenuItem";
                ToolStripMenuItem firstMenuItem = this.mainMenu.Items[firstMenuItemName] as ToolStripMenuItem;
                ToolStripDropDownItem secondMenuItem = firstMenuItem.DropDownItems[secondMenuItemName] as ToolStripDropDownItem;
                ToolStripMenuItem thirdMenuItem = secondMenuItem.DropDownItems[thirdMenuItemName] as ToolStripMenuItem;
                thirdMenuItem.Visible = false;
            }
        }

        private void initializeControls() {
            // Deshabiliar controles de estado de sincronización            
            this.syncStatusLabel.Text = "";
            this.displaySyncStatusComponents(false);
            // Mostrar propiedades del sistema
            this.clearDrawInfoLabels();
            String version = UtilityService.getApplicationSimpleVersion();
            this.softwareVersionLabel.Text = $"v {version} ";
            this.versionFooterLabel.Text = $"v {version} ";
            this.userContentLabel.Text = SystemSession.username;
            this.posContentLabel.Text = SystemSession.salePoint;
            this.companyContentLabel.Text = SystemSession.company;
            this.servicePathLabel.Text = ServiceConectionConstants.getServiceApiEndPoint();
            // Habilitar la sincronización periódica si está activa
            this.enablePeriodSync();
        }

        public void enablePeriodSync()
        {
            this.syncTimer.Stop();
            this.syncTimer.Enabled = false;
            if (ParameterService.isPeriodSyncEnabled())
            {
                this.syncTimer.Interval = ParameterService.getPeriodSyncInterval();
                this.syncTimer.Enabled = true;
                this.lastSyncTick = DateTime.Now;
                this.syncTimer.Start();
            }
            else {
                this.timeToSyncLabel.Text = "Sincronización desactivada";
            }
        }

        private void setTimeToSyncLabel()
        {
            int syncTimerSeconds = (int) this.getSyncTimeSpam().TotalSeconds;
            int timeToSync = ParameterService.getPeriodSyncInterval() / 1000 - syncTimerSeconds;
            if (ParameterService.isPeriodSyncEnabled())
            {
                //this.timeToSyncLabel.Text = syncTimerSeconds == 0 ? "" : "Sincronización en: " +  timeToSync;
                this.timeToSyncLabel.Text = syncTimerSeconds == 0 ? "" : "Sincronización en: " + FormatService.formatSecondsToMinutes(timeToSync);

            }
            else
            {
                this.timeToSyncLabel.Text = "Sincronización desactivada";
            }
        }

        public void clearDrawInfoLabels()
        {
            this.setPosNameLabel("");
            this.setDrawTitleLabel("");
            this.setGroupNameLabel("");
            this.setDayDrawLabel("");
            this.setDateDrawLabel("");
            this.setPayDrawTitleLabel("");
            this.setPrizeFactorDrawLabel("");
        }

        public void fillDrawInfoLabels(DateTime pDrawDate, long pGroupId)
        {
            
            this.clearDrawInfoLabels();
            if (pGroupId != 0)
            {
                DrawTypeService drawTypeService = new DrawTypeService();
                LDT_LotteryDrawType drawType = drawTypeService.getById(pGroupId);
                if (drawType != null)
                {
                    this.setPosNameLabel(ParameterService.getSystemSalePoint().LPS_DisplayName);
                    this.setDrawTitleLabel("Sorteo:");
                    this.setGroupNameLabel(drawType.LDT_DisplayName);
                    this.setDayDrawLabel(UtilityService.getDayName(pDrawDate));
                    this.setDateDrawLabel(UtilityService.getSimpleDate(pDrawDate));
                }
                PrizeFactorService prizeFactorService = new PrizeFactorService();
                LPF_LotteryPrizeFactor prizeFactor = prizeFactorService.getByPointSaleAndGroup(ParameterService.getSalePointId(), pGroupId);
                if (prizeFactor != null)
                {
                    string prizes = Convert.ToInt32(prizeFactor.LPF_FirtsPrizeFactor) + "% | "
                        + Convert.ToInt32(prizeFactor.LPF_SecondPrizeFactor) + "% | "
                        + Convert.ToInt32(prizeFactor.LPF_ThirdPrizeFactor) + "%"
                        ;
                    this.setPayDrawTitleLabel("Paga:");
                    this.setPrizeFactorDrawLabel(prizes);
                }
            }
            
        }

        // Eventos para setear etiquetas desde otro hilo
        public void setPosNameLabel(string pText)
        {
            this.setLabelWithThread(this.posNameLabel, pText);
        }

        public void setDrawTitleLabel(string pText)
        {
            this.setLabelWithThread(this.drawTitleLabel, pText);
        }

        public void setGroupNameLabel(string pText)
        {
            this.setLabelWithThread(this.groupNameLabel, pText);
        }

        public void setDayDrawLabel(string pText)
        {
            this.setLabelWithThread(this.dayDrawLabel, pText);
        }

        public void setDateDrawLabel(string pText)
        {
            this.setLabelWithThread(this.dateDrawLabel, pText);
        }

        public void setPayDrawTitleLabel(string pText)
        {
            this.setLabelWithThread(this.payDrawTitleLabel, pText);
        }

        public void setPrizeFactorDrawLabel(string pText)
        {
            this.setLabelWithThread(this.prizeFactorDrawLabel, pText);
        }

        // Evento para setear un Label desde otro hilo
        public void setLabelWithThread(Label pLabel, string pText)
        {
            if (pLabel.InvokeRequired)
            {
                pLabel.BeginInvoke(new MethodInvoker(delegate {
                    pLabel.Text = pText;
                }));
            }
            else
            {
                pLabel.Text = pText;
            }
        }

        public void setSyncStatusText(string pStatusText)
        {
            this.syncStatusLabel.Text = pStatusText;
            if (pStatusText == LabelConstants.COMPLETED_SYNC_TRANSACTIONS_LABEL_TEXT)
            {
                this.syncStatusProgressBar.Style = ProgressBarStyle.Blocks;
                this.syncStatusProgressBar.Value = 100;
            }
        }

        private void displaySyncStatusComponents(bool pNeedDisplay)
        {
            if (pNeedDisplay)
            {
                this.syncStatusProgressBar.Value = 20;
                this.syncStatusProgressBar.Style = ProgressBarStyle.Marquee;
                this.syncStatusLabel.Show();
                this.syncStatusProgressBar.Show();
            }
            else
            {
                this.syncStatusLabel.Hide();
                this.syncStatusProgressBar.Hide();
            }
        }

        public void showFormInMainPanel(MainModuleForm pForm, DateTime? pDrawDate = null, long pGroupId = 0, bool pUpdateBox=false)
        {
            MainModuleForm existingForm = getExistingForm(pForm);
            // Validar si existe o no el formulario
            if (existingForm == null)
            {
                this.centerBoxPanel.Hide();
                // Agregar BoxNumber al AppMediator
                if (pForm.type == SystemConstants.NUMBER_BOX_CODE)
                {
                    this.mediator.appNumberBox = (NumberBoxForm) pForm;
                }
                // Agregar a la aplicación el nuevo formulario si no existe
                MainModuleForm formToAdd = pForm as MainModuleForm;
                formToAdd.TopLevel = false;
                formToAdd.Dock = DockStyle.Fill;
                this.centerBoxPanel.Controls.Add(formToAdd);
                this.centerBoxPanel.Tag = formToAdd;
                formToAdd.Show();
                formToAdd.BringToFront();
                this.mediator.updateBoxNumber(0, DateTime.Today);
                this.centerBoxPanel.Show();
            }
            else
            {
                // Destruir el formulario nuevo y mostrar el existente
                pForm.Dispose();
                if (this.activeFormType != existingForm.type || pUpdateBox)
                //if(true)
                {
                    this.centerBoxPanel.Hide();
                    existingForm.BringToFront();
                    // Si se trae al frente un NumberBoxForm, se debe actualizar
                    if (existingForm.type == SystemConstants.NUMBER_BOX_CODE)
                    {
                        NumberBoxForm numberBox = (NumberBoxForm)existingForm;
                        numberBox.updateNumberBox(pDrawDate, pGroupId);
                    }
                    else
                    {
                        this.mediator.updateBoxNumber(0, DateTime.Today);
                    }
                    this.centerBoxPanel.Show();
                }
            }
            this.activeFormType = pForm.type;
        }

        private MainModuleForm getExistingForm(MainModuleForm pForm) {
            MainModuleForm existingForm = null;
            // Iterar por los controles, obteniendo el formulario si existe
            foreach (Control control in this.centerBoxPanel.Controls)
            {
                MainModuleForm currentForm = control as MainModuleForm;
                int formType = currentForm.type;
                // Hacer match de los tipos de formulario
                if (formType == pForm.type)
                {
                    existingForm = currentForm;
                }
            }
            return existingForm;
        }

        private void showDisplayListForm(int pCode) {
            DisplayListForm displayListForm = new DisplayListForm(this.mediator, pCode);
            this.showFormInMainPanel(displayListForm);
        }

        private void displayCloseSelector()
        {
            ClosingSelectorForm closingForm = new ClosingSelectorForm(this.mediator);
            closingForm.ShowDialog(this);
        }

        public async void closeTransactions(int pSyncType, DateTime? pDrawDate = null, long pDrawType = 0)
        {
            bool syncResult = await this.processParallelSynchronization(pDrawDate, pDrawType, pSyncType);
            if (syncResult)
            {
                if (pDrawDate != null && pDrawType != 0)
                {
                    DrawService drawService = new DrawService();
                    drawService.changeDrawStatus(pDrawType, pDrawDate, SystemConstants.DRAW_STATUS_CLOSED);
                    MessageService.displayInfoMessage(
                    "El sorteo fue cerrado de manera exitosa",
                    "CIERRE COMPLETADO"
                    );
                }
            }
        }

        private void processMenuRequest(/*KeyEventArgs pEvent*/)
        {
            // Validar si existe menú de opciones            
            if (this.mainOptionMenu != null)
            {
                this.mainOptionMenu.Dispose();
            }
            // Desplegar menú de opciones
            this.mainOptionMenu = new MainOptionMenu(this.mediator);
            this.mainOptionMenu.ShowDialog(this);
        }




        //--------------------------------------- Botones de Menú Lateral --------------------------------------//
        #region Botones de Menú Lateral

        public void showBoxNumber()
        {
            this.showFormInMainPanel(new NumberBoxForm(this.mediator));
        }

        private void saleMenuButton_Click(object sender, EventArgs e)
        {
            this.showBoxNumber();
        }

        private void copyListButton_Click(object sender, EventArgs e)
        {
            this.showDisplayListForm(SystemConstants.COPY_LIST_CODE);
        }

        private void printMenuButton_Click(object sender, EventArgs e)
        {
            this.showDisplayListForm(SystemConstants.PRINTER_LIST_CODE);
        }

        private void eraseButton_Click(object sender, EventArgs e)
        {
            this.showDisplayListForm(SystemConstants.ERASER_LIST_CODE);
        }

        private void displayQRMenuButton_Click(object sender, EventArgs e)
        {
            this.showDisplayListForm(SystemConstants.DISPLAY_QR_CODE);
        }

        private void closeDrawMenuButton_Click(object sender, EventArgs e)
        {
            this.displayCloseSelector();
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            /*
            ServerConnectionService serverConnection = new ServerConnectionService();
            Object result = serverConnection.synchronizeDrawAssociation().result;
            Console.WriteLine(result);
            JObject jsonObject = JObject.FromObject(result);
            Console.WriteLine(jsonObject);
            string createDate = (string) jsonObject["createDate"];
            Console.WriteLine(createDate);
            JObject draw = (JObject) jsonObject["lotteryDraw"];
            Console.WriteLine(draw);
            */

            /*
            DisplayQRForm qrForm = new DisplayQRForm();
            qrForm.Show();
            */

            String version = UtilityService.getApplicationVersion();
            String serviceUrl = ServiceConectionConstants.getServiceApiEndPoint();
            MessageBox.Show($"SILO Application. Version: {version}\n\nServicio: {serviceUrl}");
            
        }
        #endregion

        //--------------------------------------- Acciones de Menú --------------------------------------//
        #region Acciones de Menú
        private void ventaDePapelesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.showFormInMainPanel(new NumberBoxForm(this.mediator));
        }

        private void prohibidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProhibitedNumberForm prohibitedForm = new ProhibitedNumberForm(this.mediator);
            prohibitedForm.ShowDialog();
        }

        private void ingresarGanadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawNumberWinningForm winningForm = new DrawNumberWinningForm(this.mediator);
            winningForm.ShowDialog();
        }

        private void parámetrosDeImpresiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrinterParamsForm printerParamsForm = new PrinterParamsForm(this.mediator);
            printerParamsForm.ShowDialog();
        }

        private void servidorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServerParamForm serverParamsForm = new ServerParamForm(this.mediator);
            serverParamsForm.ShowDialog();
        }

        private void localesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SyncParamForm serverParamsForm = new SyncParamForm(this.mediator);
            serverParamsForm.ShowDialog();
        }

        private void dispositivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeviceParamsForm deviceForm = new DeviceParamsForm();
            deviceForm.Show();
        }

        private void sincronizaciónDeEmergenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.displayCloseSelector();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String version = UtilityService.getApplicationVersion();
            String serviceUrl = ServiceConectionConstants.getServiceApiEndPoint();
            MessageBox.Show($"SILO Application. Version: {version}\n\nServicio: {serviceUrl}");
        }

        private async void enviarAlServidorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult msgResult =
                    MessageService.displayConfirmWarningMessage(
                            "¿Está seguro desea realizar sincronización con el servidor?",
                            "SINCRONIZANDO TRANSACCIONES AL SERVIDOR..."
                            );
            // Procesar el resultado de la confirmación
            switch (msgResult)
            {
                case DialogResult.Yes:
                    // Procesar la sincronización
                    //this.processLinearSynchronization();
                    await this.processParallelSynchronization(FormatService.formatDrawDate(DateTime.Today));
                    break;
                case DialogResult.No:
                    break;
                default:
                    break;
            }
        }

        private void ApplicationForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Multiply:
                    //if (this.optionMenuEnabled)
                    if (true)
                    {
                        this.processMenuRequest();
                    }
                    break;
                case Keys.Escape:

                    break;
                default:
                    break;
            }
        }

        private void syncTimer_Tick(object sender, EventArgs e)
        {
            //Console.WriteLine("Tick: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            this.lastSyncTick = DateTime.Now;
            this.processPeridicSynchronization(FormatService.formatDrawDate(DateTime.Today));
        }

        private void threadCounterTimer_Tick(object sender, EventArgs e)
        {
            this.setTimeToSyncLabel();
            this.threadCounterLabel.Text = "Hilos: " + UtilityService.getThreadCounter();
        }

        private TimeSpan getSyncTimeSpam()
        {
            return this.lastSyncTick == null ? TimeSpan.Zero : DateTime.Now - (DateTime) this.lastSyncTick;
        }

        private void salirDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        //--------------------------------------- Otros Eventos --------------------------------------//
        #region Otros Eventos
        private void ApplicationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.parentForm.Dispose();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        #endregion
        
        private async void processPeridicSynchronization(DateTime? pDrawDate = null, long pDrawType = 0)
        {
            // Lanzar sincronización periódica solamente si está activa
            if (ParameterService.isPeriodSyncEnabled())
            {
                // Tareas previas a la sincronización
                Console.WriteLine("Inicia SyncPeriodica: " + DateTime.Now.ToString("HH:mm:ss"));
                this.setSyncStatusText(LabelConstants.SYNC_PENDING_TRANSACTIONS_LABEL_TEXT);
                this.displaySyncStatusComponents(true);
                // Invocar la sincronización
                SynchronizeService service = new SynchronizeService();
                await Task.Run(() => service.syncPendingListNumberToServerAsync(pDrawDate, pDrawType));
                //await service.syncPendingListNumberToServerAsync(pDrawDate, pDrawType);
                // Tareas posteriores a la sincronización
                this.mediator.updateTotalBoxes();
                this.setSyncStatusText(LabelConstants.COMPLETED_SYNC_TRANSACTIONS_LABEL_TEXT);
                this.displaySyncStatusComponents(false);
                Console.WriteLine("Finaliza SyncPeriodica: " + DateTime.Now.ToString("HH:mm:ss"));
            }
        }

        private async Task<bool> processParallelSynchronization(DateTime? pDrawDate = null, long pDrawType = 0, int pSyncType = 0)
        {
            this.setSyncStatusText(LabelConstants.SYNC_PENDING_TRANSACTIONS_LABEL_TEXT);
            this.displaySyncStatusComponents(true);
            LoadingForm loading = new LoadingForm();
            loading.Show(this);
            SynchronizeService service = new SynchronizeService();
            bool syncResult = await service.syncPendingListNumberToServerAsync(pDrawDate, pDrawType);
            this.setSyncStatusText(LabelConstants.COMPLETED_SYNC_TRANSACTIONS_LABEL_TEXT);
            loading.Dispose();
            if (syncResult)
            {
                MessageService.displayInfoMessage("La sincronización ha finalizado de manera exitosa", "RESULTADO DE LA SINCRONIZACIÓN");
            }
            else
            {
                MessageService.displayErrorMessage("No fue posible realizar la sincronización.\nPor favor intente más tarde.", "RESULTADO DE LA SINCRONIZACIÓN");
            }
            this.displaySyncStatusComponents(false);
            return syncResult;
        }

        private void processLinearSynchronization() {
            LoadingForm loading = new LoadingForm();
            loading.Show(this);
            SynchronizeService service = new SynchronizeService();
            service.syncPendingListNumberToServer();
            loading.Dispose();
            MessageService.displayInfoMessage("La sincronización ha finalizado");
        }

        private void enterWinnersMenuButton_Click(object sender, EventArgs e)
        {
            DrawNumberWinningForm winningForm = new DrawNumberWinningForm(this.mediator);
            winningForm.ShowDialog();
        }
        
    }
}
