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

namespace SILO.DesktopApplication.Core.Forms.Modules.Parameters
{
    public partial class PrinterParamsForm : Form
    {
        public PrinterParamsForm()
        {
            InitializeComponent();
            initializeControls();
        }

        public void initializeControls() {
            PrinterService printerService = new PrinterService();
            printerService.fillPrintersControl(ref this.printerBox);
        }

        private void savePrinterButton_Click(object sender, EventArgs e)
        {
            UtilityService.setPrinter(printerBox.SelectedValue.ToString());
            UtilityService.setEnablePrinter(cbxEnablePrint.Checked ? "1" : "0");
            MessageBox.Show("Impresora: '" + printerBox.SelectedValue + "'");
            //this.Dispose();
        }
    }
}
