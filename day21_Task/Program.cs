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

        }
    }
}