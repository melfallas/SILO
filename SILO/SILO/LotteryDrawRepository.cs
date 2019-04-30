using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO
{
    class LotteryDrawRepository
    {
        public List<LTD_LotteryDraw> getAll()
        {
            List<LTD_LotteryDraw> drawList = null;
            using (var context = new SILOEntities())
            {
                drawList = context.LTD_LotteryDraw.ToList();
            }
            return drawList;
        }


        public LTD_LotteryDraw getById(long pId)
        {
            LTD_LotteryDraw draw = null;
            using (var context = new SILOEntities())
            {
                draw = context.LTD_LotteryDraw.Find(pId);
            }
            return draw;
        }

        public LTD_LotteryDraw getByTypeAndDate(long pDrawType, DateTime pDrawDate)
        {
            LTD_LotteryDraw findedDraw = null;
            List < LTD_LotteryDraw > drawList = this.getAll().Where(
                item =>
                    item.LDT_LotteryDrawType == pDrawType
                    && item.LTD_CreateDate == pDrawDate
                ).ToList();
            if (drawList.Count > 0)
            {
                findedDraw = drawList[0];
            }
            return findedDraw;
        }


        public LTD_LotteryDraw getDrawRegister(LTD_LotteryDraw pDraw)
        {
            LTD_LotteryDraw findedDraw = null;
            using (var context = new SILOEntities())
            {
                if (pDraw.LTD_Id != 0) {
                    findedDraw = context.LTD_LotteryDraw.Find(pDraw.LTD_Id);
                }
                else
                {
                    List<LTD_LotteryDraw> drawList = context.LTD_LotteryDraw
                        .Where(list => list.LTD_CreateDate == pDraw.LTD_CreateDate)
                        .Where(list => list.LDT_LotteryDrawType == pDraw.LDT_LotteryDrawType)
                        .ToList();
                    if(drawList.Count > 0){
                        findedDraw = drawList[0];
                    }
                }
            }
            return findedDraw;
        }


        public void save(ref LTD_LotteryDraw pDraw)
        {
            LTD_LotteryDraw matchingDraw = this.getDrawRegister(pDraw);
            if (matchingDraw != null)
            {
                pDraw = matchingDraw;
            }
            else {
                using (var context = new SILOEntities())
                {
                    context.LTD_LotteryDraw.Add(pDraw);
                    context.SaveChanges();
                }
            }
        }

        public void saveList(ref LTL_LotteryList pList)
        {
            using (var context = new SILOEntities())
            {
                context.LTL_LotteryList.Add(pList);
                context.SaveChanges();
            }
        }


        public void saveListDetail(ref LND_ListNumberDetail pList)
        {
            using (var context = new SILOEntities())
            {
                context.LND_ListNumberDetail.Add(pList);
                context.SaveChanges();
            }
        }

    }
}
