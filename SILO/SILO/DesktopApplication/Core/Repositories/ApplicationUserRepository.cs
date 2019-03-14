using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Repositories
{
    class ApplicationUserRepository
    {
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
