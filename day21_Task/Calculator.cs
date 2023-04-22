using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
 *      물론 스택으로 
 */ 

// 스택의 기능 
// 1.  
// 2. foreach 또한 선입선출방식이다  
// C# 기준 반복기는 단방향인데, 반복기 정의 당시 index[0] 부터가 아닌 index[length-1]부터 아래로 진행되게 된다. 
namespace day21_Task
{
    public class Calculator
    {
        class StringConverter // 스트링 값을 받아서 스택에 정리하기 위해서 기호, 숫자를 정렬하기 위한 객체 
        {
            protected string target { get; set; }
            protected Stack<string> segment { get; set; }
            protected (string, Ops_Priority) segment_barcode;

            public enum Ops_Priority
            {
                plusminus = 0, 
                divmult =1, 
                bracket = 2, 
                number = -1
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
            public bool Op_Identifier(char ops)
            {
                switch (ops)
                {
                    case '+':
                    case '*':
                    case '-':
                    case '/':
                        return true; 
                    default:
                        return false;
                }
            }
            public Ops_Priority Categorize(char ops)
            {
                switch (ops)
                {
                    case '+':
                    case '-':
                        return Ops_Priority.plusminus;
                    case '*':
                    case '/':
                        return Ops_Priority.divmult;
                    case '(':
                    case ')':
                        return Ops_Priority.bracket;
                    default:
                        return Ops_Priority.number;
                }
            }
        }
    }

    
}
