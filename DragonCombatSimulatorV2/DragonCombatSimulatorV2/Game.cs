using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonCombatSimulatorV2
{
    class Game
    {
        //properties
        public Enemy Enemy { get; set; }
        public Player Player { get; set; }

        //constructor
        public Game()
        {
            this.Enemy = new Enemy("Bob", 200);
            this.Player = new Player(100);
        }

        //methods and functions
        public void DisplayCombatInfo()
        {
            Console.WriteLine("Player HP: " + this.Player.HP + "\nDragon HP: " + this.Enemy.HP);
            
        
            //updates the screen each turn
            Console.Title = "Dragon Slayer   Dragon Health: " + this.Enemy.HP + "   Player Health: " + this.Player.HP;
        }
        

        public void PlayGame()
        {
            //play until the game is over
            while (this.Player.IsAlive&&this.Enemy.IsAlive)
            {
                DisplayCombatInfo();
                this.Enemy.TakeDamage(this.Player.DoAttack());
                this.Player.TakeDamage(this.Enemy.DoAttack());
            }
            if (this.Player.IsAlive)
            {
                Console.WriteLine("You won!");
            }
            else
            {
                Console.WriteLine("You lost!");
            }
        }


    }
}
