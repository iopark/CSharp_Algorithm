using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day20_Task
{

    public class LinkedListNode<T>
    {
        internal LinkedList<T>? list;
        public LinkedList<T> List { get { return list; } internal set { list = value; } }


        internal LinkedListNode<T>? prev;
        public LinkedListNode<T> Prev { get { return prev; } internal set { prev = value; } }

        internal LinkedListNode<T>? next;
        public LinkedListNode<T> Next { get { return next; } internal set { next = value; } }
        internal T? item;
        public T Value
        { get { return item; } set { item = value; } }

        public LinkedListNode(T Value)
        {
            this.list = null;
            this.prev = null;
            this.next = null;
            this.item = Value;
        }

        public LinkedListNode(LinkedList<T> list, T value)
        {
            this.list = list;
            this.prev = null;
            this.next = null;
            this.item = value;
        }

        public LinkedListNode(LinkedList<T> list, LinkedListNode<T> prev, LinkedListNode<T> next, T value)
        {
            this.list = list;
            this.prev = prev;
            this.next = next;
            this.item = value;
        }


    }
    public class LinkedList<T> : IEnumerable<T>
    {

        private LinkedListNode<T> head;
        public LinkedListNode<T> Head { get { return head; } }
        private LinkedListNode<T> tail;
        public LinkedListNode<T> Tail { get { return tail; } }
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
            LinkedListNode<T> node = new LinkedListNode<T>(this, value);
            if (head != null)
            {
                node.next = head;
                head.prev = node;
            }
            else
            {

                tail = node;
            }
            head = node;
            count++;
            return node;
        } // Done 

        public LinkedListNode<T> AddLast(T value)
        {
            LinkedListNode<T> lastNode = new LinkedListNode<T>(this, value); // since this is a function within a linked_list instance, 


            if (tail != null)
            {

                tail.next = lastNode;
                lastNode.prev = tail;

            }
            else // 꼬리가 없어? 그럼 아무것도 없지 
            {
                head = lastNode;
            }
            tail = lastNode;
            count++;
            return lastNode;
            // 2-2.

        } // Done

        public void AddAfter(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            newNode = AddAfter(node, newNode.item);  
        } // Done 
        public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value)
        {
            ValidateTest(node);
            LinkedListNode<T> afterNode = new LinkedListNode<T>(this, value);



            afterNode.next = node.next;
            if (node.next != null)
            {
                node.next.prev = afterNode;
            }
            else 
                tail = afterNode;
            node.next = afterNode;
            count++;

            Console.WriteLine($"{value} has been added after {node.Value}");
            return afterNode;

        } // Done
        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
        {
            LinkedListNode<T> beforeNode = new LinkedListNode<T>(this, value);
            ValidateTest(node);
            beforeNode.next = node;
            beforeNode.prev = node.prev;

            if (node.prev != null)
            {
                node.prev.next = beforeNode;
            }
            else
            {
                head = beforeNode;
            }
            node.prev = beforeNode;
            count++;
            Console.WriteLine($"{value} has been added before {node.Value}");
            return beforeNode;
        } // Done 
        public void Clear()
        {

            this.tail = null;
            this.head = null;
            count = 0;
        } // Done 

        public bool Contains(T value)
        {
            if (Find(value) != null) // Find 기능을 적극 재활용 
                return true;
            return false;

        }// Done 

        public LinkedListNode<T>? FindLast(T value)
        {
            LinkedListNode<T> search = tail;
            EqualityComparer<T> comparing = EqualityComparer<T>.Default; // EqualityComparer 의 .Default 는 T의 기본 비교형 기능을 호출하여 비교를 하게 한다. magical. 

            while (search.prev != null)
            {
                if (comparing.Equals(value, search.Value)) //comparing would summon appropriate Equals depending on the data_type declared on T 
                    return search;
                else
                    search = search.prev; // Basically reusing previous Find function 
            }
            return null;

        }  // Done 

        //TODO: Remove feature 
        public void Remove(LinkedListNode<T> node)
        {
            ValidateTest(node);

            if (node == head) 
            {
                head = node.next; 
            }
            if (node == tail) 
            {
                tail = node.prev; 
            }
            if (node.next != null) 
                node.next.prev = node.prev;  
            if (node.prev != null) 
                node.prev.next = node.next; 

        }
        public bool Remove(T value)
        {
            LinkedListNode<T> target_LL = Find(value); 

            if (target_LL != null)
            {
                Remove(target_LL);
                count--;
                return true;
            }
            else
                return false;
        } // Done 
        public void RemoveFirst()
        {
            LinkedListNode<T> head_ = head;
            ValidateTest(head); // set the node as the head, 기본적인 ArgumentisNull/ InvalidOperationException예외처리 완료 
            Remove(head_);
            //Remove(head_); 

        }
        public void RemoveLast()
        {
            LinkedListNode<T> head_ = Head;
            ValidateTest(tail);
            if (tail.prev != null)
            {
                tail.prev = null;
            }
            else
            {
                tail = null;
            }// this means there's only one node 


            tail.prev.next = tail.next;
            tail.prev = tail;
        }

        public LinkedListNode<T>? Find(T value) //set as nullable for node can and may return a null. 
        {
            LinkedListNode<T> search = this.Head;
            // 이것은 나의 능력밖, 수업을 참조한다. 
            EqualityComparer<T> comparing = EqualityComparer<T>.Default; // EqualityComparer 의 .Default 는 T의 기본 비교형 기능을 호출하여 비교를 하게 한다. magical. 

            while (search.next != null || search == tail)
            {
                if (comparing.Equals(value, search.Value)) //comparing would summon appropriate Equals depending on the data_type declared on T 
                    return search;
                else
                    search = search.next;
            }
            return null;
        }
        private void ValidateTest(LinkedListNode<T> node)
        {
            //해당 행동명령들은 다른 함수에서도 자주자주 사용되기에 이렇게 함수로 제작하면 
            // 항상 재사용을 할수 있다. 
            if (node == null)
                throw new ArgumentNullException();
            if (node.List != this)
                throw new InvalidOperationException();
        }



         public string ToString(string seperator = ",")
         {
             if (count > 0)
             {
                 StringBuilder sboDataStr = new StringBuilder();

                 LinkedListNode<T> node = head;

                 while (node.Next != null)
                 {
                     sboDataStr.Append(node.Value);
                     sboDataStr.Append(seperator);

                     node = node.Next;
                 }
                 sboDataStr.Append(node.Value); // appends the final tail val 

                 return sboDataStr.ToString();
             }
             return "(EMPTY)";
         }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        public struct Enumerator : IEnumerator<T>
        {
            private LinkedList<T> linkedList; // 해당 반복기가 사용할/ 연동될 자료구조 
            private LinkedListNode<T> node; // 해당 반복기가 값을 추적할때 필요할 맴버구조들도 추가 생성 
            private T current;

            public Enumerator(LinkedList<T> linkedList)
            {
                this.linkedList = linkedList;
                this.node = linkedList.Head;
                current = default(T); 
            }
            public T Current => current;

            object IEnumerator.Current => (object)current;

            public void Dispose()
            {
                //probably for the GC / heap region cleaning purpose?
            }

            public bool MoveNext()
            {
                if (node != null) // while() must continue until post tail in 노드기반 자료 
                {
                    current = node.Value;
                    node = node.Next; // pre-Iterator에 맞게 반복기 이동전 값 반환할것 
                    return true; 
                }
                else 
                {
                    current = default(T);
                    return false; 
                }
            }

            public void Reset()
            {
                node = linkedList.Head; 
            }
        }
    }
    
}


