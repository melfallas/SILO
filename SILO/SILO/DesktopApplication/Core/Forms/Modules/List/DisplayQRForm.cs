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
                // Cambiar estado de lista a QR Generado
                ListService listService = new ListService();
                listService.changeSyncStatusToQRUpdated(this.drawType, this.drawDate);
                // Obtener parámetros del QR generado
                DrawTypeService drawTypeService = new DrawTypeService();
                PointSaleService posService = new PointSaleService();
                this.dateLabel.Text = "" + UtilityService.getLargeDate(this.drawDate);
                this.drawLabel.Text = "Grupo: " + drawTypeService.getById(this.drawType).LDT_DisplayName;
                this.posLabel.Text = "Suc: " + posService.getPointSale().LPS_DisplayName;
                // Obtener QRString codificada
                text = UtilityService.getEncodeQRString(text, this.drawDate, this.drawType);
                Console.WriteLine("Original QR: " + text);
                //text = UtilityService.compressText(text);
                Console.WriteLine("Compress QR: " + text);
                this.countLabel.Text = text.Length.ToString() + " | " + (from c in text where c == '0' select c).Count().ToString();
                this.displayQRPanel.BackgroundImage = UtilityService.buildQRCode(text, this.displayQRPanel.Width, this.displayQRPanel.Height);
            }
            return successGeneration;
        }

    }
}
