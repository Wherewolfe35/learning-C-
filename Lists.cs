using System;
using System.Collections.Generic;

namespace learning_generics
{
  public class Lists
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Thank you for shopping with us, here is your receipt:");
      ShoppingBaskets print = new ShoppingBaskets();
      Console.WriteLine(print.AddTax());
    }

    public class ShoppingItem
    {
      public int numberOfItems { get; set; }
      public string itemName { get; set; }
      public double price { get; set; }
    }

    public class ShoppingBaskets // this could be made into a loop where it creates x number of baskets depending on a variable that states there are x number of baskets. 
    {
      List<ShoppingItem> shoppingBasket1 = new List<ShoppingItem>();
      List<ShoppingItem> shoppingBasket2 = new List<ShoppingItem>();
      List<ShoppingItem> shoppingBasket3 = new List<ShoppingItem>();


      public ShoppingBaskets()
      {
        shoppingBasket1 = new List<ShoppingItem>
        {
            new ShoppingItem {numberOfItems = 1, itemName = "book", price = 12.49},
            new ShoppingItem {numberOfItems = 1, itemName = "music CD", price = 14.99},
            new ShoppingItem {numberOfItems = 1, itemName = "chocolate Bar", price = 0.85},
        };
        shoppingBasket2 = new List<ShoppingItem>
        {
            new ShoppingItem {numberOfItems = 1, itemName = "imported box of chocolate", price = 10.00},
            new ShoppingItem {numberOfItems = 1, itemName = "imported bottle of perfume", price = 47.50},
        };
        shoppingBasket3 = new List<ShoppingItem>
        {
            new ShoppingItem {numberOfItems = 1, itemName = "imported bottle of perfume", price = 27.99},
            new ShoppingItem {numberOfItems = 1, itemName = "bottle of perfume", price = 18.99},
            new ShoppingItem {numberOfItems = 1, itemName = "packet of headache pills", price = 9.75},
            new ShoppingItem {numberOfItems = 1, itemName = "imported box of chocolate", price = 11.25},
        };
      }

      public void TaxCalculator(List<ShoppingItem> item)
      {
        double totalPrice = 0;
        double salesTax = 0;
        double tax = 0;
        double cost = 0;
        double importTax = 0;
        string[] taxExempt = { "book", "chocolate", "pills" };
        item.ForEach((item) =>
        {
          tax = Math.Ceiling(Math.Round(item.price * 0.1, 2) * 20) / 20;
          for (int i = 0; i < taxExempt.Length; i++)
          {
            if (item.itemName.Contains(taxExempt[i]))
            {
              tax = 0;
            }
          }
          salesTax += tax;
          if (item.itemName.Contains("imported"))
          {
            importTax = Math.Ceiling(Math.Round(item.price * 0.05, 2) * 20) / 20;
          }
          else
          {
            importTax = 0;
          }
          salesTax += importTax;
          cost = Math.Round(item.price + tax + importTax, 2);
          totalPrice += cost;
          Console.WriteLine($"{item.numberOfItems} {item.itemName}: ${cost.ToString("f2")}");
        });

        Console.WriteLine("Sales Tax: $" + Math.Round(salesTax, 2).ToString("f2"));
        Console.WriteLine("Total: $" + Math.Round(totalPrice, 2).ToString("f2"));
        Console.WriteLine();
      }

      public string AddTax() //I do not know why this won't let me return void, so I had it return a string instead
      {
        TaxCalculator(shoppingBasket1);
        TaxCalculator(shoppingBasket2);
        TaxCalculator(shoppingBasket3);
        return "";
      }
    }
  }
}