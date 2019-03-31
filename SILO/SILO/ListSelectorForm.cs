using SILO.Core.Constants;
using SILO.DesktopApplication.Core.Constants;
using SILO.DesktopApplication.Core.Forms.Modules.List;
using SILO.DesktopApplication.Core.Repositories;
using SILO.DesktopApplication.Core.Services;
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
        public void processOperation(long pListId)
        {
            switch (this.operationType)
            {
                case SystemConstants.PRINTER_LIST_CODE:
                    this.printList(pListId);
                    break;
                case SystemConstants.ERASER_LIST_CODE:
                    this.eraseList(pListId);
                    break;
                default:
                    break;
            }
        }


        public void eraseList(long pListId)
        {
            LotteryListRepository listRepository = new LotteryListRepository();
            LTL_LotteryList list = listRepository.getById(pListId);
            list.LLS_LotteryListStatus = SystemConstants.LIST_STATUS_CANCELED;
            listRepository.updateList(list);
            this.Hide();
            MessageService.displayInfoMessage(GeneralConstants.SUCCESS_TRANSACTION_CANCELATION_MESSAGE, GeneralConstants.SUCCESS_TRANSACTION_CANCELATION_TITLE);
            LotteryDrawRepository drawRepository = new LotteryDrawRepository();
            LotteryDrawTypeRepository drawTypeRepository = new LotteryDrawTypeRepository();
            ListInstanceForm listInstance = new ListInstanceForm(
                this,
                UtilityService.getPointSale(),
                drawTypeRepository.getById(drawRepository.getById(list.LTD_LotteryDraw).LDT_LotteryDrawType),
                DateTime.Today,
                listRepository.getListDetail(pListId)
                );
            listInstance.StartPosition = FormStartPosition.CenterParent;
            listInstance.ShowDialog();
            //listInstance.ShowDialog(this);
        }

        public void printList(long pListId)
        {
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
