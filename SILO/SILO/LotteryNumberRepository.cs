using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO
{
    class LotteryNumberRepository
    {
        public LNR_LotteryNumber getByNumberCode(string pNumberCode)
        {
            LNR_LotteryNumber findedNumber = null;
            using (var context = new SILOEntities())
            {
                List<LNR_LotteryNumber> numberlist = context.LNR_LotteryNumber.Where(n => n.LNR_Number.Equals(pNumberCode)).ToList();
                if (numberlist.Count > 0)
                {
                    findedNumber = numberlist[0];
                }
            }
            return findedNumber;
        }

        public List<LNR_LotteryNumber> getAll()
        {
            List<LNR_LotteryNumber> numberList = null;
            using (var context = new SILOEntities())
            {
                numberList = context.LNR_LotteryNumber.ToList();
            }
            return numberList;
        }

        public void saveProhibitedNumbers(int[] pProhibitedArray) {
            
            LNR_LotteryNumber number = null;
            using (var context = new SILOEntities())
            {
                //for determina cual es 1 y cual es 0 y lo guarda en la tabla

                for (int i = 1; i <= 100; i++) {

                   
                   else if (pProhibitedArray[i] == 1)
                    {
                        number = context.LNR_LotteryNumber.Find(i);
                        number.LNR_IsProhibited = 1;
                    }
                    else if (pProhibitedArray[i] == 0) {
                        number = context.LNR_LotteryNumber.Find(i);
                        number.LNR_IsProhibited =0 ;
                    }
                }
                
                
                context.SaveChanges();
            }

        }
    }
}
