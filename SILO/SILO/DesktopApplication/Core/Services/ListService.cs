using SILO.DesktopApplication.Core.Constants;
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
        private LotteryDrawRepository drawRepository;
        private LotteryListRepository listRepository;

        public ListService()
        {
            this.drawRepository = new LotteryDrawRepository();
            this.listRepository = new LotteryListRepository();
        }

        public int[] getDrawTotals(DateTime pDate, long pGroup)
        {
            return this.listRepository.getDrawListTotals(UtilityService.getPointSaleId(), pDate, pGroup);
        }

        public int[] getDrawPendingSyncTotals(DateTime pDate, long pGroup)
        {
            return this.listRepository.getDrawListTotals(UtilityService.getPointSaleId(), pDate, pGroup, 0, true);
        }

        public int[] getTotalImportBySyncStatus(DateTime pDate, long pGroup, long pSyncStatus)
        {
            return this.listRepository.getDrawListTotals(UtilityService.getPointSaleId(), pDate, pGroup, pSyncStatus);
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

        public void changeSyncStatusToQRUpdated(long pDrawType, DateTime pDrawDate)
        {

            this.changeListStatus(this.drawRepository.getByTypeAndDate(pDrawType, pDrawDate), SystemConstants.SYNC_STATUS_QRUPDATED);
        }

        public void changeListStatus(LTD_LotteryDraw pDraw, long pNewStatus)
        {
            List<LTL_LotteryList> pendingListCollection = this.listRepository.getPosPendingTransactionsByDraw(pDraw);
            this.listRepository.changeListSyncStatus(pendingListCollection, pNewStatus);
        }

        public List<LTL_LotteryList> getPosPendingTransactionsByDate(DateTime? pDrawDate)
        {
            return this.listRepository.getPosPendingTransactionsByDate(pDrawDate);
        }

        public List<LTL_LotteryList> getPosPendingTransactionsByDateAndType(DateTime? pDrawDate, long pDrawType)
        {
            return this.getPosPendingTransactionsByDraw(this.drawRepository.getByTypeAndDate(pDrawType, pDrawDate));
        }

        public List<LTL_LotteryList> getPosPendingTransactionsByDraw(LTD_LotteryDraw pDraw)
        {

            return this.listRepository.getPosPendingTransactionsByDraw(pDraw);
        }

    }
}
