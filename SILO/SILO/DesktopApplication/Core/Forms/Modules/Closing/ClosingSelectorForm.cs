using SILO.Core.Constants;
using SILO.DesktopApplication.Core.Constants;
using SILO.DesktopApplication.Core.Integration;
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

namespace SILO.DesktopApplication.Core.Forms.Modules.Closing
{
    public partial class ClosingSelectorForm : Form
    {
        public ApplicationMediator appMediator { get; set; }

        public ClosingSelectorForm(ApplicationMediator pMediator)
        {
            InitializeComponent();
            this.appMediator = pMediator;
            this.loadControls();
        }

        private void loadControls()
        {
            this.drawTypeBox.ValueMember = GeneralConstants.DISPLAY_DRAWTYPE_KEY_LABEL;
            this.drawTypeBox.DisplayMember = GeneralConstants.DISPLAY_DRAWTYPE_VALUE_LABEL;
            this.drawTypeBox.DataSource = UtilityService.drawTypeDataTable(this.drawTypeBox.ValueMember, this.drawTypeBox.DisplayMember);
            this.drawTypeBox.SelectedIndex = 0;
            this.datePickerList.Focus();
        }

        private void closeView()
        {
            this.appMediator.setAppTopMost(true);
            this.Dispose();
            this.appMediator.setAppTopMost(false);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.closeView();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            this.startDrawClosing(Convert.ToInt64(this.drawTypeBox.SelectedValue), this.datePickerList.Value.Date);
        }

        private void startDrawClosing(long pDrawTypeToClose, DateTime pDateToClose)
        {
            if (pDrawTypeToClose == 0)
            {
                MessageBox.Show("Debe elegir un grupo válido");
            }
            else
            {
                this.closeDraw(pDrawTypeToClose, pDateToClose);
            }
        }

        private void clearDrawTypeBox()
        {
            this.drawTypeBox.SelectedValue = 0;
        }

        private void closeDraw(long pDrawTypeToClose, DateTime pDateToClose) {
            DrawService drawService = new DrawService();
            LTD_LotteryDraw existingDraw = drawService.getDraw(pDrawTypeToClose, pDateToClose);
            // Validar si el sorteo está cerrado
            if (existingDraw == null || existingDraw.LDS_LotteryDrawStatus == SystemConstants.DRAW_STATUS_CLOSED)
            {
                MessageService.displayInfoMessage(
                "El sorteo se encuentra cerrado\nNo es necesario realizar la operación.",
                "SORTEO CERRADO PREVIAMENTE"
                );
                this.clearDrawTypeBox();
            }
            else
            {
                List<LTD_LotteryDraw> otherUnclosedDrawList = drawService.getUnclosedDraw(pDrawTypeToClose, pDateToClose);
                if (otherUnclosedDrawList.Count > 0)
                {
                    DrawTypeService drawType = new DrawTypeService();
                    LDT_LotteryDrawType type = drawType.getById(pDrawTypeToClose);
                    string unclosedDateListString = "\n\n";
                    foreach (LTD_LotteryDraw drawItem in otherUnclosedDrawList)
                    {
                        if (drawItem.LTD_CreateDate != pDateToClose)
                        {
                            unclosedDateListString += type.LDT_DisplayName + "\t" + FormatService.formatDrawDateToSimpleString(drawItem.LTD_CreateDate) + "\n";
                        }
                    }
                    //Console.WriteLine(unclosedDateListString);
                    MessageService.displayWarningMessage(
                    "Existen sorteos de fechas anteriores pendientes de cierre.\nPor favor, proceda primero a realizar los cierres pendientes:" + unclosedDateListString,
                    "SORTEOS ANTERIORES SIN CERRAR"
                    );
                    //this.clearDrawTypeBox();
                }
                else
                {
                    this.confirmDrawClosing(pDrawTypeToClose, pDateToClose);
                }
            }
        }

        private void confirmDrawClosing(long pGroupId, DateTime pDrawDate)
        {
            DialogResult msgResult =
                    MessageService.displayConfirmWarningMessage(
                            GeneralConstants.CLOSING_CONFIRM_MESSAGE,
                            GeneralConstants.CLOSING_CONFIRM_TITLE
                            );
            // Procesar el resultado de la confirmación
            switch (msgResult)
            {
                case DialogResult.Yes:
                    // Procesar la sincronización
                    this.closeView();
                    this.appMediator.setAppTopMost(true);
                    // Proceder con el cierre
                    this.appMediator.closeTransactions(SystemConstants.SYNC_CLOSING_TYPE, pDrawDate, pGroupId);
                    // Sincronizar cierre de sorteo con el servidor
                    if (UtilityService.realTimeSyncEnabled())
                    {
                        this.closeDrawInServer(pDrawDate, pGroupId);
                    }
                    // Almacenar importe de venta para el sorteo
                    DrawBalanceService drawBalanceService = new DrawBalanceService();
                    drawBalanceService.saveDrawSaleImport(pGroupId, pDrawDate);
                    this.appMediator.setAppTopMost(false);
                    break;
                case DialogResult.No:
                    break;
                default:
                    break;
            }
        }

        private async void closeDrawInServer(DateTime pDrawDate, long pGroupId)
        {
            SynchronizeService syncService = new SynchronizeService();
            syncService.appMediator = this.appMediator;
            await syncService.closeDrawInServerAsync(pDrawDate, pGroupId);
        }

        private void ClosingSelectorForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.closeView();
            }
        }
    }
}
