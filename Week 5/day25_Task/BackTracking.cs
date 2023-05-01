using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day25_Task
{
    // 2번문제 구현: N 과 M (3)
    internal class Backtrack
    {

        public class Solution
        {
            public StringBuilder sb = new StringBuilder();
            int[] array;
            int limit;
            int index;

            public void Run()
            {
                string str = Console.ReadLine();
                string[] str_list = str.Split(" ");
                limit = int.Parse(str_list[0]);
                index = int.Parse(str_list[1]);
                array = new int[index]; // if 2 , make list length of 2 , with int val 

                GetVal(0); // Start from the index 0, 그것이 유분수지.
                Console.WriteLine(sb.ToString()); 
            }
            /// <summary>
            /// 재귀를 통해서 세팅한 마지막 index까지 간후, 마지막 index에 들어간 항목까지 들어간 값을 strinbuilder에 추가하며, 값을 반환합니다 
            /// 해당 기법은 Backtracking 으로, 불가능한 수에 대해서는 index로 측정하며, 정한 index 밖까지 값을 측정한다면 불가능에 해당합니다. 
            /// 또한 백트래킹을 하는 시점으로는 불가능에 도달한 바로 그 이전 시점으로 돌아갑니다. 
            /// </summary>
            /// <param name="loc"></param>
            public void GetVal(int loc)
            {
                int next_loc = loc + 1; 
                //Base Case 
                if (index < next_loc)
                {
                    foreach (int i in array)
                    {
                        sb.Append(i + " ");
                    }
                    sb.AppendLine();
                    return; // 어떠한 재귀의 끝을 알립니다. 
                }
                //An smaller algorithm that 이 함수를 통해서 베이스케이스에 도달하게 할수 있습니다.
                //1 을 시작으로 분할정복하며 값을 찾기도 하고, 가능한 모든 경우의 수를 따질수 있습니다. 
                // Where for this problem, M >= N, 이런식으로 설정해주어도 문제는 없습니다
                //
                for (int i = 1; i <= limit; i++) //print 1 to the limit
                {
                    array[loc] = i; 
                    GetVal(next_loc);
                }
                //Function to Get to the BaseCase 
            }
        }
        
        static void Main_Backtrack()
        {
            Solution solution = new Solution(); 
            solution.Run();
        }

    }
}
