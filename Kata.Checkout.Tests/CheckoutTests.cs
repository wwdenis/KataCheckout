using NUnit.Framework;

namespace Tests
{
    public class CheckoutTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Check_Totals()
        {
            var checkout = new SimpleCheckout();

            checkout.Scan("DUMMY");

            decimal total = checkout.Calculate();
            decimal expectedTotal = 0;

            Assert.AreEqual(expectedTotal, total);
        }
    }
}