using System.Collections;
using System.Runtime.CompilerServices;

namespace day20_Task
{
    /* 1. List, LinkedList IEnumerable 구현 하기 
     * 2. foreach 에 List, LinkedList 반복확인 
     * 
     * ========================================================
     * 추가 3. 반복기 (Iterator) - Design Pattern 반복자 기술 면접 준비 
     * ========================================================
     * 추가추가: 
     * Sort (배열), Sort(List) 둘 모두 정렬 가능한 하나의 함수 구현 
     * 1. List: IList<T> 내용 구현 
     * 2. 자료구조의 평균을 구하는 Average(자료구조) 구현 
     */ 

    internal static class Program
    {

        // Array, List = IList, 
        // Array, List = Object 
        // Array, List = IEnumerable 
        // IComparer => object 
        // 
        public static double Average(IEnumerable<int> container) 
        {
            double sum = 0;
            int count = 0; 
            foreach(int item in container)
            {
                sum += item;
            }

            return sum / count;
        }

        public static int Max(this IEnumerable<int> container) // 확정매서드: this 를 매개변수에 활용한 사례
        {
            int max = int.MinValue; // 우선적으로 가장 낮은 값부터 (int자료형의) 
            foreach (int item in container)
            {
                if (item > max)
                    max = item; 
            }
            return max; 
        }
        
        static void Main(string[] args)
        {
            day20_Task.List<int> list = new day20_Task.List<int>(); 
            for (int i = 1; i <= 5; i++) list.Add(i);

            IEnumerator<int> list_iterate = list.GetEnumerator();
            list_iterate.Reset(); 
            while (list_iterate.MoveNext())
            {
                int value = list_iterate.Current;
                Console.WriteLine(value); 
            }
            
            foreach(int i in list)
            {
                Console.WriteLine(i);
            }

            day20_Task.LinkedList<int> linkedList = new day20_Task.LinkedList<int>();
            for (int i = 1; i <= 5; i++) linkedList.AddFirst(i);
            Console.WriteLine($"저장된 값 {linkedList.ToString(" >> ")}");
            Console.Write("IEnumerable 작동확인 값: using foreach() "); 
            foreach (int i in linkedList)
            {
                Console.Write($" {i}");
            }
            //=============================iList================================


            int[] array = new int[] { 1, 2, 3, 4, 5 };
            ArrayList arrayList = new ArrayList();
            for (int i = 5; i >= 1; i--) arrayList.Add(i); 

            foreach (int i in array) Console.WriteLine(i);
            foreach (int i in arrayList) Console.WriteLine(i);

            Average(array);
            Average(linkedList); // this is also viable because it holds IEnumerable 
            Average(list); // this is also true too/ 

            //this way, 어떤함수를 제작할때에, 매개변수로 인터페이스 변수를 받는 매개변수를 설정하여주면 
            // 보다 포괄적으로 다양한 자료구조형에 대해서 응용이 가능한 함수를 생성해줄수 있다 

            // when we design for the whole / large system, and when we design each objects, 
            // if we are able to place ourselves in selective interfaces, 
            // we'll be able to 'effectively' design our functions for various data_structures. 


        }
    }
}