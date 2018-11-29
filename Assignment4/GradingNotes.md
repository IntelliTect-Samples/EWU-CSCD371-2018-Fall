# Notes from Grading and reviewing Code Reviews

### 1. Should I use an expression body for a one-liner get?
  
I'd say that using an expression bodied property is optional based on programmer preference.  I would recommend you stay consistent within the file.  
The advantage of the expression bodied member is succinctness without reducing readability.  I like prefer it for this reason.  If I was writing a coding standard on this I would say, "CONSIDER using expression bodied property implementations for the most simple properties and methods.

### 2. Is it okay to set the default value explicitly even though it is redundant (e.g. `int Number {get;set;} = 0;`)?

Sure, especially if the default value is important.  I'd leave it to the programmers choice.  Generally when you aren't sure, readabilty should be the guide - keeping in mind that sometimes more code is less readable and sometimes less code is more readable.

### 3. What is the casing convention for fields?

Either `private DateTime _DateStart;` or `private DateTime _dateStart;` but be consistent throughout the project.  I (Mark Michaelis) prefer `_DateStart` because it means I only need to enter the name once for a field backed property.  (In class I showed how to update __snippets__ so that you could take advantage the approach I favor.)

### 4. Can I assign a method or property return to an implicitly typed local variable (`var`)

Hmmmm.... the Guideline is, "AVOID using implicitly typed local variables unless the data type of the assigned value is obvious."  What is the return type of the `SummaryInformation` method in `var data = SummaryInformation()` (whether a property or a method)?  If you can't tell, I suggest using the explicit rather than the implicit type.

### 5. Shoud I specify the message when instantiating a `ArgumentNullException`?

You should always identify the parameter name for which the exception is being thrown and you should do so using the `nameof` operator. However, there is generally no reason to also provide a message unless the message is adding value above and beyond the default message for an `ArgumentNullException`.  The general message, given a parameter name of data, is: "Value cannot be null. Parameter name: data"

### 6. When using pattern matching with a polymorphism (i.e. `UniversityCourse` derives from `Event` and either or both have a `GetSummaryInformation()` method) should I have _case_ statments for both types (i.e  `UniversityCourse` and `Event`). 

No.  If you have tests with pattern matching against `Event` and `UniversityCourse` you will notice that the most derived implementation is invoked such that you only need to have a case statement for `Event` assuming all it does is invoke `GetSummaryInformation()`.


### 7. Is it okay to change the value assigned in the setter of a property?

This is relatively unusual and possibly unexpected to the caller.  Use caution when changing the value.  When setting a value programmers expect the value the passed to be assigned. If you change it (invoke Trim() on a string for example) it might be unexpected behavior.  That doesn't mean don't, but you would certainly want to document this at a minimum.  If you don't want to allow pre/post fix spaces, consider throwing an exception instead.

### 8. Should I group all fields together and then all properties together or should they be intermingled so that each field appears with its' property.

I would stronly encourage the latter.  It isn't wrong to do it the other way but if you separate them then any changed to the property (such as the type or the name) would not be immediately obvious unless they were together.  Also, since fields should generally only be accessed from within their properties, the association (as though the field were part of the property definition) makes sense.
