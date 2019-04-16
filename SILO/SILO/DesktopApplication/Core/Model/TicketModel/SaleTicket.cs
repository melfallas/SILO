using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Model.TicketModel
{
    public class SaleTicket
    {
        public string companyName { get; set; }
        public string pointSaleName { get; set; }
        public string userName { get; set; }
        public string drawTypeCode { get; set; }
        public DateTime drawDate { get; set; }
        public DateTime createDate { get; set; }
        public long ticketId { get; set; }
        public string globalId { get; set; }
        public string customerName { get; set; }
        public List<LotteryTuple> listNumberDetail { get; set; }

        public float MyProperty { get; set; }

        public long getTotalImport()
        {
            long totalImport = 0;
            foreach (LotteryTuple tuple in this.listNumberDetail)
            {
                totalImport += tuple.import;
            }
            return totalImport;
        }

    }
}
