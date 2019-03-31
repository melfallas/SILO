using SILO.DesktopApplication.Core.Abstract.Generic;
using SILO.DesktopApplication.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Repositories
{
    class LotteryPointSaleRepository : GenericRepository<LPS_LotteryPointSale, Object>
    {
        /*
        public List<LPS_LotteryPointSale> getAll()
        {
            List<LPS_LotteryPointSale> posList = null;
            using (var context = new SILOEntities())
            {
                posList = context.LPS_LotteryPointSale.ToList();
            }
            return posList;
        }

        public LPS_LotteryPointSale getById(long pId)
        {
            LPS_LotteryPointSale posValue = null;
            using (var context = new SILOEntities())
            {
                posValue = context.LPS_LotteryPointSale.Find(pId);
            }
            return posValue;
        }


        public LPS_LotteryPointSale save(LPS_LotteryPointSale pSalePoint)
        {
            LPS_LotteryPointSale findedSalePoint = null;
            using (var context = new SILOEntities())
            {
                if (pSalePoint.LPS_Id != 0)
                {
                    findedSalePoint = context.LPS_LotteryPointSale.Find(pSalePoint.LPS_Id);
                    if (findedSalePoint == null)
                    {
                        findedSalePoint = pSalePoint;
                        context.LPS_LotteryPointSale.Add(pSalePoint);
                    }
                    else
                    {
                        findedSalePoint.copy(pSalePoint);
                    }
                    context.SaveChanges();
                }
            }
            return findedSalePoint;
        }

        public void saveList(List<LPS_LotteryPointSale> pSalePointList)
        {
            foreach (LPS_LotteryPointSale pos in pSalePointList)
            {
                this.save(pos);
            }
        }
        */

        // Método que registra la persistencia de una lista de objetos
        public void saveList(List<LPS_LotteryPointSale> pEntityList)
        {
            foreach (LPS_LotteryPointSale entity in pEntityList)
            {
                entity.SYS_SynchronyStatus = SystemConstants.SYNC_STATUS_COMPLETED;
                this.save(entity, entity.LPS_Id, (e1, e2) => e1.copy(e2));
            }
        }


    }
}
