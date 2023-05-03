using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13._PathFinding
{

    public class Astar
    {
        // 모든 값에 대해서는 

        const int CostStraight = 10;
        const int CostDiagnoal = 14;

        static Point[] Direction =
        {
            new Point (0, 1),       // Top
            new Point (0, -1),      // Bottom
            new Point (-1, 0),      // Left
            new Point (1, 0),       // Right 
            new Point( -1, +1 ),    // 좌상
			new Point( -1, -1 ),    // 좌하
			new Point( +1, +1 ),    // 우상
			new Point( +1, -1 )     // 우하 
        };
        public static bool PathFinding(bool[,] tileMap, Point start, Point end, out List<Point> path)
        {
            int ySize = tileMap.GetLength(0); // y, x 를 구분하여, x != y map 에 대해서 대응하도록 한다. 
            int xSize = tileMap.GetLength(1);
            path = new List<Point>();
            bool[,]visited = new bool[ySize, xSize]; // 탐색된 정점에 대해서는 중복탐색을 이처럼 방지한다.

            AsNode[,] nodes = new AsNode[ySize, xSize];
            PriorityQueue<AsNode, int> nextPointPQ = new PriorityQueue<AsNode, int>();

            // 0. 시작 정점을 생성하여 추가하여 준다. 
            // Where depending on the Heuristic function, the distinction between A* and dijkstra becomes clearer
            AsNode startNode = new AsNode(start, null, 0, Heuristic(start, end));
            nextPointPQ.Enqueue(startNode, startNode.f); // 최초 검색값은 시작점으로 지정한 정점이다. 

            // 도착지에 관하여 
            while (nextPointPQ.Count > 0)
            {
                // 1. 다음으로 탐색할 정점을 꺼내기 (AsNode.f 값에 의해 결정된 최상단 순위의 정점값) 
                AsNode nextNode = nextPointPQ.Dequeue();
                // 2. 해당 정점은 탐색됬음을 알려주자  
                visited[nextNode.point.y, nextNode.point.x] = true;
                // 3. 탐색할 정점이 도착지인 경우, 
                // 도착했다고 판단한경우 
                if (nextNode.point.x == end.x && nextNode.point.y == end.y)
                {
                    Point? pathPoint = end; 
                    
                    while (pathPoint != null)
                    {
                        Point point = pathPoint.GetValueOrDefault();
                        path.Add(point);
                        pathPoint = nodes[point.y, point.x].parent; // 마지막 값의 parent 값을 다시 반복가능한 노드로 설정하여, where start.parent == null, start 값까지 역추적하게 해준다. 
                    }

                    path.Reverse(); 
                    return true; 
                }

                // 4. Astar 탐색을 진행 

                // 상, 하, 좌, 우 방향에 대해서 유망한 정점 탐색 및 힙에 저장 
                for (int i = 0; i< Direction.Length; i++)
                {
                    //renewing coordinate for each respective Direction value 
                    int x = nextNode.point.x + Direction[i].x; 
                    int y = nextNode.point.y + Direction[i].y;

                    // 탐색가능한 값으로 지정하기 위한 조건문들 
                    // 1. 탐색한 정점이 아니여야만 하며 
                    // 2. 해당 정점이 벽에 가거나,
                    // 3. 맵밖에 뛰쳐나갈때는 탐먹금 
                    // 해당 정점은 탐색 대상에 추가한다. 
                    if (x < 0 || x >= xSize || y < 0 || y >= ySize)
                        continue; //해당정점 스킵 
                    else if (tileMap[y, x] == false)
                        continue;
                    else if (visited[y,x])
                        continue;

                    // 4 -2 탐색대상으로 설정하여준다. 
                    int g = nextNode.g + (nextNode.point.x == end.x || nextNode.point.y == end.y ? CostStraight : CostDiagnoal);
                    int h = Heuristic(new Point(x, y), end);
                    AsNode candidateNode = new AsNode(new Point(x, y), nextNode.point, g, h);

                    // 4 -3. 정점의 갱신이 필요한 경우 새로운 정점으로 할당 한다. 
                    // 이제 노드 배열에 정점값을 저장을 할텐데, 이때도 조건이 필요하다. 
                    // 이는 이미 해당 배열에 더 작은 f 값의 정점이 저장될수도 있기 때문이다. 
                    // 따라서 중복으로 최단거리값이 없어지는 경우를 배제하기 위한 수단으로 조건문이 필요하겠다. 

                    if (nodes[y,x] == null || // 해당 정점이 비어있거나, 
                        nodes[y,x].f > candidateNode.f) // 이미 저장된 정점의 점수 값이 갱신된 값 대비 낮을때만, 
                    {
                        nodes[y,x] = candidateNode; // 
                        nextPointPQ.Enqueue(candidateNode, candidateNode.f); // 해당 대상또한 추적 대상으로 선정된다. 
                    }
                     
                }
            }
            //만약 도착지를 찾지 못햇다면, 
            path = null;
            return false; 
        }
        private bool? DiagonalAlley(bool[,] tileMap, Point candidate, int direction)
        {
            if (direction >= 4)
            {
                // leftTop 
                // leftBottom 
                // rightTop 
                // rightBottom 
            }
            return null; 
        }

        // 휴리스틱 (Heuristic) : 
        private static int Heuristic(Point point, Point end)
        {
            // Using Euclidean Distance 
            int y = Math.Abs(point.y - end.y); 
            int x = Math.Abs(point.x - end.x);

            return CostStraight * (int)Math.Sqrt(x * x + y * y);

        }
        private class AsNode
        {
            public Point point; // 정점의 위치값  
            public Point? parent; // 정점의 이전 값, nullable 

            public int f; // where f = f(x) = g(x) + h(x), expected total distance to destination 
            public int g; // 현재까지 진행된 거리  
            public int h; // 휴리스틱: 앞으로 예상되는 거리 

            public AsNode (Point point, Point? parent, int g, int h) // where f is determined by g and h 
            {
                this.point = point;
                this.parent = parent;
                this.g = g; 
                this.h = h;
                this.f = g + h;
            }

        }

        public struct Point // 정보만 제공해주면 되기에, struct 를 이용해주어도 된다. 
        {
            public int x, y;
            public Point(int x, int y)
            {
                this.x = x; this.y = y;
            }
        }
    }
}
