using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Assignment2_Calculator
{
    public static class Calculator
    {  
        public static void Main(string[] args)
        {   
            var userInput = args.Length == 0 ? TakeUserInput() : args[0];
            while(!IsValidExpression(userInput))
                userInput = TakeUserInput();

            (long operandOne, long operandTwo, char operatorOne)expressionTuple = ParseIntoTuple(userInput);

             var solution = EvaluateExpression(expressionTuple);
             Console.WriteLine($"{expressionTuple.operandOne}{expressionTuple.operatorOne}{expressionTuple.operandTwo}={solution}");
        }

        private static string TakeUserInput()
        {
            Console.Write("Please enter an expression ie. (3+1): ");
            return Regex.Replace(Console.ReadLine(), " ", "");
        }


        private static bool IsValidExpression(string expressionStr)
        {
            var regex = new Regex(@"^-?\d+[-+/*%^]{1}-?\d+$");    //correct expression pattern
            var isValid = regex.IsMatch(expressionStr);
            regex = new Regex(@"-?\d+[/]{1}0+$");                //checks if there is division by zero
            var hasDivisionByZero = regex.IsMatch(expressionStr);
            regex = new Regex(@"-?\d+[%]{1}0+$");                //checks if there is division by zero
            var hasModByZero = regex.IsMatch(expressionStr);
            
            if(!isValid)
                Console.WriteLine($"Invalid Expression: {expressionStr}");
            if(hasDivisionByZero)
                Console.WriteLine($"Cannot divide by zero: {expressionStr}");
            if(hasModByZero)
                Console.WriteLine($"Cannot mod by zero: {expressionStr}");
            
            return isValid && !hasDivisionByZero && !hasModByZero;
        }

        private static (long, long, char) ParseIntoTuple(string expressionStr)
        {
            (long operandOne, long operandTwo, char operatorOne) expressionTuple; 
            var match = Regex.Match(expressionStr,@"(?<=\d)[-+*/%^]{1}");                        //gets operator not negative sign        
            char.TryParse(match.Value, out expressionTuple.operatorOne);
            
            long.TryParse(expressionStr.Substring(0,match.Index), out expressionTuple.operandOne);
            long.TryParse(expressionStr.Substring(match.Index+1), out expressionTuple.operandTwo);
            return expressionTuple;
        }

        private static double EvaluateExpression( (long operandOne, long operandTwo, char operatorOne) expressionTuple)
        {
            switch (expressionTuple.operatorOne)
            {
                case '+':
                    return expressionTuple.operandOne + expressionTuple.operandTwo;
                case '-':
                    return expressionTuple.operandOne - expressionTuple.operandTwo;
                case '*':
                    return expressionTuple.operandOne * expressionTuple.operandTwo;
                case '/':
                    return expressionTuple.operandOne / (double)expressionTuple.operandTwo;
                case '%':
                    return expressionTuple.operandOne % expressionTuple.operandTwo;
                case '^':
                    return Math.Pow(expressionTuple.operandOne, expressionTuple.operandTwo);
                default:
                    return 0;
            }
        }
    }
}