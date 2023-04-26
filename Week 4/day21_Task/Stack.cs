using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_DataStructure
{
    /// <summary>
    /// 어댑터 패턴은 기존에 존재하는 레거시 코드를 기준으로 Adaptee 로 설정하고, 새로운 객체를 구현할때 동일한/ 혹은 매우 유사한 기능을 가지고 있지만 
    /// 조금 어딘가 무엇이 살짝 다른경우, 코드를 재사용하게 해주는 디자인 패턴중 하나이다. 
    /// Stack 은 리스트와 많이 유사하지만 인덱스의 지정방식이 박스형이라는 차이점이 있기에, 어댑터 패턴을 이용한다 
    /// 어댑터 패턴 이용시 주의사항은 Adapter-Adaptee 기준, Big-O 가 달라지게 되면 RedFlag 1, 
    /// Big-O 가 달라졌고 해당 기능의 역할에 따라, 악화된 Big-O와 직접적인 연관이 있다면 RedFlag 2, 로 차라리 다른 Adapter를 선정하거나, 그라운드 부터 새로 작성하는게 지향된다. 
    /// 밑의 예시처럼 스택 자체는 역할때문에 사용되는 곳이 많게 되는데, 레거시 코드를 가져다가 약간의 수정을 통하여 새로운 기능을 수행하는 또다른 객체를 생성하게 된다. 
    /// 기능 자체가 수정되었지만, 자료구조적으로 메모리에 미치는 영향은 레거시 코드와 크게 다른바가 없다는것도 주목해볼 필요가 있다. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> list;

        public Stack() 
        {
            list = new List<T>();
        }
        public int Count { get { return list.Count; } }
    
        public T this[int index] { get { return list[index]; } set { list[index] = value; } }
        public void Push (T Item)
        {
            list.Add(Item);
        }

        public void Reverse()
        {
            list.Reverse();
        }
        public T Pop ()
        {
            T item = this.list[list.Count - 1];
            this.list.RemoveAt(list.Count - 1);
            return item;
        }
        public T Peek()
        {
            return this.list[list.Count-1]; 
        }
        //======================그저 기존 리스트 복붙영역==============================
        public void Clear() // 어댑터의 장점은 이런식으로 조금 엇다른 객체를 이렇게 정의가 가능하다.
                            // 마치 대머리독수리와 일반 독수리를 정의하는것처럼 말이다.
                            // (bald = true;)           (bald = false;), rest, bald_eagle = eagle
        {
            this.list.Clear();
        }

        //public bool TryPop(T item) 아직 내 능력밖
        //{

        //    return this.list[this.list.Count - 1] == item ? true : false;
        //}

        //public bool TryPush()
        //public bool Contains(T item)
        //{
        //    return this.list.Contains(item);
        //}

        public void CopyTo(T[] array, int arrayIndex)
        {
            this.list.CopyTo(array, arrayIndex);
        }
        public int EnsureCapacity(int capacity)
        {
            return this.list.EnsureCapacity(capacity);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }
        /// <summary>
        /// Stack의 구조적인 이해와, 반복기의 추가적인 이해를 위해 스택을 위한 반복기 재정의를 실시한다. 
        /// </summary>
        public struct Enumerator : IEnumerator<T>
        {
            private int index;
            public int Index { get { return index; } set { index = value; } }
            private Stack<T> stack;
            public Stack<T> Stack { get { return stack; } }
            private T current; 

            public Enumerator(Stack<T> stack)
            {
                this.stack = stack;
                this.current = default(T);
                this.index = stack.Count-1; // 리스트와는 다르게 반복기 또한 스택의 동작형태로 값을 접근해야 하기에, 이와같이 시작점 또한 최상단(최 우측) 값으로 지정한다 
            }
            public T Current => current;

            object IEnumerator.Current =>(object) current ;

            public void Dispose()
            {

            }

            public bool MoveNext()
            {
                if (index >= 0)
                {
                    current = stack[Index--]; // pre-Iterator 으로써 foreach를 고려하며 current 값은 MoveNext 이전값을 반환하게 설정한다. 
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
                index = 0; 
            }
        }
    }
}
