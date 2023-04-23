using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/* 해당 프로젝트는 스택을 응용하는 연습중 하나로써, 
 * 스택을 자료구조적으로 이해하고, 
 * 스택의 역할을 자료구조적으로 이해하고 (값을 어떻게 접근, 탐색, 삽입, 삭제)하는지에 대하여 생각하고, 
 * 해당 고찰을 응용한 알고리즘을 구현하여보는 연습을 해보는 과제이다.
 * 스택은 리스트와 매우 유사한 방법으로 값을 다루지만, FiLo 방식으로 값을 삽입, 접근에 있어서 차이점이 있다. (Adapter: List, Adaptee: Stack)
 * Big-O적으로 보면 차이가 없지만, 스택은 Time/Space Complexity를 넘어서 (실제로도 List와 capacity대비 비효율적일수있는 count를 제외하면 차이점이 없어보인다)
 * 기계공과 같은 프로그래머들에게는 하나의 고유역할로 인해서 많이 도입/사용되는 자료구조형이다. 
 */ 

/* 해야할일 목록 
 * 1. 후위 표기법 방식으로 전환 기능 구현: 컴퓨터는 오른손잡이여서, (안타깝께도), 오른쪽 부터 읽게 되는데, 
 *  a. 이것또한 스택으로 구현이 가능할까..?
 * 2. 변환된 표기법을 적용한 계산기능 구현 
 * 
 * 찾아본 결과 후기표기법에 대해서 스택에 응용하는 방식은 이렇다 
 * 1. 숫자라면 스택에 푸쉬 한다 
 * 2. 사칙연산 이라면 2개를 팝 하여 계산하고 계산된 값을 넣는데, 
 * 2-1. 계산할때에 나중에 나오는 녀석이 앞으로 온다. 
 * 예시. if stack = [x][y], stack.pop = y,x, stack.push(x _ops_ y), not y _ops_ x. 
 */ 

// 스택의 기능 
// 1.  
// 2. foreach 또한 선입선출방식이다  
// C# 기준 반복기는 단방향인데, 반복기 정의 당시 index[0] 부터가 아닌 index[length-1]부터 아래로 진행되게 된다. 
namespace day21_Task
{
    public class Calculator
    {
        protected double stackTop = 0;
        protected double stackBottom = 0;
        protected double postOps;
        Task_DataStructure.Stack<string> stack = new Task_DataStructure.Stack<string>();
        public Task_DataStructure.Stack<double> calculation = new Task_DataStructure.Stack<double>();
        public Calculator(Task_DataStructure.Stack<string> stack) 
        {
            this.stack = stack;
            stack.Reverse();
        }
        public string postFixExpression { get; set; }

        public void Run()
        {
            while (stack.Count > 0) 
            { 
                string frag = stack.Pop();
                SegmentIdentifier(frag);
            }
            Console.WriteLine($"Calculation is done, the final value is {calculation.Peek()}");
        }

        public void SegmentIdentifier(string identifier)
        {
            switch (identifier)
            {
                case "+":
                    AssignValue();
                    plus();
                    break;
                case "-":
                    AssignValue();
                    minus();
                    break;
                case "*":
                    AssignValue();
                    mult();
                    break;
                case "/":
                    AssignValue();
                    div();
                    break;
                default:
                    calculation.Push(double.Parse(identifier));
                    //Console.WriteLine($"{calculation.Count} 번째로 {double.Parse(identifier)}이 저장되었습니다"); 
                    break;
            }
        }

        public double Result()
        {
            Console.WriteLine($"{calculation.Count} Remains"); 
            return calculation.Pop(); 
        }
        private void minus()
        {
            postOps = stackBottom - stackTop;
            calculation.Push(postOps);
        }

        private void plus()
        {
            postOps = stackBottom + stackTop;
            calculation.Push(postOps);
        }

        private void div()
        {
            postOps = stackBottom / stackTop;
            calculation.Push(postOps);
        }

        private void mult()
        {
            postOps = stackBottom * stackTop;
            calculation.Push(postOps);
        }

        private void AssignValue()
        {
            stackTop = calculation.Pop(); // 젤 위의 값이 stackTop
            stackBottom = calculation.Pop(); // 그다음 값은 stackBottom 이다. 
        }

        
    }
    class PostFixConverter // 스트링 값을 받아서 스택에 정리하기 위해서 기호, 숫자를 정렬하기 위한 객체 
    {
        //우선 욕심 내려놓고, 괄호 기능은 거세한 사칙연산에 대해서만 똑똑한 계산기 구현 
        // 지금 부터 제작할 후기표기법은 위의 스택의 계산기의 형태에 맞게 계산할수 있도록 정리해주는 역할을 수행해야 한다.
        // 따라서 이와같은 규칙으로 왼쪽에서 오른쪽으로 스택에 정렬될 값을 나열하는 객체를 생성한다. 
        // 1. 먼저 수행되야할 연산을 추출하고 기존연산규칙에 따라 순위를 매긴뒤 왼쪽에서 오른쪽으로 차례대로 나열한다. 
        // 2-1 . 만약 */ 둘중 하나라면 오른쪽값이 스택에 들어간후 바로 대입한다 
        // 2-2. 만약 +- 둘중 하나라면, 오른쪽값 대입 이후에도 */가 없다면 대입, 있다면 */가 소진될때까지 보관된다. 
        // 그리해서 완료된 식은 스트링 형식으로 스택 계산기를 위해 전달한다. 
        Task_DataStructure.Stack<string> stack = new Task_DataStructure.Stack<string>();
        //Task_DataStructure.Queue<string> operations = new Task_DataStructure.Queue<string>(); // 막상 이건 사용하지 않게 됬다. 
        public Task_DataStructure.Stack<string> newStack = new Task_DataStructure.Stack<string>();
        private List<int> ops_type = new List<int>(); // 오히려 해당 리스트값을 인덱스를 통해서 활용했다. 
        protected bool lowOpIn = false; // 연산자 정렬을 위해 사용이됨. 만약 true 라면 해당 스택에 값을 모두 꺼내고
                                        // 
        protected int isPlusMinus = 0;     // 이 두 값도 이용하지 않았다. 
        protected int isDivMultiple = 0;   // 이 두 값도 이용하지 않았다. 
        public bool midShutDown = false;
        // 문제 1. 중위 표기법을 숫자, 그리고 연산자를 구분하여 컬랙션으로 보관하기 
        // 해답 1. Regex Class 를 이용하여 나눠버리기 source: https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.split?view=net-6.0

        public string[] IntoArray(string expression)
        {
            string pattern = @"(-)|(+)|(*)|(/)";
            string[] array = Regex.Split(expression, pattern);
            return array; 
        }

        // 해답 2 : 스택응용하며 한번 스택에 대한 지식 고체화 하기 

        public void GeneratePostFix(string expression)
        {
            IntoStack(expression);
            SortStack();
            if (midShutDown == true)
            {
                Console.WriteLine("Something went wrong while making this");
            }
            Console.WriteLine("Please Use the newStack Stack<string> for Calculation"); 
        }
        public void IntoStack(string expression)
        {
            StringBuilder sb = new StringBuilder();  
            string[] temp = expression.ToCharArray().Select(x => x.ToString()).ToArray();
            foreach (string c in temp)
            {
                stack.Push(c);
                PopNumber(stack, ref sb);
                if (sb.Length == 0) // 새로 추가한 값이 숫자가 아니었다면, 
                {
                    Op_Stack(c); //연산자 스택에 새로 값 추가 
                }
            }
            stack.Reverse();
            return;
        }

        public void SortStack() // 이제 정리하기전 알게 된 사실이 있습니다. 연산의 종류별 양을 알고 있기에, +_- 는 *_/ 가 있다면 가 등장하기 전까지 스택에 추가되지 않습니다. 
        {
            
            Task_DataStructure.Stack<string> tempOpsStack= new Task_DataStructure.Stack<string>();
            int count = 0; 
            foreach (string s in stack) // e.g. 1+2*3+4*5
            {
                string sorting = stack.Pop();
                if (int.TryParse(s, out int n))
                    newStack.Push(sorting);
                else
                { // 0,1, 1,2, 2,3
                    PopOps(s, ref count, newStack, tempOpsStack); 
                }
            }
            FinalOps(newStack, tempOpsStack);
        }

        public void PopOps(string ops, ref int count, Task_DataStructure.Stack<string> newStack, Task_DataStructure.Stack<string> tempOpsStack) // 스택속에 연산자에 대한 처리 방법 구현 
        {
            if (count != 0 && ops_type.Count != count) // 만약 카운팅 하는것이 처음이라면 연산값이 스택에 들어가선 안되며, 마지막수라면 스택에 추가하면 안되기 때문이다.  
            {
                if (ops_type[count-1] != 0) // 해당 연산자가 * 혹은 / 이라면 
                {
                    while (tempOpsStack.Count > 0) // 저장 되있던 있는값을 전부 새로 정렬될 스택으로 넣습니다 
                    {
                        newStack.Push(tempOpsStack.Pop());
                    }
                    tempOpsStack.Push(ops);
                    count++;
                }
                else // 만약 연산자가 +_- 이라면, 우선 연산스택에 저장하고 계산스택에 추가하진않는다.  
                {
                    tempOpsStack.Push(ops);
                    count++; 
                }
            }
            else
            {
                count++; //마지막 연산값이든, 처음이든, 카운팅 자체는 에러를 이르키는 녀석은 아닐것임으로, 같은 공간에 작업하게 허락한다. 
                tempOpsStack.Push(ops);
            }
        }

        public void FinalOps(Task_DataStructure.Stack<string> newStack, Task_DataStructure.Stack<string> tempOpsStack)
        {
            if (tempOpsStack != null)
            {
                while (tempOpsStack.Count > 0) { newStack.Push(tempOpsStack.Pop()); }
            }
        }

        public void PopNumber(Task_DataStructure.Stack<string> stack, ref StringBuilder temp_)
        {
            if (int.TryParse(stack.Peek(), out int test)) // 만약 마지막 으로 넣었던 값이 숫자였는지 검사하고
            {
                temp_.Append(stack.Pop()); // 맞다면 일시저장소 값과 통합한다. 이는 만약 숫자가 2자리수 이상이라면 다음 연산전까지 값을 계속 
                stack.Push(temp_.ToString());
            }
            else // 아니라면 일시 저장소는 다시 빈칸으로 만듭니다 
                temp_.Clear();
        }


        //public void GetSegment(char ops) 
        //{
        //    while (!Op_Identifier(ops))
        //    {
        //        this.segment.Add(ops);
        //    }

        //}

        // 캐릭터 들을 모아서 하나의 숫자를 반환하여줍니다 
        //public List<string> SortList(string segment)
        //{

        //    segment = segment.Split("*"); 

        //}
        public void Op_Stack(string operation)
        {
            switch (operation)
            {
                case "+":
                case "-":
                    //operations.Enqueue(operation);
                    ops_type.Add(0); 
                    isPlusMinus++;
                    break;
                case "*":
                case "/":
                    //operations.Enqueue(operation);
                    ops_type.Add(1);
                    isDivMultiple++;
                    break;
                default:
                    Console.WriteLine("Invalid symbol has entered!"); 
                    midShutDown = true;
                    break;
            }
        }

    }


}
