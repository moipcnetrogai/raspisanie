using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Raspisanie
{
    class Connection
    {
        static string connect = "Server=Vc-stud-mssql1,1433;Initial Catalog=user90_db;User id=user90_db;Password=user90;MultipleActiveResultSets=True; App = EntityFrameword; Connection Timeout=2;";
        public static SqlConnection MyConnection = new SqlConnection(@connect);
        public static int On(int x)
        {
            try { MyConnection.Open(); }
            catch (System.Data.SqlClient.SqlException) { return x = 1; }
            return x = 0;
        }
        public static void Off()
        {
            MyConnection.Close();
        }

    }
}
