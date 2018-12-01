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
            int INI_X = 40;
            int INI_Y = 10;
            int SPACING_X = 90;
            int SPACING_Y = 22;
            int posX = INI_X;
            int posY = INI_Y;

            for (int i = 0; i < 100; i++)
            {

                if (i != 0 && i % 17 == 0)
                {
                    posX += SPACING_X;
                    posY = INI_Y;
                }

                Label numberLabel = new Label();
                numberLabel.Text = i.ToString();
                numberLabel.Top = posY;
                numberLabel.Left = posX;
                numberLabel.Width = 20;
                numberLabel.Height = 20;
                this.numberBoxPanel.Controls.Add(numberLabel);

                TextBox txbImport = new TextBox();
                txbImport.Text = "0";
                txbImport.Top = posY;
                txbImport.Left = posX + 20;
                txbImport.Width = 50;
                txbImport.Height = 20;
                txbImport.TextAlign = HorizontalAlignment.Right;
                txbImport.ReadOnly = true;
                this.numberBoxPanel.Controls.Add(txbImport);
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
        }

        private void drawTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.drawTypeBox.SelectedValue) != 0)
            {
                this.displayNewListInstance();
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
