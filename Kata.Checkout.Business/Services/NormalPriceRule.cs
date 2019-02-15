using Kata.Checkout.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.Checkout.Business.Services
{
    /// <summary>
    /// Calculates all items that have no offer
    /// </summary>
    public class NormalPriceRule : IPriceRule
    {
        public decimal Calculate(ICollection<CartItem> items)
        {
            // Sum all item totals and clear the collection (to avoid being calculated for another PriceRule)
            var total = items.Sum(i => i.Total);
            items.Clear();
            return total;
        }
    }
}
