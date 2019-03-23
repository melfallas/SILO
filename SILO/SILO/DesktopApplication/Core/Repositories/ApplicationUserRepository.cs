﻿using SILO.DesktopApplication.Core.Abstract.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Repositories
{
    class ApplicationUserRepository : GenericRepository<AUS_ApplicationUser, Object>
    {
        // Métodos que registra la persistencia de una lista de objetos
        public void saveList(List<AUS_ApplicationUser> pEntityList)
        {
            foreach (AUS_ApplicationUser entity in pEntityList)
            {
                this.save(entity, entity.AUS_Id, (e1, e2) => e1.copy(e2));
            }
        }

        public AUS_ApplicationUser getByUserAndPass(string pUser, string pPassword)
        {
            AUS_ApplicationUser appUser = null;
            using (var context = new SILOEntities())
            {
                List<AUS_ApplicationUser> userList = context.AUS_ApplicationUser
                    .Where(user => user.AUS_Username == pUser)
                    .Where(user => user.AUS_Password == pPassword)
                    .ToList()
                    ;
                if (userList.Count() > 0)
                {
                    appUser = userList[0];
                }
            }
            return appUser;
        }

    }
}
