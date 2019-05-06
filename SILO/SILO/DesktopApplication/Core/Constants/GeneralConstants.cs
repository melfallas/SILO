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

        public const string DEFAULT_POS_INSTANCE = "";


        public const string DISPLAY_DRAWTYPE_KEY_LABEL = "id";
        public const string DISPLAY_DRAWTYPE_VALUE_LABEL = "display";

        public const string NO_NAME_LABEL = "Sin Nombre";
        public const string SELECT_GROUP_LABEL = "SELECCIONE UN GRUPO";


        public const string EMPTY_WINNER_VALUE = "";

        // Security Constants
        public const string BAD_USER_OR_PASS_TITLE = "ERROR DE AUTENTICACIÓN";
        //public const string BAD_USER_OR_PASS_TITLE = "Error de Autenticación";
        public const string BAD_USER_OR_PASS_ERROR = "Usuario o contraseña incorrectos.\nPor favor, ingrese sus credenciales nuevamente.";
        public const string USER_AND_PASS_REQUIRED_VALIDATION = "Por favor, ingrese usuario y contraseña";

        public const string INACTIVE_USER_ERROR_TITLE = "USUARIO INACTIVO";
        public const string INACTIVE_USER_ERROR_MESSAGE = "El usuario está inactivo y no puede ingresar.\nPor favor, contacte al administrador.";
        public const string INCORRRECT_POS_ERROR_TITLE = "INCONSISTENCIA EN SUCURSAL";
        public const string INCORRRECT_POS_ERROR_MESSAGE = "El usuario está asignado a otra sucursal y no puede ingresar.\nPor favor, contacte al administrador.";

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
        public const string POS_CONFIRM_MESSAGE3 = "¿Desea inicializar el sistema con este punto de venta?\n";
        //--- Sucursal no especificada
        public const string POS_INITIALIZATION_TITLE = "SUCURSAL NO ESPECIFICADA";
        public const string POS_INITIALIZATION_ERROR = "No fue posible inicializar la sucursal.\nPor favor, vuelva a ingresar sus credenciales.\nPosteriormente confirme el punto de venta.";
        public const string GET_SESSION_USER_ERROR2 = "Error";

        //--- Dispositivo no registrado
        public const string UNREGISTERED_DEVICE_TITLE = "ERROR EN EL REGISTRO DEL DISPOSITIVO";
        public const string UNREGISTERED_DEVICE_ERROR = "El dispositivo no se encuentra configurado adecuadamente.\nPor favor, contacte al administrador.";



        // Constantes de VENTA
        public const string PRIZE_FACTOR_NOT_FOUND_TITLE = "FACTOR DE PREMIO NO ESPECIFICADO";
        public const string PRIZE_FACTOR_NOT_FOUND_MESSAGE = "No se ha especificado un factor de premio para el grupo.\nPor favor, contacte al administrador.";

        public const string DRAW_CLOSED_TITLE = "SORTEO CERRADO - NO SE PUEDE VENDER";
        public const string DRAW_CLOSED_MESSAGE = "El sorteo se encuentra cerrado.\nNo es posible realizar la operación.";


        //--- Venta no permitida
        public const string NOT_ALLOWED_PREVIOUS_DATE_SALE_TITLE = "VENTA NO PERMITIDA";
        public const string NOT_ALLOWED_PREVIOUS_DATE_SALE_MESSAGE = "No es posible realizar ventas de días anteriores.\nSolamente podrá visualizar el resumen de los importes.";

        //--- Reversión exitosa
        public const string SUCCESS_TRANSACTION_CANCELATION_TITLE = "RESULTADO DE LA REVERSIÓN";
        public const string SUCCESS_TRANSACTION_CANCELATION_MESSAGE = "La transacción fue anulada exitosamente.";


        public const string CHECKBOX_NAME_ID_LABEL = "Id";


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
