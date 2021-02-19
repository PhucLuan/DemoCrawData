using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCrawData
{
    public class Activityhistory
    {
        public Activityhistory(string TenCT, string Donvitochuc, DateTime NgayTC, string Hocky, int Namhoc,string Giaithuong)
        {
            this.TenCT = TenCT;
            this.Donvitochuc = Donvitochuc;
            this.NgayTC = NgayTC;
            this.Hocky = Hocky;
            this.Namhoc = Namhoc;
            this.Giaithuong = Giaithuong;
        }
        public string TenCT { get; set; }
        public string Donvitochuc { get; set; }
        public DateTime NgayTC { get; set; }
        public string Hocky { get; set; }
        public int Namhoc { get; set; }
        public string Giaithuong { get; set; }
    }
}
