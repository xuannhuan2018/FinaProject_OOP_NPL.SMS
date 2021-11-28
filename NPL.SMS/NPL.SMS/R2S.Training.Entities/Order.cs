using System;
using System.Collections.Generic;
using System.Text;

namespace NPL.SMS.R2S.Training.Entities
{
    /// <summary>
    /// Class: Order
    /// </summary>
    class Order
    {
        // attributes
        private int orderId, customerId, employeeId;
        private DateTime orderDate;
        private double total;

        /// <summary>
        /// Constructor with 5 args
        /// </summary>
        /// <param name="orderId">Order Id</param>
        /// <param name="customerId">Customer Id</param>
        /// <param name="employeeId">Employee Id</param>
        /// <param name="orderDate">Oerder Date</param>
        /// <param name="total">Total</param>
        public Order(int orderId, int customerId, int employeeId, DateTime orderDate, double total)
        {
            this.OrderId = orderId;
            this.CustomerId = customerId;
            this.EmployeeId = employeeId;
            this.OrderDate = orderDate;
            this.Total = total;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Order()
        {
        }

        // properties
        public int OrderId { get => orderId; set => orderId = value; }
        public int CustomerId { get => customerId; set => customerId = value; }
        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public DateTime OrderDate { get => orderDate; set => orderDate = value; }
        public double Total { get => total; set => total = value; }

        public override string ToString()
        {
            return string.Format("OrderID: {0}, Order Date: {1}, Customer ID: {2}, Employee ID: {3}, Total: {4}", OrderId, OrderDate, CustomerId, EmployeeId, Total);
        }
    }
}
