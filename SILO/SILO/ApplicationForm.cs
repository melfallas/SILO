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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            new NumberBoxForm();
            exec();
        }

        public void exec()
        {
            LotteryListRepository l = new LotteryListRepository();
            l.getDrawListTotals();
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

        private void ventaDePapelesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormInMainPanel(new NumberBoxForm());
        }

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

        private void aboutButton_Click(object sender, EventArgs e)
        {
            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            MessageBox.Show($"Aplicación de Prueba. Version: {version} ");
        }
    }
}
