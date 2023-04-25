# Iterators C# Language

### Part of the Lecture Learning: Data Structure and Algorithmic Thinking

#### <b>Prepping for the Technical Interview</b>

1. ���� Ž�� Ʈ���� �Ѱ��� 
2. �Ѱ����� ���� �غ� ��� 
3. ����Ž��Ʈ���� ��ȸ ����� ��ȸ ���� 
Source: https://www.freecodecamp.org/news/binary-search-tree-traversal-inorder-preorder-post-order-for-bst/, and Lecture Learning from Day 23: Binary Search Tree

## �ݺ���� ���������Ͽ��� �� �߿��ұ��?

�⺻������ 22 GoF ������ ���� ���� �ൿ ������ �������� �з��Ǵ� ���ϵ���, �˰���/ �Ǵ� ��ü���� å���Ҵ翡 ������ �ΰ� �ֽ��ϴ�. ���߿��� �ݺ��ڸ� �˾ƺ��ô�. 

�ڷᱸ������� �����ϰ�, �ڷ��� ����ü�� ����°͵� ��ٷο� �۾�������, ������ ����ü�� ó���ϴ� ��Ķ��� �����غ����ϴ� �����Դϴ�. 
Ư�� Complex data structure ���� ���, ���ǿ� ���� �ٸ�������� (�ܼ� linear �ϰ� �ڷḦ ��ȸ�� �Ұ����� ��쿡), �ٸ� ������� �ڷ�����ü�� ���ؼ� �����ϴ� ����� �ʿ��մϴ�. 

�̷��� �����տ�, �ݺ��� ������ �پ��� ���ٹ���� ������ ������ ���Ͽ� �Ϸ��� �ൿ���/������ �����մϴ�. 

## �����ϴ� ��
Ư���� ������� ������ �ڷᱸ���� element/ Ȥ�� ���� ���Ͽ� �ٷ�� �ִ� �ż��带 ���� �ϳ��� ��ü�� �����ϴ°��� �ݺ��� ������ �����մϴ�. 

C# ���� ���, �ݺ����� ���Կ� ���ѹ����� IEnumerator/IEnumerable �������̽��ν�, 
�ݺ���� ��κ� �ڷᱸ������ ������ �ϸ�, ��� ��ü���� �ݺ��⸦ ���ؼ� ������ �ϰ� �ɶ�, �پ��� �ڷᱸ������ ���� ���� ���ٹ�İ�, �˰��� ���� ��Ŀ� ���ؼ� C#�� ������ �����Ѵ�.

�⺻������ �ݺ���� 
1. �����ϴ±�ɰ�, Reset () = set to the first pointer to search 
2. Ű�� �����ϼ��ִ� ��ɰ�, MoveNext() Move to the  next pointer, if pointer == null, prints false 
3. Ű�� ����Ű�� ���� �����ϴ� ��ɰ�, Current() Prints the value the pointer is pointing to (where in C#, its a pre-Iterator, considers the index prior to progress as a value to return. 
4. ���������� Ű�� ���� �����Ͽ����� Dispose �ϴ� (GC �� ������ ������ �־������, ������ �����ϴ�) when the MoveNext prints false, Iter.Dispose(); 

�̷��� �⺻���� ���� C#�� �����ϸ�, ���α׷����� �츮�� �ٷ�� �ڷᱸ����, ��ü�� Ư���� �°� �ݺ��⸦ �籸���Ҽ� �ְ� �ȴ�. 



 