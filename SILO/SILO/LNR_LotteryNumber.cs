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
    
    public partial class LNR_LotteryNumber
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LNR_LotteryNumber()
        {
            this.LND_ListNumberDetail = new HashSet<LND_ListNumberDetail>();
        }
    
        public long LNR_Id { get; set; }
        public string LNR_Number { get; set; }
        public long LNR_IsProhibited { get; set; }
        public long SYS_SynchronyStatus { get; set; }

        public long copy(LNR_LotteryNumber pNumber)
        {
            long actualStatus = pNumber.SYS_SynchronyStatus;
            this.LNR_Number = pNumber.LNR_Number;
            this.LNR_IsProhibited = pNumber.LNR_IsProhibited;
            this.SYS_SynchronyStatus = pNumber.SYS_SynchronyStatus;
            return actualStatus;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LND_ListNumberDetail> LND_ListNumberDetail { get; set; }
        public virtual SYS_SynchronyStatus SYS_SynchronyStatus1 { get; set; }
    }
}
