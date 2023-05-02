using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12._ShortestPath
{
    public class FloydWarshall
    {
        public static void ShortestPath(int[,] graph, out int[,] costTable, out int[,] pathTable)
        {
            int size = graph.GetLength(0);
            costTable = new int[size, size];
            pathTable = new int[size, size];

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    costTable[y,x] = graph[y, x];
                    pathTable[y, x] = -1; 
                }
            }

            for (int middle =  0; middle < size; middle++)
            {
                for (int start =0; start < size; start++)
                {
                    for(int end =0; end < size; end++)
                    {
                        if (costTable[start,end] > costTable[start, middle] + costTable[middle, end])
                        {
                            costTable[start, end] = costTable[start, middle] + costTable[middle, end];
                            pathTable[start,end] = middle;
                        }
                    }
                }
            }
        }
    }
}
