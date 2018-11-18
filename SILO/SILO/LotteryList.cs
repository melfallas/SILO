using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SILO
{
    public class LotteryList
    {
        public Dictionary<int, LotteryTuple> tupleList { get; }
        public int count { get; set; }

        public LotteryList()
        {
            this.count = 0;
            tupleList = new Dictionary<int, LotteryTuple>();
        }

        public LotteryList(DataGridView pGridView)
        {
            this.count = pGridView.RowCount - 1;
            this.tupleList = new Dictionary<int, LotteryTuple>();
            for (int i = 0; i < this.count; i++)
            {
                LotteryTuple tuple = new LotteryTuple(getGridCellValue(pGridView, i, 0), int.Parse(getGridCellValue(pGridView, i, 1)));
                this.tupleList.Add(i + 1, tuple);
            }
        }

        public int getSize()
        {
            return tupleList.Count;
        }


        public String toString()
        {
            String output = "";
            foreach (var item in this.tupleList)
            {
                output += item.Key + " - " + item.Value.number + " - " + item.Value.import;
            }
            return output;
        }

        private String getGridCellValue(DataGridView pGridView, int pRow, int pColum)
        {
            Object cellValue = pGridView.Rows[pRow].Cells[pColum].Value;
            String stringCellValue = cellValue == null ? "" : cellValue.ToString();
            return stringCellValue;
        }
    }
}
