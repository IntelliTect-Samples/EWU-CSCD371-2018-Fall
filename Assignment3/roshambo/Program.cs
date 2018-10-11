using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace roshambo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int playerOneHealthPoints = 100;
            int playerTwoHealthPoints = 100;

            bool continuePlay = true;

            while (continuePlay)
            {
                while (playerOneHealthPoints > 0 && playerTwoHealthPoints > 0)
                {
                    Console.Write("Enter your move (rock, paper, scissors): ");
                    string playerOneMove = Console.ReadLine();
                    string computerMove = GetComputerMove();
                    
                    Console.WriteLine($"Player one played {playerOneMove} and computer played {computerMove}");
                    
                    (string loser, int healthDeduction) lastRoundResults = CalculateRoundLoser(playerOneMove, computerMove);

                    if (lastRoundResults.loser.Equals("tie"))
                    {
                        Console.WriteLine("There was a tie!");
                    }
                    else
                    {
                        Console.WriteLine($"{lastRoundResults.loser} lost the round!");
                    }

                    if (lastRoundResults.loser.Equals("PlayerOne"))
                    {
                        playerOneHealthPoints -= lastRoundResults.healthDeduction;
                    }
                    else if(lastRoundResults.loser.Equals("PlayerTwo"))
                    {
                        playerTwoHealthPoints -= lastRoundResults.healthDeduction;
                    }
                    
                    Console.WriteLine($"Player has {playerOneHealthPoints} health points and computer has " +
                                      $"{playerTwoHealthPoints} health points");
                }
                
                string winner = (playerOneHealthPoints > playerTwoHealthPoints) ? "player one" : "player two";
                Console.Write($"{winner} wins! Press 'y' to play again or 'n' to quit!: ");

                switch (Console.ReadLine().Trim())
                {
                       case "y":
                           continuePlay = true;
                           playerOneHealthPoints = 100;
                           playerTwoHealthPoints = 100;
                           break;
                       case "n":
                           continuePlay = false;
                           break;
                }
            }
        }

        /// <summary>
        /// Given playerOneMove and playerTwoMove return the loser of the round and the number of health points
        /// to deduct. Throws InvalidDataException is data does not evaluate to a valid move
        /// </summary>
        /// <param name="playerOneMove">Move of the first player. Valid values: rock, paper, scissors</param>
        /// <param name="playerTwoMove">Move of the second player. Valid values: rock, paper, scissors</param>
        /// <returns>"PlayerOne" if playerOne is the winner. "PlayerTwo" is playerTwo is the winner
        /// "tie" if there is no winner.</returns>
        public static (string, int) CalculateRoundLoser(string playerOneMove, string playerTwoMove)
        {
            string playerOneMoveLower = playerOneMove.ToLower();
            string playerTwoMoveLower = playerTwoMove.ToLower();

            bool swap = false; // if the moves for playerOne and playerTwo have been reversed
            
            if (!playerOneMoveLower.Equals(playerTwoMoveLower))
            {
                while (true)
                {
                    switch (playerOneMoveLower)
                    {
                        case "rock": // 20 points
                            if (playerTwoMoveLower.Equals("scissors"))
                            {
                                int pointsVal = 20;
                                return (swap) ? ("PlayerTwo", pointsVal) : ("PlayerOne", pointsVal);
                            }
                            break;
                        case "paper": // 10 points
                            if (playerTwoMoveLower.Equals("rock"))
                            {
                                int pointsVal = 10;
                                return (swap) ? ("PlayerTwo", pointsVal) : ("PlayerOne", pointsVal);
                            }
                            break;
                        case "scissors": // 15 points
                            if (playerTwoMoveLower.Equals("paper"))
                            {
                                int pointsVal = 15;
                                return (swap) ? ("PlayerTwo", pointsVal) : ("PlayerOne", pointsVal);
                            }
                            break;
                        default:
                            throw new InvalidDataException($"{playerOneMoveLower} is not a valid move");
                    }
                    
                    string temp = playerTwoMoveLower;
                    playerTwoMoveLower = playerOneMoveLower;
                    playerOneMoveLower = temp;
                    swap = true;
                }
            }
            else
            {
                return ("tie", 0);
            }
        }

        /// <summary>
        /// Randomly calculates computers move.
        /// </summary>
        /// <returns>Random value of "rock", "paper", or "scissors"</returns>
        public static string GetComputerMove()
        {
            List<string> testList = new List<string>{"rock", "paper", "scissors"};
            Random rand = new Random();
            int indexOfRandomElement = rand.Next(testList.Count);
            return testList[indexOfRandomElement];
        }
    }
}