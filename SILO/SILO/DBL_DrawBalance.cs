//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SILO
{
    using DesktopApplication.Core.Constants;
    using System;
    using System.Collections.Generic;

    public partial class DBL_DrawBalance
    {
        
        public long DBL_Id { get; set; }
        public long LTD_LotteryDraw { get; set; }
        public long DBL_SaleImport { get; set; }
        public long DBL_PayImport { get; set; }

        public DBL_DrawBalance()
        {
            LTD_LotteryDraw = 0;
            DBL_SaleImport = 0;
            DBL_PayImport = 0;
        }

        public long copy(DBL_DrawBalance pDrawBalance)
        {
            long actualStatus = SystemConstants.SYNC_STATUS_COMPLETED;
            this.LTD_LotteryDraw = pDrawBalance.LTD_LotteryDraw;
            this.DBL_SaleImport = pDrawBalance.DBL_SaleImport == 0 ? this.DBL_SaleImport : pDrawBalance.DBL_SaleImport;
            this.DBL_PayImport = pDrawBalance.DBL_PayImport == 0 ? this.DBL_PayImport : pDrawBalance.DBL_PayImport;
            return actualStatus;
        }

        public virtual LTD_LotteryDraw LTD_LotteryDraw1 { get; set; }
    }
}
