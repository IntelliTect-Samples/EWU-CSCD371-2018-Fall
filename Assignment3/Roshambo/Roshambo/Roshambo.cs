using System;

namespace Roshambo
{
    public class Roshambo
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("<<Welcome to Roshambo>>\n");
            string endGame = "";

            do
            {
                endGame = "";
                PlayGame();

                Console.Write("\nPlay Again? (y/n)\n" +
                    "-->");

                while (endGame != "n" && endGame != "N" && endGame != "y" && endGame != "Y")
                {
                    endGame = Console.ReadLine();
                    if(endGame != "n" && endGame != "N" && endGame != "y" && endGame != "Y")
                    {
                        Console.Write("\nPlease enter a valid answer...(y/n)\n" +
                            "-->");
                    }
                }
            } while (endGame != "n" && endGame != "N");
        }

        public static void PlayGame()
        {
            int userLifePoints = 100;
            int AI_LifePoints = 100;

            do
            {

                string userInput = userMoveChoice();

                var userAI_LifePoints = determineDamage(userInput, userLifePoints, AI_LifePoints); //Item1 is userLife - Item2 is AI_Life
                userLifePoints = userAI_LifePoints.Item1;
                AI_LifePoints = userAI_LifePoints.Item2;
                

                Console.WriteLine($"User Life Points: {userLifePoints}    AI Life Points: {AI_LifePoints}");
            } while (userLifePoints > 0 && AI_LifePoints > 0);

            if(userLifePoints <= 0)
            {
                Console.WriteLine("\n*----------*\n  AI Wins!\n*----------*\n");
            }
            else if(AI_LifePoints <= 0)
            {
                Console.WriteLine("\n*----------*\n User Wins!\n*----------*\n");
            }
        }

        public static string userMoveChoice()
        {
            Console.Write("\nSelect your move (Rock/Paper/Scissors)\n-->");
            string userInput = Console.ReadLine();

            while (userInput.ToLower() != "rock" && userInput.ToLower() != "paper" && userInput.ToLower() != "scissors")
            {
                Console.Write("\nInvalid Move, try again...(Rock/Paper/Scissors)\n" +
                    "-->");
                userInput = Console.ReadLine();
            }

            Console.WriteLine("\n");

            return "userInput";
        }

        public static (int, int) determineDamage(string userInput, int userLifePoints, int AI_LifePoints)
        {
            Random randomNumber = new Random();

            switch (randomNumber.Next() % 3)
            {
                case 0:
                    if (userInput.ToLower() == "scissors")
                    {
                        userLifePoints -= 20;
                    }

                    else if (userInput.ToLower() == "paper")
                    {
                        AI_LifePoints -= 10;
                    }

                    Console.WriteLine($"AI: Rock   {randomNumber.Next() % 3}\nUser: {userInput}");
                    break;

                case 1:
                    if (userInput.ToLower() == "rock")
                    {
                        AI_LifePoints -= 20;
                    }

                    else if (userInput.ToLower() == "paper")
                    {
                        userLifePoints -= 15;
                    }

                    Console.WriteLine($"AI: Scissors    {randomNumber.Next() % 3}\nUser: {userInput}");
                    break;
                case 2:
                    if (userInput.ToLower() == "rock")
                    {
                        userLifePoints -= 10;
                    }

                    else if (userInput.ToLower() == "scissors")
                    {
                        AI_LifePoints -= 15;
                    }

                    Console.WriteLine($"AI: Paper    {randomNumber.Next() % 3}\nUser: {userInput}");
                    break;
            }
            return (userLifePoints, AI_LifePoints);
        }
    }
}