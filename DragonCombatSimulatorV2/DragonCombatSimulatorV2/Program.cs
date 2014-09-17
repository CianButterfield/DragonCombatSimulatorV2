using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonCombatSimulatorV2
{
    class Program
    {
     

        static void Main(string[] args)
        {
            //change the console window title to "Dragon Slayer"
            Console.Title = "Dragon Slayer";

            //start the game
            Game game = new Game();
            game.PlayGame();
        }

        

        
    }
}
