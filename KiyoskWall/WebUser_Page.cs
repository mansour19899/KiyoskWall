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
    
    public partial class WebUser_Page
    {
        public int Id { get; set; }
        public Nullable<int> WebUser_Id_Fk { get; set; }
        public Nullable<int> WebPage_Id_Fk { get; set; }
    
        public virtual PoonehWebPage PoonehWebPage { get; set; }
        public virtual PoonehWebUser PoonehWebUser { get; set; }
    }
}
