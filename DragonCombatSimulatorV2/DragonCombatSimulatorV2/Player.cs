using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonCombatSimulatorV2
{
    enum AttackType
    {
        Sword, Magic, Heal
    }
    class Player
    {
        //propertis
        public int HP { get; set; }
        public bool IsAlive { get { return HP > 0; } }

        //constructor
        public Player(int health)
        {
            this.HP = health;
        }

        //methods and functions
        public int DoAttack()
        {
            //get user input
            AttackType attackType = ChooseAttack();

            //make a random num gen
            Random randNum = new Random();

            if (attackType == AttackType.Sword)
            {
                //use sword
                //check if the user hits
                int hitChance = randNum.Next(1, 101);
                if (hitChance > 30)
                {
                    //user hits
                    int damage = randNum.Next(20, 36);
                    Console.WriteLine("You hit the dragon with your sword for " + damage + " damage.\n");
                    return damage;
                }
                else
                {
                    //user misses
                    Console.WriteLine("You miss the dragon.\n");
                    return 0;
                }
            }
            if (attackType == AttackType.Magic)
            {
                //use magic
                int damage = randNum.Next(10, 16);
                Console.WriteLine("You fling your death magic at the dragon and deal " + damage + " damage to it.\n");
                return damage;
            }
            if (attackType == AttackType.Heal)
            {
                //use heal
                int healNum = randNum.Next(10, 21);
                HP += healNum;
                Console.WriteLine("You use your healing magic to restore yourself, you now have " + HP + " health.\n");
                return 0;
            }
            else
            {
                return 0;
            }
        }

        private AttackType ChooseAttack()
        {
            //takes the user's input and processes it

            //ask the user what they would like to do
            Console.WriteLine("\n\nWhat would you like to use? (Please type 1 2 or 3)\n1: Sword   2: Magic   3: Heal");

            //take the users input and store it
            string input = string.Empty;
            input = Console.ReadLine().ToLower();

            //clear the console screen after user input
            Console.Clear();

            //determine what to do

            if (input == "1" || input == "sword" || input == "s" || input == "one")
            {
                //use sword
                return AttackType.Sword;
            }
            else if (input == "2" || input == "magic" || input == "m" || input == "two")
            {
                return AttackType.Magic;
            }
            else if (input == "3" || input == "heal" || input == "h" || input == "three")
            {
                return AttackType.Heal;
            }
            else
            {
                return AttackType.Sword;
            }
            
        }

        public void TakeDamage(int damage)
        {
            this.HP -= damage;
            if (HP <= 0)
            {
                Console.WriteLine("\nFatality!!!\nYou have been killed by the dragon.");
            }
        }
    }
}
