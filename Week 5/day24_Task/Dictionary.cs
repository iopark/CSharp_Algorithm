using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_DataStructure
{
    /// <summary>
    /// 1. 해당 Dictionary 는 Default 로는 GetHashCode를 통하여 SHA 알고리즘을 적용시킨 값으로써 인덱스 값을 생성하는데, 해싱함수를 유저의 편의에 따라 변경도 가능하게 설정한다. 
    /// 2. 해당 Dict 는 충돌에 대하여 취하는 조치로 Open Address형태로 그 다음 index를 찾은후 적용시키는 방식이다 (where interval = double Hash) 
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    internal class Dictionary<TKey, TValue> where TKey : IEquatable<TKey> // Dictionary 는 Key 로 접근을 해야 함으로 인덱서로 구현시, 또는 충돌방지를 위해서 비교가 가능한 값이어야만 한다. 
    {
        //1. 해당 자료구조의 멤버변수를 정의한다. 
        private const int DefaultCapacity = 1000; 
        public Entry[] table;
        private Func<TKey, int> hashFunc;  // 델리게이트를 응용하여 친숙하지 못하는 나의 영역에 대해서 확장시키겠노라. 
        //where Func Syntax is Func<Input, out Output> Func_name. So a Func_name = any method which holds the parameter (Tkey), with the expected output, int 
        public struct Entry
        {
            public enum State // 해당 상태값은 이후 인덱스 위치의 상태에 대해 정의하며, 이것은 충돌상태 방지와도 밀접한 관계가 있다. 
            {
                None, Using, Deleted
            }
            public TKey key; // 상태값과 마찬가지로 키는 충돌상태 예방에서도 쓰이며, 해시가 되는 값이기도 하다. 이값은 일정한 해시값을 제시하는 입력값이다. 
            public TValue value;
            public State state;
            public int hashCode; 
        }
        /// <summary>
        /// 기본으로 생성자는 해싱함수를 C#에서 권장하는 GetHashCode로 적용시킨다.  
        /// </summary>
        public Dictionary()
        {
            this.table = new Entry[DefaultCapacity];
            this.hashFunc = DefaultHash; 
        } 
        /// <summary>
        /// 이런식으로 델리게이트를 이용하여 새로운 hashMethod를 반환을 받아 해당 해싱함수를 이 해시테이블의 해시함수로 적용시키는것또한 가능하겠다. 
        /// </summary>
        /// <param name="hashMethod"></param>
        public Dictionary(Func<TKey, int> hashMethod)
        {
            this.table = new Entry[DefaultCapacity]; 
            this.hashFunc = hashMethod;
        }

        private int DefaultHash(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("key"); // key 를 적어 해당 key 값에 문제가 있음을 알림  
            return Math.Abs(key.GetHashCode()); 
        }
        //생성자 기능구현이후에는 인덱서가 존재한다면 인덱서를 구현하여 준다. 
        public TValue this[TKey key]
        {
            get
            {
                TValue value; // 반환형 매개변수로 지정하여 값을 받을 TValue 선언 
                bool testGet = TryGetValue(key, out value); // 반환형 매개변수로 만약 TryGet에 성공한다면 해당 키의 value 값을 
                if (testGet)
                {
                    return value; // 찾았다면 찾은 키의 value값 반환
                } 
                else
                {
                    throw new KeyNotFoundException("I Can't offer what does not exist"); // 저장되지 않는 키를 찾기에 예외처리 
                }
            }
            set
            {
                int setIndex = FindIndex(key); // 우선 인덱스값을 정합니다 
                if (setIndex > 0) // 인덱스가 멀쩡이 있다면 
                {
                    table[setIndex].value = value; // 해당 인덱스에 위치한 값을 재정의하게 합니다 
                }
                else
                {
                    throw new KeyNotFoundException("Can't Set what does not Exist"); // 물론 인덱스가 없다면 예외처리당하는건 마찬가지입니다. 
                }
                
            }
        }
        /// <summary>
        /// 해시테이블에 해당키가 존재하는지 확인하는 방법중 하나입니다. 
        /// 이를 선진행함으로써 중복되는 키를 입력하는것을 방지하며, 없는값을 찾다가 예외처리당하는것을 방지할수 있습니다 (이론적으론) 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ContainsKey(TKey key)
        {
            int findKey = FindIndex(key);
            if (findKey > 0)
            {
                return true;
            }
            else
                return false;
        }
        public bool TryGetValue(TKey key, out TValue value) // Key Value를 
        {
            int tryGetIndex = FindIndex(key);
            if (tryGetIndex > 0)
            {
                value = table[tryGetIndex].value;
                return true;
            }
            else
            {
                value = default(TValue);
                return false;
            }
        }
        /// <summary>
        /// 열쇠를 들고 찾아간 사람에게, 해당 열쇠값이 있는 인덱스를 알려주며, 없다면 -1을 반환합니다. 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private int FindIndex(TKey key)
        {
            int hashCode = hashFunc(key); // Where Math.Abs 가 전제로 깔려있는 상황임으로, 다시 하지않아도 된다. Default. GetHashCode 로 키를 일정하지만 고유에 가까운 해시값을 생성하고, 
            int index = hashCode % table.Length; // Table.Length의 나머지로 설정하여 인덱스값으로 활용할수 있는 값으로 만들어 줍니다. 
            while (table[index].state != Entry.State.None) // 상태가 None 이 아닌값에 대하여, 
            {
                if (table[index].state == Entry.State.Using) // 만약 Using 이라면, 
                {
                    if (table[index].key.Equals(key)) // 그리고 찾는 키가 맞다면 
                    {
                        return index; // 해당 인덱스를 반환합니다 
                    }
                    continue; // 아니면 None 이 나올때까지 반복하구요
                } // 또한 None 이 아니라면 존재할수 있는 다른상태, delete에 대해서는 그냥 무시하여 주고
                index = ++index % table.Length; // index 를 1 추가하여줍니다
            } // 살짝 Delete에 대해서 키값을 확인할까 고민하였지만, ContainsKey를 확인해야하기에 예외처리는 따로 진행하지 않았습니다. 
            return -1; // 만약 None 상태값을 찾았다면 -1을 반환합니다. 
        }
        public void Add(TKey key, TValue value)
        {
            bool tryAdd = TryInsert(key, value);
            if (tryAdd)
                return;
            else
                throw new InvalidOperationException(); 
        }
        /// <summary>
        /// 값을 삽입하기를 시도합니다. 
        /// 1. 우선 키를 해쉬하여 일정한 인덱스값으로 변형하여 줍니다. 
        /// 2. 만약 칸이 비었다면, 값을 추가할수 있기에 True 를 반환 
        /// 3. 만약 칸에 해당 해쉬값으로 저장된 값이 이미 있다면에 대해 추가적으로 처리가 필요하며, 값이 더이상 없는 장소일때까지 이를 반복하여 줍니다. 
        /// 3 -1. 만약 값이 Using 이라면 1. 키값이라면 예외처리하며 키값이 아니라면 넘겨서 None이 더 있는지 Deleted가 있는지 확인하여 준다. 
        /// 3 -2. 만약 값이 Deleted 이라면 = 값을 오버라이드 합니다 State = Using 으로 다시 변경하여준다. 
        /// 3 -3. 만약 값이 None 이라면  = 값을 추가하며, 상태또한 Using  으로 변경한다. 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool TryInsert(TKey key, TValue value)
        {
            int hashCode = hashFunc(key);
            int index = hashCode % table.Length;
            while (table[index].state != Entry.State.None) // None이 아닌이상 반복합니다.
            {
                if (table[index].state == Entry.State.Deleted) //만약 3 -2 상황이라면, 
                {
                    Add_ing(key, value, hashCode); // 해당 인덱스에 덮어쓰기를 진행합니다. 
                    return true; // 
                }
                if (table[index].state == Entry.State.Using) // 만약 3- 1 상황중에서 
                {
                    if (table[index].key.Equals(key)) // 키값도 같다면 예외처리 합니다 
                    {
                        throw new InvalidOperationException("C# does not allow any overlapping Key values");
                    }
                    continue; // 아니라면 선형구조로/double Hashing 으로/ exponentially grow 하며 탐문합니다. 
                }
                index = ++index % table.Length;
            }
            Add_ing(key, value, hashCode); // 드디어 None 에 도달하였다면 값을 반환합니다. 
            return true; 
        }
        /// <summary>
        /// 해당 함수는 값을 추가하는것이 합당한 상황일때만 호출되는 함수입니다. 
        /// Entry에 해당되는 모든 값들을 재정립하여 줍니다. 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="hashCode"></param>
        private void Add_ing (TKey key, TValue value, int hashCode)
        {
            int index = hashCode % table.Length;
            table[index].state = Entry.State.Using;
            table[index].hashCode = hashCode;
            table[index].key = key;
            table[index].value = value;
        }
        public void Remove(TKey key)
        {
            bool tryRemove = TryRemove(key);
            if (tryRemove)
                return;
        }
        /// <summary>
        /// 만약 키 값이 테이블에 저장되어있다면 삭제하고 true반환, 
        /// 없다면 false 를 반환합니다. 
        /// 나머지 알고리즘은 Add와 유사합니다. 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public bool TryRemove(TKey key)
        {
            int hashCode = hashFunc(key);
            int index = hashCode % table.Length;
            bool occupied = false;
            while (table[index].state != Entry.State.None) // None이 아닌이상 반복합니다. 
            {
                if (table[index].state == Entry.State.Deleted)
                {
                    if (table[index].key.Equals(key))
                    {
                        throw new InvalidOperationException("Requested Key has been Erased Already");
                    }
                    continue;
                }
                else if (table[index].state == Entry.State.Using)
                {
                    if (table[index].key.Equals(key))
                    {
                        Remove_ing(key, hashCode);
                        return true;
                    }
                    continue;
                }
                index = ++index % table.Length;
            }
            return false; // 만약 도달하였다면 삭제하고자 하는 값이 없기에, false 를 반환합니다 
        }

        private void Remove_ing(TKey key, int hashCode)
        {
            int index = hashCode % table.Length;
            table[index].state = Entry.State.Deleted;
        }

    }
}
