using System;
using System.Collections.Generic;
using System.Text;
using NPL.SMS.R2S.Training.Entities;

namespace NPL.SMS.R2S.Training.DAO
{
    /// <summary>
    /// Inter face ICustomerDAO
    /// </summary>
    interface ICustomerDAO
    {
        /// <summary>
        /// Get All Customer By Order ID
        /// </summary>
        /// <returns>List of Customer</returns>
        List<Customer> GetAllCustomer();

        /// <summary>
        /// Add Customer
        /// </summary>
        /// <param name="customer">New Customer</param>
        /// <returns>No.Rows Changes</returns>
        bool AddCustomer(Customer customer);

        /// <summary>
        /// Delete Customer
        /// </summary>
        /// <param name="customerId">Customer ID will be deleted</param>
        /// <returns></returns>
        bool DeleteCustomer(int customerId);

        /// <summary>
        /// Update Customer
        /// </summary>
        /// <param name="customer">New customer</param>
        /// <returns>No.Rows Changes</returns>
        bool UpdateCustomer(Customer customer);
    }
}
