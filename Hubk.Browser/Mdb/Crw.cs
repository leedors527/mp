using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Hubk.Browser.Mdb
{
    public class Crw
    {
        public static int newSave(Models.Product d,string u)
        {
            string q = @"INSERT INTO dbo.Crwitem(Item_market,Cat_big,Cat_middle,Cat_small,Item_id,Item_nm,Item_price,Item_url,Writeday) VALUES
           (@Item_market, @Cat_big, @Cat_middle,@Cat_small, @Item_id, @Item_nm, @Item_price, @Item_url,@Writeday)";

            Hel h = new Hel();
            h.url = u;
            SqlCommand cmd;
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = q;

            cmd.Parameters.Add("@Item_market", SqlDbType.NVarChar, 30).Value = d.Item_market;
            cmd.Parameters.Add("@Cat_big", SqlDbType.NVarChar,100).Value = d.Cat_big;
            cmd.Parameters.Add("@Cat_middle", SqlDbType.NVarChar,100).Value = d.Cat_middle;
            cmd.Parameters.Add("@Cat_small", SqlDbType.NVarChar,100).Value = d.Cat_small;
            cmd.Parameters.Add("@Item_id", SqlDbType.NVarChar,100).Value = d.Item_id;

            cmd.Parameters.Add("@Item_nm", SqlDbType.NVarChar, 100).Value = d.Item_nm;
            cmd.Parameters.Add("@Item_price", SqlDbType.Int).Value = d.Item_price;
            cmd.Parameters.Add("@Item_url", SqlDbType.NVarChar, 500).Value = d.Item_url;
            cmd.Parameters.Add("@Writeday", SqlDbType.DateTime).Value = d.Writeday;
            int ix = h.ExcuteTransaction(cmd);
            return ix;
        }

        public static int Save(Models.Product d,string u)
        {
            string q = @"UPdate dbo.Crwitem set 
                Item_nm=@Item_nm 
                ,Item_price=@Item_price
                ,Item_url=@Item_url
                ,Writeday=@Writeday
            where Item_market=@Item_market and Cat_big=@Cat_big and Cat_middle=@Cat_middle and Cat_small=@Cat_small and Item_id=@Item_id";

            Hel h = new Hel();
            h.url = u;
            SqlCommand cmd;
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = q;

            cmd.Parameters.Add("@Item_market", SqlDbType.NVarChar, 30).Value = d.Item_market;
            cmd.Parameters.Add("@Cat_big", SqlDbType.NVarChar, 100).Value = d.Cat_big;
            cmd.Parameters.Add("@Cat_middle", SqlDbType.NVarChar, 100).Value = d.Cat_middle;
            cmd.Parameters.Add("@Cat_small", SqlDbType.NVarChar, 100).Value = d.Cat_small;
            cmd.Parameters.Add("@Item_id", SqlDbType.NVarChar, 100).Value = d.Item_id;

            cmd.Parameters.Add("@Item_nm", SqlDbType.NVarChar, 100).Value = d.Item_nm;
            cmd.Parameters.Add("@Item_price", SqlDbType.Int).Value = d.Item_price;
            cmd.Parameters.Add("@Item_url", SqlDbType.NVarChar, 500).Value = d.Item_url;
            cmd.Parameters.Add("@Writeday", SqlDbType.DateTime).Value = d.Writeday;
            int ix = h.ExcuteTransaction(cmd);
            return ix;
        }

        public static int AllDelete(string Item_market,string u)
        {
            string q = @"DELETE FROM dbo.Crwitem 
            where Item_market='" + Item_market + "'";

            Hel h = new Hel();
            h.url = u;
            SqlCommand cmd;
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = q;

            //cmd.Parameters.Add("@Item_market", SqlDbType.NVarChar, 30).Value = d.Item_market;
            //cmd.Parameters.Add("@Cat_big", SqlDbType.NVarChar, 100).Value = d.Cat_big;
            //cmd.Parameters.Add("@Cat_middle", SqlDbType.NVarChar, 100).Value = d.Cat_middle;
            //cmd.Parameters.Add("@Cat_small", SqlDbType.NVarChar, 100).Value = d.Cat_small;
            //cmd.Parameters.Add("@Item_id", SqlDbType.NVarChar, 100).Value = d.Item_id;

            //cmd.Parameters.Add("@Item_nm", SqlDbType.NVarChar, 100).Value = d.Item_nm;
            //cmd.Parameters.Add("@Item_price", SqlDbType.Int).Value = d.Item_price;
            //cmd.Parameters.Add("@Item_url", SqlDbType.NVarChar, 500).Value = d.Item_url;
            //cmd.Parameters.Add("@Writeday", SqlDbType.DateTime).Value = d.Writeday;
            int ix = h.ExcuteTransaction(cmd);
            return ix;
        }

        public static int readCount(string Item_market,string Cat_big,string Cat_middle,string Cat_small,string Item_id,string u)
        {
            string q = @"select count(*) from dbo.Crwitem ";
            q += " where Item_market = '" + Item_market + "'";
            q += " and Cat_big = '" + Cat_big + "'";
            q += " and Cat_middle = '" + Cat_middle + "'";
            q += " and Cat_small = '" + Cat_small + "'";
            q += " and Item_id = '" + Item_id + "'";

            Hel h = new Hel();
            h.url = u;
            SqlCommand cmd = new SqlCommand(q);
            DataSet ds = h.ExecuteCommand(cmd);
            return int.Parse(ds.Tables[0].Rows[0][0].ToString());
        }

        public static DataTable readData(string Item_market,string u)
        { 
            DataTable dt = new DataTable();
            string q = @"select * from dbo.Crwitem ";
            q += " where Item_market = '" + Item_market + "'";
            //q += " and Cat_big = '" + Cat_big + "'";
            //q += " and Cat_middle = '" + Cat_middle + "'";
            //q += " and Cat_small = '" + Cat_small + "'";
            //q += " and Item_id = '" + Item_id + "'";

            Hel h = new Hel();
            h.url = u;
            SqlCommand cmd = new SqlCommand(q);
            DataSet ds = h.ExecuteCommand(cmd);
            dt = ds.Tables[0];
            return dt;
        }
    }
}
