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
    
    public partial class LPT_LocalParameterType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LPT_LocalParameterType()
        {
            this.LPR_LocalParameter = new HashSet<LPR_LocalParameter>();
        }
    
        public long LPT_Id { get; set; }
        public string LPT_DisplayName { get; set; }
        public string LPT_Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LPR_LocalParameter> LPR_LocalParameter { get; set; }
    }
}
