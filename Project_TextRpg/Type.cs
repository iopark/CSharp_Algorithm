using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRpg
{
    // 게임의 위치 정보 
    public struct Position
    {
        public int x; 
        public int y;

        public Position(int x, int y)
        {
            this.x = x; this.y = y;
        }
    }

    // Game 의 방향정보 
    public enum Direction
    {
        Left, 
        Right, 
        Up, 
        Down
    }
}
