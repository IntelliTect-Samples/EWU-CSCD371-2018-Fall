using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace Assignment2
{
    public class UserInputExpression
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Booting up Mathematical Expression Solver\n");
            Menu();
            UserInput();
        }

        public static void Menu()
        {
            String menuInput = "a";

            while (!(menuInput.Equals("q")))
            {
                if(menuInput == "e" || menuInput == "E")
                {
                    UserInput();
                }
                Console.Write("Type E for new expression\n" +
                    "Type Q to quit\n" +
                    "-->");
                menuInput = Console.ReadLine();
            }
        }

        public static void UserInput()
        {
            String userInput = Console.ReadLine();
            int result = UserInputExpressionEvaluation(userInput);
            Console.WriteLine(result);
        }

        public static int UserInputExpressionEvaluation(string toSolve)
        {
            var operators = new char[] { '+', '-', '*', '/' };
            var nums = GetNumsFromStr(toSolve);
            var solveChars = toSolve.ToCharArray();
            var op = ' ';

            for (int i = 0; i < solveChars.Length; i++)
            {
                if (char.IsDigit(solveChars[i])) continue;

                // First number negative check
                if (i == 0)
                {
                    nums[0] = ToNegative(nums[0]);
                    continue;
                }

                // Second number negative check AND find out operator
                if (!char.IsDigit(solveChars[i + 1]))
                {
                    nums[1] = ToNegative(nums[1]);
                }

                op = solveChars[i];
                break;
            }

            return Calculate(op, nums);
        }

        private static int Calculate(char oper, int[] vals)
        {
            switch (oper)
            {
                case '+': return vals[0] + vals[1];

                case '-': return vals[0] - vals[1];

                case '/': return vals[0] / vals[1];

                case '*': return vals[0] * vals[1];
            }

            return -1;
        }

        private static int[] GetNumsFromStr(string str)
        {
            var nums = new List<int>();
            var pattern = @"(\d)+";

            foreach (Match m in Regex.Matches(str, pattern))
            {
                nums.Add(Int32.Parse(m.ToString()));
            }

            return nums.ToArray<int>();
        }

        private static int ToNegative(int val)
        {
            return val - (val * 2);
        }
    }
}
