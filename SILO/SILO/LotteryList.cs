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
        public Dictionary<int, LotteryTuple> tupleList { get; set; }
        public int count { get; set; }

        public LotteryList()
        {
            this.count = 0;
            tupleList = new Dictionary<int, LotteryTuple>();
        }

        public LotteryList(DataGridView pGridView)
        {
            this.fill(pGridView);
        }


        public void fill(DataGridView pGridView)
        {
            this.count = pGridView.RowCount - 1;
            this.tupleList = new Dictionary<int, LotteryTuple>();
            for (int i = 0; i < this.count; i++)
            {
                string numberCode = getGridCellValue(pGridView, i, 0);
                string importItem = getGridCellValue(pGridView, i, 1);
                Boolean emptyRegister = numberCode.Equals("") || importItem.Equals("");
                if(!emptyRegister)
                {
                    LotteryTuple tuple = new LotteryTuple(numberCode, int.Parse(importItem));
                    this.tupleList.Add(i + 1, tuple);
                }
            }
        }

        public int getSize()
        {
            return tupleList.Count;
        }

        public long getTotalImport()
        {
            long import = 0;
            foreach(var item in this.tupleList)
            {
                import += item.Value.import;
            }
            return import;
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
