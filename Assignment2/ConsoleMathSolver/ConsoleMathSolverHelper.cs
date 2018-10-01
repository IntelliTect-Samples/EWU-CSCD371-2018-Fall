using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace ConsoleMathSolver
{
    public class ConsoleMathSolverHelper
    {
        /// <summary>
        /// Returns list of type [int] split on operators. If list is not properly formatted null is returned
        /// First non-integer number is considered to be operator. If this operator is not one of the
        /// valid operators, null is returned.
        /// Valid operators: +, -, *, /
        /// </summary>
        /// <param name="operatorInput">Operator delimited string of integers
        /// I.E: "1+1" not "1+1+"</param>
        /// <param name="operatorUsed">Operator splitting integers</param>
        public static List<int> ParseOperators(string operatorInput)
        {
            if (string.IsNullOrEmpty(operatorInput))
            {
                return null;
            }

            char operatorUsed = OperatorUsed(operatorInput);
            
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
            return (validNumCount == tempArr.Count) ? toReturn : null;
        }

        private static char OperatorUsed(string operatorInput)
        {
            foreach (var i in operatorInput)
            {
                if (!char.IsDigit(i))
                {
                    // check if is one of the valid operators
                    if (new List<char> {'+', '-', '/', '*'}.Contains(i))
                    {
                        return i;
                    }
                    throw new InvalidDataException($"\"{i}\" is not a valid operator");
                }
            }
            throw new InvalidDataException("No valid operator found");
        }
    }
}