using System;

namespace Assignment5
{
    public static class ConsoleExtensions
    {
        public static string GetString(this IConsole console, string message)
        {
            if (console == null) throw new ArgumentNullException(nameof(console));

            string input;
            do
            {
                console.WriteLine(message ?? "Enter a string");
                input = console.ReadLine();
            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }

        public static DateTime GetDateTime(this IConsole console, string message)
        {
            if (console == null) throw new ArgumentNullException(nameof(console));

            DateTime? input = null;
            do
            {
                console.WriteLine(message ?? "Enter a DateTime");
                if (DateTime.TryParse(console.ReadLine(), out DateTime dt))
                {
                    input = dt;
                }
            } while (input == null);

            return input.Value;
        }
    }
}