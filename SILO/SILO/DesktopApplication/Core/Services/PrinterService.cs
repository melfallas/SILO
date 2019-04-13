﻿using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SILO.DesktopApplication.Core.Services
{
    class PrinterService
    {
        public void fillPrintersControl(ref ComboBox pListPrinter)
        {
            String printerName = "";
            Dictionary<string, string> printerList = new Dictionary<string, string>();
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                printerName = PrinterSettings.InstalledPrinters[i];
                //Console.WriteLine(printerName);
                printerList.Add(printerName, printerName);
            }
            pListPrinter.DataSource = new BindingSource(printerList, null);
            pListPrinter.DisplayMember = "Value";
            pListPrinter.ValueMember = "Key";
        }

        public void c() {

        }
    }
}