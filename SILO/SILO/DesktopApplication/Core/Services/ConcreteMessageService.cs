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

        public static void displayDrawClosedMessage()
        {
            MessageService.displayErrorMessage(GeneralConstants.DRAW_CLOSED_MESSAGE, GeneralConstants.DRAW_CLOSED_TITLE);
        }

        public static void systemUpdatingMessage()
        {
            MessageService.displayInfoMessage(GeneralConstants.SYSTEM_UPDATING_MESSAGE, GeneralConstants.SYSTEM_UPDATING_TITLE);
        }
    }
}
