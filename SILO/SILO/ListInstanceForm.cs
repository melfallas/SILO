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
        public LTL_LotteryList list { get; set; }
        public MainOptionMenu mainOptionMenu { get; set; }
        public string customerName { get; set; }

        /*  
        public ListInstanceForm()
        {
            initializeComponent();
        }
        */
        public ListInstanceForm(LPS_LotteryPointSale pPointSale, LDT_LotteryDrawType pDrawType, DateTime pDrawDate)
        {
            this.pointSale = pPointSale;
            this.drawType = pDrawType;
            this.drawDate = pDrawDate;
            initializeComponent();
        }

        public void initializeComponent() {
            InitializeComponent();
            this.formatLabels();
            this.addControls();
            this.listInstanceBottomPanel.Hide();
        }


        public void formatLabels()
        {
            this.posLabel.Text = pointSale.LPS_DisplayName;
            this.groupLabel.Text = drawType.LDT_DisplayName;
        }

        public void addControls()
        {
            LotteryListControl lotteryListControl = new LotteryListControl();
            lotteryListControl.TabIndex = 0;
            lotteryListControl.Focus();
            this.listInstanceMainPanel.Controls.Add(lotteryListControl);
            this.listInstanceMainPanel.Focus();
        }


        private void ListInstanceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        public void processList()
        {
            LotteryListControl listControl = this.listInstanceMainPanel.Controls.OfType<LotteryListControl>().First();
            // Validar si la lista tiene datos
            if (listControl.loteryList.tupleList.Count == 0)
            {
                MessageBox.Show("La lista no tiene datos");
                //this.togglePrintListButton();
            }
            else {
                //this.mainOptionMenu.Dispose();
                ListNameForm listNameForm = new ListNameForm(this);
                listNameForm.Show();
            }
        }

        public void createList()
        {
            LotteryListControl listControl = this.listInstanceMainPanel.Controls.OfType<LotteryListControl>().First();
            this.saveList(listControl);
            this.printList(this.list);
            this.Dispose();
        }


        private void saveList(LotteryListControl pListControl)
        {
            //LTD_LotteryDraw newDraw = LTD_LotteryDraw.
            LotteryDrawRepository lotteryDrawRepository = new LotteryDrawRepository();
            // Crear y guardar nuevo sorteo
            LTD_LotteryDraw drawToSave = new LTD_LotteryDraw();
            drawToSave.LTD_CreateDate = this.drawDate;
            drawToSave.LDT_LotteryDrawType = this.drawType.LDT_Id;
            drawToSave.LTD_Status = 2;
            lotteryDrawRepository.save(ref drawToSave);
            // Crear y guardar nueva lista
            LTL_LotteryList listToSave = new LTL_LotteryList();
            listToSave.LPS_LotteryPointSale = UtilityService.getPointSale().LPS_Id;
            listToSave.LTD_LotteryDraw = drawToSave.LTD_Id;
            listToSave.LTL_CustomerName = this.customerName;
            this.printDate = DateTime.Now;
            listToSave.LTL_CreateDate = this.printDate;
            lotteryDrawRepository.saveList(ref listToSave);
            this.list = listToSave;
            LotteryNumberRepository numberRepository = new LotteryNumberRepository();
            foreach (var register in pListControl.loteryList.tupleList)
            {
                LND_ListNumberDetail newListNumberDetail = new LND_ListNumberDetail();
                newListNumberDetail.LTL_LotteryList = listToSave.LTL_Id;
                newListNumberDetail.LND_Id = register.Key;
                newListNumberDetail.LNR_LotteryNumber = numberRepository.getByNumberCode(register.Value.number).LNR_Id;
                newListNumberDetail.LND_Import = register.Value.import;
                lotteryDrawRepository.saveListDetail(ref newListNumberDetail);
            }
        }

        private void printList(LTL_LotteryList pNumberList)
        {
            // Configurar impresión para Ticket de Venta
            TicketPrinter ticketPrinter = new TicketPrinter();
            SaleTicket saleTicket = new SaleTicket();
            saleTicket.companyName = UtilityService.getCompanyName();
            // Obtener datos del punto de venta
            LPS_LotteryPointSale pointSale = UtilityService.getPointSale();
            saleTicket.pointSaleName = pointSale.LPS_DisplayName;
            // Obtener datos del sorteo
            LotteryDrawRepository drawRepo = new LotteryDrawRepository();
            LTD_LotteryDraw drawObject = drawRepo.getById(pNumberList.LTD_LotteryDraw);
            saleTicket.drawDate = drawObject.LTD_CreateDate;
            // Obtener datos de tipo de sorteo
            LotteryDrawTypeRepository drawTypeRepo = new LotteryDrawTypeRepository();
            LDT_LotteryDrawType drawType = drawTypeRepo.getById(drawObject.LDT_LotteryDrawType);
            saleTicket.drawTypeCode = drawType.LDT_Code;

            saleTicket.createDate = DateTime.Now;
            saleTicket.ticketId = pNumberList.LTL_Id;
            saleTicket.globalId = pointSale.LPS_Id + "" + saleTicket.ticketId;

            saleTicket.customerName = this.customerName;
            // Obtener detalle de la lista procesada
            LotteryListRepository listRepo = new LotteryListRepository();
            saleTicket.listNumberDetail = listRepo.getListDetail(pNumberList.LTL_Id);
            ticketPrinter.saleTicket = saleTicket;
            // Obtener nombre de impresora y enviar impresión
            string printerName = UtilityService.getTicketPrinterName();
            ticketPrinter.printLotterySaleTicket(printerName);
        }

        private void printListButton_Click(object sender, EventArgs e)
        {
            this.togglePrintListButton();
            //this.saveList();
            this.processList();
        }

        private void togglePrintListButton() {
            Button printButton = this.listInstanceBottomPanel.Controls.OfType<Button>().First();
            printButton.Enabled = !printButton.Enabled;
        }

        private void ListInstanceForm_KeyDown(object sender, KeyEventArgs e)
        {
            processMenuRequest(e);
        }

        private void processMenuRequest(KeyEventArgs pEvent)
        {
            if (pEvent.KeyCode == Keys.Multiply)
            {
                //MessageBox.Show("* KD");
                MainOptionMenu mainOptionMenu = new MainOptionMenu(this);
                this.mainOptionMenu = mainOptionMenu;
                mainOptionMenu.ShowDialog(this);
                pEvent.SuppressKeyPress = true;
            }
        }
    }
}
