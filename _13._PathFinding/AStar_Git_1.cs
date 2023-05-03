using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13._PathFinding
{
    internal class AStar_Git_1
    {
        /******************************************************
		 * A* 알고리즘
		 * 
		 * 다익스트라 알고리즘을 확장하여 만든 최단경로 탐색알고리즘
		 * 경로 탐색의 우선순위를 두고 유망한 해_부터_ 우선적으로 탐색
		 ******************************************************/

        const int CostStraight = 10; // 
        const int CostDiagonal = 14;

        static Point_1[] Direction =
        {
            new Point_1(  0, +1 ),			// 상
			new Point_1(  0, -1 ),			// 하
			new Point_1( -1,  0 ),			// 좌
			new Point_1( +1,  0 ),			// 우
			// new Point_1( -1, +1 ),		    // 좌상
			// new Point_1( -1, -1 ),		    // 좌하
			// new Point_1( +1, +1 ),		    // 우상
			// new Point_1( +1, -1 )		    // 우하
		};

        public static bool PathFinding(in bool[,] tileMap, in Point_1 start, in Point_1 end, out List<Point_1> path)
        {
            int ySize = tileMap.GetLength(0);
            int xSize = tileMap.GetLength(1);

            ASNode[,] nodes = new ASNode[ySize, xSize];
            bool[,] visited = new bool[ySize, xSize]; // 맵에 대해서 추적된 정점에 대해서 기록하는데에 사용하며, 백트래킹과 비슷하게 아마도 마지막으로 추적된 시점으로 백트래킹을 하지않을까?
            PriorityQueue<ASNode, int> nextPointPQ = new PriorityQueue<ASNode, int>();

            // 0. 시작 정점을 생성하여 추가
            ASNode startNode = new ASNode(start, null, 0, Heuristic(start, end));
            nodes[startNode.point.y, startNode.point.x] = startNode; // where iteration goes from y, x. 
            nextPointPQ.Enqueue(startNode, startNode.f); 
            // where f, is heuristic value representing path value to the end point 
            // (시작점, 도착점)을 기점으로 시작한다. 
            while (nextPointPQ.Count > 0) // 힙 자료구조에 저장된 값이 있다면, 진행하며, Enqueue 가 되는 시점은 line 101 이 유일하다. 
            {
                // 1. 다음으로 탐색할 정점 꺼내기
                ASNode nextNode = nextPointPQ.Dequeue();

                // 2. 방문한 정점은 방문표시
                visited[nextNode.point.y, nextNode.point.x] = true;

                // 3. 다음으로 탐색할 정점이 도착지인 경우
                // 도착했다고 판단해서 경로 반환
                if (nextNode.point.x == end.x && nextNode.point.y == end.y)
                {
                    Point_1? pathPoint = end;
                    path = new List<Point_1>();

                    while (pathPoint != null)
                    {
                        Point_1 point = pathPoint.GetValueOrDefault(); // GetValueOrDefault returns the default value of the datatype, which in this case, (int) = (0,0) 
                        path.Add(point);
                        pathPoint = nodes[point.y, point.x].parent;
                    }

                    path.Reverse(); // 도착시점을 기점으로 시작점까지의 길에 대해서 반환하게 해준다. 
                    return true; // 더이상 에이스타 알고리즘 실행 정지 
                }

                // 4. AStar 탐색을 진행
                // a. 방향 탐색, Order is Top, Bottom, Left, and Right. 만약 탐색이 가능한 지점이라면, 
                // <b>b.</b>해당 정점을 기준으로 또다른 탐색 가능한 정점을 힙에 추가한다. (백트래킹 마냥 불가능의 조건에 대한 돌아갈수있는 분기점으로 활용되게 된다) 

                for (int i = 0; i < Direction.Length; i++)
                {
                    int x = nextNode.point.x + Direction[i].x; // up, down, left, and right 
                    int y = nextNode.point.y + Direction[i].y;

                    // 4-1. 탐색하면 안되는 경우
                    // 만약해당 경우를 통과하지 않는다면 다른 남은 방향으로 경로를 확인합니다. 
                    if (x < 0 || x >= xSize || y < 0 || y >= ySize) //만약 0에서 벗어나거나 맵밖으로 나갈시 
                        continue;
                    // 탐색할 수 없는 정점일 경우
                    else if (tileMap[y, x] == false) //만약 접근 불가지역에 도달하였다면,
                        continue;
                    // 이미 방문한 정점일 경우
                    else if (visited[y, x]) // 이미 방문된 지역이라면 
                        continue;

                    // 특정한 방향으로 try 하는 정점값 
                    // 4-2. 탐색한 정점 만들기
                    int g = nextNode.g + ((nextNode.point.x == x || nextNode.point.y == y) ? CostStraight : CostDiagonal);
                    int h = Heuristic(new Point_1(x, y), end);
                    ASNode newNode = new ASNode(new Point_1(x, y), nextNode.point, g, h);

                    // 4-3. 정점의 갱신이 필요한 경우 새로운 정점으로 할당
                    if (nodes[y, x] == null ||      // 탐색하지 않은 정점이거나 (해당 조건은 line 88 에서 추가적으로 점검이 되었다) 
                        nodes[y, x].f > newNode.f)  // 가중치가 높은 정점인 경우
                    {
                        nodes[y, x] = newNode;
                        nextPointPQ.Enqueue(newNode, newNode.f); //  이때 힙에 저장되는 값 덕분에, 유클리드의 최악의상황,
                                                                 //  대각선 기준 꾿꾿이 탐색하였지만 벽에 전부 막히는 상황에 막히며 이미 인접장소가 탐색되었다면, 다른 동떨어진 정점으로 백트래킹 하게 된다. 

                    }
                }
            }

            path = null;
            return false;
        }

        // 휴리스틱 (Heuristic) : 최상의 경로를 추정하는 순위값, 휴리스틱에 의해 경로탐색 효율이 결정됨
        private static int Heuristic(Point_1 start, Point_1 end)
        {
            int xSize = Math.Abs(start.x - end.x);  // 가로로 가야하는 횟수
            int ySize = Math.Abs(start.y - end.y);  // 세로로 가야하는 횟수

            // 맨해튼 거리 : 가로 세로를 통해 이동하는 거리
            // return CostStraight * (xSize + ySize);

            // 유클리드 거리 : 대각선을 통해 이동하는 거리
            return CostStraight * (int)Math.Sqrt(xSize * xSize + ySize * ySize);
        }

        //정점을 구성하게 되는 노드
        private class ASNode
        {
            public Point_1 point;     // 현재 정점
            public Point_1? parent;   // 이 정점을 탐색한 정점 - 이것으로 이전 겂에 대해서 추적하는데에 이용한다. therefore, in the beginning this can be null

            public int g;           // 현재까지의 값, 즉 지금까지 경로 가중치 
            public int h;           // 앞으로 예상되는 값, 목표까지 추정 경로 가중치
            public int f;           // f(x) = g(x) + h(x);

            public ASNode(Point_1 point, Point_1? parent, int g, int h)
            {
                this.point = point;
                this.parent = parent;
                this.g = g;
                this.h = h;
                this.f = g + h;
            }
        }
    }

    public struct Point_1
    {
        public int x;
        public int y;

        public Point_1(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}