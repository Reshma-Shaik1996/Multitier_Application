using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;//SQL Server
using System.Configuration;//Configuration

namespace Midterm_ClientDB_Reshma.DataAccess
{
   public static class UtilityDB
    {
        public static SqlConnection ConnectDB()
        {
            SqlConnection connDB = new SqlConnection();
            connDB.ConnectionString = ConfigurationManager.ConnectionStrings["ClientDBConnection"].ConnectionString;
            connDB.Open();
            return connDB;
        }


    }
}
