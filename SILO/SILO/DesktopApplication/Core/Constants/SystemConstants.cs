using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Constants
{
    static class SystemConstants
    {

        // Constantes de Login
        public const int LOGIN_SUCCESS = 1;
        public const int LOGIN_SUCCESS_WITH_ERRORS = 2;
        public const int LOGIN_FAIL = 3;

        // Constantes para roles de usuario
        public const long ROLE_SA_ID = 1;
        public const long ROLE_ADMIN_ID = 2;
        public const long ROLE_SALLER_ID = 3;
        // Constantes para estados de sincronización
        public const long SYNC_STATUS_NONE = 0;
        public const long SYNC_STATUS_PENDING_TO_SERVER = 1;
        public const long SYNC_STATUS_PENDING_TO_CLIENT = 2;
        public const long SYNC_STATUS_COMPLETED = 3;
        public const long SYNC_STATUS_QRUPDATED = 4;
        // Constantes para estados de Sorteo
        public const long DRAW_STATUS_OPENED = 1;
        public const long DRAW_STATUS_CLOSED = 2;
        public const long DRAW_STATUS_REOPENED = 3;
        public const long DRAW_STATUS_QRUPDATED = 4;
        // Constantes para estados de lista
        public const long LIST_STATUS_CREATED = 1;
        public const long LIST_STATUS_CANCELED = 2;
        public const long LIST_STATUS_PRINTED = 3;
        public const long LIST_STATUS_PROCESSING = 4;

        // Constantes para tipos de formulario operaciones de lista
        public const int NUMBER_BOX_CODE = 1;
        public const int PRINTER_LIST_CODE = 2;
        public const int ERASER_LIST_CODE = 3;
        public const int COPY_LIST_CODE = 4;
        public const int DISPLAY_QR_CODE = 5;

        // Constantes de http
        public const string HTTP_GET_METHOD = "GET";
        public const string HTTP_POST_METHOD = "POST";
        public const string HTTP_PUT_METHOD = "PUT";
        public const string HTTP_DELETE_METHOD = "DELETE";

        // Sincronización
        public const int SYNC_DEFAULT_TYPE = 0;
        public const int SYNC_CLOSING_TYPE = 1;

    }
}
