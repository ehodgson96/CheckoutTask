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
            Checkout.SetupItemList();
            Checkout.Scan(input);
            int output = Checkout.GetTotalPrice();
            Assert.AreEqual(50,output);
        }

        [Test]
        public void Get30FromB()
        {
            string input = "B";
            Checkout.SetupItemList();
            Checkout.Scan(input);
            int output = Checkout.GetTotalPrice();
            Assert.AreEqual(30, output);
        }

        [Test]
        public void Get20FromC()
        {
            string input = "C";
            Checkout.SetupItemList();
            Checkout.Scan(input);
            int output = Checkout.GetTotalPrice();
            Assert.AreEqual(20, output);
        }

        [Test]
        public void Get15FromD()
        {
            string input = "D";
            Checkout.SetupItemList();
            Checkout.Scan(input);
            int output = Checkout.GetTotalPrice();
            Assert.AreEqual(15, output);
        }

        [Test]
        public void Get100FromAA()
        {
            string input = "A";
            Checkout.SetupItemList();
            Checkout.Scan(input);
            Checkout.Scan(input);
            int output = Checkout.GetTotalPrice();
            Assert.AreEqual(100, output);
        }


    }
}