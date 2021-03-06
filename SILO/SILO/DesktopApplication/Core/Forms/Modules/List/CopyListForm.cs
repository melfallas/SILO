﻿using SILO.Core.Constants;
using SILO.DesktopApplication.Core.Integration;
using SILO.DesktopApplication.Core.Services;
using SILO.DesktopApplication.Core.Util;
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

        public ApplicationMediator appMediator { get; set; }

        public CopyListForm(ApplicationMediator pMediator, ListSelectorForm pSelectorForm, long pListId)
        {
            InitializeComponent();
            this.listId = pListId;
            this.selectorForm = pSelectorForm;
            this.groupService = new DrawTypeService();
            this.createControls();
            // Establecer el ApplicationMediator
            this.appMediator = pMediator;
        }

        public void createControls()
        {

            this.groupService.addRadioButtonList(ref this.centerMainPanel);
        }

        private RadioButton getCheckedGroupRadio()
        {
            return this.centerMainPanel.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
        }

        private void processCopy() {
            RadioButton checkedRadio = this.getCheckedGroupRadio();
            // Validar si hay un grupo seleccionado para la copia
            if (checkedRadio == null)
            {
                MessageService.displayWarningMessage("Debe seleccionar un grupo");
            }
            else
            {
                long drawTypeId = -1;
                string drawTypeString = checkedRadio.Name.Replace(GeneralConstants.CHECKBOX_NAME_ID_LABEL, "");
                bool isNumericResult = long.TryParse(drawTypeString, out drawTypeId);
                if (isNumericResult)
                {
                    SaleValidator saleValidator = new SaleValidator();
                    saleValidator.validatePrizeFactor(drawTypeId, copyAndDisplayListInstance);
                    //this.copyAndDisplayListInstance(drawTypeId);
                }
                else
                {
                    MessageService.displayErrorMessage("Error obteniendo el grupo");
                }
            }
        }

        private bool copyAndDisplayListInstance(long pDrawTypeId) {
            bool successResult = true;
            ListService listService = new ListService();
            LDT_LotteryDrawType selectedGroup = this.groupService.getById(pDrawTypeId);
            ListInstanceForm listInstance = new ListInstanceForm(
                this.appMediator,
                this.selectorForm,
                UtilityService.getPointSale(),
                selectedGroup,
                DateTime.Today,
                listService.getListDetail(this.listId)
                );
            listInstance.StartPosition = FormStartPosition.CenterParent;
            listInstance.ShowDialog();
            //MessageBox.Show("Display: " + selectedGroup.LDT_DisplayName);
            return successResult;
        }


        private void copyButton_Click(object sender, EventArgs e)
        {
            this.processCopy();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void CopyListForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    this.processCopy();
                    break;
                case Keys.Escape:
                    this.Dispose();
                    break;
                case Keys.Multiply:

                    break;
                default:
                    break;
            }
        }
    }
}
