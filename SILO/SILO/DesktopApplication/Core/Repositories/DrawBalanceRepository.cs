using SILO.DesktopApplication.Core.Abstract.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Repositories
{
    public class DrawBalanceRepository : GenericRepository<DBL_DrawBalance, Object>
    {

        public DBL_DrawBalance getByDraw(long pDrawId)
        {
            DBL_DrawBalance drawBalanceResult = null;
            List<DBL_DrawBalance> drawBalanceList = this.getAll()
                .Where(item => item.LTD_LotteryDraw == pDrawId).ToList();
            if (drawBalanceList.Count > 0)
            {
                drawBalanceResult = drawBalanceList[0];
            }
            return drawBalanceResult;
        }

        // Método que registra la persistencia de una lista de objetos
        public void saveList(List<DBL_DrawBalance> pEntityList)
        {
            foreach (DBL_DrawBalance entity in pEntityList)
            {
                this.save(entity, entity.DBL_Id, (e1, e2) => e1.copy(e2));
            }
        }
    }
}
