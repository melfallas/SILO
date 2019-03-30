using SILO.DesktopApplication.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Services
{
    class ListService
    {
        public int[] getDrawTotals(DateTime pDate, long pGroup)
        {
            LotteryListRepository lotteryListRepository = new LotteryListRepository();

            return lotteryListRepository.getDrawListTotals(UtilityService.getPointSaleId(), pDate, pGroup);
        }
    }
}
