using SILO.Core.Constants;
using SILO.DesktopApplication.Core.Constants;
using SILO.DesktopApplication.Core.Repositories;
using SILO.DesktopApplication.Core.SystemConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SILO.DesktopApplication.Core.Services
{
    class ProgramInitializationService
    {


        public bool setInstancePointSale()
        {
            bool instanceSetup = false;
            AUS_ApplicationUser appUser = SystemSession.sessionUser;
            if (appUser == null)
            {
                MessageBox.Show(GeneralConstants.GET_SESSION_USER_ERROR);
            }
            else
            {
                long userRoleId = appUser.USR_UserRole;
                // Validar el Rol del usuario
                switch (userRoleId)
                {
                    case SystemConstants.ROLE_ADMIN_ID:
                        instanceSetup = this.validateSalePointInstance();
                        break;
                    case SystemConstants.ROLE_SA_ID:
                    case SystemConstants.ROLE_SALLER_ID:
                        instanceSetup = this.requestPosId();
                        break;
                    default:
                        break;
                }
            }
            return instanceSetup;
        }

        public string getLocalPointSale()
        {
            PointSaleService pointSaleService = new PointSaleService();
            return pointSaleService.getPointSaleInstance();
        }

        public string getPointSaleInstance()
        {
            PointSaleService pointSaleService = new PointSaleService();
            return pointSaleService.getPointSaleInstance();
        }

        private LPS_LotteryPointSale getApplicationPointSale()
        {
            PointSaleService pointSaleService = new PointSaleService();
            return pointSaleService.getPointSale();
        }

        private void initializePosParameter(long posId)
        {
            // Inicializar el parámetro para consecutivo del sorteo
            int maxIncrementDrawValue = this.setIncrementDrawParam();
            // Inicializar el parámetro para consecutivo de lista
            int maxIncrementListValue = this.setIncrementListParam();
            // Validar consecutivo de Sorteos en Servidor
            this.validateServerDrawConsecutive(maxIncrementDrawValue);
            // Validar consecutivo de Listas en Servidor
            this.validateServerListConsecutive(maxIncrementListValue);
            // Inicializar la sucursal
            PointSaleService pointSaleService = new PointSaleService();
            pointSaleService.initialize(posId);
        }

        private int setIncrementDrawParam()
        {
            DrawService drawService = new DrawService();
            long posId = SystemSession.sessionPointSale.LPS_Id;
            int maxIncrementDrawValue = drawService.getMaxDrawServerId(posId);
            //Console.WriteLine("Draw: " + maxIncrementDrawValue);
            LPR_LocalParameter listIncrementParam = ParameterService.getInitialDrawIncrementParam();
            if (listIncrementParam == null)
            {
                ParameterService.setInitialDrawIncrementParam(maxIncrementDrawValue.ToString(), 4);
            }
            else
            {
                maxIncrementDrawValue = Int32.Parse(listIncrementParam.LPR_Value);
            }
            return maxIncrementDrawValue;
        }

        private int setIncrementListParam()
        {
            ListService listService = new ListService();
            long posId = SystemSession.sessionPointSale.LPS_Id;
            int maxIncrementListValue = listService.getMaxDrawServerId(posId);
            //Console.WriteLine("List: " + maxIncrementListValue);
            LPR_LocalParameter listIncrementParam = ParameterService.getInitialListIncrementParam();
            if (listIncrementParam == null)
            {
                ParameterService.setInitialListIncrementParam(maxIncrementListValue.ToString(), 4);
            }
            else
            {
                maxIncrementListValue = Int32.Parse(listIncrementParam.LPR_Value);
            }
            return maxIncrementListValue;
        }

        private void validateServerDrawConsecutive(int pMaxIncrementDrawValue)
        {
            DrawService drawService = new DrawService();
            int drawConsecutive = drawService.getMaxDrawId();
            if(drawConsecutive < pMaxIncrementDrawValue)
            {
                drawService.updateDrawConsecutive(pMaxIncrementDrawValue);
            }
        }

        private void validateServerListConsecutive(int pMaxIncrementListValue)
        {
            ListService listService = new ListService();
            int drawConsecutive = listService.getMaxListId();
            if (drawConsecutive < pMaxIncrementListValue)
            {
                listService.updateListConsecutive(pMaxIncrementListValue);
            }
        }

        private bool validateSalePointInstance()
        {
            bool instanceSetting = true;
            string salePointId = this.getLocalPointSale();
            if (ValidationService.isValidId(salePointId))
            {
                LotteryPointSaleRepository pointSaleRepo = new LotteryPointSaleRepository();
                SystemSession.sessionPointSale = pointSaleRepo.getById(long.Parse(salePointId));
            }
            else
            {
                // Sucursal no inicializada, lanzar error
                instanceSetting = false;
                MessageService.displayErrorMessage(
                            GeneralConstants.UNINITIALIZED_SYSTEM_ERROR,
                            GeneralConstants.UNINITIALIZED_SYSTEM_TITLE
                            );
            }
            return instanceSetting;
        }


        private bool requestPosId()
        {
            bool instanceSetting = true;
            string salePointId = this.getLocalPointSale();
            if (ValidationService.isValidId(salePointId))
            {
                LotteryPointSaleRepository pointSaleRepo = new LotteryPointSaleRepository();
                SystemSession.sessionPointSale = pointSaleRepo.getById(long.Parse(salePointId));
            }
            else
            {
                // Solicitar inicialización de Sucursal solamente si el usuario no es SA
                if (SystemSession.sessionUser != null && SystemSession.sessionUser.USR_UserRole != SystemConstants.ROLE_SA_ID)
                {
                    instanceSetting = this.requestPosInitialization();
                }
            }
            return instanceSetting;
        }

        public bool requestPosInitialization()
        {
            bool instanceSetting = true;
            long userPosId = SystemSession.sessionUser.LPS_LotteryPointSale;
            LotteryPointSaleRepository pointSaleRepo = new LotteryPointSaleRepository();
            SystemSession.sessionPointSale = pointSaleRepo.getById(userPosId);
            DialogResult msgResult =
                MessageService.displayConfirmMessage(
                        GeneralConstants.getPosConfirmMessage(SystemSession.sessionUser, SystemSession.sessionPointSale),
                        GeneralConstants.POS_CONFIRM_TITLE
                        );
            // Procesar el resultado de la confirmación
            switch (msgResult)
            {
                case DialogResult.Yes:
                    // Configurar la instancia de sucursal
                    this.initializePosParameter(userPosId);
                    break;
                case DialogResult.No:
                    instanceSetting = false;
                    MessageService.displayErrorMessage(
                        GeneralConstants.POS_INITIALIZATION_ERROR,
                        GeneralConstants.POS_INITIALIZATION_TITLE
                        );
                    break;
                default:
                    break;
            }
            return instanceSetting;
        }


    }
}
