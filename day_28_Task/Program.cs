namespace day_28_Task
{
    internal class Program
    {
        const int INF = 999999; 
        static void Main(string[] args)
        {
            int[,] graph = new int[8, 8]
            {
                {   0,   1, INF,   2, INF, INF, INF, INF},
                {   1,   0,   8,   9, INF,   4,   8, INF},
                { INF,   8,   0, INF, INF,   8,   9, INF},
                {   2,   9, INF,   0, INF,   6, INF, INF},
                { INF, INF, INF, INF,   0, INF,   1, INF},
                { INF,   4,   1, INF, INF,   0, INF, INF},
                { INF,   1, INF, INF,   1, INF,   0, INF},
                { INF, INF, INF, INF, INF, INF, INF,   0},
            };
            Console.WriteLine("<다익한 스트라야>");
            Dijkstra vandijk = new Dijkstra();
            
            int[] distance; int[] path;
            Dijkstra.SearchFirst(in graph, 0, out distance, out path);

            foreach(int dist in distance)
            {
                Console.WriteLine(dist);
            }
            PrintDijkstra(distance, path);

        }

        private static void PrintDijkstra(int[] distance, int[] path)
        {
            Console.Write("Vertex");
            Console.Write("\t");
            Console.Write("dist");
            Console.Write("\t");
            Console.WriteLine("path");

            for (int i = 0; i < distance.Length; i++)
            {
                Console.Write("{0,3}", i);
                Console.Write("\t");
                if (distance[i] >= INF)
                    Console.Write("INF");
                else
                    Console.Write("{0,3}", distance[i]);
                Console.Write("\t");
                if (path[i] < 0)
                    Console.WriteLine("  X ");
                else
                    Console.WriteLine("{0,3}", path[i]);
            }
        }
    }
}