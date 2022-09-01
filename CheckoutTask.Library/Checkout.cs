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

        private static int totalCost = 0;

        /// <summary>
        /// This is to set up the item pricing and offers avaiable. Add to this if more items are needed
        /// </summary>
        public static void SetupItemList()
        {
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
        /// Scan an item and add the appropriate price to the total cost
        /// </summary>
        /// <param name="input"></param>
        public static void Scan(string input)
        {
            
            totalCost += SKUList.Find(n => n.itemName == input).price;

        }

        /// <summary>
        /// Get the final price from the scanned items
        /// </summary>
        /// <returns></returns>
        public static int GetTotalPrice()
        {
            int finalPrice = totalCost;
            totalCost = 0;
            return finalPrice;
        }
    }
}
