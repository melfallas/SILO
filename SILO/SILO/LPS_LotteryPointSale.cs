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
    
    public partial class LPS_LotteryPointSale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LPS_LotteryPointSale()
        {
            this.AUS_ApplicationUser = new HashSet<AUS_ApplicationUser>();
            this.LPF_LotteryPrizeFactor = new HashSet<LPF_LotteryPrizeFactor>();
            this.LTL_LotteryList = new HashSet<LTL_LotteryList>();
        }

        public void copy(LPS_LotteryPointSale pSalePoint)
        {
            this.LPS_Code = pSalePoint.LPS_Code;
            this.LPS_DisplayName = pSalePoint.LPS_DisplayName;
            this.LPS_Description = pSalePoint.LPS_Description;
            this.CPN_Company = pSalePoint.CPN_Company;
            this.LPS_Counter = pSalePoint.LPS_Counter;
            this.LPS_IsActive = pSalePoint.LPS_IsActive;
            this.SYS_SynchronyStatus = pSalePoint.SYS_SynchronyStatus;
            this.LPS_CreateDate = pSalePoint.LPS_CreateDate;
        }
    
        public long LPS_Id { get; set; }
        public string LPS_Code { get; set; }
        public string LPS_DisplayName { get; set; }
        public string LPS_Description { get; set; }
        public System.DateTime LPS_CreateDate { get; set; }
        public long CPN_Company { get; set; }
        public long LPS_Counter { get; set; }
        public long LPS_IsActive { get; set; }
        public long SYS_SynchronyStatus { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AUS_ApplicationUser> AUS_ApplicationUser { get; set; }
        public virtual CPN_Company CPN_Company1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LPF_LotteryPrizeFactor> LPF_LotteryPrizeFactor { get; set; }
        public virtual SYS_SynchronyStatus SYS_SynchronyStatus1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LTL_LotteryList> LTL_LotteryList { get; set; }
    }
}
