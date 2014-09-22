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
        private void Greet()
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

        public void DisplayCombatInfo()
        {
            Console.WriteLine("Player HP: " + this.Player.HP + "\nDragon HP: " + this.Enemy.HP);
            
        
            //updates the screen each turn
            Console.Title = "Dragon Slayer   Dragon Health: " + this.Enemy.HP + "   Player Health: " + this.Player.HP;
        }
        

        public void PlayGame()
        {
            //greet the user
            Greet();

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

                //give the user a moment to read
                System.Threading.Thread.Sleep(3000);
                //add high score
                AddHighScore(this.Player.HP);
                //display highscores
                DisplayHighScores();

            }
            else
            {
                Console.WriteLine("You lost!");
            }
            Console.ReadLine();
        }


        public void AddHighScore(int playerScore)
        {
            Console.Clear();

            //get player name for high score
            Console.Write("Your name: "); string playerName = Console.ReadLine();

            //create a gateway to the database
            CianEntities db = new CianEntities();

            //create a new high score object
            // fill it with our user's data
            HighScore newHighScore = new HighScore();
            newHighScore.DateCreated = DateTime.Now;
            newHighScore.Game = "Dragon Slayer V2";
            newHighScore.Name = playerName;
            newHighScore.Score = playerScore;

            //add it to the database
            db.HighScores.Add(newHighScore);

            //save our changes
            db.SaveChanges();
        }

        public void DisplayHighScores()
        {
            //clear the console
            Console.Clear();
            Console.Title = "ΦDragon Slayer V2 ScoresΦ";
            Console.WriteLine("Dragon Slayer V2 Scores");
            Console.WriteLine("≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡");

            //create a new connection to the database
            CianEntities db = new CianEntities();
            //get the high score list
            List<HighScore> highScoreList = db.HighScores.Where(x => x.Game == "Dragon Slayer V2").OrderByDescending(x => x.Score).Take(10).ToList();

            foreach (HighScore highScore in highScoreList)
            {
                Console.WriteLine("{0}. {1} - {2}", highScoreList.IndexOf(highScore) + 1, highScore.Name, highScore.Score);
            }
            Console.ReadKey();
        }
    }
}
