using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day20_Task
{
    public class Sort_<T>
    {
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

        public void Sort(IList value) 
        {

            int n = value.Count;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (Comparer.Default.Compare(value[j] , value[j + 1]) > 0)
                    {
                        // swap temp and arr[i]
                        int temp = (int)value[j];
                        value[j] = value[j + 1];
                        value[j + 1] = temp;
                    }
        }
    }
}
