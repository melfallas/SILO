using SILO.DesktopApplication.Core.Constants;
using SILO.DesktopApplication.Core.Model.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Services
{
    public class DrawService
    {
        private LotteryDrawRepository drawRepo;

        public DrawService()
        {
            this.drawRepo = new LotteryDrawRepository();
        }

        public void changeDrawStatus(long pDrawType, DateTime? pDrawDate, long pNewStatus)
        {
            LTD_LotteryDraw existingDraw = this.drawRepo.getByTypeAndDate(pDrawType, pDrawDate);
            if (existingDraw != null)
            {
                existingDraw.LDS_LotteryDrawStatus = pNewStatus;
                this.drawRepo.save(ref existingDraw);
            }
        }

        public bool isDrawClosed(long pDrawType, DateTime? pDrawDate)
        {
            bool closedDraw = false;
            LTD_LotteryDraw existingDraw = this.drawRepo.getByTypeAndDate(pDrawType, pDrawDate);
            if (existingDraw != null)
            {
                closedDraw = existingDraw.LDS_LotteryDrawStatus == SystemConstants.DRAW_STATUS_CLOSED ? true : false;
            }
            return closedDraw;
        }

        public LTD_LotteryDraw getDraw(long pDrawType, DateTime? pDrawDate)
        {
            return this.drawRepo.getByTypeAndDate(pDrawType, pDrawDate);
        }

        public List<LTD_LotteryDraw> getUnclosedDraw(long pDrawType, DateTime pDrawDate)
        {
            return this.drawRepo.getUnclosedDraw(pDrawType, pDrawDate);
        }

        public int getMaxDrawId() {
            return this.drawRepo.getMaxDrawId();
        }

        public void updateDrawConsecutive(int pNewConsecutive)
        {
            this.drawRepo.updateDrawConsecutive(pNewConsecutive);
        }

        public int getMaxDrawServerId(long pPosId)
        {
            ServerConnectionService connection = new ServerConnectionService();
            ServiceResponseResult responseResult = connection.getMaxDrawServerId(pPosId);
            return Convert.ToInt32(responseResult.result);
        }

    }
}
