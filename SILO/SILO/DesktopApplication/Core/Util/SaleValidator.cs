using SILO.DesktopApplication.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Util
{
    class SaleValidator
    {
        public bool validatePrizeFactor(long pGroupId, Func<long, bool> pProcessResponseFunction) {
            bool validFactor = false;
            PrizeFactorService prizeFactorService = new PrizeFactorService();
            LPF_LotteryPrizeFactor prizeFactor = prizeFactorService.getByGroup(pGroupId);
            if (prizeFactor == null)
            {
                ConcreteMessageService.displayPrizeFactorNotFoundMessage();
            }
            else
            {
                validFactor = pProcessResponseFunction(pGroupId);
            }
            return validFactor;
        }

        public bool validatePrizeFactorAsync(long pGroupId)
        {
            bool validFactor = false;
            PrizeFactorService prizeFactorService = new PrizeFactorService();
            LPF_LotteryPrizeFactor prizeFactor = prizeFactorService.getByGroup(pGroupId);
            if (prizeFactor != null)
            {
                validFactor = true;
            }
            return validFactor;
         }

        public bool isClosingDraw(long pGroupId, DateTime pDrawDate)
        {
            bool isClosing = false;
            DrawService drawService = new DrawService();
            if (drawService.isDrawClosed(pGroupId, pDrawDate))
            {
                isClosing = true;
            }
            return isClosing;
        }



        /*
        public async Task<bool> validatePrizeFactorAsync(long pGroupId, Func<long, Task<bool>> pProcessResponseFunction)
        {
            bool validFactor = false;
            PrizeFactorService prizeFactorService = new PrizeFactorService();
            LPF_LotteryPrizeFactor prizeFactor = prizeFactorService.getByGroup(pGroupId);
            if (prizeFactor == null)
            {
                ConcreteMessageService.displayPrizeFactorNotFoundMessage();
            }
            else
            {
                validFactor = await pProcessResponseFunction(pGroupId);
            }
            return validFactor;
         }
         */
    }
}
