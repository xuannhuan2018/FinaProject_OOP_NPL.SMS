using System;
using System.Collections.Generic;
using System.Text;
using NPL.SMS.R2S.Training.Entities;
namespace NPL.SMS.R2S.Training.DAO
{
    interface ILineItemDAO
    {
        /// <summary>
        /// Get All LineItem of order ID
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns>List of LineItem</returns>
        List<LineItem> GetAllItemsByOrderId(int orderId);

        /// <summary>
        /// Add LineItem
        /// </summary>
        /// <param name="lineItem">Information of LineItem will be added</param>
        /// <returns>No.Rows Changes</returns>
        bool AddLineItem(LineItem lineItem);
    }
}
