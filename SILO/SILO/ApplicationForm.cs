using Newtonsoft.Json.Linq;
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

namespace SILO
{
    public partial class ApplicationForm : Form
    {
        public Form parentForm { get; set; }

        public ApplicationForm(Form pParentForm)
        {
            InitializeComponent();
            this.parentForm = pParentForm;
            this.userNameLabel.Text = SystemSession.username;
            //new NumberBoxForm();
        }

        private void ShowFormInMainPanel(object pForm) {
            this.centerBoxPanel.Hide();
            if (this.centerBoxPanel.Controls.Count > 0) {
                this.centerBoxPanel.Controls.RemoveAt(0);
            }
            Form formToAdd = pForm as Form;
            formToAdd.TopLevel = false;
            formToAdd.Dock = DockStyle.Fill;
            this.centerBoxPanel.Controls.Add(formToAdd);
            this.centerBoxPanel.Tag = formToAdd;
            formToAdd.Show();
            this.centerBoxPanel.Show();
        }

        //--------------------------------------- Botones de Menú Lateral --------------------------------------//

        private void saleMenuButton_Click(object sender, EventArgs e)
        {
            ShowFormInMainPanel(new NumberBoxForm());
        }

        private void printMenuButton_Click(object sender, EventArgs e)
        {
            //ShowFormInMainPanel(new GeneralConfigurationForm());
            DisplayListForm displayListForm = new DisplayListForm(SystemConstants.PRINTER_LIST_CODE);
            ShowFormInMainPanel(displayListForm);
            //ListSelectorForm listSelectorForm = new ListSelectorForm();
            //listSelectorForm.ShowDialog();
        }

        private void eraseButton_Click(object sender, EventArgs e)
        {
            DisplayListForm displayListForm = new DisplayListForm(SystemConstants.ERASER_LIST_CODE);
            ShowFormInMainPanel(displayListForm);
        }

        private void displayQRMenuButton_Click(object sender, EventArgs e)
        {
            DisplayListForm displayListForm = new DisplayListForm(SystemConstants.DISPLAY_QR_CODE);
            ShowFormInMainPanel(displayListForm);
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
            
            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            MessageBox.Show($"Aplicación de Prueba. Version: {version} ");
            
        }


        //--------------------------------------- Acciones de Menú --------------------------------------//

        private void ventaDePapelesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormInMainPanel(new NumberBoxForm());
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

        //--------------------------------------- Otros Eventos --------------------------------------//

        private void ApplicationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.parentForm.Dispose();
        }
    }
}
