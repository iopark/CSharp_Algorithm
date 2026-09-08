using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q8
{
    public class Map
    {
        private string[,] bingoMap;
        public string[,] bingoMap_ 
        { get { return bingoMap; } 
            set { bingoMap = value; } }
        private Pointer bingoVal;
        public Pointer binggoVal_
        {
            get {return bingoVal; }
            set { bingoVal = value; }
        }
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
        public static string[,] IntoMatrix(int[] map)
        {
            int count = 0;
            string[,] matrix = new string[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrix[i, j] = map[count].ToString();
                    count++;
                }
            }
            return matrix;
        }
        public void SetBingoMap()
        {
            this.bingoMap_ = IntoMatrix(Generate_Array());
        }
    }
}
