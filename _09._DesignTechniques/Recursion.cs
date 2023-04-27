using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Part of Lecture Material: gitHub 
namespace _09._DesignTechnique
{
    internal class Recursion
    {
        /******************************************************
		 * 재귀 (Recursion)
		 * 
		 * 어떠한 것을 정의할 때 자기 자신을 참조하는 것
		 ******************************************************/

        // <재귀함수 조건>
        // 1. 함수내용 중 자기자신함수를 다시 호출해야함
        // 2. 종료조건이 있어야 함

        // <재귀함수 사용>
        // Factorial : 정수를 1이 될 때까지 차감하며 곱한 값
        // x! = x * (x-1)!;
        // 1! = 1;
        // ex) 5! = 5 * 4 * 3 * 2 * 1
        public static int Factorial(int x)
        {
            if (x == 1) // 종료조건은 x ==1 이며, 이렇게 설정이 가능한 이유는 우리는 어떠한 값을 넣어도 결국 값이 1로 도달할것임을 알기 때문이다. 
                return 1;
            else
                return x * Factorial(x - 1); // 마찬가지로 
        }
    }
}