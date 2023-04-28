using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day25_Task
{
    // 2번문제 구현: N 과 M (3)
    internal class Program
    {
        public static StringBuilder sb = new StringBuilder(); 
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            string[] str_list = str.Split(" ");
            int limit = int.Parse(str_list[0]);
            int index = int.Parse(str_list[1]);
            int[] array = new int[index]; // if 2 , make list length of 2 , with int val 

            GetVal(limit, index, array, 0); 
        }

        static void GetVal(int N, int M, int[] array, int index)
        {
            //base case 
            if (index >= M-1)
            {
                return;
            }
            for (int i = 0; i <= N; i++)
            {
                array[index] = i;
                sb.Append();
                if (i >= N)
                {
                    return;
                }
            }

            for (int i = 1; )
            GetVal(N, M, array, index+1); // do something to reach the base case 
        }

    }
}
