using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day22_Task
{
    public class Findmedian
    {
        /* 많은 예시들을 찾아본 결과, 힙 자료구조는 어떤 자료 stream 에 대해서 처리하는 것이 용이한 자료구조이다 
         * 크기가 정해져 있는 결과 값을 다루는 상황이 아닌경우, 값을 처리하기 위해 해당 자료구조를 사용하는데, 
         * 일시적인 기준을 설립하고, 나오는 다양한 출력물에 따라서 기준을 바꿈으로써, 
         * 원하는 값에 도달하게 하는 형태의 알고리즘이었다. 
         */ 

        // 해당 자료구조가 이런 데이터 스트림에 유용한 까닭은 time Complexity 가 
        // 일반적으로 List.Sort 하고, Findindex하는것보다 더 '효율'적이기 때문이다. 
        // where List Sort(O(n)), for every update is O(n^update) 
        // whereas in PriorityQueue, Sort(O(log N) where base is 2, 
        // for every update, PriorityQueue < Array.Sort in terms of Big O 

        public float median;
        DescHeap descHeap;
        public PriorityQueue<int,int> desc;
        AscHeap ascHeap;
        public PriorityQueue<int,int> asc;
        public Findmedian(DescHeap descHeap, AscHeap ascHeap)
        {
            this.median = 0; // 우선 0을 시작점으로 두고 값을 입력받는다! 
            this.desc = descHeap.heap;
            this.asc = ascHeap.heap;
            this.descHeap = descHeap;
            this.ascHeap = ascHeap;
        }

        //우선순위 큐의 특성상 가장 우선순위가 상위인 값이 조상노드로 설정됨으로 (Dequeue이후에도 힙정렬이 된다) 
        // 오름차의 첫번째 값은 가장 낮은 값이겠고, 
        // 내림차의 첫번째 값은 가장 높은값이겠다. 
        public void UpdatePQ(int newVal)
        {
            if (median < newVal) //임의 중간값보다 값이 크다면 
            {
                desc.Enqueue(newVal, newVal);
            }
            else // 중간값보다 작다면 오름차 힙에 입력한다. 
                asc.Enqueue(newVal, newVal);
        }

        public void BalanceHeap()
        {
            // 만약 오름차에 지정되는 값이 많아진다면, median ~ Minimum val 
            // 내림차에 값을 넣어줌으로써 중간값을 조금더 max 근처에 가게 한다. 
            if (desc.Count < asc.Count +1) 
            {
                desc.Enqueue(asc.Peek(), asc.Dequeue());
            }
            // 만약 내림차에 저장되는 값이 더 많아지는 형국이라면,
            // 가정된 중간값이 내림차, 즉 가장 높은값에 더 근접했다고 디덕션 할수 있겠다. 
            // 마찬가지로 미니멈 값에 더 근접하게 함으로써 최종 중간값을 찾아간다. 
            else if (desc.Count + 1 > asc.Count)
            {
                asc.Enqueue(desc.Peek(), desc.Dequeue());
            }
        }
        public void UpdateMedian ()
        {
            int tempMax = descHeap.Max(); 
            int tempMin = ascHeap.Min();
            // 중간값의기준 1:만약 오름차와 내림차가 같다면, 
            // 2. 만약 오름차가 내림차보다 많다면 
            if (desc.Count > asc.Count) // 만약 내림차의 힙이 오름차 보다 더 많은 값을 저장하고 있다면, 
            {
                Max = tempMax; 
            }

            this.Max = descHeap.Max(); 
            this.Min = ascHeap.Min();
        }


    }
    public class DescHeap
    {
        public PriorityQueue<int, int> heap;
        public int maxVal; 
        public DescHeap()
        {
            this.heap = new PriorityQueue<int, int>(Comparer<int>.Create((a,b)=> b-a));
        }
        public int Max()
        {
            this.maxVal = heap.Peek();
            return this.heap.Peek();
        }
    }

    public class AscHeap
    {
        public PriorityQueue<int,int> heap;
        public int minVal;
        public AscHeap()
        {
            this.heap = new PriorityQueue<int,int>();
        }
        public int Min()
        {
            this.minVal = heap.Peek();
            return this.heap.Peek();
        }
    }
}
