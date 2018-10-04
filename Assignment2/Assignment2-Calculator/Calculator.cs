using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Assignment2_Calculator
{
    public class Calculator
    {  
        public static void Main(string[] args)
        {   
            var userInput = args.Length == 0 ? TakeUserInput() : args[0];
            int max = int.MaxValue;
            while(!IsValidExpression(userInput))
                userInput = TakeUserInput();

            try
            {
                (int operandOne, int operandTwo, char operatorOne)
                    expressionTuple = ParseExpressionIntoTuple(userInput);

                double solution = EvaluateExpression(expressionTuple);
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
            string input = Console.ReadLine();
            return Regex.Replace(input, " ", "");
        }


        private static bool IsValidExpression(string expressionStr)
        {
            var regex = new Regex(@"^-?\d+[-+/*]{1}-?\d+$");    //correct expression pattern
            var isValid = regex.IsMatch(expressionStr);
            if(!isValid)
                Console.WriteLine($"Invalid Expression: {expressionStr}");
            return isValid;
        }

        private static (int, int, char) ParseExpressionIntoTuple(string expressionStr)
        {
            (int operandOne, int operandTwo, char operatorOne) expressionTuple; 
            var regex = new Regex(@"(?<=\d)[-+*/]{1}");        //gets operator not minus sign

           var match = regex.Match(expressionStr);
            char.TryParse(match.Value, out expressionTuple.operatorOne);
            string[] splitExpression = expressionStr.Split(expressionTuple.operatorOne);
            int.TryParse(splitExpression[0], out expressionTuple.operandOne);
            int.TryParse(splitExpression[1], out expressionTuple.operandTwo);
            return expressionTuple;
        }

        private static double EvaluateExpression( (int operandOne, int operandTwo, char operatorOne) expressionTuple)
        {
            switch (expressionTuple.operatorOne)
            {
                case '+':
                    return expressionTuple.operandOne + expressionTuple.operandTwo;
                case '-':
                    return expressionTuple.operandOne + expressionTuple.operandTwo;
                case '*':
                    return expressionTuple.operandOne + expressionTuple.operandTwo;
                case '/':
                    return expressionTuple.operandOne + expressionTuple.operandTwo;
                default:
                    return 0;
            }
        }
        
        

        private static int Add(int intA, int intB)
        {
            return intA + intB;
        }
        
        private static int Subtract(int intA, int intB)
        {
            return intA - intB;
        }

        private static double Multiply(int intA, int intB)
        {
            return intA * intB;
        }

        private static double Divide(int intA, int intB)
        {
            if(intB == 0)
                throw new DivideByZeroException();
            return intA / (double)intB;
        }
    }
}