using Kata.Checkout.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.Checkout.Business.Services
{
    public class QuantityOfferRule : IPriceRule
    {
        readonly string _sku;
        readonly int _quantity;
        readonly decimal _price;

        public QuantityOfferRule(string sku, int quantity, decimal price)
        {
            _sku = sku;
            _quantity = quantity;
            _price = price;
        }

        public decimal Calculate(ICollection<CartItem> items)
        {
            decimal total = 0;
            var selected = items.FirstOrDefault(i => i.Product.Sku == _sku);

            if (selected != null)
            {
                int multiple = Math.DivRem(selected.Quantity, _quantity, out int remainder);
                total = multiple * _price;

                if (remainder > 0)
                    selected.Quantity = remainder;
                else
                    items.Remove(selected);
            }

            return total;
        }
    }
}
