using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day16_test_commit
{
    internal class Q2
    {
        public static void Test2()
        {
            string input = Console.ReadLine();
            string trim = input.Replace("\n", "");
            string[] input_ar = input.Split(" ");
            Console.WriteLine(input_ar.Length);

        }
    }
}
