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
    
    public partial class CPN_Company
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CPN_Company()
        {
            this.LPS_LotteryPointSale = new HashSet<LPS_LotteryPointSale>();
        }
    
        public long CPN_Id { get; set; }
        public string CPN_Code { get; set; }
        public string CPN_DisplayName { get; set; }
        public string CPN_Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LPS_LotteryPointSale> LPS_LotteryPointSale { get; set; }
    }
}