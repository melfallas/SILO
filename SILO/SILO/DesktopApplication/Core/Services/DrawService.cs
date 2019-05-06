using SILO.DesktopApplication.Core.Constants;
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

    }
}
