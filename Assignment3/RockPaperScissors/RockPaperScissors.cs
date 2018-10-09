using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace RockPaperScissors
{
    class RockPaperScissors
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Rock Paper Scissors!\nInput Ex.: \"rock\", \"r\"\n");

            do
            {
                var userHealth = 100;
                var computerHealth = 100;
                do
                {
                    var userMove = GetUserMove();
                    var computerMove = GetComputerMove();
                    
                    Console.WriteLine($"You played {userMove}"); 
                    Console.WriteLine($"Computer played {computerMove}");

                  
                    var winner = GetRoundWinner(userMove, computerMove);
                    
                    

                } while (userHealth > 0 && computerHealth > 0);
            } while (PlayAgain());
        }


        public static int GetRoundWinner(string userMove, string computerMove)
        {
            if (userMove.Equals(computerMove))
                return 0;
            switch (userMove)
            {
                case "rock":
                    return computerMove.Equals("scissors") ? 1 : -1; 
                case "paper":
                    return computerMove.Equals("rock") ? 1 : -1; 
                case "scissors":
                    return computerMove.Equals("paper") ? 1 : -1; 
                default:
                    throw new Exception("A terrible mistake has been made.");
            }    
        }
        

        public static bool PlayAgain()
        {
            Console.Write("Would you like to play another game? [y][n]: ");
            return false;
        }
        

        public static string GetUserMove()
        {
            Console.Write("Three. Two. One. Shoot!: ");
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
        
        public static string GetComputerMove()
        {
            var randInt = new Random().Next(3);
            if (randInt < 1)
                return "rock";
            if (randInt < 2)
                return "paper";
            return "scissors";
        }
        
        
    }
}