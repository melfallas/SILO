using SILO.DesktopApplication.Core.Forms.Modules.Sale;
using SILO.DesktopApplication.Core.Forms.Start;
using SILO.DesktopApplication.Core.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Integration
{
    public class ApplicationMediator : MediatorObject
    {
        public ApplicationForm appForm { get; set; }
        public NumberBoxForm appNumberBox { get; set; }


        public void fillDrawInfoLabels(DateTime pDrawDate, long pGroupId)
        {
            if (this.appForm != null)
            {
                this.appForm.fillDrawInfoLabels(pDrawDate, pGroupId);
            }
        }

        public void setAppTopMost(bool pSetTop) {
            this.appForm.TopMost = pSetTop;
        }

        public void setApplicationFocus()
        {
            if (this.appForm != null)
            {
                this.appForm.setApplicationFocus();
            }
        }

        public void closeTransactions(int pSyncType, DateTime? pDrawDate = null, long pDrawType = 0) {
            if (this.appForm != null)
            {
                this.appForm.closeTransactions(pSyncType, pDrawDate, pDrawType);
            }
        }

        public void updateTotalBoxes()
        {
            if (this.appNumberBox != null)
            {
                this.appNumberBox.updateTotalBoxes();
            }
        }

        public void displayNumberBox(DateTime? pDrawDate = null, long pGroupId = 0, bool pUpdateBox = false)
        {
            if (this.appForm != null)
            {
                this.appForm.showFormInMainPanel(new NumberBoxForm(this), pDrawDate, pGroupId, pUpdateBox);
            }
        }

        public void setBoxNumberGroup(int pGroupId)
        {
            if (this.appNumberBox != null)
            {
                this.appNumberBox.setSelectedGroup(pGroupId);
            }
        }
        
        public void updateBoxNumber()
        {
            if (this.appNumberBox != null)
            {
                this.appNumberBox.updateNumberBox();
            }
        }

        public void updateBoxNumber(long pGroupId) {
            if (this.appNumberBox != null)
            {
                this.appNumberBox.updateNumberBox(pGroupId);
            }
        }

        public void updateBoxNumber(long pGroupId, DateTime pDrawDate)
        {
            if (this.appNumberBox != null)
            {
                this.appNumberBox.updateNumberBox(pDrawDate, pGroupId);
            }
        }

    }
}
