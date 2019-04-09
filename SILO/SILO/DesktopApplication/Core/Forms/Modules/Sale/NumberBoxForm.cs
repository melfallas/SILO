using SILO.Core.Constants;
using SILO.DesktopApplication.Core.Constants;
using SILO.DesktopApplication.Core.Forms.Modules.ModuleForm;
using SILO.DesktopApplication.Core.Integration;
using SILO.DesktopApplication.Core.Repositories;
using SILO.DesktopApplication.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SILO.DesktopApplication.Core.Forms.Modules.Sale
{
    public partial class NumberBoxForm : MainModuleForm
    {

        private BoxNumberUnit[] boxArray;
        public ApplicationMediator appMediator { get; set; }

        public NumberBoxForm(ApplicationMediator pMediator)
        {
            InitializeComponent();
            this.type = SystemConstants.NUMBER_BOX_CODE;
            this.contentPanel.Visible = false;
            this.erasePanels();
            this.loadControls();
            this.createBoxNumber();
            // Establecer el ApplicationMediator
            this.appMediator = pMediator;

            //Thread.Sleep(5000);
            //this.contentPanel.Visible = true;
        }

        private void erasePanels() {
            this.titlePanel.Visible = false;
        }

        public void loadControls() {
            this.drawTypeBox.ValueMember = GeneralConstants.DISPLAY_DRAWTYPE_KEY_LABEL;
            this.drawTypeBox.DisplayMember = GeneralConstants.DISPLAY_DRAWTYPE_VALUE_LABEL;
            this.drawTypeBox.DataSource = UtilityService.drawTypeDataTable(this.drawTypeBox.ValueMember, this.drawTypeBox.DisplayMember);
            this.drawTypeBox.SelectedIndex = 0;
        }

        public void createBoxNumber()
        {
            // Generar el array de controles
            boxArray = new BoxNumberUnit[100];
            // Obtener detalle de los números prohibidos
            bool[] prohibitedNumbers = UtilityService.getProhibitedArray();
            this.buildBoxNumber(prohibitedNumbers);
            //MessageBox.Show("Mostrando");
            this.contentPanel.Visible = true;
        }

        public void buildBoxNumber(bool[] prohibitedNumbers)
        {
            // Establecer coordenadas para la caja
            int INI_X = 40;
            int INI_Y = 10;
            int SPACING_X = 90;
            int SPACING_Y = 22;
            int posX = INI_X;
            int posY = INI_Y;
            // Iterar por el panel creando las 100 casillas
            for (int i = 0; i < 100; i++)
            {
                if (i != 0 && i % 17 == 0)
                {
                    posX += SPACING_X;
                    posY = INI_Y;
                }
                // Crear el Label para la casilla
                Label numberLabel = new Label();
                numberLabel.Text = i.ToString();
                numberLabel.Top = posY;
                numberLabel.Left = posX;
                numberLabel.Width = 20;
                numberLabel.Height = 20;
                // Marcar los números prohibidos
                this.markProhibitedNumber(prohibitedNumbers[i], numberLabel);
                this.numberBoxPanel.Controls.Add(numberLabel);
                // Crear el TextBox para la casilla
                TextBox txbImport = new TextBox();
                txbImport.Text = "0";
                txbImport.Top = posY;
                txbImport.Left = posX + 20;
                txbImport.Width = 50;
                txbImport.Height = 20;
                txbImport.TextAlign = HorizontalAlignment.Right;
                txbImport.ReadOnly = true;
                this.numberBoxPanel.Controls.Add(txbImport);
                // Agregar el Label y el Texbox al array de controles
                this.boxArray[i] = new BoxNumberUnit(numberLabel, txbImport);
                posY += SPACING_Y;
            }
        }

        // Método para marcado de números prohibidos
        public void markProhibitedNumber(bool pIsProhibitedNumber, Label pLabelControl)
        {
            if (pIsProhibitedNumber)
            {
                pLabelControl.ForeColor = Color.FromArgb(255, 0, 0);
            }
            else
            {
                pLabelControl.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }


        //--------------------------------------- Métodos de Actualización --------------------------------------//

        private void updateBoxArray(long pGroupId)
        {
            int pendingImport = 0;
            int synchronizedImport = 0;
            ListService listService = new ListService();
            // Calcular importe sincronizado con el server
            int[] syncTotalImportArray = listService.getDrawTotals(this.datePickerList.Value.Date, pGroupId);
            for (int i = 0; i < syncTotalImportArray.Length; i++)
            {
                synchronizedImport += syncTotalImportArray[i];
                this.boxArray[i].textbox.Text = FormatService.formatInt(syncTotalImportArray[i]);
            }
            this.txbTotalImport.Text = FormatService.formatInt(synchronizedImport);
            // Calcular importe pendiente de sincronización
            int[] pendingSyncImportArray = listService.getDrawPendingSyncTotals(this.datePickerList.Value.Date, pGroupId);
            for (int i = 0; i < syncTotalImportArray.Length; i++)
            {
                pendingImport += pendingSyncImportArray[i];
            }
            this.txbSyncImport.Text = FormatService.formatInt(pendingImport);
            //var maxToReceive = Math.Round(totalImport * 0.00011);
            int maxToReceive = (int) (synchronizedImport * 0.03);
            //this.txbMaxToReceive.Text = FormatService.formatInt(maxToReceive);
            this.txbMaxToReceive.Text = maxToReceive == 0 ? "" : FormatService.formatInt(maxToReceive);
        }

        private void cleanBoxNumber()
        {
            for (int i = 0; i < boxArray.Length; i++)
            {
                this.boxArray[i].textbox.Text = "0";
            }
            this.txbTotalImport.Text = "0";
            this.txbSyncImport.Text = "0";
            this.txbMaxToReceive.Text = "";
        }

        private void displayNewListInstance() {
            bool displayInstance = ValidationService.isNotPreviousDate(this.datePickerList.Value.Date);
            // Desplegar control de instancia si cumple las validaciones
            if (displayInstance)
            {
                LotteryDrawTypeRepository typeRepository = new LotteryDrawTypeRepository();
                ListInstanceForm listInstance = new ListInstanceForm(
                    this.appMediator,
                    this,
                    UtilityService.getPointSale(),
                    typeRepository.getById(this.drawTypeBox.SelectedIndex),
                    this.datePickerList.Value.Date
                    );
                listInstance.StartPosition = FormStartPosition.CenterParent;
                //listInstance.ShowDialog();
                listInstance.ShowDialog(this);
                //listInstance.Show(this);
            }
            else
            {
                MessageService.displayErrorMessage(GeneralConstants.NOT_ALLOWED_PREVIOUS_DATE_SALE_MESSAGE, GeneralConstants.NOT_ALLOWED_PREVIOUS_DATE_SALE_TITLE);
            }
        }


        public void updateNumberBox()
        {
            long groupId = this.drawTypeBox.SelectedIndex;
            this.updateNumberBox(groupId);
        }

        public void updateNumberBox(DateTime? pDrawDate, long pGroupId)
        {
            if (pDrawDate == null) {
                this.datePickerList.Value = DateTime.Today;
            }
            else
            {
                this.datePickerList.Value = (DateTime) pDrawDate;
            }
            this.updateNumberBox(pGroupId);
        }

        public void updateNumberBox(long pGroupId)
        {
            // Si no hay número de grupo se debe limpiar el boxNumber
            if (pGroupId == 0)
            {
                this.cleanBoxNumber();
            }
            else
            {
                // Actualizar importes sólo si el grupo es distinto de cero
                //long groupId = Convert.ToInt64(this.drawTypeBox.SelectedValue);
                this.updateBoxArray(pGroupId);
            }
            // Actualizar números prohibidos siempre
            bool[] prohibitedNumbers = UtilityService.getProhibitedArray();
            for (int i = 0; i < prohibitedNumbers.Length; i++)
            {
                this.markProhibitedNumber(prohibitedNumbers[i], this.boxArray[i].label);
            }
            // Actualizar el drawType ComboBox al id de grupo especificado
            this.drawTypeBox.SelectedIndex = (int)pGroupId;
            //this.updateBoxArray(lotteryListRepository.getDrawListTotals(this.datePickerList.Value.Date, pGroupId));
        }

        


        //--------------------------------------- Eventos de Controles --------------------------------------//

        private void drawTypeBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                //this.drawTypeBox
                //MessageBox.Show("dfddf");
            }
        }

        private void datePickerList_ValueChanged(object sender, EventArgs e)
        {
            this.drawTypeBox.SelectedIndex = 0;
            this.cleanBoxNumber();
            //MessageBox.Show(this.datePickerList.Value.Date);
        }

        private void drawTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            long groupId = Convert.ToInt64(this.drawTypeBox.SelectedValue);
            if (groupId != 0)
            {
                this.updateNumberBox(groupId);
                this.displayNewListInstance();
            }
        }

    }
}
