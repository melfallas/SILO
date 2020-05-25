using SILO.DesktopApplication.Core.Constants;
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

        public void save(ref LTD_LotteryDraw pDraw)
        {
            using (var context = new SILOEntities())
            {
                //LTD_LotteryDraw matchingDraw = context.LTD_LotteryDraw.Find(pDraw.LTD_Id);
                LTD_LotteryDraw matchingDraw = this.getByTypeAndDate(pDraw.LDT_LotteryDrawType, pDraw.LTD_CreateDate);
                if (matchingDraw != null)
                {
                    matchingDraw = context.LTD_LotteryDraw.Find(matchingDraw.LTD_Id);
                    matchingDraw.LDS_LotteryDrawStatus = pDraw.LDS_LotteryDrawStatus;
                    context.SaveChanges();
                    pDraw = matchingDraw;
                }
                else
                {
                    context.LTD_LotteryDraw.Add(pDraw);
                    context.SaveChanges();
                }
            }
        }

        public LTD_LotteryDraw getByTypeAndDate(long pDrawType, DateTime? pDrawDate)
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

        public List<LTD_LotteryDraw> getUnclosedDraw(long pDrawType, DateTime pDrawDate)
        {
            List<LTD_LotteryDraw> drawList = this.getAll()
                .Where(
                    item =>
                        item.LDT_LotteryDrawType == pDrawType &&
                        item.LTD_CreateDate < pDrawDate &&
                        (
                        item.LDS_LotteryDrawStatus == SystemConstants.DRAW_STATUS_OPENED ||
                        item.LDS_LotteryDrawStatus == SystemConstants.DRAW_STATUS_REOPENED
                        )
                )
                .OrderBy(item => item.LTD_CreateDate)
                .ToList();
            return drawList;
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

        public int getMaxDrawId() {
            int maxId;
            using (var context = new SILOEntities())
            {
                var query = "SELECT IFNULL(MAX(LTD_Id), 0) AS maxDrawId FROM LTD_LotteryDraw ;";
                var maxList = context.Database.SqlQuery<int>(query).ToList();
                maxId = maxList.First();
            }
            return maxId;
        }

        public void updateDrawConsecutive(int pNewConsecutive)
        {
            using (var context = new SILOEntities())
            {
                //var query = "UPDATE SQLITE_SEQUENCE SET seq = " + pNewConsecutive + " WHERE name = 'LTD_LotteryDraw'";
                var query = "INSERT OR REPLACE INTO SQLITE_SEQUENCE(name, seq) VALUES('LTD_LotteryDraw', '" + pNewConsecutive + "');";
                var maxList = context.Database.ExecuteSqlCommand(query);
            }
        }

    }
}
