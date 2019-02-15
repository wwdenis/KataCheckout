using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Checkout.Business.Models
{
    public class CartItem
    {
        public CartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public Product Product { get; }
        public int Quantity { get; set; }
        public decimal Total => Quantity * Product?.Price ?? 0;
    }
}
