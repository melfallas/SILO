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
    
    public partial class LDT_LotteryDrawType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LDT_LotteryDrawType()
        {
            this.LTD_LotteryDraw = new HashSet<LTD_LotteryDraw>();
            this.LPF_LotteryPrizeFactor = new HashSet<LPF_LotteryPrizeFactor>();
        }
    
        public long LDT_Id { get; set; }
        public string LDT_Code { get; set; }
        public string LDT_DisplayName { get; set; }
        public string LDT_Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LTD_LotteryDraw> LTD_LotteryDraw { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LPF_LotteryPrizeFactor> LPF_LotteryPrizeFactor { get; set; }
    }
}
