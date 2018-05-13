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
    
    public partial class Guest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public Nullable<int> GuestType_Id_Fk { get; set; }
        public Nullable<bool> EdariConfirm { get; set; }
        public Nullable<int> EdariUser_Id_Fk { get; set; }
        public Nullable<int> PublicRelationUser_Id_Fk { get; set; }
        public Nullable<int> UnitCard_Id_Fk { get; set; }
        public Nullable<bool> Lunch { get; set; }
        public Nullable<bool> Dinner { get; set; }
        public Nullable<bool> AfterNight { get; set; }
        public Nullable<bool> ExtraMeal { get; set; }
        public Nullable<bool> Eftar { get; set; }
        public Nullable<int> Unit_Id_Fk { get; set; }
        public Nullable<int> Company_Id_Fk { get; set; }
        public string RegDate { get; set; }
        public Nullable<int> RegUser_Id_Fk { get; set; }
        public Nullable<bool> PublicRelationConfirm { get; set; }
        public string Note { get; set; }
    
        public virtual Company Company { get; set; }
        public virtual GuestType GuestType { get; set; }
        public virtual PoonehWebUser PoonehWebUser { get; set; }
        public virtual PoonehWebUser PoonehWebUser1 { get; set; }
        public virtual PoonehWebUser PoonehWebUser2 { get; set; }
        public virtual Unit Unit { get; set; }
        public virtual UnitCard UnitCard { get; set; }
    }
}
