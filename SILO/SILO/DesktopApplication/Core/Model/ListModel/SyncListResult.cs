using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Model.ListModel
{
    class SyncListResult
    {
        public int id { get; set; }
        public int listNumber { get; set; }
        public string customerName { get; set; }
        public Object lotteryPointSale { get; set; }
        public Object lotteryDraw { get; set; }
        public Object lotteryListStatus { get; set; }
        public Object synchronyStatus { get; set; }
        public string createDate { get; set; }
    }
}
