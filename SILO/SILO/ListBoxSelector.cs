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
    public partial class ListBoxSelector : UserControl
    {
        public DateTime drawDate { get; set; }
        public long drawType { get; set; }
        public ListSelectorForm selector { get; set; }

        public ListBoxSelector()
        {
            InitializeComponent();
            this.fillTable();
        }

        public ListBoxSelector(ListSelectorForm pSelector, DateTime pDate, long pGroup)
        {
            InitializeComponent();
            this.drawDate = pDate;
            this.drawType = pGroup;
            this.selector = pSelector;
            this.fillTable();
        }

        private void fillTable() {
            LotteryListRepository lotteryListRepository = new LotteryListRepository();
            List<ListData> listData = lotteryListRepository.getListCollection(this.drawDate, this.drawType);
            if(listData.Count == 0)
            {
                MessageBox.Show("No existen registros para los parámetros especificados");
            }
            else
            {
                foreach (var item in listData)
                {
                    this.listSelectorGrid.Rows.Add(item.id, item.date, item.global, item.name);
                }
            }
        }

        private void selectListButton_Click(object sender, EventArgs e)
        {
            var cell = this.listSelectorGrid.CurrentRow.Cells[0];
            long listId = Convert.ToInt64(cell.Value.ToString());
            MessageBox.Show(listId.ToString());
            this.selector.execOperation(listId);
        }

    }
}
