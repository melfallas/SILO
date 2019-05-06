using SILO.DesktopApplication.Core.Constants;
using SILO.DesktopApplication.Core.Forms.Modules.Sale;
using SILO.DesktopApplication.Core.Integration;
using SILO.DesktopApplication.Core.Model;
using SILO.DesktopApplication.Core.Services;
using SILO.DesktopApplication.Core.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SILO
{
    public partial class ListInstanceForm : Form
    {
        // Atributos de la instancia de lista
        public LPS_LotteryPointSale pointSale { get; set; }
        public LDT_LotteryDrawType drawType { get; set; }
        public DateTime drawDate { get; set; }
        public DateTime printDate { get; set; }
        public MainOptionMenu mainOptionMenu { get; set; }
        public string customerName { get; set; }

        public LTL_LotteryList list { get; set; }
        private LotteryListControl lotteryListControl { get; set; }
        //public List<LND_ListNumberDetail> numberDetail { get; set; }

        public NumberBoxForm numberBoxFormParent { get; set; }
        public ListSelectorForm listSelectorFormParent { get; set; }

        public ApplicationMediator appMediator { get; set; }

        private TicketPrintService ticketPrintService;


        private bool optionMenuEnabled;


        /*  
        public ListInstanceForm()
        {
            initializeComponent();
        }
        */
        public ListInstanceForm(ApplicationMediator pMediator,
        NumberBoxForm pParent, LPS_LotteryPointSale pPointSale, LDT_LotteryDrawType pDrawType, DateTime pDrawDate)
        {
            this.optionMenuEnabled = true;
            this.numberBoxFormParent = pParent;
            this.listSelectorFormParent = null;
            this.pointSale = pPointSale;
            this.drawType = pDrawType;
            this.drawDate = pDrawDate;
            //this.numberDetail = null;
            initializeComponent();
            // Establecer el ApplicationMediator
            this.appMediator = pMediator;
            this.ticketPrintService = new TicketPrintService();
            //this.lotteryListControl.resetCurrentCell();
        }

        public ListInstanceForm(ApplicationMediator pMediator, ListSelectorForm pSelectorForm, LPS_LotteryPointSale pPointSale, 
            LDT_LotteryDrawType pDrawType, DateTime pDrawDate, List<LotteryTuple> pNumberList = null)
        {
            this.optionMenuEnabled = true;
            this.numberBoxFormParent = null;
            this.listSelectorFormParent = pSelectorForm;
            this.pointSale = pPointSale;
            this.drawType = pDrawType;
            this.drawDate = pDrawDate;
            this.initializeComponent();
            // Inicializar el list control si hay una lista asociada
            if (pNumberList != null)
            {
                this.initializeListControl(pNumberList);
            }
            // Establecer el ApplicationMediator
            this.appMediator = pMediator;
            this.ticketPrintService = new TicketPrintService();
            //this.lotteryListControl.resetCurrentCell();
        }

        public void initializeComponent() {
            InitializeComponent();
            this.formatLabels();
            this.addControls();
            //this.listInstanceBottomPanel.Hide();
            this.focusList();
        }

        public void resetCurrentListCell()
        {
            this.lotteryListControl.resetCurrentCell();
        }

        public void formatLabels()
        {
            this.posLabel.Text = this.pointSale.LPS_DisplayName;
            this.groupLabel.Text = this.drawType.LDT_DisplayName;
            this.dateLabel.Text = UtilityService.getLargeDate(this.drawDate);
        }

        public void addControls()
        {
            //LotteryListControl lotteryListControl = new LotteryListControl();
            lotteryListControl = new LotteryListControl();
            lotteryListControl.TabIndex = 0;
            lotteryListControl.Focus();
            //lotteryListControl.resetCurrentCell();
            this.listInstanceMainPanel.Controls.Add(lotteryListControl);
            this.listInstanceMainPanel.Focus();
        }

        public void initializeListControl(List<LotteryTuple> pNumberList)
        {
            this.lotteryListControl.fillList(pNumberList);
        }

        private LotteryListControl getCurrentListControl() {
            LotteryListControl list = null;
            if (this.listInstanceMainPanel.Controls.Count > 0)
            {
                list = this.listInstanceMainPanel.Controls.OfType<LotteryListControl>().First();
            }
            else
            {
                //MessageBox.Show("ERROR: Desplegando la instancia");
            }
            return list;
        }

        public void processList()
        {
            LotteryListControl listControl = this.getCurrentListControl();
            // Validar si la lista tiene datos
            if (listControl.loteryList.tupleList.Count == 0)
            {
                this.setEnabledButtonsAndMenu(true);
                MessageBox.Show("La lista no tiene datos");
                //this.togglePrintListButton();
            }
            else {
                //this.mainOptionMenu.Dispose();
                ListNameForm listNameForm = new ListNameForm(this);
                listNameForm.ShowDialog();
            }
        }

        public void createList()
        {
            this.appMediator.setAppTopMost(true);
            this.setEnabledButtonsAndMenu(false);
            // Cerrar y liberar memoria de formulario de selección si no es nulo
            if (this.listSelectorFormParent != null)
            {
                this.listSelectorFormParent.Dispose();
            }
            // Si existe un option menu abierto, cerrarlo
            if (this.mainOptionMenu != null)
            {
                this.mainOptionMenu.Hide();
            }
            // Guardar la lista de manera local
            LotteryListControl listControl = this.listInstanceMainPanel.Controls.OfType<LotteryListControl>().First();
            List < LND_ListNumberDetail > savedNumberDetailList = this.saveList(listControl);
            // Imprimir solamente si la impresora está habilitada
            if (UtilityService.printerEnabled())
            {
                ticketPrintService.printList(this.list);
            }            
            // ***Actualizar NumberBox si no es nula
            if (this.numberBoxFormParent != null)
            {
                //this.numberBoxFormParent.updateNumberBox(this.drawType.LDT_Id);
            }
            // Sincronizar con el servidor, solamente si los servicios están habilitados
            if (UtilityService.realTimeSyncEnabled())
            {
                this.sendListNumberToServer(savedNumberDetailList);
            }
            // TODO: Cambiar todos los registros de QR a pendiente / Creo que ya no se necesita

            this.Dispose();
            // Actualizar BoxNumber y mostrar en pantalla resultado de la venta
            //this.appMediator.updateBoxNumber(this.drawType.LDT_Id);
            this.appMediator.setBoxNumberGroup(0);
            this.appMediator.displayNumberBox(this.drawDate, this.drawType.LDT_Id, true);
            this.appMediator.setAppTopMost(false);
            // Limpiar y reestablecer el ListControl
            //this.resetFormList();
            //this.focusList();
        }

        private List<LND_ListNumberDetail> saveList(LotteryListControl pListControl)
        {
            LotteryDrawRepository lotteryDrawRepository = new LotteryDrawRepository();
            // Crear y guardar nuevo sorteo
            LTD_LotteryDraw drawToSave = new LTD_LotteryDraw();
            drawToSave.LTD_CreateDate = this.drawDate;
            drawToSave.LDT_LotteryDrawType = this.drawType.LDT_Id;
            drawToSave.LDS_LotteryDrawStatus = SystemConstants.DRAW_STATUS_OPENED;
            lotteryDrawRepository.save(ref drawToSave);
            // Crear y guardar nueva lista
            LTL_LotteryList listToSave = new LTL_LotteryList();
            listToSave.LPS_LotteryPointSale = UtilityService.getPointSale().LPS_Id;
            listToSave.LTD_LotteryDraw = drawToSave.LTD_Id;
            listToSave.LTL_CustomerName = this.customerName;
            this.printDate = DateTime.Now;
            listToSave.LTL_CreateDate = this.printDate;
            listToSave.LLS_LotteryListStatus = SystemConstants.LIST_STATUS_CREATED;
            listToSave.SYS_SynchronyStatus = SystemConstants.SYNC_STATUS_PENDING_TO_SERVER;
            lotteryDrawRepository.saveList(ref listToSave);
            this.list = listToSave;
            // Crear colección y guardar a nivel local detalle de números de la lista
            List<LND_ListNumberDetail> numberDetailCollection = new List<LND_ListNumberDetail>();
            LotteryNumberRepository numberRepository = new LotteryNumberRepository();
            foreach (var register in pListControl.loteryList.tupleList)
            {
                LND_ListNumberDetail newListNumberDetail = new LND_ListNumberDetail();
                newListNumberDetail.LTL_LotteryList = listToSave.LTL_Id;
                newListNumberDetail.LND_Id = register.Key;
                newListNumberDetail.LNR_LotteryNumber = numberRepository.getByNumberCode(register.Value.number).LNR_Id;
                newListNumberDetail.LND_SaleImport = register.Value.import;
                lotteryDrawRepository.saveListDetail(ref newListNumberDetail);
                numberDetailCollection.Add(newListNumberDetail);
            }
            // Almacenar la colección de números generada
            //this.numberDetail = numberDetailCollection;
            return numberDetailCollection;
        }

        private async void sendListNumberToServer(List<LND_ListNumberDetail> pNumberDetail)
        {
            SynchronizeService syncService = new SynchronizeService();
            syncService.appMediator = this.appMediator;
            //syncService.sendListNumberToServer(this.list, pNumberDetail);
            await syncService.sendListNumberToServerAsync(this.list, pNumberDetail);
        }

        private void setActiveButton(Button pButton, bool pEnabled) {
            pButton.Enabled = pEnabled;
        }
        
        private void processMenuRequest(/*KeyEventArgs pEvent*/)
        {
            // Actualizar la estructura de lista antes de desplegar menú de opciones
            LotteryListControl listControl = this.getCurrentListControl();
            if (listControl != null)
            {
                listControl.getList().EndEdit();
                if (this.mainOptionMenu != null)
                {
                    this.mainOptionMenu.Dispose();
                }
                // Desplegar menú de opciones
                this.mainOptionMenu = new MainOptionMenu(this.appMediator, this);
                mainOptionMenu.ShowDialog(this);
                //pEvent.SuppressKeyPress = true;
            }
        }

        private void clearList()
        {
            this.lotteryListControl.clearList();
        }

        private void focusList()
        {
            this.listInstanceMainPanel.Focus();
            LotteryListControl listControl = this.getCurrentListControl();
            if (listControl != null)
            {
                listControl.Focus();
            }
        }

        private void resetFormList()
        {
            //this.numberDetail = null;
            this.setEnabledButtonsAndMenu(true);
            this.clearList();
            this.focusList();
        }

        private void setEnabledButtonsAndMenu(bool pActivate)
        {
            this.optionMenuEnabled = pActivate;
            this.setActiveButton(this.printListButton, pActivate);
            this.setActiveButton(this.eraseListButton, pActivate);
        }

        //--------------------------------------- Eventos de Controles --------------------------------------//
        #region Eventos de Controles

        private void printListButton_Click(object sender, EventArgs e)
        {
            DialogResult msgResult =
                    MessageService.displayConfirmWarningMessage(
                            "¿Está seguro que quiere imprimir la lista?",
                            "IMPRIMIENDO..."
                            );
            // Procesar el resultado de la confirmación
            switch (msgResult)
            {
                case DialogResult.Yes:
                    // Procesar la impresión
                    this.setEnabledButtonsAndMenu(false);
                    this.processList();
                    this.resetFormList();
                    break;
                case DialogResult.No:
                    break;
                default:
                    break;
            }
            this.focusList();
        }

        private void eraseListButton_Click(object sender, EventArgs e)
        {
            DialogResult msgResult =
                    MessageService.displayConfirmWarningMessage(
                            "¿Está seguro que quiere limpiar la lista?",
                            "LIMPIANDO LISTA..."
                            );
            // Procesar el resultado de la confirmación
            switch (msgResult)
            {
                case DialogResult.Yes:
                    // Procesar el limpiado
                    this.clearList();
                    break;
                case DialogResult.No:
                    break;
                default:
                    break;
            }
            this.focusList();
        }

        private void ListInstanceForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Multiply:
                    if (this.optionMenuEnabled)
                    {
                        this.processMenuRequest();
                    }
                    break;
                case Keys.Escape:
                    this.appMediator.setAppTopMost(true);
                    //this.appMediator.setBoxNumberGroup(0);
                    this.Dispose();
                    this.appMediator.setAppTopMost(false);
                    break;
                default:
                    break;
            }
        }

        private void ListInstanceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.appMediator.setBoxNumberGroup(0);
            if (this.listSelectorFormParent != null)
            {
                this.listSelectorFormParent.Dispose();
            }
        }
        #endregion
        
    }
}
