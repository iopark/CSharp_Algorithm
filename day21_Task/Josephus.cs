using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day21_Task
{
    // my brotha Joesephus likes to gather around his people before starts killing them in a pattern until there's a single survivor

    /* Program must provide, N, and K 
     * where N is the total number of people 
     * and K is the starting position which the killing begins (where starting point prior to K is 0) 
     * Find the position of the last survivor https://brilliant.org/wiki/josephus-problem/ 
     * 예시: N 8, K 4 
     * [1][2][3][#][5][6][7][8] count 7, index 3 gone
     * [1][2][3][#][5][6][7][#] count 6 index 7 gone 
     * [1][2][3][#][#][6][7][#] count 5 index 4 gone
     * [1][#][3][#][#][6][7][#] count 4 index 1 gone 
     * [#][#][3][#][#][6][7][#] count 3 index 0 gone
     * [#][#][#][#][#][6][7][#] count 2 index 2 gone 
     * [#][#][#][#][#][6][#][#], 6 survives, index 6 gone 
     */

    // 음 큐를 어떻게 활용할수 있을까? (큐가 확장형이 아닌 사이즈가 명시된 상황에서 순환형이라면) 
    /* FiFo 자료구조형에 대해 응용해본다면 디큐를 하는데, k번째 디큐에 대해서는 다른 큐에 저장하지 않는다면 어떨까? 
     * 1,2,3,5,6,7,8 (4)저장 안됨 
     * 1,2,3,6,7,8 (5) 저장 안됨 
     * 1,2,
     */

    // 생각보다 큐를 이용한다면 간단하게 해결할수 있을거 같다 
    internal class Josephus
    {
        public int N { get; set; }
        public int K { get; set; }
        public Task_DataStructure.Queue<int> Queue; 
        public int survivor;

        public Josephus(int count, int k) 
        {
            Generate(count); 
            this.K = k;
        }
        public void Generate(int count) 
        {
            this.Queue = new Task_DataStructure.Queue<int>();
            for (int i = 0; i < count; i++) Queue.Enqueue(i);
        } 

        public void Trigger()
        {
            while (this.Queue.Count > 1) 
            {
                
            }
        }

    }
}
