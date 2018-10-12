using System;
using System.Collections.Generic;
using System.Text;

namespace HW3_Roshambo
{
    public class Player
    {
        private int playersPoints;
        private string playersWeaponChoice;
        private string playersName;       
        
        public Player(string name)
        {            
            playersName = name;
        }

        public void initialPlayersPoint()
        {
            playersPoints = 100;
        }

        public bool stillHasPoints()
        {
            return playersPoints > 0;
        }

        public void getHumansWeaponChoice()
        {
            System.Console.WriteLine("Please choose - rock, paper, or scissors.");
            string usersWeapon = System.Console.ReadLine();
            validHumansWeaponChoice(usersWeapon);
        }

        public void validHumansWeaponChoice(string usersWeaponChoiceString)
        {
            
            if (usersWeaponChoiceString.StartsWith('r'))
            {
                playersWeaponChoice = "rock";
            }
            else if (usersWeaponChoiceString.StartsWith('p'))
            {
                playersWeaponChoice = "paper";
            }
            else if (usersWeaponChoiceString.StartsWith('s'))
            {
                playersWeaponChoice = "scissors";
            }
            else
            {
                System.Console.WriteLine("Error - invalid input! Rock was selcted for you (since you must be one)");

                playersWeaponChoice = "rock";
            }
        }

        public void ComputerPicksWeapon()
        {            
            DateTime dateTime = DateTime.Now;
            int getRandomNum = dateTime.Millisecond % 3;

            if(getRandomNum == 0)
                playersWeaponChoice = "rock";
            else if (getRandomNum == 1)
                playersWeaponChoice = "paper";
            else                
                playersWeaponChoice = "scissors";
        }

        public string getWeaponPicked()
        {
            return playersWeaponChoice;
        }

        public void SubtractPoints()
        {
           // System.Console.WriteLine("Entering the " +
           //     playersName + "'s subtract points method. Weapon was " + playersWeaponChoice +
            //    ", points before subracation is " + playersPoints);
            if (playersWeaponChoice == "rock") {
              //  System.Console.WriteLine("Enter Rock if statement");
                playersPoints = playersPoints - 20;
            }
            else if (playersWeaponChoice == "scissors")
                playersPoints = playersPoints - 15;
            else //paper was selected
                playersPoints = playersPoints - 10;
           // System.Console.WriteLine("Exiting subract method, player points is now " + playersPoints);
        }

        public int getPlayersPoints()
        {
            return playersPoints;
        }

        public void setPlayersWeapon(String weapon)
        {
            playersWeaponChoice = weapon;
        }

    }
}
