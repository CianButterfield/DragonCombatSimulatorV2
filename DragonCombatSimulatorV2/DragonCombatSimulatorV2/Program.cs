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

            //greet the user
            Greet();

            //start the game
            Game game = new Game();
            game.PlayGame();

            System.Threading.Thread.Sleep(2000);
        }

        static void Greet()
        {
            //greet the user, give instructions
            Console.WriteLine(@"Welcome to Dragon Slayer.

As the greatest hero in the land, you have been sent to slay the mighty dragon.

You have three options per turn: Sword, Magic, and Heal.
    Your sword deals the most damage but sometimes misses.
    Your magic always hits but does less damage.
    You may use heal to recover some health.

(Press any key to continue)");

            //wait for user to hit a key
            Console.ReadKey();

            //clear the screen for the begining of the game
            Console.Clear();

        }

        
    }
}
