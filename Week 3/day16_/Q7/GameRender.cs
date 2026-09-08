using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q7
{
    /// <summary>
    /// 게임의 입력, 그리고 갱신이후 출력을 위해, 다음 프레임을 생성하기 위한 캡슐화된 객체 
    /// </summary>
    ///
    public struct RenderPoints
    {
        public string blank = "  ";
        public string sideWall = "|";
        public string floorCeiling = "-";
        public string corner = "+";
        public RenderPoints(string blank, string sideWall, string floorCeiling, string corner) 
        {
            this.blank = blank;
                this.sideWall = sideWall;
            this.floorCeiling = floorCeiling;
            this.corner = corner;
        }
        
    }
    public class GameRender
    {
        RenderPoints symbols;
        Player player; 
        Map map; 
        Block[,] b_Map; int[,] i_Map;
        Pointer playerPointer; 
        public GameRender(Map map, Player player)
        {
            this.map = map;
            this.player = player;
            this.b_Map = map.blockMap_;
            this.i_Map = map.numberMap_;
            playerPointer = player._importPlayerPosition; 

        }

        public void RenderMap()
        {
            StringBuilder aBlock = new StringBuilder();
            for (int y = 0; y < 7; y++)
            {
                StringBuilder sb = new StringBuilder();
                for (int x = 0; x < 7; x++)
                {
                    if ((x >= 1 && y >= 1) && (x <= 5 && y <= 5))
                    {
                        sb.Append(map.numberMap_[x-1,y-1].ToString().PadLeft(4).PadRight(4));
                        continue; 
                    }
                    switch (b_Map[x, y])
                    {
                        case Block.Numbers:
                            sb.Append("  ".ToString().PadLeft(4).PadRight(4));
                            break;
                        case Block.Wall_LR:
                            sb.Append("|".ToString().PadLeft(4).PadRight(4));
                            break;
                        case Block.Wall_Corner:
                            sb.Append("+".ToString().PadLeft(4).PadRight(4)); 
                            break;
                        case Block.Wall_TB:
                            sb.Append("-".ToString().PadLeft(4).PadRight(4));
                            break;
                    }
                    
                }
                sb.Append('\n');
                aBlock.Append(sb);
            }
            Console.WriteLine(aBlock.ToString());
        }


        public void RenderGame()
        {
            Console.Clear(); 
            Console.WriteLine("0을 통해 다른숫자를과 교환하여 보세요"); 
            RenderMap();
            Console.Write("위: \u2191 아래: \u2193 왼쪽: \u2190 오른쪽: \u2192 끄기: ESC\n");
            Console.WriteLine($"{player._importPlayerPosition.x},{player._importPlayerPosition.y}");
            Console.SetCursorPosition(player._importPlayerPosition.x*4+6, player._importPlayerPosition.y+2);
            
        }

        public void RenderEnd()
        {
            Console.Clear();
            Console.WriteLine("Thanks for Playing"); 
            Console.ReadKey();
        }
    }
}
