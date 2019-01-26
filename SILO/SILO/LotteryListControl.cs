using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SILO
{
    public partial class LotteryListControl : UserControl
    {
        public LotteryList loteryList { get; set; }

        public DataGridView getList() { return this.listView; }

        public LotteryListControl()
        {
            loteryList = new LotteryList();
            InitializeComponent();
            initializeEvents();
            initializeOperations();
        }

        public void initializeEvents()
        {
            this.listView.RowsAdded += new DataGridViewRowsAddedEventHandler(this.listView_RowsAdded);
        }

        public void initializeOperations()
        {
            fillRowListNumber();
        }

        public void print()
        {
            this.loteryList = new LotteryList(this.listView);
            Console.WriteLine(this.loteryList.toString());
        }


        // Método para agregar números de línea a las filas
        private void fillRowListNumber()
        {
            this.loteryList.count = this.listView.Rows.Count - 1;
            for (int i = 0; i < this.listView.Rows.Count; i++)
            {
                this.listView.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }

        // Evento que desencadena el agregado de números de línea en las filas
        private void listView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.fillRowListNumber();
        }

        private void listView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //this.totalTextLabel.Text = "15.500";
        }

        private void listView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.loteryList.fill(this.listView);
            this.txbTotalImport.Text = this.loteryList.getTotalImport().ToString();
        }

        private void listView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                /*
                DataGridViewCell currentCell = this.listView.CurrentCell;
                this.listView.EndEdit();
                this.listView.CurrentCell = currentCell;
                */
                e.SuppressKeyPress = true;
                //SendKeys.Send("{UP}");
                SendKeys.Send("{TAB}");
                //e.Handled = true;
            }
            else
            {
                if (e.KeyCode == Keys.Multiply)
                {
                    SendKeys.Send("{TAB}");
                }
            }
        }

        private void listView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("dfdf");
            SendKeys.Send("{UP}");
            SendKeys.Send("{TAB}");
        }

        private void listView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("F: " + e.RowIndex + "C: " + e.ColumnIndex);
        }

        private void listView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("F: " + e.RowIndex + "C: " + e.ColumnIndex);
            //this.listView.CurrentCell = this.listView[e.RowIndex, e.ColumnIndex];
        }
    }
}
