using System;
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

            try
            {
                (long operandOne, long operandTwo, char operatorOne)
                    expressionTuple = ParseIntoTuple(userInput);

                var solution = EvaluateExpression(expressionTuple);
                Console.WriteLine(
                    $"{expressionTuple.operandOne}{expressionTuple.operatorOne}{expressionTuple.operandTwo}={solution}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType());
            }
        }

        private static string TakeUserInput()
        {
            Console.Write("Please enter an expression ie. (3+1): ");
            return Regex.Replace(Console.ReadLine(), " ", "");
        }


        private static bool IsValidExpression(string expressionStr)
        {
            var regex = new Regex(@"^-?\d+[-+/*]{1}-?\d+$");    //correct expression pattern
            var isValid = regex.IsMatch(expressionStr);
            if(!isValid)
                Console.WriteLine($"Invalid Expression: {expressionStr}");
            return isValid;
        }

        private static (long, long, char) ParseIntoTuple(string expressionStr)
        {
            (long operandOne, long operandTwo, char operatorOne) expressionTuple; 
            var regex = new Regex(@"(?<=\d)[-+*/]{1}");        //gets operator not minus sign

            var match = regex.Match(expressionStr);
            char.TryParse(match.Value, out expressionTuple.operatorOne);
            string[] splitExpression = expressionStr.Split(expressionTuple.operatorOne);
            long.TryParse(splitExpression[0], out expressionTuple.operandOne);
            long.TryParse(splitExpression[1], out expressionTuple.operandTwo);
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
                default:
                    return 0;
            }
        }
    }
}