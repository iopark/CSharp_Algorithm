using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Task_DataStructure
{
    /// <summary>
    /// 오늘 실습을 바탕으로 리스트형태의 우선순위큐(힙)을 구현한다. 
    /// 배열로도 트리 자료구조이지만, 완전이진트리를 적용한다면 구현이 가능하다. 
    /// 하지만 리스트로써 작성했을때의 장점은, 힙정렬을 통해서 값을 추가하거나, 삭제하는것에 유연하며, C#의 특성상 
    /// GC부화가 덜 하는 상태에서 삭제, 그리고 삽입이 비교적 자유롭다는 메리트가 있다. 
    /// </summary>
    /// <typeparam name="TElement"></typeparam>
    public class PriorityQueue<TElement>
    {

        /// <summary>
        /// 들어오는 값에 대해서 실존하는 값과, 우선순위를 표기하기 위한 최소한의 단위를 구조체로 생성하여준다. 
        /// </summary>
        private struct Node
        {
            public TElement element;
            public int priority; 
            // IComparable 을 통해서도 값을 지정하여줄수 있으나, 그렇게 할까..? nvm not yet 
            // int의 default Comparer 를 사용하기 때문에, it's Ascending 으로 Sort 되기 때문에 lower Number = higher Priority 으로 설정하고 진행하였다. 
        }

        private List<Node> nodes; 
        public int Count
        {
            get { return nodes.Count; }
        }
        /// <summary>
        /// 최초 선언시, 할건 딱히 없다, 힙구조자료는 List를 돚거/아답트 하여 리스트를 이용하며 새로운 기능을 구현한다. 
        /// </summary>
        public PriorityQueue()
        {
            this.nodes = new List<Node>();
        }
        /// <summary>
        /// 값을 빼거나 삽입하거나 가장중요한것은 힙정렬을 통해 힙상태를 유지해주는 것이다 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="priority"></param>
        public void Enqueue(TElement element, int priority)
        {
            // 새로운 값 생성시, 해당 값은 자연스럽게 리스트의 마지막에 추가가 된다.
            Node newNode = new Node();
            newNode.element = element;
            newNode.priority = priority;

            //nodes[Count-1] = newNode;
            int newIndex = nodes.Count - 1;

            while (newIndex > 0)// 만약 새로운 인덱스값이 0이라면 최초값이기에, 힙정렬을 진행할 이유가 전혀 없을것이다. 
            {
                int parentIndex = GetParentNode(newIndex); 
                Node parent = nodes[parentIndex];

                if (newIndex < nodes.Count)// 멀쩡한 인덱스 값이라면 (List 에서), List의 카운트 보다 항상 작을것이다. // 매우 간단하게 정상적인 index값인지 확인하는 방법이다.  
                {
                    if (nodes[newIndex].priority < nodes[parentIndex].priority)
                    {
                        nodes[parentIndex] = nodes[newIndex];
                        nodes[newIndex] = newNode;
                        parentIndex = newIndex;
                    }
                    else // 더이상 신입이 상위 노드보다 위에 있지 않다면 힙상태 도달 완료 (where Top.Priority > Mid.Priority > Low.Priority) 
                        break;
                }   
            }
        }

        public TElement Dequeue()
        {
            Node ancestor = nodes[0]; // 우선 밖으로 추출할 조상님 저장 (구조체로) 
            Node lastNode = nodes[nodes.Count - 1];
            nodes[0] = lastNode; //힙정렬을 위하여 마지막 값에 저장된 값을 맨앞으로 부르고, 위에서부터 아래로 힙정렬 시전 
            int root = 0; 
            while (root < nodes.Count)
            {
                int L_Index = LChildIndex(root);
                int R_Index = RChildIndex(root);
                // Case 1. There's 2 Child Ndoes 
                if (R_Index < nodes.Count)
                {
                    int target = nodes[L_Index].priority < nodes[R_Index].priority ? L_Index : R_Index;
                    if (nodes[target].priority < nodes[root].priority)
                    {
                        nodes[target] = nodes[root];
                        nodes[root] = lastNode;
                        target = root;
                        root = target;
                    }
                    else
                        break;
                }
                // 이것의 목적은 힙정렬이다. 그러므로 힙상태를 위해 상위클래스는 무조건 더 높은 우선순위를 가진 노드가 올라가야만 한다 
                // Case 2. There's 1 Child Node (Left, given we are working on a List, (if there's only 1, in a binary tree, RemoveAt(마지막)을 통해서 값을 삭제하였기에, 삭제되는 순서는 오른쪽, 왼쪽순으로 간다는것을 전제로 해도 된다.
                else if (L_Index < nodes.Count)
                {
                    if (nodes[L_Index].priority < nodes[root].priority)
                    {
                        nodes[L_Index] = nodes[root];
                        nodes[root] = lastNode;
                        L_Index = root;
                        root = L_Index;
                    }
                    else
                        break;
                }
                else
                    break; 
                // Case 3. 하위노드가 없다. 
            }
            return ancestor.element; 
        }

        public TElement Peek()
        {
            return this.nodes[0].element; 
        }
        //public void Swap(int first, int second, Node n_first)
        //{
        //    nodes[second] = nodes[first];
        //    nodes[first] = n_first;
        //    second = first;
        //}
        public int GetParentNode(int childIndex)
        {
            return (childIndex - 1) / 2;
        }
        private int LChildIndex(int parentIndex)
        {
            return parentIndex * 2 + 1;
        }

        private int RChildIndex(int parentIndex)
        {
            return parentIndex * 2 + 2;
        }

    }
}
