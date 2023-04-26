# Binary Search Tree C# Language

### Part of the Lecture Learning: Data Structure and Algorithmic Thinking

#### <b>Prepping for the Technical Interview</b>

1. ���� Ž�� Ʈ���� �Ѱ��� 
2. �Ѱ����� ���� �غ� ��� 
3. ����Ž��Ʈ���� ��ȸ ����� ��ȸ ���� 
Source: https://www.freecodecamp.org/news/binary-search-tree-traversal-inorder-preorder-post-order-for-bst/, and Lecture Learning from Day 23: Binary Search Tree

## 1. �Ѱ��� 
���� �������� Left < ��� < Right ��Ģ�� ��Ű�� �Ǿ����� ��κ��� ��� O(Log N)�� �ð� ���⵵��, ������ List �� O(N)��� ȹ�������� �������� �����Ҽ��ִ� ���鿡 ���� ����/����/����/Ž���ϰ� ��������

�ش� ��Ģ�� �����ϰ� �Ǿ������� �Ѱ���/�Ǵ� ������ �����ϰ� �ȴ�. 
���÷� 1,0,3,6,9,11,15 �Ͱ��� ���� �����Ͽ�����, 3�� ��������, �������θ� ������ �Ǵ� �ұ����� �߻��� �� ������,

���� ����Ž��Ʈ���� ��������� �����ϴ� �ð� ���⵵�� ���� �޸�Ʈ�� �������� �ְ� �ȴ�. 

where Search in Worst Case could be ~(O(n)). 
Ư�� �ȱ׷��� GC�� �ɱ⸦ �ǵ帮���ʱ����� �����ϸ� ����� �ڷ����� ���ǵǴ� C#����, Time Complexity�� ���� �޸�Ʈ���� ���ٸ� ���� Binary Search Tree �� ����ؾ��� ������ ��������Եȴ�. 

�̿Ͱ��� �� ������ ������ �ұ����� �����ϱ� ���ؼ�, �ڱ� ���� ����� ������ Ʈ���� ���� ������ Ŀ���Ҽ� �ְڴ�.  


## 2. �Ѱ����� ���� �غ� ��� 
�Ѱ����� �ұ����� �����̶��, Red/Black Tree, �׸��� AVL Tree �� �ִ�. 
�� ���� �������� ���� �ٸ� ��Ģ���� ��Ʈ���� Left Subtree, Right Subtree�� Root ���� Leaf ���� �ұ����� �����ϴ��� Ȯ���ϰ�, �ұ����� �����Ѵٸ� L < Node < R (in terms of Value) �� �������ʴ� ������ ��尪���� ��ȸ��, �Ǵ� ��ȸ�� �Ͽ� (��� ���踦 �������ϸ�) �ұ����� ����°� �����Ѵ�.

## 3. Binary Search Tree Traversal Order 
(Where Traversing means 1. Visiting the selected Data, 2. Outputting/ Extracting the relavant data from the selected datum)\
Selecting a method of traversal means selecting specific route to traverse through the tree data structure. 
Generally speaking, in a Tree Data Structure, there are multiple ways of traversing through data, 
which is quite unlike the other data structure(specifically for what I know for now, Linear DS which only holds bidirectional/single route of traversal)

There are 3 main types of Traversal Order, 
1. InOrder (����): which starts from the Left Child node, the Node, and the Right Child node
2. PreOrder (����): the Node, Left Node, and then the Right  
3. PostOrder (����) : Left, the Right, and the Node itself. 


For the Binary Search Tree, the InOrder would present a sequence of output in a ascending order of data by which the tree have sorted out from the root. 
Whilst the other types of traversal order may offer unique value to other data structure and their endeavour. \
For now Pre and PostOrder Traversal does not seem to offer any means of relatable context for this particular tree; That is, presenting an hierarchical data collection in a way that is efficiently accessible for the users. (Compared to linear data structure) 

��ȸ�� ���� ������ ���� Complex type�� Data Structure�� ���� ������ ���ǹ��� ���̵�� �ϰ����� �����ȴ�. 
�̴� ��ȸ�� �ݺ������ ���迡���� �����غ��� �ִµ�, � �ڷ��� Collection �̴��� ���ǹ����� �ο��Ǵ°��� �����Ͽ� ���� �̿��Ҷ��̴�.

�׷��⿡ �ٸ� �ڷᱸ���� ���� �ش� ������ ������ ������ �˾ư��ٴ°��� �ش� ������ ���� ����, ����, ����, Ž���� ���� �������� ��ó�ϸ�, �� Ž��/��ȸ��Ŀ� ��� �����ϴ��� ����� �� �ְڰ�, ���� ���α׷��Ӵ� �� �ڷᱸ���� ���� (complex) ��ȸ��ĵ鿡 ���� ������� ��ɹ����� �������� �����غ��ƾ� �Ұ����� �����ȴ�. 

���������� ��ȸ��Ŀ� ���� ����� �ش� ��ü�� ���� ������ �ݺ���(��)�� ���ؼ��� �����ϰ� �������� �ƴ°Ͷ��� ���α׷����� �����̶� �����ȴ�. 
