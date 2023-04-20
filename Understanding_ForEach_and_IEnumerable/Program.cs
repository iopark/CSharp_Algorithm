namespace Understanding_ForEach_and_IEnumerable
{
    internal class Program
    {
        /* part of this learning activity is based on the day20_lecture on Iterator 
         * as well as indiv part of learning on ways C# has approached upon STL/ general class handling styles 
         * (LINQ **) 
         */

        /* As such, part of this activity is based on the Stackoverflow: https://stackoverflow.com/questions/398982/how-do-foreach-loops-work-in-c 
 */ 

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Test test = new Test(); 
            foreach (int i in test) { Console.WriteLine(i); }
            // prints 0-4 
        }

        class Test
        {
            public Foreach_ GetEnumerator()
            {
                return new Foreach_(); 
            }
        }
    }
}