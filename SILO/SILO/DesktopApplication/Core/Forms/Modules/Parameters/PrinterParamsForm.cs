using SILO.Core.Constants;
using SILO.DesktopApplication.Core.Integration;
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

        public ApplicationMediator appMediator { get; set; }

        public PrinterParamsForm(ApplicationMediator pMediator)
        {
            this.appMediator = pMediator;
            InitializeComponent();
            initializeControls();
        }

        public void initializeControls() {
            PrinterService printerService = new PrinterService();
            printerService.fillPrintersControl(ref this.printerBox, "SELECCIONE UNA IMPRESORA");
            String printerName = ParameterService.getPrinter();
            String printerIsEnabled = ParameterService.getEnablePrinter();
            this.cbxEnablePrint.Checked = printerIsEnabled == "1" ? true : false;
            if (printerName == "")
            {
                this.printerBox.SelectedValue = "0";
            }
            else
            {
                this.printerBox.SelectedValue = printerName;
            }
        }

        private void savePrinterButton_Click(object sender, EventArgs e)
        {
            string printerName = this.printerBox.SelectedValue.ToString();
            ParameterService.setPrinter(printerName);
            ParameterService.setEnablePrinter(cbxEnablePrint.Checked ? "1" : "0");
            this.closeView();
            MessageService.displayInfoMessage(GeneralConstants.SET_PRINTER_MESSAGE + printerName, GeneralConstants.SET_PRINTER_TITLE);
        }

        private void closeView()
        {
            this.appMediator.setAppTopMost(true);
            this.Dispose();
            this.appMediator.setAppTopMost(false);
        }

        private void PrinterParamsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.closeView();
            }
        }
    }
}
