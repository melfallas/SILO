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

        }
    }
}
