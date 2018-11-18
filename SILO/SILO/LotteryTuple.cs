using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO
{
    public class LotteryTuple
    {
        public string number { get; set; }
        public int import { get; set; }

        public LotteryTuple(string pNumber, int pImport)
        {
            this.number = pNumber;
            this.import = pImport;
        }
    }
}
