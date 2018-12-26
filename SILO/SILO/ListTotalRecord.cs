using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO
{
    public class ListTotalRecord
    {
        public int numberId { get; set; }
        public int totalImport { get; set; }

        public ListTotalRecord()
        {
            this.numberId = 0;
            this.totalImport = 0;
        }
        
    }
}
