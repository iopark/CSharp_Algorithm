namespace _05._Queue
{
    internal class Program
    {
        /* Stack 의 반대 , 파이프라인 형 자료형이며, Stack과 마찬가지로 역할 때문에 빈번하게 사용된다. 
         */ 

        static void Test()
        {
            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < 6; i++)
            {
                queue.Enqueue(i);// to add element to the queue 
                Console.WriteLine($"헤드 값:{queue.Head} 테일 값:{queue.Tail}");
            }
            //Console.WriteLine(queue.Peek()); // 가장 최_전방_ 의 값을 반환하여준다. 
            while (queue.Count > 0)
            {
                Console.WriteLine($" >> {queue.Dequeue()}, 헤드 값:{queue.Head} 테일 값:{queue.Tail}"); // To release element entered in the queue 
            }
            for (int i = 6; i < 10; i++) queue.Enqueue(i);
            while (queue.Count > 0)
            {
                Console.WriteLine($" >> {queue.Dequeue()}, 헤드 값:{queue.Head} 테일 값:{queue.Tail}"); // To release element entered in the queue 
            }
            Console.Write($" >> {queue.Count} 로딩완료!\n");
            while (queue.Count > 1)
            {
                Console.WriteLine($" >> {queue.Dequeue()}, 헤드 값:{queue.Head} 테일 값:{queue.Tail}"); // To release element entered in the queue 
            } // 최종: Head 0 , Head 0 
        }
        static void Main(string[] args)
        {
            Test();
            Console.WriteLine("Hello, World!");
        }
    }
}