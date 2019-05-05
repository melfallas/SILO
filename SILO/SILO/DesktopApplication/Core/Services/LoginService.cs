using SILO.Core.Constants;
using SILO.DesktopApplication.Core.Constants;
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
        public int doLogin(string pUser, string pPassword)
        {
            int successAuthentication = SystemConstants.LOGIN_FAIL;
            ApplicationUserRepository appUserRepository = new ApplicationUserRepository();
            AUS_ApplicationUser authenticatedUser = appUserRepository.getByUserAndPass(pUser, pPassword);
            // Verificar resultado de la autenticación
            if (authenticatedUser != null)
            {
                // Verificar registro de dispositivos
                //if (this.validDevice(authenticatedUser) > 0)
                if(true)
                {
                    successAuthentication = this.validateUser(authenticatedUser);
                }
                else
                {
                    successAuthentication = SystemConstants.LOGIN_SUCCESS_WITH_ERRORS;
                    MessageService.displayErrorMessage(
                        GeneralConstants.UNREGISTERED_DEVICE_ERROR,
                        GeneralConstants.UNREGISTERED_DEVICE_TITLE
                    );
                }
            }
            return successAuthentication;
        }

        public int validDevice(AUS_ApplicationUser pCurrentUser)
        {
            int result = 1;
            if (pCurrentUser.USR_UserRole != SystemConstants.ROLE_SA_ID)
            {
                DeviceService deviceService = new DeviceService();
                result = deviceService.verifyRegisteredDevices();
            }
            return result;
        }

        public int validateUser(AUS_ApplicationUser pAuthenticatedUser)
        {
            int authenticationSuccess = SystemConstants.LOGIN_FAIL;
            // Verificar si el usuario está activo
            if (pAuthenticatedUser.AUS_IsActive == 0)
            {
                // Error de usuario inactivo
                authenticationSuccess = SystemConstants.LOGIN_SUCCESS_WITH_ERRORS;
                MessageService.displayErrorMessage(GeneralConstants.INACTIVE_USER_ERROR_MESSAGE, GeneralConstants.INACTIVE_USER_ERROR_TITLE);
            }
            else
            {
                // Realizar validación de sucursal sólo para usuarios de venta
                if (pAuthenticatedUser.USR_UserRole == SystemConstants.ROLE_SALLER_ID)
                {
                    authenticationSuccess = this.validateSallerUser(pAuthenticatedUser);
                }
                else
                {
                    // Si no es usuario de venta, indicar autenticación exitosa
                    this.checkSuccessAutentication(ref authenticationSuccess, pAuthenticatedUser);
                }
            }
            return authenticationSuccess;
        }

        public int validateSallerUser(AUS_ApplicationUser pAuthenticatedUser)
        {
            int authenticationSuccess = SystemConstants.LOGIN_FAIL;
            PointSaleService posService = new PointSaleService();
            string posInstance = posService.getPointSaleInstance();
            // Validar si sucursal del usuario coincide con la del sistema
            if (posInstance == null || pAuthenticatedUser.LPS_LotteryPointSale.ToString() == posInstance)
            {
                // Si la sucursal coincide, indicar autenticación exitosa
                this.checkSuccessAutentication(ref authenticationSuccess, pAuthenticatedUser);
            }
            else
            {
                // Error de inconsistencia en sucursal
                authenticationSuccess = SystemConstants.LOGIN_SUCCESS_WITH_ERRORS;
                MessageService.displayErrorMessage(GeneralConstants.INCORRRECT_POS_ERROR_MESSAGE, GeneralConstants.INCORRRECT_POS_ERROR_TITLE);
            }
            return authenticationSuccess;
        }

        private void checkSuccessAutentication(ref int pAuthenticationResult, AUS_ApplicationUser pUser)
        {
            // Marcar autenticación como exitosa
            pAuthenticationResult = SystemConstants.LOGIN_SUCCESS;
            // Guardar el usuario en sesión
            SystemSession.sessionUser = pUser;
        }

    }
}
