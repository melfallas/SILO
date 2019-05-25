using SILO.Core.Constants;
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
        private string qrText;
        public long drawType { get; set; }
        public DateTime drawDate { get; set; }

        public DisplayQRForm(DateTime pDate, long pGroup)
        {
            InitializeComponent();
            this.initializeForm(pDate, pGroup);
        }


        private void initializeForm(DateTime pDate, long pGroup) {
            this.qrText = "";
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
                MessageService.displayConfirmWarningMessage(GeneralConstants.QR_CLOSING_CONFIRM_MESSAGE, GeneralConstants.QR_CLOSING_CONFIRM_TITLE);
            // Procesar el resultado de la confirmación
            switch (msgResult)
            {
                case DialogResult.Yes:
                    // Procesar la generación de QR y cierre
                    successGeneration = this.startQRGenrationAndClosing(pGroupId, pDrawDate, qrText);
                    break;
                case DialogResult.No:
                    successGeneration = false;
                    break;
                default:
                    break;
            }
            return successGeneration;
        }

        private bool startQRGenrationAndClosing(long pDrawType, DateTime pDrawDate, string pQRText)
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
            string qrOriginalText = UtilityService.getEncodeQRString(pQRText, pDrawDate, pDrawType);
            Console.WriteLine("Original QR: " + qrOriginalText);
            //text = UtilityService.compressText(text);
            string qrEncriptedText = qrOriginalText;
            Console.WriteLine("Compress QR: " + qrEncriptedText);

            // Setear el QRText y obtener las propiedades del mismo
            this.qrText = qrEncriptedText;
            int qrTextLength = qrEncriptedText.Length;
            int zerosCount = (from c in qrEncriptedText where c == '0' select c).Count();

            // Desplegar propiedades del QR
            this.countLabel.Text = qrTextLength + " | " + zerosCount;
            this.displayQRPanel.BackgroundImage = UtilityService.buildQRCode(qrEncriptedText, this.displayQRPanel.Width, this.displayQRPanel.Height);

            // Validar tamaño de QR y advertir en caso de ser muy grande
            int maxQRSizeSuported = 350;
            if (qrTextLength > maxQRSizeSuported)
            {
                MessageService.displayErrorMessage(
                    "El QR parece tener un tamaño no apropiado para ser leído.\nEs preferible que copie el QR y lo envíe por whatsapp.\nEn caso de duda contacte al administrador.",
                    "PREFERIBLE EL ENVÍO DEL QR POR WHATSAPP"
                    );
            }
            // Cerrar el sorteo
            if (pDrawDate != null && pDrawType != 0)
            {
                DrawService drawService = new DrawService();
                drawService.changeDrawStatus(pDrawType, pDrawDate, SystemConstants.DRAW_STATUS_CLOSED);
            }
            return successGeneration;
        }

        private void copyQRButton_Click(object sender, EventArgs e)
        {
            this.copyQR();
        }

        private void copyQR()
        {
            if (UtilityService.copyQRToClipboard(this.qrText))
            {
                MessageBox.Show("QR generado y copiado al portapapeles.\nPor favor envíelo por whatsapp, usando la opción pegar.\nTambién puede pegarlo en whatsapp usando Ctrl + v",
                    "QR COPIADO DE MANERA EXITOSA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al copiar texto al portapapeles.", "Error al copiar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
