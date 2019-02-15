using Kata.Checkout.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.Checkout.Business.Services
{
    public class NormalPriceRule : IPriceRule
    {
        public decimal Calculate(ICollection<CartItem> items)
        {
            var total = items.Sum(i => i.Total);
            items.Clear();
            return total;
        }
    }
}
