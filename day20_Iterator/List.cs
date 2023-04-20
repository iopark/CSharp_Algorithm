using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    internal class List<T> : IEnumerable<T>
    {
        // 우선 교수님 기준 예시 적용 

        private const int DefaultCapacity = 4;

        private T[] items;
        private int size;

        public List()
        {
            items = new T[DefaultCapacity];
            size = 0;
        }

        public int Capacity { get { return items.Length; } }
        public int Count { get { return size; } }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= size)
                    throw new IndexOutOfRangeException();

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
                Grow();

            items[size++] = item;
        }

        public void Clear()
        {
            items = new T[DefaultCapacity];
            size = 0;
        }

        public T? Find(Predicate<T> match)
        {
            if (match == null) throw new ArgumentNullException();

            for (int i = 0; i < size; i++)
            {
                if (match(items[i]))
                    return items[i];
            }

            return default(T);
        }

        public int FindIndex(Predicate<T> match)
        {
            return FindIndex(0, size, match);
        }

        public int FindIndex(int startIndex, int count, Predicate<T> match)
        {
            if (startIndex > size)
                throw new ArgumentOutOfRangeException();
            if (count < 0 || startIndex > size - count)
                throw new ArgumentOutOfRangeException();
            if (match == null)
                throw new ArgumentNullException();

            int endIndex = startIndex + count;
            for (int i = startIndex; i < endIndex; i++)
            {
                if (match(items[i])) return i;
            }
            return -1;
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(items, item, 0, size);
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException();

            size--;
            Array.Copy(items, index + 1, items, index, size - index);
        }

        private void Grow()
        {
            int newCapacity = items.Length * 2;
            T[] newItems = new T[newCapacity];
            Array.Copy(items, 0, newItems, 0, size);
            items = newItems;
        }

        public IEnumerator<T> GetEnumerator() // foreach (inti in _this_instance)에 해당하는 GetEnumerator호출, 그리고 Enumerator 를 이용한다. 
        {
            // here a IEnumerator<T> object must be returned 
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()// when the GetEnumerator is called, in this Class instance do the following 
        {
            return new Enumerator(this);
        }

        public struct Enumerator : IEnumerator<T> // we define 
        {
            private List<T> list; //반복기
            private int index;
            private T current;


            internal Enumerator(List<T> list) //배열에서의 특정값을 가리키는 포인터같은 역할을 하는 반복기 이다. 
            {
                this.list = list;
                this.index = 0;
                current = default(T); // 왜 default로 설정해둘까
                                      // 반복기의 본 기능이 실행하는지 확인하기위한 최소한의 장치
            }

            public T Current { get { return current; } } // ForEach retreives this 

            object IEnumerator.Current // this is called when a value not declared is called, which returns whatever the value pointer/indexer 
            {               //or this for the ForEach Current 
                get
                {
                    if (index < 0 || index >= list.Count)
                        throw new InvalidOperationException();
                    return (object)current; // normally this can be expected to be called in a ArrayList Data Structure 
                }
            }

            public void Dispose() { }

            public bool MoveNext() // and this for the while(MoveNext()) 
            {
                if (index < 2 ) // returns false when list.length -1 = index  (if list.length = 3, index is 2,), therefore
                                        // 2 = 2, this should signal the end 
                {
                    Console.WriteLine("the limit for MoveNext is set to 2 "); 
                    current = list[index++];
                    return true;
                }
                else
                {
                    current = default(T); // this is where the pointer is pointing 
                    return false;
                }
            }

            public void Reset()
            {
                index = 0; // 왜냐하면 늘 0번부터 시작해야 하기에 
            }
        }
    }
}