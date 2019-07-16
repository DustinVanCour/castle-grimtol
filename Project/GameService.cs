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
      CurrentPlayer = player;
      Setup();
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
        case "go": //WORKS
          Go(choice);
          Look();
          break;

        case "inventory": //WORKS
          Inventory();
          break;

        case "help": //WORKS
          Help();
          break;

        case "look": //WORKS
          Look();
          break;

        case "quit": //WORKS
          Quit();
          break;

        case "reset": //WORKS
          Reset();
          break;

        case "take":  //WORKS
          TakeItem(choice);
          break;

        case "use":
          UseItem(choice);
          break;

        default: //WORKS
          Console.WriteLine("Invalid Input. Try Again. Or type HELP.");
          break;
      }
    }

    public void Go(string direction)
    {
      Console.Clear();
      if (CurrentRoom.Exits.ContainsKey(direction))
      {
        CurrentRoom = (Room)CurrentRoom.Exits[direction];
      }
      else
      {
        Console.WriteLine("");
        Console.WriteLine("Invalid Direction. Please choose a different direction.");
        Thread.Sleep(2000);
      };
    }

    public void Help()
    {
      Console.WriteLine("");
      Console.WriteLine("Available Exits (Use -go- Command): ");
      foreach (var exit in CurrentRoom.Exits)
      {
        Console.WriteLine(exit.Key);
      }
      if (CurrentPlayer.Inventory.Count == 0)
      {
        Console.WriteLine("");
        Console.WriteLine("Available Inventory (Use -use- Command):");
        Console.WriteLine("Your Inventory is currently empty.");
      }
      else
      {
        Console.WriteLine("");
        Console.WriteLine("Available Inventory (Use -use- Command):");
        int count = 1;
        foreach (var item in CurrentPlayer.Inventory)
        {
          Console.WriteLine($"{count}) {item.Description}");
          count++;
        }
      }
    }

    public void Inventory()
    {
      if (CurrentPlayer.Inventory.Count == 0)
      {
        Console.WriteLine("");
        Console.WriteLine("Your Inventory is currently empty.");
      }
      else
      {
        Console.WriteLine("");
        Console.WriteLine("INVENTORY:");
        int count = 1;
        foreach (var item in CurrentPlayer.Inventory)
        {
          Console.WriteLine($"{count}) {item.Description}");
          count++;
        }
      }
    }

    public void Look()
    {
      Console.Clear();
      Console.WriteLine(CurrentRoom.Description);
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
                    |  Hall   |
                    |         |
                  //|____  ___|\\
                 //      ||     \\
               //        ||       \\
             //          ||         \\
     _______//       ____||___       \\ _______
   |         |      |         |      |         |
W  | Library |------| Console |------|   Door  |  E
   |         |------|    X    |------|         |
   |________ |      |____  ___|      | ________|
            \\           ||          //
             \\          ||         //
               \\        ||       //
                 \\  ____||___  //
                  \\|         |//
                    | Shelves |
                    |         |
                    |_________|
                    
                        S

      Your head is spinning as your eyes slowly open. You are laying on the floor unsure of your surroundings. You slowly start to stand up and gradually your world begins to come into view. You're in the TARDIS; standing next to the console. Things are in disarray and in need of repair. You are unsure what happened, but you know you must get off the ship. You reach into your coat pocket for your trusty Sonic Screwdriver, but it is nowhere to be found. As you removed you hand from your pocket, you notice a small black line on your wrist, as if drawn by a marker. Panic sets in as you become aware of how severe the sitaution is. You must find you Sonic ASAP if you are going to get out of this alive.");
      Room console = new Room("Console", @"
                         N
                     _________
                    |         |
                    |  Hall   |
                    |         |
                  //|____  ___|\\
                 //      ||     \\
               //        ||       \\
             //          ||         \\
     _______//       ____||___       \\ _______
   |         |      |         |      |         |
W  | Library |------| Console |------|   Door  |  E
   |         |------|    X    |------|         |
   |________ |      |____  ___|      | ________|
            \\           ||          //
             \\          ||         //
               \\        ||       //
                 \\  ____||___  //
                  \\|         |//
                    | Shelves |
                    |         |
                    |_________|
                    
                        S

      The TARDIS console. It still seems to be functional, but barely. The viewscreen is lit up and you can see movement.");
      Room hall = new Room("Dark Hall", "You approach the hallway leading to the back fo the TARDIS. It is very dark with only a few sparks from loose wires. The closer you get though, a figure comes into view...");
      Room library = new Room("Library", @"
                         N
                     _________
                    |         |
                    |  Hall   |
                    |         |
                  //|____  ___|\\
                 //      ||     \\
               //        ||       \\
             //          ||         \\
     _______//       ____||___       \\ _______
   |         |      |         |      |         |
W  | Library |------| Console |------|   Door  |  E
   |    X    |------|         |------|         |
   |________ |      |____  ___|      | ________|
            \\           ||          //
             \\          ||         //
               \\        ||       //
                 \\  ____||___  //
                  \\|         |//
                    | Shelves |
                    |         |
                    |_________|
                    
                        S

      Your trusty deck library. Full of books and articfacts from previous adventures. Three distinct books are prominent on the middle shelf.");
      Room shelves = new Room("Shelves", @"
                         N
                     _________
                    |         |
                    |  Hall   |
                    |         |
                  //|____  ___|\\
                 //      ||     \\
               //        ||       \\
             //          ||         \\
     _______//       ____||___       \\ _______
   |         |      |         |      |         |
W  | Library |------| Console |------|   Door  |  E
   |         |------|         |------|         |
   |________ |      |____  ___|      | ________|
            \\           ||          //
             \\          ||         //
               \\        ||       //
                 \\  ____||___  //
                  \\|         |//
                    | Shelves |
                    |    X    |
                    |_________|
                    
                         S

      A display shelf of personal affects you use throughout your travels. Coats, a guitar, and something very familiar and red in a display case.");
      Room door = new Room("Door", @"
                         N
                     _________
                    |         |
                    |  Hall   |
                    |         |
                  //|____  ___|\\
                 //      ||     \\
               //        ||       \\
             //          ||         \\
     _______//       ____||___       \\ _______
   |         |      |         |      |         |
W  | Library |------| Console |------|   Door  |  E
   |         |------|         |------|    X    |
   |________ |      |____  ___|      | ________|
            \\           ||          //
             \\          ||         //
               \\        ||       //
                 \\  ____||___  //
                  \\|         |//
                    | Shelves |
                    |         |
                    |_________|
                    
                         S

      The bright blue front door to the TARDIS. The door unfortunately does not budge.");
      Room finalRoom = new Room("Final Room", "The door now opens wide for you to use. Outside, Amy and Rory and waiting for you. They embrace you tightly with a sigh of relief. YOU WIN!!!");

      //--ITEMS--
      Item sonic = new Item("sonic", "Sonic Screwdriver");
      Item fez = new Item("fez", "Fez");
      Item bookCyborg = new Item("book-cyborg", "Book: Wild West Cyborg");
      Book bookPompei = new Book("book-pompei", "Book: Fires of Pompei", sonic);
      Item bookTime = new Item("book-time", "Book: End of Time");

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
      shelves.Items.Add(fez);

      StartGame();
    }

    public void StartGame()
    {
      Look();
      while (Running)
      {
        GetUserInput();
      }
    }

    public void TakeItem(string itemName)
    {
      Item itemToTake = CurrentRoom.Items.Find(item => item.Name == itemName);
      if (itemToTake is null)
      {
        Console.WriteLine("No Items to Take.");
      }
      else
      {
        CurrentPlayer.Inventory.Add(itemToTake);
        CurrentRoom.Items.Remove(itemToTake);
      }
    }

    public void UseItem(string itemName)
    {
      Item itemToUse = CurrentPlayer.Inventory.Find(item => item.Name == itemName);
      Room roomToUse = CurrentRoom;
      if (itemToUse is null)
      {
        Console.WriteLine("Cannot use this item here.");
      }

      if (itemToUse is Book)
      {
        CurrentPlayer.Inventory.Remove(itemToUse);
        Book b = (Book)itemToUse;
        CurrentPlayer.Inventory.Add(b.Contents);
        Console.WriteLine("A green glow starts to permiate from the pages. As you open the book, you remember you hid your backup Sonic here. Hope fills your two hearts as you tuck it away into your coat pocket.");
      }


      if (itemToUse.Name == "book-time")
      {
        EndGame1();
      }

      if (itemToUse.Name == "fez")
      {
        Console.WriteLine("");
        CurrentPlayer.Inventory.Remove(itemToUse);
        Console.WriteLine("You put your fez on your head. Fezzes are Cool!");
      }
      {
        if (itemToUse.Name == "sonic")
        {
          UseSonic(itemName);
        }
      }

      // if (itemToUse.Name == "sonic" && roomToUse.Name == "console")
      // {
      //   Console.WriteLine("");
      //   Console.WriteLine("You pull your Sonic Screwdriver from your coat pocket and aim at the damaged portion of the Console. Wires start coming back together and the console lights up. In the near distance you hear the DOOR of the TARDIS click.");
      // }
      // else
      // {
      //   Console.WriteLine("");
      //   Console.WriteLine("You pull your Sonic Screwdriver from your coat pocket and press the switch. It whirs, buzzes, and lights up green, but nothing changes. You put it back in your coat pocket.");
      // }

      //find item from currentplayer.inventory where item.name == itemName **
      //null check **
      //try to find from room.items ---Not Using Currently ---
      //if still null then prompt failure
      // if item is Book
      //if book.name == 'endoftime'
      //EndGame1()
      //if book.name == 'pompei'
      //Book b = (book)item
      //player.inventory.add(b.contents)
      //player.inventory.remove(item)
    }

    public void UseSonic(string itemName)
    {
      Item itemToUse = CurrentPlayer.Inventory.Find(item => item.Name == itemName);
      if (itemToUse is null)
      {
        Console.WriteLine("Cannot use this here.");
      }
      if (itemToUse.Name == "sonic" && CurrentRoom.Name == "Console")
      {
        CurrentRoom.Items.Add(itemToUse);
        Console.WriteLine("");
        Console.WriteLine("You pull your Sonic Screwdriver from your coat pocket and aim at the damaged portion of the Console. Wires start coming back together and the console lights up. In the near distance you hear the DOOR of the TARDIS click.");
      }
      else
      {
        Console.WriteLine("");
        Console.WriteLine("You pull your Sonic Screwdriver from your coat pocket and press the switch. It whirs, buzzes, and lights up green, but nothing changes. You put it back in your coat pocket.");
      }
    }
    public void EndGame1()
    {
      Console.Clear();
      Console.WriteLine("A book called END OF TIME lies in your hands. As you thumb through it, you read about your prior incarnation's jouney's through time and space and how it all came to your turn. As you close the back cover a plume of dust wafts across your face. You start a sneeze and as you look down at the back cover of the book, you see an embossed angel statue. And for a split moment, as your eyes start to shut, you swear you saw it move. You let out a mighty sneeze and when you eyes open back up, the environemt has changed. Trees and grassland surround the area and the atmosphere is thick with moisture. In the near distance a Tyranasaurus Rex breaks through the tree line making a beeline for you. In a panic, you toss the book the ground and RUN!");
      Environment.Exit(-1);
    }

    public void WinGame(string room)
    {
      // Room ConsoleFixed = inalRoom.Items.Find(item => item.Name == itemName);
      // {
      if (CurrentRoom.Name == "Door")
      {
        ;
      }
    }
  }
}