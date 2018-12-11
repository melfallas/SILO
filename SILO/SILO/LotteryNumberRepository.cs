﻿using System;
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
    }
}