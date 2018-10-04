using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleMathSolver
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.Write("Please enter expression in form <integer><operator><integer>: ");
                
                // checks if a command line argument is present, if not input taken from console
                string userInput = (args.Length != 0) ? args[0] : Console.ReadLine();
                
                
                double result = CalculateValue(userInput);
                Console.WriteLine($"Value is: {result}");
            }
            catch (InvalidDataException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        
        
        public static double CalculateValue(string userInput)
        {
            if (string.IsNullOrEmpty(userInput))
            {
                throw new InvalidDataException("Input cannot be empty!");
            }
            
            // remove spaces from input string
            string userInputNoSpaces = Regex.Replace(userInput, "\\ +", "");

            if (userInputNoSpaces.Length == 0)
            {
                throw new InvalidDataException("Input cannot be empty!");
            }
           
            string operatorUsed = OperatorUsed(userInputNoSpaces);

            List<int> parsedNumbers = ParseOperators(userInputNoSpaces, operatorUsed);

            if (operatorUsed == "--")
            {
                operatorUsed = operatorUsed[0] + "";
                parsedNumbers[1] = parsedNumbers[1] * -1;
            }

            if (parsedNumbers.Count != 2)
            {
                return 0; 
            }
            double result = (double) parsedNumbers[0];

            switch (operatorUsed)
            {
                    case "+":
                        for (int i = 1; i < parsedNumbers.Count; i++)
                        {
                            result += parsedNumbers[i];
                        }

                        return result;
                    case "-":
                        for (int i = 1; i < parsedNumbers.Count; i++)
                        {
                            result -= parsedNumbers[i];
                        }

                        return result;
                    case "*":
                        for (int i = 1; i < parsedNumbers.Count; i++)
                        {
                            result *= parsedNumbers[i];
                        }

                        return result;
                    case "/":
                        for (int i = 1; i < parsedNumbers.Count; i++)
                        {
                            // check for divide by 0
                            if (parsedNumbers[i] == 0)
                            {
                                throw new DivideByZeroException("Cannot divide by 0!");
                            }

                        result /= parsedNumbers[i];
                        }

                        return result;
            }
            
            return result;
        }
        
        // throws NullReferenceException if operatorInput or operatorUsed are null
        // throws InvalidDataException 
        private static List<int> ParseOperators(string operatorInput, string operatorUsed)
        {
            List<int> toReturn = new List<int>();

            List<string> splitOnOperator;

            if (operatorInput[0] == '-' && operatorUsed == "-") // if the first number is a negative
            {
                string tempString = operatorInput.Substring(1); // exclude first negative
                splitOnOperator = new List<string>(tempString.Split(operatorUsed));

                if (splitOnOperator.Count < 2)
                {
                    throw new InvalidDataException("String not properly operator delimited.");
                }
                
                string replaceNegative = "-" + splitOnOperator[0];
                splitOnOperator[0] = replaceNegative;
            }
            else
            {
                splitOnOperator = new List<string>(operatorInput.Split(operatorUsed));
                
                if (splitOnOperator.Count < 2)
                {
                    throw new InvalidDataException("String not properly operator delimited.");
                }
            }

            // no operators present
            if (splitOnOperator.Count == 0)
            {
                throw new InvalidDataException("Invalid input sequence! Input must match <integer><operator><integer>");
            }

            int validNumCount = 0;

            foreach (var temp in splitOnOperator)
            {
                if (int.TryParse(temp, out int parsedVal))
                {
                    toReturn.Add(parsedVal);
                }
                if (!temp.Equals(""))
                {
                    validNumCount++;
                }
            }

            // make sure the last character isn't a erroneous operator
            if (splitOnOperator.Count > 2 || !char.IsDigit(splitOnOperator[1][splitOnOperator[1].Length-1]))
            {
                throw new InvalidDataException("String not properly operator delimited.");
            }
            
            // too many operators
            return toReturn;
        }

        // Finds first non-digit in string, and determines if it is a valid operator
        // Throws InvalidDataException if no valid operator found
        private static string OperatorUsed(string operatorInput)
        {
            for (int i = 0; i < operatorInput.Length; i++)
            {
                if (i == 0 && operatorInput[i] == '-')
                {
                    continue;
                }
                if (!char.IsDigit(operatorInput[i]))
                {
                    if (operatorInput[i] == '-' && (i+1) < operatorInput.Length)
                    {
                        // -1 - -1
                        // negative following subtraction symbol
                        if (operatorInput[i + 1] == '-')
                        {
                            return "--";
                        }
                        else
                        {
                            return "-";
                        }
                    }
                    else if (new List<char> {'+', '-', '/', '*'}.Contains(operatorInput[i]))
                    {
                        return operatorInput[i] + "";
                    }

                    throw new InvalidDataException($"\"{i}\" is not a valid operator");
                }
            }

            throw new InvalidDataException("No valid operator found");
        }
    }
}