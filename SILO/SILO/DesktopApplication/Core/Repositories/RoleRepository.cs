using SILO.DesktopApplication.Core.Abstract.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Repositories
{
    class RoleRepository : GenericRepository<USR_UserRole, Object>
    {
        // Métodos que registra la persistencia de una lista de objetos
        public void saveList(List<USR_UserRole> pEntityList)
        {
            foreach (USR_UserRole entity in pEntityList)
            {
                this.save(entity, entity.USR_Id, (e1, e2) => e1.copy(e2));
            }
        }

    }
}
