using SILO.DesktopApplication.Core.Forms.Modules.Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Pattern
{
    public interface MediatorObject
    {
        void updateBoxNumber();
        void updateBoxNumber(long pGroupId);

        void displayNumberBox(DateTime? pDrawDate = null, long pGroupId = 0);



    }
}
