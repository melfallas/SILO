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

        //--------------------------------------- Métodos de Inicialización --------------------------------------//
        #region Métodos de Inicialización

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
        #endregion

        //--------------------------------------- Métodos de Procesamiento --------------------------------------//
        #region Métodos de Procesamiento

        // Método para procesado de la lista según el tipo operación
        public void processOperation(long pListId)
        {
            switch (this.operationType)
            {
                case SystemConstants.COPY_LIST_CODE:
                    this.copyList(pListId);
                    break;
                case SystemConstants.PRINTER_LIST_CODE:
                    this.printList(pListId);
                    break;
                case SystemConstants.ERASER_LIST_CODE:
                    this.validateEraseList(pListId);
                    break;
                default:
                    this.Dispose();
                    break;
            }
        }

        private void copyList(long pListId)
        {
            CopyListForm copyListForm = new CopyListForm(this, pListId);
            this.Hide();
            copyListForm.ShowDialog();
            LotteryListRepository listRepository = new LotteryListRepository();
           // UtilityService.printList(listRepository.getById(pListId));
        }

        private void printList(long pListId)
        {
            LotteryListRepository listRepository = new LotteryListRepository();
            UtilityService.printList(listRepository.getById(pListId));
        }

        private void validateEraseList(long pListId)
        {
            DialogResult msgResult =
                    MessageService.displayConfirmWarningMessage(
                            "¿Está seguro que quiere borrar la lista?",
                            "BORRANDO LISTA..."
                            );
            // Procesar el resultado de la confirmación
            switch (msgResult)
            {
                case DialogResult.Yes:
                    // Procesar el borrado
                    this.eraseList(pListId);
                    break;
                case DialogResult.No:
                    break;
                default:
                    break;
            }
        }

        private void eraseList(long pListId)
        {
            ListService listService = new ListService();
            LTL_LotteryList list = listService.getById(pListId);
            list.LLS_LotteryListStatus = SystemConstants.LIST_STATUS_CANCELED;
            listService.updateList(list);
            // TODO: Reversar la lista en el servidor
            this.Hide();
            MessageService.displayInfoMessage(GeneralConstants.SUCCESS_TRANSACTION_CANCELATION_MESSAGE, GeneralConstants.SUCCESS_TRANSACTION_CANCELATION_TITLE);
            LotteryDrawRepository drawRepository = new LotteryDrawRepository();
            LotteryDrawTypeRepository drawTypeRepository = new LotteryDrawTypeRepository();
            ListInstanceForm listInstance = new ListInstanceForm(
                this,
                UtilityService.getPointSale(),
                drawTypeRepository.getById(drawRepository.getById(list.LTD_LotteryDraw).LDT_LotteryDrawType),
                DateTime.Today,
                listService.getListDetail(pListId)
                );
            listInstance.StartPosition = FormStartPosition.CenterParent;
            listInstance.ShowDialog();
            //listInstance.ShowDialog(this);
        }

        #endregion

        //--------------------------------------- Eventos de Controles --------------------------------------//
        #region Eventos de Controles
        private void ListSelectorForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }
        #endregion

        private void ListSelectorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //MessageBox.Show("Abierto: " + this.operationType);
        }
    }
}
