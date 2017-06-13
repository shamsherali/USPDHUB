using System;
using System.Linq;
using System.Data.SqlClient;
using System.Data;

namespace USPDHUBDAL
{
    public class ConnectionManager
    {
        private static ConnectionManager instance = null;

        /// <summary>
        /// Singleton design pattern that creates only one
        /// instance of the class at any given time.
        /// </summary>
        public static ConnectionManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new ConnectionManager();
                return instance;
            }
        }

        /// <summary>
        /// Opens a connection to sqlserver database.
        /// </summary>
        /// <returns>SqlConnection object</returns>
        public SqlConnection GetSQLConnection()
        {
            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = USPDHUBDAL.DataAccess.SqlCon1;
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            return sqlCon;
        }

        /// <summary>
        /// Releases the sqlconnection object to the connection pool.
        /// </summary>
        /// <param name="sqlCon"></param>
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
