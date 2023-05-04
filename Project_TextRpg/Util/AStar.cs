using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRpg
{
    public class Astar
    {
        const int vert_horizontal = 10;
        const int diagonal = 14;
        static Point[] Direction =
        {
            new Point (0, 1),       // Top
            new Point (0, -1),      // Bottom
            new Point (-1, 0),      // Left
            new Point (1, 0)       // Right 
            //new Point( -1, +1 ),    // Left Top[ 
			//new Point( -1, -1 ),    // Left Bottom 
			//new Point( +1, +1 ),    // Right Top 
			//new Point( +1, -1 )     // Right bottom  
        };

        // where tile = [y, x] flipped x,y for sake of graphic rendering 
        public static bool ShortestPath(bool[,] Map, Point start, Point end, out List<Point> shortestpath)
        {
            int sizeY = Map.GetLength(0);
            int sizeX = Map.GetLength(1);
            shortestpath = new List<Point>();
            bool[,] visited = new bool[sizeY, sizeX];
            PriorityQueue<StarNode, int> contestingNodes = new PriorityQueue<StarNode, int>();

            // must also have a matrix which saves vertices prior to the 'search'. 
            StarNode[,] nodes = new StarNode[sizeY, sizeX];// 이건 나중에 route 를 전달할때에 용이하게 사용될수 있다. 

            // Start with the node of the starting position 

            StarNode initial = new StarNode(start, null, 0, Heuristic(start, end));
            contestingNodes.Enqueue(initial, initial.f);

            while (contestingNodes.Count > 0)
            {

                StarNode contestant = contestingNodes.Dequeue();
                //Welcome to the testing ground 
                visited[contestant.point.y, contestant.point.x] = true;
                nodes[contestant.point.y, contestant.point.x] = contestant;
                // if contestant is the final node 
                if (contestant.point.x == end.x && contestant.point.y == end.y)
                {
                    // must retrive the route which has been taken to get to the destination 
                    Point? toInitial = contestant.point;
                    // null 이 아닐때 까지 path 에 저장해야만 하는데, 
                    while (toInitial != null)
                    {
                        // 1. path 에 해당 point 저장 
                        // 2. 해당 point 의 parent point 를 반복문을 위해 저장 
                        Point previous = toInitial.GetValueOrDefault();
                        shortestpath.Add(previous);
                        toInitial = nodes[previous.y, previous.x].parent;
                    }
                    shortestpath.Reverse();
                    return true;
                }

                //이후에는 탐색하는 정점의 목표점의 근접한 주변값에 대해 탐색이 필요합니다. 

                for (int i = 0; i < Direction.Length; i++)
                {
                    int new_x = contestant.point.x + Direction[i].x;
                    int new_y = contestant.point.y + Direction[i].y;

                    // 해당 주변값의 상태를 확인한후, 괜찮다면 탐색대기열에 추가합니다 
                    // 1. 이미탐색한 값이면 안되고 
                    // 2. 타일기준 접근불가지역이여서도 안되며 
                    // 3. 맵밖에 나가는 값이여도 안됩니다.
                    if (new_x < 0 || new_x >= sizeX || new_y < 0 || new_y >= sizeY)
                        continue;
                    else if (Map[new_y, new_x] == false)
                        continue;
                    else if (visited[new_y, new_x])
                        continue;

                    Point temp_point = new Point(new_x, new_y);
                    int g = contestant.g + 10; // for vert/horizontal only 
                    int h = Heuristic(temp_point, end);
                    //이후에 추가하기전 마지막으로 검사해야할것은 만약 해당 정점값이 이미 추가가 된 값이라면,
                    //또는.f 값과 비교해 목표치로 더 유망하다면 스왑, 아니라면 포기해야합니다 

                    StarNode temporary = new StarNode(temp_point, contestant.point, g, h);
                    if (nodes[new_y, new_x] == null ||
                        nodes[new_y, new_x].f > temporary.f)
                    {
                        nodes[new_y, new_x] = temporary;
                        contestingNodes.Enqueue(temporary, temporary.f);
                    }
                }
            }
            // if through the loop, false is not given and loop is broken, there's no valid route to destination in this map. 
            shortestpath = null;
            return false;



        }

        private static int Heuristic(Point start, Point end)
        {
            // Using Euclidean distance for the Heuristic value, in deciding whether contesting node is close to the final destination 
            int x = Math.Abs(start.x - end.x);
            int y = Math.Abs(start.y - end.y);

            return vert_horizontal * (int)Math.Sqrt(x * x + y * y);
        }
        public class StarNode
        {
            public Point point;
            public Point? parent;
            public int f; // f = g + h
            public int g; // accumulated value from previous routes 
            public int h; // predicted routes based on certain distance calculation Metric

            public StarNode(Point point, Point? parent, int g, int h)
            {
                this.point = point;
                this.parent = parent;
                this.f = g + h;
                this.g = g;
                this.h = h;
            }
        }

    }
    public struct Point
    {
        public int x;
        public int y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
