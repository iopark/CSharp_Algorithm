using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._Searching
{
    public class Search
    {
        //Sequential Search 
        public static int SequentialSearch<T>(in IList<T> list, in T item) where T : IEquatable<T>
        {
            for (int i= 0; i<list.Count; i++)
            {
                if (item.Equals(list[i]))
                    return i;
            }
            return -1;
        }
        //Binary Search 
        public static int BinarySearch<T>(in IList<T> list, in T item) where T : IComparable<T>
        {
            int low = 0; // 작은 위치의 index 
            int high = list.Count - 1; // 가장 큰 위치의 범위를 설정해준다. 이는 이후에 좁혀가며 포획하듯이 탐색하기 위함이다. 
            while (low <= high) // 범위를 좁혀가며 값을 검색한다. 
            {
                int mid = (low + high) >> 1; // 2; //컴퓨터는 나누기에 약하다. 나누기 다음으로 강한 수는 곱하기
                                             // 하지만 2의 곱셈, 나누기라면, 비트연산자로 조져라 
                int compare = list[mid].CompareTo(item); // if list[mid] > item, returns 
                if (compare < 0) // if list[mid] < item
                    low = mid + 1;
                else if (compare > 0) // if list[mid] > item 
                    high = mid - 1;
                else // if list[mid] == item; 
                    return mid; 
            }
            // if low is ever to get higher than high, it means the value being searched does not exist 
            return -1; 
        }

        // DFS & BFS Optimized algorithm for the Graph , or any data structure which requires specifying start -> end point of search 

        // DFS 
        public static void DFS(bool[,] graph, int start, out bool[] visited, out int[] parents)
        {
            visited = new bool[graph.GetLength(0)];
            parents = new int[graph.GetLength(0)];

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                visited[i] = false; // [false, false, false, false, false] 
                parents[i] = -1;
            }
            SearchMode(graph, start, visited, parents); 
        }

        private static void SearchMode(bool[,] graph, int start, bool[] visited, int[] parents)
        {
            visited[start] = true; // 시작지점에 대해서 True 로 시작한다. 
            for (int i = 0; i < graph.GetLength(0); i++)// Where getLength represent all the vertices 
            {
                if (graph[start,i] && // edge 끼리 연결되어있으면 탐색, 
                    !visited[i])// 또한 해당 정점이 visit 하지 않은곳에 대해서만 탐색 
                                // 따라서 이것이 해당 분할정복의 basecase가 되기도 한다. 
                {
                    parents[i] = start; 
                    SearchMode(graph, i, visited, parents); // basecase에 도달할때까지, DFS 방식으로 탐색 구현 
                } 
            }
        }

        public static void BFS(bool[,] graph, int start, bool[] visited, int[] parents)
        {
            visited = new bool[graph.GetLength(0)];
            parents = new int[graph.GetLength(0)];

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                visited[i] = false; parents[i] = -1;
            }

            Queue<int> bfsQueue = new Queue<int>();

            bfsQueue.Enqueue(start);

            while (bfsQueue.Count > 0) // 더이상 Enqueue가 들어올게 없을때까지 분할정복 
            {
                int next = bfsQueue.Dequeue();

                visited[next] = true;

                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    if (graph[next, i] && !visited[i]) // 연결되어있어야 하며, 방문한적 없는 정점에 대해서 탐색한다. 
                    {
                        parents[i] = next;
                        bfsQueue.Enqueue(i); 
                    }
                }
            }
        }


    }
}
