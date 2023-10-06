# Path Finding 

## Dijkstra Algorithm 
  1. 그래프 기준 탐색을 안한노드중 가장 가까운 노드를 선정한다. (A)
  2. A를 기점으로 연결된 노드중 가장 가까운 노드를 선정하고 (B), if O - B > O - A - B, O - B = O-A-B
  3. O를 기점으로 가장 경로들로 최신화 하여준다.
  4. 모든 노드들을 순회한다. 
## Floyd-Warshall Algorithm 
 > 이거 왜씀?

## A* Algorithm 

> 게임 업계에서 거의 Book of Genesis

Dijkstra 알고리즘에서 확장하며, 기존에 출발기점에서 모든곳을 목적지로 지정하는 것과 달리, 
목적지를 정하고, 탐색하는 노드들을에 대해서 기준을 가지고 (f, g, h) 목표지점에 유망한 노드들을 구분하며 
가장 유망한 지점부터 전개하며 최단거리를 찾는다. 
휴리스틱값을 찾는 방법으로는 크게는 2가지로, 

Manhattan/ TaxiCab 

Euclidean

특정 휴리스틱 결정 사유 
(휴리스틱, Either Taxicab, 
