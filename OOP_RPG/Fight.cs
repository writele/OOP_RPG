using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_RPG
{
  public class Fight
  {
    public List<Monster> Monsters { get; set; }
    public Monster monster { get; set; }
    public Game game { get; set; }
    public Hero hero { get; set; }

    public Fight(Hero hero, Game game)
    {
      this.Monsters = new List<Monster>();
      this.hero = hero;
      this.game = game;
      this.AddMonster("Squid", 9, 8, 20);
      this.AddMonster("Kraken", 10, 6, 25);
      this.AddMonster("Octoman", 12, 5, 18);
      this.AddMonster("Killer Dolphin", 7, 11, 21);
    }

    public void AddMonster(string name, int strength, int defense, int hp)
    {
      var monster = new Monster(name, strength, defense, hp, hp);
      this.Monsters.Add(monster);
    }

    public void Start()
    {
      //this.monster = this.Monsters[this.Monsters.Count-1];
      //this.monster = this.Monsters[2];
      //this.monster = this.Monsters.Where(x => x.OriginalHP < 20).FirstOrDefault();
      //this.monster = this.Monsters.Where(x => x.Strength >= 12).FirstOrDefault();
      Random randomInt = new Random();
      int randomMonster = randomInt.Next(this.Monsters.Count - 1);
      this.monster = this.Monsters[randomMonster];

      Console.WriteLine("You've encountered a " + monster.Name + "! " + monster.Strength + " Strength/" + monster.Defense + " Defense/" +
      this.monster.CurrentHP + " HP. What will you do?");
      Console.WriteLine("1. Fight");
      var input = Console.ReadLine();
      if (input == "1")
      {
        this.HeroTurn(this.monster);
      }
      else {
        this.game.Main();
      }
    }

    public void HeroTurn(Monster monster)
    {
      var compare = hero.Strength - monster.Defense;
      int damage;

      if (compare <= 0)
      {
        damage = 1;
        monster.CurrentHP -= damage;
      }
      else {
        damage = compare;
        monster.CurrentHP -= damage;
      }
      Console.WriteLine("You did " + damage + " damage!");

      if (monster.CurrentHP <= 0)
      {
        this.Win(monster);
      }
      else
      {
        this.MonsterTurn(monster);
      }

    }

    public void MonsterTurn(Monster monster)
    {
      int damage;
      var compare = monster.Strength - hero.Defense;
      if (compare <= 0)
      {
        damage = 1;
        hero.CurrentHP -= damage;
      }
      else {
        damage = compare;
        hero.CurrentHP -= damage;
      }
      Console.WriteLine(monster.Name + " does " + damage + " damage!");
      if (hero.CurrentHP <= 0)
      {
        this.Lose();
      }
      else
      {
        this.Start();
      }
    }

    public void Win(Monster monster)
    {
      Console.WriteLine(monster.Name + " has been defeated! You win the battle!");
      this.hero.Gold += this.monster.Gold;
      game.Main();
    }

    public void Lose()
    {
      Console.WriteLine("You've been defeated! :( GAME OVER.");
      return;
    }

  }

}