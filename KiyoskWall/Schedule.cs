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
    
    public partial class Schedule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Schedule()
        {
            this.PoonehReservations = new HashSet<PoonehReservation>();
        }
    
        public int Id { get; set; }
        public string SDate { get; set; }
        public Nullable<int> Restaurant_Id_Fk { get; set; }
        public Nullable<int> Tray_Id_Fk { get; set; }
        public string RegDate { get; set; }
        public Nullable<int> Meal_Id_Fk { get; set; }
        public Nullable<int> PorsNo { get; set; }
        public Nullable<int> Res_Cont_Contract_Id_Fk { get; set; }
        public Nullable<int> AdditionalPorsNo { get; set; }
        public Nullable<int> RemainPorsNo { get; set; }
        public Nullable<System.DateTime> PoonehArchived { get; set; }
    
        public virtual Meal Meal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PoonehReservation> PoonehReservations { get; set; }
        public virtual Res_Cont_Contract Res_Cont_Contract { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual Tray Tray { get; set; }
    }
}
