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
            _checkout = new SimpleCheckout();
        }

        [TestCase(50, "A")]                         // Normal Price (single)
        [TestCase(30, "B")]                         // Normal Price (single)
        [TestCase(80, "A", "B")]                    // Normal Price (multiple)
        [TestCase(100, "A", "A")]                   // Normal Price (multiple)
        [TestCase(130, "A", "A", "A")]              // One Offer
        [TestCase(45, "B", "B")]                    // One Offer
        [TestCase(175, "A", "A", "A", "B", "B")]    // Two Offers
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