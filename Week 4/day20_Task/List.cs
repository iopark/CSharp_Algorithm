using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace day20_Task
{
    public class List<T> : IEnumerable<T>
    {
        // 해당 객체에 IEnumerable<T> 를 넣는다는것은 
        // 반복기와 상호작용을 일으킬만한 자료구조를 설계한다는것과 같은 맥락으로 봐야한다. 
        // 리스트 같은 경우, IEnumerable 의 Current, bool MoveNext()의 기능에 대해서 
        // Current 는 Array 의 Index 값으로 상호작용을 일으키며, 
        // Index < List.Length 을 while(bool MoveNext) 에 대하여 정의하는것이 명백하다 
        // 이렇게 C#는 query 기능중 Loop 행동에 대해서, 해당 객체(Container 로서의 역할에 대해) IEnumerable 을 통해 하나의 기준을 제시한다. 
        // 그렇기에 추후의 객체를 설계시, 자료구조를 선택할때에, IEnumerable 도 유념하여 제작한다면 
        // C# 에선 보다 더 효율적인 상호작용을 만들어 낼수 있을꺼라 생각한다. 
        private const int DefaultCapacity = 2;
        private int size;
        private T[] items; 

        public int Count {  get { return size; } }
        public int Capacity { get { return items.Length; } }

        public List()
        {
            items = new T[DefaultCapacity];
            size = 0; 
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= size)
                    throw new ArgumentOutOfRangeException("index");
                return items[index];
            }
            set
            {
                if (index < 0 || index >= size)
                    throw new IndexOutOfRangeException(); 
                items[index] = value;
            }
        }

        public void Add(T item)
        {
            if (size >= items.Length)
                IncreaseCap(); 
            items[size++] = item;
        }

        public void IncreaseCap()
        {
            T[] new_Items = new T[items.Length*2];
            Array.Copy(items, 0, new_Items, 0, size); 
            items = new_Items;
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
            private List<T> list; 
            private int index;
            private T current; 

            public Enumerator (List<T> list) // 초기화는 이렇게 구현하여, 해당객체는 이렇게 반응
            {
                this.list = list;
                this.index = 0;
                current = default(T); 
            }
            public T Current
            {
                get { return current; }
            }

            object IEnumerator.Current => (object)current; // T가 선언되지않은 인스턴스인 경우 해당값 반환..?

            public void Dispose()
            {
                //아마도 
            }

            public bool MoveNext()
            {
                if (index < list.Count) // basic 101. execute the following 배열 until 마지막 element 
                {
                    current = list[index++];
                    return true;
                }
                else
                {
                    Console.WriteLine(" 그만 해! 인덱스 끝났어!"); 
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
