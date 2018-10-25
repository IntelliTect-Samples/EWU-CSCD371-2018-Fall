# Assignment 5

This assignment will use some of the code files you created in Assignment 4. For this project simply copy over the work you did for Assignment 4 as a starting point.

## Reading 
* Read through Chapter 8 by 10/23/2018
* Read through Chapter 9 by 10/25/2018

## Code Review (due 10/25/2018)
* Perform a Code Review on another person's Assignment 4 pull request.
* Make sure you mark yourself as the reviewer on GitHub.
* A code review MUST have comments
    * Identify any bugs
    * Ask questions on anything you cannot explain
    * Suggest better alternatives

## Coding Excercise (due 10/30/2018)
* The project that contains the `UniversityCourse` and `Event` classes should be a console application. If this is not already the case, you may find it simpler to create new projects for this assignment and simply copy over the code (*.cs) files.
* The console application should provide the following:
    * User should be able to create events
    * User should be able to display a list of created events
* Create an `IConsole` interface to abstract `System.Console` functionality.
    * You will need to create two implementations of this interface. One for the main console app, that forwards calls to `System.Console` and one in the unit test project to verify that the correct calls were made.
    * You will need to unit test your implementation of `IConsole` that is in the main project. You will want to consider using the IntelliTect.TestTools.Console.ConsoleAssert class to assist with this.
    * Use the implementation of `IConsole` in the unit test project to unit test methods use the console.
* Create an `IEvent` interface and implement it on both the `UniversityCourse` and `Event` classes (or the equivelent classes you created in assignment 4). The exact members of this interface are up to you.
* Create an extension method for the `IEvent` interface to return a calculated value
* Add unit tests for type casting using `is`, `as`, and direct cast.

## Coding Guidlines

* **All production code should be unit tested.  And, although we can't verify it, you are encouraged to do so following a TDD process.**
* **All projects should have project properties set so that warnings are reported as errors by the compiler**
* **Follow all coding guidelines for chapters covered**
