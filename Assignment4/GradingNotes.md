# Notes from Grading and reviewing Code Reviews

* Should I use an expression body for a one-liner get?
  
    I'd say that using an expression bodied property is optional based on programmer preference.  I would recommend you stay consistent within the file.  
    The advantage of the expression bodied member is succinctness without reducing readability.  I like prefer it for this reason.  If I was writing a coding standard on this I would say, "CONSIDER using expression bodied property implementations for the most simple properties and methods.

* Is it okay to set the default value explicitly even though it is redundant (e.g. `int Number {get;set;} = 0;`)?

    Sure, especially if the default value is important.  I'd leave it to the programmers choice.  Generally when you aren't sure, readabilty should be the guide - keeping in mind that sometimes more code is less readable and sometimes less code is more readable.

* What is the casing convention for fields?

    Either `private DateTime _DateStart;` or `private DateTime _dateStart;` but be consistent throughout the project.  I (Mark Michaelis) prefer `_DateStart` because it means I only need to enter the name once for a field backed property.  (In class I showed how to update __snippets__ so that you could take advantage the approach I favor.)

* Can I assign a method or property return to an implicitly typed local variable (`var`)

    Hmmmm.... the Guideline is, "AVOID using implicitly typed local variables unless the data type of the assigned value is obvious."  What is the return type of the `SummaryInformation` method in `var data = SummaryInformation()` (whether a property or a method)?  If you can't tell, I suggest using the explicit rather than the implicit type.

*  Shoud I specify the message when instantiating a `ArgumentNullException`?

    You should always identify the parameter name for which the exception is being thrown and you should do so using the `nameof` operator. However, there is generally no reason to also provide a message unless the message is adding value above and beyond the default message for an `ArgumentNullException`.  The general message, given a parameter name of data, is: "Value cannot be null. Parameter name: data"

* When using pattern matching with a polymorphism (i.e. `UniversityCourse` derives from `Event` and either or both have a `GetSummaryInformation()` method) should I have _case_ statments for both types (i.e  `UniversityCourse` and `Event`). 

    No.  If you have tests with pattern matching against `Event` and `UniversityCourse` you will notice that the most derived implementation is invoked such that you only need to have a case statement for `Event` assuming all it does is invoke `GetSummaryInformation()`.


* Is it okay to change the value assigned in the setter of a property?

    This is relatively unusual and possibly unexpected to the caller.  Use caution when changing the value.  When setting a value programmers expect the value the passed to be assigned. If you change it (invoke Trim() on a string for example) it might be unexpected behavior.  That doesn't mean don't, but you would certainly want to document this at a minimum.  If you don't want to allow pre/post fix spaces, consider throwing an exception instead.

## Ignore

See [Assignment4/GradingNotes.md](https://github.com/IntelliTect-Samples/EWU-CSCD371-2018-Fall/blob/master/Assignment4/GradingNotes.md).

1. Contains required projects code - __10pts__
1. Submission compiles - __10pts__
1. App performs expected operations - __20pts__
1. Unit tests properly test code - __20pts__