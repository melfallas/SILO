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
            this.posLabel.Text = this.pointSale.LPS_DisplayName;
            this.groupLabel.Text = this.drawType.LDT_DisplayName;
            this.dateLabel.Text = UtilityService.getLargeDate(this.drawDate);
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

        private LotteryListControl getCurrentListControl() {
            return this.listInstanceMainPanel.Controls.OfType<LotteryListControl>().First();
        }

        public void processList()
        {
            LotteryListControl listControl = this.getCurrentListControl();
            // Validar si la lista tiene datos
            if (listControl.loteryList.tupleList.Count == 0)
            {
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
            LotteryListControl listControl = this.listInstanceMainPanel.Controls.OfType<LotteryListControl>().First();
            this.saveList(listControl);
            UtilityService.printList(this.list);
            this.Dispose();
        }


        private void saveList(LotteryListControl pListControl)
        {
            LotteryDrawRepository lotteryDrawRepository = new LotteryDrawRepository();
            // Crear y guardar nuevo sorteo
            LTD_LotteryDraw drawToSave = new LTD_LotteryDraw();
            drawToSave.LTD_CreateDate = this.drawDate;
            drawToSave.LDT_LotteryDrawType = this.drawType.LDT_Id;
            drawToSave.LDS_LotteryDrawStatus = 2;
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
            ServerConnectionService service = new ServerConnectionService();
            ServiceResponseResult response = service.generateList(listToSave, numberDetailCollection);
            Console.WriteLine("Respuesta Venta: " + response.result);
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
                // Actualizar la estructura de lista antes de desplegar menú de opciones
                LotteryListControl listControl = this.getCurrentListControl();
                listControl.getList().EndEdit();
                // Desplegar menú de opciones
                MainOptionMenu mainOptionMenu = new MainOptionMenu(this);
                this.mainOptionMenu = mainOptionMenu;
                mainOptionMenu.ShowDialog(this);
                pEvent.SuppressKeyPress = true;
            }
        }
    }
}
