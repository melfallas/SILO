using SILO.DesktopApplication.Core.Abstract.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Repositories
{
    public class LoginEventRepository : GenericRepository<LGV_LoginEvents, Object>
    {
        // Método que registra la persistencia de una lista de objetos
        public void saveList(List<LGV_LoginEvents> pEntityList)
        {
            foreach (LGV_LoginEvents entity in pEntityList)
            {
                this.saveWithStatus(entity, entity.LGV_Id, (e1, e2) => e1.copy(e2));
            }
        }
    }
}
