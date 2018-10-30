﻿using System;

namespace Assignment5
{
    public class MyConsole : IConsole
    {
        public void WriteLine(string str)
        {
            Console.WriteLine(str);
        }

        public void Write(string str)
        {
            Console.Write(str);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}