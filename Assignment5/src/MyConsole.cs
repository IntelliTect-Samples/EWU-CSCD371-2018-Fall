using System;

namespace Assignment5
{
    public class MyConsole: IConsole
    {          
        public String ReadLine()
        {
            return Console.ReadLine();
        }

        public int ReadInt()
        {
            var possNum = ReadLine();
            if(int.TryParse(possNum, out int isNum))
            {
                return isNum;
            }
            else
            {
                throw new Exception("User did not type valid integer");
            }
        }
        public void Write(String str)
        {
            Console.Write($"{str}");
        }

        public void WriteLine(String str)
        {
            Console.WriteLine($"{str}");
        }
    }
}
