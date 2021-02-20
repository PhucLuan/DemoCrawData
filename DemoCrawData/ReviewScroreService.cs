using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCrawData
{
    public class ReviewScroreService
    {
        public static void ReviewScrore(DT_QL_SV5TOT_6Entities db, DIEM diemSV)
        {
            //db.DIEMs.Add(diemSV);
            //Điểm được add vào phải trong thời gian xét
            if (diemSV.HOCKY_XETDIEM.THOIGIAN_XET.TrangThai == true)
            {
                //Nếu sinh viên chưa có điểm ở kỳ trước đó thì chỉ cần insert ko cần xét đạt tiêu chuẩn hay ko --> đến khi có điểm của cả 2 kỳ mới xét
                if (db.DIEMs.Where(x => x.Mssv == diemSV.Mssv && x.MaLoaiDiem == diemSV.MaLoaiDiem ).ToList().Count() == 1)
                {
                    var DiemHocKyTruoc = db.DIEMs.Where(x => x.MaLoaiDiem == diemSV.MaLoaiDiem).Select(x => x.Diem1).FirstOrDefault();

                    var QDdiemToiThieu_Truong = db.QUYDINH_DIEM
                        .Where(x => x.MaLoaiDiem == diemSV.MaLoaiDiem &&
                            x.MaDonVi == "HSVT" &&
                            x.Mathoigian == diemSV.HOCKY_XETDIEM.THOIGIAN_XET.MaThoiGian)
                        .FirstOrDefault();

                    var QDdiemToiThieu_Donvi = db.QUYDINH_DIEM
                        .Where(x => x.MaLoaiDiem == diemSV.MaLoaiDiem &&
                            x.MaDonVi == diemSV.SINH_VIEN.DON_VI.MaDonVi &&
                            x.Mathoigian == diemSV.HOCKY_XETDIEM.THOIGIAN_XET.MaThoiGian)
                        .FirstOrDefault();

                    if (diemSV.LOAI_DIEM.TenLoaiDiem == "Điểm rèn luyện")
                    {
                        AddTieuChuanDiemRenLuyen(db, diemSV, QDdiemToiThieu_Truong, QDdiemToiThieu_Donvi, (int)DiemHocKyTruoc);
                    }
                    else
                    {
                        AddTieuChuanDiemKhac(db, diemSV, QDdiemToiThieu_Truong, QDdiemToiThieu_Donvi, (int)DiemHocKyTruoc);
                    }

                }

                db.SaveChanges();
            }
            else
                throw new Exception("Điểm được thêm phải nằm trong thời gian xét");
        }
        //Xét đạt tiêu chuẩn cho Loại điểm là Điểm rèn luyện
        //Nếu điểm từng kỳ lớn hơn điểm tối thiểu thì đạt
        //Nếu lớn hơn điểm tối thiểu trường thì đạt cấp trường, khoa thì đạt cấp khoa, trường hợp nhỏ hơn ko làm gì cả
        private static void AddTieuChuanDiemRenLuyen(DT_QL_SV5TOT_6Entities db, DIEM diemSV,
            QUYDINH_DIEM QDdiemToiThieu_Truong,
            QUYDINH_DIEM QDdiemToiThieu_Donvi,
            int DiemHocKyTruoc)
        {
            if (DiemHocKyTruoc >= ((int)QDdiemToiThieu_Truong.DiemToiThieu) && (int)diemSV.Diem1 >= ((int)QDdiemToiThieu_Truong.DiemToiThieu))
            {
                db.THUCHIEN_TIEUCHUAN.Add(new THUCHIEN_TIEUCHUAN
                {
                    Mssv = diemSV.Mssv,
                    MaTieuChuan = (int)QDdiemToiThieu_Truong.MaTieuChuan,
                    MaThoiGian = diemSV.HOCKY_XETDIEM.THOIGIAN_XET.MaThoiGian
                });
            }
            else if (DiemHocKyTruoc >= ((int)QDdiemToiThieu_Donvi.DiemToiThieu) && (int)diemSV.Diem1 >= ((int)QDdiemToiThieu_Donvi.DiemToiThieu))
            {
                db.THUCHIEN_TIEUCHUAN.Add(new THUCHIEN_TIEUCHUAN
                {
                    Mssv = diemSV.Mssv,
                    MaTieuChuan = (int)QDdiemToiThieu_Donvi.MaTieuChuan,
                    MaThoiGian = diemSV.HOCKY_XETDIEM.THOIGIAN_XET.MaThoiGian
                });
            }
        }
        //Xét đạt tiêu chuẩn cho loại điểm khác
        //Nếu điểm trung bình 2 kỳ xét lớn hơn quy định tối thiểu thì đạt
        //Nếu lớn hơn điểm tối thiểu trường thì đạt cấp trường, khoa thì đạt cấp khoa, trường hợp nhỏ hơn ko làm gì cả
        private static void AddTieuChuanDiemKhac(DT_QL_SV5TOT_6Entities db,DIEM diemSV,
            QUYDINH_DIEM QDdiemToiThieu_Truong, 
            QUYDINH_DIEM QDdiemToiThieu_Donvi, 
            int DiemHocKyTruoc)
        {
            if (((int)DiemHocKyTruoc + (int)diemSV.Diem1) / 2 >= (int)QDdiemToiThieu_Truong.DiemToiThieu)
            {
                db.THUCHIEN_TIEUCHUAN.Add(new THUCHIEN_TIEUCHUAN
                {
                    Mssv = diemSV.Mssv,
                    MaTieuChuan = (int)QDdiemToiThieu_Truong.MaTieuChuan,
                    MaThoiGian = diemSV.HOCKY_XETDIEM.THOIGIAN_XET.MaThoiGian
                });
            }
            else if (((int)DiemHocKyTruoc + (int)diemSV.Diem1) / 2 >= (int)QDdiemToiThieu_Donvi.DiemToiThieu)
            {
                db.THUCHIEN_TIEUCHUAN.Add(new THUCHIEN_TIEUCHUAN
                {
                    Mssv = diemSV.Mssv,
                    MaTieuChuan = (int)QDdiemToiThieu_Donvi.MaTieuChuan,
                    MaThoiGian = diemSV.HOCKY_XETDIEM.THOIGIAN_XET.MaThoiGian
                });
            }
        }
    }
}
