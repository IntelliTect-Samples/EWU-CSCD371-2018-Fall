# Assignment 3

### For this assigment we are going to make a simple game of roshambo (rock, paper, scissors). Of course there is going to be a twist since usually the first comment out of the losing player's mouth is "best 2 out of 3?". This means the twist will be, instead of trying to appease the "best 2 out of 3/best 3 out of 5" argument, each player will start with a life of 100 points and as they lose a round, their points will be deducted.

#### Game Requirements
* Assume that when the person launches the application, they want to play the game, so don't prompt them on if they want to play or not
* Each "player" (the player and the computer) are going to start out with 100 life points. Each time a player loses, the life points will need to be deducted.
  * Rock causes a loss of 20 points
  * Scissors cause a loss of 15 points
  * Paper causes a loss of 10 points
  * No points are deducted if both players "throw" the same thing
* The game is played until one player runs out of life points
* When the game is over, the user is asked if they would like to play again

#### Coding Requirements
* You must have one method that returns a tuple
* Pick the proper Flow Control (do/while, while, for, foreach, switch, if/else) block for each process
* Make your methods public so that they are easy to test. There really won't be a good way to test the "Main" method, so try and put as much logic as possible into methods that can be tested
* As with all projects, unit tests are required for this assignment

#### Assumptions that can be made
* I will only type one of the following (it will always be the whole word and it will always be lower case)
  * rock
  * paper
  * scissors
* When prompted on if I would like play again, I will only type 'y' or 'n'
* Since we haven't covered "randomness" yet, you can use the same idea I did of using the current DateTime seconds and then modding that value by 3 for one response, modding it by 2 for another, and then defaulting to the third response if neither of those conditions are met
