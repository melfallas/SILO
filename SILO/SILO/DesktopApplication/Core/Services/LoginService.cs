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
                // Verificar si el suaurio está activo
                if (authenticatedUser.AUS_IsActive == 0)
                {
                    // Error de usuario inactivo
                    successAuthentication = SystemConstants.LOGIN_SUCCESS_WITH_ERRORS;
                    MessageService.displayErrorMessage(GeneralConstants.INACTIVE_USER_ERROR_MESSAGE, GeneralConstants.INACTIVE_USER_ERROR_TITLE);
                }
                else
                {
                    // Realizar validación de sucursal sólo para usuarios de venta
                    if (authenticatedUser.USR_UserRole == SystemConstants.ROLE_SALLER_ID)
                    {
                        PointSaleService posService = new PointSaleService();
                        string posInstance = posService.getPointSaleInstance();
                        // Validar si sucursal del usuario coincide con la del sistema
                        if (authenticatedUser.LPS_LotteryPointSale.ToString() == posInstance)
                        {
                            // Si la sucursal coincide, indicar autenticación exitosa
                            this.checkSuccessAutentication(ref successAuthentication, authenticatedUser);
                        }
                        else
                        {
                            // Error de inconsistencia en sucursal
                            successAuthentication = SystemConstants.LOGIN_SUCCESS_WITH_ERRORS;
                            MessageService.displayErrorMessage(GeneralConstants.INCORRRECT_POS_ERROR_MESSAGE, GeneralConstants.INCORRRECT_POS_ERROR_TITLE);
                        }
                    }
                    else
                    {
                        // Si no es usuario de venta, indicar autenticación exitosa
                        this.checkSuccessAutentication(ref successAuthentication, authenticatedUser);
                    }
                }
            }
            return successAuthentication;
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
