using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Services
{
    public class DrawService
    {
        private LotteryDrawRepository drawRepo;

        public DrawService()
        {
            this.drawRepo = new LotteryDrawRepository();
        }

        public void changeDrawStatus(long pNewStatus)
        {
            //this.drawRepo.getById(1);
            //this.drawRepo.save();
        }

    }
}
