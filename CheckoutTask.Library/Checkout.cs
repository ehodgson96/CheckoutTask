using System;
using System.Collections.Generic;

namespace CheckoutTask.Library
{
    public class Checkout
    {
        struct shoppingItem
        {
            public string itemName;//item string name
            public int price;    //normal price
            public int offerNum;   //number of items to qualify for S.O.
            public int offerPrice;// price with S.O.
        }

        private static List<shoppingItem> SKUList = new List<shoppingItem>();

        private static List<char> purchaseList = new List<char>();

        /// <summary>
        /// This is to set up the item pricing and offers avaiable. Add to this if more items are needed
        /// </summary>
        public static void SetupItemList()
        {
            SKUList = new List<shoppingItem>();
            string SKUItems = "ABCD";
            char[] SKUArray = SKUItems.ToCharArray();
            Console.WriteLine("--------- PRICING RULES ---------");

            foreach (var SKU in SKUArray)
            {
                shoppingItem NewSKUItem = new shoppingItem();
                NewSKUItem.itemName = SKU.ToString();
                Console.WriteLine("---------");
                Console.WriteLine("Pricing Rules For SKU Item: " + NewSKUItem.itemName );

                Console.WriteLine("Enter Base Price For SKU Item : ");
                String Result = Console.ReadLine();
                int price = CheckInputValues(Result);
                NewSKUItem.price = price;

                Console.WriteLine("Does this item have a special offer (y/n) : ");
                string readLine = Console.ReadLine().ToUpper();
                while(readLine != "Y"&& readLine != "N")
                {
                    Console.WriteLine("Incorrect Character entered. Please enter either y or n");
                    readLine = Console.ReadLine();
                }

                if (readLine == "Y")
                {
                    Console.WriteLine("Enter Minumum Quantity of units to qualify for Offer: ");
                    Result = Console.ReadLine();
                    int offerNum = CheckInputValues(Result);
                    NewSKUItem.offerNum = offerNum;

                    Console.WriteLine("Enter Offer Price: ");
                    Result = Console.ReadLine();
                    int integerValue = CheckInputValues(Result);
                    NewSKUItem.offerPrice = integerValue;

                }
                else
                {
                    NewSKUItem.offerNum = 0;
                    NewSKUItem.offerPrice = 0;
                }

                SKUList.Add(NewSKUItem);

            }
            Console.WriteLine("-------------------------------");


        }

        /// <summary>
        /// This is to set up the default item pricing and offers avaiable for testing.
        /// </summary>
        public static void SetupDefaultItemList()
        {
            SKUList = new List<shoppingItem>();

            shoppingItem AItem = new shoppingItem
            {
                itemName = "A",
                price = 50,
                offerNum = 3,
                offerPrice = 130
            };
            SKUList.Add(AItem);

            shoppingItem BItem = new shoppingItem
            {
                itemName = "B",
                price = 30,
                offerNum = 2,
                offerPrice = 45
            };
            SKUList.Add(BItem);

            shoppingItem CItem = new shoppingItem
            {
                itemName = "C",
                price = 20,
                offerNum = 0,
                offerPrice = 0
            };
            SKUList.Add(CItem);

            shoppingItem DItem = new shoppingItem
            {
                itemName = "D",
                price = 15,
                offerNum = 0,
                offerPrice = 0
            };
            SKUList.Add(DItem);
        }

        /// <summary>
        /// This is used to check input values for the SKU pricing rules are integers
        /// </summary>
        /// <param name="readLine"></param>
        /// <returns></returns>
        private static int CheckInputValues(string readLine)
        {
            int integerValue = 0;
            while (integerValue <= 0)
            {
                while (!Int32.TryParse(readLine, out integerValue))
                {
                    Console.WriteLine("Not a valid number, try again.");

                    readLine = Console.ReadLine();
                }

                if (integerValue <= 0)
                {
                    Console.WriteLine("Please enter a value greater than 0");
                    readLine = Console.ReadLine();
                }
            }
            
            return integerValue;
        }

        /// <summary>
        /// Scan an item and add the appropriate price to the total cost
        /// </summary>
        /// <param name="input"></param>
        public static void Scan(string input)
        {
            if (SKUItemExists(input.ToUpper())) //Check input value is same as one of the set SKU
                purchaseList.Add(char.Parse(input.ToUpper()));
        }

        public static bool SKUItemExists(string input)
        {
            return SKUList.Exists(x => x.itemName == input); //Check input value is same as one of the set SKU
        }


        /// <summary>
        /// Get the final price from the scanned items
        /// </summary>
        /// <returns></returns>
        public static int GetTotalPrice()
        {
            int finalPrice = 0;
            foreach (var item in SKUList)
            {
                int scannedCount = purchaseList.FindAll(n => n.ToString().ToUpper() == item.itemName).Count;
                if (scannedCount > 0)
                {
                    int totalItemPrice = GetItemPrice(scannedCount, item);
                    finalPrice += totalItemPrice;
                }
            }

            purchaseList.Clear(); //Clear list for next Checkout

            return finalPrice;
        }

        /// <summary>
        /// Get the total value from the individual SKU items
        /// </summary>
        /// <param name="scannedCount">count of the scanned items</param>
        /// <param name="item">item variables</param>
        /// <returns></returns>
        static int GetItemPrice(int scannedCount, shoppingItem item)
        {

            int totalPrice = 0;
            if (item.offerNum > 0)
            {
                int offerCount = scannedCount / item.offerNum;

                int normalPriceCount = (scannedCount % item.offerNum);

                int totalOfferPrice = offerCount * item.offerPrice;

                int totalNormalPrice = normalPriceCount * item.price;

                totalPrice = totalOfferPrice + totalNormalPrice;

            }
            else
            {
                totalPrice = (scannedCount * item.price);

            }
            return totalPrice;
        }

        /// <summary>
        /// Gets the base price from input for testing purposes
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int GetBasePrice(string input)
        {
            return SKUList.Find(x => x.itemName == input).price;
        }

        /// <summary>
        /// Gets the base price from input for testing purposes
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int GetMinimumOffer(string input)
        {
            return SKUList.Find(x => x.itemName == input).offerNum;
        }

        /// <summary>
        /// Gets the base price from input for testing purposes
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int GetOfferPrice(string input)
        {
            return SKUList.Find(x => x.itemName == input).offerPrice;
        }

    }
}