# Assignment 4

In this assignment, we will be using test driven development to create new classes for a UniversityCourse and an event.

## Exercises

* Read through Chapter 7 by 2018-10-16
* Be prepared to discuss all chapter 6&7 coding guidelines in class on 2018-10-16
* Create a new project and corresponding test project for University Course Work
* Create a new `UniversityCourse` class (The name `Course` is acceptable)
* Create at least 4 different properties covering the following:
  * Read-Only properties
  * Automatically implemented properties
  * Properties with validation
  * Calculated properties
* Add a (one time) `Event` class that has some common properties with `UniversityCourse` but `Event` should be a one time occurrence while the `UniversityCourse` should have a repeating schedule. Don't worry about the nitty gritty details of defining a repeating schedule for the `UniversityCourse`.  (We will possibly do that in a future exercise.)  Using a string for the "course schedule" is acceptable.
* Provide a `GetSummaryInformation()` method on both `UniversityCourse` and `Event` that returns a summary as text.
* Provide a method (such as a display method) on a static class that uses polymorphism to retrieve the summary information for a collection of events/courses.
* Define a Display method on a static class.  In the display method use a switch statement with pattern matching to call the `GetSummaryInformation()` method if it exists or call `ToString()` if it doesn't. The invocation of the `GetSummaryInformation()` method should use polymorphism.
* Include appropriate constructors in all classes
* Include a deconstructor in one or more of your classes
* Add a property that tracks the number of times courses/events are instantiated.
* All classes and class members should have appropriate instance (static/instance) scope and appropriately assigned access modifiers
* All classes should have validation such that they can't be in an invalid state
* Read some of Chapter 8 by 2018-10-18

## Coding Requirements

* See below

## All Assignments going forward

* **All production code should be unit tested.  And, although we can't verify it, you are encouraged to do so following a TDD process.**
* **All projects should have project properties set so that warnings are reported as errors by the compiler**
* **Follow all coding guidelines for chapters covered**
