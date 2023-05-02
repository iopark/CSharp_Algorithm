using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12._ShortestPath
{
    internal class FloydWarshall_Git
    {
        /******************************************************
		 * 플로이드-워셜 알고리즘 (Floyd-Warshall Algorithm)
		 * 
		 * 모든 노드에서 출발하여 다른 노드로 가는 각각의 최단 경로를 구함
		 * 모든 노드를 거쳐가며 최단 거리가 갱신되는 조합이 있을 경우 갱신 (새로운 조합 발현) 
		 ******************************************************/

        const int INF = 99999;
        // [선택정점] -a- [정점] -b- [다음정점] 의 경로에 대해서만 탐색후, Min(a,b) 최단의 거리를 가진 조합을 반환하는 알고리즘 
        // 
        public static void ShortestPath(in int[,] graph, out int[,] costTable, out int[,] pathTable)
        {
            int count = graph.GetLength(0);
            costTable = new int[count, count];
            pathTable = new int[count, count];

            for (int y = 0; y < count; y++)
            {
                for (int x = 0; x < count; x++)
                {
                    costTable[y, x] = graph[y, x]; // 값 복사 
                    pathTable[y, x] = -1; // 우선 모든 값 -1으로 설정 
                }
            }

            for (int middle = 0; middle < count; middle++) //why mid first?: 중간값을 설정하는이유는 중간값을 기준으로 연결되는 start , end 에 대해서 탐색하며,
                                                           //연결되는 모든 vertex 에 대해서 탐색하기 때문이다. 
            {
                for (int start = 0; start < count; start++) // start 정점값 설정 
                {
                    for (int end = 0; end < count; end++) // End 정접값 설정 , where Evaluating value is [v_start, v_end
                    {
                        if (costTable[start, end] > costTable[start, middle] + costTable[middle, end])
                        {
                            costTable[start, end] = costTable[start, middle] + costTable[middle, end];
                            pathTable[start, end] = middle;
                        }
                    }
                }
            }
        }
    }
}
