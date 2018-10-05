using System;

/*
    The difference between /n and System.Enviroment.newLine is that they serve the same purpose, but not all machines have
    the same format for new line character. Such as Linux systems the forward slash while Windows systems use the backward slash.
    Having it in one format that some machines don't support may result in errors when inplementing the .net framework, 
    so it's safer to use the C# library's version to replace with the version the system implmenting the program uses.
 */

namespace src
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Expression.Expression newExpression = null;
            switch(args.Length)
            {
                case 0:
                    Console.Write("Please type in the expression you wish to calculate: ");
                    newExpression = new Expression.Expression(Console.ReadLine());
                    Console.WriteLine(newExpression.postFixEval());
                    break;
                case 1:
                    newExpression = new Expression.Expression(args[0]);
                    Console.WriteLine(newExpression.postFixEval());
                    break;
                default:
                    Console.WriteLine("Error: Cannot calculate passed in paramters,{0} Please pass in one expression.", System.Environment.NewLine);
                    break;
            }
        }
    }
}
