using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public class Sort<T> : IComparable, IEnumerable<Sort>
    {
        protected IList<T> list; 
        public IList<T> List { get { return list; } set { list = value; } }
        
        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;
            Sort<T> newSort = obj as Sort<T>;
            Enumerator<Sort> enumerator = newSort.GetEnumerator();
            if (newSort != null)
            {
                return this.List.
            }
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

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this.list); 
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this.list);
        }

        public struct Enumerator : IEnumerator<T>
        {
            private int index;
            private IList<T> list;
            private T current; 

            public Enumerator(IList<T> list)
            {
                this.list = list;
                this.index = 0;
                this.current = default(T);
            }
            public T Current => current;

            object IEnumerator.Current => (object)current;

            public void Dispose()
            {

            }

            public bool MoveNext()
            {
                if (index < list.Count)
                {
                    current = list[index++];
                    return true;
                }
                else
                {
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
