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
using System.Windows.Media.Animation;
using System.Xml.XPath;
using System.Diagnostics;
using System.Reflection;
using HtmlAgilityPack;
using HubK.MarketCrawler.Contract.Dto;
using System.ComponentModel.Composition;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;

namespace Hubk.Browser.UI
{
    /// <summary>
    /// MallEmart.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MallEmart : Window
    {
        DataTable dt = new DataTable();
        Models.Allproduct Emart = new Models.Allproduct();
        Queue myQ = new Queue();
        DoubleAnimation cda = new DoubleAnimation();
        bool ActionStart = false;
        int ActionIdx = -1;
        int ict = 0;
        int totp = 0;
        int page = 0;
        int tpage = 0;
        string mainaddr = string.Empty;
        public MallEmart()
        {
            InitializeComponent();
            this.Loaded += MallEmart_Loaded;

        }

        private void MallEmart_Loaded(object sender, RoutedEventArgs e)
        {
            Martdata.Emartmall.Makeuri(ref Emart.Itemlist);
            Martdata.SveData.MakeTable(ref dt);
            dataview();
            ll.ItemsSource = Martdata.Emart.lstemart.getlst();
            Clst.ItemsSource = Emart.Itemlist;
        }

        void dataview()
        {
            if (ll.SelectedIndex > -1)
            {
                DataTable dt = Mdb.Crw.readData("emartmall", ll.Items[ll.SelectedIndex].ToString());
                Crw.ItemsSource = dt.DefaultView;
            }
        }
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            //for (int i = 0; i < Emart.Itemlist.Count; i++)
            //{
            //    Uri u = new Uri(Emart.Itemlist[i].ListaddressA+i.ToString()+ Emart.Itemlist[i].ListaddressB);
            //    string s = GetPageSource(Encoding.UTF8, u);
            //    HParser(s, Emart.Itemlist[i].Viewaddress);
            //}
            RRotatemaster(31);
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
            //string Viewaddress = "";
            //for (int i = 0; i < Emart.Itemlist.Count; i++)
            //{
            //    Uri u = new Uri(Emart.Itemlist[i].ListaddressA+i.ToString()+ Emart.Itemlist[i].ListaddressB);
            //    string s = GetPageSource(Encoding.UTF8, u);
            //    HParser(s, Emart.Itemlist[i].Viewaddress);
            //    Viewaddress = Emart.Itemlist[i].Viewaddress;
            //}
            RRotatemaster(31);
            
        }
        private void Clst_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (ActionStart == false)
            {
                if (Clst.SelectedIndex <= int.Parse(Endp.Text))
                {
                    ActionStart = true;
                    ActionIdx = Clst.SelectedIndex;
                    ll.SelectedIndex = ActionIdx;
                    if (ll.SelectedIndex > -1)
                    {
                        DataTable dt = Mdb.Crw.readData("emartmall", ll.Items[ll.SelectedIndex].ToString());
                        Crw.ItemsSource = dt.DefaultView;
                    }

                    RRotatemaster(31);
                }
            }
        }
        void RRotatemaster(int st)
        {
            cda = new DoubleAnimation();
            cda.From = 0;
            cda.To = 150;
            cda.Duration = new Duration(TimeSpan.FromSeconds(st));
            cda.Completed += cdamaster_Completed;
            acT.BeginAnimation(Button.HeightProperty, cda);
        }

        private void cdamaster_Completed(object sender, EventArgs e)
        {
            Random r = new Random();
            r.Next();
            int rr = r.Next(30, 50);
            string Viewaddress = "";
            try
            {
                if (ActionIdx < Clst.Items.Count && ActionIdx>-1)
                {
                    Models.ItemList row = (Models.ItemList)Clst.SelectedItem;
                    tpage = int.Parse(row.Allpage.ToString()); //Emart.Itemlist[ActionIdx].Allpage;
                    if (tpage > page)
                    {
                        //if (ict == 1)
                        //    ict = 1;
                        page += 1;
                        Uri u = new Uri(row.ListaddressA + page.ToString() + row.ListaddressB);
                        string s = GetPageSource(Encoding.UTF8, u);
                        HParser(s, row.Viewaddress);
                        Viewaddress = row.Viewaddress;
                        mainaddr = row.ListaddressA;

                        //page = Emart.Itemlist[ict].Allpage;
                        itemcount.Text = myQ.Count.ToString();
                        if (page < tpage)
                            RRotatemaster(rr);
                        //else if (page == tpage)
                        //{
                            //ict += 1;
                            //ActionStart = false;
                        //    page = 0;
                        //}
                    }
                    //else if (tpage == page)
                    //{
                        //ict += 1;
                        //ActionStart = false;
                    //    page = 0;
                    //}
                }


            }
            catch { RRotatemaster(rr); }

            if (ActionStart == true && page == tpage)
            {
                totp = myQ.Count;
                itemcount.Text = myQ.Count.ToString() + "/" + totp.ToString();
                SangsePage(Viewaddress);
            }
            else if (ActionStart == true && page < tpage)
            {
                //page = 0;
                RRotatemaster(rr);
            }
        }


        //private void cdamaster_Completed(object sender, EventArgs e)
        //{
        //    Random r = new Random();
        //    r.Next();
        //    int rr = r.Next(30, 50);
        //    string Viewaddress = "";
        //    try
        //    {
        //        if(ict< Emart.Itemlist.Count)
        //        {
        //            tpage = Emart.Itemlist[ict].Allpage;
        //            if (tpage > page)
        //            {
        //                if (ict == 1)
        //                    ict = 1;
        //                page += 1;
        //                Uri u = new Uri(Emart.Itemlist[ict].ListaddressA + page.ToString() + Emart.Itemlist[ict].ListaddressB);
        //                string s = GetPageSource(Encoding.UTF8, u);
        //                HParser(s, Emart.Itemlist[ict].Viewaddress);
        //                Viewaddress = Emart.Itemlist[ict].Viewaddress;
        //                mainaddr = Emart.Itemlist[ict].ListaddressA;

        //                //page = Emart.Itemlist[ict].Allpage;
        //                itemcount.Text = myQ.Count.ToString();
        //                if (page < tpage)
        //                    RRotatemaster(rr);
        //                else if(page==tpage)
        //                {
        //                    ict += 1;
        //                    page = 0;
        //                }
        //            }
        //            else if (tpage == page)
        //            {
        //                ict += 1;
        //                page = 0;
        //            }
        //        }


        //    }
        //    catch { RRotatemaster(rr); }

        //    if (ict == Emart.Itemlist.Count)
        //    {
        //        totp = myQ.Count;
        //        itemcount.Text = myQ.Count.ToString() + "/" + totp.ToString();
        //        SangsePage(Viewaddress);
        //    }
        //    else if(Emart.Itemlist.Count>ict)
        //    {
        //        //page = 0;
        //        RRotatemaster(rr);
        //    }
        //}
        void HParser(string d, string sangse)
        {
            //string ss = "";
            //string sa = "";
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(d);


            var inputs = from input in htmlDoc.DocumentNode.SelectNodes("//a[@href]").Where(x => x.HasClass("cmqv_btn_view"))
                         select input;
            foreach (var input in inputs)
            {
                if (!myQ.Contains(input.Attributes["data-replace-href"].Value))
                {
                    myQ.Enqueue(input.Attributes["data-replace-href"].Value);

                }
            }

            
            
        }
        void RRotate(int st)
        {
            cda = new DoubleAnimation();
            cda.From = 0;
            cda.To = 150;
            cda.Duration = new Duration(TimeSpan.FromSeconds(st));
            cda.Completed += cda_Completed;
            acT.BeginAnimation(Button.HeightProperty, cda);
        }
        private void cda_Completed(object sender, EventArgs e)
        {
            Random r = new Random();
            r.Next();                            
            int rr = r.Next(30, 50);

            try
            {
                if (myQ.Count>0)//ict < Emart.Itemlist.Count())
                {
                    //ict += 1;

                    cda.Completed -= cda_Completed;
                    cda = null;
                    if(mainaddr.Length==0)
                        mainaddr = Emart.Itemlist[0].ListaddressA;
                    string[] a = myQ.Dequeue().ToString().Split('?');
                    Uri url = new Uri(mainaddr + a[1]);
                    string htmlBody = GetPageSource(Encoding.UTF8, url);
                    SangParse(htmlBody, mainaddr + a[1]);

                    itemcount.Text = myQ.Count.ToString() + "/" + totp.ToString();
                    if (myQ.Count > 0)
                        RRotate(rr);
                    else if (myQ.Count == 0 && dt.Rows.Count > 0)
                        Martdata.SveData.SaveDataTable(dt, @"C:\marketpro\data");
                }
                else
                {
                    if (myQ.Count > 0)
                        RRotate(rr);
                    else if (myQ.Count == 0)// && dt.Rows.Count > 0)
                    {
                        //string u = Application.Current.StartupUri + @"\Crw";
                        //Martdata.SveData.SaveDataTable(dt, u);
                        //this.Close();
                        if (Clst.SelectedIndex == ActionIdx && ActionIdx < Clst.Items.Count)
                        {
                            ActionStart = false;
                            Clst.SelectedIndex = ActionIdx + 1;
                            Clst_MouseLeftButtonUp(null, null);
                        }
                    }
                }
            }
            catch { RRotate(rr); }
        }
        void SangsePage(string s)
        {
            mainaddr = s;
            Random r = new Random();
            r.Next();
            int rr = r.Next(30, 50);
            RRotate(rr);
            //while (myQ.Count > 0)
            //{
            //    string[] a = myQ.Dequeue().ToString().Split('?');
            //    Uri url = new Uri(s + a[1]);
            //    string htmlBody = GetPageSource(Encoding.UTF8, url);
            //    SangParse(htmlBody, s + a[1]);
            //}

        }
        void SangParse(string htmlbody, string url)
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
            Models.Product r = new Models.Product();
            r.Item_url = url;

            string av = "";
            htmlDoc.LoadHtml(htmlbody);
            try
            {
                foreach (HtmlNode row in htmlDoc.DocumentNode.SelectNodes("//th/div[contains(text(), '생산자')]"))
                {
                    foreach (HtmlNode col in row.SelectNodes("//td"))
                    {
                        av += col.InnerText + ",";
                    }
                }
                string[] ar = av.Split(',');
                r.Item_market = ar[49];

                //HtmlNode nn = htmlDoc.DocumentNode.SelectSingleNode("//th/div[contains(text(), '생산자')]");

                //av = nn.SelectSingleNode("//td[@class='in']").InnerText;
                av = "";
                var inputs = from input in htmlDoc.DocumentNode.SelectNodes("//option[@selected='selected']")
                             select input;
                foreach (var input in inputs)
                {
                    string a = input.InnerText.Substring(8, input.InnerText.Length - 8);
                    av += a + ",";
                }
                string[] cat = av.Split(',');
                r.Item_market = "emartmall";
                r.Cat_big = cat[0];
                r.Cat_middle = cat[1];
                r.Cat_small = cat[2];
                var itemNm = htmlDoc.DocumentNode.SelectSingleNode("//input[@type='hidden' and @id='itemNm']")
                    .Attributes["value"].Value;

                var itemId = htmlDoc.DocumentNode.SelectSingleNode("//input[@type='hidden' and @id='itemId']")
                    .Attributes["value"].Value;
                
                var itemPrice = htmlDoc.DocumentNode.SelectSingleNode("//span[@class='cdtl_price point']/em[@class='ssg_price']").InnerText;
                r.Item_nm = itemNm;
                r.Item_id = itemId;
                r.Item_price = int.Parse(itemPrice.Replace(",",""));
                r.Writeday = DateTime.Now;
               int i =  Mdb.Crw.readCount(r.Item_market, r.Cat_big, r.Cat_middle, r.Cat_small, r.Item_id, ll.Items[ll.SelectedIndex].ToString());
                if (i == 0)
                    Mdb.Crw.newSave(r, ll.Items[ll.SelectedIndex].ToString());
                else if (i == 1)
                    Mdb.Crw.Save(r, ll.Items[ll.SelectedIndex].ToString());
                dataview();

                itemcount.Text = myQ.Count.ToString() + "/" + totp.ToString();
                if(myQ.Count==0)
                {
                    if(Clst.SelectedIndex==ActionIdx && ActionIdx<Clst.Items.Count)
                    {
                        ActionStart = false;
                        Clst.SelectedIndex = ActionIdx + 1;
                        Clst_MouseLeftButtonUp(null, null);
                    }
                }
            }
            catch { RRotate(21); }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int i = Mdb.Crw.AllDelete("emartmall", ll.Items[ll.SelectedIndex].ToString());
            if (i > 0)
                MessageBox.Show(i.ToString() + " 개 데이타가 삭제되었습니다");
            dataview();
        }

        
        private void ll_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //MessageBox.Show(ll.Items[ll.SelectedIndex].ToString());

            Mdb.Hel h = new Mdb.Hel();
            h.url = ll.Items[ll.SelectedIndex].ToString();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string q = @"select * from dbo.Crwitem ";
            SqlCommand cmd = new SqlCommand(q);
            ds = h.ExecuteCommand(cmd);
            if (ds.Tables.Count == 1)
                dt = ds.Tables[0];

            Crw.ItemsSource = dt.DefaultView;
        }

        
    }
}
