using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Constants
{
    static class SystemConstants
    {

        // Constantes de roles de usuario
        public const long ROLE_SA_ID = 1;
        public const long ROLE_ADMIN_ID = 2;
        public const long ROLE_SALLER_ID = 3;
        // Constantes de estados de sincronización
        public const long SYNC_STATUS_NONE = 0;
        public const long SYNC_STATUS_PENDING_SEND = 1;
        public const long SYNC_STATUS_PENDING_RECEIVED = 2;
        public const long SYNC_STATUS_COMPLETED = 3;
        // Constantes de estados de lista
        public const long LIST_STATUS_CREATED = 1;
        // Constantes de operaciones de lista
        public const int PRINTER_LIST_CODE = 1;
        public const int ERASER_LIST_CODE = 2;
        public const int DISPLAY_QR_CODE = 3;

    }
}
