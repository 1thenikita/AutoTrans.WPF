//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutoTrans.WPF.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class SchedulesRoute
    {
        public int ID { get; set; }
        public int RouteID { get; set; }
        public bool IsWeekday { get; set; }
        public System.TimeSpan TimeWork { get; set; }
    
        public virtual Route Route { get; set; }
    }
}
