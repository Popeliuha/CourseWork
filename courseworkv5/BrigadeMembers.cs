//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace courseworkv5
{
    using System;
    using System.Collections.Generic;
    
    public partial class BrigadeMembers
    {
        public int BrigadeMembersId { get; set; }
        public int BrigadeId { get; set; }
        public int WorkerId { get; set; }
    
        public virtual Brigades Brigades { get; set; }
        public virtual Workers Workers { get; set; }
    }
}