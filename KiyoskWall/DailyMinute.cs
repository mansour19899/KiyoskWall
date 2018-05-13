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
    
    public partial class DailyMinute
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DailyMinute()
        {
            this.DailyMinuteDocuments = new HashSet<DailyMinuteDocument>();
            this.DailyMinuteItems = new HashSet<DailyMinuteItem>();
        }
    
        public int Id { get; set; }
        public string MinuteDate { get; set; }
        public Nullable<int> Restaurant_Id_Fk { get; set; }
        public Nullable<int> Res_Cont_Contract_Id_Fk { get; set; }
        public Nullable<int> User_Id_Fk { get; set; }
        public string Note { get; set; }
        public Nullable<int> Meal_Id_Fk { get; set; }
    
        public virtual Meal Meal { get; set; }
        public virtual PoonehWebUser PoonehWebUser { get; set; }
        public virtual Res_Cont_Contract Res_Cont_Contract { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DailyMinuteDocument> DailyMinuteDocuments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DailyMinuteItem> DailyMinuteItems { get; set; }
    }
}
