using SILO.DesktopApplication.Core.Repositories;
using SILO.DesktopApplication.Core.SystemConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Services
{
    class TicketPrintService
    {
        private LotteryListRepository listRepo;
        private LotteryDrawTypeRepository drawTypeRepo;

        public int type { get; set; }

        public TicketPrintService() {
            LotteryListRepository listRepo = new LotteryListRepository();
            LotteryDrawTypeRepository drawTypeRepo = new LotteryDrawTypeRepository();
        }

        public void printList(LTL_LotteryList pNumberList)
        {
            // Configurar impresión para Ticket de Venta
            SaleTicket saleTicket = new SaleTicket();
            saleTicket.companyName = UtilityService.getCompanyName();
            // Obtener datos del punto de venta
            LPS_LotteryPointSale pointSale = UtilityService.getPointSale();
            saleTicket.pointSaleName = pointSale.LPS_DisplayName;
            // Obtener usuario vendedor
            saleTicket.userName = SystemSession.username;
            // Obtener datos del sorteo
            LotteryDrawRepository drawRepo = new LotteryDrawRepository();
            LTD_LotteryDraw drawObject = drawRepo.getById(pNumberList.LTD_LotteryDraw);
            saleTicket.drawDate = drawObject.LTD_CreateDate;
            // Obtener datos de tipo de sorteo
            this.drawTypeRepo = new LotteryDrawTypeRepository();
            LDT_LotteryDrawType drawType = drawTypeRepo.getById(drawObject.LDT_LotteryDrawType);
            saleTicket.drawTypeCode = drawType.LDT_Code;
            // Llenar datos del número de lista
            saleTicket.createDate = DateTime.Now;
            saleTicket.ticketId = pNumberList.LTL_Id;
            saleTicket.globalId = pointSale.LPS_Id + "" + saleTicket.ticketId;
            saleTicket.customerName = pNumberList.LTL_CustomerName;
            // Obtener detalle de la lista procesada
            this.listRepo = new LotteryListRepository();
            saleTicket.listNumberDetail = listRepo.getTupleListDetail(pNumberList.LTL_Id);
            // Crear instancia de impresora y asignar el ticket
            TicketPrinter ticketPrinter = new TicketPrinter();
            ticketPrinter.saleTicket = saleTicket;
            // Obtener nombre de impresora y enviar impresión
            string printerName = UtilityService.getTicketPrinterName();
            ticketPrinter.printLotterySaleTicket(printerName);
        }
    }
}
