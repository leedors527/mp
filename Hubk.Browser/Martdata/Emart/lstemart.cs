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
            lst.Add(s);

            s = @"C:\dbdata\emart\정육\0006110139 소고기(국내산)\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\정육\0006110140 돼지고기\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\정육\0006110141 수입육\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\정육\0006110142 닭오리고기\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\정육\0006110143 계란알류가공란\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\정육\0006110144 양념육가공육\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\정육\0006110145 축산선물세트\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\정육\6000020338 말고기\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\수산물해산물건어물\0006110840 고등어갈치조기장어\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\수산물해산물건어물\0006110841 삼치대구명태간편반찬\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\수산물해산물건어물\0006110842 오징어낙지\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\수산물해산물건어물\0006110843 새우게기타해산물\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\수산물해산물건어물\0006110844 전복굴조개류\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\수산물해산물건어물\0006110845 멸치천연조미료\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\수산물해산물건어물\0006110846 김\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\수산물해산물건어물\0006110847 미역다시마황태\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\수산물해산물건어물\0006110848 오징어쥐포육포어포스낵\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\수산물해산물건어물\0006110849 수산선물세트\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\수산물해산물건어물\6000011849 생선회\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\수산물해산물건어물\6000041477 점포픽업\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\음료주류커피분유\6000023670 삼다수봉평샘물국산생수\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\음료주류커피분유\6000023671 에비앙볼빅수입생수\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\음료주류커피분유\6000023672 탄산수탄산음료심층수수입음료\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\음료주류커피분유\6000023673 분유과일아채음료\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\음료주류커피분유\6000023674 콜라사이다환타스포츠음료\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\음료주류커피분유\6000023675 스타벅스커피티건강음료\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\음료주류커피분유\6000023676 성인유아두유\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\음료주류커피분유\6000023677 커피믹스원두캡슐커피세트\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\음료주류커피분유\6000023678 녹차홍차아이스티코코아\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\음료주류커피분유\6000023679 분유유아식\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\음료주류커피분유\6000030978 수입분유유아식\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\음료주류커피분유\6000039394 전통주\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\과자초콜릿시리얼빵\6000023680 스낵\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\과자초콜릿시리얼빵\6000023681 쿠키비스킷크래커\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\과자초콜릿시리얼빵\6000023682 파이케익\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\과자초콜릿시리얼빵\6000023683 한과화과자전통과자\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\과자초콜릿시리얼빵\6000023684 소시지원물간식\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\과자초콜릿시리얼빵\6000023685 초콜릿초코바\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\과자초콜릿시리얼빵\6000023686 사탕젤리양갱껌\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\과자초콜릿시리얼빵\6000023687 시리얼\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\과자초콜릿시리얼빵\6000023688 식빵호빵찐빵빵\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\과자초콜릿시리얼빵\6000023689 베이커리생지쨈\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\과자초콜릿시리얼빵\6000041479 점포픽업\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\라면통조림조미료장류\6000023690 라면컵라면면식품\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\라면통조림조미료장류\6000023691 밥류카레짜장즉석식품\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\라면통조림조미료장류\6000023692 참치스팸잼통조림류\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\라면통조림조미료장류\6000023693 간장고추장된장쌈장\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\라면통조림조미료장류\6000023694 식용유참기름\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\라면통조림조미료장류\6000023695 파스타소스드레싱\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\라면통조림조미료장류\6000023696 밀가루설탕소금조미료\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\라면통조림조미료장류\6000023697 수입통조림조미료대용식\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\라면통조림조미료장류\6000023698 통조림조미료 선물세트\" + "Crw.mdf";
            lst.Add(s);

            s = @"C:\dbdata\emart\라면통조림조미료장류\6000033071 빙수재료\" + "Crw.mdf";
            lst.Add(s);

            return lst;
        }
    }
}
