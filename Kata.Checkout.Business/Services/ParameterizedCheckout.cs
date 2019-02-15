using Kata.Checkout.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.Checkout.Business.Services
{
    public class ParameterizedCheckout : ICheckout
    {
        readonly IPriceRule[] _rules;
        readonly Product[] _products;

        readonly List<string> _skus = new List<string>();

        public ParameterizedCheckout(Product[] products, IPriceRule[] rules)
        {
            _rules = rules ?? throw new ArgumentNullException();
            _products = products ?? throw new ArgumentNullException();
        }

        public decimal Calculate()
        {
            decimal total = 0;

            var grouped = _skus.GroupBy(i => i);

            var items = from p in _products
                        let quantity = _skus.Count(i => i == p.Sku)
                        where quantity > 0
                        select new CartItem(p, quantity);

            var list = items.ToList();

            foreach (var rule in _rules)
            {
                var ruleTotal = rule.Calculate(list);
                total += ruleTotal;
            }

            return total;
        }

        public void Scan(string sku)
        {
            _skus.Add(sku);
        }
    }
}
