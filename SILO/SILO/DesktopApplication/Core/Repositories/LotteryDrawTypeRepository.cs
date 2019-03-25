using SILO.DesktopApplication.Core.Abstract.Generic;
using SILO.DesktopApplication.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Repositories
{
    class LotteryDrawTypeRepository : GenericRepository<LDT_LotteryDrawType, Object>
    {
        
        public List<LDT_LotteryDrawType> findUnsynTypes()
        {
            return this.getAll().Where(user => user.SYS_SynchronyStatus == SystemConstants.SYNC_STATUS_PENDING_TO_SERVER).ToList();
        }
        

        /*
        public List<LDT_LotteryDrawType> getAll()
        {
            List<LDT_LotteryDrawType> drawTypeList = null;
            using (var context = new SILOEntities())
            {
                drawTypeList = context.LDT_LotteryDrawType.ToList();
            }
            return drawTypeList;
        }

        public LDT_LotteryDrawType getById(long pId)
        {
            LDT_LotteryDrawType drawType = null;
            using (var context = new SILOEntities())
            {
                drawType = context.LDT_LotteryDrawType.Find(pId);
            }
            return drawType;
        }
        */
    }
}
