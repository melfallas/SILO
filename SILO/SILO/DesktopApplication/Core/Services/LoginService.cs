using SILO.DesktopApplication.Core.Repositories;
using SILO.DesktopApplication.Core.SystemConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Services
{
    class LoginService
    {
        public bool doLogin(string pUser, string pPassword)
        {
            bool successAuthentication = false;
            ApplicationUserRepository appUserRepository = new ApplicationUserRepository();
            AUS_ApplicationUser authenticatedUser = appUserRepository.getByUserAndPass(pUser, pPassword);
            if (authenticatedUser != null)
            {
                successAuthentication = true;
                SystemSession.sessionUser = authenticatedUser;
            }
            return successAuthentication;
        }
    }
}
