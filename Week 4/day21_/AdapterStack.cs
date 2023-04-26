using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04._Stack
{
    // Adapter 디자인 패턴을 적용하는 사례 
    // List 를 이용해서 이미 있던 자료구조를 이용하여 (응용하여) 
    // 새로운 / 조금 다른 방식의 자료구조를 생성하는것이 가능하다. 
    internal class AdapterStack<T>
    {
        private List<T> container; 

        public void Push(T item)
        {
            container.Add(item);
        }

        public T Pop()
        {
            T item = container[container.Count - 1];
            container.RemoveAt(container.Count - 1);
            return item; 
        }

        public T Peek()
        {
            return container[container.Count - 1];
        }
    }
}
