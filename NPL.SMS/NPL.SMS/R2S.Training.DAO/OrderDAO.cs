using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using NPL.SMS.R2S.Training.Entities;

namespace NPL.SMS.R2S.Training.DAO
{
    /// <summary>
    /// Class OrderDAO
    /// </summary>
    class OrderDAO :IOrderDAO
    {
        /// <summary>
        /// Query for Functional Requirement 02: Select Order ID By Customer ID
        /// </summary>
        private const string SELECT = @"SELECT * FROM dbo.Orders WHERE customer_id = @customerid";

        /// <summary>
        /// Query for Functional Requirement 04: Compute total by order ID
        /// </summary>
        private const string COMPUTE_TOTAL_BY_ORDER_ID = @"SELECT dbo.FN_total_price(@orderId)";

        /// <summary>
        /// Insert Order
        /// </summary>
        private const string ADD_ORDER = @"INSERT INTO Orders(order_date, customer_id, employee_id, total) VALUES (@orderDate, @customerId, @employeeId, @total)";

        /// <summary>
        /// Update Order Total
        /// </summary>
        private const string UPDATE_ORDER_TOTAL = "UPDATE Orders SET total = @total WHERE order_id = @orderId";

        /// <summary>
        /// GetAllOrdersByCustomerId
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>List of Orders</returns>
        public List<Order> GetAllOrdersByCustomerId(int customerId)
        {
            // In a using statement, acquire the SqlConnection as a resource
            using SqlConnection conn = Common.GetSqlConnection();

            // Open the SqlConnection
            conn.Open();

            // The following code uses a SqlCommand based on the SqlConnection
            using SqlCommand cmd = Common.GetSqlCommand(SELECT, conn);

            // Create parameter
            SqlParameter param = new SqlParameter
            {
                ParameterName = "@customerid",
                Value = customerId
            };

            //add parameter into SqlCommand
            cmd.Parameters.Add(param);


            using SqlDataReader dataReader = cmd.ExecuteReader();

            List<Order> list = new List<Order>();
            while (dataReader.Read())
            {
                // Create new a order
                Order order = new Order
                {
                    OrderId     = dataReader.GetInt32(0),
                    OrderDate   = dataReader.GetDateTime(1),
                    CustomerId  = dataReader.GetInt32(2),
                    EmployeeId  = dataReader.GetInt32(3),
                    Total       = dataReader.GetDouble(4)

                };

                // Add into list
                list.Add(order);
            }

            // Done
            return list;

        }

        /// <summary>
        /// Compute Order Total
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns>No.Row changes</returns>
        public double ComputeOrderTotal(int orderId)
        {
            // In a using statement, acquire the SqlConnection as a resource
            using SqlConnection conn = Common.GetSqlConnection();

            // Open the SqlConnection
            conn.Open();

            // The following code uses a SqlCommand based on the SqlConnection
            using SqlCommand cmd = Common.GetSqlCommand(COMPUTE_TOTAL_BY_ORDER_ID, conn);

            // Create parameter
            SqlParameter param = new SqlParameter
            {
                ParameterName = "@orderId",
                Value = orderId
            };

            //add parameter into SqlCommand
            cmd.Parameters.Add(param);
            double total = Convert.ToDouble(cmd.ExecuteScalar());

            // Done
            return total;
        }

        /// <summary>
        /// Insert Order
        /// </summary>
        /// <param name="order"></param>
        /// <returns>No. Rows Changes</returns>
        public bool AddOrder(Order order)
        {
            // In a using statement, acquire the SqlConnection as a resource
            using SqlConnection conn = Common.GetSqlConnection();

            // Open the SqlConnection
            conn.Open();

            // The following code uses a SqlCommand based on the SqlConnection
            using SqlCommand cmd = Common.GetSqlCommand(ADD_ORDER, conn);

            //add parameter into SqlCommand
            cmd.Parameters.Add(new SqlParameter("@orderDate", order.OrderDate));
            cmd.Parameters.Add(new SqlParameter("@customerId", order.CustomerId));
            cmd.Parameters.Add(new SqlParameter("@employeeId", order.EmployeeId));
            cmd.Parameters.Add(new SqlParameter("@total", order.Total));

            // Check ExecuteNonQuery
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            return false;
        }

        /// <summary>
        /// Update Order Total
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns>No. Rows Changes</returns>
        public bool UpdateOrderTotal(int orderId)
        {
            LineItem lineItem = new LineItem();
            LineITemDAO lineITemDAO = new LineITemDAO();
            // In a using statement, acquire the SqlConnection as a resource
            using SqlConnection conn = Common.GetSqlConnection();

            // Open the SqlConnection
            conn.Open();

            // The following code uses a SqlCommand based on the SqlConnection
            using SqlCommand cmd = Common.GetSqlCommand(UPDATE_ORDER_TOTAL, conn);

            //add parameter into SqlCommand
            cmd.Parameters.Add(new SqlParameter("@orderId", orderId));

            // Create Parameter
            SqlParameter param = new SqlParameter
            {
                ParameterName = "@total",
                Value = ComputeOrderTotal(orderId)
            };

            //Add Parameter
            cmd.Parameters.Add(param);

            // Check ExecuteNoQuert
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            return false;
        }
    }
}
