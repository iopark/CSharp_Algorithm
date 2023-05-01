//using System;
//using System.Text;

//namespace day25_Task
//{
//    internal class Hanoi
//    {

//        public static void Main_Hanoi()
//        {
//            string input = Console.ReadLine();
//            int diskCount = int.Parse(input);
//            rods = new Stack<int>[3];
//            StringBuilder sb = new StringBuilder();
//            int moves = 0; 
//            for (int i = 0; i < rods.Length; i++)
//            {
//                rods[i] = new Stack<int>();
//            }
//            for (int i = 0; i <= diskCount; i++)
//            {
//                rods[0].Push(i);
//            }
//            Move(diskCount, 0, 2, ref moves, sb);
//            string finale = $"{moves}\n"+sb.ToString(); 
//            // Or simply print Console.WriteLine($"{Math.Pow(2, diskCount) -1}")
//            Console.WriteLine(finale);
//        }

//        public static Stack<int>[] rods;
//        public static void Move(int count, int from, int to, ref int moves, StringBuilder sb)
//        {
//            if (count == 1)
//            {
//                int plate = rods[from].Pop();
//                rods[to].Push(plate);
//                moves++;
//                sb.Append($"{from + 1} {to + 1}\n");
//                string finale = sb.ToString().Trim('\r', '\n');
//                return;
//            }

//            int otherrod = 3 - from - to;
//            // in order to complete Move(count, from, to) where from = stack[0] and to = stack[2]
//            Move(count -1, from, otherrod, ref moves, , sb); // subdivision 1 - moving the top to let the bottom move
//            Move(1, from, to, ref moves, sb); // moving the bottom disk to 
//            Move(count - 1, otherrod, to, ref moves,  sb); // subdivision 2, making the top follow the bottom  
//        }
//    }
//}