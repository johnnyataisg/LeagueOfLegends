//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LeagueOfLegends.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Queue
    {
        public int id { get; set; }
        public string map { get; set; }
        public string pickType { get; set; }
        public string gameType { get; set; }
        public bool isActive { get; set; }
        public string notes { get; set; }
    }
}
