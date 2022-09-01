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
            purchaseList.Add(char.Parse(input));
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
    }
}