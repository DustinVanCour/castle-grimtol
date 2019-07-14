using System;
using CastleGrimtol.Project;
using CastleGrimtol.Project.Models;

namespace CastleGrimtol
{
  public class Program
  {
    public static void Main(string[] args)
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
                      ");
      System.Console.WriteLine("Welcome to Escape the TARDIS! What is your name?");
      string name = Console.ReadLine();
      Player newPlayer = new Player(name);
      GameService app = new GameService(newPlayer);
      app.StartGame();
    }
  }
}
