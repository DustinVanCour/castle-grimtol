using System;
using CastleGrimtol.Project;

namespace CastleGrimtol
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Console.Clear();
      System.Console.WriteLine("Welcome to Escape the TARDIS! What is your name?");
      string name = Console.ReadLine();
      GameService app = new GameService(name);
      app.StartGame();
    }
  }
}
