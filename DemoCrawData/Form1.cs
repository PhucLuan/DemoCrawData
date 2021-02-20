using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.SqlServer;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoCrawData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DT_QL_SV5TOT_6Entities db = new DT_QL_SV5TOT_6Entities();

        private DataTable dt;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            //ReviewActivityService reviewActivityService = new ReviewActivityService();

            //string htmlCode = System.IO.File.ReadAllText(@"C:\HỌC TẬP\KINH TẾ TRẺ\demo.txt");

            //ActivityHistoryService activityHistoryService = new ActivityHistoryService();
            //reviewActivityService.ReviewActivity("31171022596", db, activityHistoryService.GetActivityhistories(htmlCode));
            //dataGridView1.DataSource = activityHistoryService.GetActivityhistories(htmlCode);

            DIEM diemSV = new DIEM { Mssv = "31171025965", MaHocKy = 2, MaLoaiDiem = 1, Diem1 = 80 };
            db.DIEMs.Add(diemSV);
            ReviewScroreService.ReviewScrore(db, diemSV);



            //activityHistoryService.GetActivityhistories(htmlCode);
            //HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();

            //doc.LoadHtml(htmlCode);

            //dt = new DataTable();
            //dt.Columns.Add("Name", typeof(string));
            //dt.Columns.Add("Value", typeof(string));

            //int count = 0;
            //List<string> Dshd = new List<string>();
            //List<Activityhistory> activityhistories = new List<Activityhistory>();
            //activityhistories
            //                .Add(new Activityhistory("Test chương trình cấp khoa BIT",
            //                                          "Khoa Công Nghệ Thông Tin Kinh Doanh",
            //                                          DateTime.ParseExact("10/10/2010", "d/M/yyyy", CultureInfo.InvariantCulture),
            //                                          "Cuối",
            //                                          2020,
            //                                          null));
            ////Crawdata from youth
            //foreach (HtmlNode table in doc.DocumentNode.SelectNodes("/html/body/form/div[3]/div[2]/div/table"))
            //{
            //    foreach (HtmlNode row in table.SelectNodes("/html/body/form/div[3]/div[2]/div/table//tr"))
            //    {

            //        if (count == 0)
            //        {
            //            List<string> check = row.SelectNodes("th").ToList().Select(x => x.InnerText).Take(8).ToList();
            //        }
            //        else
            //        {
            //            List<string> check = row.SelectNodes("td").ToList().Select(x => x.InnerText).Take(8).ToList();
            //            string GiaiThuong = check[7];
            //            activityhistories
            //                .Add(new Activityhistory(check[0].ToString(),
            //                                          check[1],
            //                                          DateTime.ParseExact(check[2].ToString(), "d/M/yyyy", CultureInfo.InvariantCulture),
            //                                          check[3],
            //                                          int.Parse(check[4]),
            //                                          GiaiThuong == "&nbsp;"?null:check[7]));
            //            //dataGridView1.Rows.Add(check[0], check[1], check[2], check[3], check[4], check[5], check[6], check[7]);
            //        }
            //        count++;
            //    }
            //}

        }


        List<string> ListStuActivity = new List<string>();


        private void btnValidation_Click(object sender, EventArgs e)
        {
            ListStuActivity.Add("Cuộc thi học thuật \"Global Talents 2020\" - CLB Công nghệ Kinh tế");
            ListStuActivity.Add("Hội thao truyền thống khoa Ngân hàng năm 2020 môn Bóng đá Nam");
            ListStuActivity.Add("Chiến dịch Xuân Tình nguyện 2020 - Hội Sinh viên trường");
            ListStuActivity.Add("sdfsdsdg");
            ListStuActivity.Add("hkgfjgsldjfs");

            //Lấy danh sách chương trinh
            List<string> commons = db.CHUONG_TRINH.Select(x => x.TenChuongTrinh).ToList().Intersect(ListStuActivity.Select(s2 => s2)).ToList();
            //Kiểm tra chương trình thuộc hoạt động nào
            foreach (var item in commons)
            {
                int IDhoatDong = Convert.ToInt32(db.CHUONG_TRINH.Where(x => x.TenChuongTrinh.ToString() == item.ToString()).Select(x => x.MaTieuChuan).FirstOrDefault());
                var tieuChi = db.TIEU_CHUAN.Where(x => x.MaTieuChuan == IDhoatDong).Select(x => x.MaTieuChi).FirstOrDefault();
            }

        }
    }
}