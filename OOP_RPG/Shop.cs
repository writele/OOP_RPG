using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
  public class Shop
  {
    public Shop(Hero hero, Game game)
    {
      this.Inventory = new List<IItem>();
      this.game = game;
      this.hero = hero;
    }

    public List<IItem> Inventory { get; set; }
    public Game game { get; set; }
    public Hero hero { get; set; }

    public void Menu()
    {
      Console.WriteLine("Welcome to my shop! What would you like to do?");
      Console.WriteLine("1. Buy Item");
      Console.WriteLine("2. Sell Item");
      Console.WriteLine("3. Return to Game Menu");
      var input = Console.ReadLine();
      if (input == "1")
      {
        this.ShowShopInventory();
      }
      else if (input == "2")
      {
        this.ShowHeroInventory();
      }
      else {
        game.Main();
      }
    }

    public void ShowShopInventory()
    {
      Console.WriteLine("**** INVENTORY ****");
      foreach (IItem item in Inventory)
      {
        Console.WriteLine(item.Name + ", " + item.OriginalValue + " Gold");
      }
      Console.WriteLine("You currently have " + hero.Gold + " gold. Enter the name of the item you would like to buy. Press 'q' to return to the main menu.");
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
        ShowShopInventory();
      }

    }

    public void ShowHeroInventory()
    {
      Console.WriteLine("Enter the name of the item you would like to sell. Press 'q' to return to the main menu.");
      foreach (IItem item in hero.Inventory)
      {
        Console.WriteLine(item.Name + " for " + item.OriginalValue + " Gold");
      }
      var input = Console.ReadLine().ToLower();
      if (input == "q")
      {
        Menu();
      }

      try
      {
        IItem saleItem = Inventory.Where(x => x.Name.ToLower() == input).First();
        Buy(saleItem);
      }
      catch
      {
        Console.WriteLine("That is not a valid entry.");
        ShowHeroInventory();
      }
    }

    public void Sell(IItem item)
    {
      if (hero.Gold >= item.OriginalValue)
      {
        hero.Inventory.Add(item);
        hero.Gold -= item.OriginalValue;
        Console.WriteLine("You have purchased " + item.Name);
      }
      else {
        Console.WriteLine("You do not have enough gold to purchase that item.");
      }
      Menu();
    }

    public void Buy(IItem item)
    {
      hero.Inventory.Remove(item);
      hero.Gold += item.OriginalValue;
      Console.WriteLine("Successful transaction. You now have " + hero.Gold + " gold.");
      Menu();
    }
  }
}
