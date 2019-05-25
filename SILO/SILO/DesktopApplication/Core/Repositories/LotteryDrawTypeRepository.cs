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
            return this.getAll().Where(drawType => drawType.SYS_SynchronyStatus == SystemConstants.SYNC_STATUS_PENDING_TO_SERVER).ToList();
        }

        public List<LDT_LotteryDrawType> findActiveGroups()
        {
            //return this.getAll().Where(drawType => drawType.active == 1).ToList();
            return this.getAll();
        }

        public void changeStates(List<LDT_LotteryDrawType> pNumberList, long pNewStatus = SystemConstants.SYNC_STATUS_COMPLETED)
        {
            foreach (LDT_LotteryDrawType drawType in pNumberList)
            {
                drawType.SYS_SynchronyStatus = pNewStatus;
                this.save(drawType, drawType.LDT_Id, (e1, e2) => e1.copy(e2));
            }
        }

        // Método que registra la persistencia de una lista de objetos
        public void saveList(List<LDT_LotteryDrawType> pEntityList)
        {
            foreach (LDT_LotteryDrawType entity in pEntityList)
            {
                entity.SYS_SynchronyStatus = SystemConstants.SYNC_STATUS_COMPLETED;
                this.save(entity, entity.LDT_Id, (e1, e2) => e1.copy(e2));
            }
        }

    }
}
