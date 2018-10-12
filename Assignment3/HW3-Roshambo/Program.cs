using System;

namespace HW3_Roshambo
{
    class Program
    {
        static void Main(string[] args)
        {
            WelcomeScreen();

            //game init
            Player human = new Player("human");
            Player computer = new Player("computer");
            GameActions gameActions = new GameActions();
            bool wantsToPlayAgain = false;
            do
            {
                human.initialPlayersPoint();
                computer.initialPlayersPoint();

                do
                {
                    human.getHumansWeaponChoice();
                    System.Console.WriteLine("You picked " + human.getWeaponPicked());
                    computer.ComputerPicksWeapon();
                    System.Console.WriteLine("The computer picked " + computer.getWeaponPicked());

                    gameActions.DetermineRoundWinner(human, computer);
                    gameActions.AdjustPoints(human, computer);
                    gameActions.printRoundsWinner();
                    var scores = gameActions.getUserScores(human, computer);
                    gameActions.printerPlayersScores(scores.Item1, scores.Item2);

                }
                while (human.stillHasPoints() && computer.stillHasPoints());

                System.Console.WriteLine("Would you like to play again (yes or no)");
                string playAgainAnswer = System.Console.ReadLine();
                if (playAgainAnswer.StartsWith('y'))
                    wantsToPlayAgain = true;
                else
                    wantsToPlayAgain = false;
            }
            while (wantsToPlayAgain);

            System.Console.WriteLine("Press any key to continue");
            System.Console.ReadLine();
        }

        private static void WelcomeScreen()
        {
            System.Console.WriteLine("Welcome to the Roshambo game. \n" +
                "Each player will be given 100 points, the round will last until one of you reaches 0 points." +
                "\nGood luck! \n  ");
        }       
            
    }//end class Program
}//end namespace HW3_Roshambo
