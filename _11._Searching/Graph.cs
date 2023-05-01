using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._Searching
{

    // 인접 행렬 그래프 

    // 그래프는 기본적으로 유연적인 간선의 움직임이 존재한다. 
    public class Node
    {
        //List<Node> edges 이것도 하나의 방법이지만, ; 
        List<List<int>> listGraph; // 이것이 정배다. 
        List<List<(int, int)>> weightedListGraph; // 가중치 그래프

        // Adjacency List Graph 인접리스트 그래프 
        public void CreateGraph()
        {
            listGraph = new List<List<int>>();
            for (int i = 0; i < 5; i++)
            {
                listGraph.Add(new List<int>());
            }
            listGraph[0].Add(1);
            listGraph[1].Add(0);
            listGraph[1].Add(3);
        }
    }
}
