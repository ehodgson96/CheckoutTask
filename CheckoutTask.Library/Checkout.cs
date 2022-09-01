using System;

namespace CheckoutTask.Library
{
    public class Checkout
    {
        private static int totalCost = 0;

        public static void Scan(string input)
        {
            totalCost += 50;

        }

        public static int GetTotalPrice()
        {
            return totalCost;
        }
    }
}
