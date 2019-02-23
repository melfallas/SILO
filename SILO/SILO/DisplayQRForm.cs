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
                MessageBox.Show("No existen datos para el sorteo especificado.");
            }
            else
            {
                text = UtilityService.getEncodeQRString(text, this.drawDate, this.drawType);
                Console.WriteLine("QR: " + text);
                this.countLabel.Text = text.Length.ToString() + " | " + (from c in text where c == '0' select c).Count().ToString();
                this.displayQRPanel.BackgroundImage = UtilityService.buildQRCode(text, this.displayQRPanel.Width, this.displayQRPanel.Height);
            }
            return successGeneration;
        }

    }
}
