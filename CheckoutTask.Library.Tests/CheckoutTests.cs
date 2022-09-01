using NUnit.Framework;

namespace CheckoutTask.Library.Tests
{
    public class CheckoutTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Get50FromA()
        {
            string input = "A";
            Checkout.Scan(input);
            int output = Checkout.GetTotalPrice();
            Assert.AreEqual(50,output);
        }
    }
}