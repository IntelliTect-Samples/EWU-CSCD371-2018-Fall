# Notes from Grading and reviewing Code Reviews

* Should I use an expression body for a one-liner get?
  
    I'd say that using an expression bodied property is optional based on programmer preference.  I would recommend you stay consistent within the file.  
    The advantage of the expression bodied member is succinctness without reducing readability.  I like prefer it for this reason.  If I was writing a coding standard on this I would say, "CONSIDER using expression bodied property implementations for the most simple properties and methods.

* Is it okay to set the default value explicitly even though it is redundant (e.g. `int Number {get;set;} = 0;`)?

    Sure, especially if the default value is important.  I'd leave it to the programmers choice.  Generally when you aren't sure, readabilty should be the guide - keeping in mind that sometimes more code is less readable and sometimes less code is more readable.

* What is the casing convention for fields?

    Either `private DateTime _DateStart;` or `private DateTime _dateStart;` but be consistent throughout the project.  I (Mark Michaelis) prefer `_DateStart` because it means I only need to enter the name once for a field backed property.  (In class I showed how to update __snippets__ so that you could take advantage the approach I favor.)
