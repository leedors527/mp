using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

using System.Xml.XPath;
using System.Diagnostics;
using System.Reflection;
using HtmlAgilityPack;
using HubK.MarketCrawler.Contract.Dto;
using System.ComponentModel.Composition;
using System.Collections.Specialized;

namespace Hubk.Browser
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        Models.Allproduct Emart = new Models.Allproduct();
        Queue myQ = new Queue();
        List<string> myL = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            makeInfo();
        }

        void makeInfo()
        {
            Emart.Marketname = "이마트몰";
            Martdata.Emartmall.Makeuri(ref Emart.Itemlist);
        }
        public string GetPageSource(Encoding targetEncoding, Uri targetUri)
        {
            using (var process = new Process())
            {
                string basePath = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);
                string targetEncodingName = "utf8";
                if (!targetEncoding.Equals(Encoding.UTF8))
                {
                    targetEncodingName = targetEncoding.BodyName;
                }
                var startInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    FileName = Path.Combine(basePath, "phantomjs.exe"),
                    Arguments = $@"""{Path.Combine(basePath, "index.js")}"" ""{targetUri.AbsoluteUri}"" ""{UserAgentStringPool.Default.GetNextUserAgentString()}"" ""{targetEncodingName}"""
                };

                process.StartInfo = startInfo;
                process.StartInfo.StandardOutputEncoding = targetEncoding;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                
                return output;
            }
        }

        public async Task<string> GetPageSourceAsync(Encoding targetEncoding, Uri targetUri)
        {
            return await Task.Run(() => this.GetPageSource(targetEncoding, targetUri)).ConfigureAwait(false);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //http://emart.ssg.com/disp/category.ssg?dispCtgId=0006110002&page=1&pageSize=100&mallGb=1&brandIds=&benefit=&shpp=&cls=&salestrNo=&pickuSalestr=&clipSizeYn=&sizeIds=&viewType=&minsellPrc=&maxsellPrc=&prc=&sort=&brandMoreYn=&benefitMoreYn=
            //http://emart.ssg.com/item/itemView.ssg?itemId=0000010534577&siteNo=6001&salestrNo=2034
            //<a href=\"javascript:void(0)\" class=\"cmqv_btn_view clickable \" role=\"button\" data-layer-target=\"#ly_cmqv\" data-replace-href=\"/item/popup/quickItemView.ssg?itemId=0000010534577&amp;siteNo=6001&amp;salestrNo=2034\" data-info=\"0000010534577\" data-index=\"1\" data-position=\"quick\" data-unit=\"img\">
            
            //Task<string> s = GetPageSourceAsync(Encoding.UTF8, u);
            //MessageBox.Show(s.Result);
            //string s = await GetPageSourceAsync(Encoding.UTF8, u).ConfigureAwait(false);
            
            for(int i=0; i<Emart.Itemlist.Count;i++)
            {
                Uri u = new Uri(Emart.Itemlist[i].ListaddressA+i.ToString()+ Emart.Itemlist[i].ListaddressB);
                string s = GetPageSource(Encoding.UTF8, u);
                HParser(s,Emart.Itemlist[i].Viewaddress);
            }
        }

        void HParser(string d,string sangse)
        {
            string ss = "";
            string sa = "";
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(d);
            

            var inputs = from input in htmlDoc.DocumentNode.SelectNodes("//a[@href]").Where(x=>x.HasClass("cmqv_btn_view"))
                         select input;
            foreach (var input in inputs)
            {
                if (!myQ.Contains(input.Attributes["data-replace-href"].Value))
                {
                    myQ.Enqueue(input.Attributes["data-replace-href"].Value);

                }
                if(!myL.Contains(input.Attributes["data-replace-href"].Value))
                {
                    myL.Add(input.Attributes["data-replace-href"].Value);
                }
            }
            SangsePage(sangse);
           
        }

        void SangsePage(string s)
        {
            //MessageBox.Show("http://emart.ssg.com/item/itemView.ssg?"+u[0]);
            //myQ.Dequeue();
            //http://emart.ssg.com/item/itemView.ssg?itemId=0000010534577&siteNo=6001&salestrNo=2034
            //string[] a = myQ.Dequeue().ToString().Split('?');

            //Uri url = new Uri(@"http://emart.ssg.com/item/itemView.ssg?" + a[1];
            //string htmlBody = GetPageSource(Encoding.UTF8, url);
            //SangParse(htmlBody);

            while (myQ.Count > 0)
            {
                string[] a = myQ.Dequeue().ToString().Split('?');
                Uri url = new Uri(s + a[1]);
                string htmlBody = GetPageSource(Encoding.UTF8, url);
                SangParse(htmlBody);
            }
        }
        void SangParse(string htmlbody)
        {
            //
            //select cat_b 대카테고리
            //select cat_m 중카테고리
            //select cat_cat_s
            // hidden =>itemNm
            // hidden=> itemId  
            //class=\"ssg_price\
            //cdtl_sec
            HtmlDocument htmlDoc = new HtmlDocument();
            //option[@selected='selected']
            //.DocumentNode.SelectNodes("//select[@id='cat_b']/option[@selected='selected']")).Attributes["value"].Value;

            string av = "";
            htmlDoc.LoadHtml(htmlbody);
            foreach (HtmlNode row in htmlDoc.DocumentNode.SelectNodes("//th/div[contains(text(), '생산자')]"))
            {
                foreach (HtmlNode col in row.SelectNodes("//td"))
                {
                    av += col.InnerText +",";
                }
            }
            string[] ar = av.Split(',');
            string sProducer = ar[49];
            //HtmlNode nn = htmlDoc.DocumentNode.SelectSingleNode("//th/div[contains(text(), '생산자')]");

            //av = nn.SelectSingleNode("//td[@class='in']").InnerText;
            av = "";
            var inputs = from input in htmlDoc.DocumentNode.SelectNodes("//option[@selected='selected']")
                         select input;
            foreach (var input in inputs)
            {
                //foreach (HtmlAgilityPack.HtmlNode node2 in input.Descendants("//option[@selected='selected']"))
                //{
                    string a= input.InnerText.Substring(8, input.InnerText.Length-8);
                    av += a + ",";
                //}
            }
            //htmlDoc.DocumentNode.SelectNodes("//select[@id='cat_b']//option")) \"location_section

            //av = htmlDoc.DocumentNode.SelectSingleNode("//select[@id='cat_b']/option[@selected='selected']").OuterHtml;


            //foreach (HtmlAgilityPack.HtmlNode node in htmlDoc.DocumentNode.Descendants("//select[@id='cat_b']"))
            //{
            //    foreach (HtmlAgilityPack.HtmlNode node2 in node.Descendants("//option[@selected='selected']"))
            //    {
            //        av = node2.Attributes["value"].Value;
            //    }
            //}
            //HtmlNode[] nodes = htmlDoc.DocumentNode.SelectNodes("//select").Where(x => x.InnerHtml.Contains("cat_b")).ToArray();
            //foreach (HtmlNode item in nodes)
            //{
            //    cat_b = item.InnerText;
            //}
            //var valuea = htmlDoc.DocumentNode.SelectSingleNode("//select[@id='cat_b' and @selected='selected']")
            //    .Attributes["value"].Value; ("//*[@id='my_name']").
            //string av = "";
            //string checkstring = "//select[@id='cat_b']";
            //HtmlNodeCollection Nodes = htmlDoc.DocumentNode.SelectNodes(checkstring);
            //foreach (HtmlAgilityPack.HtmlNode node in Nodes)
            //{
            //    av = node.Attributes["value"].Value;
            //}
            //var cat_b = htmlDoc.DocumentNode.SelectSingleNode("//select[@id='cat_b'/option@selected='selected']")
            //    .Attributes["value"].Value;
            //var cat_b = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='location_section']/a[@class='selectBox cat_select selectBox-dropdown']/span[@class='selectBox-label']").InnerText;
            
            var itemNm = htmlDoc.DocumentNode.SelectSingleNode("//input[@type='hidden' and @id='itemNm']")
                .Attributes["value"].Value;

            var itemId = htmlDoc.DocumentNode.SelectSingleNode("//input[@type='hidden' and @id='itemId']")
                .Attributes["value"].Value;

            var itemPrice = htmlDoc.DocumentNode.SelectSingleNode("//span[@class='cdtl_price point']/em[@class='ssg_price']").InnerText;

            //var product = htmlDoc.DocumentNode.SelectSingleNode("//th[contains(text(), '생산자')]//following-sibling::td").InnerText;

            //HtmlNode someNode = htmlDoc.DocumentNode.SelectNodes("//div[@id='div1']").First(); //("//select[@name='SearchFood']//option");
            string atxt = "";
            //cat_b = htmlDoc.DocumentNode.SelectSingleNode("//select[@id='cat_b']").InnerText;
            //string atxt = htmlDoc.DocumentNode.SelectSingleNode("//option[@selected='selected']").InnerText;
            ////HtmlAgilityPack.HtmlNodeCollection Colnode = htmlDoc.DocumentNode.SelectNodes("//select[@title='대카테고리']//option[@selected='selected']");
            ////foreach (HtmlAgilityPack.HtmlNode node in Colnode)
            ////{
            ////    atxt = node.SelectSingleNode("option[@selected = 'selected']").Attributes["value"].Value;
            //}
            //MessageBox.Show(atxt);
            //ProductItemDto model = new ProductItemDto()
            //{
            //    Categories = 
            //UniqueArticleNo = doc.CreateNavigator().SelectSingleNode("//dt[@class='stit15']/following-sibling::dd")?.ToString()?.HtmlDecode()?.Trim(),
            //    Maker = doc.CreateNavigator().SelectSingleNode("//th[contains(text(), '생산자')]//following-sibling::td")?.ToString()?.HtmlDecode()?.Trim(),
            //    Price = doc.CreateNavigator().SelectSingleNode("//dt[@class='stit2']/following-sibling::dd//strong[@class='price']")?.ToString()?.HtmlDecode()?.Trim().ExtractPrice(),
            //    Producer = doc.CreateNavigator().SelectSingleNode("//th[contains(text(), '생산자')]//following-sibling::td")?.ToString()?.HtmlDecode()?.Trim(),
            //    Title = doc.CreateNavigator().SelectSingleNode("//div[@class='right']/h1")?.ToString()?.HtmlDecode()?.Trim(),
            //    PriceCurrency = "KRW",
            //    MarketId = targetUri.Host,
            //    MarketName = targetUri.Host,
            //    MarketUri = new Uri(targetUri, "/"),
            //    ProductUri = targetUri,
            //};
            //var inputs = from input in htmlDoc.DocumentNode.SelectNodes("//a[@href]").Where(x => x.HasClass("cmqv_btn_view"))
            //             select input;
            //foreach (var input in inputs)
            //{


            //}
        }

        private void btnEmart_Click(object sender, RoutedEventArgs e)
        {
            UI.MallEmart win = new UI.MallEmart();

            win.Show();
        }
    }
}
