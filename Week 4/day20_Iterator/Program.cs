using System.Security.Cryptography.X509Certificates;

namespace day20_Iterator
{
    // 당분간 인터페이스를 통해서 query based 기능들에 익숙해 질때까지 ICollectible,
    // 그리고 IEnumerable 은 포함시키고 사용해주도록 하자 

    internal class Program
    {
        void Main1()
        {
            List<string> list = new List<string>();
            Console.WriteLine("Hello, World!");
            LinkedList<int> intList = new LinkedList<int>(); 

            for (int i = 1; i <= 5; i++)
            {
                intList.AddLast(i); 
            }

            for (int i = 0; i < intList.Count; i++)
            {
                //Console.WriteLine(intList[i]); // this doesn't work for the linked list 
            } //not easily accessible for enumerating /interface/ functions 

            //declare node first 
            LinkedListNode<int> node = intList.First;
            //traverse through the nodes 
            while (node != null)
            {
                Console.WriteLine(node.Value);
                Array.Sort
                
                node = node.Next; 
            }
            int[] test = { 1, 2, 3, 4 }; 

            // 배우게 될 것들 
            Stack<int> stack; 
            Queue<int> queue = new Queue<int>();
            //SortedList, SortedSet, SortedDictionary, Dictionary 

            //반복기를 이용한 순회 
            // Foreach function 은 Enumerator 반복기를 통한 반복자인데, 
            // 거의 모든 
            
            
            // 반복기 직접 조작 
            List<string> strings = new List<string>();
            for (int i = 0; i < 5; i++) strings.Add($"{i}데이터");
            IEnumerator<string> iter = strings.GetEnumerator(); // 인터페이스 변수를 이미 기능이 입력된 string class를 통해서 생성 
            iter.MoveNext(); // IEnumerator 인터페이스의 기능을 구현/물론 해당 기능의 definition 은 string을 통해서 완성이 되어있음 
            Console.WriteLine(iter.Current); // can summon the current data 
            iter.Reset(); // returns back to the first element of the data structure/ is it standard Template library 

            while (iter.MoveNext()) // would shift to next element, until element are found no more, returns false 
            {
                Console.WriteLine(iter.Current); 
            }

           
        }
        static void Main(string[] args)
        {
            Iterator.List<int> list = new Iterator.List<int>(); 
            for (int i = 1; i <= 5; i++) list.Add(i);

            //IEnumerator<int> listIter = list.GetEnumerator(); // brings IEnumerator functions/ given that these are defined in the List Class 
            //while (listIter.MoveNext())
            //{
            //    Console.WriteLine(listIter.Current);

            //}
            foreach (int i in list) // this works because class List now contains IEnumerable<T>
            {
                Console.WriteLine(i); 
            }
            Iterator.LinkedList<int> linkedList = new Iterator.LinkedList<int>();
            for (int i = 1; i <= 5; i++) linkedList.AddLast(i); 

            foreach (int i in linkedList)
            {
                Console.WriteLine(i); 
            }
        }
        // 반복기를 활용한 기능 구현도 가능하겠다. 
        public void Find(IEnumerable<int> container, int value)
        {
            //IEnumerable<int> iter = container.GetEnumerator(); 

        }
    }
}