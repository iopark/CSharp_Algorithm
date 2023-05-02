using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12._ShortestPath
{
    public class Dijkstra
    {
        const int INF = 99999; 
        public static void ShortestPath(int[,] graph, int start, out int[] distance, out int[] path)
        {
            int size = graph.GetLength(0);
            bool[] visited = new bool[size]; // set to false by default? 
            distance = new int[size];
            path = new int[size];

            //헷갈리는 포인트: 어떻게 regardless of the starting position, 해당 포지션에서 연결된 모든 노드에 대한 최단거리를 탐색하는가? 
            // ~~ 이유: 0부터 모든 정점에 대해서 반복하는데, 어떻게 starting 정점값과 연결되어있는지 모르겠다. 

            for (int i = 0; i < size; i++)
            {
                distance[i] = graph[start, i]; // 탐색하는 조건에 대해서는 (start, i) 로 설정하여준다. 
                                            // 이것을 기준으로 만약 다른 INF 값에 대해서 연결할수 있는지 유무가 결정나게 된다. 
                path[i] = graph[start,i] < INF ? start:-1; // Starting 포지션의 직접적으로 연결된 값으로 path 값으로 우선 지정한다. 

            }
            // 주석 기준:  스타팅 값이 3 이다. 
            for (int i = 0; i < size; ++i)
            {
                // 1. 방문하지 않은 정점값은 최단거리 값을 우선적으로 탐색대상으로 지정 
                int minCost = INF;
                int next = -1; 

                for (int j = 0; j < size; ++j)
                {
                    if (!visited[j] &&       
                        distance[j] < minCost)  // 
                    {
                        minCost = distance[j]; // 우선적으로 distance[0] where distance = distance from 3 to {0,1,2,3,4,5,6,7,8}
                        next = j; // where in the iteration where starting node is directed, Next will be a starting node, since the distance is the smallest, 0 
                                // 그게 아닌 상황에서는 가장 가까운 노드가 탐구대상이 된다. 
                                // 또는 기존의 starting node부터 연결되지 않은 값도, starting node 와 연결되어있는 node 가 존재한다면, 해당 노드가 연결되어있는 값들은 연결이 됬다고 가정이 가능하기에, 
                                // 최단거리에 대한 갱신이 starting node 와 직접적인 관계를 가지게 된다. 

                        // distance[next] = from Start 
                    }
                }
                if (next < 0)
                    break; 
                // 2. 직접 연결된 거리보다 (또는 초기거리보단) 거리보다 거쳐서 가는 값이 짧다면 해당거리로 갱신한다. 

                for(int j = 0; j < size; j++)
                {
                    // distance[j] = 
                    // distance[next] = 
                    // graph[next,j] = 
                    if (distance[j] > distance[next] + graph[next,j]) // if 처음 생성한 distance 3을 기준으로 간선의 값들중, 처음 개시한 j에대한 값보다 가장 가까운값 + j 정점부터 j의 가까운 값이 더 작다면, 그것으로 설정한다.  
                    {                                               // 
                        distance[j] = distance[next] + graph[next, j]; // distance 는 이때 갱신이 된다. 
                        path[j] = next; // start위치의 정점 => next위치의 정점 => j 
                            // path또한 이때 갱신된다. 
                    }
                }
                visited[next] = true; // next의 정점은 확인이 됬음을 표기한다. 
            }
        }
    }
}
