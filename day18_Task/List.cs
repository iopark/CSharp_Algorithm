using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day18_Task
{
    /* 1. 선형리스트 구현 - MSDN C# List 참고
    * Indexer[], Add, Remove, Find, FindIndex, Count, etc. 
    * + 주석으로 설명 
    * 2. 배열, 선형리스트 기술면접 정리 
    * ------------------------------------------------------------------
    * 0. 더 필요한 구현들 시도, FindFirst, FindLast, CopyTo, ToArray 등 
    * 선형리스트와 연결리스트의 차이점에 대해서 예기해주세요 
    */
    public class List<T>
    {
        private const int DefaultCapacity = 1;
        private T[] items;
        private int size = 0;

        public List() 
        { 
            items = new T[DefaultCapacity];
            this.size = 0; 

        }

        public void Add(T item)
        {
           if (size == DefaultCapacity)
            {
                IncreaseCap();
                items[size++] = item;
            }
           items[size++] = item; // Post++ 사용되는 예시;
                                 // 우선 prev size 에 item 입력 이후 size ++; 
        }

        public bool Remove(T item)
        {
            int findIndex = IndexOf(item);
            if (findIndex >= 0)
            {
                RemoveAt(findIndex);
                return true;
            }
            else
                return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= items.Length)
                throw new IndexOutOfRangeException();

            size--;
            Array.Copy(items, index + 1, items, index, size - index);
            // 원본 items의 startingpoint = index, index = 2 
            // [a, b, c, d, e] if erasing c, source index +1 as a starting point = d
            // copy from d, size - index  = (5-1) - 2 = 3 Therefore would copy from d - e 
            // 

        }

        public T? Find (Predicate<T> match)
        {
            if (match == null)
                throw new ArgumentNullException(); 
            for (int i = 0; i < size; i++)
            {
                if (match(items[i]))
                    return items[i];

            }
            return default(T); //만약 아무것도 찾지 못했다면 이 List Class 의 T 의
                               //기본값을 반환합니다  
        }

        public int FindIndex (Predicate<T>match)
        {
            for (int i =0; i < size; i++)
            {
                if (match(items[i]))
                    return i;
            }
            return -1; 
        }
        /// <summary>
        /// 추가 작업, MSDN .NET 8 참조 
        /// </summary>
        /// <param name="match"></param>
        /// <returns>찾는값중 선행배열기준 마지막으로 있는값을 반환(if found), 없다면 상대하는 list의 자료형의 default를 반환 if int, 0, etc </returns>
        public T? FindLast(Predicate<T> match)
        {
            //int findAny = FindIndex(match); // Recursion 방식으로 할수 있지 않을까 생각해보았지만,(할줄모름다)
            //                                   아직은 때가 아니라고 판단하였습니다 (어떻게 해요 교수님 ㅠ)
            //if (findAny != -1)                 찾아도 나오질 않습니다 (찾을줄도모름다)
            //{
            //    for (int i = findAny; i < size; i++)
            if(match == null)
                throw new ArgumentNullException();
            for (int i = size- 1; i >= 0; i--)
            {
                if (match(items[i]))
                    return items[i];
            }
            return default(T);
        }

        public T? Contain(Predicate<T> match)
        {
            if (match == null)
                throw new ArgumentNullException();
            for (int i = 0;i < size; i++)
            {
                
            }
        }

        public int IndexOf<T>(T item)
        {
           for(int i = 0; i < size; i++)
            {
                //if (item.Equals(items[i])) // 이것이 안되는 이유는 기본적인
                //    return i;
                return Array.IndexOf(items, item); // where (확인하는 배열, 찾는 element)
                                                   // if none found, returns -1 
            }
           return -1;
        }
        public void IncreaseCap()
        {
            int newCap = items.Length * 2;
            T[] newItems = new T[newCap];
            Array.Copy(items, 0, newItems, 0, size); // (원본_arr, 복사스타팅인덱스, 뉴_arr,
                                                     // 복사스타팅포인트, 어느정도나 복사하나요#)
            this.items = newItems; //해당 클래스 맴버변수를 복사되고 capacity 가 늘어난 새로운 선형리스트로 복사 
        }


        /// <summary>
        /// MSDN 기준 인덱서는 get; set; 프로퍼티 로써 값을 할당하거나 반환할수 있습니다 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= items.Length)
                    throw new IndexOutOfRangeException();
                else
                    return items[index];
            }
            set
            {
                if (index < 0 || index >= items.Length)
                    throw new IndexOutOfRangeException();
                else
                    items[index] = value;
            }
        }

            
            
        public int Count
        {
            get { return items.Length;  }
        }
    }
}



