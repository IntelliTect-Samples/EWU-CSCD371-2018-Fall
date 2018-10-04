using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace ConsoleMathSolver
{
    public static class ConsoleMathSolverHelper
    {
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

            if (parsedNumbers.Count != 2)
            {
                return 0; 
            }
            double result = (double) parsedNumbers[0];

            // todo: set result to first in array and then calculate from subsequent elements
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
        public static List<int> ParseOperators(string operatorInput, string operatorUsed)
        {
            List<int> toReturn = new List<int>();

            List<string> tempArr = new List<string>(operatorInput.Split(operatorUsed));

            // no operators present
            if (tempArr.Count == 0)
            {
                throw new InvalidDataException("Invalid input sequence! Input must match <integer><operator><integer>");
            }

            int validNumCount = 0;

            foreach (var temp in tempArr)
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

            // too many operators
            return (validNumCount == tempArr.Count) ? toReturn : 
                throw new InvalidDataException("String not properly operator delimited.");
        }

        // Finds first non-digit in string, and determines if it is a valid operator
        // Throws InvalidDataException if no valid operator found
        public static string OperatorUsed(string operatorInput)
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