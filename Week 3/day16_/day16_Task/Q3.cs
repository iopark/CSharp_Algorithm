using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day16_test_commit
{
    internal class Q3
    {  
        // Q3 구현 문제 
        public static bool IsPrime(int n)
        {
            if (n <= 1) return false;
            for (int i = n - 1; i >= 2; i--)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }
        public static void Test3()
        {
            string input = Console.ReadLine();
            int input_conv = int.Parse(input);
            bool verdict = IsPrime(input_conv);
            Console.WriteLine($"{verdict}: {input_conv} 은 프라임수가 아닙니다");
        }
    }
}
