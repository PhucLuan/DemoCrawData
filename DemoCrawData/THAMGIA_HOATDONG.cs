//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemoCrawData
{
    using System;
    using System.Collections.Generic;
    
    public partial class THAMGIA_HOATDONG
    {
        public string Mssv { get; set; }
        public int MaHoatDong { get; set; }
        public string TrangThai { get; set; }
    
        public virtual HOAT_DONG HOAT_DONG { get; set; }
        public virtual SINH_VIEN SINH_VIEN { get; set; }
    }
}
