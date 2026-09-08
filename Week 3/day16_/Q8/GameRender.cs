using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q8
{
    public class GameRender
    {
        Map map;
        GameCheck gC; 

        public GameRender(Map map, GameCheck gC) 
        { 
            this.map = map;
            this.gC = gC;
        }
        public void RenderMap()
        {
            StringBuilder aBlock = new StringBuilder();
            for (int y = 0; y < 5; y++)
            {
                StringBuilder sb = new StringBuilder();
                for (int x = 0; x < 5; x++)
                {

                    sb.Append(map.bingoMap_[x,y].ToString().PadLeft(4).PadRight(4));

                }
                sb.Append('\n');
                aBlock.Append(sb);
            }
            Console.WriteLine(aBlock.ToString());
        }

        public void RenderGame()
        {
            Console.Clear();
            Console.WriteLine("=====================빙고=====================");
            Console.WriteLine($"빙고 갯수 : {gC.totalBingo}");
            RenderMap();
        }
    }
}
