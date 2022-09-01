using NUnit.Framework;
using System;

namespace CheckoutTask.Library.Tests
{
    public class CheckoutTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetBasePriceFromSingleInput([Values("A", "B", "C", "D")] string input)
        {
            Checkout.SetupDefaultItemList();
            Checkout.Scan(input);
            int output = Checkout.GetTotalPrice();
            int basePrice = Checkout.GetBasePrice(input);
            Assert.AreEqual(basePrice, output);
        }

        [Test]
        public void GetOfferPriceFromMinimumOfferInput([Values("A", "B", "C", "D")] string input)
        {
            Checkout.SetupDefaultItemList();
            int minimumAmountForOffer = Checkout.GetMinimumOffer(input);
            for (int i = 0; i < minimumAmountForOffer; i++)
            {
                Checkout.Scan(input);
            }

            int output = Checkout.GetTotalPrice();

            int offerPrice = Checkout.GetOfferPrice(input);
            Assert.AreEqual(offerPrice, output);
        }


        [Test]
        public void Get100FromAA()
        {
            string input = "A";
            Checkout.SetupDefaultItemList();
            Checkout.Scan(input);
            Checkout.Scan(input);
            int output = Checkout.GetTotalPrice();
            Assert.AreEqual(100, output);
        }


        [Test]
        public void GetOfferFromDifferentOrder()
        {
            string input = "A";
            string input2 = "B";
            Checkout.SetupDefaultItemList();
            Checkout.Scan(input);
            Checkout.Scan(input);
            Checkout.Scan(input2);
            Checkout.Scan(input);
            int output = Checkout.GetTotalPrice();
            Assert.AreEqual(160, output);
        }

        [Test]
        public void CheckForIncorrectInput([Values("", " ", "H","X","AA")] string input)
        {
            Checkout.SetupDefaultItemList();
            Checkout.Scan(input);
            int output = Checkout.GetTotalPrice();
            Assert.AreEqual(0, output);
        }



    }
}