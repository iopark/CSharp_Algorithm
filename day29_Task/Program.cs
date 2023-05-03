namespace day29_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool[,] map = new bool[9, 9]
            {
                { false, false, false, false, false, false, false, false, false },
                { false,  true,  true,  true, false, false, false,  true, false },
                { false,  true, false,  true, false, false, false,  true, false },
                { false,  true, false,  true,  true,  true,  true,  true, false },
                { false,  true, false,  true, false, false, false,  true, false },
                { false,  true, false,  true, false, false, false,  true, false },
                { false, false, false, false, false, false, false,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true, false },
                { false, false, false, false, false, false, false, false, false },
            };

            bool[,] map_blocked = new bool[9, 9]
            {
                { false, false, false, false, false, false, false, false, false },
                { false,  true,  true,  true, false, false, false,  true, false },
                { false,  true, false,  true, false, false, false,  true, false },
                { false,  true, false,  true,  true,  true,  true,  true, false },
                { false,  true, false,  true, false, false, false,  true, false },
                { false,  true, false,  true, false, false, false,  true, false },
                { false, false, false, false, false, false, false,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  false, false },
                { false, false, false, false, false, false, false, false, false },
            };
            List<Point> shortestpath; 
            Astar.ShortestPath(map, new Point(1, 1), new Point(1, 7), out shortestpath);

            List<Point_8> shortestpath_Diag;
            Astar_8.ShortestPath_8(map, new Point_8(1, 1), new Point_8(1, 7), out shortestpath_Diag); 

            PrintResult(map, shortestpath);

            PrintResult_8(map, shortestpath_Diag, new Point_8(1, 7), new Point_8(1, 1));

            List<Point_8> shortestpath_Diag_Blocked;

            Astar_8.ShortestPath_8(map_blocked, new Point_8(1, 1), new Point_8(1, 7), out shortestpath_Diag_Blocked);
            PrintResult_8(map_blocked, shortestpath_Diag_Blocked, new Point_8(1, 7), new Point_8(1, 1));
        }

        static void PrintResult(in bool[,] tileMap, in List<Point> path)
        {
            char[,] pathMap = new char[tileMap.GetLength(0), tileMap.GetLength(1)];
            for (int y = 0; y < pathMap.GetLength(0); y++)
            {
                for (int x = 0; x < pathMap.GetLength(1); x++)
                {
                    if (tileMap[y, x])
                        pathMap[y, x] = ' ';
                    else
                        pathMap[y, x] = '#';
                }
            }

            foreach (Point point in path)
            {
                pathMap[point.y, point.x] = '*';
            }

            Point start = path.First();
            Point end = path.Last();
            pathMap[start.y, start.x] = 'S';
            pathMap[end.y, end.x] = 'E';

            for (int i = 0; i < pathMap.GetLength(0); i++)
            {
                for (int j = 0; j < pathMap.GetLength(1); j++)
                {
                    Console.Write(pathMap[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void PrintResult_8(in bool[,] tileMap, in List<Point_8> path, Point_8 endPoint, Point_8 startPoint)
        {
            char[,] pathMap = new char[tileMap.GetLength(0), tileMap.GetLength(1)];
            for (int y = 0; y < pathMap.GetLength(0); y++)
            {
                for (int x = 0; x < pathMap.GetLength(1); x++)
                {
                    if (tileMap[y, x])
                        pathMap[y, x] = ' ';
                    else
                        pathMap[y, x] = '#';
                }
            }

            foreach (Point_8 point in path)
            {
                pathMap[point.y, point.x] = '*';
            }

            Point_8 start = startPoint; // ~~
            Point_8 end = endPoint; // 값을 찾지 못한 상황연출을 위한 임의설정
            pathMap[start.y, start.x] = 'S';
            pathMap[end.y, end.x] = 'E';

            for (int i = 0; i < pathMap.GetLength(0); i++)
            {
                for (int j = 0; j < pathMap.GetLength(1); j++)
                {
                    Console.Write(pathMap[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}