using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12._ShortestPath
{
    internal class DijkStra_Git
    {
        /******************************************************
		 * 다익스트라 알고리즘 (Dijkstra Algorithm)
		 * 
		 * 특정한 노드에서 출발하여 다른 노드로 가는 각각의 최단 경로를 구함
		 * 방문하지 않은 노드 중에서 최단 거리가 가장 짧은 노드를 선택 후,
		 * 해당 노드를 거쳐 다른 노드로 가는 비용 계산
		 ******************************************************/

        const int INF = 99999;
        public static void ShortestPath(in int[,] graph, in int start, out int[] distance, out int[] path)
        {
            int size = graph.GetLength(0);
            bool[] visited = new bool[size];

            distance = new int[size];
            path = new int[size];
            // 초기 생성 단계
            // Distance = 해당 정점에 등록된 가중간선들에 대해서 저장 
            // Path = 해당 정점의 연결된 값들에 대해서 저장 
            for (int i = 0; i < size; i++)
            {
                distance[i] = graph[start, i];
                path[i] = graph[start, i] < INF ? start : -1;
            }

            for (int i = 0; i < size; i++) // 모든 정점에 대해서, {0 - last} 
            {
                // 1. 방문하지 않은 정점 중 가장 가까운 정점부터 탐색
                int next = -1;
                int minCost = INF;
                for (int j = 0; j < size; j++)
                {
                    if (!visited[j] && // 만약 아직 탐색을 하지 않았거나 
                        distance[j] < minCost) // 탐색하는 간선의 값이 저장된 최단거리보다 짧다면, 
                    {
                        next = j; // 해당 정점을 탐색지점으로 저장 (이후의 최단거리를 탐색하기 위한 조건으로 이용됨. 
                        // Next 값은 X, 의 Y값으로 정점값으로 표기가 되기에, where X.length == Y.length, X 값으로도 이용이 가능하다. 
                        minCost = distance[j]; // 최단거리값도 갱신한다. 
                    }
                }
                if (next < 0)
                    break;

                // 2. 직접연결된 거리보다 거쳐서 더 짧아진다면 갱신.
                for (int j = 0; j < size; j++)
                {
                    // distance[j] : 목적지까지 직접 연결된 거리
                    // distance[next] : 탐색중인 정점까지 거리
                    // graph[next, j] : 탐색중인 정점부터 목적지의 거리
                                                    // [최초(X)] -p[]- [다음정점(Y)] -q[]- [목표되는정점(Z)]
                    if (distance[j] > distance[next] + graph[next, j]) // 만약, 어떠한 p->q (where can be INF) 값보다, p+q 가 더 짧다면, X-Z의 거리를 p+q 로 명시한다.
                    {
                        distance[j] = distance[next] + graph[next, j];
                        path[j] = next;
                    }
                }
                visited[next] = true;
            }
        }
    }
}
