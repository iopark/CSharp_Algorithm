using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_Github
{
    //해당 주석문은 GitHub 에 올라와있는 또다른 접근 방법으로 HashTable객체를 구현한 자료이다. 
    // 기존 수업내용과는 별개로, Delegate값을 같이 이용하였으며, Delegate자체에 대해서 아직 많이 어색한 나의 입장에선, 
    // 알고리즘 자체에 대해서 알아가고 친해져가는것에 메리트를 느낌으로, 추가 주석작업을 진행하였다. 

    internal class HashTable<TKey, TValue> where TKey : IEquatable<TKey>
    {
        private const int DefaultCapacity = 1000;

        private struct Entry
        {
            public enum State { None, Using, Deleted }

            public int hashCode;
            public State state;
            public TKey key;
            public TValue value;
        }
        // Where syntax for Func delgate is Func<TParameter, TOutput>
        private Func<TKey, int> hashFunc; // hashFunc 는 키를 반환받게 되며, index값을 돌려주는 hashFunc 를 사용하게 된다. 
        private Entry[] table;

        public HashTable()
        {
            table = new Entry[DefaultCapacity];
            hashFunc = HashFunc; // 
        }

        public HashTable(Func<TKey, int> hashFunc)
        {
            this.table = new Entry[DefaultCapacity];
            this.hashFunc = hashFunc;
        }
        /// <summary>
        /// 생성자, 맴버변수 생성이후에는 인덱서가 있다면 인덱서를 생성하여준다. 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public TValue this[TKey key] // 기존의 배열과는다르게 키로써 해싱된 값을 기반으로 배열에 접근하기에, Tkey 입력을 받고, 
        { 
            get
            {
                TValue value;
                if (TryGetValue(key, out value))
                    return value;
                else
                    throw new KeyNotFoundException(); // 찾는 값이 없다면 KeyNotFound를 뱉는다. 
            }
            set
            {
                TryInsert(key, value, InsertionBehavior.OverrideExist);
            }
        }

        public void Add(TKey key, TValue value)
        {
            TryInsert(key, value, InsertionBehavior.ThrowOnExisting);
        }

        public bool TryAdd(TKey key, TValue value)
        {
            return TryInsert(key, value, InsertionBehavior.None);
        }

        public void Clear()
        {
            table = new Entry[DefaultCapacity];
        }

        public bool ContainsKey(TKey key)
        {
            return TryGetValue(key, out var value);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            int index = FindIndex(key);

            if (index < 0)
            {
                value = default(TValue);
                return false;
            }
            else
            {
                value = table[index].value;
                return true;
            }
        }

        public bool Remove(TKey key)
        {
            int index = FindIndex(key);

            if (index < 0)
            {
                return false;
            }
            else
            {
                table[index].state = Entry.State.Deleted;
                return true;
            }
        }

        private int HashFunc(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("key");

            return key.GetHashCode();
        }

        private int DoubleHash(int index)
        {
            return ++index % table.Length;
        }

        private enum InsertionBehavior { None, OverrideExist, ThrowOnExisting }
        private bool TryInsert(TKey key, TValue value, InsertionBehavior behavior) // 만약 값이 들어갈수 있다면 true, 아니라면 false반환한다. 
        {
            int hashCode = hashFunc(key); // hashCode 는 해쉬 함수로 입력받은 key 를 어떠한 숫자로 변환한 최초값이며, 해당 값은 key 에 대해서 consistent한 값을 배출해야만 한다. 
            int index = Math.Abs(hashCode) % table.Length; // 이후에 배열에 대해서는 plus 이여야 하기에 Abs이용, 그리고 배열에 사용하기에 적합하게 하기 위하여 table.Length 로 나머지를 한다. 
            while (table[index].state == Entry.State.Using) // 찾는 배열에 이미 key가 이용되어 있다면, 충돌방지를 위해 오픈 Address로써 충돌을 방지한다 (double hashing 이후 값을 반환하여준다)
            {
                if (key.Equals(table[index].key)) // 충돌발생할수 있는 현장에 왔다면, 
                {
                    switch (behavior) // 
                    {
                        case InsertionBehavior.OverrideExist:
                            table[index].hashCode = hashCode;
                            table[index].key = key;
                            table[index].value = value;
                            return true;
                        case InsertionBehavior.ThrowOnExisting:
                            throw new ArgumentException();
                        case InsertionBehavior.None:
                        default:
                            return false;
                    }
                }
                index = DoubleHash(index);
            }

            table[index].hashCode = hashCode;
            table[index].state = Entry.State.Using;
            table[index].key = key;
            table[index].value = value;
            return true;
        }

        private int FindIndex(TKey key)
        {
            int hashCode = hashFunc(key);
            int index = Math.Abs(hashCode) % table.Length;
            while (table[index].state == Entry.State.Using)
            {
                if (key.Equals(table[index].key))
                {
                    return index;
                }
                index = DoubleHash(index);
            }

            return -1;
        }
    }
}