using System;
using System.Collections.Generic;

using System.Text;
using NPL.SMS.R2S.Training.Entities;

namespace NPL.SMS.R2S.Training.DAO
{
    /// <summary>
    /// Interface IOrderDAO
    /// </summary>
    interface IOrderDAO
    {
        /// <summary>
        /// Get All Order By Customer ID
        /// </summary>
        /// <param name="customerid"></param>
        /// <returns>List of Orders</returns>
        List<Order> GetAllOrdersByCustomerId(int customerid);

        /// <summary>
        /// ComputeOrderTotal
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns>A Result Total</returns>
        double ComputeOrderTotal(int orderId);

        /// <summary>
        /// Insert Order
        /// </summary>
        /// <param name="order"></param>
        /// <returns>No.Rows Changes</returns>
        bool AddOrder(Order order);

        /// <summary>
        /// Update Order Total
        /// </summary>
        /// <param name="orderId">orderID need updated</param>
        /// <returns>No. Rows Changes</returns>
        bool UpdateOrderTotal(int orderId);
    }
}
