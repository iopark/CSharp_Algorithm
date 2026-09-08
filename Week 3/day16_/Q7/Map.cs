using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Q7
{
    public enum Block
    {
        Numbers, 
        Wall_TB, 
        Wall_LR,
        Wall_Corner
    }
    /// <summary>
    /// 맵을 추상화 하여 나누는것도 가능할것 같다만, 해당하는 효용성에 대한 시험도 추가적으로 필요해 보인다 
    /// </summary>
    public class Map
    {
        private Block[,] blockMap = new Block[7, 7];
        public Block[,] blockMap_ {  get { return blockMap; } set { blockMap = value; } }
        public Pointer number_Pointer { get; set; }
        private int[,] numberMap; 
        public int[,] numberMap_ { get { return numberMap; } set { numberMap = value; } }
        public static int[] Generate_Array()
        {
            int[] map_deriv = new int[25];
            //int[] temp = new int[25];

            for (int i = 0; i < 24;)
            {
                Random random = new Random();
                int newGen = random.Next(1, 25);

                //Console.WriteLine(newGen);

                bool check = map_deriv.Contains(newGen);

                if (!check)
                {
                    map_deriv[i] = newGen;
                    i++;
                }
                else
                {
                    //Console.WriteLine("false");
                    continue;
                }


            }
            return map_deriv;
        }

        public static int[,] IntoMatrix(int[] map)
        {
            int count = 0;
            int[,] matrix = new int[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrix[i, j] = map[count];
                    count++;
                }
            }
            return matrix;
        }

        public void numberSwap(int left_x, int left_y, int right_x, int right_y)
        {
            int temp = this.numberMap_[left_x, left_y];
            this.numberMap_[left_x,left_y] = this.numberMap_[right_x, right_y];
            this.numberMap_[right_x, right_y] = temp; 
        }

        public void SetNumberMap ()
        {
            this.numberMap = IntoMatrix(Generate_Array()); 
        }

        public Block[,] SetBlockMap()
        {
            for (int y = 0; y < 7; y++)
            {
                for (int x = 0; x < 7; x++)
                {
                    if ((x, y) == (0, 0) || (x, y) == (6, 0) || (x, y) == (0,6) || (x, y) == (6,6))
                    {
                        this.blockMap[x, y] = Block.Wall_Corner;
                        continue;
                    }
                    else if (y == 0 || y == 6)
                    {
                        this.blockMap[x, y] = Block.Wall_TB;
                        continue;
                    }
                    else if (x == 0 || x == 6)
                    {
                       this.blockMap[x, y] = Block.Wall_LR;
                       continue;
                    }
                }
            }
            return this.blockMap; 
            
        }


    }
}
