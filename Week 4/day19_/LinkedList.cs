//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

///* 1. LinkedList 구현해보기 AddFirst/Last, AddBefore/After, <T>/void Remove, Find 우선 구현 
// *  +++++++++++ 주석 추가 
// *  2. LinkedList 기술면접 준비 
// *  0. C# LinkedList 참고해서 최대한 모든 기능 구현해보기 
// *  Contains, FindLast, RemoveFirst, RemoveLast 추가 구현 하기 
// *  교수님한테 확인 받기  
// ////*/ 
//namespace DataStructure
//{
//    public class LinkedListNode<T>
//    {
//        //LinkedList는 노드로 구성되어있는 non-Continuous, 노드기반 자료 구조 입니다 
//        // 때문에 리스트를 구성하기 전, 해당 객체를 구성하는 노드를 구성합니다 
//        internal LinkedList<T> list; // 해당 노드를 포함하는 연결 리스트 이름 // or name it list_instance 
//        internal LinkedListNode<T> prev; //because must be accessible with LinkedList, turn private -> internal
//        internal LinkedListNode<T> next;
//        internal T item; 

//        public LinkedListNode<T> Prev { get { return prev; } }
//        public LinkedListNode<T> Next { get { return next; } }
//        public LinkedList<T> List { get { return list; } }
//        public T Value { get { return item; } set { item = value; } }

//        public LinkedListNode(T value)
//        {
//            this.list = null;
//            this.prev = null;
//            this.next = null;
//            this.item = value; 
//        }

//        public LinkedListNode(LinkedList<T> list, T value)
//        {
//            this.list = list;
//            this.prev = null;
//            this.next = null;
//            this.item = value; 
//        }

//        public LinkedListNode(LinkedList<T> list, LinkedListNode<T> prev, LinkedListNode<T> next, T value)
//        {
//            this.list = list;
//            this.prev = prev;
//            this.next = next;
//            this.item = value; 
//        }
//    }
//    public class LinkedList<T>
//    {
//        //Dealing with the doubly, each holds node, value, and node 
//        private LinkedListNode<T>? head;
//        private LinkedListNode<T>? tail;
//        private int count; 

//        public LinkedList()
//        {
//            this.head = null;
//            this.tail = null; 
//            this.count = 0; 
//        }
//        public LinkedListNode<T> First { get { return head; } }
//        public LinkedListNode<T> Last { get { return tail; } }
//        public int Count { get { return count; } }


//        public LinkedListNode<T> AddFirst(T value) 
//        { 
//            // 1. 새로운 노드 생성
//            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);
//            // 2. 연결구조 바꾸기 
//            if (head != null) // 2-1. Head Node가 있었을 때 
//            {
//                newNode.next = head; // 참조형식을 이용하여 새로운것을 가리키게 한다 
//                head.prev = newNode;
//                // 3. 새로운 노드를 head 노드로 지정 
//                head = newNode;
//            }
//            else
//            {
//                head = newNode;
//                tail = newNode; 
//            }
//            this.count++; //because tada, there's a node now in this specified instance 
//            return newNode; 
//        }

//        public LinkedListNode<T> AddLast(T value)
//        {
//            // Part of LinkedList instance's function, 
//            // 1. Declare new Node, which must hold value to store, prev/next to allocate itself correctly, and the instance the node belongs to 
//            LinkedListNode<T> lastNode = new LinkedListNode<T>(this, value); // since this is a function within a linked_list instance, 

//            // 2. Redirect/ Relocate the following Node to appropriate location : for the AddLast to the linked_List
//            // 2-1. if tail already exists, 
//            if (this.tail != null) // 2.1 applies here 
//            {
//                // 1. declare this as the tail (Linked_List),
//                // 2. declare Node's prev and next node
//                // 3. Return this Node 
//                lastNode.next = null; // 이 생성되는 노드가 가리키는 다음노드는? null 이여야 한다. 
//                lastNode.prev = tail; // 이 생성되는 노드가 기리키는 이전노드는? 이전의 tail이여야 하며 
//                tail.next = lastNode; // tail.next 를 가리키는 곳은? 이 노드여야한다. 
                                      
//                tail = lastNode; // 마지막으로 이 Linked_List instance 의 tail에 해당되는 노드는? 이 노드여야한다. 
//            }
//            else // if tail does not exists, 
//            { // we can just assume this is the very first node for this Linked_List instance 
//                tail = lastNode;
//                head = lastNode; 
//            }
//            this.count++; 
//            return lastNode;
//            // 2-2.

//            // 3. Declare this specific(because we are setting up this as last node;
//            // following node as a Tail for this Linked List 
//        }
//        /// <summary>
//        /// Adds the specific new node, after the specified existing node in the Linked List 
//        /// </summary>
//        /// <param name="node"></param>
//        /// <param name="newNode"></param>
//        public void AddAfter (LinkedListNode<T> node, LinkedListNode<T> newNode)
//        {
//            newNode = AddAfter(node, newNode.item);
//        }
//        //===================== vs =======================
//        //I guess the difference here is in the user's preferred style of declaring/adding new node?
//        public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value)
//        {
//            // 1. Declare/create new node for this Linked_List 
//            LinkedListNode<T> afterNode = new LinkedListNode<T> (this, value);
//            // 2. Basing off the node in the parameter, reallocate the creating node in appropriate region
//            //    In this case, node.prev must be the node, and the node.next must be node.next 
//            // Case to watch out for:
            
//            if (node == null)
//                throw new ArgumentNullException();
//            if (node.List != this)
//                throw new InvalidOperationException();
//            // 2 - 1.What if the node was the Tail/ Head node? the only node?
//            // 2 - 2. What if the node was the Last node? How do we know when to set this as a tail?
//            node.next.prev = afterNode.prev; 
//            afterNode.prev = node;
//            if (node.next != null)
//            {
//                node.next = afterNode;
//                afterNode.next = node.next.next; 
//            }
//            else
//                tail = afterNode; 
//            count++;
//            return afterNode; 
//            // 
//            // 3. 
//        }
//        /// <summary>
//        /// Similar 
//        /// </summary>
//        /// <param name="node"></param>
//        /// <param name="value"></param>
//        /// <returns></returns>
//        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
//        {
//            // 예외처리 
//            if (node == null)
//                throw new ArgumentNullException();
//            if (node.List != this)
//                throw new InvalidOperationException(); 
//            // 1.노드 선언
//            LinkedListNode<T> priorNode = new LinkedListNode<T>(this, value); 
//            // 2. 연결구조 바꾸기 

//            // Check if head is the previous node 

//            priorNode.next = node;
//            priorNode.prev = node.prev;
//            node.prev.next = priorNode.prev; // if node. prev is null, null's.next is priorNode anyhow. 
//            if (node.prev != null)
//                node.prev = priorNode;
//            else
//                head = priorNode; 

//            count++;
//            return priorNode; 
//        }

//        public void Clear() { }

//        public void Contains(T value) { }


//        public void Remove(LinkedListNode<T> node)
//        {
//            //해당 기능을 구현하기 위해서는, 기존에 있을, 연결된 노드들을 생각해보고 구현하는것이 좋다 
//            // 예외사항 처리 우선, 
//            // 예외 1. perform only when node is in this instance 
//            if (node.list != this)
//                throw new InvalidOperationException();
//            // 예외 2. only erase if following is not a null 
//            if (node == null)
//                throw new ArgumentNullException();
//            // 0. 지웠을때 , head 나 tail 이 변경되는 경우 적용 
//            if (head == node)
//                head = node.next;
//            if (tail == node)
//                tail = node.prev;
//            // 1. 연결구조 변경해주기 
//            // node's previous node's next should be relocated to point to node.next
//            if (node.prev != null) // perform only if there IS a prev node 
//                node.prev.next = node.next; 
//            if (node.next != null) // similarly to above, only do so if there's next 
//                node.next.prev = node.prev;
//            // 1-2 but what if the node.prev is null 

//            count--; 
//        }

//        public bool Remove(T value)
//        {
//            LinkedListNode<T> findNode = Find(value); // 우선 해당되는 노드 찾기 -> 값을 기준으로 찾는 함수 구현 필요 
//            if (findNode != null)
//            {
//                Remove(findNode);
//                return true;
//            }
//            else
//            {
//                return false; 
//            }
                

//        }

//        public LinkedListNode<T> Find(T value)
//        {
//            LinkedListNode<T> target = head; 
//            // Equal 을 쓰기 싫다면 
//            EqualityComparer<T> comparer = EqualityComparer<T>.Default;

//            while (target != null)
//            {
//                if (comparer.Equals(value, target.Value))
//                    return target;
//                else
//                    target = target.next; // target 또한 노드임으로, next가 있는것을 가정할수 있다 
//            }
//            return null; 
//        }

//    }
//}
