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
    
    public partial class THUCHIEN_TIEUCHUAN
    {
        public string Mssv { get; set; }
        public int MaTieuChuan { get; set; }
        public int MaThoiGian { get; set; }
    
        public virtual SINH_VIEN SINH_VIEN { get; set; }
        public virtual THOIGIAN_XET THOIGIAN_XET { get; set; }
        public virtual TIEU_CHUAN TIEU_CHUAN { get; set; }
    }
}
