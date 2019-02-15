using Kata.Checkout.Business.Models;
using Kata.Checkout.Business.Services;
using NUnit.Framework;

namespace Tests
{
    public class CheckoutTests
    {
        ICheckout _checkout;
        
        [SetUp]
        public void Setup()
        {
            Product[] products = 
            {
                new Product("A", 50),
                new Product("B", 30),
                new Product("C", 20),
                new Product("D", 15)
            };

            IPriceRule[] rules =
            {
                new QuantityOfferRule("A", 3, 130),
                new QuantityOfferRule("B", 2, 45),
                new NormalPriceRule()
            };

            _checkout = new ParameterizedCheckout(products, rules);
            // _checkout = new SimpleCheckout();
        }

        [TestCase(50, "A")]                         // Normal Price (single)
        [TestCase(30, "B")]                         // Normal Price (single)
        [TestCase(80, "A", "B")]                    // Normal Price (multiple)
        [TestCase(100, "A", "A")]                   // Normal Price (multiple)
        [TestCase(130, "A", "A", "A")]              // One Offer
        [TestCase(45, "B", "B")]                    // One Offer
        [TestCase(175, "A", "A", "A", "B", "B")]    // Two Offers

        // Test Cases from : http://codekata.com/kata/kata09-back-to-the-checkout/
        [TestCase(0, "")]
        [TestCase(115, "C", "D", "B", "A")]
        [TestCase(180, "A", "A", "A", "A")]
        [TestCase(230, "A", "A", "A", "A", "A")]
        [TestCase(260, "A", "A", "A", "A", "A", "A")]
        [TestCase(160, "A", "A", "A", "B")]
        [TestCase(190, "A", "A", "A", "B", "B", "D")]
        [TestCase(190, "D", "A", "B", "A", "B", "A")]
        public void Check_Totals_With_Incremental_Scans(decimal expectedTotal, params string[] skus)
        {
            foreach (var sku in skus)
            {
                _checkout.Scan(sku);
            }

            decimal total = _checkout.Calculate();
            
            Assert.AreEqual(expectedTotal, total);
        }
    }
}