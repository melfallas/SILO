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
        public long import { get; set; }

        public LotteryTuple()
        {
            this.number = "";
            this.import = 0;
        }

        public LotteryTuple(long pNumber, long pImport)
        {
            this.number = pNumber.ToString();
            this.import = pImport;
        }

        public LotteryTuple(int pNumber, int pImport)
        {
            this.number = pNumber.ToString();
            this.import = pImport;
        }

        public LotteryTuple(string pNumber, int pImport)
        {
            this.number = pNumber;
            this.import = pImport;
        }

        public LotteryTuple(string pNumber, string pImport)
        {
            this.number = pNumber;
            this.import = Convert.ToInt32(pImport);
        }
    }
}
