using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class List<T>
    {
        private const int DefaultCapacity = 10;

        private T[] items;
        private int size = 0; 

        public List ()
        {
            this.items = new T[DefaultCapacity];
            this.size = 0; 
        }

        public void Add (T item)
        {
            if (size < items.Length )
            {
                
            }
            items[size++] = item; // first set items[size] = item, then size ++ 
            
        }

        public void Grow()
        {
            int newCapacity = items.Length * 2;
            T[] newItems = new T[newCapacity];
            Array.Copy(items, 0, newItems, 0, size); 
            items = newItems;
        }
    }
}
