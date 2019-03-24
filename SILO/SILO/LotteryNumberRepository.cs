﻿using SILO.DesktopApplication.Core.Abstract.Generic;
using SILO.DesktopApplication.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO
{
    class LotteryNumberRepository : GenericRepository<LNR_LotteryNumber, Object>
    {
        public List<LNR_LotteryNumber> findUnsynUsers()
        {
            return this.getAll().Where(user => user.SYS_SynchronyStatus == SystemConstants.SYNC_STATUS_PENDING_TO_SERVER).ToList();
        }

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

        /*
        public List<LNR_LotteryNumber> getAll()
        {
            List<LNR_LotteryNumber> numberList = null;
            using (var context = new SILOEntities())
            {
                numberList = context.LNR_LotteryNumber.ToList();
            }
            return numberList;
        }
        */

        public void saveProhibitedNumbers(int[] pProhibitedArray) {
            LNR_LotteryNumber number = null;
            using (var context = new SILOEntities())
            {
                // Determina cual es 1 y cual es 0 en el array de prohibidos y lo guarda en la tabla
                for (int i = 0; i < 100; i++) {
                    int positionArray = (i == 0 ? 100 : i);
                    number = context.LNR_LotteryNumber.Find(positionArray);
                    // Actualizar número y estado de sincronización solo si varió el valor
                    if(number.LNR_IsProhibited != pProhibitedArray[i])
                    {
                        number.LNR_IsProhibited = pProhibitedArray[i];
                        number.SYS_SynchronyStatus = SystemConstants.SYNC_STATUS_PENDING_TO_SERVER;
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
