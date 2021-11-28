using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using NPL.SMS.R2S.Training.Entities;

namespace NPL.SMS.R2S.Training.DAO
{
    /// <summary>
    /// Class LineItemDao
    /// </summary>
    class LineITemDAO: ILineItemDAO
    {
        /// <summary>
        /// Query of Functional Requirement 03: Get All Items by Order ID
        /// </summary>
        private const string SELECT_ITEMS_BY_ORDER_ID = @"SELECT * FROM dbo.LineItem WHERE order_id = @orderId";

        /// <summary>
        /// Query of Functional Requirement 09: Insert LineItem
        /// </summary>
        private const string INSERT_LINEITEM = @"INSERT INTO LineItem (order_id, product_id, quantity, price) VALUES (@orderId, @productId, @quantity, @price)";

        /// <summary>
        /// Get All Items by Order ID
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns>List of LineItem</returns>
        public List<LineItem> GetAllItemsByOrderId(int orderId)
        {
            // In a using statement, acquire the SqlConnection as a resource
            using SqlConnection conn = Common.GetSqlConnection();

            // Open the SqlConnection
            conn.Open();

            // The following code uses a SqlCommand based on the SqlConnection
            using SqlCommand cmd = Common.GetSqlCommand(SELECT_ITEMS_BY_ORDER_ID, conn);

            // Create parameter
            SqlParameter param = new SqlParameter
            {
                ParameterName = "@orderId",
                Value = orderId
            };

            //add parameter into SqlCommand
            cmd.Parameters.Add(param);


            using SqlDataReader dataReader = cmd.ExecuteReader();

            List<LineItem> list = new List<LineItem>();
            while (dataReader.Read())
            {
                // Create new a order
                LineItem lineItem = new LineItem
                {
                    OrderId = dataReader.GetInt32(0),
                    ProductId = dataReader.GetInt32(1),
                    Quantity = dataReader.GetInt32(2),
                    Price = dataReader.GetDouble(3)
                };

                // Add into list
                list.Add(lineItem);
            }

            // Done
            return list;
        }

        /// <summary>
        /// Insert LineItem
        /// </summary>
        /// <param name="lineItem"></param>
        /// <returns>No. Rows Changes</returns>
        public bool AddLineItem(LineItem lineItem)
        {
            // In a using statement, acquire the SqlConnection as a resource
            using SqlConnection conn = Common.GetSqlConnection();

            // Open the SqlConnection
            conn.Open();

            // The following code uses a SqlCommand based on the SqlConnection
            using SqlCommand cmd = Common.GetSqlCommand(INSERT_LINEITEM, conn);

            //add parameter into SqlCommand
            cmd.Parameters.Add(new SqlParameter("@orderId", lineItem.OrderId));
            cmd.Parameters.Add(new SqlParameter("@productId", lineItem.ProductId));
            cmd.Parameters.Add(new SqlParameter("@quantity", lineItem.Quantity));
            cmd.Parameters.Add(new SqlParameter("@price", lineItem.Price));

            // Check ExecuteNonQuery and Done
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            return false;
        }
    }
}
