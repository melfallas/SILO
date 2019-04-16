using SILO.DesktopApplication.Core.Abstract.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Repositories
{
    class LotteryPrizeFactorRepository : GenericRepository<LPF_LotteryPrizeFactor, Object>
    {
        public LPF_LotteryPrizeFactor getByPointSaleAndGroup(long pSalePoint, long pGroup)
        {
            LPF_LotteryPrizeFactor prizeFactorResult = null;
            List<LPF_LotteryPrizeFactor> prizeFactorList = this.getAll()
                .Where(item =>(item.LPS_LotteryPointSale == pSalePoint) && (item.LDT_LotteryDrawType == pGroup)).ToList();
            if (prizeFactorList.Count > 0)
            {
                prizeFactorResult = prizeFactorList[0];
            }
            return prizeFactorResult;
        }
    }

}
