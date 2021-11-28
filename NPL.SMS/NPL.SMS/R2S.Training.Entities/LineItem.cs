using System;
using System.Collections.Generic;
using System.Text;

namespace NPL.SMS.R2S.Training.Entities
{
    /// <summary>
    /// Class: LineItem
    /// </summary>
    public class LineItem
    {
        // attributes
        private int orderId, productId, quantity;
        private double price;

        /// <summary>
        /// Default constructor
        /// </summary>
        public LineItem()
        {
        }

        /// <summary>
        /// Constructor with args
        /// </summary>
        /// <param name="orderId">Order Id</param>
        /// <param name="productId">Product Id</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="price">Price</param>
        public LineItem(int orderId, int productId, int quantity, double price)
        {
            this.OrderId = orderId;
            this.ProductId = productId;
            this.Quantity = quantity;
            this.Price = price;
        }

        // properties
        public int OrderId { get => orderId; set => orderId = value; }
        public int ProductId { get => productId; set => productId = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public double Price { get => price; set => price = value; }

        public override string ToString()
        {
            return string.Format("Order ID: {0}, Product ID: {1}, Quantity: {2}, Price: {3}", OrderId, ProductId, Quantity, Price);
        }
    }
}
