using System;
using System.Collections.Generic;
using System.Threading;
using CastleGrimtol.Project.Interfaces;
using CastleGrimtol.Project.Models;

namespace CastleGrimtol.Project
{
  public class GameService : IGameService
  {
    public bool Running = true;
    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }

    public GameService(Player player)
    {
      Setup();
      CurrentPlayer = player;
    }



    public void GetUserInput()
    {
      string[] input = Console.ReadLine().ToLower().Split(" ");
      string action = input[0];
      string choice = input[1];
      switch (action)
      {
        case "go":
          Go(choice);
          break;

        case "inventory":
          Inventory();
          break;

        case "help":
          Help();
          break;

        case "look":
          Look();
          break;

        case "quit":
          Quit();
          break;

        case "reset":
          Reset();
          break;

        case "take":
          TakeItem(choice);
          break;

        case "use":
          UseItem(choice);
          break;

        default:
          Console.WriteLine("Invalid Input. Try Again. If you need help, type HELP.");
          break;
      }
    }

    public void Go(string direction)
    {
      if (CurrentRoom.Exits.ContainsKey(direction))
      {
        CurrentRoom = (Room)CurrentRoom.Exits[direction];
      }
      else
      {
        Console.WriteLine("Invalid Direction. Please choose a different direction.");
        Thread.Sleep(2000);
      };
    }

    public void Help()
    {
      ;
    }

    public void Inventory()
    {
      ;
    }

    public void Look()
    {
      ;
    }

    public void Quit()
    {
      ;
    }

    public void Reset()
    {
      ;
    }

    public void Setup()
    {
      //--ROOMS--
      Room console = new Room("Console");
      Room hall = new Room("Dark Hall");
      Room library = new Room("Library");
      Room shelves = new Room("Shelves");
      Room door = new Room("Door");

      //--ITEMS--
      Item sonic = new Item("Sonic Screwdriver");
      Item fez = new Item("Fez");
      Item bookCyborg = new Item("Wild West Cyborg");
      Item bookPompei = new Item("Fires of Pompei");
      Item bookTime = new Item("End of Time");

      //--ROOM RELATIONSHIPS--
      console.Exits.Add("north", hall);
      console.Exits.Add("south", shelves);
      console.Exits.Add("west", library);
      console.Exits.Add("east", door);
      library.Exits.Add("north", hall);
      library.Exits.Add("east", console);
      library.Exits.Add("south", shelves);
      shelves.Exits.Add("west", library);
      shelves.Exits.Add("north", console);
      shelves.Exits.Add("east", door);
      door.Exits.Add("north", hall);
      door.Exits.Add("west", console);
      door.Exits.Add("south", shelves);

      CurrentRoom = console;

      //--ITEM RELATIONSHIPS--
      library.Items.Add(bookCyborg);
      library.Items.Add(bookPompei);
      library.Items.Add(bookTime);
      library.Items.Add(sonic);
      shelves.Items.Add(fez);
    }

    public void StartGame()
    {
      while (Running)
      {
        Console.Clear();
        Console.WriteLine($"{CurrentRoom.Name}");
        GetUserInput();
      }
    }

    public void TakeItem(string itemName)
    {
      ;
    }

    public void UseItem(string itemName)
    {
      ;
    }

  }
}