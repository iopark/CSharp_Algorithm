using System.Text;

namespace day25_Task
{
    internal class Hanoi
    {

        static void Main_Hanoi()
        {
            string input = Console.ReadLine();
            int diskCount = int.Parse(input);
            rods = new Stack<int>[3];
            StringBuilder sb = new StringBuilder();
            int moves = 0; 
            for (int i = 0; i < rods.Length; i++)
            {
                rods[i] = new Stack<int>();
            }
            for (int i = 0; i <= diskCount; i++)
            {
                rods[0].Push(i);
            }
            Move(diskCount, 0, 2, ref moves, diskCount, sb);
        }

        public static Stack<int>[] rods;
        public static void Move(int count, int from, int to, ref int moves, int initial, StringBuilder sb)
        {
            if (count == 1 && rods[2].Count >= initial -1)
            {
                int plate = rods[from].Pop();
                rods[to].Push(plate);
                moves++;
                sb.Append($"{from + 1} {to + 1}\n");
                Console.WriteLine($"{moves}");
                string finale = sb.ToString().Trim('\r', '\n');
                Console.Write($"{finale}");
                return;
            }
            else if(count == 1)
            {
                int plate = rods[from].Pop(); 
                rods[to].Push(plate);
                sb.Append($"{from + 1} {to + 1}\n");
                moves++;
                return;
            }
            int otherrod = 3 - from - to;

            Move(count -1, from, otherrod, ref moves, initial, sb);
            Move(1, from, to, ref moves,initial, sb);
            Move(count - 1, otherrod, to, ref moves, initial, sb);
        }
    }
}