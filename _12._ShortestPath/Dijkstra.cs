using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12._ShortestPath
{
    public class Dijkstra_Lecture
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

                // vertex 0, 
                for (int j = 0; j < size; ++j) // this iteration just makes sure this loop is iterated for the amount of vertices involved in the graph 
                {
                    if (!visited[j] &&       // based on Visited, and distance initialized through starting node 3, 
                        distance[j] < minCost)  // this forloop would select closest node, itself first, which would return vertex 3. 
                                                // in the 2nd iteration, would run to check closest node from 3, choose that as next val which would be 0. 
                                                // 
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
                    // 3을 기준으로 알고있는 모든 가중치 값에 대해서, next 값을 기준으로 새로운 최단거리를 갱신한다. 
                    if (distance[j] > distance[next] + graph[next,j]) // 만약, next와, next에 연결된 값이 있고, 기존의 distance 값보다 작다면, 같이 연결된 값이 있기에, 해당 정점또한 starting node와 연결되어 있고,
                                                                      // 해당값에 어떠한 값이 연결되어 있는지 추가적으로 확인이 가능해진다 (애초에 중복탐사를 막기위해 visited{} 로 관리가 되어진다. 
                    {                                               // 
                        distance[j] = distance[next] + graph[next, j]; // distance 는 이때 갱신이 된다. 
                                                                        // this renewed distance would be tested again in the forloop at line 22 - 28, where the closest vertex value may be updated.  
                        path[j] = next; // start위치의 정점 => next위치의 정점 => j 
                            // path또한 이때 갱신된다. 
                    }
                }
                visited[next] = true; // 해당 정점은 탐문됬음으로 표기되며, 더이상 탐구대상이 되지 않는다. (specifically for the line (22-28).  
            }
        }
    }
}
