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
    public partial class NumberBoxForm : Form
    {

        private BoxNumberUnit[] boxArray;


        public NumberBoxForm()
        {
            InitializeComponent();
            this.erasePanels();
            this.loadControls();
            this.createBoxNumber();
        }

        private void erasePanels() {
            this.titlePanel.Visible = false;
        }

        public void loadControls() {
            this.drawTypeBox.ValueMember = "id";
            this.drawTypeBox.DisplayMember = "display";
            this.drawTypeBox.DataSource = UtilityService.drawTypeDataTable(this.drawTypeBox.ValueMember, this.drawTypeBox.DisplayMember);
            this.drawTypeBox.SelectedIndex = 0;
        }

        public void createBoxNumber()
        {
            // Generar el array de controles
            boxArray = new BoxNumberUnit[100];
            // Obtener parámetros
            bool[] prohibitedNumbers = UtilityService.getProhibitedArray();
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
            
            /*
            txbImport = new TextBox();
            txbImport.Text = "85000";
            txbImport.Top = 100;
            txbImport.Left = 50;
            txbImport.Width = 50;
            this.numberBoxPanel.Controls.Add(txbImport);
            */
        }

        private void updateBoxArray(int[] importArray)
        {
            for (int i = 0; i < importArray.Length; i++)
            {
                this.boxArray[i].textbox.Text = importArray[i].ToString();
            }
        }

        private void drawTypeBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter)) {
                //this.drawTypeBox
                //MessageBox.Show("dfddf");
            }
        }

        private void datePickerList_ValueChanged(object sender, EventArgs e)
        {
            this.drawTypeBox.SelectedIndex = 0;
            //MessageBox.Show(this.datePickerList.Value.Date);
        }

        private void drawTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            long groupId = Convert.ToInt64(this.drawTypeBox.SelectedValue);
            if (groupId != 0)
            {
                this.displayNewListInstance();
                LotteryListRepository lotteryListRepository = new LotteryListRepository();
                this.updateBoxArray(lotteryListRepository.getDrawListTotals(this.datePickerList.Value.Date, groupId));
                //MessageBox.Show("Valor: " + this.drawTypeBox.SelectedValue + " - " + this.drawTypeBox.Text);
            }
        }
        
        private void displayNewListInstance() {
            LotteryDrawTypeRepository typeRepository = new LotteryDrawTypeRepository();
            ListInstanceForm listInstance = new ListInstanceForm(
                UtilityService.getPointSale(),
                typeRepository.getById(this.drawTypeBox.SelectedIndex),
                this.datePickerList.Value.Date
                );
            /*
            listInstance.pointSale = UtilityService.getPointSale();
            listInstance.drawType = typeRepository.getById(this.drawTypeBox.SelectedIndex);
            listInstance.drawDate = this.datePickerList.Value.Date;
            */
            
            //formToAdd.TopLevel = false;
            //formToAdd.Dock = DockStyle.Fill;
            //this.centerBoxPanel.Controls.Add(formToAdd);
            //this.centerBoxPanel.Tag = formToAdd;
            listInstance.StartPosition = FormStartPosition.CenterParent;
            //listInstance.ShowDialog();
            listInstance.Show(this);
        }

        
    }
}
