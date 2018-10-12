using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace RoshamboUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        //code snippits taken from https://blogs.msdn.microsoft.com/ploeh/2006/10/21/console-unit-testing/
        HW3_Roshambo.Player human = new HW3_Roshambo.Player("human");
        HW3_Roshambo.Player computer = new HW3_Roshambo.Player("computer");
        HW3_Roshambo.GameActions gameActions = new HW3_Roshambo.GameActions();

        [TestMethod]
        public void humanPicksWeapon_UserInputIsrock_playersWeaponChoiceShouldBeRock()
        {
            // Arrange 
            // Act            
            human.validHumansWeaponChoice("rock");                

            // Assert
            Assert.AreEqual("rock", human.getWeaponPicked());
                       
        }//end of test method

        [TestMethod]
        public void humanPicksWeapon_UserInputIsR_playersWeaponChoiceShouldBeRock()
        {
            // Arrange 
            // Act            
            human.validHumansWeaponChoice("r");

            // Assert
            Assert.AreEqual("rock", human.getWeaponPicked());
            
        }//end of test method

        [TestMethod]
        public void humanPicksWeapon_UserInputIsPaper_playersWeaponChoiceShouldBeRock()
        {
            // Arrange 
            // Act            
            human.validHumansWeaponChoice("paper");

            // Assert
            Assert.AreEqual("paper", human.getWeaponPicked());
            
        }//end of test method

        [TestMethod]
        public void humanPicksWeapon_UserInputIsscissors_playersWeaponChoiceShouldBeRock()
        {
            // Arrange 
            // Act            
            human.validHumansWeaponChoice("scissors");

            // Assert
            Assert.AreEqual("scissors", human.getWeaponPicked());
            
        }//end of test method

        [TestMethod]
        public void humanPicksWeapon_InvalidUserInputIsLizard_playersWeaponChoiceShouldBeRock()
        {
            // Arrange 
            // Act            
            human.validHumansWeaponChoice("Lizzard");

            // Assert
            Assert.AreEqual("rock", human.getWeaponPicked());
            
        }//end of test method

        [TestMethod]
        public void SubtractPoints_ForRock_100PointsDownTo80()
        {
            // Arrange  
            human.setPlayersWeapon("rock");
            human.initialPlayersPoint(); //sets back to 100 points

            // Act            
            human.SubtractPoints();

            // Assert
            Assert.AreEqual(80, human.getPlayersPoints());

            
        }//end of test method

        [TestMethod]
        public void SubtractPoints_ForPaper_100PointsDownTo90()
        {
            // Arrange  
            human.setPlayersWeapon("paper");
            human.initialPlayersPoint(); //sets back to 100 points

            // Act            
            human.SubtractPoints();

            // Assert
            Assert.AreEqual(90, human.getPlayersPoints());
        }//end of test method

        [TestMethod]
        public void SubtractPoints_ForScissors_100PointsDownTo85()
        {
            // Arrange  
            human.setPlayersWeapon("scissors");
            human.initialPlayersPoint(); //sets back to 100 points

            // Act            
            human.SubtractPoints();

            // Assert
            Assert.AreEqual(85, human.getPlayersPoints());

        }//end of test method


        [TestMethod]
        public void DetermineRoundWinner_HumanGetsRock_ComputerGetsRock_tie()
        {
            // Arrange  
            human.setPlayersWeapon("rock");
            computer.setPlayersWeapon("rock");

            // Act            
            gameActions.DetermineRoundWinner(human, computer);

            // Assert
            Assert.AreEqual("tie", gameActions.getWinnerName());

        }//end of test method

        [TestMethod]
        public void DetermineRoundWinner_HumanGetsRock_ComputerGetsPaper_ComputerWins()
        {
            // Arrange  
            human.setPlayersWeapon("rock");
            computer.setPlayersWeapon("paper");

            // Act            
            gameActions.DetermineRoundWinner(human, computer);

            // Assert
            Assert.AreEqual("computer", gameActions.getWinnerName() );

        }//end of test method

        [TestMethod]
        public void DetermineRoundWinner_HumanGetsRock_ComputerGetsScissors_HumanWins()
        {
            // Arrange  
            human.setPlayersWeapon("rock");
            computer.setPlayersWeapon("scissors");

            // Act            
            gameActions.DetermineRoundWinner(human, computer);

            // Assert
            Assert.AreEqual("human", gameActions.getWinnerName());

        }//end of test method

        [TestMethod]
        public void DetermineRoundWinner_HumanGetsPaper_ComputerGetsRock_HumanWins()
        {
            // Arrange  
            human.setPlayersWeapon("paper");
            computer.setPlayersWeapon("rock");

            // Act            
            gameActions.DetermineRoundWinner(human, computer);

            // Assert
            Assert.AreEqual("human", gameActions.getWinnerName());

        }//end of test method

        [TestMethod]
        public void DetermineRoundWinner_HumanGetsPaper_ComputerGetsPaper_Tie()
        {
            // Arrange  
            human.setPlayersWeapon("paper");
            computer.setPlayersWeapon("paper");

            // Act            
            gameActions.DetermineRoundWinner(human, computer);

            // Assert
            Assert.AreEqual("tie", gameActions.getWinnerName());

        }//end of test method

        [TestMethod]
        public void DetermineRoundWinner_HumanGetsPaper_ComputerGetsScissors_ComputerWins()
        {
            // Arrange  
            human.setPlayersWeapon("paper");
            computer.setPlayersWeapon("scissors");

            // Act            
            gameActions.DetermineRoundWinner(human, computer);

            // Assert
            Assert.AreEqual("computer", gameActions.getWinnerName());


        }//end of test method

        [TestMethod]
        public void DetermineRoundWinner_HumanGetsScissors_ComputerGetsRock_ComputerWins()
        {
            // Arrange  
            human.setPlayersWeapon("scissors");
            computer.setPlayersWeapon("rock");

            // Act            
            gameActions.DetermineRoundWinner(human, computer);

            // Assert
            Assert.AreEqual("computer", gameActions.getWinnerName());

        }//end of test method

        [TestMethod]
        public void DetermineRoundWinner_HumanGetsScissors_ComputerGetsPaper_HumanWins()
        {
            // Arrange  
            human.setPlayersWeapon("scissors");
            computer.setPlayersWeapon("paper");

            // Act            
            gameActions.DetermineRoundWinner(human, computer);

            // Assert
            Assert.AreEqual("human", gameActions.getWinnerName());

        }//end of test method

       
        [TestMethod]
        public void DetermineRoundWinner_HumanGetsScissors_ComputerGetsScissors_tie()
        {
            // Arrange  
            human.setPlayersWeapon("scissors");
            computer.setPlayersWeapon("scissors");

            // Act            
            gameActions.DetermineRoundWinner(human, computer);

            // Assert
            Assert.AreEqual("tie", gameActions.getWinnerName());

        }//end of test method

       

       

       

        
    }
}
