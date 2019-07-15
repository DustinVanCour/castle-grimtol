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
      string[] input = Console.ReadLine().ToLower().Split(' ');
      string action = input[0];
      string choice = "";
      if (input.Length > 1)
      {
        choice = input[1];
      }
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
          Console.WriteLine("Invalid Input. Try Again. Or type HELP.");
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
      Console.WriteLine($"{CurrentRoom.Exits}");
    }

    public void Inventory()
    {
      Console.WriteLine("INVENTORY:");
      int count = 1;
      foreach (var Item in CurrentPlayer.Inventory)
      {
        Console.WriteLine($"{count}) {Item.Name}");
        count++;
      }
      // Console.WriteLine($"INVENTORY: {}");
    }

    public void Look()
    {
      ;
    }

    public void Quit()
    {
      Console.WriteLine("Thanks for playing!");
      Thread.Sleep(5000);
      Environment.Exit(-1);
    }

    public void Reset()
    {
      Console.Clear();
      Console.WriteLine(@"  
  ______                            _   _            _______       _____  _____ _____  _____ 
 |  ____|                          | | | |          |__   __|/\   |  __ \|  __ \_   _|/ ____|
 | |__   ___  ___ __ _ _ __   ___  | |_| |__   ___     | |  /  \  | |__) | |  | || | | (___  
 |  __| / __|/ __/ _` | '_ \ / _ \ | __| '_ \ / _ \    | | / /\ \ |  _  /| |  | || |  \___ \ 
 | |____\__ \ (_| (_| | |_) |  __/ | |_| | | |  __/    | |/ ____ \| | \ \| |__| || |_ ____) |
 |______|___/\___\__,_| .__/ \___|  \__|_| |_|\___|    |_/_/    \_\_|  \_\_____/_____|_____/ 
                      | |                                                                    
                      |_|                                                                    
                      
                      
                                        _.--._
                                        _|__|_
                            _____________|__|_____________
                         .-'______________________________'-.
                         | |________POLICE___BOX__________| |
                         |  |============================|  |
                         |  | .-----------..-----------. |  |
                         |  | |  _  _  _  ||  _  _  _  | |  |
                         |  | | | || || | || | || || | | |  |
                         |  | | |_||_||_| || |_||_||_| | |  |
                         |  | | | || || | || | || || | | |  |
                         |  | | |_||_||_| || |_||_||_| | |  |
                         |  | |  _______  ||  _______  | |  |
                         |  | | |       | || |       | | |  |
                         |  | | |       | || |       | | |  |
                         |  | | |       | || |       | | |  |
                         |  | | |_______| || |_______| | |  |
                         |  | |  _______ @||@ _______  | |  |
                         |  | | |       | || |       | | |  |
                         |  | | |       | || |       | | |  |
                         |  | | |       | || |       | | |  |
                         |  | | |_______| || |_______| | |  |
                         |  | |  _______  ||  _______  | |  |
                         |  | | |       | || |       | | |  |
                         |  | | |       | || |       | | |  |
                         |  | | |       | || |       | | |  |
                         |  | | |_______| || |_______| | |  |
                         |  | '-----------''-----------' |  |
                        _|__|/__________________________\|__|_
                       '----'----------------------------'----'
                      ");
      System.Console.WriteLine("Welcome to Escape the TARDIS! What is your name?");
      string name = Console.ReadLine();
      Player newPlayer = new Player(name);
      GameService app = new GameService(newPlayer);
      app.StartGame(); ;
    }

    public void Setup()
    {
      //--ROOMS--
      Room opening = new Room("Opening Scene", @"
                         N
                     _________
           	        |         |
                    | Library |
                    |         |
                  //|____  ___|\\
                 //      ||     \\
               //        ||       \\
             //          ||         \\
     _______//       ____||___       \\ _______
   |	       |      |         |      |         |
E  | Shelves |------| Console |------|   Hall  |  W
   |         |------|    X    |------|         |
   |________ |      |____  ___|      | ________|
            \\           ||          //
             \\          ||         //
               \\        ||       //
                 \\  ____||___  //
                  \\|         |//
                    |   Door  |
                    |         |
                    |_________|
                    
                          S
      Your head is spinning as your eyes slowly open. You are laying on the floor unsure of your surrounding. You slowly start to stand up and gradually your world begins to come into view. You're in the TARDIS; standing next to the console. Things are in disarray and in need of repair. You are unsure what happened, but you know you must get off the ship. You reach into your coat pocket for your trusty Sonic Screwdriver, but it is nowhere to be found. As you removed you hand from your pocket, you notice a small black line on your wrist, as if drawn by a marker. Panic sets in as you become aware of how severe the sitaution is. You must find you Sonic ASAP if you are going to get out of this alive.");
      Room console = new Room("Console", "The TARDIS console. It still seems to be functional, but barely. The viewscreen is lit up and you can see movement.");
      Room hall = new Room("Dark Hall", "You approach the hallway leading to the back fo the TARDIS. It is very dark with only a few sparks from loose wires. The closer you get though, a figure comes into view...");
      Room library = new Room("Library", "Your trusty deck library. Full of books and articfacts from previous adventures. Three distinct books are prominent on the middle shelf.");
      Room shelves = new Room("Shelves", "A display shelf of personal affects you use throughout your travels. Coats, a guitar, and something very familiar and red in a display case.");
      Room door = new Room("Door", "The bright blue front door to the TARDIS. The door unfortunately does not budge.");

      //--ITEMS--
      Item sonic = new Item("Sonic Screwdriver");
      Item fez = new Item("Fez");
      Item bookCyborg = new Item("Wild West Cyborg");
      Item bookPompei = new Item("Fires of Pompei");
      Item bookTime = new Item("End of Time");
      Item viewscreen = new Item("Viewscreen");

      //--ROOM RELATIONSHIPS--
      opening.Exits.Add("north", hall);
      opening.Exits.Add("south", shelves);
      opening.Exits.Add("west", library);
      opening.Exits.Add("east", door);
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

      CurrentRoom = opening;

      //--ITEM RELATIONSHIPS--
      library.Items.Add(bookCyborg);
      library.Items.Add(bookPompei);
      library.Items.Add(bookTime);
      library.Items.Add(sonic);
      console.Items.Add(sonic);
      console.Items.Add(viewscreen);
      shelves.Items.Add(fez);
    }

    public void StartGame()
    {
      while (Running)
      {
        Console.Clear();
        Console.WriteLine($"{CurrentRoom.Description}");
        GetUserInput();
        Inventory();
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