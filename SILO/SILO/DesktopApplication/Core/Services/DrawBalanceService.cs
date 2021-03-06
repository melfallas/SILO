﻿using SILO.DesktopApplication.Core.Repositories;
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
                    balanceToSave = new DBL_DrawBalance();
                    balanceToSave.LTD_LotteryDraw = drawToSave.LTD_Id;
                }
                balanceToSave.DBL_SaleImport = pSaleImport;
                balanceToSave.DBL_PayImport = pPayImport;
                this.drawBalanceRepo.save(balanceToSave, balanceToSave.DBL_Id, (e1, e2) => e1.copy(e2));
            }
        }

        public void saveDrawSaleImport(long pDrawType, DateTime pDrawDate)
        {
            // Obtener total de venta del sorteo
            ListService listService = new ListService();
            long saleImport = listService.getDrawSaleImport(ParameterService.getSalePointId(), pDrawDate, pDrawType);
            // Almacenar importe de premio para el sorteo
            DrawBalanceService drawBalanceService = new DrawBalanceService();
            drawBalanceService.saveBalance(pDrawType, pDrawDate, saleImport);
        }

    }
}
