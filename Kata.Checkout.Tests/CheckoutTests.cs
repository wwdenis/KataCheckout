using NUnit.Framework;

namespace Tests
{
    public class CheckoutTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(50, "A")]
        [TestCase(30, "B")]
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