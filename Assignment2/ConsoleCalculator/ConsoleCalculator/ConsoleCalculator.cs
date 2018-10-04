using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * ConsoleCalculator.cs
 * Created by Brian Bos
 */

namespace BrianBosAssignment2Namespace
{
    public class ConsoleCalculator
    {
        public static void Main(string[] args)
        {
            int firstOperand;
            bool isCharacterValid;
            bool isErrorThrown;
            bool isUserInputValid;
            int secondOperand;
            string userInput;
            int userInputStringPosition;
            char[] validCharacters = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '-', '*', '/', ' ' };

            /*
             * There is a difference between System.Environment.Newline and \n.
             *
             * \n is simply the newline UTF-16 character code
             * 
             * System.Environment.Newline is defined to be \r\n for Windows platforms (carriage return + line feed, what Windows expects a true new line to look like),
             * and \n for Mac and Unix-based platforms (where \n on its own is seen as a normal new line.)
             */
            Console.WriteLine($"ConsoleCalculator is now running.{Environment.NewLine}Enter \"Bye\" to quit the program.{Environment.NewLine}");

            while (true)
            {
                Console.Write("Enter an expression to evaluate: ");
                userInput = Console.ReadLine();

                if (String.Compare(userInput.ToLower(), "bye") == 0)
                {
                    break;
                }

                isUserInputValid = true;

                for (int i = 0; i < userInput.Length; i++)
                {
                    isCharacterValid = false;

                    for (int j = 0; j < validCharacters.Length; j++)
                    {
                        if (userInput[i] == validCharacters[j])
                        {
                            isCharacterValid = true;
                            break;
                        }
                    }

                    if (!isCharacterValid)
                    {
                        Console.WriteLine($"Invalid character \"{userInput[i]}\" found at position {i} of the equation string.");
                        isUserInputValid = false;
                    }
                }

                if (!isUserInputValid)
                {
                    Console.WriteLine();
                    continue;
                }

                firstOperand = getOperand(userInput, 0, out userInputStringPosition);

                if (userInputStringPosition == -1)
                {
                    continue;
                }

                int operatorStringPosition = userInputStringPosition;
                secondOperand = getOperand(userInput, userInputStringPosition + 1, out userInputStringPosition);

                if (userInputStringPosition == -1)
                {
                    continue;
                }

                int equationResult = 0;

                if (userInputStringPosition != userInput.Length)
                {
                    Console.WriteLine("Warning: This application only supports 2 operands. All characters after the second operand were ignored.");
                }

                if (userInputStringPosition != -1)
                {
                    checked
                    {
                        try
                        {
                            isErrorThrown = false;

                            switch (userInput[operatorStringPosition])
                            {
                                case '+':
                                    equationResult = firstOperand + secondOperand;
                                    break;

                                case '-':
                                    equationResult = firstOperand - secondOperand;
                                    break;

                                case '*':
                                    equationResult = firstOperand * secondOperand;
                                    break;

                                case '/':
                                    equationResult = firstOperand / secondOperand;
                                    break;

                                default:
                                    Console.WriteLine($"Error: Invalid operator \"{userInput[operatorStringPosition]}\" encountered");
                                    break;
                            }
                        }
                        catch (DivideByZeroException)
                        {
                            Console.WriteLine($"Error: Division by zero{Environment.NewLine}");
                            isErrorThrown = true;
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine($"Error: Integer overflow{Environment.NewLine}");
                            isErrorThrown = true;
                        }
                    }

                    if (!isErrorThrown)
                    {
                        Console.WriteLine($"Result: {equationResult}{Environment.NewLine}");
                    }
                }
            }
        }

        static int getOperand(string equationString, int startIndex, out int operandEndStringPosition)
        {
            bool isOperandNegative = false;
            int stringPosition = startIndex;
            int tempOperand = 0;

            while (stringPosition < equationString.Length && equationString[stringPosition] == ' ')
            {
                stringPosition++;
            }

            if (stringPosition >= equationString.Length)
            {
                Console.WriteLine($"Error: Invalid equation (stringPosition >= equationString.Length in method getOperand()){Environment.NewLine}");
                operandEndStringPosition = -1;
                return 0;
            }

            if (equationString[stringPosition] == '-')
            {
                isOperandNegative = true;
                stringPosition++;

                // Admittedly an inelegant solution (large "not equal to" chain), but it is fully functional
                if (stringPosition >= equationString.Length || (equationString[stringPosition] != '0' && equationString[stringPosition] != '1' && equationString[stringPosition] != '2' && equationString[stringPosition] != '3' && equationString[stringPosition] != '4' && equationString[stringPosition] != '5' && equationString[stringPosition] != '6' && equationString[stringPosition] != '7' && equationString[stringPosition] != '8' && equationString[stringPosition] != '9'))
                {
                    Console.WriteLine($"Error: A lonely negative sign has made its way into getOperand(){Environment.NewLine}");
                    operandEndStringPosition = -1;
                    return 0;
                }
            }
            
            while (equationString[stringPosition] != '+' && equationString[stringPosition] != '-' && equationString[stringPosition] != '*' && equationString[stringPosition] != '/' && equationString[stringPosition] != ' ')
            {
                checked
                {
                    try
                    {
                        tempOperand *= 10;
                        tempOperand += Convert.ToInt32(equationString[stringPosition].ToString());
                    }
                    catch (OverflowException)
                    {
                        // Minor quirk: ints are allowed to contain the value -2147483648 (int.MinValue), but doing arithmetic on that value triggers an overflow exception, even if it doesn't overflow (such subtracting 0 or adding 1)
                        Console.WriteLine($"Error: An operand was larger than {int.MaxValue} or smaller than or equal to {int.MinValue} (int.MaxValue and int.MinValue, respectively){Environment.NewLine}");
                        operandEndStringPosition = -1;
                        return 0;
                    }
                }

                stringPosition++;

                if (stringPosition >= equationString.Length)
                {
                    break;
                }
            }

            if (isOperandNegative)
            {
                tempOperand *= -1;
            }

            while (stringPosition < equationString.Length && equationString[stringPosition] == ' ')
            {
                stringPosition++;
            }

            operandEndStringPosition = stringPosition;
            return tempOperand;
        }
    }
}
