using System;

namespace CheckoutTask.Library
{
    public class Checkout
    {
        private static int totalCost = 0;

        public static void Scan(string input)
        {
            if (input == "A")
                totalCost += 50;
            if (input == "B")
                totalCost += 30;
            if (input == "C")
                totalCost += 20;
            if (input == "D")
                totalCost += 15;
        }

        public static int GetTotalPrice()
        {
            int finalPrice = totalCost;
            totalCost = 0;
            return finalPrice;
        }
    }
}
