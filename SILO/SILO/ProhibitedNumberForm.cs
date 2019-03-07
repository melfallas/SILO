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
    public partial class ProhibitedNumberForm : Form
    {
        public CheckBox[]  arrayCheckBox { get; set; }

        public ProhibitedNumberForm()
        {
            InitializeComponent();
            this.initializeControls();
        }

        private void ProhibitedNumberForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        private void initializeControls()
        {
            arrayCheckBox = new CheckBox[100];
            // Obtener parámetros de números prohibidos
            bool[] prohibitedNumbers = UtilityService.getProhibitedArray();
            // Establecer coordenadas para la caja
            int INI_X = 40;
            int INI_Y = 10;
            int SPACING_X = 50;
            int SPACING_Y = 22;
            int posX = INI_X;
            int posY = INI_Y;
            for (int i = 0; i < 100; i++)
            {
                if (i != 0 && i % 10 == 0)
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
                this.prohibitedMainPanel.Controls.Add(numberLabel);
                CheckBox cbxProhibitedNumber = new CheckBox();
                cbxProhibitedNumber.Top = posY;
                cbxProhibitedNumber.Left = posX + 20;
                cbxProhibitedNumber.Width = 25;
                cbxProhibitedNumber.Height = 20;
                if (prohibitedNumbers[i]) {
                    cbxProhibitedNumber.Checked = true;
                }
                arrayCheckBox[i] = cbxProhibitedNumber;

                this.prohibitedMainPanel.Controls.Add(cbxProhibitedNumber);
                /*
                TextBox txbImport = new TextBox();
                txbImport.Text = "0";
                txbImport.Top = posY;
                txbImport.Left = posX + 20;
                txbImport.Width = 50;
                txbImport.Height = 20;
                txbImport.TextAlign = HorizontalAlignment.Right;
                txbImport.ReadOnly = true;
                this.prohibitedMainPanel.Controls.Add(txbImport);
                */
                posY += SPACING_Y;
            }
        }

        private void entryProhibitedButtom_Click(object sender, EventArgs e)
        {    

            int[] array = new int[100];
            for (int i = 0; i < 100; i++) {

               
                if (arrayCheckBox[i].Checked) {
                    array[i] = 1;
                }
                else {
                    array[i] = 0;
                }

            }
                UtilityService.saveProhibitedNumbers(array);
        }
    }
}
