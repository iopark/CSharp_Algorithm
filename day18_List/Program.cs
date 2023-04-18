using System;
using System.Collections.Generic;
using System.IO; 
using System.Linq;
using System.Net.Http; 
using System.Text;
using System.Threading; 
using System.Threading.Tasks;

namespace DataStructure
{
    internal class Program
    {
        public void Array_()
        {
            int[] intArray = new int[10];
            // 이런식으로 정해진 자료형의 집합체에 대해서 배열을 활용한ㄷ.ㅏ 
            // 인덱스를 통해서 접근을 하게 되는데, 
            intArray[0] = 1; // 이런식으로 해당배열의 값을 
        }

        public void List_()
        {
        }
        public int FindinDex(int[] intArray, int data)
        {
            for (int i = 0; i < intArray.Length; i++)
            {
                if (intArray[i] == data)
                {
                    return i;
                }
            }return -1; 
        }

        // 
        static void Main(string[] args)
        {
            int[] test = new int[10];
            Array.Resize(ref test, 11); 

            Console.WriteLine("Hello, World!");
        }
    }
}