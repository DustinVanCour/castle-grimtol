using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;
using CastleGrimtol.Project.Models;

namespace CastleGrimtol.Project
{
  public class GameService : IGameService
  {
    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }

    public void GetUserInput()
    {
      ;
    }

    public void Go(string direction)
    {
      ;
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

    }

    public void StartGame()
    {
      ;
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