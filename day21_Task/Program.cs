namespace day21_Task
{
    /* 1. 스택 (어댑터), 큐(순환배열) 구현 
     * +++++++++++++주석파티++++++++++++++
     * 2. [스택] 괄호 검사기, where ()(), (()) spits true, if ()), )()(, false 
     * 3. [스택] 우선순위 없는 계산기 (사칙연산 개념상실한 녀셕) (사칙연산 준수) 
     * 4. [큐] 속도가 빠른 플레이어부터 행동 
     * 5. [큐] 요세푸스 순욜 구현 
     */ 

    internal class Program
    {
        static void Main(string[] args)
        {
            BracketEvaluator bracketTest = new BracketEvaluator()
            {
                Bracket_Left = "(",
                Bracket_Right = ")"
            };
            string test1 = "()()";
            string test2 = "()(()())";
            string test3 = ")(())(";
            bracketTest.Test_(test1); 
            Console.WriteLine(bracketTest.FinalEval);
            bracketTest.Test_(test2);
            Console.WriteLine(bracketTest.FinalEval);
            bracketTest.Test_(test3);
            Console.WriteLine(bracketTest.FinalEval);
            Console.WriteLine("========================브라킷 구현 완료 ===========================");
            Console.WriteLine("========================기본계산기(괄호x) 테스터 ===========================");
            PostFixConverter converter = new PostFixConverter();
            PostFixConverter converter2 = new PostFixConverter();
            string test4 = "1+2*3+4*5"; // 27
            string test5 = "1+2+3+4*5+6"; //32
            converter.GeneratePostFix(test4);
            converter2.GeneratePostFix(test5);
            Task_DataStructure.Stack<string> testrun = converter.newStack;
            Task_DataStructure.Stack<string> testrun2 = converter2.newStack;
            Calculator calculator = new Calculator(testrun);
            Calculator calculator2 = new Calculator(testrun2);
            calculator.Run();
            calculator.Result(); // 결과값을 프린트 합니다 27 
            calculator2.Run();
            calculator2.Result(); // 결과값을 프린트 합니다 32
            Console.WriteLine("========================계산기 구현 완료 ===========================");
            Console.WriteLine("=================== 요셉아 형들 그만죽여.. =========================");
            Josephus problem1 = new Josephus(8, 4);
            problem1.Trigger();
            //최후로 죽은자는 6 번째 사람 입니다
            Josephus problem2 = new Josephus(41, 7);
            problem2.Trigger();
            //최후로 죽은자는 31 번째 사람 입니다
            Console.WriteLine("========================요셉 ㅃ2===========================");

        }
    }
}