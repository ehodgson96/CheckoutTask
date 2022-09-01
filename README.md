# CheckoutTask

This Project is my resolution to tech task provided by BrightHR

# The Task

In a normal supermarket, things are identified using Stock Keeping Units, or SKUs. In our shop, we’ll use individual letters of the alphabet (A, B, C, and so on). Our goods are priced individually. In addition, some items are multipriced: buy n of them, and they’ll cost you y pounds. For example, item ‘A’ might cost 50 pounds individually, but this week we have a special offer: buy three ‘A’s and they’ll cost you 130. The current pricing and offers are as follows:
SKU 	Unit Price 	Special Price
A 	50 	3 for 130
B 	30 	2 for 45
C 	20 	
D 	15 	

Our checkout accepts items in any order, so that if we scan a B, an A, and another B, we’ll recognize the two B’s and price them at 45 (for a total price so far of 95). Because the pricing changes frequently, we need to be able to pass in a set of pricing rules each time we start handling a checkout transaction.

Here's a suggested interface for the checkout...

interface ICheckout
{
    void Scan(string item);
    int GetTotalPrice();
}

### Instructions

Implement a class library that satisfies the problem described above. The solution should be test driven.

# Final Comments

This is the first time I have attempted to use the TDD Structure for solving a problem, so this took me longer than usual to complete the task.
Towards the end I found it tricky to provide dynamic tests for the changing inputted SKU values, this was due to the tests being performed on pre set values and not from console.Readline
(this is something I will look into further)

I forgot to push a previous commit before the last commit. Hence the naming, the difference between was the implementation of the program.cs actual checkout using the Checkout.Library
