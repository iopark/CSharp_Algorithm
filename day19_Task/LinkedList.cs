using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataStructure
{
    /* 1. LinkedList 구현해보기 AddFirst/Last, AddBefore/After, <T>/void Remove, Find 우선 구현 
 *  +++++++++++ 주석 추가 
 *  2. LinkedList 기술면접 준비 
 *  0. C# LinkedList 참고해서 최대한 모든 기능 구현해보기 
 *  Contains, FindLast, RemoveFirst, RemoveLast 추가 구현 하기 
 *  교수님한테 확인 받기  으아아아아 저도 코드 잘하고 싶어요 
 */


    public class LinkedListNode<T>
    {
        internal LinkedList<T>? list;
        public LinkedList<T> List { get { return list; } internal set { list = value; } } //어떤이들은 internal Set 도 설정하여 임의로 바꿀수있게 해준다, which makes sense
                                                                                          //저런센스는 어떻게 키우는 걸까 
                                                                
        internal LinkedListNode<T>? prev;
        public LinkedListNode<T> Prev { get { return prev; } internal set { prev = value; } } // 아마도 이후 LinkedList<T> 의 함수의 기능에서 활용할수 있는 방법이 있으랴 생각된다 

        internal LinkedListNode<T>? next;
        public LinkedListNode<T> Next { get { return next; } internal set { next = value; } }
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
            { // 리스트의 해드가 이미 있다면,  // head.next 의 prev 는 head 였음으로 이렇게 연결해줄수도 있겠다.
                node.next = head;
                head.prev = node;
            }
            else
            { // if head's null, there's nothing here 

                tail = node;
            }
            head = node; //무슨일 있어도 이것은 해드가 된다. 
            count++; // welcome to the Linked_List club 
            return node;      
        } // Done 
        
        public LinkedListNode<T> AddLast(T value)
        {
            // Part of LinkedList instance's function, 
            // 1. Declare new Node, which must hold value to store, prev/next to allocate itself correctly, and the instance the node belongs to 
            LinkedListNode<T> lastNode = new LinkedListNode<T>(this, value); // since this is a function within a linked_list instance, 

            // Replicating the AddFirst format, 
            // 2.1 applies here 꼬리가 있었다면, 해당노드는 꼬리가 되기위한 관계정리를 해야한다. 
            //1. 테일의 관계들을 복사한다. 
            //2. 테일 앞의 관계들을 재정립하여 준다 (tail.prev.next only), tail.prev
            if (tail != null)
            {
                 // 이 생성되는 노드가 가리키는 다음노드는? null 이여야 한다. 
                // 이 생성되는 노드가 기리키는 이전노드는? 이전의 tail이여야 하며 
                // tail.next 를 가리키는 곳은? 이 노드여야한다. 
                // 마지막으로 이 Linked_List instance 의 tail에 해당되는 노드는? 이 노드여야한다. 
                tail.next = lastNode; // 꼬리의 이전의 다음은 꼬리의 연결사항을 이것으로 지정하고,
                lastNode.prev = tail;                        // 이것은 꼬리가 되어 연결을 마친다. 

                // 근데 만약 tail.prev 가 head 가 된다면? x 가정필요가 없다 
                // 이유는 어차피 마지막장소에 넣기에, tail 이 null 이라면 애초에 노드가 없기에, 이후 조건문이 이 고민을 해결하여준다. 
            }
            else // 꼬리가 없어? 그럼 아무것도 없지 
            { // we can just assume this is the very first node for this Linked_List instance 
                head = lastNode;
            }
            tail = lastNode;
            // 마찬가지로 조건문 이후 해당되는 것들 
            // 1. 우선 기존 tail 의 관계를 재정립한다. Tail.prev 의 단면적인 (꼬리로 향하는 노드의 관계 재정립하여준다)
            // 2. 생성되는 꼬리또한 정리하여 주는데, 어차피 꼬리가 되는게 단정지어진 상황에 .next 는 재끼고 .prev 만 정리하여 준다. 
            // 3. 마지막으로, 애초에 기존꼬리가 있었던 없었던 관계없이 마지막으로 추가된 노드는 꼬리가 되기에, 모든 조건문 이후 추가한다. 
            count++; // welcome to Linked_List club 
            return lastNode;
            // 2-2.

            // 3. Declare this specific(because we are setting up this as last node;
            // following node as a Tail for this Linked List 
        } // Done
        /// <summary>
        /// Adds the specific new node, after the specified existing node in the Linked List 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="newNode"></param>
        public void AddAfter(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            newNode = AddAfter(node, newNode.item); //하나의 함수 생성이후에는 어차피 코드재사용으로 오버로딩이 쉬워진다. 
        } // Done 
        //===================== vs =======================
        //I guess the difference here is in the user's preferred style of declaring/adding new node?
        public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value)
        {
            ValidateTest(node);// run tests to see if there's any exception errors 
            // 1. Declare/create new node for this Linked_List 
            LinkedListNode<T> afterNode = new LinkedListNode<T>(this, value);
            // 2. Basing off the node in the parameter, reallocate the creating node in appropriate region
            //    In this case, node.prev must be the node, and the node.next must be node.next 
            // Case to watch out for:
            // 2 - 1.노드 자체가 테일/해드 였다면 조건부 처리 방법은?check node.next == null 
            // 2 - 2. What if the node was the Last node? How do we know when to set this as a tail? : same as 2- 1, run to see node.next == null 
            // 그렇다면, 명령문의 패턴은 node.next == null 해당 조건문으로만 갈라주면 될거 같다. 
            // situation = ||[node.prev]|| [node] [afterNode] [node.next]

           
            afterNode.next = node.next; // 노드가 만약 꼬리라면 어떻하지 걱정을 하였지만 쪼금만 생각해보면 같이 null을 가리키기에 문제가 되지 않는다
             // 노드의 next 값또한 신입노드들 가리키게 진행해준다. 
            afterNode.prev = node; // 너무너무 헷갈리면 우선 당연하며 논리를 가르는데 도움이 되는것을 확인해보자 
            //node.next = afterNode; // 이건 이제 확인 작업이 필요하다 node.next == null; 
              
            if (node.next != null) // 이전의 노드가 꼬리가 아니었다면, 해당값이 가리키는 곳이 새로운 노드를 향하게 하면 된다
            {
                node.next.prev = afterNode; // 아 이렇게 하면 afterNode.prev 가 afterNode 가 되버리네.. 
            }
            else // 물론 꼬리가 맞다면 그냥 꼬리로 설정하면 된다. 
                tail = afterNode;
                // 다음을 가리키는 좌표가 null이었다면, 신입을 그냥 꼬리로 세우면 끝이다. 

            node.next = afterNode;
            count++;
            /*한것을 정리해 보자면 이렇다 
             * 0. exception확인 이후
             * 1. 생성된 노드의 prev 변수를 설정하여준다 
             * 2. 생성된 노드의 next 변수또한 설정하여 준다 
             * 3. 기준노드의 next 값을 지정해준다 // 이것은 하나만 해도 된다 왜냐하면 기준되는것은 한면만 영향을 받게 되니 
             * 4. 기준노드의 단짝이었던 값의 한면의 노드를 재정리 해준다. (이때 조건문을 활용하여 주었다) 
             * 5. 이렇게 절차식으로 코드생성을 최소화하고 간략하게 할수있는 방법이 있음을 기억한다! 
             */
            Console.WriteLine($"{value} has been added after {node.Value}"); 
            return afterNode;

        } // Done
        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value) 
        {
            LinkedListNode<T> beforeNode = new LinkedListNode<T>(this, value);
            ValidateTest(node);
            
            // AddAfter와 비슷하게 생성
            // 지정할것이 명확하여졌을때 간소화작업이 가능해진다 
            // 이는 각 명령별로 효과적이며 확실한 명령만 설정할수있게 도움이 되기 때문이다. 
           
            beforeNode.next = node; // beforeNode.next = 5
            beforeNode.prev = node.prev; // beforeNode.prev = node.prev (
            
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
            //노드 전부 박-멸 
            // head& tail 자르면 모두 사실 연결이 잘리므로 기능구현에 해당한다고 볼수 있겠다. 
            // 모두 GC의 청소대상이 되어버린다. 
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

        //TODO: FindLast feature - Done 
        public LinkedListNode<T>? FindLast(T value) 
        {
            //its a Find, but in opposite way 
            LinkedListNode<T> search = tail;
            // 이것은 나의 능력밖, 수업을 참조한다. 
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
        public void Remove (LinkedListNode<T> node) 
        { 
            ValidateTest(node); // 코드 재사용 드가자 
            // 어떤 노드를 삭제하더라도, 주변 노드의 관계를 재정립해야하는데, 조건부가 무조건적으로 붙게 된다. 
            // 조건부와 상관없이 정리되는 관계를 정립하여 보자 
            // 1. 신입 노드의 양
            // 만약 하나만 있었고 그 노드를 없애면 head/tail 은 어떻게 정리해야 할까? (if count ==1) || if node == head and node == tail //  아직까진 카운트로 처리하는게 편리해 보인다 .. . ... 
            // 우선 베스트 케이스 시나리오인 3개중, 중간것이 없다는걸 가정하여 보자. 없애는 방법으로는 중간것을 없음 취급을 하고 양옆을 이어줌으로써 처리한다 (kinda like how we do Clear()) 

            /* 나라면 했을 방법 
            * if (count >= 2) 노드가 2 보다 크다면 
            * 
            *  if (node.prev != null && node.next != null)
            *      node.prev.next = node.next;
            *      node.next.prev = node.prev; // 이렇게 하면 중간녀석은 삭제 되며 상황은 종료된다. 
            *      count --; return 
            *  else 
            *
            *      if (node == head) 
            *      node.next == head;
            *      else 
            *      node.prev = tail; 
            *  
            *  else if (count ==1) 
            *  
            *  head = null; 
            *  tail = null; 
            *  return; 
            *  case closed
            */


            // 조건문이 필요한 부분을 정리해 보자 
            // if node is the head 1.
            // if node is the tail 2.
            // if node is both really (count == 1) 3. 
            // 1 과 2가 모두 해당하여 추가 행동을 시행한다면, 과연 3 이 필요할까?
            
            // 또 다른 접근은 1. 사실이 아니라고 가정한 행동문을 작성하고 
            // 2. 도 사실이 아닌 행동문을 작성하면 
            // 3. 남은 행동군은 3에 해당하는 행동만 남게 되지 않을까? 
            // 하지만 이 접근은 위의 명시한 행위를 무색하게 만드는 가정이 되어버린거 같다 
            
            // 이 두 접근을 합친다면 어떨까?
            if (node == head) // case 1
            {
                // 이렇게 node의 .next node와의 관계를 아예절단 시킴 
                head = node.next; // 다음노드가 헤드로 설정하여주며, 
            }
            if (node == tail) // case 2
            {
                // 이렇게 node의 .next node와의 관계를 아예절단 시킴
                tail = node.prev; // 다음노드가 테일로 설정하여준다. 
            }
            if (node.next != null) // 이것이 꼬리가 아니라는 전재에  case 3 // 또한 지우고하는 노드의 다음노드와 전노드를 이어주는 작업 1 
                node.next.prev = node.prev;  // 테일 방향의 관계에 대해서 재정립 하여 주며 
            if (node.prev != null) // 이것이 해드가 아니라는 전제에  case 4 
                node.prev.next = node.next; // 헤드의 방향에서의 단면적인 관계에 대해서 재정립하여 준다. 
            // 또한 지우고하는 노드의 다음노드와 전노드를 이어주는 작업 2
            // 위에 3,4 의 전제를 절차적으로 돌림으로써 만약 노드가 [node1] [target] [node2] 이런식으로 있다면 통과할수밖에 없는 형식으로도 구성이 가능하다! ㄴㅇㄱ 
            // 이렇게 여과되는 필터처럼 절차형식으로 간단명료하게 명령문을 짤수 있게 된다 
            // 이것을 하려면 원하는 결과에 대해 명확한 기대값이 있어야 하며, 그것은 구체적이여야 한다. 
            // 예를 들어, 리스트에 2개만 남았다면 1,2, 를 거친후, 3,4 를 거칠 필요가 없어지겠고, 
            // 1 과 2는 해당되지않지만 3, 4 둘다 해당될수도, 
            // 1, 3만 해당되는 노드라면 
            // 어찌됬는 이곳을 통과한다면 노드 정리 뿐만아니라 관계 재배치까지 완료될수있는 코드가 완성이 되게 된다. 
            // 위의 예시는 수업에서따온것임으로, 아직은 나는 어떻게 이렇게까지 할수 있을까 가늠이잘 안되지만, 기존에 존재하는 알고리즘패턴을 알아가며 적용사례를 알아간다면 익숙해지지않을까 생각해본다. 
        } // Done 
        /* 정리해 보자면, 위의 알고리즘은 2방향 순서로 정리가 된 값들중, 
         * 1. 왼쪽값에 대해서 정리하고 
         * 2. 오른쪽값에 대해서 정리하는데 
         * 1-1. 만약 정리하는 대상이 해드라면 새로운 헤드를 설정하여 주고 
         * 2-1. 테일이라면 새로운 테일을 설정하여 주고 (남은 노드가 하나더라도 because node = head&tail) 추가 조건문이 필요하지 않으며
         * 1-2. 왼쪽값이 있다면 해당 노드에 대해서 오른쪽 노드관계를 재설정 하여주었고 
         * 2-2. 오른쪽 값이 있다면 해당 노드에 대해서 왼쪽 노드관계를 재정립 하여주었다. 
         */ 

        public bool Remove(T value)
        {
                LinkedListNode<T> target_LL = Find(value); //better make Find method first, and void Remove too 
                
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
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns>매개변수로 입력한 값을 Linked List instance 에 찾은후 반환합니다. 이때 없다면 null을 반환가능합니다 </returns>
        public LinkedListNode<T>? Find (T value) //set as nullable for node can and may return a null. 
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
        private void ValidateTest (LinkedListNode<T> node)
        {
            //해당 행동명령들은 다른 함수에서도 자주자주 사용되기에 이렇게 함수로 제작하면 
            // 항상 재사용을 할수 있다. 
            if (node == null)
                throw new ArgumentNullException();
            if (node.List != this)
                throw new InvalidOperationException(); 
        }
        
        /*public void Printf(LinkedList<T> list, LinkedListNode<T> list_Node, T Value) // 으아아 Enumerator 가 뭐야 
        {
            list_Node = new LinkedListNode<T>(list, Value); 
        
        }*/

        public string ToString(string seperator = ",")
        {
            //int i = 0; 
            //StringBuilder sb = new StringBuilder();
            //LinkedListNode<T> node = head; 
            //if (count <= 0)
            //    return "Nothing is here M8"; 
            //while (count > i || node.Next != null)
            //{
            //    sb.Append(node.Value);
            //    sb.Append(seperator);

            //    i++;
            //    node = node.Next;
            //}
            //return sb.ToString();
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
}
}
