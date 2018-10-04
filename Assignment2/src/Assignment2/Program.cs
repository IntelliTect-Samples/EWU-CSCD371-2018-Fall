using System;

namespace Assignment2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Please enter a calculation to perform: ");

            var input = Console.ReadLine();

            string[] array;



            if (input.Contains('+')) //addition
            {
                array = input.Split('+');

                int.TryParse(array[0], out int num1);
                int.TryParse(array[1], out int num2);

                int res = num1 + num2;

                Console.WriteLine("{0}+{1} = {2}", num1, num2, res);
            }




            else if (input.Contains('*')) //multiplication
            {
                array = input.Split('*');

                int.TryParse(array[0], out int num1);
                int.TryParse(array[1], out int num2);

                int res = num1 * num2;

                Console.WriteLine("{0}*{1} = {2}", num1, num2, res);
            }




            else if (input.Contains('/')) //division
            {
                array = input.Split('/');

                int.TryParse(array[0], out int num1);
                int.TryParse(array[1], out int num2);

                if (num2 != 0)
                {
                    int res = num1 / num2;

                    Console.WriteLine("{0}/{1} = {2}", num1, num2, res);
                }

                else
                {
                    Console.WriteLine("Cannot Divide by Zero - Please Try Again");
                }
            }




            else if (input.Contains('-')) //subtraction - by checking for subtraction last it ensures that negatives work properly for all above calculations
            {
                array = input.Split('-');

                int num1 = 0, num2 = 0;


                if (array.Length == 2) // no negatives
                {
                    int.TryParse(array[0], out num1);
                    int.TryParse(array[1], out num2);
                }

                else if (array.Length == 3) // 1 negative
                {
                    if (array[0].Equals(""))        //if array[0] is empty string then first num is negative - second num positive
                    {                               //this happens because of way that split("-") works: "-2-3" --> { "", "2", "3" }

                        int.TryParse(array[1], out num1);
                        int.TryParse(array[2], out num2);

                        num1 = num1 * (-1);         //make num1 negative
                    }

                    else                            // second num negative - first number postiive - this splits as such: "2--3" --> { "2", "", "3" }
                    {
                        int.TryParse(array[0], out num1);
                        int.TryParse(array[2], out num2);

                        num2 = num2 * (-1);         //make num2 negative
                    }
                }

                else if (array.Length == 4) // both negative - splits as such: "-2--3" --> { "", "2", "", "3" }
                {
                    int.TryParse(array[1], out num1);
                    int.TryParse(array[3], out num2);

                    num1 = num1 * (-1);
                    num2 = num2 * (-1);         //make both nums negative
                }

                int res = num1 - num2;

                Console.WriteLine("{0}-{1} = {2}", num1, num2, res);
            }

     


            else //user doesnt input a math Symbol
            {
                Console.WriteLine("ERROR - Please include an operator (+, -, *, /) in your input");
            }




            Console.Write("Press Enter to Exit Program . . .");

            Console.ReadLine();
        }
        
    }
}
