using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Model.NumberModel
{
    public class WinningNumberInfo
    {
        public int prizeOrder { get; set; }
        public string numberCode { get; set; }
        public long saleImport { get; set; }
        public long prizeImport { get; set; }
        public long salePoint { get; set; }
        public long localId { get; set; }
        public string customerName { get; set; }
    }
}
