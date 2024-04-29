using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sun_Broseth.Data
{
    internal class LoanContext
    {
        static OracleConnection db;
        public static void OpenConnection()
        {
            if (db == null)
            {
                db = new OracleConnection();
                db.ConnectionString = "Data Source=localhost:1521/XEPDB1;User Id = Loan; Password = 123; ";
                db.Open();
            }

        }
        public static void CloseConnection()
        {
            if (db != null)
            {
                db.Close();
            }
            db = null;
        }
        public static OracleConnection GetConnection()
        {
            if (db == null)
            {
                OpenConnection();
            }
            return db;
        }
    }
}
