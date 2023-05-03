using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day29_Task
{
    // 가장 중요한 것은 A* 는 시작점과 목표점을 기점으로, 어떠한 Heuristic 값을 이용하여, 주변값을 평가하고, 가장 유망한 값 (목표점에 가깝다고 판단되는) 에 대해서 우선적으로 확인 및 해당 값의 인접값에 대해서 확인한다. 
    // 다만 불가능의 조건에 도달하게 되었을때는, 대기중인 포인트로 백트래킹하여 계속하여 목표접에 접근을 시도할수 있다. 
    // 따라서 Heuristic 을 찾기 위한 조건은 Grid 기준 Metric function 을 이용하지만, Grid 가 아닌 것에 대해서도 이용하는것이 가능하며, 
    // Direction의 개념에 대해서 선형적으로 책정하는것뿐만아니라, 다양하게 선정이 가능하겠다. 
    public class Astar
    {
        const int vert_horizontal = 10;
        const int diagonal = 14;
        Point[] Direction =
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
        public bool ShortestPath(bool[,] Map, Point start, Point end, out IList<Point> shortestpath)
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
                // if contestant is the final node 
                if (contestant.point.x == end.x && contestant.point.y == end.y)
                {
                    // must retrive the route which has been taken to get to the destination 
                    Point? toInitial = contestant.point;
                    // null 이 아닐때 까지 path 에 저장해야만 하는데, 
                    while (toInitial != null)
                    {
                        Point previous = nodes[toInitial.y, toInitial.x].parent; ; 
                        shortestpath.Add(toInitial); 
                        initialPoint = nodes[initialPoint.y, initialPoint.x].parent;
                    }
                    Console.WriteLine("종착역에 이르었습니다"); 
                    return true; 
                }

                
            }
            // if through the loop, false is not given and loop is broken, hell there's no path in this map. 
            shortestpath = null;
            Console.WriteLine("없어요 여기 종착점");
            return false; 
            


        }

        private static int Heuristic(Point start, Point end)
        {
            // Using Euclidean distance for the Heuristic value, in deciding whether contesting node is close to the final destination 
            int x = Math.Abs(start.x - end.x);
            int y = Math.Abs(start.y - end.y);

            return vert_horizontal* (int)Math.Sqrt(x*x + y*y);
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
        public struct Point
        {
            public int x; 
            public int y;
            public Point (int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
    }
}
