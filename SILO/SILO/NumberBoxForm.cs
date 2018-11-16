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
            loadControls();
        }

        public void loadControls() {
            this.drawTypeBox.ValueMember = "id";
            this.drawTypeBox.DisplayMember = "display";
            this.drawTypeBox.DataSource = UtilityService.buildDataTable();
            this.drawTypeBox.SelectedIndex = 0;
        }

        private void drawTypeBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter)) {
                //this.drawTypeBox
                //MessageBox.Show("dfddf");
            }
        }

        private void drawTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.drawTypeBox.SelectedValue) != 0)
            {
                MessageBox.Show("Valor: " + this.drawTypeBox.SelectedValue + " - " + this.drawTypeBox.Text);
            }
        }
    }
}
