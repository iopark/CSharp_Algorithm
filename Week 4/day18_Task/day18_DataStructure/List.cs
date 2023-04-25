//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection.Metadata.Ecma335;
//using System.Text;
//using System.Threading.Tasks;
// 교수님 수업내용 
/////
////
//namespace day18_DataStructure
//{
//    public class List<T>
//    {
//        private const int DefaultCapacity = 10; //default 값으로 설정되는 capacity 크기 
//        private T[] items;
//        private int size = 0;

//        public List()
//        {
//            this.items = new T[DefaultCapacity];
//            this.size = 0;
//        }

//        public int Count
//        {
//            get { return size; }
//        }

//        public int Capacity
//        {
//            get { return items.Length;  }
//        }
//        public void Add(T item)
//        {
//            if (size < items.Length)
//            {
//                items[size++] = item; // first set items[size] = item, then size ++ 
//            }
//            else
//            {
//                Grow(); 
//                items[size++] = item; 
//            }
//        }

//        public T? Find(Predicate<T> match) // T? returns null if following data is not found 
//        {
//            if (match == null)
//                throw new ArgumentNullException($"{match}"); 

//            for (int i = 0; i < size; i++)
//            {
//                if (match(items[i]))
//                    return items[i]; 
//            }
//            return default(T); 
//        }

//        public int FindIndex(Predicate<T> match)
//        {
//            for (int i = 0; i < size; i++)
//            {
//                if (match(items[i]))
//                    return i;
//            }
//            return -1;
//        }

//        public bool Remove(T item)
//        {
//            int index = IndexOf(item); 
//            if (index >= 0)
//            {
//                // TODO : 지우기 작업 
//                RemoveAt(index); 
//                return true;
                
//            }
//            else
//            {
//                // TODO : 못찾은 경우 
//                return false; 
//            }

//        }
//        /// <summary>
//        /// 이런식으로 여러가지 함수를 생성후 상호작용을 일으키는것으로 코드 reuse를 활용할수 있다. 
//        /// </summary>
//        /// <param name="item"></param>
//        public void RemoveAt(int index)
//        {
//            if (index < 0 || index >= size)
//                throw new IndexOutOfRangeException(); 
//            size--;
//            Array.Copy(items, index + 1, items, index, size - index); 
//            // copy(source, source, dest_startindex, dest_pool, dest.size) 
//        }

//        public T this[int index]
//        {
//            get
//            {
//                if (index < 0 || index >= size)
//                    throw new IndexOutOfRangeException(); 

//                return items[index];
//            }
//            set
//            {
//                if (index < 0 || index >= size)
//                    throw new IndexOutOfRangeException();
//                items[index] = value; 
//            }
//        }

//        public int IndexOf(T item)
//        {
//            return Array.IndexOf(items, item, 0, size); 
//        }

//        private void Grow()
//        {
//            int newCapacity = items.Length * 2;
//            T[] newItems = new T[newCapacity];
//            Array.Copy(items, 0, newItems, 0, size);
//            items = newItems;
//        }
//    }
//}
