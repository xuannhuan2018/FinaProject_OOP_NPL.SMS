using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace NPL.SMS.R2S.Training.DAO
{
    class Common
    {
        /// <summary>
        /// Connection string
        /// </summary>
        private const string CONN_STRING = @"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=SMS;Integrated Security=True";

        /// <summary>
        ///  SqlConnection
        /// </summary>
        public static SqlConnection GetSqlConnection()
        {
            SqlConnection conn = new SqlConnection(CONN_STRING);
            return conn;
        }

        /// <summary>
        /// GetSqlCommand
        /// </summary>
        /// <param name="query"></param>
        /// <param name="conn"></param>
        /// <returns>cmd</returns>
        public static SqlCommand GetSqlCommand(string query, SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            return cmd;
        }
    }

}
