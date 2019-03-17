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
        // Compañía no inicializada
        public const string UNINITIALIZED_COMPANY_TITLE = "COMPAÑÍA NO ESPECIFICADA";
        public const string UNINITIALIZED_COMPANY_ERROR = "La compañía no ha sido especificada.\nPor favor, contacte al administrador.";
        //--- Sistema no inicializado
        public const string UNINITIALIZED_SYSTEM_TITLE = "SISTEMA NO INICIALIZADO";
        public const string UNINITIALIZED_SYSTEM_ERROR = "El sistema no ha sido inicializado.\nDebe ingresar con un usuario de venta.";
        //--- Confirmación de sucursal
        public const string POS_CONFIRM_TITLE = "CONFIRMACIÓN DE SUCURSAL";
        public const string POS_CONFIRM_MESSAGE = "Debe especificar sucursal";
        //--- Sucursal no especificada
        public const string POS_INITIALIZATION_TITLE = "SUCURSAL NO ESPECIFICADA";
        public const string POS_INITIALIZATION_ERROR = "No fue posible inicializar la sucursal.\nPor favor, vuelva a ingresar sus credenciales.\nPosteriormente confirme el punto de venta.";
        public const string GET_SESSION_USER_ERROR2 = "Error";



    }
}
