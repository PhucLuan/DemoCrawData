using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCrawData
{
    public class ActivityHistoryService
    {
        public List<Activityhistory> GetActivityhistories(string htmlCode)
        {
            if (String.IsNullOrEmpty(htmlCode))
            {
                return null;
            }

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();

            doc.LoadHtml(htmlCode);

            int count = 0;

            List<Activityhistory> activityhistories = new List<Activityhistory>();

            //Crawdata from youth
            foreach (HtmlNode table in doc.DocumentNode.SelectNodes("/html/body/form/div[3]/div[2]/div/table"))
            {
                foreach (HtmlNode row in table.SelectNodes("/html/body/form/div[3]/div[2]/div/table//tr"))
                {

                    if (count == 0)
                    {
                        List<string> check = row.SelectNodes("th").ToList().Select(x => x.InnerText).Take(8).ToList();
                    }
                    else
                    {
                        List<string> check = row.SelectNodes("td").ToList().Select(x => x.InnerText).Take(8).ToList();
                        string GiaiThuong = check[7];
                        activityhistories
                            .Add(new Activityhistory(check[0].ToString(),
                                                      check[1],
                                                      DateTime.ParseExact(check[2].ToString(), "d/M/yyyy", CultureInfo.InvariantCulture),
                                                      check[3],
                                                      int.Parse(check[4]),
                                                      GiaiThuong == "&nbsp;" ? null : check[7]));
                    }
                    count++;
                }
            }

            return activityhistories;
        }
    }
}
