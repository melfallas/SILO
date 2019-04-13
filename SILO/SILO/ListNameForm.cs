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
    public partial class ListNameForm : Form
    {
        public ListInstanceForm listInstance { get; set; }

        public ListNameForm()
        {
            InitializeComponent();
        }

        public ListNameForm(ListInstanceForm pListInstance)
        {
            this.listInstance = pListInstance;
            //this.listInstance.mainOptionMenu.Dispose();
            InitializeComponent();
        }

        private void txtListName_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    this.listInstance.customerName = txtListName.Text;
                    this.Hide();
                    this.listInstance.createList();
                    this.Dispose();
                    break;
                case Keys.Escape:
                    this.Dispose();
                    break;
                default:
                    break;
            }
        }

    }
}
