using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.Core.Constants
{
    class GeneralConstants
    {
        // Constantes Generales
        public const string EMPTY_STRING = "";

        public const string DISPLAY_DRAWTYPE_KEY_LABEL = "id";
        public const string DISPLAY_DRAWTYPE_VALUE_LABEL = "display";

        public const string NO_NAME_LABEL = "Sin Nombre";
        public const string SELECT_GROUP_LABEL = "Seleccione un grupo";

        // Security Constants
        public const string BAD_USER_OR_PASS_TITLE = "ERROR DE AUTENTICACIÓN";
        //public const string BAD_USER_OR_PASS_TITLE = "Error de Autenticación";
        public const string BAD_USER_OR_PASS_ERROR = "Usuario o contraseña incorrectos.\nPor favor, ingrese sus credenciales nuevamente.";
        public const string USER_AND_PASS_REQUIRED_VALIDATION = "Por favor, ingrese usuario y contraseña";

        // Inicialization Constants
        public const string GET_SESSION_USER_ERROR = "Error al obtener la sesión del usuario";
        public const string INITIAL_SYNCHRONIZATION_TITLE = "ERROR DE SINCRONIZACIÓN";
        public const string INITIAL_SYNCHRONIZATION_ERROR = "Error al conectarse al servidor.\nPor favor, revise su conexión de internet.";
        // Compañía no inicializada
        public const string UNINITIALIZED_COMPANY_TITLE = "COMPAÑÍA NO ESPECIFICADA";
        public const string UNINITIALIZED_COMPANY_ERROR = "La compañía no ha sido especificada.\nPor favor, contacte al administrador.";
        //--- Sistema no inicializado
        public const string UNINITIALIZED_SYSTEM_TITLE = "SISTEMA NO INICIALIZADO";
        public const string UNINITIALIZED_SYSTEM_ERROR = "El sistema no ha sido inicializado.\nDebe ingresar con un usuario de venta.";
        //--- Confirmación de sucursal
        public const string POS_CONFIRM_TITLE = "CONFIRMACIÓN DE SUCURSAL";
        public const string POS_CONFIRM_MESSAGE1 = "Inicializando sucursal con usuario ";
        public const string POS_CONFIRM_MESSAGE2 = "El usuario está configurado para iniciar con:\n\n";
        public const string POS_CONFIRM_MESSAGE3 = "¿Desea inicialiar el sistema con este punto de venta?\n";
        //--- Sucursal no especificada
        public const string POS_INITIALIZATION_TITLE = "SUCURSAL NO ESPECIFICADA";
        public const string POS_INITIALIZATION_ERROR = "No fue posible inicializar la sucursal.\nPor favor, vuelva a ingresar sus credenciales.\nPosteriormente confirme el punto de venta.";
        public const string GET_SESSION_USER_ERROR2 = "Error";


        //--- Anulación exitosa
        public const string SUCCESS_TRANSACTION_CANCELATION_TITLE = "Resultado de la anulación";
        public const string SUCCESS_TRANSACTION_CANCELATION_MESSAGE = "La transacción fue anulada exitosamente.";


        public static string getPosConfirmMessage(AUS_ApplicationUser pAppUser, LPS_LotteryPointSale pSalePoint) {
            string message = "";
            message += POS_CONFIRM_MESSAGE1 + pAppUser.AUS_Username.ToUpper() + "\n";
            message += POS_CONFIRM_MESSAGE2;
            message += "Sucursal #" + pSalePoint.LPS_Id + " - " + pSalePoint.LPS_DisplayName + "\n\n";
            message += POS_CONFIRM_MESSAGE3;
            return message;
        }


    }
}
