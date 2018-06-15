using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Security.Permissions;

namespace Hubk.Browser.Martdata
{
    public class SveData
    {
        public static void MakeTable(ref DataTable dt)
        {
            dt.TableName = "Crl";
            dt.Columns.Add("Cat_big");
            dt.Columns.Add("Cat_middle");
            dt.Columns.Add("Cat_small");
            dt.Columns.Add("Item_id");
            dt.Columns.Add("Item_nm");
            dt.Columns.Add("Item_price");
            dt.Columns.Add("Item_market");
            dt.Columns.Add("Item_url");
            
        }

        public static void SaveDataTable(DataTable dt,string uri)
        {
            FileInfo file = new FileInfo(uri);
            file.IsReadOnly = false;
            //File.Delete(strFilePath);
            FileIOPermission f2 = new FileIOPermission(FileIOPermissionAccess.Write, uri);


            if (File.Exists(uri))
                File.Delete(uri);
            try
            {
                dt.WriteXml(uri, XmlWriteMode.WriteSchema, false);
            }
            catch(Exception ex)
            {
                string s=ex.Message;
            }
        }

        public static void ReadData(string uri,ref DataTable dt)
        {
            if (File.Exists(uri))
                dt.ReadXml(uri);
        }
    }
}
