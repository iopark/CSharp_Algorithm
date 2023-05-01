namespace day25_Task
{
    // 3번문제 구현: 괄호 사냥꾼 

    //교수님 풀이 정리 
    // 1. 괄호가 없다는것이 가정되었을때, 가장 낮은 값의 조건은 무엇인가?
    // 2. 해당 조건을 충족하는 방법은 무엇인가? 

    // 1. given that calculation goes from left to right, 가장낮은 값의 조건은 - 가 있는경우 가장 높은값을 - 를 할 경우 가장 낮은 값이 된다. 
    // 2. 때문에 1을 충족하기 위해서는 
    internal class MP_Greedy
    {

        public class Minusplus
        {
            public string[] input_list;
            public int minusIndex;
            public int sum;


            public void Run(string input)
            {
                
                minusIndex = input.IndexOf("-");


                if (minusIndex == -1) // 만약 마이너스값이 없었던 상황이었다면 
                {
                    input_list = input.Split(new char[] { '+', '-'});
                    foreach (string item in input_list)
                    {
                        sum += int.Parse(item);
                    }

                }
                else // 아닌 상황에 대해서는 
                {

                    // 마이너스 이후의 상황에대해서 전부 더하여, 마이너스될 값에 대해서 최대로 증폭시킨다. 
                    string pre_minus = input.Substring(0, minusIndex); //  Greedy 특성으로써, - 에대해서 우선적으로 처리하며, -에 대해서 두값으로 나눈다. 
                    string post_minus = input.Substring(minusIndex + 1, input.Length - minusIndex - 1); // 마이너스를 기점으로 2가지 식으로 구분하며 

                    string[] pre_list = pre_minus.Split(new char[] { '+', '-' }); // 
                    string[] post_list = post_minus.Split(new char[] { '+', '-' });

                    foreach (string item in pre_list) 
                    {
                        sum += int.Parse(item);
                    }

                    foreach (string item in post_list)
                    {
                        sum -= int.Parse(item);
                    }

                }
                Console.Write(sum);

            }
        }
        
        static void Main_MinusPlus()
        {
            string input = Console.ReadLine();
            Minusplus mp = new Minusplus();
            mp.Run(input);
        }
    }
}
