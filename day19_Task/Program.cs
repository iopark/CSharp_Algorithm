using System.ComponentModel.DataAnnotations;

namespace day19_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            DataStructure.LinkedList<string> newLL = new DataStructure.LinkedList<string>();
            DataStructure.LinkedListNode<string> newLL_Node = new DataStructure.LinkedListNode<string>("test"); 
            //연결 리스트 Add First/Last 
            newLL.AddFirst("test");
            newLL.AddFirst("first");
            newLL.AddLast("Last");

            DataStructure.LinkedListNode<string> target_AddBefore = new DataStructure.LinkedListNode<string>("test");
            //추가 Add Before/After 
            //newLL.AddBefore()
            

        }
    }
}