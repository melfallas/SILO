using SILO.DesktopApplication.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Services
{
    public class DrawBalanceService
    {
        private DrawBalanceRepository drawBalanceRepo;

        public DrawBalanceService(){
            this.drawBalanceRepo = new DrawBalanceRepository();
        }

        public DBL_DrawBalance getByDateAndType(long pDrawType, DateTime? pDrawDate)
        {
            DBL_DrawBalance existingDrawBalance = null;
            DrawService drawService = new DrawService();
            LTD_LotteryDraw drawToSave = drawService.getDraw(pDrawType, pDrawDate);
            if (drawToSave != null)
            {
                existingDrawBalance = this.drawBalanceRepo.getByDraw(drawToSave.LTD_Id);
            }
            return existingDrawBalance;
        }

        public void saveBalance(long pDrawType, DateTime? pDrawDate, long pSaleImport = 0, long pPayImport = 0)
        {
            DBL_DrawBalance balanceToSave = null;
            DrawService drawService = new DrawService();
            LTD_LotteryDraw drawToSave = drawService.getDraw(pDrawType, pDrawDate);
            if (drawToSave != null)
            {
                balanceToSave = this.drawBalanceRepo.getByDraw(drawToSave.LTD_Id);
                // Si no existe el balance crearlo
                if (balanceToSave == null)
                {
                    balanceToSave = new DBL_DrawBalance(drawToSave.LTD_Id, pSaleImport, pPayImport);
                }
                this.drawBalanceRepo.save(balanceToSave, balanceToSave.DBL_Id, (e1, e2) => e1.copy(e2));
            }
        }

    }
}
