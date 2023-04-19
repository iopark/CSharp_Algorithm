using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    /* 1. LinkedList 구현해보기 AddFirst/Last, AddBefore/After, <T>/void Remove, Find 우선 구현 
 *  +++++++++++ 주석 추가 
 *  2. LinkedList 기술면접 준비 
 *  0. C# LinkedList 참고해서 최대한 모든 기능 구현해보기 
 *  Contains, FindLast, RemoveFirst, RemoveLast 추가 구현 하기 
 *  교수님한테 확인 받기  
 */

    public class LinkedListNode<T>
    {
        internal LinkedList<T>? list;
        public LinkedList<T> List { get{ return list;} }
        internal LinkedListNode<T>? prev;
        public LinkedListNode<T> Prev { get { return prev; } }

        internal LinkedListNode<T>? next;
        public LinkedListNode<T> Next { get { return next; } }
        internal T? item; 
        public T Value
        { get { return item; } set { item = value; } }

        public LinkedListNode (T Value)
        {
            this.list = null;
            this.prev = null;
            this.next = null;
            this.item = Value; 
        }

        public LinkedListNode (LinkedList<T> list, T value)
        {
            this.list = list;
            this.prev = null;
            this.next = null;
            this.item = value; 
        }

        public LinkedListNode (LinkedList<T> list, LinkedListNode<T> prev, LinkedListNode<T> next, T value)
        {
            this.list = list;
            this.prev = prev;
            this.next = next;
            this.item = value;
        }


    }
    public class LinkedList<T>
    {
        // 노드는 노드가 소속되는 리스트 인스턴스이름, 순서적으로 이전 prev, 순서적으로 이후인 next,
        // 마지막으로 값인 item 을 지니게 되는데, 이것을 지닌 리스트는, 노드들을 지니지만, 
        // 자료구조로써 가장 중요하게 여기는건 애석하게도 head, tail 그리고 가지고 있는 노드의 숫자 뿐이다 
        private LinkedListNode<T> head;
        public LinkedListNode<T> Head { get { return head; } }
        private LinkedListNode<T> tail;
        public LinkedListNode <T> Tail { get { return tail; } }
        private int count; 
        public int Count { get { return count; } }

        public LinkedList()
        {
            this.head = null;
            this.tail = null;
            this.count = 0; 
        }
        public LinkedListNode<T> AddFirst(T value) 
        {
            // 1. 노드들의 순서정리에 앞서 우선 새로운 노드 생성
            LinkedListNode<T> node = new LinkedListNode<T>(this, value);
            // 관계정리 
            if (head != null)
            { // 리스트의 해드에 뭐가 들었다면 
                head.next.prev = node; // head.next 의 prev 는 head 였음으로 이렇게 연결해줄수도 있겠다. 
                head = node; // head 는 생성된 노드로 착지
            }
            else
            { // if head's null, there's nothing here 
                head = node;
                tail = node;
            }
            head.next = node; // 조건문 이후에 상관없이 해당되는 명령문들 
            count++; // welcome to the Linked_List club 
            return node;      
        }
        
        public LinkedListNode<T> AddLast(T value)
        {
            // Part of LinkedList instance's function, 
            // 1. Declare new Node, which must hold value to store, prev/next to allocate itself correctly, and the instance the node belongs to 
            LinkedListNode<T> lastNode = new LinkedListNode<T>(this, value); // since this is a function within a linked_list instance, 

            // Replicating the AddFirst format, 
            if (tail != null) // 2.1 applies here 꼬리가 있다면?
            {
                 // 이 생성되는 노드가 가리키는 다음노드는? null 이여야 한다. 
                // 이 생성되는 노드가 기리키는 이전노드는? 이전의 tail이여야 하며 
                // tail.next 를 가리키는 곳은? 이 노드여야한다. 
                // 마지막으로 이 Linked_List instance 의 tail에 해당되는 노드는? 이 노드여야한다. 
                tail.prev.next = lastNode; // 꼬리의 이전의 다음은 꼬리의 연결사항을 이것으로 지정하고,
                                           // 이것은 꼬리가 되어 연결을 마친다. 
                tail = lastNode; 
                // 근데 만약 tail.prev 가 head 가 된다면? x 가정필요가 없다 
            }
            else // 꼬리가 없어? 그럼 아무것도 없지 
            { // we can just assume this is the very first node for this Linked_List instance 
                tail = lastNode;
                head = lastNode;
            }
            // 마찬가지로 조건문 이후 해당되는 것들 
            tail.prev = lastNode; 
            count++; // welcome to Linked_List club 
            return lastNode;
            // 2-2.

            // 3. Declare this specific(because we are setting up this as last node;
            // following node as a Tail for this Linked List 
        }
        /// <summary>
        /// Adds the specific new node, after the specified existing node in the Linked List 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="newNode"></param>
        public void AddAfter(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            newNode = AddAfter(node, newNode.item);
        }
        //===================== vs =======================
        //I guess the difference here is in the user's preferred style of declaring/adding new node?
        public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value)
        {
            ValidateTest(node);// run dam tests to see if there's any exception errors 
            // 1. Declare/create new node for this Linked_List 
            LinkedListNode<T> afterNode = new LinkedListNode<T>(this, value);
            // 2. Basing off the node in the parameter, reallocate the creating node in appropriate region
            //    In this case, node.prev must be the node, and the node.next must be node.next 
            // Case to watch out for:
            // 2 - 1.What if the node was the Tail/ Head node? the only node?
            // check node.next == null 
            // 2 - 2. What if the node was the Last node? How do we know when to set this as a tail?
            // same as 2- 1, run to see node.next == null 
            // 그렇다면, 명령문의 패턴은 node.next == null 해당 조건문으로만 갈라주면 될거 같다. 
            // no need ||[node.prev]|| [node] [afterNode] [node.next]
            node.next.prev = afterNode; // even if this was the tail, would draw the relationship properly
            afterNode.next = node.next.prev; // 삽입되는 노드의 다음좌표를 이전node 
            afterNode.prev = node;
            //node.next = afterNode; // 이건 이제 확인 작업이 필요하다 node.next == null; 
              
            if (node.next != null) // 이전의 노드의 다음값이 꼬리가 아니었다면, 
            {
                node.next = afterNode;
            }
            else
                tail = afterNode;
            count++;
            return afterNode;
            // 
            // 3. 
        }
        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value) 
        {
            ValidateTest(node);
            LinkedListNode<T> beforeNode = new LinkedListNode<T>(this, value);
            // AddAfter와 비슷하게 생성
            // 
            return beforeNode;

        }
        public void Clear() 
        {
            //노드 전부 박-멸 
            // head& tail 자르면 모두 사실 연결이 잘리므로 기능구현에 해당한다고 볼수 있겠다. 
            this.tail = null;
            this.head = null;
            count = 0;
        }

        public void Contains(T value) { }
        //TODO: AddBefore feature
        //public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value) { }

        //TODO: Find feature 
        //public LinkedListNode<T>? Find (T value) { }

        //TODO: FindLast feature 
        //public LinkedListNode<T>? FindLast(T value) { } 

        //TODO: Remove feature 
        public void Remove (LinkedListNode<T> node) { }

        private void ValidateTest (LinkedListNode<T> node)
        {
            //해당 행동명령들은 다른 함수에서도 자주자주 사용되기에 이렇게 함수로 제작하면 
            // 항상 재사용을 할수 있다. 
            if (node == null)
                throw new ArgumentNullException();
            if (node.List != this)
                throw new InvalidOperationException(); 
        }

        public void Printf(LinkedList<T> list, LinkedListNode<T> list_Node, T Value)
        {
            list_Node = new LinkedListNode<T>(list, Value); 
            
        }
    }
}
