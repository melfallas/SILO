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
        public long drawType { get; set; }
        public DateTime drawDate { get; set; }

        public ListInstanceForm()
        {
            InitializeComponent();
            this.addControls();
        }


        public void addControls()
        {
            this.listInstancePanel.Controls.Add(new LotteryListControl());
        }


        private void ListInstanceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            LotteryListControl listControl = this.listInstancePanel.Controls.OfType<LotteryListControl>().First();
            //var v = listControl.loteryList.tupleList;
            // Validar si la lista tiene datos
            if (listControl.loteryList.tupleList.Count > 0)
            {
                this.processList(listControl);
            }
            else
            {
                MessageBox.Show("La lista no tiene datos");
            }
        }

        private void processList(LotteryListControl pListControl)
        {
            //LTD_LotteryDraw newDraw = LTD_LotteryDraw.
            LotteryDrawRepository lotteryDrawRepository = new LotteryDrawRepository();
            // Crear y guardar nuevo sorteo
            LTD_LotteryDraw drawToSave = new LTD_LotteryDraw();
            drawToSave.LTD_CreateDate = this.drawDate;
            drawToSave.LDT_LotteryDrawType = this.drawType;
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

    }
}
