using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    internal class SimpleCheckout
    {
        readonly (string, decimal)[] prices =
        {
            ( "A", 50 ),
            ( "B", 30 )
        };

        readonly List<string> items = new List<string>();

        public SimpleCheckout()
        {
        }

        internal decimal Calculate()
        {
            decimal total = 0;

            // Group SKU's and count
            var grouped = items.GroupBy(i => i).ToDictionary(k => k.Key, v => v.Count());

            foreach (var group in grouped)
            {
                var price = prices.FirstOrDefault(i => i.Item1 == group.Key);
                
                total += price.Item2 * group.Value;
            }

            return total;
        }

        public void Scan(string sku)
        {
            items.Add(sku);
        }
    }
}