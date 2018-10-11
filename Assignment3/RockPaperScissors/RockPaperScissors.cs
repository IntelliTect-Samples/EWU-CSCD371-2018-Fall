using System;

namespace RockPaperScissors
{
    public class RockPaperScissors
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Rock Paper Scissors!\nInput Ex.: \"rock\", \"r\"");

            do
            {
                (int userHealth, int cpuHealth) playersHealth = (100, 100);
                do
                {
                    (string userMove, string cpuMove) roundMoves = (GetUserMove(), GetCpuMove());
                    
                    Console.WriteLine($"Computer played {roundMoves.cpuMove}");

                    playersHealth = UpdateHealth(roundMoves , CalculateDamageDealt(roundMoves), playersHealth);
                    Console.WriteLine($"Your health: {playersHealth.userHealth}\nComputer health: {playersHealth.cpuHealth}");

                } while (IsGameOver(playersHealth));

                var results = playersHealth.userHealth == 0 ? "lost" : "won";
                Console.WriteLine($"You {results}!\n");
            } while (!PlayAgain());
            Console.WriteLine("Goodbye...");
        }

        

        public static string GetUserMove()
        {
            Console.Write("\nThree. Two. One. Shoot!: ");
            var userInput = Console.ReadLine().Trim().ToLower();
            
            if (userInput.Equals("rock") || userInput.Equals("r"))
                return "rock";
            if (userInput.Equals("paper") || userInput.Equals("p"))
                return "paper";
            if(userInput.Equals("scissors") || userInput.Equals("s"))
                return "scissors";
         
            Console.WriteLine("Invalid input");
            return GetUserMove();
        }
        
        
        public static string GetCpuMove()
        {
            var randInt = new Random().Next(89);
            if (randInt < 30)
                return "rock";
            if (randInt < 60)
                return "paper";
            return "scissors";
        }
        

        //Updates the round loser's health, and displays to the user the event
        public static (int userHealth, int cpuHealth) UpdateHealth((string userMove, string cpuMove) roundMoves ,int damageDealt, (int userHealth, int cpuHealth) playersHealth)
        {
            if(damageDealt == 0)
                Console.WriteLine("Round draw! No damage dealt.");
            else if (damageDealt > 0)
            {
                Console.WriteLine($"{roundMoves.userMove} causes {damageDealt} damage to the computer.");
                playersHealth.cpuHealth = playersHealth.cpuHealth < damageDealt ? 0 : playersHealth.cpuHealth -= damageDealt;        //if computer has negative health, set to 0
            }
            else{
                Console.WriteLine($"{roundMoves.cpuMove} causes {damageDealt * -1} damage to you.");
                playersHealth.userHealth = playersHealth.userHealth < damageDealt * -1 ? 0 : playersHealth.userHealth += damageDealt;                //if user has negative health, set to 0
            }
            return playersHealth;
        }
        
        
        //Calculates winner and returns damage dealt. If positive, the user won, if negative, the computer won
        public static int CalculateDamageDealt((string userMove, string cpuMove) roundMoves)
        {
            if (roundMoves.userMove.Equals(roundMoves.cpuMove))
                return 0;
            switch (roundMoves.userMove)
            {
                //if user = rock, since they are already not equal, if cpu throws scissors, user wins, else cpu wins
                case "rock":
                    return roundMoves.cpuMove.Equals("scissors") ? 20 : -10; 
                case "paper":
                    return roundMoves.cpuMove.Equals("rock") ? 10 : -15; 
                case "scissors":
                    return roundMoves.cpuMove.Equals("paper") ? 15 : -20; 
                default:
                    throw new Exception("A terrible mistake has been made.");
            }    
        }


        public static bool IsGameOver((int userHealth, int cpuHealth) playersHealth)
        {
            return !(playersHealth.userHealth > 0 && playersHealth.cpuHealth > 0);
        }
        

        public static bool PlayAgain()
        {
            Console.Write("Would you like to play another game? [y][n]: ");;
            var userInput = Console.ReadLine().Trim().ToLower();
            
            if (userInput.Equals("yes") || userInput.Equals("y"))
                return true;
            if (userInput.Equals("no") || userInput.Equals("n"))
                return false;
         
            Console.WriteLine("Invalid input");
            return PlayAgain();
        }
    }
}