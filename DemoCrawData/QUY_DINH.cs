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
    
    public partial class QUY_DINH
    {
        public string MaDonVi { get; set; }
        public int MaHoatDong { get; set; }
        public int MaLoaiDiem { get; set; }
        public Nullable<int> DiemToiThieu { get; set; }
    
        public virtual DON_VI DON_VI { get; set; }
        public virtual HOAT_DONG HOAT_DONG { get; set; }
        public virtual LOAI_DIEM LOAI_DIEM { get; set; }
    }
}
