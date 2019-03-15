using SILO.Core.Constants;
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
                    case SystemConstants.ROLE_SA_ID:
                    case SystemConstants.ROLE_ADMIN_ID:
                        instanceSetup = this.validateSalePointInstance();
                        break;
                    case SystemConstants.ROLE_SALLER_ID:
                        instanceSetup = this.requestPosId();
                        break;
                    default:
                        break;
                }
            }
            return instanceSetup;
        }

        public bool isPointSaleSetting()
        {
            PointSaleService pointSaleService = new PointSaleService();
            string posInstance = pointSaleService.getPointSaleInstance();
            return posInstance == null ? false : true;
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
            PointSaleService pointSaleService = new PointSaleService();
            pointSaleService.initialize(posId);
        }

        private bool validateSalePointInstance()
        {
            bool instanceSetting = true;
            if (!this.isPointSaleSetting())
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
            if (!this.isPointSaleSetting())
            {
                // Solicitar inicialización de Sucursal
                DialogResult msgResult = 
                    MessageService.displayConfirmMessage(
                            GeneralConstants.POS_CONFIRM_MESSAGE,
                            GeneralConstants.POS_CONFIRM_TITLE
                            );
                // Procesar el resultado de la confirmación
                switch (msgResult)
                {
                    case DialogResult.Yes:
                        // Configurar la instancia de sucursal
                        this.initializePosParameter(SystemSession.sessionUser.LPS_LotteryPointSale);
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
            }
            return instanceSetting;
        }


    }
}
