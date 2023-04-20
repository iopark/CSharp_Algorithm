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
            Console.WriteLine($"AddLast(5), AddFirst(0) 이후 값은 {newLL.ToString()}");

            DataStructure.LinkedListNode<int> find_Node = newLL.Find(2);

            //추가 Add Before/After 
            newLL.AddAfter(find_Node, 4);
            Console.WriteLine($"AddAfter(5) 이후 4 추가 {newLL.ToString(" & ")}\t");
            DataStructure.LinkedListNode<int> find_ = newLL.Find(5);
            newLL.AddBefore(find_, 10);
            Console.WriteLine($"AddBefore(5) 이후 10 추가 {newLL.ToString(" & ")}\t");

            //Remove // RemoveLast// Removefirst 
            newLL.Remove(10);
            Console.WriteLine($"10 삭제, 0, 5 삭제 {newLL.ToString(" | ")}\t");
            newLL.RemoveLast(); 
            newLL.RemoveFirst();
            Console.WriteLine($"10 삭제, 0, 5 삭제 {newLL.ToString(" | ")}\t");


        }
    }
}