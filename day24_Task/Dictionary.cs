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
            public enum State
            {
                None, Using, Deleted
            }
            public TKey key;
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
            return key.GetHashCode(); 
        }
        //생성자 기능구현이후에는 인덱서가 존재한다면 인덱서를 구현하여 준다. 
        public TValue this[TKey key]
        {
            get
            {
                int hash = hashFunc(key);
                int hasCode = hash % table.Length;

                return 
          
            }
            set
            {
                table[key].value = value;
            }
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
        /// 3 -1. 만약 값이 Using 이라면 
        /// 3 -2. 만약 값이 Deleted 이라면 = 값을 오버라이드 합니다 State = Using Again 
        /// 3 -3. 만약 값이 None 이라면  = 값을 추가하며, 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool TryInsert(TKey key, TValue value)
        {
            int hashCode = hashFunc(key);
            int index = hashCode % table.Length;
            bool occupied = false; 
            while (table[index].state != Entry.State.None) // None이 아닌이상 반복합니다. 
            {
                if (table[index].state == Entry.State.Deleted)
                {
                    Add_ing(key, value, hashCode);
                    return true;
                }
                else if (table[index].state == Entry.State.Using)
                {
                    if (table[index].key.Equals(key))
                    {
                        occupied = true;
                        break;
                    }
                    continue;
                }
                index = ++index % table.Length;
            }
            if (occupied)
                throw new InvalidOperationException();
            Add_ing(key, value, hashCode);
            return true; 
        }

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
            else
                throw new InvalidOperationException();
        }
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
                        occupied = true;
                        break;
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
            if (occupied)
                throw new InvalidOperationException();
            return true;
        }

        private void Remove_ing(TKey key, int hashCode)
        {
            int index = hashCode % table.Length;
            table[index].state = Entry.State.Deleted;
        }

    }
}
