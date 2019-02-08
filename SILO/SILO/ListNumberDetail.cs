using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO
{
    public class ListNumberDetail
    {
        
        public long id { get; set; }
        public long list { get; set; }
        public long number { get; set; }
        public long saleImport { get; set; }

        public ListNumberDetail(long id, long list, long number, long saleImport)
        {
            this.id = id;
            this.list = list;
            this.number = number;
            this.saleImport = saleImport;
        }

    }
}
