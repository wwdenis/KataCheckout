using Kata.Checkout.Business;
using NUnit.Framework;

namespace Tests
{
    public class CheckoutTests
    {
        [SetUp]
        public void Setup()
        {
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
            var checkout = new SimpleCheckout();

            foreach (var sku in skus)
            {
                checkout.Scan(sku);
            }

            decimal total = checkout.Calculate();
            
            Assert.AreEqual(expectedTotal, total);
        }
    }
}