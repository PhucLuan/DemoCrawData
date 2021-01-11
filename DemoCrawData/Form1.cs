using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private DataTable dt;

        private void Form1_Load(object sender, EventArgs e)
        {
            string htmlCode = System.IO.File.ReadAllText(@"D:\HỌC TẬP\KINH TẾ TRẺ\demo.txt");

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();

            doc.LoadHtml(htmlCode);

            dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Value", typeof(string));

            int count = 0;
            List<string> Dshd = new List<string>();

            foreach (HtmlNode table in doc.DocumentNode.SelectNodes("/html/body/form/div[3]/div[2]/div/table"))
            {
                foreach (HtmlNode row in table.SelectNodes("/html/body/form/div[3]/div[2]/div/table/tbody//tr"))
                {
                    //if (row.InnerText == "&lt;&lt;&lt; Quay lại")
                    //{
                    //    break;
                    //}
                    if (count == 0)
                    {
                        List<string> check = row.SelectNodes("th").ToList().Select(x => x.InnerText).Take(8).ToList();
                        dataGridView1.Rows.Add(check[0],check[1], check[2], check[3], check[4], check[5], check[6], check[7]);
                    }
                    else
                    {
                        List<string> check = row.SelectNodes("td").ToList().Select(x => x.InnerText).Take(8).ToList();
                        dataGridView1.Rows.Add(check[0], check[1], check[2], check[3], check[4], check[5], check[6], check[7]);
                    }
                    count++;
                }
            }
        }


        List<string> ListStuActivity = new List<string>();
        

        ĐT_QL_SV5TOTEntities db = new ĐT_QL_SV5TOTEntities();
        

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
                int IDhoatDong = Convert.ToInt32(db.CHUONG_TRINH.Where(x => x.TenChuongTrinh.ToString() == item.ToString()).Select(x => x.MaHoatDong).FirstOrDefault());
                var tieuChi = db.HOAT_DONG.Where(x => x.MaHoatDong == IDhoatDong).Select(x => x.MaTieuChi).FirstOrDefault();
            }
            
        }
    }
}
