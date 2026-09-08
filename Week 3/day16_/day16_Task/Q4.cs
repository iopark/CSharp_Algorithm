using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day16_test_commit
{
    internal class Q4
    {
        //시험문제 4번 문제 풀이 
        public void Test4()
        {
            Console.Write("입력: ");
            string input = Console.ReadLine();
            input = input.Replace(" ", "").Replace("\n", "");
            char[] input_ar = input.ToCharArray();
            int[] int_ar = Array.ConvertAll(input_ar, i => int.Parse(i.ToString()));
            int sum = int_ar.Sum();
            Console.Write("출력: ");
            Console.WriteLine(sum);
        }
    }
}
