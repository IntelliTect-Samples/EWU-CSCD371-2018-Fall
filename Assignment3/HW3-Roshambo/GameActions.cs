using System;
using System.Collections.Generic;
using System.Text;

namespace HW3_Roshambo
{
    public class GameActions
    {
        private string winnerIs;

        public void DetermineRoundWinner(Player human, Player computer)
        {
            string humanPickedWeapon = human.getWeaponPicked();
            string computerPickedWeapon = computer.getWeaponPicked();

            if(humanPickedWeapon == computerPickedWeapon)
                winnerIs = "tie";
            else if (humanPickedWeapon == "rock")
            {
                if (computerPickedWeapon == "scissors")
                    winnerIs = "human";
                else //picked paper
                    winnerIs = "computer";                
            }
            else if (humanPickedWeapon == "paper")
            {
                if (computerPickedWeapon == "scissors")
                    winnerIs = "computer";
                else //picked rock
                    winnerIs = "human";               
            }
            else  //human picked scissors
            {
                if (computerPickedWeapon == "rock")
                    winnerIs = "computer";
                else //picked paper
                    winnerIs = "human";                 
            }            
            
        }//end method compute

        public void printRoundsWinner()
        {
            if (winnerIs == "tie")
                System.Console.WriteLine("The round was a tie!");
            else
                System.Console.WriteLine("The " + winnerIs + " won this round!");
        }
        public string getWinnerName()
        {
            return winnerIs;
        }
        public void AdjustPoints(Player human, Player computer)
        {
            if (winnerIs == "human")
                computer.SubtractPoints();
            else if (winnerIs == "computer")
                human.SubtractPoints();
            else
            { // no points need to be adjusted for a tie 
            }                               

        }//end method AdjustPoints

        public Tuple<int, int> getUserScores(Player human, Player computer)
        {
            var scoresTuple = Tuple.Create( human.getPlayersPoints(),  computer.getPlayersPoints());
            return scoresTuple;
        }//

        public void printerPlayersScores(int humanScore, int computerScore)
        {
            System.Console.WriteLine("You have " + humanScore + " points and the computer has " + computerScore + " points");
        }
    }
}
