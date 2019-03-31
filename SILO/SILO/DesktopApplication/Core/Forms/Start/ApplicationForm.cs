using Newtonsoft.Json.Linq;
using SILO.DesktopApplication.Core.Constants;
using SILO.DesktopApplication.Core.Forms.Modules.List;
using SILO.DesktopApplication.Core.Forms.Modules.ModuleForm;
using SILO.DesktopApplication.Core.Forms.Modules.Sale;
using SILO.DesktopApplication.Core.Services;
using SILO.DesktopApplication.Core.SystemConfig;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SILO.DesktopApplication.Core.Forms.Start
{
    public partial class ApplicationForm : Form
    {
        public Form parentForm { get; set; }

        public ApplicationForm(Form pParentForm)
        {
            InitializeComponent();
            this.parentForm = pParentForm;
            this.userContentLabel.Text = SystemSession.username;
            this.posContentLabel.Text = SystemSession.salePoint;
            this.companyContentLabel.Text = SystemSession.company;
            //this.printMenuButton.BackColor = Color.FromArgb(12, 61, 92);
        }

        private void showFormInMainPanel(MainModuleForm pForm)
        {
            this.centerBoxPanel.Hide();
            MainModuleForm existingForm = getExistingForm(pForm);
            // Validar si existe o no el formulario
            if (existingForm == null)
            {
                // Agregar el nuevo formulario si no existe
                MainModuleForm formToAdd = pForm as MainModuleForm;
                formToAdd.TopLevel = false;
                formToAdd.Dock = DockStyle.Fill;
                this.centerBoxPanel.Controls.Add(formToAdd);
                this.centerBoxPanel.Tag = formToAdd;
                formToAdd.Show();
                formToAdd.BringToFront();
            }
            else
            {
                // Destruir el formulario nuevo y mostrar el existente
                pForm.Dispose();
                existingForm.BringToFront();
                // Si se trae al frente un NumberBoxForm, se debe actualizar
                if (existingForm.type == SystemConstants.NUMBER_BOX_CODE)
                {
                    NumberBoxForm numberBox = (NumberBoxForm)existingForm;
                    numberBox.updateNumberBox();
                }
            }
            this.centerBoxPanel.Show();
        }

        private MainModuleForm getExistingForm(MainModuleForm pForm) {
            MainModuleForm existingForm = null;
            // Iterar por los controles, obteniendo el formulario si existe
            foreach (Control control in this.centerBoxPanel.Controls)
            {
                MainModuleForm currentForm = control as MainModuleForm;
                int formType = currentForm.type;

                Console.WriteLine(formType.ToString());
                if (formType == pForm.type)
                {
                    existingForm = currentForm;
                }
            }
            return existingForm;
        }

        //--------------------------------------- Botones de Menú Lateral --------------------------------------//
        #region Botones de Menú Lateral
        private void saleMenuButton_Click(object sender, EventArgs e)
        {
            this.showFormInMainPanel(new NumberBoxForm());
        }

        private void copyListButton_Click(object sender, EventArgs e)
        {
            DisplayListForm displayListForm = new DisplayListForm(SystemConstants.COPY_LIST_CODE);
            this.showFormInMainPanel(displayListForm);
        }

        private void printMenuButton_Click(object sender, EventArgs e)
        {
            //ShowFormInMainPanel(new GeneralConfigurationForm());
            DisplayListForm displayListForm = new DisplayListForm(SystemConstants.PRINTER_LIST_CODE);
            this.showFormInMainPanel(displayListForm);
            //ListSelectorForm listSelectorForm = new ListSelectorForm();
            //listSelectorForm.ShowDialog();
        }

        private void eraseButton_Click(object sender, EventArgs e)
        {
            DisplayListForm displayListForm = new DisplayListForm(SystemConstants.ERASER_LIST_CODE);
            this.showFormInMainPanel(displayListForm);
        }

        private void displayQRMenuButton_Click(object sender, EventArgs e)
        {
            DisplayListForm displayListForm = new DisplayListForm(SystemConstants.DISPLAY_QR_CODE);
            this.showFormInMainPanel(displayListForm);
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            /*
            ServerConnectionService serverConnection = new ServerConnectionService();
            Object result = serverConnection.synchronizeDrawAssociation().result;
            Console.WriteLine(result);
            JObject jsonObject = JObject.FromObject(result);
            Console.WriteLine(jsonObject);
            string createDate = (string) jsonObject["createDate"];
            Console.WriteLine(createDate);
            JObject draw = (JObject) jsonObject["lotteryDraw"];
            Console.WriteLine(draw);
            */
            
            /*
            DisplayQRForm qrForm = new DisplayQRForm();
            qrForm.Show();
            */
            
            String version = UtilityService.getApplicationVersion();
            MessageBox.Show($"Aplicación de Prueba. Version: {version} ");
            
        }
        #endregion

        //--------------------------------------- Acciones de Menú --------------------------------------//
        #region Acciones de Menú
        private void ventaDePapelesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.showFormInMainPanel(new NumberBoxForm());
        }

        private void prohibidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProhibitedNumberForm prohibitedForm = new ProhibitedNumberForm();
            prohibitedForm.ShowDialog();
        }

        private void ingresarGanadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawNumberWinningForm winningForm = new DrawNumberWinningForm();
            winningForm.ShowDialog();
        }

        private void salirDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        //--------------------------------------- Otros Eventos --------------------------------------//
        #region Otros Eventos
        private void ApplicationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.parentForm.Dispose();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        #endregion

    }
}
