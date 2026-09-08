# day29_Task

_2023-05-04_

|  |  |  |  |  |  |  |  |  |  |  |  |  |  |
| :-: | :-: | :-: | :-: | :-: | :-: | :-: | :-: | :-: | :-: | :-: | :-: | :-: | :-: |
|  |  |  |  |  |  |  |  |  |  |  |  |  |  |
|  |  | U uranium | U uranium | f, 86 g, 20 h 66 | f, 92 g, 30 h 62 | f, 98 g, 40 h 58 | f, 104 g, 50 h 54 | f, 110 g, 60 h 50 | f,  g,  h | f,  g,  h |  | 1\. 4방향 AStar |  |
|  |  | U uranium | U uranium | f,66 g10,  h56 | f,72 g20,  h52 |  |  | f,  g,  h | f,  g,  h | f,  g,  h |  | f,g,h  | where Linear = 10  Diagonal = 14 for h |
|  |  | U uranium | U uranium | S | f52 g10  h42 |  | f,  g10,  h | f,  g,  h | f,  g,  h | f,  g,  h |  | 탐색은 빨간색  |  |
|  |  | U uranium | U uranium | f,58  g10,  h48 | f,58 g20,  h38 |  | f,  g10,  h | f,  g,  h | f,  g,  h | f,  g,  h |  | 탐색된 정점은 화살표  |  |
|  |  | U uranium | U uranium | f,94  g40,  h54 | f,64 g30,  h34 |  | f,  g10,  h | f,  g,  h | f,  g,  h | f,  g,  h |  | 최단경로는 노랑색  |  |
|  |  | U uranium | U uranium | f,90  g50,  h40 | f,70  g40,  h30 |  | f,110  g100,  h10 | E | f,  g10,  h | f,  g10,  h |  | Where Iteration = 상, 하, 좌, 우 |  |
|  |  | U uranium | U uranium | f,104 g60,  h44 | f,84 g50,  h34 |  | f,104  g90,  h14 | f,110 g100,  h10 | f,  g10,  h | f,  g10,  h |  | Anything Left of the Starting node has been  ignored for convenience  |  |
|  |  | U uranium | U uranium | f,118  g70,  h48 | f,98 g60,  h38 | f,98 g70,  h28 | f,104 g80,  h24 | f,110  g90,  h20 | f,  g10,  h | f,  g10,  h |  |  |  |
|  |  |  |  |  |  |  |  |  |  |  |  |  |  |
|  |  |  |  |  |  |  |  |  |  |  |  |  |  |
|  |  |  |  |  |  |  |  |  |  |  |  |  |  |
|  |  | U uranium | U uranium | f, 86 g, 20 h 66 | f, 82 g, 20 h 62 | f, 78 g, 20 h 58 | f, 74 g, 30 h 54 | f, 90 g, 40 h 50 | f,  g,  h | f,  g,  h |  | 1\. 8방향 AStar |  |
|  |  | U uranium | U uranium | f,66 g10,  h56 | f,62 g10,  h52 |  |  | f, 80 g, 40 h 40 | f,  g,  h | f,  g,  h |  | f,g,h  |  |
|  |  | U uranium | U uranium | S | f52 g10  h42 |  | f,  g,  h | f,  g,  h | f,  g,  h | f,  g,  h |  | 탐색은 빨간색  |  |
|  |  | U uranium | U uranium | f,58  g10,  h48 | f,48 g10,  h38 |  | f,  g,  h | f,  g,  h | f,  g,  h | f,  g,  h |  | 탐색된 정점은 화살표  |  |
|  |  | U uranium | U uranium | f,74  g20,  h54 | f,54 g20,  h34 |  | f,  g,  h | f,  g,  h | f,  g,  h | f,  g,  h |  | 최단경로는 노랑색  |  |
|  |  | U uranium | U uranium | f,70  g30,  h40 | f,60  g30,  h30 |  | f, 80 g, 70 h 10 | E | f,  g,  h | f,  g,  h |  | Where Iteration = 상, 하, 좌, 우 |  |
|  |  | U uranium | U uranium | f,84 g40,  h44 | f,74 g40,  h34 |  | f,74  g60,  h14 | f,80 g70,  h10 | f,  g,  h | f,  g,  h |  | Anything Left of the Starting node has been  ignored for convenience  |  |
|  |  | U uranium | U uranium | f,98  g50,  h48 | f,88 g50,  h38 | f,78 g50,  h28 | f,84 g60,  h24 | f,90  g70,  h20 | f,  g,  h | f,  g,  h |  |  |  |