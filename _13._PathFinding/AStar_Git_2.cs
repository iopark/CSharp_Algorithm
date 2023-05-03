using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13._PathFinding
{
    internal class AStar_Git_2
    {
        /******************************************************
		 * A* 알고리즘
		 * 
		 * 다익스트라 알고리즘을 확장하여 만든 최단경로 탐색알고리즘
		 * 경로 탐색의 우선순위를 두고 유망한 해부터 우선적으로 탐색
		 ******************************************************/

        const int CostStraight = 10; // g, h 값을 위한 가로, 세로 에 대한 값 
        const int CostDiagonal = 14; // g, h 값을 위한 대각선 값 

        // 
        static Point_2[] Direction =
        {
            new Point_2(  0, +1 ),			// 상
			new Point_2(  0, -1 ),			// 하
			new Point_2( -1,  0 ),			// 좌
			new Point_2( +1,  0 ),			// 우
			// new Point( -1, +1 ),		    // 좌상
			// new Point( -1, -1 ),		    // 좌하
			// new Point( +1, +1 ),		    // 우상
			// new Point( +1, -1 )		    // 우하
		};

        public static bool PathFinding(in bool[,] tileMap, in Point_2 start, in Point_2 end, out List<Point_2> path)
        {
            int ySize = tileMap.GetLength(0);
            int xSize = tileMap.GetLength(1);

            ASNode[,] nodes = new ASNode[ySize, xSize];
            bool[,] visited = new bool[ySize, xSize];
            PriorityQueue<ASNode, int> nextPointPQ = new PriorityQueue<ASNode, int>();

            // 0. 시작 정점을 생성하여 추가
            ASNode startNode = new ASNode(start, null, 0, Heuristic(start, end));
            nodes[startNode.point.y, startNode.point.x] = startNode;
            nextPointPQ.Enqueue(startNode, startNode.f);

            while (nextPointPQ.Count > 0)
            {
                // 1. 다음으로 탐색할 정점 꺼내기
                ASNode nextNode = nextPointPQ.Dequeue();

                // 2. 방문한 정점은 방문표시
                visited[nextNode.point.y, nextNode.point.x] = true;

                // 3. 다음으로 탐색할 정점이 도착지인 경우
                // 도착했다고 판단해서 경로 반환
                if (nextNode.point.x == end.x && nextNode.point.y == end.y)
                {
                    Point_2? pathPoint = end;
                    path = new List<Point_2>();

                    while (pathPoint != null)
                    {
                        Point_2 point = pathPoint.GetValueOrDefault();
                        path.Add(point);
                        pathPoint = nodes[point.y, point.x].parent;
                    }

                    path.Reverse();
                    return true;
                }

                // 4. AStar 탐색을 진행
                // 방향 탐색을 진행하는데, 방향에 따라서 목적지에 따른 값이 더 유망하다면, 해당 방향성또한 유망하다 취급한다. 

                for (int i = 0; i < Direction.Length; i++)
                {
                    int x = nextNode.point.x + Direction[i].x;
                    int y = nextNode.point.y + Direction[i].y;

                    // 4-1. 탐색하면 안되는 경우
                    // 맵을 벗어났을 경우
                    if (x < 0 || x >= xSize || y < 0 || y >= ySize)
                        continue;
                    // 탐색할 수 없는 정점일 경우
                    else if (tileMap[y, x] == false) // defined by the tile map 
                        continue;
                    // 이미 방문한 정점일 경우
                    else if (visited[y, x])
                        continue;

                    // 4-2. 탐색한 정점 만들기
                    int g = nextNode.g + ((nextNode.point.x == x || nextNode.point.y == y) ? CostStraight : CostDiagonal);
                    int h = Heuristic(new Point_2(x, y), end);
                    ASNode newNode = new ASNode(new Point_2(x, y), nextNode.point, g, h);

                    // 4-3. 정점의 갱신이 필요한 경우 새로운 정점으로 할당
                    if (nodes[y, x] == null ||      // 탐색하지 않은 정점이거나
                        nodes[y, x].f > newNode.f)  // 가중치가 높은 정점인 경우
                    {
                        nodes[y, x] = newNode;
                        nextPointPQ.Enqueue(newNode, newNode.f);
                    }
                }
            }

            path = null;
            return false;
        }

        // 휴리스틱 (Heuristic) : 최상의 경로를 추정하는 순위값, 휴리스틱에 의해 경로탐색 효율이 결정됨
        private static int Heuristic(Point_2 start, Point_2 end)
        {
            int xSize = Math.Abs(start.x - end.x);  // 가로로 가야하는 횟수
            int ySize = Math.Abs(start.y - end.y);  // 세로로 가야하는 횟수

            //Generally, if unit's movement is limited to the grid, L,R,T,B, could go with Manhattan 
            // if movement is not limited to the sides of grid, e.g. can move diagonally, then better to go with euclid

            // 맨해튼 거리 : 가로 세로를 통해 이동하는 거리
            // return CostStraight * (xSize + ySize);
            // 

            // 유클리드 거리 : 대각선을 통해 이동하는 거리
            return CostStraight * (int)Math.Sqrt(xSize * xSize + ySize * ySize);
        }
        // show me how sqrt((x2 - x1)^2 + (y2 - y1)^2) == 

        private class ASNode
        {
            public Point_2 point;     // 현재 정점
            public Point_2? parent;   // 이 정점을 탐색한 정점

            public int g;           // 현재까지의 값, 즉 지금까지 경로 가중치
            public int h;           // 앞으로 예상되는 값, 목표까지 추정 경로 가중치
            public int f;           // f(x) = g(x) + h(x);

            public ASNode(Point_2 point, Point_2? parent, int g, int h)
            {
                this.point = point;
                this.parent = parent;
                this.g = g;
                this.h = h;
                this.f = g + h;
            }
        }
    }

    public struct Point_2
    {
        public int x;
        public int y;

        public Point_2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}

