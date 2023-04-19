using System.ComponentModel.DataAnnotations;

namespace day19_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            DataStructure.LinkedList<int> newLL = new DataStructure.LinkedList<int>();
            //DataStructure.LinkedListNode<string> newLL_Node = new DataStructure.LinkedListNode<string>("test"); 
            //연결 리스트 Add First/Last 
            newLL.AddFirst(2);
            newLL.AddFirst(1);
            //Head = 1 

            newLL.AddLast(5);
            newLL.AddFirst(0);
            // Tail = 3 
            Console.WriteLine($"AddLast 이후 값은 {newLL.ToString()}");

            DataStructure.LinkedListNode<int> find_Node = newLL.FindLast(5);

            //추가 Add Before/After 
            newLL.AddAfter(find_Node, 4);
            Console.WriteLine($"AddAfter(5) 이후 4 추가 {newLL.ToString(" & ")}\t");


        }
    }
}