using System;


namespace Ass3
{
    public class Player
    {
        private int health;
        private int score;

        public Player(int health, int score)
        {
            this.health = health;
            this.score = score;
        }

        public Player(int health)
        {
            this.health = health;
            this.score = 0;
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            set
            {
                this.health = value;
            }
        }

        public int Score
        {
            get
            {
                return this.score;
            }
            set
            {
                this.score = value;
            }
        }


    }

    public class Program
    {
        public static void Main(String[] args)
        {
            Program pro = new Program();
            pro.PlayGame(new Player(100), new Player(100));
        }
        public void PlayGame(Player user, Player ai)
        {
            char playAgain;
            int result, min = 1, max = 1;


            do{
                do{
                    Console.WriteLine(HealthString(user, ai));
                    Console.Write("Choice -> ");
                    result = PlayRound(Console.ReadLine(), GenOppChoice());
                    DealDamage(result, user, ai);
                    Console.WriteLine();
                }while(user.Health > 0 && ai.Health > 0);
                GivePoint(user, ai);
                Console.WriteLine(ScoreString(user, ai));
                ResetHealth(user, ai);
                var temp = BestOutOf(min, max, user, ai);
                min = temp.returnMin;
                max = temp.returnMax;
                Console.Write("Do you wish to play again? -> ");
                playAgain = Console.ReadKey().KeyChar;
                Console.WriteLine(Environment.NewLine);
            }while(playAgain == 'y');
            Console.WriteLine(DeclareWinner(user, ai));
        }

        public (int returnMin, int returnMax) BestOutOf(int min, int max, Player user, Player ai)
        {
            if(user.Score >= min || ai.Score >= min)
            {
                min++;
                max+=2;
                Console.WriteLine($"Best {min} out of {max}?");
            }
            return (min, max);
        }

        public String GenOppChoice()
        {
            Random t = new Random();
            
            switch(t.Next(1,4))
            {
                case 1:
                    return "paper";
                case 2:
                    return "rock";
                default:
                    return "scissors";
            }
        } 

        public int PlayRound(String human, String ai)//guranteed to be correct word, so I just chose to check first letter incase of mispelling.
        {
            Console.Write($"User choice: {human} vs AI choice: {ai} {Environment.NewLine}");
            if(human != ai)//3 choose 2 ways: 3 to win, 3 to lose, 3 to tie
            {
                if(human[0] == 'r' && ai[0] == 'p')
                {
                    return -10;
                }//SOP the results and damage taken
                else if(human[0] == 'p' && ai[0] == 's')
                {
                    return -15;
                }
                else if(human[0] == 's' && ai[0] == 'r') 
                {
                    return -20;
                }
                if(human[0] == 'p' && ai[0] == 'r')
                {
                    return 10;
                }
                else if(human[0] == 's' && ai[0] == 'p')
                {
                    return 15;
                }
                else if(human[0] == 'r' && ai[0] == 's')
                {
                    return 20;
                }            
            }
            return 0;
        }

        public void GivePoint(Player user, Player ai)
        {
            if(user.Health <= 0)
            {
                ai.Score = (ai.Score + 1);
            }
            else if(ai.Health <= 0)
            {
                user.Score = (user.Score + 1);
            }
        }

        public void ResetHealth(Player user, Player ai)
        {
            user.Health = 100;
            ai.Health = 100;
        }

        public void DealDamage(int value, Player user, Player ai)
        {
            int curHealth = 0;
            if(value < 0)
            {
                Console.WriteLine("Opponent Won Round!");
                curHealth = user.Health;
                user.Health = curHealth + value;
            }
            else if(value > 0)
            {
                Console.WriteLine("User Won Round!");
                curHealth = ai.Health;
                ai.Health = curHealth - value;
            }
            else
            {
                Console.WriteLine("Round Tie!");
            }
        }

        public String HealthString(Player user, Player ai)
        {
            return $"User Health: {user.Health} | AI Health: {ai.Health}";
        }

        public String ScoreString(Player user, Player ai)
        {
            return $"User Score: {user.Score} AI Score {ai.Score}";
        }

        public String DeclareWinner(Player user, Player ai)
        {
            if(user.Score > ai.Score)
            {
                return "User Won the Game!!!";
            }
            else if(user.Score < ai.Score)
            {
                return "AI Won the Game!!!";
            }
            else
            {
                return "The Two Opponents Agreed on a Tie!!!";
            }
        }
    }
}