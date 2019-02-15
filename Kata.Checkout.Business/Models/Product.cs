using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Checkout.Business.Models
{
    public class Product
    {
        public Product(string sku, decimal price)
        {
            Sku = sku;
            Price = price;
        }

        public string Sku { get; }
        public decimal Price { get; }
    }
}
