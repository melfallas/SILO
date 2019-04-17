using SILO.DesktopApplication.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Services
{
    class PrizeFactorService
    {
        private LotteryPrizeFactorRepository prizeFactorRepo;

        public PrizeFactorService() {
            this.prizeFactorRepo = new LotteryPrizeFactorRepository();
        }

        public LPF_LotteryPrizeFactor getByGroup(long pGroup)
        {
            return this.prizeFactorRepo.getByPointSaleAndGroup(UtilityService.getPointSaleId(), pGroup);
        }

        public LPF_LotteryPrizeFactor getByPointSaleAndGroup(long pSalePoint, long pGroup)
        {
            return this.prizeFactorRepo.getByPointSaleAndGroup(pSalePoint, pGroup);
        }

    }
}
