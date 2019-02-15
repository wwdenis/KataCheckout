using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Checkout.Business.Models
{
    /// <summary>
    /// Represents a group of scanned items
    /// </summary>
    public class CartItem
    {
        public CartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        /// <summary>
        /// The product informarion (Sku, Unit Price)
        /// </summary>
        public Product Product { get; }

        /// <summary>
        /// The total of scanned items
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Returns the simplest item total price
        /// </summary>
        public decimal Total => Quantity * Product?.Price ?? 0;
    }
}
