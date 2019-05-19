using SILO.DesktopApplication.Core.Repositories;
using SILO.DesktopApplication.Core.SystemConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Services
{
    public class LoginEventService
    {

        private LoginEventRepository loginEventRepo;

        public LoginEventService()
        {
            this.loginEventRepo = new LoginEventRepository();
        }

        public void saveLoginEvent(int authResult)
        {
            string externalIp = "ERROR";
            try
            {
                externalIp = new WebClient().DownloadString("http://icanhazip.com");
            }
            catch (Exception e)
            {
                // Capturar errores en el log
                LogService.log(e.Message, e.StackTrace);
            }
            LGV_LoginEvents loginEvent = new LGV_LoginEvents();
            loginEvent.LGV_EventDate = DateTime.Now;
            loginEvent.LGV_IpAdress = externalIp;
            loginEvent.LGV_User = authResult + " | " + SystemSession.username;
            loginEvent.LGV_DeviceId = ParameterService.getDeviceValue();
            loginEventRepo.saveWithStatus(loginEvent, loginEvent.LGV_Id, (e1, e2) => e1.copy(e2));
        }
    }
}
