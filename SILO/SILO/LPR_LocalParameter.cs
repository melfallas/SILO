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
    
    public partial class LPR_LocalParameter
    {
        public long LPR_Id { get; set; }
        public string LPR_Name { get; set; }
        public string LPR_Value { get; set; }
        public long LPT_LocalParameterType { get; set; }
    
        public virtual LPT_LocalParameterType LPT_LocalParameterType1 { get; set; }
    }
}
