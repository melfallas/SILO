using SILO.Core.Constants;
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
    public partial class CopyListForm : Form
    {
        private long listId;
        private ListSelectorForm selectorForm;
        private DrawTypeService groupService;

        public CopyListForm(ListSelectorForm pSelectorForm, long pListId)
        {
            InitializeComponent();
            this.listId = pListId;
            this.selectorForm = pSelectorForm;
            this.groupService = new DrawTypeService();
            this.createControls();
        }

        public void createControls()
        {

            this.groupService.addRadioButtonList(ref this.centerMainPanel);
        }

        private RadioButton getCheckedGroupRadio()
        {
            return this.centerMainPanel.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
        }

        private void process() {
            RadioButton checkedRadio = this.getCheckedGroupRadio();
            // Validar si hay un grupo seleccionado para la copia
            if (checkedRadio == null)
            {
                MessageService.displayWarningMessage("Debe seleccionar un grupo");
            }
            else
            {
                long drawTypeId = -1;
                ListService listService = new ListService();
                string drawTypeString = checkedRadio.Name.Replace(GeneralConstants.CHECKBOX_NAME_ID_LABEL, "");
                bool isNumericResult = long.TryParse(drawTypeString, out drawTypeId);
                if (isNumericResult)
                {
                    LDT_LotteryDrawType selectedGroup = this.groupService.getById(drawTypeId);
                    ListInstanceForm listInstance = new ListInstanceForm(
                        this.selectorForm,
                        UtilityService.getPointSale(),
                        selectedGroup,
                        DateTime.Today,
                        listService.getListDetail(this.listId)
                        );
                    listInstance.StartPosition = FormStartPosition.CenterParent;
                    listInstance.ShowDialog();
                    //MessageBox.Show("Display: " + selectedGroup.LDT_DisplayName);
                }
                else
                {
                    MessageService.displayErrorMessage("Error obteniendo el grupo");
                }
            }
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            this.process();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
