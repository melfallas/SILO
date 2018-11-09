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


        private void ShowFormInRightPanel(object pForm) {
            if (this.boxRightPanel.Controls.Count > 0) {
                this.boxRightPanel.Controls.RemoveAt(0);
            }
            Form formToAdd = pForm as Form;
            formToAdd.TopLevel = false;
            formToAdd.Dock = DockStyle.Fill;
            this.boxRightPanel.Controls.Add(formToAdd);
            this.boxRightPanel.Tag = formToAdd;
            formToAdd.Show();
        }

        private void ventaDePapelesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormInRightPanel(new numberBoxForm());
        }
    }
}
