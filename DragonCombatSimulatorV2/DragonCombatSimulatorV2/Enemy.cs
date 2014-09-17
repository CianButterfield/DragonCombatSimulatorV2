using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonCombatSimulatorV2
{
    class Enemy
    {
        //properties
        public int HP { get; set; }
        public string Name { get; set; }
        public bool IsAlive { get { return HP > 0; } }

        //constructor
        public Enemy(string name, int health)
        {
            this.HP = health;
            this.Name = name;
        }

        //methods and functions
        public int DoAttack()
        {
            //make a random num gen
            Random randNum = new Random();

            //tell the user that it is the dragons turn
            Console.WriteLine("\nThe dragon goes for an attack.");

            //check if the dragon hits
            int hitChance = randNum.Next(1, 101);
            if (hitChance > 20)
            {
                //the dragon hits
                //calculate dragons damage
                int damage = randNum.Next(5, 16);
                Console.WriteLine("The dragon hits you for " + damage + " damage.");
                return damage;
            }
            else
            {
                //the dragon misses
                Console.WriteLine("The dragon misses you, this time.");
                return 0;
            }
        }

        public void TakeDamage(int damage)
        {
            this.HP -= damage;
            if (HP <= 0)
            {
                Console.WriteLine("You have slain the dragon, good job.");
            }
        }
    }
}
