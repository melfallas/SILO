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
                if(numberlist.Count > 0)
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
            Console.Write("Estoy funcionando");

            LNR_LotteryNumber number = null;
            using (var context = new SILOEntities())
            {
                number = context.LNR_LotteryNumber.Find(10);
                //number.LNR_IsProhibited = 1;
                context.SaveChanges();
            }

        }
    }
}
