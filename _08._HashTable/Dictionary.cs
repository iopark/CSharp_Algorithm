using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    internal class Dictionary<TKey, TValue> where TKey: IEquatable<TKey>// IDictionary인터페이스로도 객체를 아답터 하거나 할때 이용할수도 있겠다.  
    { // 키는 unique 해야 하며, key 가 같다면 해당 키에 값을 저장해야 하기에, IEquatable로 비교가 가능한 자료형만 받을수 있게 하여 준다. 
        private const int DefaultCapacity = 1000; //List와 비슷하게 최초생성당시 일정한 크기로 생성이 되며, 들어가는 값에 따라서 늘어나게 된다. 

        private struct Entry //들어오는 값의 요소에 대하여 정의. 해당 값은 해싱이후 특정한 위치에 이모든 상태에 대하여 저장하여 준다. 
        {
            public enum State
            {
                None, Using, Deleted
            }
            public State state; // 위치의 상태에 대하여 지정 (충돌을 방지하기 위한 장치) 
            public int hashCode; // 
            public TKey key; // 해싱이 될 키값, 충돌이후 체이닝 이든, 오픈 Addressing 이던 해당 값으로 추적이 가능하게 하는용도도 있다. 
            public TValue value; 
        }

        private Entry[] table; // Dictionary 는 Entry Struct 값으로 구성이 되어있으며, Entry 는 유니크한 key, 그리고 Value 값을 소지한다. 

        public Dictionary()
        {
            table = new Entry[DefaultCapacity]; // 최초 생성당시, 정해진 크기(const Default Capcity)로 리스트의 형태로 생성이 됩니다. 
        }
        /// <summary>
        /// Add 를 할때에는, 1. 해쉬과정을 거쳐, Key 를 특정한 주소값으로 (일정한)변환합니다.
        /// 2. 이후 해당 주소에 입력받은 값을 저장합니다. 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(TKey key, TValue value)
        {
            // Key 를 index로 생성 : Hashing 
            // 해쉬함수에 대해서 크게 4가지 방법이 있는데, 
            // 1. Division Method.
            // 2. Mid Square Method.
            // 3. Folding Method.
            // 4. Multiplication Method 가 있다. 

            // C# 에서는 GetHashCode를 제시한다. 
            // key 를 index로 해싱
            int index = Math.Abs(key.GetHashCode() % table.Length);
            // 2. 사용중이 아닌 index까지 선형으로 interval 1 씩 이동하며, 이용되지않는 인덱스값을 Add하는 장소로지정하여 준다. 
            // 물론 이또한 충돌에 대하여 방지하기 위한 최소한의 장치로 이해하는것이 유익하겠다. 

            while (table[index].state == Entry.State.Using)
            {
                if (key.Equals(table[index].key)) // C#제약사항: 키값이 똑같지만, 다른 데이터가 있는 경우, C#은 이것을 허용해주지않는다. (BST 와 비슷하네)
                                                  // 때문에 이미 있는 키값의 value값을 변환하기 위해서는, 접근하여 직접 변환하는 방식으로 구현한다. 
                {
                    throw new ArgumentException(); 
                }
                else
                { // 오픈 address로 충돌 방지 
                    index = index < table.Length -1 ? index + 1 : 0; 
                    //이중 해싱 index = index < table.Length -1 ? Math.Abs(key.GetHashCode() % table.Length) : 
                }
            }
            // 3. 사용중이 아닌 index로 발견한 경우 그 위치에 저장 
            table[index].hashCode = index;
            table[index].key = key; 
            table[index].value = value;
            table[index].state = Entry.State.Using; // 해당 해싱값에 값을 추가하고, 해당 인덱스의 상태또한 사용중으로 변경하여, 충돌방지에 대한 최소한의 장치를 구현한다. 
        }

        public bool ContainsKey(TKey key)
        {
            TKey target = 
        }
        //인덱서 구현 
        public TValue this[TKey key] // 인덱스 값또한 Tkey 로 구현하는것이 가능하다. 
        {
            get // 충돌사항에 대한 장치를 염두로 두어 값을 접근하게 한다. 
            {
                int index = Math.Abs(key.GetHashCode() % table.Length);
                while (table[index].state == Entry.State.Using)
                {
                    if (key.Equals(table[index].key)) // C#제약사항: 키값이 똑같지만, 다른 데이터가 있는 경우, C#은 이것을 허용해주지않는다. (BST 와 비슷하네)
                                                      // 때문에 이미 있는 키값의 value값을 변환하기 위해서는, 접근하여 직접 변환하는 방식으로 구현한다. 
                    {
                        return table[index].value; 
                    }
                    if (table[index].state != Entry.State.Using) // 해당 키에 대해서 충돌방지를 위해 선형으로 저장된 값을 탐색하였는데, 다음값의 state자체가 using 이아니라면, 해당 키가 없다는것이기에, 
                                                                    // 에러처리를 구현한다. 애초에 저장을 하지않은 곳에 접근을 하게 되면 기존의 인덱스를 지원하는 자료형태는 error를 던진다.  
                    {
                        break;
                    }

                    index = index <table.Length -1 ? index + 1 : 0;
                }
                throw new InvalidOperationException(); 
            }
            set // 충돌사항에 대한 장치를 염두로 두어 값을 접근하게 한다. 
            {
                // 1. key 를 index 로 해싱 
                int index = Math.Abs(key.GetHashCode() % table.Length);
                // 2. key 가 일치하는 데이터가 나올때까지 다음으로 이동 
                while (table[index].state != Entry.State.None)
                {
                    if (table[index].state == Entry.State.Deleted)
                        continue;
                    // 3. 동일한 키값을 찾았을때 덮어쓰기 기능 구현 
                    if (key.Equals(table[index].key)) // C#제약사항: 키값이 똑같지만, 다른 데이터가 있는 경우, C#은 이것을 허용해주지않는다. (BST 와 비슷하네)
                                                      // 때문에 이미 있는 키값의 value값을 변환하기 위해서는, 접근하여 직접 변환하는 방식으로 구현한다. 
                    {
                        table[index].value = value;
                        return;
                    }
                    if (table[index].state != Entry.State.Using) // 해당 키에 대해서 충돌방지를 위해 선형으로 저장된 값을 탐색하였는데, 다음값의 state자체가 using 이아니라면, 해당 키가 없다는것이기에, 
                                                                 // 에러처리를 구현한다. 
                    {
                        break;
                    }

                    index = index < table.Length - 1 ? index + 1 : 0;
                }
                throw new KeyNotFoundException();
            }
        }
        /// <summary>
        /// 삭제시 주의사항: 그저 값을 실제로 삭제하면 충돌하여서 이후에 저장한 값들에대하여 추적이 불가할수도 있게 된다. 
        /// 그렇기에 삭제되는 값에 대해서는 State enum 을 establish/ apply 하여, 삭제한 값은 다루지 않게 하면 된다. 
        /// </summary>
        /// <param name="key"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void Remove(TKey key)
        {
            // 1. key 를 index 로 해싱 
            int index = Math.Abs(key.GetHashCode() % table.Length);
            // 2. key 가 일치하는 데이터가 나올때까지 다음으로 이동 
            while (table[index].state == Entry.State.Using)
            {
                // 3. 동일한 키값을 찾았을때 덮어쓰기 기능 구현 
                if (key.Equals(table[index].key)) // C#제약사항: 키값이 똑같지만, 다른 데이터가 있는 경우, C#은 이것을 허용해주지않는다. (BST 와 비슷하네)
                                                  // 때문에 이미 있는 키값의 value값을 변환하기 위해서는, 접근하여 직접 변환하는 방식으로 구현한다. 
                {
                    table[index].state = Entry.State.Deleted; 
                }
                if (table[index].state != Entry.State.Using) // 해당 키에 대해서 충돌방지를 위해 선형으로 저장된 값을 탐색하였는데, 다음값의 state자체가 using 이아니라면, 해당 키가 없다는것이기에, 
                                                             // 에러처리를 구현한다. 지정한 인덱스가 이용되지않거나 이미 삭제가 된 인덱스 라면, 
                {
                    break;
                }

                index = index < table.Length - 1 ? index + 1 : 0;
            }
            throw new KeyNotFoundException();
        }
    }
}
