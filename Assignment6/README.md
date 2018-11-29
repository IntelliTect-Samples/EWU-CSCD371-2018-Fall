# Assignment 6

This assignment will use some of the code files you created in Assignment 5. For this project simply copy over the work you did for Assignment 5 as a starting point.

## Reading 
* TBD

## Coding Excercise (due 11/06/2018)
* Create a flags enum for the days of the week
* Create an enum for the quarters (Spring, Summer, Fall, Winter) in a school year
* Create a struct that will store only a Time value (hour, minute, second)
* Create a struct called Schedule that has the following properties
  * DayOfWeek
  * Quarter
  * StartTime
  * Duration (this will be of type TimeSpan)
* Write unit tests that verify the following
  * You are able to parse a string for multiple days of the week and it sets the enum properly (both single and combination)
  * You are able to parse a single value string for Quarter and it sets the proper value
  * Your structs are readonly
  * Using Marshal.SizeOf, make sure your struct isn't larger than 16 bytes - Marshal.SizeOf<Schedule>() returns an integer stating how many bytes a value type is.

* Create a separate class and struct for performing the following tests (this is needed because we aren't going to be following best practices for the struct in these tests).
  * Create a struct and class that has some read/write properties
  * Write tests that show the following behavior
    * When passing a struct to a method and changing a property value, the passed in struct is not changed in the original calling method
    * When passing a class to a method and changing a property value, the passed in class is changed in the original calling method
    * When passing a struct to a method and changing a property value, the passed in struct is changed in the original calling method
    * When passing a class to a method and creating a new instance of that class, the passed in class is changed in the original calling method
    * When casting a struct to an interface, then passing that interface to a method that changes a property value, show that the interface after the method call has the property value changed in the original calling method

## Coding Guidlines

* **All production code should be unit tested.  And, although we can't verify it, you are encouraged to do so following a TDD process.**
* **All projects should have project properties set so that warnings are reported as errors by the compiler**
* **Follow all coding guidelines for chapters covered** - Except where called out in the second part of the assignment
