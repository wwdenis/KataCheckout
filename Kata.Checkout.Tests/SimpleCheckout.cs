using System;
using System.Collections.Generic;

namespace Tests
{
    internal class SimpleCheckout
    {
        readonly List<string> items = new List<string>();

        public SimpleCheckout()
        {
        }

        internal decimal Calculate()
        {
            return 0;
        }

        public void Scan(string sku)
        {
            items.Add(sku);
        }
    }
}