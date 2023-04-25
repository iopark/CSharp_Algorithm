using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
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
        private int size; 

        public List() 
        { 
            items = new T[DefaultCapacity ];
            size = 0; 
        }

        public void Add(T item)
        {
           if (size == items.Length)
            {
                IncreaseCap();
            }
           items[size++] = item; // Post++ 사용되는 예시;
                                 // 우선 prev size 에 item 입력 이후 size ++; 
        }

        public void Add(T[] item_array)
        {
            for (int i = 0; i < item_array.Length; i++)
            {
                Add(item_array[i]);
            }
        }


        //=========================================extra 시작=============================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index">배열에 element삽입을 원하는장소를 인덱스로써 설정</param>
        /// <param name="item">삽입하고자하는 element</param>
        /// <exception cref="IndexOutOfRangeException">MS: don't even try</exception>
        /// 

        /* 숙제 제출 목표: 제출 마감 10분전까지 제출할것 
         * ToArray, CopyTo 완료하기 
         * ToArray 이후 .Add 를 위해 .Add 오버로딩 하기 
         * 시간이 있다면 .GetRange 만들기 // MSDN .Net 7 예제 기준 
         * .GetRange().ToArray()는 아직은 제 능력밖인거 같은데.. 
         * \// WORTH MENTIONING: 얕은 복사와 깊은복사를 이해하고 응용해보는 기회가 되었다. 
         * 특히 ToArray 는 얕은복사로 해당클래스에 이미 할당된 값들의 주소만 주는것인 반연 
         * CopyTo 는 해당 장소로 깊은복사로 갚을 전달하게 된다. 이때 get/set프로퍼티를 적극 응용하여주는예시들을 참조하였다. 
         * 
         */
        public void Insert(int index, T item)
        {
            if (index < 0) // 마이너스 배열이 입력이 된다면 힙영역에서 전혀 예상치못한 값이 호출될수도 있겠다
                           // 이유는 애초에 값을 부르는방식이 연속적으로 저장된값속중, 각도를 부르는것처럼 data_type * 배수로 호출하는데
                           // 호출하게 되는 대상이 값이 저장된 주소이기에, technically, 일정히 정렬된(가정)(힙영역이 하나의객체로구성된것또한 가정)
                           // 다른데이터들중 강제로 다른값도 부르는게 가능하지않을까 생각한다. 
                throw new ArgumentOutOfRangeException($"{index} is completely out of range buddy"); 
            else if (index >= items.Length) // 값은 배열의 카운트 내에서만 가능하게 예외처리가 되어있다 
                throw new IndexOutOfRangeException("_stop_trolling_&look_at_the_index_");
            if (size == items.Length)
            {
                IncreaseCap();
            }
            //아래는 array의 특성에 근거한 명령문들이다 

            T[] temp = new T[size+1]; // 이미 위 조건문으로 인서트가 들어갈 capacity는 확보했기에,
                                      // 원본 카운트 +1의 배열을 복사하여 진행하여도 안전하다. 
            Array.Copy(items,0,temp,0,index); // 원본에서의 호출된 인덱스 지점 이전 element들 모두 복사
                                              // if index 0, 여도, 복사를 안하는것으로 가정한다. 

            temp[index+1] = item; // 복사된 값의 다음값에 대하여 삽입할 element값으로 지정 
            Array.Copy(items,index+1, temp, index+1, size-index);
            // 원본의 index 다음값부터 복사를 하며 
            // 새로운 배열의 복사되는 시작값또한 호출된 인덱스의 다음수 부터 받는다 
            // 갯수는 기존 원본의 카운트/사이즈 - index 로, 이렇게 하면 남은 element를 모두 복사대상으로 지정할수있게 된다


        }
        
        public T?[] ToArray() 
        {
            //얕은 복사이기 때문에 해당 배열값의 주소값만 반환 해주면 되는듯 하다. 
            if (size == 0)
            {
                T[] is_nothing = new T[0];
                return is_nothing;
            }
                
            T[] shallow_ = new T[size];
            Array.Copy(items, shallow_, items.Length);
            return shallow_;
        }
        /// <summary>
        /// MSDN overload중 (Array, int32) 참조 
        /// </summary>
        public void CopyTo(T[] array, int start_index) 
        { 
            if (array == null)
                throw new ArgumentNullException("array");
            if (start_index < 0)
                throw new ArgumentOutOfRangeException();
            if (items.Length > array.Length || (array.Length - start_index) < items.Length)
                throw new ArgumentException(); 
            Array.Copy(items, start_index, array, 0, size - start_index);
        } 

        public List<T> ShallowClone()
        {
            List<T> list = (List<T>)this.MemberwiseClone();
            return list;
        }

        public List<T> DeepClone()
        {
            List<T> deep_Cloned = new List<T>();
            return deep_Cloned; 
        }

        public void Clear()
        {
            //Capacity 기준으로 다시 재생성하며, 해당값의 주소값을 재생성된, 하지만 배열의 자료형에 따라 다르겠지만 
            // Default 값으로 재생성된 배열로 탄생된다. 
            items = new T[items.Length];
            size = 0; 
        }
        public void TrimExcess()
        {
            // Because Count/Size > Capacity (사이즈가 오를때 캡은 무조건 같이 따라서 오르는 구조이기에 
            T[] trimmed = new T[size];
            Array.Copy(items,trimmed,size);
        }
        

        public void RemoveRange(int start_index, int count) { }
        /// <summary>
        /// Enumerable 인터페이스가 들어가있는 객체들중 가능한 기능인 Contain도 추가 구현 시도하여봅니다. 
        /// 
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool Contain(Predicate<T> match)
        {
            if (match == null)
                throw new ArgumentNullException();
            for (int i = 0; i < size; i++) // 최악 bigO = O(n) where n= list.length
            {
                if (match(items[i]))
                    return true;
            }
            return false;
        }
        //=========================================extra 끝===============================

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
            Array.Copy(items, index + 1, items, index, size - index); // 최악 bigO = O(n) where n= size - index
            // 원본 items의 startingpoint = index, index = 2 
            // [a, b, c, d, e] if erasing c, source index +1 as a starting point = d
            // copy from d, size - index  = (5-1) - 2 = 3 Therefore would copy from d - e 
            // 

        }

        public T? Find (Predicate<T> match)
        {
            if (match == null)      //예외처리 
                throw new ArgumentNullException($"{match}"); 
            for (int i = 0; i < size; i++) //최악 bigO = O(n) where n = list.length
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
        
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf<T>(T item)
        {
           //for(int i = 0; i < size; i++)
           // {
                //if (item == items[i])) // 이것이 안되는 이유는 기본적으로 일반화가 가지는 태생적인 결함도 있을 뿐더러
                //                      이미 어떠한 디자인패턴으로 설계이후 파생된 객체들중, 하나의기능을 다루다가 불안해 하기에는
                //                      아직은 이른단계인것 같다. 
                //    return i;
                return Array.IndexOf(items, item); // where (확인하는 배열, 찾는 element)
                                                   // if none found, returns -1 
           // }
           //return -1;
        }
        public void IncreaseCap()
        {
            //카운트가 오를때마다 한계치 또한 그것에 맞게 상승합니다 => 한계치가 더 높은 배열 생성후, 
            // 기존의 배열의 값을 그곳에 복사하고, 새로운 배열의 주소값을 전달합니다 
            // 더이상 호출되지않는 손절당한 기존의 배열은 버림받아 쓰레기처리자의 처분대상이 됩니다 
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
        public T this[int index] //인덱서를 통해 클래스 객체를 배열과 같이 취급할수 있는 기능을 추가합니다.
                                 //아직까지는 배열이 아닌 객체들에 인덱서를 적용하는것이 생소하지만,
                                 //이처럼 객체를 연속적으로 나열된 값으로 취급, 그중 원하는값을 인덱스를 동해 얻을수 있음으로
                                 //생겨날수 있는 상호작용요소들/기능들에 대해 생각해보게 됩니다. 
        {
            get
            {
                if (index < 0 || index >= size)// not items.length (capacity와 별개로) List 는 카운트로써 값을 접근하는것을 제한한다. 
                    throw new ArgumentOutOfRangeException(); //The exception that is thrown when the value of an argument is outside the allowable
                                                             //     range of values as defined by the invoked method.
                else
                    return items[index];
            }
            set
            {
                if (index < 0 || index >= size)
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



