using System;
using System.Collections.Generic;
using System.Text;

namespace NPL.SMS.R2S.Training.Entities
{
    /// <summary>
    /// Class: Customer
    /// </summary>
    public class Customer
    {
        // attributes
        private int customerId;
        private string customerName;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Customer()
        {
        }

        /// <summary>
        /// Constructor with 2 args
        /// </summary>
        /// <param name="customerId">Customer Id</param>
        /// <param name="customerName">Custimer Name</param>
        public Customer(int customerId, string customerName)
        {
            this.CustomerId = customerId;
            this.CustomerName = customerName;
        }

        // properties
        public int CustomerId { get => customerId; set => customerId = value; }
        public string CustomerName { get => customerName; set => customerName = value; }

        public override string ToString()
        {
            return string.Format("Customer ID: {0}, CustomerName: {1}", CustomerId, CustomerName);
        }
    }

}
