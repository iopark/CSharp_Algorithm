using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day16_test_commit
{
    internal class Q5
    {
        public static void Test5()
        {
            static int[] FindCommonInt(int[] ar1, int[] ar2, int[] ar3)
            {
                int[] overlap1 = ar1.Intersect(ar2).ToArray();
                int[] overlap2 = ar2.Intersect(ar3).ToArray();
                int[] overlapfinale = overlap1.Intersect(overlap2).ToArray();

                return overlapfinale.Distinct().ToArray();

            }
        }
        

    }
}
