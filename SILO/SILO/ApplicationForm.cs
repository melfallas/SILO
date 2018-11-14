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
        }


        private void ShowFormInMainPanel(object pForm) {
            if (this.centerBoxPanel.Controls.Count > 0) {
                this.centerBoxPanel.Controls.RemoveAt(0);
            }
            Form formToAdd = pForm as Form;
            formToAdd.TopLevel = false;
            formToAdd.Dock = DockStyle.Fill;
            this.centerBoxPanel.Controls.Add(formToAdd);
            this.centerBoxPanel.Tag = formToAdd;
            formToAdd.Show();
        }

        private void ventaDePapelesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormInMainPanel(new NumberBoxForm());
        }
    }
}
