using Newtonsoft.Json.Linq;
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

        private int activeFormType = -1;

        public ApplicationForm(Form pParentForm)
        {
            InitializeComponent();
            this.parentForm = pParentForm;
            this.initializeControls();
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

        private void initializeControls() {
            // Deshabiliar controles de estado de sincronización
            this.syncStatusLabel.Text = "";
            this.displaySyncStatusComponents(false);
            // Mostrar propiedades del sistema
            this.userContentLabel.Text = SystemSession.username;
            this.posContentLabel.Text = SystemSession.salePoint;
            this.companyContentLabel.Text = SystemSession.company;
            // Habilitar la sincronización periódica si está activa
            if (ParameterService.isSyncEnabled())
            {
                this.syncTimer.Interval = ParameterService.getSyncInterval();
                this.syncTimer.Enabled = true;
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

        public void closeTransactions(int pSyncType, DateTime? pDrawDate = null, long pDrawType = 0)
        {
            this.processParallelSynchronization(pDrawDate, pDrawType, pSyncType);
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
            MessageBox.Show($"Aplicación de Prueba. Version: {version} ");
            
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
            PrinterParamsForm printerParamsForm = new PrinterParamsForm();
            printerParamsForm.Show();
        }

        private void enviarAlServidorToolStripMenuItem_Click(object sender, EventArgs e)
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
                    this.processParallelSynchronization();
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
            this.processPeridicSynchronization(FormatService.formatDrawDate(DateTime.Today));
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
            if (ParameterService.isSyncEnabled())
            {
                // Tareas previas a la sincronización
                Console.WriteLine("Inicia SyncPeriodica: " + DateTime.Now.ToString("HH:mm:ss"));
                this.setSyncStatusText(LabelConstants.SYNC_PENDING_TRANSACTIONS_LABEL_TEXT);
                this.displaySyncStatusComponents(true);
                // Invocar la sincronización
                SynchronizeService service = new SynchronizeService();
                await service.syncPendingListNumberToServerAsync(pDrawDate, pDrawType);
                // Tareas posteriores a la sincronización
                this.mediator.updateTotalBoxes();
                this.setSyncStatusText(LabelConstants.COMPLETED_SYNC_TRANSACTIONS_LABEL_TEXT);
                this.displaySyncStatusComponents(false);
                Console.WriteLine("Finaliza SyncPeriodica: " + DateTime.Now.ToString("HH:mm:ss"));
            }
        }

        private async void processParallelSynchronization(DateTime? pDrawDate = null, long pDrawType = 0, int pSyncType = 0)
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
        }

        private void processLinearSynchronization() {
            LoadingForm loading = new LoadingForm();
            loading.Show(this);
            SynchronizeService service = new SynchronizeService();
            service.syncPendingListNumberToServer();
            loading.Dispose();
            MessageService.displayInfoMessage("La sincronización ha finalizado");
        }
        
    }
}
