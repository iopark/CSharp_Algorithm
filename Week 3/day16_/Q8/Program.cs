namespace Q8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bingo! Click to Continue");
            Console.ReadKey(); 

            Game game = new Game();
            game.Run(); 
        }
    }
}