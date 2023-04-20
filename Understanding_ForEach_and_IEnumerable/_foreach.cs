using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Understanding_ForEach_and_IEnumerable
{
    /* apparently, you can technically use foreach if there's, 
     * 1. GetEnumerator() function which must be public, 
     * and a bool Movement() function 
     * and a ?(a nullable) Current get/set property 
     */

    public class Foreach_
    {
        public int Current { get; private set; }
        private int step;
        public bool MoveNext()
        {
            if (step >= 5) return false;
            Current = step++;
            return true;
        }
    }
}

