using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO
{
    class DrawNumberWinningRepository
    {

        public DNW_DrawNumberWinning getById(long pId)
        {
            DNW_DrawNumberWinning drawWinning = null;
            using (var context = new SILOEntities())
            {
                drawWinning = context.DNW_DrawNumberWinning.Find(pId);
            }
            return drawWinning;
        }

        public DNW_DrawNumberWinning getDrawWinningRegister(DNW_DrawNumberWinning pDrawWinning)
        {
            DNW_DrawNumberWinning findedDrawWinning = null;
            using (var context = new SILOEntities())
            {
                if (pDrawWinning.LTD_LotteryDraw != 0)
                {
                    findedDrawWinning = context.DNW_DrawNumberWinning.Find(pDrawWinning.LTD_LotteryDraw);
                }
                else
                {
                    
                }
            }
            return findedDrawWinning;
        }

        public void save(ref DNW_DrawNumberWinning pDrawWinning)
        {
            DNW_DrawNumberWinning matchingDrawWinning = this.getDrawWinningRegister(pDrawWinning);
            if (matchingDrawWinning == null)
            {
                using (var context = new SILOEntities())
                {
                    context.DNW_DrawNumberWinning.Add(pDrawWinning);
                    context.SaveChanges();
                }
            }
            else
            {
                using (var context = new SILOEntities())
                {
                    matchingDrawWinning = context.DNW_DrawNumberWinning.Find(pDrawWinning.LTD_LotteryDraw);
                    matchingDrawWinning.DNW_FirtsNumber = pDrawWinning.DNW_FirtsNumber;
                    matchingDrawWinning.DNW_SecondNumber = pDrawWinning.DNW_SecondNumber;
                    matchingDrawWinning.DNW_ThirdNumber = pDrawWinning.DNW_ThirdNumber;
                    matchingDrawWinning.DNW_CreateDate = pDrawWinning.DNW_CreateDate;
                    matchingDrawWinning.SYS_SynchronyStatus = pDrawWinning.SYS_SynchronyStatus;
                    context.SaveChanges();
                }
            }
        }




    }
}
