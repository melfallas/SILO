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
    public partial class DisplayListForm : Form
    {
        public int type { get; set; }

        public DisplayListForm()
        {
            InitializeComponent();
        }

        public DisplayListForm(int pType)
        {
            InitializeComponent();
            this.initializeAttributes(pType);
            this.loadControls();
        }

        public void initializeAttributes(int pType) {
            this.type = pType;
        }

        public void loadControls()
        {
            this.drawTypeBox.ValueMember = GeneralConstants.DISPLAY_DRAWTYPE_KEY_LABEL;
            this.drawTypeBox.DisplayMember = GeneralConstants.DISPLAY_DRAWTYPE_VALUE_LABEL;
            this.drawTypeBox.DataSource = UtilityService.drawTypeDataTable(this.drawTypeBox.ValueMember, this.drawTypeBox.DisplayMember);
            this.drawTypeBox.SelectedIndex = 0;
        }

        public void displayListForm() {
            if (Convert.ToInt32(this.drawTypeBox.SelectedValue) != 0)
            {
                // Validar el tipo de pantalla de despliegue
                // DisplayScreenForm
                if(this.type == SystemConstants.DISPLAY_QR_CODE)
                {
                    // Pantalla de despliegue de Código QR
                    DisplayQRForm qrForm = new DisplayQRForm(this.datePickerList.Value.Date, this.drawTypeBox.SelectedIndex);
                    if (qrForm.generateQRCode())
                    {
                        qrForm.Show();
                    }
                }
                else
                {
                    // Pantalla de despliegue de Selección de Lista
                    ListSelectorForm listBoxSelector = new ListSelectorForm(this.datePickerList.Value.Date, this.drawTypeBox.SelectedIndex, this.type);
                    listBoxSelector.ShowDialog();
                }
            }
        }

        private void drawTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.displayListForm();
        }

        private void datePickerList_ValueChanged(object sender, EventArgs e)
        {
            this.drawTypeBox.SelectedIndex = 0;
            //this.displayListForm();
        }
    }
}
