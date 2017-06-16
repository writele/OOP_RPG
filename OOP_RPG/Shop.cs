using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
  public class Shop
  {
    public Shop(Game game)
    {
      this.Inventory = new List<IItem>();
      this.game = game;
    }

    public List<IItem> Inventory { get; set; }
    public Game game { get; set; }

    public void Menu()
    {
      Console.WriteLine("Welcome to my shop! What would you like to do?");
      Console.WriteLine("1. Buy Item");
      Console.WriteLine("2. Sell Item");
      Console.WriteLine("3. Return to Game Menu");
      var input = Console.ReadLine();
      if (input == "1")
      {
        this.ShowInventory();
      }
      else if (input == "2")
      {
        this.BuyfromUser();
      }
      else {
        game.Main();
      }
    }

    public void ShowInventory()
    {
      Console.WriteLine("**** INVENTORY ****");
      foreach (IItem item in Inventory)
      {
        Console.WriteLine(item.Name + ", " + item.OriginalValue + " Gold");
      }
      Console.WriteLine("Press 'q' to return to the main menu.");
      var input = Console.ReadLine().ToLower();

      if (input == "q")
      {
        Menu();
      }

      try
      {
        IItem saleItem = Inventory.Where(x => x.Name.ToLower() == input).First();
        Sell(saleItem);
      }
      catch
      {
        Console.WriteLine("That is not a valid entry.");
        ShowInventory();
      }

    }

    public void Sell(IItem item)
    {
      Console.WriteLine("You have purchased " + item.Name);
      Console.ReadKey();
      Menu();
    }

    public void BuyfromUser()
    {

    }
  }
}
