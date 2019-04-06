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
        private LotteryListRepository listRepository;

        public ListService()
        {
            this.listRepository = new LotteryListRepository();
        }

        public int[] getDrawTotals(DateTime pDate, long pGroup)
        {
            return this.listRepository.getDrawListTotals(UtilityService.getPointSaleId(), pDate, pGroup);
        }


        public LTL_LotteryList getById(long pListId)
        {
            return this.listRepository.getById(pListId);
        }

        public List<LotteryTuple> getListDetail(long pListId)
        {
            return this.listRepository.getTupleListDetail(pListId);
        }

        public void updateList(LTL_LotteryList pList)
        {
            this.listRepository.updateList(pList);
        }

    }
}
