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
    public partial class ListSelectorForm : Form
    {
        public DateTime drawDate { get; set; }
        public long drawType { get; set; }
        public int operationType { get; set; }

        public ListSelectorForm(DateTime pDate, long pGroup, int pOperation)
        {
            InitializeComponent();
            this.drawDate = pDate;
            this.drawType = pGroup;
            this.operationType = pOperation;
            this.addControls();
        }

        private void addControls()
        {
            this.listSelectorPanel.Controls.Add(new ListBoxSelector(this, this.drawDate, this.drawType));
        }

        // Método para procesado de la lista según el tipo operación
        public void execOperation(long pListId)
        {
            switch (this.operationType)
            {
                case SystemConstants.PRINTER_LIST_CODE:
                    this.printList(pListId);
                    break;
                case SystemConstants.ERASER_LIST_CODE:
                    //this.printList();
                    break;
                default:
                    break;
            }
        }

        public void printList(long pListId)
        {
            //MessageBox.Show("Printer");
            LotteryListRepository listRepository = new LotteryListRepository();
            UtilityService.printList(listRepository.getById(pListId));
        }

        private void ListSelectorForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }
    }
}
