using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Part of Lecture Material: gitHub
namespace _09._DesignTechnique
{
    internal class DynamicProgramming
    {
        /******************************************************
		 * 동적계획법 (Dynamic Programming)
		 * 
		 * 작은문제의 해답을 큰문제의 해답의 부분으로 이용하는 상향식 접근 방식
		 * 주어진 문제를 해결하기 위해 부분 문제에 대한 답을 계속적으로 활용해 나가는 기법
		 ******************************************************/

        // 예시 - 피보나치 수열
        int Fibonachi(int x)
        {
            int[] fibonachi = new int[x + 1];
            fibonachi[1] = 1;
            fibonachi[2] = 1;

            for (int i = 3; i <= x; i++)
            {
                fibonachi[i] = fibonachi[i - 1] + fibonachi[i - 2];
            }

            return fibonachi[x];
        }

        //n 개의 정수로 이루어진 임의 의 수열이 주어진다 
        // 우리는 이 중, 연속된 몇개의 수를 택하고, 구할수 있는 합 중 가장 큰 합을 배출하여야한다. 
        // 이때 숫자는 하나 이상이여야 하겠다. 

        // 질문 
        // 동적계획법에 의거한다면, 해결가능한 가장작은 방식을 이용하여 커다란 문제를 해결한다는 것인데, 
        // 1. 해결해야하는 커다란 문제는 무엇인가? 
        // 2. 해결가능한 가장작은 문제는 무엇일까?
        // 3. 2 를 반복해서 1을 획득할수 있을까? 있다면 어떻게 값을 이용할것인가? 

        //답 
        // 1. 연속적인 값을 더한 조합들중, 가장 높은값을 반환하는 조합을 찾아야 한다. 
        // 2. 해결 가능한 가장작은 문제는 1과 1을 더해준후, 해당 값들을 비교하는것이다 
        // 3. 2번이 1번에 응용은 가능하다. 구한값을 

    }
}