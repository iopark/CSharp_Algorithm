using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._DesignTechniques
{
    
    internal class Hanoi_Tower
    {
        //분할 정복의 사용 예시 
        // 
        // 1. 분할을 하고 
        // 2. 해결하기 쉬운 작은문제에 대하여 해결한후
        // 3. 해당값을 병합한다.
        // 2 번의 답: 그럼 하노이 탑에서 해결할수 있는 가장 작은 단위는 무엇일까? 
        // 하나의 단위를 움직이는 것 
        // 1 번의 답: 분할을 하는 조건은 어떤것인가? 
        // 3개의 판을 옮겨야할때, x = n-1으로 진행하고, 남은 n에 대해서 구현하고, x(n-1) 의 값에 대해서 추가로 분할을 진행한다
        // n-1 개에 대해서 n-1으로 추가 분할을 진행한다 (like a tree) 
        // 3. 해당값을 병합하였을때, n 자체를 옮기는 상황과 동일한가? 
        // yes, 왜냐하면 hanoi 타워의 규칙에 따라서 값을 옮기는 상황에 대해서는, 
        // 타워를 옮기는 상황은 결국 tower의 마지막 한개를 제외한 타워를 옮기고, 남은 디스크를 옮기는것을 반복하는 행위로 정의가 가능하기 때문에,
        // move(1, start, end)로 분할이 가능하여지겠다. 



        public enum Place
        {
            Left, Middle, Right
        }

        public void Hanoi()
        {
            Move(5, 0, 2); 
        }

        public static void Move(int count, int start, int end) 
        {
            if (count ==1) // 1이 남은 상황이 해당 recursion 의 base case 이자, 해결가능한 가장 작은 단위이자 종료조건이자 병합 트리거가 되겠다. 
            {
                //
                int node = stick[start].Pop(); 
                stick[end].Push(node);
                Console.WriteLine($"{start} 스틱에서 {end} 스틱으로 {node} 이동"); 
                return;
            }
            int other = 3 - start - end; // 3- 0 -2 initially  // 1. 최소단위로 분할 작업 
            // if left, middle = 3- (0-1) = 2 = right 
            // if left, right = 3 - (0 -2) = 1 = middle
            Move(count - 1, start, other); // 1. 어떠한 타워도 n-1 을 진행하고 
            Move(1, start, end); // 2. 남은 디스크를 옮기고
            Move(count - 1, other, end); // 3. 그 남은 타워에 대해서 옮기는 작업을 해주는것을 반복하여 주며, 

            //if (start == Place.Left)
            //{
            //    if (end == Place.Right)
            //    {
            //        other = Place.Middle; 
            //    }
            //}
            //else
            //{
            //    other = Place.Right; 
            //}
        }

        public static Stack<int>[] stick; 

        public static void Run()
        {
            stick = new Stack<int>[3]; 
            for (int i = 0; i <stick.Length; i++)
            {
                stick[i] = new Stack<int>(); 
            }

            for (int i = 5; i > 0; i--)
            {
                stick[0].Push(i); 
            }

            Move(3, 0, 2); // where Move(Number of Plate, left, to right) 
        }
        
    }
}
