namespace day25_Task
{
    // 3번문제 구현: 괄호 사냥꾼 

    //교수님 풀이 정리 
    // 1. 괄호가 없다는것이 가정되었을때, 가장 낮은 값의 조건은 무엇인가?
    // 2. 해당 조건을 충족하는 방법은 무엇인가? 

    // 1. given that calculation goes from left to right, 가장낮은 값의 조건은 - 가 있는경우 가장 높은값을 - 를 할 경우 가장 낮은 값이 된다. 
    // 2. 때문에 1을 충족하기 위해서는 
    internal class Program
    {
        // Divide and Conquer - Most likely using Recursion here again 
        public class Origami
        {
            public string[] input_list;
            public int count;
            public bool[,] canvas;
            public int white; // white is true
            public int blue; // blue is false 


            public void Run()
            {
                string input_count = Console.ReadLine();
                count = int.Parse(input_count);
                canvas = new bool[count, count];
                for (int i = 0; i < count; i++)
                {
                    string line_input = Console.ReadLine();
                    string[] intoArray = line_input.Split(" ");
                    int rowCount = 0;
                    foreach (string item in intoArray)
                    {
                        bool block = int.Parse(item) == 1 ? true : false;
                        canvas[i, rowCount] = block;
                        rowCount++;
                    }
                    rowCount = 0;
                }
                Divide(0, 0, count, count);
                Console.WriteLine(white);
                Console.Write(blue);
            }

            public void Divide (int x, int y, int sizex, int sizey)
            {
                if (AllColor(x, y, sizex, sizey)) // 제이스 케이스는 꼭 숫자가 아니여도 되며, 특정한 조건으로도 구현이 가능하다. 
                { // 또한 베이스케이스로 가는조건이 한가지만 아니어도 되며, 여러가지를 같이 재귀하게 하되 (동일한 규격으로 하면 예측이 가능해진다) 
                    bool color = canvas[x, y];
                    if (color)
                    {
                        white++;
                    }
                    else
                        blue++;
                    return;
                }

                Divide(x, y, sizex/2, sizey/2); // divide by the first quarter
                Divide(x + sizex / 2, y, sizex / 2, sizey / 2);
                Divide(x, y + sizey / 2, sizex / 2, sizey / 2); 
                Divide(x+sizex / 2,y+sizey / 2,sizex/2, sizey/2);
            }

            public bool AllColor(int x, int y, int sizex, int sizey)
            {
                bool check = canvas[x, y]; // 잘린 종이의 0,0 첫번째되는 숫자를 기준으로 전부 같은 종류를 가지고 있는지 확인합니다. 

                for (int i = x; i < x+sizex; i++)
                {
                    for (int j = y; j < y+sizey; j++)
                    {
                        if (canvas[i, j] != check) 
                            return false;
                    }
                }

                return true;
            }
        }
        
        static void Main(string[] args)
        {

            Origami origami = new Origami();
            origami.Run();
        }
    }
}
