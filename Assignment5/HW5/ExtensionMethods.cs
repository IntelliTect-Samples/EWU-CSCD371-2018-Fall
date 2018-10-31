using System;


namespace HW5
{
    public static class MyExtension
    {
        public static void PublicAnnoucement(this String eventName)
        {
            //converter the event's name to uppercase (like your yelling) and print it out.
            string str = eventName.ToUpper();
            System.Console.WriteLine(str);
        }
        
    }
}
