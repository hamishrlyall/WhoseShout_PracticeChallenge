//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WhoseShoutApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class coffeeDate
    {
        public int coffeeDateID { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public System.DateTime dateTime { get; set; }
        public string venue { get; set; }
    
        public virtual Colleague Colleague { get; set; }
    }
}
