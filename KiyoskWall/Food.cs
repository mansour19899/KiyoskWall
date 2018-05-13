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
    
    public partial class Food
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Food()
        {
            this.DailyMinuteItems = new HashSet<DailyMinuteItem>();
            this.Food_Material = new HashSet<Food_Material>();
            this.Res_Cont_ContractItem = new HashSet<Res_Cont_ContractItem>();
            this.TrayItems = new HashSet<TrayItem>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public Nullable<int> FoodType_Id_Fk { get; set; }
        public byte[] Image { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DailyMinuteItem> DailyMinuteItems { get; set; }
        public virtual FoodType FoodType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Food_Material> Food_Material { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Res_Cont_ContractItem> Res_Cont_ContractItem { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrayItem> TrayItems { get; set; }
    }
}
