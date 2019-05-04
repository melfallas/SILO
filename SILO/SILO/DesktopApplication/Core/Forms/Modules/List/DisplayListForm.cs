using SILO.Core.Constants;
using SILO.DesktopApplication.Core.Constants;
using SILO.DesktopApplication.Core.Forms.Modules.ModuleForm;
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

namespace SILO.DesktopApplication.Core.Forms.Modules.List
{
    public partial class DisplayListForm : MainModuleForm
    {

        public ApplicationMediator appMediator { get; set; }

        /*
        public DisplayListForm(ApplicationMediator pMediator)
        {
            InitializeComponent();
            // Establecer el ApplicationMediator
            this.appMediator = pMediator;
        }
        */

        public DisplayListForm(ApplicationMediator pMediator, int pType)
        {
            InitializeComponent();
            this.initializeAttributes(pType);
            this.loadControls();
            // Establecer el ApplicationMediator
            this.appMediator = pMediator;
        }

        private void initializeAttributes(int pType) {
            this.type = pType;
            string formTitle = this.getDisplayFormTitle(pType);
            if (formTitle != "")
            {
                this.displayFormTitleLabel.Text = formTitle;
            }
        }

        private string getDisplayFormTitle(int pType)
        {
            string title = "";
            switch (pType)
            {
                case SystemConstants.PRINTER_LIST_CODE:
                    title = "REIMPRESIÓN DE LISTAS";
                    break;
                case SystemConstants.ERASER_LIST_CODE:
                    title = "BORRADO  DE LISTAS";
                    break;
                case SystemConstants.COPY_LIST_CODE:
                    title = "COPIADO DE LISTAS";
                    break;
                case SystemConstants.DISPLAY_QR_CODE:
                    title = "ENVÍO DE QR Y CIERRE";
                    break;
                default:
                    break;
            }
            return title;
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
                // Validar el tipo de pantalla de despliegue DisplayScreenForm
                // DisplayScreenForm
                if (this.type == SystemConstants.DISPLAY_QR_CODE)
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
                    ListSelectorForm listBoxSelector = new ListSelectorForm(this.appMediator, this.datePickerList.Value.Date, this.drawTypeBox.SelectedIndex, this.type);
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
