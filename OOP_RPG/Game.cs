using System;
using System.Collections.Generic;

namespace OOP_RPG
{
  public class Game
  {
    public Hero hero { get; set; }
    public Shop shop { get; set; }

    public Game()
    {
      this.hero = new Hero();
    }

    public void Start()
    {
      Console.WriteLine("Welcome hero!");
      Console.WriteLine("Please enter your name:");
      this.hero.Name = Console.ReadLine();
      InitializeShop();
      Console.WriteLine("Hello " + hero.Name);
      this.Main();
    }

    public void Main()
    {
      Console.WriteLine("Please choose an option by entering a number.");
      Console.WriteLine("1. View Stats");
      Console.WriteLine("2. View Inventory");
      Console.WriteLine("3. Fight Monster");
      var input = Console.ReadLine();
      if (input == "1")
      {
        this.Stats();
      }
      else if (input == "2")
      {
        this.Inventory();
      }
      else if (input == "3")
      {
        this.Fight();
      }
      else {
        return;
      }
    }

    public void InitializeShop()
    {
      this.shop = new Shop();
      Weapon weapon1 = new Weapon("Sword", 3, 10, 2);
      Weapon weapon2 = new Weapon("Axe", 4, 12, 3);
      Weapon weapon3 = new Weapon("Longsword", 7, 20, 5);

      shop.Weapons.Add(weapon1);
      shop.Weapons.Add(weapon2);
      shop.Weapons.Add(weapon3);

      Armor armor1 = new Armor("Wooden Armor", 3, 10, 2);
      Armor armor2 = new Armor("Metal Armor", 7, 20, 5);

      shop.Armor.Add(armor1);
      shop.Armor.Add(armor2);

      Potion potion1 = new Potion("Healing Potion", 5, 15, 5);
      shop.Potions.Add(potion1);
    }
    public void Stats()
    {
      hero.ShowStats();
      Console.WriteLine("Press any key to return to main menu.");
      Console.ReadKey();
      this.Main();
    }

    public void Inventory()
    {
      hero.ShowInventory();
      Console.WriteLine("Press any key to return to main menu.");
      Console.ReadKey();
      this.Main();
    }

    public void Fight()
    {
      var fight = new Fight(this.hero, this);
      fight.Start();
    }


  }
}