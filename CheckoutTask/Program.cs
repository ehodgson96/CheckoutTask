using CheckoutTask.Library;
using System;

namespace CheckoutTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            do
            {
                Checkout.SetupItemList();

                Console.WriteLine("Enter shopping item here    ||    Enter g to get total price    ||    Enter x to Exit    ||");
                do
                {
                    input = Console.ReadLine();
                    Checkout.Scan(input);

                } while (input != "x" && input != "g");

                if (input == "g")
                {
                    int output = Checkout.GetTotalPrice();
                    Console.WriteLine("--------------------");
                    Console.WriteLine("Total Price : " + output);
                    Console.WriteLine("--------------------");
                    Console.WriteLine("------------------------------------------------------------");
                }
            } while (input != "x");
        }
    }
}
