using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Repositories
{
    class LotteryPointSaleRepository
    {
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
    }
}
