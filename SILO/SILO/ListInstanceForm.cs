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

        private void saveList()
        {
            LotteryListControl listControl = this.listInstanceMainPanel.Controls.OfType<LotteryListControl>().First();
            //var v = listControl.loteryList.tupleList;
            // Validar si la lista tiene datos
            if (listControl.loteryList.tupleList.Count > 0)
            {
                this.processList(listControl);
                this.Close();
            }
            else
            {
                MessageBox.Show("La lista no tiene datos");
                this.togglePrintListButton();
            }
        }

        private void processList(LotteryListControl pListControl)
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
            listToSave.LPS_LotteryPointSale = 1;
            listToSave.LTD_LotteryDraw = drawToSave.LTD_Id;
            listToSave.LTL_CustomerName = "MFC Prueba";
            listToSave.LTL_CreateDate = DateTime.Now;
            lotteryDrawRepository.saveList(ref listToSave);
            // Crear y guardar el detalle de la lista
            /*
            List<LotteryTuple> numberList = new List<LotteryTuple>();
            numberList.Add(new LotteryTuple("01", 1000));
            numberList.Add(new LotteryTuple("02", 2000));
            numberList.Add(new LotteryTuple("03", 3000));
            */

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

        private void printListButton_Click(object sender, EventArgs e)
        {
            this.togglePrintListButton();
            this.saveList();
        }

        private void togglePrintListButton() {
            Button printButton = this.listInstanceBottomPanel.Controls.OfType<Button>().First();
            printButton.Enabled = !printButton.Enabled;
        }

        private void ListInstanceForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            processMenuRequest(e);
        }

        private void ListInstanceForm_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show("Tecla d presionada");
        }


        private void processMenuRequest(KeyPressEventArgs pEvent)
        {
            if (pEvent.KeyChar == '*')
            {
                MessageBox.Show("*");
            }
            else
            {
                //MessageBox.Show("Tecla presionada");
            }
        }

    }
}
