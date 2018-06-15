using System;
using System.Data.SqlClient;

namespace Hubk.Browser.Mdb
{
    public class dbconnect
    {
        static SqlConnection scn = new SqlConnection();
        public static SqlConnection Opendatabase(string u)
        {
            //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\marketpro\project\hubk-crawler\Hubk.Browser\LocalDB\Crw.mdf;Integrated Security=True;Connect Timeout=30
            scn = new SqlConnection();
            try
            {
                //C:\dbdata
                //scn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + System.AppDomain.CurrentDomain.BaseDirectory + @"LocalDB\Crw.mdf;Integrated Security=True;Connect Timeout=30";
                //scn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + @"C:\dbdata\Crw.mdf;Integrated Security=True;Connect Timeout=30";
                scn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + u + ";Integrated Security=True;Connect Timeout=30";
                scn.Open();
            }
            catch (Exception Ex)
            {
                string s = Ex.Message;
            }
            return scn;
        }
        public static SqlConnection Opendatabase()
        {
            //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\marketpro\project\hubk-crawler\Hubk.Browser\LocalDB\Crw.mdf;Integrated Security=True;Connect Timeout=30
            scn = new SqlConnection();
            try
            {
                //C:\dbdata
                //scn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + System.AppDomain.CurrentDomain.BaseDirectory + @"LocalDB\Crw.mdf;Integrated Security=True;Connect Timeout=30";
                scn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + @"E:\dbdata\Crw.mdf;Integrated Security=True;Connect Timeout=30";
                scn.Open();
            }
            catch(Exception Ex)
            {
                string s = Ex.Message;
            }
            return scn;
        }
        public static void CloseConnection()
        {
            scn.Close();
            scn.Dispose();
        }
    }
}
