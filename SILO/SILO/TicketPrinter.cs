using System;
//using LibPrintTicket;
using System.Drawing;
using System.Collections;
using System.Drawing.Printing;

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

        //private int maxChar = 35;
        private int maxChar = 24;

        private int maxCharDescription = 20;

        private int imageHeight;

        private float leftMargin;

        private float topMargin = 3f;

        private string fontName = "Lucida Console";

        private int fontSize = 9;

        private Font printFont;

        private SolidBrush myBrush = new SolidBrush(Color.Black);

        private Graphics gfx;

        private string line;

        #endregion

        #region Propiedades

        public SaleTicket saleTicket { get; set; }

        #endregion


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

        #endregion


        #region Utilitarios


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


        /*
        public string formatNumber(string pNumberToFormat)
        {
            return pNumberToFormat.ToString("#,#", System.Globalization.CultureInfo.InvariantCulture);
        }
        */

        #endregion


        #region Prize Components

        private void generatePrizeHeader()
        {
            this.drawCenterLine(this.saleTicket.companyName);
            line = "**NOCHE**";
            this.drawCenterLine(line);
            line = "JUEVES 18/10/2018";
            this.drawCenterLine(line);
            line = "GRUPO: SAN PABLO";
            this.drawCenterLine(line);
        }

        private void generatePrizeList()
        {
            this.generateLine("=");
            string listHeaders = "No \t MONTO \t PREMIO \t CLAVE";
            this.drawLine(listHeaders);
            this.generateLine("=");
            //this.printPriceList();
            this.DrawEspacio();
            this.printPriceList();

        }

        private void printPriceList()
        {
            int[] numeros = { 84, 07, 42, 23, 00 };
            int[] montos = { 500, 500, 1000, 500, 1500 };
            int[] premios = { 37500, 86000, 23700, 98000, 235600 };
            string[] claves = { "370811", "370811", "370811", "370811", "370811" };
            string[] idArray = { "0037", "0037", "0037", "0037", "0037" };

            for (int i = 0; i < montos.Length; i++)
            {
                string itemList =
                    this.fillString(numeros[i].ToString(), 2, "0")
                    + " \t" + this.formatNumber(montos[i]) + " \t"
                    + this.formatNumber(premios[i])
                    + " > \t" + claves[i] + "/" + idArray[i]
                    ;
                this.drawLine(itemList);
                this.drawLine("--> ESTRELLA");
                this.DrawEspacio();
                //this.drawLine(itemList);
            }
            //string totalLabel = "+++TOTAL: ***5,500";
            //this.drawLine(this.printInColumns(totalLabel, 3));
        }

        #endregion


        #region Sale Ticket

        public void printLotterySaleTicket(string impresora)
        {
            printFont = new Font(fontName, (float)fontSize, FontStyle.Regular);
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
            string printTime = this.saleTicket.createDate.ToString("hh:mm");
            string printDate = this.saleTicket.createDate.ToString("dd/MM/yyyy");
            string drawDate = this.saleTicket.drawDate.ToString("dddd", new System.Globalization.CultureInfo("es-CR")).ToUpper() + " " + this.saleTicket.drawDate.ToString("dd/MM/yyyy");
            string ticketId = this.fillString(this.saleTicket.ticketId.ToString(), 4, "0");
            string globalId = this.fillString(this.saleTicket.globalId.ToString(), 6, "0");
            this.drawCenterLine(printDate);
            string line = "/" + printTime + "/----------/" + ticketId + "/";
            this.drawCenterLine(line);
            line = "<< " + this.saleTicket.customerName + " >>";
            this.drawCenterLine(line);
            this.drawCenterLine(this.saleTicket.companyName);
            line = "**" + this.saleTicket.drawTypeCode + "**";
            this.drawCenterLine(line);
            this.drawCenterLine(drawDate);
            line = "SUC: " + this.saleTicket.pointSaleName + " CL:" + globalId;
            this.drawCenterLine(line);
        }

        private void generateSaleTicketList()
        {
            this.generateLine("-");
            //this.DrawEspacio();
            this.printSaleTicketList();
            this.DrawEspacio();
        }

        private void generateSaleTicketFooter()
        {
            this.drawCenterLine(" RECUERDE QUE ", "=");
            string line = "AL 1RO: 75";
            this.drawCenterLine(line);
            line = "*** REVISE SU TIQUETE ***";
            this.drawCenterLine(line);
            line = "*** GRACIAS Y SUERTE ***";
            this.drawCenterLine(line);
            line = "***";
            this.drawCenterLine(line);
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
            string totalLabel = "+++TOTAL: " + this.fillString(this.formatNumber(this.saleTicket.getTotalImport()), 8, "*");
            this.drawCenterLine(totalLabel);
            //this.drawLine(this.printInColumns(totalLabel, 3));
        }


        #endregion


        private void pr_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            gfx = e.Graphics;
            //DrawImage();
            //DrawHeader();
            this.generateHeader();
            this.generateList();
            this.generateFooter();
            //DrawSubHeader();
            //DrawItems();
            //DrawTotales();
            //DrawFooter();
            if (headerImage != null)
            {
                HeaderImage.Dispose();
                headerImage.Dispose();
            }
        }


        private void generateHeader()
        {
            string line = "/17:15/----------------------/0039/";
            this.drawLine(line);
            line = "<<ESTRELLA>>";
            this.drawCenterLine(line);
            line = "TIEMPOS RIVERA";
            this.drawCenterLine(line);
            line = "**NOCHE**";
            this.drawCenterLine(line);
            line = "JUEVES 18/10/2018";
            this.drawCenterLine(line);
            line = "GRUPO: SAN PABLO \t CL: 639648";
            this.drawCenterLine(line);
        }

        private void generateList()
        {
            this.generateLine("-");
            //this.DrawEspacio();
            this.printList();
            this.DrawEspacio();
        }

        private void generateFooter()
        {
            this.drawCenterLine(" RECUERDE QUE ", "=");
            string line = "AL 1RO: 75";
            this.drawCenterLine(line);
            line = "*** REVISE SU TIQUETE ***";
            this.drawCenterLine(line);
            line = "*** GRACIAS Y SUERTE ***";
            this.drawCenterLine(line);
            line = "***";
            this.drawCenterLine(line);
        }

        private void printList()
        {
            int[] montos = { 500, 500, 1000, 500, 1500 };
            int[] numeros = { 84, 07, 42, 23, 00 };
            string listHeaders = this.fillString("MONTO", 6) + "   No";
            this.drawLine(this.printInColumns(listHeaders, 3));
            for (int i = 0; i < montos.Length; i++)
            {
                string itemList = "" + this.fillString(montos[i].ToString(), 6) + " X " + this.fillString(numeros[i].ToString(), 2, "0");
                this.drawLine(this.printInColumns(itemList, 3));
                //this.drawLine(itemList);
            }
            string totalLabel = "+++TOTAL: ***5,500";
            this.drawLine(this.printInColumns(totalLabel, 3));
        }


        private string printInColumns(string pText, int pColumns)
        {
            string resultLine = "";
            int columnSize = (int)Math.Floor(this.maxChar / pColumns * 1.0);
            resultLine += this.fillLine(columnSize);
            resultLine += this.fillString(pText, columnSize);
            //resultLine += this.fillLine(columnSize);
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
            line = pLineText;
            gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
            count++;
        }

        // Método que dibuja la linea que se le envía como parámetro
        private void drawCenterLine(string pLineText, string pFillText = " ")
        {
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
            gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
            count++;
        }

        // 
        private void generateLine(string pTextPatterm)
        {
            string text = "";
            for (int i = 0; i < maxChar; i++)
            {
                text += pTextPatterm;
            }
            this.drawLine(text);
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
            return topMargin + ((float)count * printFont.GetHeight(gfx) + (float)imageHeight);
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
            count++;
        }
    }

}
