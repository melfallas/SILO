using SILO.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Services
{
    class ConcreteMessageService
    {
        public static void displayPrizeFactorNotFoundMessage()
        {
            MessageService.displayErrorMessage(GeneralConstants.PRIZE_FACTOR_NOT_FOUND_MESSAGE, GeneralConstants.PRIZE_FACTOR_NOT_FOUND_TITLE);
        }
    }
}
