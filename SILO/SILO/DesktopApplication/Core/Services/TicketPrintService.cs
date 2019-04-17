using SILO.DesktopApplication.Core.Model.TicketModel;
using SILO.DesktopApplication.Core.Repositories;
using SILO.DesktopApplication.Core.SystemConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Services
{
    public class TicketPrintService
    {
        private LotteryListRepository listRepo;
        private LotteryDrawTypeRepository drawTypeRepo;

        public int type { get; set; }

        public static int SALE_TICKET_TYPE = SaleTicket.SALE_TICKET_TYPE;
        public static int COPY_TICKET_TYPE = SaleTicket.COPY_TICKET_TYPE;
        public static int REPRINT_TICKET_TYPE = SaleTicket.REPRINT_TICKET_TYPE;
        public static int ERASE_TICKET_TYPE = SaleTicket.ERASE_TICKET_TYPE;

        public TicketPrintService() {
            LotteryListRepository listRepo = new LotteryListRepository();
            LotteryDrawTypeRepository drawTypeRepo = new LotteryDrawTypeRepository();
        }

        // Método para imprimir un ticket de venta de una lista
        public void printList(LTL_LotteryList pNumberList, int pTicketType = 0)
        {
            // Configurar impresión para Ticket de Venta
            SaleTicket saleTicket = new SaleTicket(pTicketType);
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
            // Obtener datos de los premios
            PrizeFactorService prizeFactorService = new PrizeFactorService();
            LPF_LotteryPrizeFactor prizeFactor = prizeFactorService.getByGroup(drawType.LDT_Id);
            if (prizeFactor != null)
            {
                saleTicket.prizeFactorArray[0] = prizeFactor.LPF_FirtsPrizeFactor;
                saleTicket.prizeFactorArray[1] = prizeFactor.LPF_SecondPrizeFactor;
                saleTicket.prizeFactorArray[2] = prizeFactor.LPF_ThirdPrizeFactor;
            }
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

        // Método para imprimir la lista de los números premiados y ganadores
        public void printPrizeTicket(LTD_LotteryDraw pDraw, string[] pWinningNumberArray, bool sendToPrint = true)
        {
            // Configurar impresión para Ticket de Venta
            TicketPrinter ticketPrinter = new TicketPrinter();
            PrizeTicket prizeTicket = new PrizeTicket();
            prizeTicket.companyName = UtilityService.getCompanyName();
            prizeTicket.title = "NÚMEROS PREMIADOS";
            // Obtener datos del punto de venta
            LPS_LotteryPointSale pointSale = UtilityService.getPointSale();
            prizeTicket.pointSaleName = pointSale.LPS_DisplayName;
            prizeTicket.drawDate = pDraw.LTD_CreateDate;
            // Obtener datos de tipo de sorteo
            LotteryDrawTypeRepository drawTypeRepo = new LotteryDrawTypeRepository();
            LDT_LotteryDrawType drawType = drawTypeRepo.getById(pDraw.LDT_LotteryDrawType);
            prizeTicket.drawTypeCode = drawType.LDT_Code;
            // Llenar datos del número de lista
            prizeTicket.createDate = DateTime.Now;
            // Obtener datos de los premios
            PrizeFactorService prizeFactorService = new PrizeFactorService();
            LPF_LotteryPrizeFactor prizeFactor = prizeFactorService.getByGroup(drawType.LDT_Id);
            if (prizeFactor != null)
            {
                prizeTicket.prizeFactorArray[0] = prizeFactor.LPF_FirtsPrizeFactor;
                prizeTicket.prizeFactorArray[1] = prizeFactor.LPF_SecondPrizeFactor;
                prizeTicket.prizeFactorArray[2] = prizeFactor.LPF_ThirdPrizeFactor;
            }
            // Obtener listado de información de ganadores
            LotteryListRepository listRepository = new LotteryListRepository();
            prizeTicket.listWinningInfo = listRepository.getWinningNumbersList(pDraw, pWinningNumberArray);
            prizeTicket.winnerNumbers = pWinningNumberArray;
            ticketPrinter.prizeTicket = prizeTicket;
            // Obtener nombre de impresora y enviar impresión
            string printerName = UtilityService.getTicketPrinterName();
            ticketPrinter.printPrizeTicket(printerName);
            Console.Write(ticketPrinter.ticketStringText);
        }

    }
}
