using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace ConsoleMathSolver
{
    public class ConsoleMathSolverHelper
    {

        public static int CalculateValue(string operatorInput)
        {
            string operatorUsed = OperatorUsed(operatorInput);

            List<int> numsArr = ParseOperators(operatorInput, operatorUsed);

            if (!(numsArr.Count >= 2))
            {
                return 0; 
            }
            int result = numsArr[0];

            // todo: set result to first in array and then calculate from subsequent elements
            // todo: ensure at least two operators
            switch (operatorUsed)
            {
                    case "+":
                        for (int i = 1; i < numsArr.Count; i++)
                        {
                            result += numsArr[i];
                        }

                        return result;
                    case "-":
                        for (int i = 1; i < numsArr.Count; i++)
                        {
                            result -= numsArr[i];
                        }

                        return result;
                    case "*":
                        for (int i = 1; i < numsArr.Count; i++)
                        {
                            result *= numsArr[i];
                        }

                        return result;
                    case "/":
                        for (int i = 1; i < numsArr.Count; i++)
                        {
                            result /= numsArr[i];
                        }

                        return result;
            }
            
            return result;
        }
        
        /// <summary>
        /// Returns list of type [int] split on operators. If list is not properly formatted then null is returned
        /// First non-integer number is considered to be operator. If this operator is not one of the
        /// valid operators, null is returned.
        /// Valid operators: +, -, *, /
        /// </summary>
        /// <param name="operatorInput">Operator delimited string of integers
        /// I.E: "1+1" not "1+1+"</param>
        /// <param name="operatorUsed">Operator splitting integers</param>
        //todo: change to return tuple of Integer, Integer
        public static List<int> ParseOperators(string operatorInput, string operatorUsed)
        {
            if (string.IsNullOrEmpty(operatorInput))
            {
                return null;
            }
            
            List<int> toReturn = new List<int>();

            List<string> tempArr = new List<string>(operatorInput.Split(operatorUsed));

            // no operators present
            if (tempArr.Count == 0)
            {
                return null;
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
        // todo: Handle negative numbers. If second number is negative then parse on double negative character
        // todo: change to private
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