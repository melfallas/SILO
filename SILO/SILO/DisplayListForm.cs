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
    public partial class DisplayListForm : Form
    {
        public int type { get; set; }

        public DisplayListForm()
        {
            InitializeComponent();
        }

        public DisplayListForm(int pType)
        {
            InitializeComponent();
            this.initializeAttributes(pType);
            this.loadControls();
        }

        public void initializeAttributes(int pType) {
            this.type = pType;
        }

        public void loadControls()
        {
            this.drawTypeBox.ValueMember = "id";
            this.drawTypeBox.DisplayMember = "display";
            this.drawTypeBox.DataSource = UtilityService.drawTypeDataTable(this.drawTypeBox.ValueMember, this.drawTypeBox.DisplayMember);
            this.drawTypeBox.SelectedIndex = 0;
        }

        public void displayListForm() {
            if (Convert.ToInt32(this.drawTypeBox.SelectedValue) != 0)
            {
                ListSelectorForm listBoxSelector = 
                    new ListSelectorForm(this.datePickerList.Value.Date, this.drawTypeBox.SelectedIndex, SystemConstants.PRINTER_LIST_CODE);
                listBoxSelector.ShowDialog();
                //MessageBox.Show("Valor" + this.drawTypeBox.SelectedIndex);
            }
        }

        private void drawTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.displayListForm();
        }

        private void datePickerList_ValueChanged(object sender, EventArgs e)
        {
            this.displayListForm();
        }
    }
}
