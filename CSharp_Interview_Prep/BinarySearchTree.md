# Binary Search Tree C# Language

### Part of the Lecture Learning: Data Structure and Algorithmic Thinking

#### <b>Prepping for the Technical Interview</b>

1. 이진 탐색 트리의 한계점 
2. 한계점에 대한 극복 방법 
3. 이진탐색트리의 순회 방법과 순회 순서 
Source: https://www.freecodecamp.org/news/binary-search-tree-traversal-inorder-preorder-post-order-for-bst/, and Lecture Learning from Day 23: Binary Search Tree

## 1. 한계점 
값을 기준으로 Left < 노드 < Right 규칙을 지키게 되었을때 대부분의 경우 O(Log N)의 시간 복잡도로, 기존의 List 의 O(N)대비 획기적으로 계층으로 구별할수있는 값들에 대해 접근/삽입/삭제/탐색하게 해주지만

해당 규칙을 고집하게 되었을때의 한계점/또는 단점도 존재하게 된다. 
예시로 1,0,3,6,9,11,15 와같이 값을 저장하였을때, 3을 기준으로, 한쪽으로만 저장이 되는 불균형이 발생할 수 있으며,

따라서 이진탐색트리가 평균적으로 제공하는 시간 복잡도에 대한 메리트가 없어질수 있게 된다. 

where Search in Worst Case could be ~(O(n)). 
특히 안그래도 GC의 심기를 건드리지않기위해 가능하면 노드기반 자료형이 기피되는 C#에서, Time Complexity에 대한 메리트마서 없다면 굳이 Binary Search Tree 를 고민해야할 이유가 희미해지게된다. 

이와같이 이 모든것의 원흉인 불균형을 방지하기 위해서, 자기 균형 기능이 구현된 트리를 통해 단점을 커버할수 있겠다.  


## 2. 한계점에 대한 극복 방법 
한계점이 불균형된 저장이라면, Red/Black Tree, 그리고 AVL Tree 가 있다. 
이 둘의 공통점은 각자 다른 규칙으로 루트부터 Left Subtree, Right Subtree의 Root 에서 Leaf 까지 불균형이 존재하는지 확인하고, 불균형이 존재한다면 L < Node < R (in terms of Value) 가 깨지지않는 선에서 노드값들을 우회전, 또는 좌회전 하여 (노드 관계를 재정립하며) 불균형이 생기는걸 방지한다.

## 3. Binary Search Tree Traversal Order 
(Where Traversing means 1. Visiting the selected Data, 2. Outputting/ Extracting the relavant data from the selected datum)\
Selecting a method of traversal means selecting specific route to traverse through the tree data structure. 
Generally speaking, in a Tree Data Structure, there are multiple ways of traversing through data, 
which is quite unlike the other data structure(specifically for what I know for now, Linear DS which only holds bidirectional/single route of traversal)

There are 3 main types of Traversal Order, 
1. InOrder (중위): which starts from the Left Child node, the Node, and the Right Child node
2. PreOrder (전위): the Node, Left Node, and then the Right  
3. PostOrder (후위) : Left, the Right, and the Node itself. 


For the Binary Search Tree, the InOrder would present a sequence of output in a ascending order of data by which the tree have sorted out from the root. 
Whilst the other types of traversal order may offer unique value to other data structure and their endeavour. \
For now Pre and PostOrder Traversal does not seem to offer any means of relatable context for this particular tree; That is, presenting an hierarchical data collection in a way that is efficiently accessible for the users. (Compared to linear data structure) 

순회에 대한 고찰은 이제 Complex type의 Data Structure에 들어가면 갈수록 유의미한 아이디어 일것으로 생각된다. 
이는 순회가 반복기와의 관계에서도 생각해볼수 있는데, 어떤 자료의 Collection 이던지 유의미함이 부여되는것은 접근하여 값을 이용할때이다.

그렇기에 다른 자료구조를 보며 해당 구조의 장점과 단점을 알아간다는것은 해당 구조는 값의 접근, 삽입, 삭제, 탐색에 대해 어떤방식으로 대처하며, 각 탐색/순회방식에 어떻게 반응하는지 배워갈 수 있겠고, 따라서 프로그래머는 각 자료구조에 대해 (complex) 순회방식들에 따라 어떤식으로 명령문들을 구상할지 생각해보아야 할것으로 생각된다. 

마지막으로 순회방식에 대한 고민은 해당 객체를 위한 적절한 반복기(들)에 대해서도 생각하고 제시할줄 아는것또한 프로그래머의 역할이라 생각된다. 
