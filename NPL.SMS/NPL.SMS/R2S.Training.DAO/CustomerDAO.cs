using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using NPL.SMS.R2S.Training.Entities;

namespace NPL.SMS.R2S.Training.DAO
{
    /// <summary>
    /// Class CustomerDAO
    /// </summary>
    class CustomerDAO : ICustomerDAO
    {
        /// <summary>
        /// Query for Funtional Requirement 01: Get customer by order ID
        /// </summary>
        private const string SELECT_CUSTOMER_BY_ORDERID = "SELECT DISTINCT Customer.customer_id, Customer.customer_name from Customer INNER JOIN Orders on Customer.customer_id = Orders.customer_id";

        /// <summary>
        /// Query for Funtional Requirement 05: Insert Customer
        /// </summary>
        private const string INSERT_A_CUSTOMER = "SP_Insert_Customer";

        /// <summary>
        /// Query for Funtional Requirement 06: Delete customer by customer id
        /// </summary>
        private const string DELETE_CUSTOMER = "SP_Delete_Customer";

        /// <summary>
        /// Query for Funtional Requirement 07: Update customer
        /// </summary>
        private const string UPDATE_CUSTOMER = "SP_Update_Customer";

        /// <summary>
        /// GetAllCustomer
        /// </summary>
        /// <returns>list</returns>
        public List<Customer> GetAllCustomer()
        {
            // In a using statement, acquire the SqlConnection as a resource
            using SqlConnection conn = Common.GetSqlConnection();

            // Open the SqlConnection
            conn.Open();

            // The following code uses a SqlCommand based on the SqlConnection
            using SqlCommand cmd = Common.GetSqlCommand(SELECT_CUSTOMER_BY_ORDERID, conn);
            using SqlDataReader dataReader = cmd.ExecuteReader();

            List<Customer> list = new List<Customer>();
            while (dataReader.Read())
            {
                // Create new a customer
                Customer customer = new Customer
                {
                    CustomerId = dataReader.GetInt32(0),
                    CustomerName = dataReader.GetString(1)
                };

                // Add into list
                list.Add(customer);
            }

            // Done
            return list;
        }

        /// <summary>
        /// Add customer
        /// </summary>
        /// <param name="customer">New customer</param>
        /// <returns>No. Rows Changes </returns>
        public bool AddCustomer(Customer customer)
        {
            // In a using statement, acquire the SqlConnection as a resource
            using SqlConnection conn = Common.GetSqlConnection();

            // Open the SqlConnection
            conn.Open();

            // The following code uses a SqlCommand based on the SqlConnection
            using SqlCommand cmd = Common.GetSqlCommand(INSERT_A_CUSTOMER, conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // Create parameter
            SqlParameter param = new SqlParameter
            {
                ParameterName = "@customerName",
                Value = customer.CustomerName
            };

            //add parameter into SqlCommand
            cmd.Parameters.Add(param);

            if (cmd.ExecuteNonQuery() > 0)
                return true;
            return false;
        }

        /// <summary>
        /// Delete customer
        /// </summary>
        /// <param name="customerId">customerId will be deleted</param>
        /// <returns>No. Rows Changes</returns>
        public bool DeleteCustomer(int customerId)
        {
            // In a using statement, acquire the SqlConnection as a resource
            using SqlConnection conn = Common.GetSqlConnection();

            // Open the SqlConnection
            conn.Open();

            // The following code uses a SqlCommand based on the SqlConnection
            using SqlCommand cmd = Common.GetSqlCommand(DELETE_CUSTOMER, conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // Create parameter
            SqlParameter param = new SqlParameter
            {
                ParameterName = "@customerId",
                Value = customerId
            };

            //add parameter into SqlCommand
            cmd.Parameters.Add(param);

            // Check ExecuteNonQuery and Done
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            return false;
        }

        /// <summary>
        /// Update Customer
        /// </summary>
        /// <param name="customer">New customer</param>
        /// <returns>No. Rows changes</returns>
        public bool UpdateCustomer(Customer customer)
        {
            // In a using statement, acquire the SqlConnection as a resource
            using SqlConnection conn = Common.GetSqlConnection();

            // Open the SqlConnection
            conn.Open();

            // The following code uses a SqlCommand based on the SqlConnection
            using SqlCommand cmd = Common.GetSqlCommand(UPDATE_CUSTOMER, conn);
            
            //use store produce
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //add parameter into SqlCommand
            SqlParameter param = new SqlParameter
            {
                ParameterName = "@customerId",
                Value = customer.CustomerId
            };

            //add parameter into SqlCommand
            cmd.Parameters.Add(param);

            param = new SqlParameter
            {
                ParameterName = "@customerName",
                Value = customer.CustomerName
            };

            //add parameter into SqlCommand
            cmd.Parameters.Add(param);

            // Check ExecuteNonQuery and Done
            if ((int) cmd.ExecuteNonQuery() > 0)
                return true;
            return false;
        }
    }
}
