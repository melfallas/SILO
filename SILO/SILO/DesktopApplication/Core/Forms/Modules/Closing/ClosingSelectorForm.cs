using SILO.Core.Constants;
using SILO.DesktopApplication.Core.Constants;
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

namespace SILO.DesktopApplication.Core.Forms.Modules.Closing
{
    public partial class ClosingSelectorForm : Form
    {
        public ApplicationMediator appMediator { get; set; }

        public ClosingSelectorForm(ApplicationMediator pMediator)
        {
            InitializeComponent();
            this.appMediator = pMediator;
            this.loadControls();
        }

        private void loadControls()
        {
            this.drawTypeBox.ValueMember = GeneralConstants.DISPLAY_DRAWTYPE_KEY_LABEL;
            this.drawTypeBox.DisplayMember = GeneralConstants.DISPLAY_DRAWTYPE_VALUE_LABEL;
            this.drawTypeBox.DataSource = UtilityService.drawTypeDataTable(this.drawTypeBox.ValueMember, this.drawTypeBox.DisplayMember);
            this.drawTypeBox.SelectedIndex = 0;
            this.datePickerList.Focus();
        }

        private void closeView()
        {
            this.appMediator.setAppTopMost(true);
            this.Dispose();
            this.appMediator.setAppTopMost(false);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.closeView();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            long groupId = Convert.ToInt64(this.drawTypeBox.SelectedValue);
            if (groupId == 0)
            {
                MessageBox.Show("Debe elegir un grupo válido");
            }
            else
            {
                DialogResult msgResult =
                    MessageService.displayConfirmWarningMessage(
                            "¿Desea realizar el envío  al servidor y cerrar el sorteo?\nEsta operación no es reversible.",
                            "CERRANDO SORTEO..."
                            );
                // Procesar el resultado de la confirmación
                switch (msgResult)
                {
                    case DialogResult.Yes:
                        // Procesar la sincronización
                        this.closeView();
                        this.appMediator.setAppTopMost(true);
                        this.appMediator.closeTransactions(SystemConstants.SYNC_CLOSING_TYPE, this.datePickerList.Value.Date, groupId);
                        this.appMediator.setAppTopMost(false);
                        break;
                    case DialogResult.No:
                        break;
                    default:
                        break;
                }
            }
        }

        private void ClosingSelectorForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.closeView();
            }
        }
    }
}
