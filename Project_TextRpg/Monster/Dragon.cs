using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRpg
{
    public class Dragon : Monster
    {
        private int moveCount = 0; 
        public override void MoveAction()
        {
            if (moveCount++ % 2 != 0)
                return; 
            List<Point> path; 
            bool result = Astar.ShortestPath(Data.map, new Point(position.x, position.y),
                new Point(Data.player.position.x, Data.player.position.y), out path);

            if (!result)
                return;

            if (path[1].y == position.y - 1)
                Move(Direction.Up); 
            else if (path[1].y == position.y + 1)
                Move(Direction.Down);
            else if (path[1].x == position.x - 1)
                Move(Direction.Left);
            else if (path[1].x == position.x + 1)
                Move(Direction.Right);
            
        }
    }
}
