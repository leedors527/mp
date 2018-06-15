using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubk.Browser.Mdb
{
    class Makemdb
    {
        public static bool CreateDatabase(string fullFilename)
        {
            bool succeeded = false;

            try
            {
                string newDB = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullFilename;
                Type objClassType = Type.GetTypeFromProgID("ADOX.Catalog");

                if (objClassType != null)
                {
                    object obj = Activator.CreateInstance(objClassType);

                    // Create MDB file 
                    obj.GetType().InvokeMember("Create", System.Reflection.BindingFlags.InvokeMethod, null, obj,
                              new object[] { "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + newDB + ";" });
                    succeeded = true;

                    // Clean up
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }

            catch (Exception ex)
            {
                string sAns = "Could not create database file: " + fullFilename;
            }

            return succeeded;
        }

    }
}
