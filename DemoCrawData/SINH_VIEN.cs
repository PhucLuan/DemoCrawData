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
    
    public partial class SINH_VIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SINH_VIEN()
        {
            this.DIEMs = new HashSet<DIEM>();
            this.KQ_THEO_TIEUCHI = new HashSet<KQ_THEO_TIEUCHI>();
            this.THOIDIEM_SV_THAMGIA = new HashSet<THOIDIEM_SV_THAMGIA>();
            this.THUCHIEN_TIEUCHUAN = new HashSet<THUCHIEN_TIEUCHUAN>();
            this.THAMGIA_CHUONGTRINH = new HashSet<THAMGIA_CHUONGTRINH>();
        }
    
        public string Mssv { get; set; }
        public string HoTen { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string NoiSinh { get; set; }
        public string SDT { get; set; }
        public string Lop { get; set; }
        public string DonVi { get; set; }
        public string Khoa { get; set; }
        public string Email { get; set; }
        public Nullable<int> IDuser { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DIEM> DIEMs { get; set; }
        public virtual DON_VI DON_VI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KQ_THEO_TIEUCHI> KQ_THEO_TIEUCHI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THOIDIEM_SV_THAMGIA> THOIDIEM_SV_THAMGIA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THUCHIEN_TIEUCHUAN> THUCHIEN_TIEUCHUAN { get; set; }
        public virtual USER USER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THAMGIA_CHUONGTRINH> THAMGIA_CHUONGTRINH { get; set; }
    }
}
