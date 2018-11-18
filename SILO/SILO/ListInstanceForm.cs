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
        public ListInstanceForm()
        {
            InitializeComponent();
        }
        /*
        public ListInstanceForm()
        {
            InitializeComponent();
        }*/

        private void ListInstanceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //LTD_LotteryDraw newDraw = LTD_LotteryDraw.
            LotteryDrawRepository lotteryDrawRepository = new LotteryDrawRepository();
            // Crear y guardar nuevo sorteo
            LTD_LotteryDraw drawToSave = new LTD_LotteryDraw();
            drawToSave.LTD_CreateDate = DateTime.Today;
            drawToSave.LDT_LotteryDrawType = 3;
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
            List<LotteryTuple> numberList = new List<LotteryTuple>();
            numberList.Add(new LotteryTuple("01", 1000));
            numberList.Add(new LotteryTuple("02", 2000));
            numberList.Add(new LotteryTuple("03", 3000));

            LotteryNumberRepository numberRepository = new LotteryNumberRepository();
            foreach (LotteryTuple register in numberList)
            {
                LND_ListNumberDetail newListNumberDetail = new LND_ListNumberDetail();
                newListNumberDetail.LTL_LotteryList = listToSave.LTL_Id;
                newListNumberDetail.LNR_LotteryNumber = numberRepository.getByNumberCode(register.number).LNR_Id;
                newListNumberDetail.LND_Import = register.import;
                lotteryDrawRepository.saveListDetail(ref newListNumberDetail);
            }

            

            

            //lotteryDrawRepository.createLotteryList();
            //MessageBox.Show("Cerrando");
        }
    }
}
