using SILO.Core.Constants;
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

namespace SILO.DesktopApplication.Core.Forms.Modules.Parameters
{
    public partial class SyncParamForm : Form
    {
        public ApplicationMediator appMediator { get; set; }

        public SyncParamForm(ApplicationMediator pMediator)
        {
            this.appMediator = pMediator;
            InitializeComponent();
            this.fillParameterBoxes();
        }

        public void fillParameterBoxes()
        {
            this.txtSyncPeriod.Text = ParameterService.getPeriodSyncIntervalInSeconds().ToString();
            this.cbxEnableSync.Checked = ParameterService.isPeriodSyncEnabled() ? true : false;
        }

        public void saveSyncParams()
        {
            string newTimeInterval = this.txtSyncPeriod.Text;
            ParameterService.setPeriodSyncInterval(newTimeInterval);
            ParameterService.setPeriodSyncEnabled(cbxEnableSync.Checked);
            this.appMediator.restartPeriodSync();
            this.closeView();
            MessageService.displayInfoMessage(GeneralConstants.SET_PERIOD_SYNC_MESSAGE + newTimeInterval, GeneralConstants.SET_PERIOD_SYNC_TITLE);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            this.saveSyncParams();
        }

        private void LocalParamForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.closeView();
            }
        }

        private void closeView()
        {
            this.appMediator.setAppTopMost(true);
            this.Dispose();
            this.appMediator.setAppTopMost(false);
        }
        
    }
}
