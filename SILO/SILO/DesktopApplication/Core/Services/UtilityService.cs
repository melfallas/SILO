using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
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

        public static string getPointSaleParameterValue(string pParamName)
        {
            PointSaleParameterRepository posParam = new PointSaleParameterRepository();
            return posParam.getByName(pParamName).PSP_Value;
        }

        public static string getCompanyName()
        {
            return getPointSaleParameterValue(COMPANY_NAME_PARAM);
        }

        public static LPS_LotteryPointSale getPointSale()
        {
            LotteryPointSaleRepository posRepository = new LotteryPointSaleRepository();
            long posId = Convert.ToInt64(getPointSaleParameter(POS_NAME_PARAM).PSP_Value);
            return posRepository.getById(posId);
        }

        public static long getPointSaleId()
        {
            LotteryPointSaleRepository posRepository = new LotteryPointSaleRepository();
            long posId = Convert.ToInt64(getPointSaleParameter(POS_NAME_PARAM).PSP_Value);
            return posRepository.getById(posId).LPS_Id;
        }

        public static string getTicketPrinterName() {
            return getPointSaleParameter(PRINTER_NAME_PARAM).PSP_Value;
        }

        public static string getGlobalId(long pId)
        {
            return UtilityService.fillNumberString(UtilityService.getPointSale().LPS_Id.ToString(), 2) + UtilityService.fillNumberString(pId.ToString(), 4);
        }


        public static string getLargeDate(DateTime pDate) {
            return pDate.ToString("dddd", new System.Globalization.CultureInfo("es-CR")).ToUpper() + " " + pDate.ToString("dd/MM/yyyy");
        }


        public static string fillString(string pStringToFill, int pSpaces, string pFillPattern = " ")
        {
            string filledString = "";
            string originalString = pStringToFill;
            if (originalString.Length < pSpaces)
            {
                int fillCount = pSpaces - originalString.Length;
                for (int i = 0; i < fillCount; i++)
                {
                    filledString += pFillPattern;
                }
            }
            filledString += originalString;
            return filledString;
        }

        public static string fillNumberString(string pStringToFill, int pSpaces)
        {
            return fillString(pStringToFill, pSpaces, "0");
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
                row[valueLabel] = item.LDT_DisplayName;
                tabla.Rows.Add(row);
            }
            return tabla;
        }


        public static string getEncodeQRString(String pNumberListString, DateTime pDate, long pGroup)
        {
            return fillNumberString(pGroup.ToString(), 2) + pDate.ToString("yyyyMMdd") + "N" + pNumberListString;
        }


        public static string compressText(string textToCompress)
        {
            string resultText = "";
            byte[] raw = Encoding.UTF8.GetBytes(textToCompress);
            using (MemoryStream memory = new MemoryStream())
            {
                using (GZipStream gzip = new GZipStream(memory,
                    CompressionMode.Compress, true))
                {
                    gzip.Write(raw, 0, raw.Length);
                }
                byte[] buffer = memory.ToArray();
                resultText = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
            }
            return resultText;
        }

        public static string getPendingTransactions(DateTime pDate, long pGroup)
        {
            LotteryListRepository lotteryListRepository = new LotteryListRepository();
            return lotteryListRepository.getPosTotalListString(pDate, pGroup);
        }

        public static string compressNumberString(string pNumberString)
        {
            pNumberString = pNumberString.Trim();
            string newCompressNumber = "";
            if (pNumberString.Length == 1)
            {
                newCompressNumber = pNumberString;
            }
            else
            {
                int pos = 0;
                int counter = 0;
                bool isCompressible = true;
                int numberSize = pNumberString.Length - 1;
                while (isCompressible && pos < numberSize)
                {
                    if (pNumberString[numberSize - pos] == '0')
                    {
                        counter++;
                    }
                    else
                    {
                        isCompressible = false;
                    }
                    pos++;
                }
                newCompressNumber = pNumberString.Substring(0, numberSize + 1 - counter) + counter;
            }
            return newCompressNumber;
        }


        public static bool[] getProhibitedArray() {
            bool[] prohibitedArray = new bool[100];
            Dictionary<long, bool> prohibitedCollection = new Dictionary<long, bool>();
            LotteryNumberRepository numberRepository = new LotteryNumberRepository();
            // Crear diccionario para realizar la conversión
            foreach (var item in numberRepository.getAll())
            {
                bool prohibited = item.LNR_IsProhibited == 1 ? true : false;
                prohibitedCollection.Add(item.LNR_Id, prohibited);
            }
            // Llenar el array de los prohibidos
            for (int i = 0; i < prohibitedArray.Length; i++)
            {
                bool isProhibited = false;
                int numberId = (i == 0 ? 100 : i);
                if (prohibitedCollection.TryGetValue(numberId, out isProhibited))
                {
                    prohibitedArray[i] = isProhibited;
                }
                else
                {
                    prohibitedArray[i] = false;
                }
            }
            return prohibitedArray;
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
            // Llenar datos del número de lista
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

        public static void printPrizeTicket(LTD_LotteryDraw pDraw, string[] pWinningNumberArray)
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
            // Obtener listado de información de ganadores
            LotteryListRepository lotteryListRepository = new LotteryListRepository();
            prizeTicket.listWinningInfo = lotteryListRepository.getWinningNumbersList(pDraw, pWinningNumberArray);
            prizeTicket.winnerNumbers = pWinningNumberArray;
            ticketPrinter.prizeTicket = prizeTicket;
            // Obtener nombre de impresora y enviar impresión
            string printerName = UtilityService.getTicketPrinterName();
            ticketPrinter.printPrizeTicket(printerName);
        }

        public static Bitmap buildQRCode(string pCodeText, int pBitmapWidth, int pBitmapHeight)
        {
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            QrCode qrCode = new QrCode();
            qrEncoder.TryEncode(pCodeText, out qrCode);

            GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);

            MemoryStream ms = new MemoryStream();
            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
            Bitmap imageTemporal = new Bitmap(ms);
            Bitmap imagen = new Bitmap(imageTemporal, new Size(new Point(pBitmapWidth, pBitmapHeight)));
            return imagen;
        }

        public static void saveProhibitedNumbers(int [] pArray) {
            LotteryNumberRepository pointSaleRepository = new LotteryNumberRepository();
            pointSaleRepository.saveProhibitedNumbers(pArray);
        } 

        public static string getApplicationVersion()
        {
            return "v " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

    }
}
