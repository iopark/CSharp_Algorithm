namespace _04._Stack
{
    public class Program
    {
        void TesT()
        {
            Stack<int> stack = new Stack<int>(); // int 형식의 stack 

            Console.WriteLine(stack.Peek()); // 최상단의 element 값을 반환한다. 
            for (int i = 0; i < 10; i ++ ) stack.Push(i);
            while (stack.Count >0) // returns # of elements in stack 
            {
                Console.WriteLine(stack.Pop());
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}