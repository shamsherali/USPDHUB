using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace MyWorkingSamples.Reports
{
    public class ConnectionManager
    {
        private static ConnectionManager instance = null;
        public static ConnectionManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new ConnectionManager();
                return instance;
            }
        }
        public SqlConnection GetSQLConnection()
        {
            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = MyWorkingSamples.Reports.DataAccess.SqlCon1;
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            return sqlCon;
        }
        public void ReleaseSQLConnection(SqlConnection sqlCon)
        {
            if (sqlCon != null)
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            else
            {
                throw new System.Exception("Invalid Sql connection.");
            }
        }
    }
}