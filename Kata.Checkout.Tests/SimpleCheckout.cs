using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    internal class SimpleCheckout
    {
        // Price information (Tupples)
        readonly (string, decimal)[] prices =
        {
            ( "A", 50 ),
            ( "B", 30 )
        };

        // Offer information (Tupples)
        readonly (string, decimal, int)[] offers =
        {
            ( "A", 130, 3 ),
            ( "B", 45, 2 )
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
                // Look for offer related to the SKU
                var offer = offers.FirstOrDefault(i => i.Item1 == group.Key);

                // Split Offer quantities and normal price quantities
                // E.g: 5 Apples (Scanned) = 1 Offer + 2 Normal Price 
                var offerQuantity = Math.DivRem(group.Value, offer.Item3, out int priceQuantity);

                // Calculates offer and normal prices
                var offerPrice = offerQuantity * offer.Item2;
                var normalPrice = priceQuantity * prices.FirstOrDefault(i => i.Item1 == group.Key).Item2;

                total += offerPrice + normalPrice;
            }

            return total;
        }

        public void Scan(string sku)
        {
            items.Add(sku);
        }
    }
}