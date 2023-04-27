using _09._DesignTechnique;

namespace _09._DesignTechniques
{
    internal class Program
    {
        /* 알고리즘 설계 기법 
         */
        /******************************************************
		 * 알고리즘 설계기법 (Algorithm Design Technique)
		 * 
		 * 어떤 문제를 해결하는 과정에서 해당 문제의 답을 효과적으로 찾아가기 위한 전략과 접근 방식
		 * 문제를 풀 때 어떤 알고리즘 설계 기법을 쓰는지에 따라 <효율성이> 막대하게 차이
		 * 문제의 <성질과> <조건에> 따라 알맞은 알고리즘 설계기법을 <선택하여> 사용
		 * 
		 * 알고리즘을 택할때에 짚고 넘어가야할것은, 
		 * 1. 문제의 성질과, 
		 * 2. 조건에 따른 
		 * 3. 설계기법을 선택하는 것이다. 
		 ******************************************************/

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
			Recursion.Factorial(5); 

        }

		public static void Hanoi()
		{
			// 접근방법: 
			// 1. 문제파악: 규칙에 맞게 탑을 옮기자 
			// 어떠한 계층에 대해서도 동일한 방법으로 옮기는것이 가능한가? 
			// 
		}
    }
}