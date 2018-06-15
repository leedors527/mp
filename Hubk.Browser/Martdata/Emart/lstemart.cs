using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubk.Browser.Martdata.Emart
{
    public class lstemart
    {
        static List<string> lst = new List<string>();
        public static List<string> getlst()
        {
            //C:\dbdata\emart\쌀잡곡\0006110002 과일견과사과배
            string s = @"C:\dbdata\emart\쌀잡곡\0006110107 쌀 중량별\" + "Crw.mdf";
            //lst = new List<string>();
            lst.Add(s);

            s = @"C:\dbdata\emart\쌀잡곡\0006110108 쌀 품종별\" + "Crw.mdf";
            lst.Add(s);
            ////lst = new List<string>();


            s = @"C:\dbdata\emart\쌀잡곡\0006110109 쌀 지역별\" + "Crw.mdf";
            //lst = new List<string>();
            lst.Add(s);

            s = @"C:\dbdata\emart\쌀잡곡\0006110110 즉석도정미\" + "Crw.mdf";
            //lst = new List<string>();
            lst.Add(s);

            s = @"C:\dbdata\emart\쌀잡곡\0006110111 찹쌀현미흑미\" + "Crw.mdf";
            //lst = new List<string>();
            lst.Add(s);

            s = @"C:\dbdata\emart\쌀잡곡\0006110114 수입잡곡\" + "Crw.mdf";
            //lst = new List<string>();
            lst.Add(s);

            s = @"C:\dbdata\emart\쌀잡곡\0006645385 콩보리\" + "Crw.mdf";
            //lst = new List<string>();
            lst.Add(s);

            s = @"C:\dbdata\emart\쌀잡곡\0006645390 수수조깨잡곡\" + "Crw.mdf";
            //lst = new List<string>();
            lst.Add(s);

            s = @"C:\dbdata\emart\쌀잡곡\0006645397 혼합곡기능성잡곡\" + "Crw.mdf";
            //lst = new List<string>();
            lst.Add(s);

            s = @"C:\dbdata\emart\쌀잡곡\0006645406 선물세트\" + "Crw.mdf";
            //lst = new List<string>();
            lst.Add(s);

            s = @"C:\dbdata\emart\쌀잡곡\0006647481 볶은통영양곡\" + "Crw.mdf";
            //lst = new List<string>();
            lst.Add(s);

            s = @"C:\dbdata\emart\쌀잡곡\6000029758 곡물가공\" + "Crw.mdf";
            //lst = new List<string>();
            lst.Add(s);

            return lst;
        }
    }
}
