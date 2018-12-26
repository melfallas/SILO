using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO
{
    public static class UtilityService
    {
        public const string POS_NAME_PARAM = "Sucursal";
        public const string COMPANY_NAME_PARAM = "Nombre_Empresa";
        public const string PRINTER_NAME_PARAM = "Nombre_Impresora";

        public static PSP_PointSaleParameter getPointSaleParameter(string pParamName) {
            PointSaleParameterRepository posParam = new PointSaleParameterRepository();
            return posParam.getByName(pParamName);
        }

        public static LPS_LotteryPointSale getPointSale()
        {
            LotteryPointSaleRepository posRepository = new LotteryPointSaleRepository();
            long posId = Convert.ToInt64(getPointSaleParameter(POS_NAME_PARAM).PSP_Value);
            return posRepository.getById(posId);
        }

        public static string getTicketPrinterName() {
            return getPointSaleParameter(PRINTER_NAME_PARAM).PSP_Value;
        }

        public static string getCompanyName()
        {
            return getPointSaleParameter(COMPANY_NAME_PARAM).PSP_Value;
        }


        public static DataTable buildDataTable() {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("id");
            tabla.Columns.Add("display");

            DataRow row = tabla.NewRow();
            row["id"] = "0";
            row["display"] = "Seleccione un grupo";
            tabla.Rows.Add(row);

            row = tabla.NewRow();
            row["id"] = "1";
            row["display"] = "Día";
            tabla.Rows.Add(row);
            row = tabla.NewRow();
            row["id"] = "2";
            row["display"] = "Noche";
            tabla.Rows.Add(row);
            return tabla;
        }

        public static DataTable drawTypeDataTable(String idLabel, String valueLabel)
        {
            LotteryDrawTypeRepository lotteryDrawTypeReposytory = new LotteryDrawTypeRepository();
            List<LDT_LotteryDrawType> drawTypeList = lotteryDrawTypeReposytory.getAll();

            DataTable tabla = new DataTable();
            tabla.Columns.Add(idLabel);
            tabla.Columns.Add(valueLabel);
            // Opción por defecto
            DataRow row = tabla.NewRow();
            row[idLabel] = "0";
            row[valueLabel] = "SELECCIONE UN GRUPO";
            tabla.Rows.Add(row);
            // Llenado del ComboBox
            foreach (LDT_LotteryDrawType item in drawTypeList)
            {
                row = tabla.NewRow();
                row[idLabel] = item.LDT_Id;
                row[valueLabel] = item.LDT_Description;
                tabla.Rows.Add(row);
            }
            return tabla;
        }

        public static void printList(LTL_LotteryList pNumberList)
        {
            // Configurar impresión para Ticket de Venta
            TicketPrinter ticketPrinter = new TicketPrinter();
            SaleTicket saleTicket = new SaleTicket();
            saleTicket.companyName = UtilityService.getCompanyName();
            // Obtener datos del punto de venta
            LPS_LotteryPointSale pointSale = UtilityService.getPointSale();
            saleTicket.pointSaleName = pointSale.LPS_DisplayName;
            // Obtener datos del sorteo
            LotteryDrawRepository drawRepo = new LotteryDrawRepository();
            LTD_LotteryDraw drawObject = drawRepo.getById(pNumberList.LTD_LotteryDraw);
            saleTicket.drawDate = drawObject.LTD_CreateDate;
            // Obtener datos de tipo de sorteo
            LotteryDrawTypeRepository drawTypeRepo = new LotteryDrawTypeRepository();
            LDT_LotteryDrawType drawType = drawTypeRepo.getById(drawObject.LDT_LotteryDrawType);
            saleTicket.drawTypeCode = drawType.LDT_Code;

            saleTicket.createDate = DateTime.Now;
            saleTicket.ticketId = pNumberList.LTL_Id;
            saleTicket.globalId = pointSale.LPS_Id + "" + saleTicket.ticketId;

            saleTicket.customerName = pNumberList.LTL_CustomerName;
            // Obtener detalle de la lista procesada
            LotteryListRepository listRepo = new LotteryListRepository();
            saleTicket.listNumberDetail = listRepo.getListDetail(pNumberList.LTL_Id);
            ticketPrinter.saleTicket = saleTicket;
            // Obtener nombre de impresora y enviar impresión
            string printerName = UtilityService.getTicketPrinterName();
            ticketPrinter.printLotterySaleTicket(printerName);
        }

    }
}
