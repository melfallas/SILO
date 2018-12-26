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
    public partial class MainOptionMenu : Form
    {

        public ListInstanceForm listInstance { get; set; }

        public MainOptionMenu()
        {
            InitializeComponent();
        }

        public MainOptionMenu(ListInstanceForm pListInstance)
        {
            this.listInstance = pListInstance;
            InitializeComponent();
        }

        private void MainOptionMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            this.listInstance.processList();
            //this.Dispose();
        }

        private void reprintButton_Click(object sender, EventArgs e)
        {
            //ListSelectorForm listSelectorForm = new ListSelectorForm();
            //listSelectorForm.ShowDialog();
        }
    }
}
