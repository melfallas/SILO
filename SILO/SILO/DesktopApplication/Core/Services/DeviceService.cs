using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SILO.DesktopApplication.Core.Services
{
    public class DeviceService
    {
        
        public void fillDeviceListBox(ref ComboBox pListPrinter)
        {
            ManagementObjectCollection usbDevicesList = getUsbDevicesList();
            Dictionary<string, string> deviceList = new Dictionary<string, string>();
            foreach (ManagementObject usbItem in usbDevicesList)
            {
                object deviceId = usbItem["DeviceID"];
                ManagementObject theSerialNumberObjectQuery = new ManagementObject("Win32_PhysicalMedia.Tag='" + usbItem["DeviceID"] + "'");
                string usbSerialNumber = "'" + theSerialNumberObjectQuery["SerialNumber"].ToString() + "'";
                EncryptingService encryptionService = new EncryptingService();
                string encryptedSerialNumber = encryptionService.encryptMessage(usbSerialNumber);
                string displayDeviceSerial = this.getDeviceName(deviceId.ToString()) + " | " + encryptedSerialNumber.Substring(0, 10);
                //Console.WriteLine(printerName);
                deviceList.Add(encryptedSerialNumber, displayDeviceSerial);
            }
            pListPrinter.DataSource = new BindingSource(deviceList, null);
            pListPrinter.DisplayMember = "Value";
            pListPrinter.ValueMember = "Key";
        }

        private string getDeviceName(string pDevice) {
            return pDevice.Replace("\\\\.\\PHYSICAL", "");
        }
        

        public ManagementObjectCollection getUsbDevicesList()
        {
            ManagementObjectSearcher theSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive WHERE InterfaceType='USB'");
            ManagementObjectCollection usbDevicesList = theSearcher.Get();
            return usbDevicesList;
        }

        public bool findUsbDeviceBySerialId(string deviceSerialId, ManagementObjectCollection pUsbDevicesList)
        {
            bool deviceFinded = false;
            foreach (ManagementObject usbItem in pUsbDevicesList)
            {
                object deviceId = usbItem["DeviceID"];
                ManagementObject theSerialNumberObjectQuery = new ManagementObject("Win32_PhysicalMedia.Tag='" + usbItem["DeviceID"] + "'");
                string usbSerialNumber = "'" + theSerialNumberObjectQuery["SerialNumber"].ToString() + "'";
                EncryptingService encryptionService = new EncryptingService();
                string encryptedSerialNumber = encryptionService.encryptMessage(usbSerialNumber);
                if (deviceSerialId == encryptedSerialNumber)
                {
                    deviceFinded = true;
                    Console.WriteLine("*****************************************************");
                    Console.WriteLine("Finded: " + deviceId + " - Serial:" + usbSerialNumber);
                }
                Console.WriteLine(deviceId);
                Console.WriteLine(usbSerialNumber);
                Console.WriteLine(encryptedSerialNumber);
                
            }
            return deviceFinded;
        }

        /*
        public void f()
        {
            EncryptingService encryptionService = new EncryptingService();
            ///string encryptRegisteredDevice = encryptionService.encryptMessage(this.registeredDeviceSerial);
            //this.registeredDeviceSerial = encryptRegisteredDevice;
            //Console.WriteLine("RD: " + encryptRegisteredDevice);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isRegisteredSerial = false;
            ManagementObjectCollection usbDevicesList = getUsbDevicesList();
            if (usbDevicesList.Count == 0)
            {
                MessageBox.Show("No hay dispositivos conectados.");
            }
            else
            {
                //isRegisteredSerial = this.findUsbDeviceBySerialId(this.registeredDeviceSerial, usbDevicesList);
                if (true)
                {
                    MessageBox.Show("Bien.");
                }
                else
                {
                    MessageBox.Show("Debe registrar el dispositivo.");
                }
            }
        }
        */
    }
}
