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
            this.LPF_LotteryPrizeFactor = new HashSet<LPF_LotteryPrizeFactor>();
            this.LTD_LotteryDraw = new HashSet<LTD_LotteryDraw>();
        }
    
        public long LDT_Id { get; set; }
        public string LDT_Code { get; set; }
        public string LDT_DisplayName { get; set; }
        public string LDT_Description { get; set; }
        public long SYS_SynchronyStatus { get; set; }

        public long copy(LDT_LotteryDrawType pDrawType)
        {
            long actualStatus = pDrawType.SYS_SynchronyStatus;
            this.LDT_Code = pDrawType.LDT_Code;
            this.LDT_DisplayName = pDrawType.LDT_DisplayName;
            this.LDT_Description = pDrawType.LDT_Description;
            this.SYS_SynchronyStatus = pDrawType.SYS_SynchronyStatus;
            return actualStatus;
        }

        public virtual SYS_SynchronyStatus SYS_SynchronyStatus1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LPF_LotteryPrizeFactor> LPF_LotteryPrizeFactor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LTD_LotteryDraw> LTD_LotteryDraw { get; set; }
    }
}
