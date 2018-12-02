namespace Assignment5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var console = new RealConsole();
            var eventManager = new EventManager(console);
            eventManager.Run();
        }
    }
}
