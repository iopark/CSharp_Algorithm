using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace day21_Task
{
    /// <summary>
    /// this bracket is under special condition, quite common to man kind, OCD syndrome. 
    /// if you dare try to insert this guy an incomplete or simply wrongly stacked brackets it will return F 
    /// but. but. you can still mix up between brackets .. oddly. 
    /// 그리고 주석을 다는 연습을 다시 시작해야겠다. 이유를 적는것도 중요하지만, 왜 해당 라인이 필요한지 적어준다면 협업하는 상황해서 더 유의미한 주석이 되지않을까 싶다. 
    /// </summary>
    public class BracketEvaluator
    {
        public string Bracket_Left { get; set; } // 추가로 이런식으로 원하는 규칙으로 짝이 맞는 값을 찾아야할경우 재활용을 위한 여지를 제공한다. 
        public string Bracket_Right { get; set; }
        public bool Mid_ShutDown = false; 
        public bool FinalEval= false;
        protected int L_Count = 0;  
        protected int R_Count = 0;
        //protected int med_L_Count; // 이전 것들을 가능캐 한다면 이후는 그저 추가 노가다, 혹은 설계 자체에서 수정을 요하게 된다. 
        //protected int med_R_Count;
        //protected int big_L_Count;
        //protected int big_R_Count; // 아마 dict 를 배운 이후에는 더 간단해지지않을까 싶기도 하다. 


        /// <summary>
        /// Returns false 
        /// </summary>
        /// <param name="bracket"></param>
        /// <returns></returns>
        public bool Test_(string bracket)
        {
            string[] char_list = bracket.ToCharArray().Select(c => c.ToString()).ToArray(); // 1. array [char=>str] char 을 다루는것은 이후에 Concatenate 작업에서 일일히 형변환을 요하기에 이와같이 미리 str 로 형변환한다. 
            Task_DataStructure.Stack<string> bracket_stack = new Task_DataStructure.Stack<string>();
            foreach (string item in char_list)
            {
                LR_Identifier(item);
                bracket_stack.Push(item);
                BracketCollector(bracket_stack, item);
            }
            BracketFinalCheck(bracket_stack); // 문제 없으면 true, 있으면 false 전달 
            return FinalEval; 
        }
        private void LR_Identifier(string bracket)
        {
            if (bracket == null)
                throw new ArgumentNullException(bracket);
                if (bracket == Bracket_Left)
                    L_Count++;
                else if (bracket == Bracket_Right)
                    R_Count++;
                else
                {
                Console.WriteLine($"{bracket} is invalid for this calculator!"); 
                Mid_ShutDown = true;
                }
            return;
        }
        /// <summary>
        /// 해당 청소부는 오른쪽값이 들어올때 반응하게 됩니다. 이렇게 이전값이랑 새로들어온값에대해서 처리하는데 스택은 설계하는 입장에서 편리함을 허락합니다. 
        /// 이 기능은 짝을 치워주는 장치로, 짝을 치울수없는 값에 대해서는 파업을 선언합니다. 
        /// </summary>
        /// <param name="stack"></param>
        /// <param name="item"></param>
        private void BracketCollector(Task_DataStructure.Stack<string> stack, string item)
        {

            if (item == Bracket_Right) // 
            {
                if (stack.Count <= 1)
                {
                    if (stack.Peek() == Bracket_Right) // 짝 검사 중 애초에 최초에 들어오거나 스택의 처음으로 들어오는값이 ) 에 대해서 예외처리 하기 위함에 설정하였다. 
                        Mid_ShutDown = true;
                }
                else
                {
                    //if (L_Count >= R_Count) // 사실이 아니라면 아직 들어와야할
                    //{}
                    int CleanCount = R_Count * 2; // 아마 다른 종류의 브라킷을 허용할때에는 이것이 사용될것으로 예상이 됨. 
                    RunCollector(stack); 
                }
            }
            
        }
        /// <summary>
        /// 청소를 하청받게 되는 직원장치이며, 청소의 양이 default로 2 로 설정되어있습니다. 
        /// </summary>
        /// <param name="stack"></param>
        /// <param name="count"></param>
        private void RunCollector(Task_DataStructure.Stack<string> stack, int count = 2)
        {
            Task_DataStructure.Stack<string> collector = new Task_DataStructure.Stack<string>();
            while (count > 0)
            {
                string first = stack.Pop(); 
                collector.Push(first);
                L_Count--; 
                R_Count--;
                count--;
            }
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("새로 방출할 짝입니다: ");
            foreach (string item in collector) { stringBuilder.Append($"{item}"); }
            Console.WriteLine(stringBuilder.ToString()); 
        }

        /// <summary>
        /// 바구니들을 정리후, 남은것이 있다면 무엇인지 보고, 
        /// 남은것이 없다면 짝이 모두 정리됬다고 결론을 내린다. 
        /// </summary>
        /// <param name="stack"></param>
        private void BracketFinalCheck(Task_DataStructure.Stack<string> stack)
        {
            if (stack.Count > 0)
            {
                FinalEval = false;
                Console.WriteLine($"{stack.Count}가 아직 남았고, {printTest(stack)} 가 있네요"); 
            }
            else 
                FinalEval = true;
            return;    
        }

        /// <summary>
        /// 본래 바구니가 잘 확인되는지 테스터 전용 기능 구현 
        /// </summary>
        /// <param name="bracket"></param>
        /// <returns></returns>
        private bool L_Trigger (string bracket)
        {
            return bracket == Bracket_Left;
        }

        /// <summary>
        /// 개발 도중 바구니들이 잘 확인 되고 있는지 검사용 기능 구현 
        /// </summary>
        /// <param name="stack"></param>
        /// <returns></returns>
        private string printTest(Task_DataStructure.Stack<string>stack)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stack.Reverse();
            foreach (string item in  stack)
            {
                stringBuilder.Append(item);
            }
            return stringBuilder.ToString();
        }
        //public bool Ocd (Task_DataStructure.Stack<string> s_Brackets)
        //{
        //    // if start with right, return false 
        //    // if first left, second !left or null, return false 
        //    // if loop ends and bracket !left, return false 
        //    // run the loop 
        //    while (true)
        //    {
        //        int count = 1;
        //        int pair_count = count % 2; 
        //        string surveillance = s_Brackets.Pop();
        //        if (surveillance == Bracket_Right)
        //            return false;
        //        if (pair_count == 0 && surveillance != Bracket_Right)
        //            return false;
        //        if (count == s_Brackets.Count && surveillance != Bracket_Right)
        //            return false;
        //        else
        //            return true; 
                    
        //        count++;
        //    }
            
        //}
    }
}
