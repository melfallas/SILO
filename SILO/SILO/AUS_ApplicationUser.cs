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
    using System;
    using System.Collections.Generic;
    
    public partial class AUS_ApplicationUser
    {
        public long AUS_Id { get; set; }
        public string AUS_Username { get; set; }
        public string AUS_Password { get; set; }
        public long USR_UserRole { get; set; }
        public long LPS_LotteryPointSale { get; set; }
        public System.DateTime AUS_CreateDate { get; set; }
        public long AUS_IsActive { get; set; }

        public AUS_ApplicationUser copy(AUS_ApplicationUser pAppUser)
        {
            this.AUS_Username = pAppUser.AUS_Username;
            this.AUS_Password = pAppUser.AUS_Password;
            this.USR_UserRole = pAppUser.USR_UserRole;
            this.LPS_LotteryPointSale = pAppUser.LPS_LotteryPointSale;
            this.AUS_CreateDate = pAppUser.AUS_CreateDate;
            this.AUS_IsActive = pAppUser.AUS_IsActive;
            return this;
        }

        public virtual LPS_LotteryPointSale LPS_LotteryPointSale1 { get; set; }
        public virtual USR_UserRole USR_UserRole1 { get; set; }
    }
}
