using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day21_Task
{
    /// <summary>
    /// this bracket is under special condition, quite common to man kind, OCD syndrome. 
    /// if you dare try to insert this guy an incomplete or simply wrongly stacked brackets it will return F 
    /// but. but. you can still mix up between brackets .. oddly. 
    /// </summary>
    public class Bracket
    {
        public string Bracket_Left { get; set; }
        public string Bracket_Right { get; set; }

        /// <summary>
        /// Returns false 
        /// </summary>
        /// <param name="bracket"></param>
        /// <returns></returns>
        public bool Complete_Test(string bracket)
        {
            string[] char_list = bracket.Replace(" ", "").Split(); 
            Task_DataStructure.Stack<string> chars = new Task_DataStructure.Stack<string>();
            foreach (string item in char_list) chars.Push(item);

            return Ocd(chars); // 문제 없으면 true, 있으면 false 전달 
        }

        public bool Ocd (Task_DataStructure.Stack<string> s_Brackets)
        {
            // if start with right, return false 
            // if first left, second !left or null, return false 
            // if loop ends and bracket !left, return false 
            // run the loop 
            while (true)
            {
                int count = 1;
                int pair_count = count % 2; 
                string surveillance = s_Brackets.Pop();
                if (surveillance == Bracket_Right)
                    return false;
                if (pair_count == 0 && surveillance != Bracket_Right)
                    return false;
                if (count == s_Brackets.Count && surveillance != Bracket_Right)
                    return false;
                else
                    return true; 
                    
                count++;
            }
            
        }
    }
}
