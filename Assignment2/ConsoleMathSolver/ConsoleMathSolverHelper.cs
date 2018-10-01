using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ConsoleMathSolver
{
    public class ConsoleMathSolverHelper
    {
        /// <summary>
        /// Returns list of type [int] split on operators. If list is not properly formatted null is returned
        /// </summary>
        /// <param name="operatorInput">Operator delimited string of integers
        /// I.E: "1+1" not "1+1+"</param>
        /// <param name="operatorUsed">Operator splitting integers</param>
        public static List<int> ParseOperators(string operatorInput, char operatorUsed)
        {
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
                Console.WriteLine(temp);
                if (!temp.Equals(""))
                {
                    validNumCount++;
                }
            }

            // too many operators
            return (validNumCount == tempArr.Count) ? toReturn : null;
        }
    }
}