﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO
{
    static class SystemConstants
    {

        // Constantes de estados de sincronización
        public const long SYNC_STATUS_PENDING_SEND = 1;
        public const long SYNC_STATUS_PENDING_RECEIVED = 2;
        public const long SYNC_STATUS_COMPLETED = 3;
        // Constantes de operaciones de lista
        public const int PRINTER_LIST_CODE = 1;
        public const int ERASER_LIST_CODE = 2;
        
    }
}