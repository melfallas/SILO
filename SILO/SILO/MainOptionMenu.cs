using SILO.DesktopApplication.Core.Forms.Start;
using SILO.DesktopApplication.Core.Integration;
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
    public partial class MainOptionMenu : Form
    {

        public ListInstanceForm listInstance { get; set; }
        public ApplicationMediator appMediator { get; set; }

        public MainOptionMenu()
        {
            InitializeComponent();
        }

        public MainOptionMenu(ApplicationMediator pMediator, ListInstanceForm pListInstance)
        {
            this.appMediator = pMediator;
            this.listInstance = pListInstance;
            InitializeComponent();
        }

        public MainOptionMenu(ApplicationMediator pMediator)
        {
            this.appMediator = pMediator;
            this.listInstance = null;
            InitializeComponent();
        }

        private void MainOptionMenu_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D1:
                case Keys.NumPad1:
                    this.displayInstance(1, DateTime.Today);
                    break;
                case Keys.D2:
                case Keys.NumPad2:
                    this.displayInstance(2, DateTime.Today);
                    break;
                case Keys.D3:
                case Keys.NumPad3:
                    this.displayInstance(3, DateTime.Today);
                    break;
                case Keys.D4:
                case Keys.NumPad4:
                    this.displayInstance(4, DateTime.Today);
                    break;
                case Keys.D5:
                case Keys.NumPad5:
                    this.displayInstance(5, DateTime.Today);
                    break;
                case Keys.D6:
                case Keys.NumPad6:
                    this.displayInstance(6, DateTime.Today);
                    break;
                case Keys.D7:
                case Keys.NumPad7:
                    this.displayInstance(7, DateTime.Today);
                    break;
                case Keys.D8:
                case Keys.NumPad8:
                    this.displayInstance(8, DateTime.Today);
                    break;
                case Keys.Escape:
                    this.Dispose();
                    break;
                default:
                    break;
            }
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            if (this.listInstance != null)
            {
                this.listInstance.processList();
            }
            //this.Dispose();
        }

        private void reprintButton_Click(object sender, EventArgs e)
        {
            //ListSelectorForm listSelectorForm = new ListSelectorForm();
            //listSelectorForm.ShowDialog();
        }

        private void draw1Button_Click(object sender, EventArgs e)
        {
            this.displayInstance(1, DateTime.Today);
        }

        private void displayInstance(int pGroup, DateTime pDrawDate)
        {
            this.appMediator.setAppTopMost(true);
            this.Dispose();
            if (this.listInstance != null)
            {
                this.listInstance.Dispose();
            }
            if (this.appMediator.appForm != null)
            {
                this.appMediator.appForm.showBoxNumber();
            }
            this.appMediator.updateBoxNumber(pGroup, pDrawDate);
            this.appMediator.setAppTopMost(false);
            //this.listInstance.resetCurrentListCell();
        }

    }
}
