using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCrawData
{
    public class ReviewActivityService
    {
        public void ReviewActivity(string mssv, DT_QL_SV5TOT_6Entities dbContext,List<Activityhistory> activityhistories)
        {
            SINH_VIEN sv = dbContext.SINH_VIEN.Find(mssv);
            var ListActivity = dbContext.CHUONG_TRINH.Select(x => x.TenChuongTrinh).ToList();

            foreach (var item in activityhistories)
            {
                if (ListActivity.Contains(item.TenCT))
                {
                    CHUONG_TRINH chuongTrinh = dbContext.CHUONG_TRINH
                        .Where(x => x.TenChuongTrinh.ToString() == item.TenCT.ToString())
                        .FirstOrDefault();
                    int Matieuchuan = (int)chuongTrinh.MaTieuChuan;

                    TIEU_CHUAN tieuChuan = dbContext.TIEU_CHUAN.Find(Matieuchuan);

                    if (tieuChuan.Cap == 1)
                    {
                        if (sv.DON_VI.TenDonVi != item.Donvitochuc)
                        {
                            continue;
                        }
                    }
                    if (String.IsNullOrEmpty(item.Giaithuong))
                    {
                        if (tieuChuan.QuyDinhGiai == true)
                        {
                            continue;
                        }
                    }
                    dbContext.THAMGIA_CHUONGTRINH.Add(new THAMGIA_CHUONGTRINH
                    {
                        Mssv = mssv,
                        MaChuongTrinh = chuongTrinh.MaChuongTrinh,
                        Giai = String.IsNullOrEmpty(item.Giaithuong) ? 0 : 1,
                        MaThoiGian = 2
                    });
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
