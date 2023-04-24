using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class PriorityQueue<TElement>
    {
        private struct Node
        {
            public TElement element; 
            public int priority;
        }

        private List<Node> nodes; // List 를 이용한 Adaptee 객체로 만들어보도록 하자 
        //private IComparer<TPriority> comparer;

        public PriorityQueue()
        {
            this.nodes = new List<Node>();
        }

        public int Count { get { return nodes.Count; } }

        public void Enqueue(TElement element, int priority) 
        {
            Node newNode = new Node() // '노드' 구조체는 이곳에서 즉석 생성하고 힙상태 유지를 위한 작업을 시작한다. 
            {
                element = element,
                priority = priority
            };
            int newNodeIndex = nodes.Count - 1; // 힙상태 복구전 우선적으로 마지막 값으로 위치시킨다. 

            // 2. 새로운 노드를, 힙상태가 유지되도록 승격 작업 반복
            while ( newNodeIndex > 0 ) 
            {
                // 2.1 부모 노드 확인 
                int parentIndex = GetParentIndex(newNodeIndex); 
                Node parentNode = nodes[parentIndex];

                if (newNode.priority < parentNode.priority) // 만약 신입의 우선순위가 임의부모의 노드우선순위보다 높다면, 
                {
                    nodes[newNodeIndex] = parentNode; // 부모의 노드는 자식노드 위치에, 
                    nodes[parentIndex] = newNode; // 자식은 부모노드 위치로 스왑시켜준다. 
                    newNodeIndex = parentIndex; // 올라간 신입의 인덱스 또한 업데이트 시켜준다. 
                }
                else
                    break;
            }
        }
        /// <summary>
        /// 이 기능으로 인해서 
        /// </summary>
        /// <returns></returns>
        public TElement Dequeue()
        {
            Node rootNode = nodes[0];

            // 최상단 노드가 빠진이후 의 후처리 
            // 1. 가장 마지막위치의 노드 최상단으로 위치 

            Node lastNode = nodes[nodes.Count - 1]; //마지막 위치값 lastNode로 설정 
            nodes[0] = lastNode; //최상단으로 위치 
            nodes.RemoveAt(nodes.Count - 1); // 이후 배열의 마지막값을 삭제한다. 
            //이는 리스트로 구현된 힙자료구조이기에, 최상단값을 빼면서 배열 자료구조를 효율적으로 유지하며 재정립하기 위해 이같이 한다 ~O(log N) 

            // 2. 자식 노드들과 비교하며 더 작은 자식과 교체 반복 하는데, 
            int index = 0; 
            while (index < nodes.Count) // index 가 nodes.Count보다 작을때까지만 함으로써, 자식클래스중 마지막 자식클래스 값중 하나로 반환시키게 한다 
            {
                int leftChildIndex = GetLeftChildIndex(index);
                int rightChildIndex = GetRightChildIndex(index);

                // 2.1. 자식이 둘다 있는 경우 
                if (rightChildIndex < nodes.Count) // index < list.Count로 합당한 index인지 간단하게 확인이 가능하다. 
                {
                    // 2.1.1 L_R 중 우선순위가 더 높은 쪽과 비교한다. (where Lower Number = Higher priority)
                    // Q: 왜 더 높은 우선순위와 교체해야 하는가?
                    // 원하는 결과는 _힙상태의 복원이다_, 위 - 아래 교체하는 기준으로, L_R둘다 있다면 더 우위에 있는값이 올라해야지만 힙상태가 유지가 될것이다. 
                    // 그렇기에
                    int lessChildIndex = nodes[leftChildIndex].priority < nodes[rightChildIndex].priority ? 
                         leftChildIndex : rightChildIndex;
                    // 2.1.2 더 우선순위가 높은 자식과 부모 노드를 비교하며 
                    // 부모가 우선순위가 더 낮은 경우 바꾸기를 시전한다. 
                    if (nodes[lessChildIndex].priority < nodes[index].priority)
                    {
                        nodes[index] = nodes[lessChildIndex];
                        nodes[lessChildIndex] = lastNode;
                        index = lessChildIndex;
                    }
                    else
                    {
                        break;
                    }
                }
                // 2.2 자식이 하나만 있는 경우는
                // (list의 특성상 왼쪽값만 존재할때로 귀결될수 있다) 
                else if (leftChildIndex < nodes.Count) // this already assumes the child index does not have a right index
                {
                    // 자식 우선순위값과 비교하는 우선순위 값을 비교후, 
                    if (nodes[leftChildIndex].priority < nodes[index].priority) // 
                    {
                        nodes[index] = nodes[leftChildIndex];
                        nodes[leftChildIndex] = lastNode; 
                        index = leftChildIndex;
                    }
                    else
                    {
                        break;
                    }
                }
                // 2.3. 자식이 없는 경우 
                else
                {
                    break; 
                }
            }

            return rootNode.element; 
        }
        public TElement Peek()
        {
            return nodes[0].element; 
        }
        public int GetLeftChildIndex (int parentIndex)
        {
            return parentIndex * 2 + 1;
        }
        public int GetRightChildIndex(int parentIndex)
        {
            return parentIndex * 2 + 2;
        }

        private int GetParentIndex(int childindex)
        {
            return (childindex - 1) / 2; // 부모 노드 찾는 공식을 적용시킨 기능함수를 제작함으로써 제작된 프로그램의 가시성을 높인다. 
        }

        
        //public PriorityQueue(IComparer<TPriority> comparer) // 생성자 오버로딩, IComparer기능이 있는 값이 들어오게 될때에는,
        //                                                    // 우선순위를 매기는 매개체는 매개변수의 자료형의 default Sort 가 적용된다.  
        //{
        //    this.nodes = new List<Node>();
        //    this.comparer = comparer; 
        //}
        //기존으로 생성된 힙 자료구조에 새로운 값을 넣으려면 어떻게 해야 할까 
        //우선 비어있는 인덱스로 넣어주고, 우선순위를 부모(임의)의 순위값과 비교하고, 비교값에 따라 스왑하며 상위 노드로 계속 전진한다
        //, (다시 힙상태가 될때까지)
    }
}