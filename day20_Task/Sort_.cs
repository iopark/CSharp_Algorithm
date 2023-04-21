using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace day20_Task
{
    /* 해당 Icomparable 을 선택한 이유 
     * Array, List = IList, 
       Array, List = Object 
       Array, List = IEnumerable 
       IComparer => object 
    그렇기에 obj 값을 
    */
       /* 선택지에는 교수님이 보여준 Comparer 를통해 (obj x, obj y) 두개의 매개변수를 기입하고 -1,0,1, 혹은 default value (where default = declared T) 가 있고
        * 비슷한 다른 예시로는 Comparer 를 형성하는 IComparer 도 있겠다 
        * 다만 나만의 예시로는 IList값이 obj 하위 클래스라는것과, 
        * 또한 자료구조체중 여러값을 가지는 객체인 경우, 그중 하나를 기준으로 델리게이트와는 다른방식으로 사용자의 의도대로 값이 나오도록 설정할수 있다는것, 
        * 지정자를 람다식이 아닌 인터페이스 정의 당시에 설정할수 있다는것이 장점이지않을가 생각이든다. 
        * 오늘 배운 반복기를 통해서 배운 객체에 구현된 인터페이스 값을 다른 것으로도 시연해보고 싶었다. 
        */ 
    public class Sorting: IComparable//IEnumerable
    {
        public IList list; 
        public int index;
        public int count;

        public Sorting(IList list)
        {
            this.list = list;
            this.count = list.Count; 
        }
        public bool IsFixedSize => true;

        public bool IsReadOnly => true;

        public int Count => count;

        public bool IsSynchronized => true;

        public object SyncRoot => true;

        public object? this[int index] { get => list[index]; set { this[index] = value; } }


        public void Sort() {  }

        public int Add(object? value)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(object? value)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(object? value)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, object? value)
        {
            throw new NotImplementedException();
        }

        public void Remove(object? value)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public int CompareTo(object? obj)
        {
            throw new NotImplementedException();
        }


        // TODO:  try to use IComparer at home 
        //protected int val1; 
        //protected int val2;

        //public Sort_(int val1, int val2)
        //{
        //    this.val1 = val1;
        //    this.val2 = val2; 
        //}
        //public int CompareTo(object? obj)
        //{
        //    throw new NotImplementedException();
        //}

        /// <summary>
        /// 성민씨 도움으로 제작한 인터페이스 기용하는 최초 기능함수 구현 
        /// </summary>
        /// <param name="value"></param>
        //public void Sort(IList value) 
        //{

        //    int n = value.Count;
        //    for (int i = 0; i < n - 1; i++)
        //        for (int j = 0; j < n - i - 1; j++)
        //            if (Comparer.Default.Compare(value[j] , value[j + 1]) > 0)
        //            {
        //                // swap temp and arr[i]
        //                int temp = (int)value[j];
        //                value[j] = value[j + 1];
        //                value[j + 1] = temp;
        //            }
        //}


        //망
        //public struct Enumerator : IEnumerator
        //{
        //    private int index;
        //    private Sort sort; 
        //    private IList list;
        //    private object? current; 

        //    public Enumerator(Sort sort)
        //    {
        //        this.sort = sort;
        //        this.list = sort.List;
        //        this.index = 0;
        //        this.current = default(object);
        //    }
        //    public object Current => current;

        //    object IEnumerator.Current => (object)current;

        //    public void Dispose()
        //    {

        //    }

        //    public bool MoveNext()
        //    {
        //        if (index < list.Count)
        //        {
        //            current = list[index++];
        //            return true;
        //        }
        //        else
        //        {
        //            current = default(object);
        //            return false;
        //        }
        //    }

        //    public void Reset()
        //    {
        //        index = 0;
        //    }
        //} // 망 //망
    }
}
