using System;

namespace HW7
{
    class Program
    {
        static void Main(string[] args)
        {
            MangResource MR1;
            MangResource MR2;
            using (MR1 = new MangResource(@"C:\Users\Jeff\source\repos\HW7\HW7\SomeFile.txt"))
            using (MR2 = new MangResource(@"C:\Users\Jeff\source\repos\HW7\HW7\OtherFile.txt"))
                System.Console.WriteLine("total num of managed resources = " + MangResource.TotalNumOfResources);
            


            System.Console.WriteLine("total num of managed resources = " + MangResource.TotalNumOfResources);

            System.Console.WriteLine("Press any key to exit");
            System.Console.ReadLine();
        }
    }
}
