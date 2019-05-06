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
    public partial class DeviceParamsForm : Form
    {
        public DeviceParamsForm()
        {
            InitializeComponent();
            this.initializeDevices();
        }

        public void initializeDevices()
        {
            DeviceService deviceService = new DeviceService();
            deviceService.fillDeviceListBox(ref this.devicesListBox);
        }

        private void saveDeviceButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine(this.devicesListBox.SelectedIndex);
            ParameterService.setDeviceValue(this.devicesListBox.SelectedValue.ToString());
            MessageBox.Show("Dispositivo registrado exitosamente");
            //MessageBox.Show("Dispositivo: '" + this.devicesListBox.SelectedValue + "'");
        }
    }
}
