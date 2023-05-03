namespace day29_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool[,] map = new bool[9, 9]
            {
                { false, false, false, false, false, false, false, false, false },
                { false,  true,  true,  true, false, false, false,  true, false },
                { false,  true, false,  true, false, false, false,  true, false },
                { false,  true, false,  true,  true,  true,  true,  true, false },
                { false,  true, false,  true, false, false, false,  true, false },
                { false,  true, false,  true, false, false, false,  true, false },
                { false, false, false, false, false, false, false,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true, false },
                { false, false, false, false, false, false, false, false, false },
            };
        }
    }
}