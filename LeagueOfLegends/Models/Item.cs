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
    
    public partial class Item
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string colloq { get; set; }
        public string plaintext { get; set; }
        public string into { get; set; }
        public Nullable<int> image { get; set; }
        public Nullable<int> gold { get; set; }
        public string tags { get; set; }
        public Nullable<bool> map10 { get; set; }
        public Nullable<bool> map11 { get; set; }
        public Nullable<bool> map12 { get; set; }
        public Nullable<int> depth { get; set; }
    }
}
