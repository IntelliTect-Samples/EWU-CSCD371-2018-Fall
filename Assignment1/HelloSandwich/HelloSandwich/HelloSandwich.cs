using System;

/*
 * HelloSandwich.cs
 * Created by Brian Bos
 * 
 * I am using \n instead of System.Environment.NewLine here.
 * It works in the Windows Visual Studio output console,
 * and that's enough coverage for this basic project.
 */

namespace BrianBosAssignment1Namespace
{
    public class HelloSandwich
    {
        public static void Main()
        {
            string inputMouseCount;
            string inputName;

            Console.WriteLine("What is your name?");
            inputName = Console.ReadLine();

            Console.Write("\nHow many mice does it take to make a turkey sandwich?\nAnswer: ");
            inputMouseCount = Console.ReadLine(); // Numeric input is encouraged, but not required

            Console.Write($"\nEntered name  : {inputName}\nEntered answer: {inputMouseCount}\n\n\"{inputName}\" believes that it takes {inputMouseCount} mice to make a turkey sandwich!\n");
        }
    }
}