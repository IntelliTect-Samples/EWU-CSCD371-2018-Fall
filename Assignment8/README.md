# Assignment 8

## Reading

* Complete Chapter 13
* Read Chapter 14 by 11/13/2018

## Coding Exercise (due 11/15/2018)

Create a simple time tracker WPF application. The app should allow you to keep track of how long you spend working on tasks. 
The intent is to be able to start the app, and click something to indicate that you are starting a task. Then at a later point click something else to indicate that you are done. This should create a new time entry.

The app should have the following functionality:
* Show the current time (this should be updating on a timer).
* Some UI method (button?) to indicate that you are starting / stoping a task.
* A ListBox showing all of time entries that have been completed.
* The ability to delete the selected item from the ListBox.
* The window should be resizable and the elements should properly positions and scale.

Separate out the code that keeps track of the current task into its own `TimeManager` class. **This class should be unit tested**
* This class should have a method that is invoked whenever the user starts or stops a task.
* It should have an `event` that is raised whenever a time entry is completed.
* The event's arguments should contain the time entry that was completed.
* The WPF app should watch this event, when it is raised should add the time entry to the ListBox.

The `TimeManager` class will need to access the current time (`DateTime.Now`) using this directly will make unit testing difficult.
* Decouple the TimeManager class from `System.DateTime` by introducing an `IDateTime` interface. This is similar to the technique used in Assignment 5.
* The `IDateTime` imeplementation in the WPF app should simply forward calls to the `System.DateTime` class
* In the unit test project, create a testable implementation of `IDateTime` this will allow you to make the `TimeManager` class deterministic.

### Things to note:
* This is a WPF project. Because WPF is a Windows Desktop framework, this requires using Visual Studio on Windows.
* For this assignment, disreguard the `dotnet` command line tool. WPF does not work with it.
* When creating the unit test project you will need to select the Unit Test Project template that works with (.NET Framework).

### Extra credit opportunities
* Allow for including a description with each individual time entry.
* Persist the time entries to a file when the app stops and reload them when the app starts. There are methods you can override in App.xaml.cs that will be helpful here.
* Add some flare to the app with WPF styles and themeing. There are several popular libraries for doing this [MahApps](https://mahapps.com/) or [MaterialDesignInXaml](http://materialdesigninxaml.net/) being a couple examples.
* Use the MVVM design pattern. Most WPF apps created today use this pattern. This will require a bit more work, but will also make the code more testable. you can read more about it [here](https://intellitect.com/getting-started-model-view-viewmodel-mvvm-pattern-using-windows-presentation-framework-wpf/) or [here](http://www.learnmvvm.com/).

## Coding Guidelines

* **Non-WPF code should be unit tested.  And, although we can't verify it, you are encouraged to do so following a TDD process.**
* **All projects should have project properties set so that warnings are reported as errors by the compiler**
* **Follow all coding guidelines for chapters covered**

