//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KiyoskWall
{
    using System;
    using System.Collections.Generic;
    
    public partial class DailyMinuteDocument
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public string Name { get; set; }
        public Nullable<int> DailyMinute_Id_Fk { get; set; }
        public byte[] DocumentFile { get; set; }
        public string DMDDate { get; set; }
        public Nullable<int> User_Id_Fk { get; set; }
    
        public virtual DailyMinute DailyMinute { get; set; }
        public virtual PoonehWebUser PoonehWebUser { get; set; }
    }
}
