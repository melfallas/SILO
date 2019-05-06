using SILO.DesktopApplication.Core.Constants;
using SILO.DesktopApplication.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SILO
{
    public partial class DisplayQRForm : Form
    {
        public long drawType { get; set; }
        public DateTime drawDate { get; set; }

        public DisplayQRForm(DateTime pDate, long pGroup)
        {
            InitializeComponent();
            this.initializeForm(pDate, pGroup);
        }


        private void initializeForm(DateTime pDate, long pGroup) {
            this.drawType = pGroup;
            this.drawDate = pDate;
        }

        public bool generateQRCode()
        {
            bool successGeneration = true;
            // Obtener transacciones pendientes en forma de hilera
            String text = UtilityService.getPendingTransactions(this.drawDate, this.drawType);            
            if (text.Trim() == "")
            {
                successGeneration = false;
                MessageService.displayInfoMessage(
                    "Todas las transacciones están sincronizadas.\nNo es necesario enviar el QR.", 
                    "TRANSACCIONES SINCRONIZADAS COMPLETAMENTE");
                //MessageBox.Show("No existen datos para el sorteo especificado.");
            }
            else
            {
                successGeneration = this.confirmQRSendingAndDrawClosing( this.drawType, this.drawDate, text);
            }
            return successGeneration;
        }

        private bool confirmQRSendingAndDrawClosing(long pGroupId, DateTime pDrawDate, string qrText)
        {
            bool successGeneration = true;
            DialogResult msgResult =
                MessageService.displayConfirmWarningMessage(
                    "¿Desea generar y realizar el envío del QR para el sorteo?\nLuego de su generación, las ventas para el sorteo no estarán permitidas.\nEsta operación no es reversible.",
                    "CERRANDO SORTEO..."
                    );
            // Procesar el resultado de la confirmación
            switch (msgResult)
            {
                case DialogResult.Yes:
                    // Procesar la generación de QR y cierre
                    successGeneration = this.startQRGenrationAndClosing(pGroupId, pDrawDate, qrText);
                    break;
                case DialogResult.No:
                    break;
                default:
                    break;
            }
            return successGeneration;
        }

        private bool startQRGenrationAndClosing(long pDrawType, DateTime pDrawDate, string qrText)
        {
            bool successGeneration = true;
            // Cambiar estado de lista a QR Generado
            ListService listService = new ListService();
            listService.changeSyncStatusToQRUpdated(pDrawType, pDrawDate);
            // Obtener parámetros del QR generado
            DrawTypeService drawTypeService = new DrawTypeService();
            PointSaleService posService = new PointSaleService();
            this.dateLabel.Text = "" + UtilityService.getLargeDate(pDrawDate);
            this.drawLabel.Text = "Grupo: " + drawTypeService.getById(pDrawType).LDT_DisplayName;
            this.posLabel.Text = "Suc: " + posService.getPointSale().LPS_DisplayName;
            // Obtener QRString codificada
            qrText = UtilityService.getEncodeQRString(qrText, pDrawDate, pDrawType);
            Console.WriteLine("Original QR: " + qrText);
            //text = UtilityService.compressText(text);
            Console.WriteLine("Compress QR: " + qrText);
            this.countLabel.Text = qrText.Length.ToString() + " | " + (from c in qrText where c == '0' select c).Count().ToString();
            this.displayQRPanel.BackgroundImage = UtilityService.buildQRCode(qrText, this.displayQRPanel.Width, this.displayQRPanel.Height);
            // Cerrar el sorteo
            if (pDrawDate != null && pDrawType != 0)
            {
                DrawService drawService = new DrawService();
                drawService.changeDrawStatus(pDrawType, pDrawDate, SystemConstants.DRAW_STATUS_CLOSED);
            }
            return successGeneration;
        }



    }
}
