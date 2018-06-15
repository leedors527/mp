using System;
using System.Data;
using System.Data.SqlClient;

namespace Hubk.Browser.Mdb
{
    public class Helper : dbconnect
    {
        public string url = string.Empty;

        public int ExcuteTransaction(SqlCommand cmd)
        {
            SqlConnection connection = new SqlConnection();
            connection = Opendatabase();
            int i = 0;
            //cmd = connection.CreateCommand();
            SqlTransaction transaction;

            // Start a local transaction.
            transaction = connection.BeginTransaction("SampleTransaction");

            // Must assign both transaction object and connection
            // to Command object for a pending local transaction
            cmd.Connection = connection;
            cmd.Transaction = transaction;
            cmd.CommandType = CommandType.Text;
            try
            {
                
                i = cmd.ExecuteNonQuery();

                // Attempt to commit the transaction.
                if(i>0)
                    transaction.Commit();
                //Console.WriteLine("Both records are written to database.");
            }
            catch (Exception ex)
            {
                try
                {
                    string s=ex.Message;
                    transaction.Rollback();
                    i = 0;
                }
                catch (Exception ex2)
                {
                    string ss = ex2.Message;
                }
            }
            cmd.Connection.Close();
            cmd.Connection.Dispose();
            CloseConnection();
            return i;
        }
        public int ExcuteNonQuery(SqlCommand cmd)
        {
            //connection con = new connection();
            //DataSet ds = new DataSet();
            //SqlDataAdapter ad = new SqlDataAdapter();
            cmd.Connection = Opendatabase();
            cmd.CommandType = CommandType.Text;
            int i = 0;
            try
            {
                //cmd.BeginExecuteNonQuery();
                i = cmd.ExecuteNonQuery();
                //i= cmd.EndExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }

            cmd.Connection.Close();
            cmd.Connection.Dispose();
            CloseConnection();
            return i;
        }
        public int ExcuteNonProcedure(SqlCommand cmd)
        {

            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();

            cmd.Connection = Opendatabase();
            cmd.CommandType = CommandType.StoredProcedure;
            int i = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            cmd.Connection.Dispose();
            CloseConnection();
            return i;
        }
        public DataSet ExecuteCommand(SqlCommand cmd)
        {
            //connection con = new connection();
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            cmd.Connection = Opendatabase();
            cmd.CommandType = CommandType.Text;

            ad.SelectCommand = cmd;
            try
            {
                ad.Fill(ds);
            }
            catch (Exception ew)
            {
                string s = ew.Message;
                cmd.Dispose();

                ad.Dispose();
                CloseConnection();
            }
            finally
            {
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();

                    cmd.Connection.Dispose();

                }
                if (cmd != null)
                {
                    cmd.Connection.Close();

                    cmd.Connection.Dispose();

                }
                if (ad != null)
                {
                    ad.Dispose();
                }
                CloseConnection();
            }
            return ds;
        }
        public DataSet ExecuteProcedure(SqlCommand cmd)
        {
            //connection con = new connection();
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            cmd.Connection = Opendatabase();
            cmd.CommandType = CommandType.StoredProcedure;

            ad.SelectCommand = cmd;
            try
            {
                ad.Fill(ds);
            }
            catch (Exception ew)
            {
                string s = ew.Message;
                cmd.Dispose();
                ad.Dispose();
                CloseConnection();
            }
            finally
            {
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();

                    cmd.Connection.Dispose();

                }
                if (cmd != null)
                {
                    cmd.Connection.Close();

                    cmd.Connection.Dispose();
                }
                if (ad != null)
                {
                    ad.Dispose();
                }
                CloseConnection();
            }
            return ds;
        }
    }
}
