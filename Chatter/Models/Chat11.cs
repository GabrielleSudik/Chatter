//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Chatter.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Chat11
    {
        public int ChatID { get; set; }
        public string UserID { get; set; }
        public string Message { get; set; }
        public System.DateTime DateTime { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
    }
}
