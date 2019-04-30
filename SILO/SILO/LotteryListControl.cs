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

        public void resetCurrentCell()
        {
            //Console.WriteLine("RC: " + listView.RowCount + " - CC; " + listView.Rows[0]);
            this.listView.CurrentCell = this.listView.Rows[0].Cells[0];
            //this.listView.CurrentCell = this.listView[0, 0];
        }

        public void print()
        {
            this.loteryList = new LotteryList(this.listView);
        }

        public void fillList(List<LotteryTuple> pNumberList)
        {
            foreach (var tuple in pNumberList)
            {
                this.listView.Rows.Add(tuple.number, tuple.import);
            }
        }

        public void clearList()
        {
            this.listView.Rows.Clear();
            this.listView.Refresh();
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


        //--------------------------------------- Eventos de controles --------------------------------------//
        #region Eventos de controles
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
            DataGridView gridSender = (DataGridView)sender;
            int currentRow = 0;
            int currentCol = 0;
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    // Obtener indices de la celda actual
                    if (gridSender.CurrentCell != null)
                    {
                        currentRow = gridSender.CurrentCell.RowIndex;
                        currentCol = gridSender.CurrentCell.ColumnIndex;
                    }
                    this.replyImport(currentRow, currentCol);
                    //Console.WriteLine("listView_KeyDown - F: " + currentRow + " - C: " + currentCol);
                    e.SuppressKeyPress = true;
                    SendKeys.Send("{TAB}");
                    break;
                case Keys.Multiply:
                    SendKeys.Send("{TAB}");
                    break;
                case Keys.Delete:
                case Keys.Back:
                    // Obtener indices de la celda actual
                    if (gridSender.CurrentCell != null)
                    {
                        currentRow = gridSender.CurrentCell.RowIndex;
                        currentCol = gridSender.CurrentCell.ColumnIndex;
                    }
                    this.listView.Rows[currentRow].Cells[currentCol].Value = "";
                    break;
                default:
                    break;
            }
        }

        private void listView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SendKeys.Send("{UP}");
            SendKeys.Send("{TAB}");
            //Console.WriteLine("CellEndEdit - F: " + e.RowIndex + " - C: " + e.ColumnIndex);
            this.replyImport(e.RowIndex, e.ColumnIndex);
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

        #endregion

        private void replyImport(int pPreviousRowIndex, int pPreviousColumIndex)
        {
            // Replicar importe solamente si se hace tab en columna de importes
            if (pPreviousColumIndex == 1)
            {
                int rowCount = this.listView.RowCount;
                int nextRowIndex = pPreviousRowIndex + 1;
                // Replicar únicamente cuando no está en la última fila
                if (nextRowIndex < rowCount)
                {
                    object nextValue = this.listView.Rows[nextRowIndex].Cells[pPreviousColumIndex].Value;
                    // Replicar solamente si el valor del siguiente monto no se ha establecido
                    if (nextValue == null || nextValue.ToString().Trim() == "")
                    {
                        string previousImport = this.listView.Rows[pPreviousRowIndex].Cells[pPreviousColumIndex].Value.ToString();
                        this.listView.Rows[nextRowIndex].Cells[pPreviousColumIndex].Value = previousImport;
                    }
                }
            }
        }


    }
}
