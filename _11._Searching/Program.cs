using System.Text;

namespace _11._Searching
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool[,] graph = new bool[8, 8]
          {
                { false,  true, false, false, false, false, false, false },
                {  true, false,  true, false, false,  true, false, false },
                { false,  true, false, false,  true,  true, false, false },
                { false, false, false, false, false,  true, false, false },
                { false, false,  true, false, false, false,  true,  true },
                { false,  true,  true,  true, false, false, false, false },
                { false, false, false, false,  true, false, false, false },
                { false, false, false, false,  true, false, false, false },
          };

            // DFS 탐색
            bool[] dfsVisited;
            int[] dfsPath;
            Search.DFS(graph, 0, out dfsVisited, out dfsPath);
            Console.WriteLine("<DFS>");
            PrintGraphSearch(dfsVisited, dfsPath);
            Console.WriteLine();

            // BFS 탐색
            bool[] bfsVisited;
            int[] bfsPath;
            Search.BFS(graph, 0, out bfsVisited, out bfsPath);
            Console.WriteLine("<BFS>");
            PrintGraphSearch(bfsVisited, bfsPath);
            Console.WriteLine();
        }

        private static void PrintGraphSearch(bool[] visited, int[] path)
        {
            Console.Write("Vertex");
            Console.Write("\t");
            Console.Write("Visit");
            Console.Write("\t");
            Console.WriteLine("Path");

            for (int i = 0; i < visited.Length; i++)
            {
                Console.Write(i);
                Console.Write("\t");
                Console.Write(visited[i]);
                Console.Write("\t");
                Console.WriteLine(path[i]);
            }
        }
    }
    
}
