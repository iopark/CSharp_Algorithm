using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day_28_Task
{
    public class Dijkstra
    {
        const int INF = 999999;
        public static void SearchFirst(in int[,] graph, int start, out int[] distance, out int[] path)
        {
            int size = graph.GetLength(0); 
            distance = new int[size]; // 모든 정점들에 대해서 시작 값에 관한 최단거리를 기록하기 위한 배열, 
                                      // 동시에 각 정점별로 어떤식으로든 시작점과 연결이 되어 있다면 해당 값에 대해서 비교하며 최단거리의 갱신값을 기록하는 기록소이기도 하다. 
            path = new int[size];     // 모든 정점들에 대해서 접근이 되었다면, 마지막으로 접근하였던 정점을 기록하는 역할을 한다. 
                                      // 이렇게 접근이 된 값들은 나중에 trace하며 유의미한 정보형태가 되게 된다. 
            bool[] visited = new bool[size]; // visited으로써 이미 탐색이된 정점에 대해서 중복하여 검사하며 의도치않은 덮어쓰기를 방지한다.

            for (int i = 0; i < size; i++)
            {
                distance[i] = graph[start, i]; 
                path[i] = graph[start,i] < INF? start : -1;
            }

            for (int i = 0; i < size;i++) //해당포문의 의미는 모든 정점에 대해서 확인할수 있는 최소한의 장치이다. 
            {
                int minVal = INF;
                int next = -1;  // 그리고 그것은 
                //최초 startnode를 기반으로한 distance와, visited를 기반으로 다음 점검할 정점값을 선정하여 준다. 
                //이를 통하여 비록 startnode 와 직접적으로 연관되어있지않은 값에 대해서 line(46-51) loop 를 통하여 추가적으로 최단값을 갱신하게 된다. 
                for (int j = 0; j < size;j++)
                {
                    
                    if (!visited[j] && // 이전에 탐구된적이 없는 정점에 대해서 
                        distance[j] < minVal ) // 그리고 해당 정점값이 INF 가 아니며, distance 값중 가장 낮다면 
                    {
                        minVal = distance[j];
                        next = j; // 이 값은 이제 startnode 와 간접적/직접적으로 연결이 있으며, 최단거리에 대해서 적합하다고 판정받는다. 
                    }
                }
                if (next < 0)
                    break; // 만약 next 가 -1 로 남게 된다면, 더이상 연관이 있는 정점이 없기에, 박살낸다. 

                for (int j = 0; j < size;j++) 
                {
                    if (distance[j] > distance[next] +graph[next,j]) // 만약 distance[j]가 INF 가 아니라면, 새로운 최단값이 갱신되는 구간이다. 
                    {
                        distance[j] = distance[next] + graph[next, j];
                        path[j] = next; // 또한 path 에 대해서도 접근한 
                    }
                }
                visited[i] = true; // 해당 정점은 탐구됬다고 명시한다. 
            }
            // 고민 사항으로는 start node 가 0이 아닌 3이었다면, 어떻게 이게 3에 대한 최단경로값들을 찾아 줄까 였지만, 
            // 3을 기반으로 설정한 distance 를 기반으로, 그리고 애초에 33, 46 포문이 3 을 기반으로한 distance 로 갱신이 되는 구조로 설정되어있기에, 
            // 이후에 확인 될수 있는 정점에 대해서는 3과 간접적으로 연결된 노드로 취급이 가능하여진다. 


        }
    }
}
