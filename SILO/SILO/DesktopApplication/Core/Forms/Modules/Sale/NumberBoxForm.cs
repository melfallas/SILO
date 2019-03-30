using SILO.Core.Constants;
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
    public partial class NumberBoxForm : Form
    {

        private BoxNumberUnit[] boxArray;


        public NumberBoxForm()
        {
            InitializeComponent();
            this.contentPanel.Visible = false;
            this.erasePanels();
            this.loadControls();
            this.createBoxNumber();
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
                if (prohibitedNumbers[i]) {
                    numberLabel.ForeColor = Color.FromArgb(255, 0, 0);
                }
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


        //--------------------------------------- Métodos de Actualización --------------------------------------//

        

        private void updateBoxArray(int[] importArray)
        {
            int totalImport = 0;
            for (int i = 0; i < importArray.Length; i++)
            {
                totalImport += importArray[i];
                this.boxArray[i].textbox.Text = FormatService.formatInt(importArray[i]);
            }
            this.txbTotalImport.Text = FormatService.formatInt(totalImport);
            this.txbSyncImport.Text = FormatService.formatInt(totalImport);
            //var maxToReceive = Math.Round(totalImport * 0.00011);
            int maxToReceive = (int) (totalImport * 0.03);
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
                    this,
                    UtilityService.getPointSale(),
                    typeRepository.getById(this.drawTypeBox.SelectedIndex),
                    this.datePickerList.Value.Date
                    );
                listInstance.StartPosition = FormStartPosition.CenterParent;
                //listInstance.ShowDialog();
                listInstance.Show(this);
            }
            else
            {
                MessageService.displayErrorMessage(GeneralConstants.NOT_ALLOWED_PREVIOUS_DATE_SALE_MESSAGE, GeneralConstants.NOT_ALLOWED_PREVIOUS_DATE_SALE_TITLE);
            }
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
                this.displayNewListInstance();
                this.updateNumberBox(groupId);
            }
        }

        public void updateNumberBox(long pGroupId)
        {
            long groupId = Convert.ToInt64(this.drawTypeBox.SelectedValue);
            LotteryListRepository lotteryListRepository = new LotteryListRepository();
            this.updateBoxArray(lotteryListRepository.getDrawListTotals(this.datePickerList.Value.Date, groupId));
            //this.updateBoxArray(lotteryListRepository.getDrawListTotals(this.datePickerList.Value.Date, pGroupId));
        }


    }
}
