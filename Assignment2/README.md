# Assignment 2

* Create a console application that accepts a simple mathematical expression, evaluates it, and displays the result
  * For the purposes of this assignment, you can assume that the input argument is in the form "&lt;integer&gt;&lt;operator&gt;&lt;integer&gt;" (ie. 1+3)
  * You can simply prompt the user for this input
  * Support the four basic arithmetic operators addition (+), subtractions (-), multiplication (*), and division (/)
  * Integers may be positive or negative.
* Create a unit test project, that properly tests the various cases
  * Keep in mind that you should test potential failure cases where numbers may be (zero, `int.MinValue`, or `int.MaxValue`)
  * Remember that a unit test should test only a single condition, not multiple conditions. For example rather than writing a unit test for addition, create separate unit tests to handle each condition for each operator
* Write unit tests demonstrating the behavior of 4 of the built-in "string methods" (or properties).
  * It will likely require more than one unit test per method
  * The test class should be named `StringTests`.
  * Note: This only requires a testing project, no separate "target project" is required.
* The work for this assignment should be done on a separate branch within your fork
  * All of the code should be under the Assignment2 folder
  * The PR should be created against the master branch on the IntelliTect repository


#### NOT REQUIRED
For those looking to go above and beyond you may consider some of the following additions

* Allow for handling `double` or `decimal` types rather than just integers
* Allow for passing the expression via the command line arguments
* Expand the number of supported mathematical operators (take a look at the `System.Math` class)
* Add validation to the check the values the user enters are numbers (see TryParse())
* What is the difference between System.Environment.NewLine and '\n' (if any)
* Provide a test for 2 of the StringBuilder methods that demonstrate its mutability.
