//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutoTrans.DB.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class StopsInRoute
    {
        public int ID { get; set; }
        public int Position { get; set; }
        public int StopID { get; set; }
        public int RouteID { get; set; }
    
        public virtual Route Route { get; set; }
        public virtual Stop Stop { get; set; }
    }
}
