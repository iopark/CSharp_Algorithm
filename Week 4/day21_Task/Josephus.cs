using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    // Queue의 선형구조, Head, Tail 이용 (where Enqueue < Dequeue in occurrence)
    // 해드는 N을 기준으로 계속 돌지만, 테일은 k 를 기준으로 돌기에, 
    // [1,h][2][3][4][5][6][7]
    // 큐는 들어오는값을 기준으로 먼저 빼낼수 있게 하는 기능이 있기에, K 번째 값을 재 삽입하는것을 하지 않으면, 
    // 선형구조에따라 head와 tail 은 꾸준히 돌지만, 
    public class Josephus
    {
        public int N { get; set; }
        public int K { get ; set; }
        public Task_DataStructure.Queue<int> Queue; 
        public int last_survivor;

        public Josephus(int count, int k) 
        {
            this.N = count;
            Generate(count); 
            this.K = k;
        }

        public void Trigger ()
        {
            //Generate(this.K);
            Rotate();
            Console.WriteLine($"최후로 죽은자는 {last_survivor} 번째 사람 입니다");
        }
        public void Generate(int count) 
        {
            this.Queue = new Task_DataStructure.Queue<int>(count);
            for (int i = 1; i <= count; i++) Queue.Enqueue(i); //[H][2][3][4][5][6][7][8][T]
        } 

        public void Rotate()
        {
            while (this.Queue.Count > 1)  
            {
                for (int i = 1; i < K; i++) // if K = 3, 3번만 반복한다. 
                {// 최초 포지션 [H][2][3][4][5][6][7][8][T] where (H = 1), T = null
                    int item = Queue.Dequeue();
                    Queue.Enqueue(item);
                } // 최초 바퀴 이후 [2][3][T][H][6][8][T][][1] (where H = 5, T= null (previously 4)  
                Console.WriteLine(Queue.Dequeue());
            }
            last_survivor = Queue.Peek();
        }
        /* 위의 예시에서 보았듯이, 반복해야할, 하지만 해당 패턴 순서사이에 또다른 명령문을 추가해야하는 기능을 구사할때, 
         * 해당 자료구조는 꼭 필요 해 보인다. 
         * 또한 차차 사라져야하는 요소들에대해서도, Josephus 패턴을 응용하기 좋은 상황에서는 이러한 자료구조가 도움이 될것이다. 
         * 수학과 프로그래밍은 /또한 물리/화학 등 자연과학은 밀접한 관계가 있다. 
         * 모델링을 해야할때, 어떠한 자연적 패턴에 관하여 다룰때, 컴퓨터를 통해서 진행하기 때문인데, 
         * 이에 따라 게임에서, 또는 개발 도중 우리가 익숙한 특정 패턴에 대해서 구현할때에는 이러한 이미 세워진 가설들과, 수학적 정의들을 이용해야할 상황이 분명 있을것으로 생각된다. 
         * 따라서 해당 정의들에 친화적인 자료구조가 이미 있다고 생각할수 있겠고, 조금 더 컴퓨터친화적인 개발자가 되기 위해선 
         * 내가 수학을 그리고 물리를 다시 공부해야할 이유가 나타난다. 
         */ 


    }
}
