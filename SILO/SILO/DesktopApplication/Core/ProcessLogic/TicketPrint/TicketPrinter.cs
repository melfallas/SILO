using System;
//using LibPrintTicket;
using System.Drawing;
using System.Collections;
using System.Drawing.Printing;
using SILO.Core.Constants;
using SILO.DesktopApplication.Core.Services;
using SILO.DesktopApplication.Core.Model.TicketModel;
using SILO.DesktopApplication.Core.Model.NumberModel;

namespace SILO
{
    public class TicketPrinter
    {
        #region Atributos Privados

        private ArrayList headerLines = new ArrayList();

        private ArrayList subHeaderLines = new ArrayList();

        private ArrayList items = new ArrayList();

        private ArrayList totales = new ArrayList();

        private ArrayList footerLines = new ArrayList();

        private Image headerImage;

        private int count;

        private int imageHeight;
        private float leftMargin;
        private float topMargin = 3f;


        private float topPrintMargin = 0;


        public string ticketStringText { get; set; }


        private static string fontName = "Lucida Console";
        private int fontSize = 7;

        // Máximo de Caracteres
        private static int saleTicketSmallMaxChar = 24;
        private static int saleTicketMediumMaxChar = 30;
        private static int saleTicketLargeMaxChar = 38;
        // Tamaño de Fuente
        private static int saleTicketSmallFontSize = 9;
        private static int saleTicketMediumFontSize = 11;
        private static int saleTicketLargeFontSize = 14;


        //private static int maxChar = 35;
        private int maxChar = saleTicketSmallMaxChar;
        private int maxCharDescription = saleTicketSmallMaxChar - 4;
        private int defaultTicketFontSize = saleTicketSmallFontSize;
        private string defaultTicketFontName = fontName;


        private int prizeTicketFontSize = 7;

        private Font printFont;

        private SolidBrush myBrush = new SolidBrush(Color.Black);

        private Graphics gfx;

        private string line;

        #endregion

        #region Propiedades de los Tickets

        public SaleTicket saleTicket { get; set; }
        public PrizeTicket prizeTicket { get; set; }

        public long saleImport { get; set; }
        public long prizeImport { get; set; }

        #endregion


        public TicketPrinter() {
            this.ticketStringText = "";
        }

        private void addTicketStringLine(string pLineText)
        {
            this.ticketStringText += pLineText + "\n";
        }


        #region Métodos Anteriores

        public Image HeaderImage
        {
            get
            {
                return headerImage;
            }
            set
            {
                if (headerImage != value)
                {
                    headerImage = value;
                }
            }
        }

        public int MaxChar
        {
            get
            {
                return maxChar;
            }
            set
            {
                if (value != maxChar)
                {
                    maxChar = value;
                }
            }
        }

        public int MaxCharDescription
        {
            get
            {
                return maxCharDescription;
            }
            set
            {
                if (value != maxCharDescription)
                {
                    maxCharDescription = value;
                }
            }
        }

        public int FontSize
        {
            get
            {
                return fontSize;
            }
            set
            {
                if (value != fontSize)
                {
                    fontSize = value;
                }
            }
        }

        public string FontName
        {
            get
            {
                return fontName;
            }
            set
            {
                if (value != fontName)
                {
                    fontName = value;
                }
            }
        }

        public void AddHeaderLine(string line)
        {
            headerLines.Add(line);
        }

        public void AddSubHeaderLine(string line)
        {
            subHeaderLines.Add(line);
        }

        public void AddFooterLine(string line)
        {
            footerLines.Add(line);
        }

        private string AlignRightText(int lenght)
        {
            string text = "";
            int num = maxChar - lenght;
            for (int i = 0; i < num; i++)
            {
                text += " ";
            }
            return text;
        }

        private string DottedLine()
        {
            string text = "";
            for (int i = 0; i < maxChar; i++)
            {
                text += "=";
            }
            return text;
        }

        public bool PrinterExists(string impresora)
        {
            foreach (string installedPrinter in PrinterSettings.InstalledPrinters)
            {
                if (impresora == installedPrinter)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion


        #region Métodos Principales
        /*
        public void printPrizeTicket(string impresora)
        {
            printFont = new Font(fontName, (float)fontSize, FontStyle.Regular);
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrinterSettings.PrinterName = impresora;
            printDocument.PrintPage += printPrizePage;
            printDocument.Print();
        }

        private void printPrizePage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            gfx = e.Graphics;
            this.generatePrizeHeader();
            this.generatePrizeList();
            //this.generatePrizeFooter();
            if (headerImage != null)
            {
                HeaderImage.Dispose();
                headerImage.Dispose();
            }
        }
        */
        #endregion


        #region Utilitarios

        public void addLineHeight(float pFontHeight = 0) {
            this.topPrintMargin += pFontHeight;
            this.topPrintMargin += printFont.GetHeight(gfx);
        }

        public string formatNumber(int pNumberToFormat)
        {
            return pNumberToFormat.ToString("#,#", System.Globalization.CultureInfo.InvariantCulture);
        }

        public string formatNumber(long pNumberToFormat)
        {
            return pNumberToFormat.ToString("#,#", System.Globalization.CultureInfo.InvariantCulture);
        }

        public string formatNumber(string pNumberToFormat)
        {
            return Convert.ToInt64(pNumberToFormat).ToString("#,#", System.Globalization.CultureInfo.InvariantCulture);
        }

        #endregion


        #region Prize Ticket

        public void printPrizeTicket(string impresora, bool pSendToPrint)
        {
            this.maxChar = 31;
            this.printFont = new Font(fontName, (float) prizeTicketFontSize, FontStyle.Regular);
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrinterSettings.PrinterName = impresora;
            printDocument.PrintPage += printPrizePage;
            //if (pSendToPrint)
            if (true)
            {
                printDocument.Print();
            }
        }

        private void printPrizePage(object sender, PrintPageEventArgs e)
        {
            this.ticketStringText = "";
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            gfx = e.Graphics;
            this.generatePrizeHeader();
            this.generatePrizeList();
            this.generatePrizeFooter();
            if (headerImage != null)
            {
                HeaderImage.Dispose();
                headerImage.Dispose();
            }
        }

        private void generatePrizeHeader()
        {
            string line = "";
            string printTime = this.prizeTicket.createDate.ToString("HH:mm");
            string printDate = this.prizeTicket.createDate.ToString("dd-MM");
            string drawDate = this.prizeTicket.drawDate.ToString("dddd", new System.Globalization.CultureInfo("es-CR")).ToUpper() + " " + this.prizeTicket.drawDate.ToString("dd/MM/yyyy");
            // Imprimir líneas de encabezado
            this.setPrintFont(this.defaultTicketFontName, this.defaultTicketFontSize + 2, FontStyle.Bold);
            this.drawCenterLine(this.prizeTicket.companyName);
            this.drawCenterLine(this.prizeTicket.title);
            line = "**" + this.prizeTicket.drawTypeCode + "**";
            this.drawCenterLine(line);
            this.drawCenterLine(drawDate);
            this.DrawEspacio();
            this.setPrintFont(this.defaultTicketFontName, this.defaultTicketFontSize + 1, FontStyle.Bold);
            line = "NÚMEROS: -";
            for (int i = 0; i < this.prizeTicket.winnerNumbers.Length; i++)
            {
                line += (this.prizeTicket.winnerNumbers[i] == "" ? "NA-" : this.prizeTicket.winnerNumbers[i] + "-" );
            }
            this.drawCenterLine(line);
            line = "PREMIOS: -";
            for (int i = 0; i < this.prizeTicket.prizeFactorArray.Length; i++)
            {
                string prizeFactorString = ((int) this.prizeTicket.prizeFactorArray[i]).ToString();
                line += (prizeFactorString == "" ? "NA-" : this.fillString(prizeFactorString, 2) + "-");
            }
            this.drawCenterLine(line);
            line = "SUC: " + this.prizeTicket.pointSaleName;
            this.drawCenterLine(line);
            this.setPrintFont(this.defaultTicketFontName, this.defaultTicketFontSize - 2, FontStyle.Regular);
            this.drawCenterLine("SILO v " + UtilityService.getApplicationSimpleVersion());
            this.DrawEspacio();
            this.setPrintFont(this.defaultTicketFontName, this.defaultTicketFontSize - 1, FontStyle.Regular);
            line = "" + printTime + "                " + printDate + "";
            this.drawCenterLine(line);
        }

        private void generatePrizeList()
        {
            this.setPrintFont(this.defaultTicketFontName, this.defaultTicketFontSize, FontStyle.Bold);
            //this.generateLine("=");
            this.drawCenterLine("", 0, "-");
            string listHeaders = "No "
                + this.fillString("MONTO", 7)
                + this.fillString("PREMIO", 11)
                ;
            this.drawLine(listHeaders);
            this.drawCenterLine("", 0, "-");
            this.setPrintFont(this.defaultTicketFontName, this.defaultTicketFontSize, FontStyle.Bold);
            this.DrawEspacio();
            this.printPriceList();
        }

        private void printPriceList()
        {
            this.saleImport = 0;
            this.prizeImport = 0;
            this.setPrintFont(this.defaultTicketFontName, this.defaultTicketFontSize, FontStyle.Regular);
            foreach (WinningNumberInfo item in this.prizeTicket.listWinningInfo)
            {
                // Línea de números e importes
                int prizeOrder = item.prizeOrder;
                int prizeFactor = (int) this.prizeTicket.prizeFactorArray[prizeOrder - 1];
                long payImport = item.saleImport * prizeFactor;
                string localTicketId = this.fillString(item.localId.ToString(), 4, "0");
                string globalTicketId = UtilityService.getGlobalId(item.localId);
                string itemList =
                    this.fillString(item.numberCode, 2, "0")                                // Número Ganador
                    + " " + this.fillString(this.formatNumber(item.saleImport), 7) + " "    // Importe de la Venta
                    + this.fillString(this.formatNumber(payImport), 11)                     // Importe Pagado
                    ;
                this.drawLine(itemList);
                // Línea de número de Ticket
                this.setPrintFont(this.defaultTicketFontName, this.defaultTicketFontSize + 1, FontStyle.Bold);
                itemList = "->" + globalTicketId
                    + "/" + localTicketId
                    ;
                itemList += item.customerName.Trim() == "" ? "" : " ->" + this.limitString(item.customerName, 6);
                //this.drawLine(itemList);
                this.addTicketStringLine(itemList);
                this.drawPrizeTicketLine(globalTicketId, localTicketId, item.customerName);
                this.setPrintFont(this.defaultTicketFontName, this.defaultTicketFontSize, FontStyle.Regular);
                this.DrawEspacio();
                this.saleImport += item.saleImport;
                this.prizeImport += payImport;
            }
        }

        // Método que dibuja la linea que se le envía como parámetro
        private void drawPrizeTicketLine(string pGlobalId, string pLocalTicketId, string pCustomerName)
        {
            int oldSize = this.maxChar;
            Font oldPrintFont = this.printFont;
            //this.setFontAndMaxChar(this.defaultTicketFontSize - 1, FontStyle.Regular);
            //gfx.DrawString("->", printFont, myBrush, leftMargin, YPosition(), new StringFormat());
            this.setFontAndMaxChar(this.defaultTicketFontSize + 2, FontStyle.Bold);
            gfx.DrawString(pGlobalId, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
            this.setFontAndMaxChar(this.defaultTicketFontSize, FontStyle.Regular);
            gfx.DrawString("        /" + pLocalTicketId, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
            if (pCustomerName.Trim() != "")
            {
                this.setFontAndMaxChar(this.defaultTicketFontSize - 1, FontStyle.Regular);
                gfx.DrawString("               ->" + this.limitString(pCustomerName, 10), printFont, myBrush, leftMargin, YPosition(), new StringFormat());
            }
            this.printFont = oldPrintFont;
            this.addLineHeight();
            count++;
            this.maxChar = oldSize;
        }

        private string limitString(string pStringToProcess, int pCharNumber) {
            return (pStringToProcess.Length <= pCharNumber ? pStringToProcess : pStringToProcess.Substring(0, pCharNumber));
        }

        private void setFontAndMaxChar(int pFontSize, FontStyle pfontStyle)
        {
            this.setPrintFont(this.defaultTicketFontName, pFontSize, pfontStyle);
            this.maxChar = this.getMaxCharByFontSize((int)this.printFont.Size);
        }

        private void printPriceListBK()
        {
            foreach (WinningNumberInfo item in this.prizeTicket.listWinningInfo)
            {
                string itemList =
                    this.fillString(item.numberCode, 2, "0")
                    + " " + this.fillString(this.formatNumber(item.saleImport), 6) + " "
                    + this.fillString(this.formatNumber(item.prizeImport), 7)
                    + "->" + UtilityService.getGlobalId(item.localId)
                    + "/" + item.localId
                    //+ "123456789"
                    ;
                this.drawLine(itemList);
                string customerName = (item.customerName.Trim() == "" ? GeneralConstants.NO_NAME_LABEL : item.customerName);
                this.drawLine("--> " + customerName);
                this.DrawEspacio();
            }
        }


        private void generatePrizeFooter() {
            this.setPrintFont(this.defaultTicketFontName, this.defaultTicketFontSize, FontStyle.Bold);
            //this.generateLine("=");
            this.drawCenterLine("", 0, "-");
            this.setPrintFont(this.defaultTicketFontName, this.defaultTicketFontSize, FontStyle.Regular);
            //long saleImport = this.prizeTicket.getTotalSaleImport();
            //long prizeImport = this.prizeTicket.getTotalPrizeImport();
            long saleImport = this.saleImport;
            long prizeImport = this.prizeImport;
            //string line = "**TOTAL   " + this.formatNumber(saleImport) + "      " + this.formatNumber(prizeImport);
            string line =
                    "TOTAL"
                    + this.fillString(this.formatNumber(saleImport), 7) + " "    // Importe Total de la Venta
                    + this.fillString(this.formatNumber(prizeImport), 11)              // Importe Total Pagado
                    ;
            this.drawCenterLine(line);
            // Imprimir líneas de espacio finales
            this.printFinalLines();
        }

        #endregion


        #region Sale Ticket

        private void setPrintFont(string pFontName, int pFontSize, FontStyle pFontStyle) {
            printFont = new Font(pFontName, (float)pFontSize, pFontStyle);
        }

        private int getMaxCharByFontSize(int pFontSize) {
            int size = 24;
            switch (pFontSize)
            {
                case 7:
                    size = 30;
                    break;
                case 8:
                    size = 27;
                    break;
                case 9:
                    size = 24;
                    break;
                case 10:
                    size = 22;
                    break;
                case 11:
                    size = 20;
                    break;
                default:
                    break;
            }
            return size;
        }

        public void printLotterySaleTicket(string impresora)
        {
            //printFont = new Font(fontName, (float)saleTicketSmallFontSize, FontStyle.Regular);
            this.setPrintFont(this.defaultTicketFontName, this.defaultTicketFontSize, FontStyle.Regular);
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrinterSettings.PrinterName = impresora;
            printDocument.PrintPage += saleTicketPage;
            printDocument.Print();
        }

        private void saleTicketPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            gfx = e.Graphics;
            this.generateSaleTicketHeader();
            this.generateSaleTicketList();
            this.generateSaleTicketFooter();
            if (headerImage != null)
            {
                HeaderImage.Dispose();
                headerImage.Dispose();
            }
        }

        private void generateSaleTicketHeader()
        {
            // Obtener parámetros de encabezado
            string printTime = this.saleTicket.createDate.ToString("HH:mm");
            string printDate = this.saleTicket.createDate.ToString("dd-MM");
            string drawDate = this.saleTicket.drawDate.ToString("dddd", new System.Globalization.CultureInfo("es-CR")).ToUpper() + " " + this.saleTicket.drawDate.ToString("dd/MM/yyyy");
            string ticketId = this.fillString(this.saleTicket.ticketId.ToString(), 4, "0");
            string globalId = this.fillString(UtilityService.getGlobalId(this.saleTicket.ticketId), 6, "0");            
            // Iniciar con la impresión
            this.setPrintFont(this.defaultTicketFontName, this.defaultTicketFontSize, FontStyle.Regular);
            this.drawCenterLine(printDate);
            // Imprimir tipo de ticket
            string titleLegend = this.saleTicket.getTicketType().Trim();
            if (titleLegend != "")
            {
                this.drawCenterLine("<< " + titleLegend + " >>");
            }
            string line = "/" + printTime + "/----------/" + ticketId + "/";
            this.drawCenterLine(line);            
            // Imprimir nombre de la compañía
            this.setPrintFont(this.defaultTicketFontName, this.defaultTicketFontSize + 2, FontStyle.Bold);
            this.drawCenterLine(this.saleTicket.companyName);
            // Imprimir nombre del cliente
            this.setPrintFont(this.defaultTicketFontName, this.defaultTicketFontSize - 2, FontStyle.Regular);
            //string customerName = this.saleTicket.customerName.Trim() == "" ? GeneralConstants.NO_NAME_LABEL : this.saleTicket.customerName;
            string customerName = this.saleTicket.customerName;
            if (customerName.Trim() != "")
            {
                line = "<< " + customerName + " >>";
                this.drawCenterLine(line);
            }
            // Imprimir tipo de sorteo
            this.setPrintFont(this.defaultTicketFontName, this.defaultTicketFontSize + 2, FontStyle.Bold);
            line = "**" + this.saleTicket.drawTypeCode + "**";
            this.drawCenterLine(line);
            // Imprimir fecha de sorteo
            this.drawCenterLine(drawDate);
            //this.drawCenterLine("");
            this.spaceLine(this.defaultTicketFontSize);
            // Imprimir sucursal e identificador de cliente
            this.setPrintFont(this.defaultTicketFontName, this.defaultTicketFontSize, FontStyle.Bold);
            line = "USU: " + this.saleTicket.userName + "  CL:" + globalId;
            this.drawCenterLine(line);
            // Imprimir sucursal
            line = "SUC: " + this.saleTicket.pointSaleName;
            this.drawCenterLine(line);
            this.setPrintFont(this.defaultTicketFontName, this.defaultTicketFontSize - 2, FontStyle.Regular);
            this.drawCenterLine("SILO v " + UtilityService.getApplicationSimpleVersion());
        }

        private void generateSaleTicketList()
        {
            this.setPrintFont(this.defaultTicketFontName, this.defaultTicketFontSize, FontStyle.Regular);
            this.generateLine("-");
            //this.DrawEspacio();
            this.setPrintFont(this.defaultTicketFontName, this.defaultTicketFontSize + 1, FontStyle.Bold);
            this.printSaleTicketList();
            this.DrawEspacio();
        }

        private void generateSaleTicketFooter()
        {
            this.setPrintFont(this.defaultTicketFontName, this.defaultTicketFontSize, FontStyle.Regular);
            this.drawCenterLine(" RECUERDE QUE ", 0, "=");
            // Imprimir factores de premio
            this.printPrizeFactors();
            // Imprimir leyendas finales
            line = "*** REVISE SU TIQUETE ***";
            this.drawCenterLine(line);
            line = "*** GRACIAS Y SUERTE ***";
            this.drawCenterLine(line);
            line = "NO SE PAGA SIN TIQUETE";
            this.drawCenterLine(line);
            line = "***";
            // Imprimir identificador del ticket
            this.drawCenterLine(line);
            this.setPrintFont(this.defaultTicketFontName, this.defaultTicketFontSize + 2, FontStyle.Regular);
            string globalId = this.fillString(UtilityService.getGlobalId(this.saleTicket.ticketId), 6, "0");
            line = "----< " + globalId + " >----";
            this.drawCenterLine(line);
            // Imprimir líneas de espacio finales
            this.printFinalLines();
        }

        private void printFinalLines()
        {
            this.drawCenterLine(".");
            this.drawCenterLine(".");
        }

        private void printPrizeFactors() {
            string[] legendArray = { "1RO", "2DO", "3RO"};
            double[] prizeFactorArray = this.saleTicket.prizeFactorArray;
            for (int i = 0; i < prizeFactorArray.Length; i++)
            {
                if (prizeFactorArray[i] != 0)
                {
                    string line = "AL " + legendArray[i] + ": " + this.fillString(prizeFactorArray[i].ToString(), 2);
                    this.drawCenterLine(line);
                }
            }
        }

        private void printSaleTicketList()
        {
            string listHeaders = this.fillString("MONTO", 6) + "   No";
            this.drawLine(this.printInColumns(listHeaders, 3));
            foreach (LotteryTuple tuple in this.saleTicket.listNumberDetail)
            {
                string itemList = "" + this.fillString(this.formatNumber(tuple.import).ToString(), 6)
                    + " X " + this.fillString(tuple.number, 2, "0");
                this.drawLine(this.printInColumns(itemList, 3));
            }
            string totalLabel = "+++TOTAL: " + this.fillString(this.formatNumber(this.saleTicket.getTotalImport()), 9, "*");
            this.drawCenterLine(totalLabel);
            //this.drawLine(this.printInColumns(totalLabel, 3));
        }


        #endregion
        
        private string printInColumns(string pText, int pColumns)
        {
            int oldSize = this.maxChar;
            this.maxChar = this.getMaxCharByFontSize((int) this.printFont.Size);
            string resultLine = "";
            int columnSize = (int)Math.Floor(this.maxChar / (pColumns + 5 ) * 1.0);
            resultLine += this.fillLine(columnSize);
            resultLine += this.fillString(pText, 14);
            //resultLine += this.fillLine(columnSize);
            this.maxChar = oldSize;
            return resultLine;
        }

        private string printInColumnsBK(string pText, int pColumns)
        {
            int oldSize = this.maxChar;
            this.maxChar = this.getMaxCharByFontSize((int)this.printFont.Size);
            string resultLine = "";
            int columnSize = (int)Math.Floor(this.maxChar / pColumns * 1.0);
            resultLine += this.fillLine(columnSize);
            resultLine += this.fillString(pText, columnSize);
            //resultLine += this.fillLine(columnSize);
            this.maxChar = oldSize;
            return resultLine;
        }


        private string fillString(string pStringToFill, int pSpaces, string pFillPattern = " ")
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


        private string fillNumber(int pNumber, int pSpaces)
        {
            string resultNumber = "";
            string numberToFormat = pNumber.ToString();
            if (numberToFormat.Length < pSpaces)
            {
                int fillCount = pSpaces - numberToFormat.Length;
                for (int i = 0; i < fillCount; i++)
                {
                    resultNumber += " ";
                }
            }
            resultNumber += numberToFormat;
            return resultNumber;
        }


        // Método que dibuja la linea que se le envía como parámetro
        private void drawLine(string pLineText)
        {
            int oldSize = this.maxChar;
            this.maxChar = this.getMaxCharByFontSize((int)this.printFont.Size);
            line = pLineText;
            this.addTicketStringLine(line);
            gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
            this.addLineHeight();
            count++;
            this.maxChar = oldSize;
        }

        // Método que dibuja la linea que se le envía como parámetro
        private void drawCenterLine(string pLineText, int pFontSize = 0, string pFillText = " ")
        {
            int oldSize = this.maxChar;
            this.maxChar = this.getMaxCharByFontSize(pFontSize == 0 ? (int) this.printFont.Size : pFontSize);
            int size = pLineText.Length;
            if (size < maxChar)
            {
                int dif = maxChar - size;
                int aroundSize = (int)Math.Floor(dif / 2.0);
                line = this.fillLine(aroundSize, pFillText) + pLineText + this.fillLine(aroundSize, pFillText);
            }
            else
            {
                line = pLineText;
            }
            this.addTicketStringLine(line);
            gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
            count++;
            this.addLineHeight();
            this.maxChar = oldSize;
        }

        // 
        private void generateLine(string pTextPatterm)
        {
            string text = "";
            int oldSize = this.maxChar;
            this.maxChar = this.getMaxCharByFontSize((int)this.printFont.Size);
            for (int i = 0; i < maxChar; i++)
            {
                text += pTextPatterm;
            }
            this.drawLine(text);
            this.maxChar = oldSize;
        }

        // Línea divisoria
        private string splitLine()
        {
            string text = "";
            for (int i = 0; i < maxChar; i++)
            {
                text += "-";
            }
            return text;
        }

        // 
        private string fillLine(int pSize, string pFillString = " ")
        {
            string text = "";
            for (int i = 0; i < pSize; i++)
            {
                text += pFillString;
            }
            return text;
        }

        // Línea espacio
        private string spaceLine(int pSize)
        {
            string text = "";
            for (int i = 0; i < pSize; i++)
            {
                text += " ";
            }
            return text;
        }


        private float YPosition()
        {
            //this.topPrintMargin += printFont.GetHeight(gfx);
            //return topMargin + ((float)count * printFont.GetHeight(gfx) + (float)imageHeight);
            return topMargin + (this.topPrintMargin + (float)imageHeight);
        }

        private void DrawImage()
        {
            if (headerImage != null)
            {
                try
                {
                    gfx.DrawImage(headerImage, new Point((int)leftMargin, (int)YPosition()));
                    double a = (double)headerImage.Height / 58.0 * 15.0;
                    imageHeight = (int)Math.Round(a) + 3;
                }
                catch (Exception)
                {
                }
            }
        }

        private void DrawHeader()
        {
            foreach (string headerLine in headerLines)
            {
                if (headerLine.Length > maxChar)
                {
                    int num = 0;
                    for (int num2 = headerLine.Length; num2 > maxChar; num2 -= maxChar)
                    {
                        line = headerLine.Substring(num, maxChar);
                        gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                        count++;
                        num += maxChar;
                    }
                    line = headerLine;
                    gfx.DrawString(line.Substring(num, line.Length - num), printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                    count++;
                }
                else
                {
                    line = headerLine;
                    gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                    count++;
                }
            }
            DrawEspacio();
        }

        private void DrawSubHeader()
        {
            foreach (string subHeaderLine in subHeaderLines)
            {
                if (subHeaderLine.Length > maxChar)
                {
                    int num = 0;
                    for (int num2 = subHeaderLine.Length; num2 > maxChar; num2 -= maxChar)
                    {
                        line = subHeaderLine;
                        gfx.DrawString(line.Substring(num, maxChar), printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                        count++;
                        num += maxChar;
                    }
                    line = subHeaderLine;
                    gfx.DrawString(line.Substring(num, line.Length - num), printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                    count++;
                }
                else
                {
                    line = subHeaderLine;
                    gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                    count++;
                    line = DottedLine();
                    gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                    count++;
                }
            }
            DrawEspacio();
        }

        private void DrawFooter()
        {
            foreach (string footerLine in footerLines)
            {
                if (footerLine.Length > maxChar)
                {
                    int num = 0;
                    for (int num2 = footerLine.Length; num2 > maxChar; num2 -= maxChar)
                    {
                        line = footerLine;
                        gfx.DrawString(line.Substring(num, maxChar), printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                        count++;
                        num += maxChar;
                    }
                    line = footerLine;
                    gfx.DrawString(line.Substring(num, line.Length - num), printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                    count++;
                }
                else
                {
                    line = footerLine;
                    gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                    count++;
                }
            }
            leftMargin = 0f;
            DrawEspacio();
        }

        private void DrawEspacio()
        {
            line = "";
            gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
            this.addTicketStringLine(line);
            this.addLineHeight();
            count++;
        }

    }

}
