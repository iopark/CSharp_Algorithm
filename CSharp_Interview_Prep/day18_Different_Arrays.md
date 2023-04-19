# Arrays, Linked Arrays, & List in the C# Language

### Part of the Lecture Learning: Data Structure and Algorithmic Thinking

#### <b>Prepping for the Technical Interview</b>

Whilst all the <u>listed</u> classes holds the common theme in the grouping of the unique datum, the way each is dealt within its data structure and the way each is handled varies; with its differences uniquely taking its parts in OOP dynamic.
``` cs
//Array 
int[] int_Array = new int[10]; // Declaring an Array
string[] str_Array = new string[5];

//ArrayList
List<int> int_List = new List<int>(); // Declaring an ArrayList
List<string> str_List = new List<string>();

//LinkedList
LinkedList<string> linked_List = new LinkedList<string>(); // Declaring an Linked Array (Will learn more about it/discussed further in the future) 

```

04/09/2023 

�켱 �⺻������ � Array �� 
�������� �޸𸮻� ������ Ÿ���� ��Ҹ� �Ϸķ� �����ϴ� �ڷᱸ���̴�. 

�޸𸮼ӿ� ����Ǵ� �������� �������� ������, 
�迭�� ȿ�뼺�� �ִ� ������ ������ �ڷ����� �����̱� �����ε�, �̰��� �ڷ������� ������ �޸𸮿��� ������ ũ�Ⱑ �ֱ� �����̸�, �̰��� Ȱ���Ѱ��� �迭�� Index����̴�. 
���÷�, int[] array = int[10] ���� ���, int�� 4byte���� ���� ���������� �����Ǿ� �޸𸮼ӿ� ������ �Ǹ�, �׷��⿡ �� �ڷ���ũ���� �����/  �迭�� ũ�⿡ ���� �ڷᰪ�� ������ ������� ������ ������ �޸𸮿� ���������� ����� ������ ũ���� ������ ���� �����ϴ� ����̴�. 

���������� ����� ���� Ȱ���ϴ� ���÷ν�, array[3] �� ȣ���Ҷ�����, �ش纯���� ������ �ڷ����� byte ���� 3 �� ���� ���� ȣ���Կ� ����, 3��° �ڸ��� ����� ���� ã���� �ְԵȴ�. 
����������, array[200] = calling index val which is not initialized, �� ���� �ƿ��ȵǴ°��� �ƴϴ�. ������, C#�ӿ����� �ش� ������ �ε��� ũ�⿡ ���� ����ó�� ����� ���ԵǾ� �ִ�. 

�迭�� �ð� ���⵵ 
�迭�ӿ�����, n ��ŭ�� �����Ͱ� ����� �迭�� Ž���Ҷ���, ���� ������ O(1) ������, �迭�� ����Ž���� ���ؼ� ó�� �ϱ� ������ O(n) ��ŭ Ž���ϰ� �Ǵ� �ð�complexity �� �ִ�. 


�׷� List �� ���?
�켱 �ڷ� ������ �������� �޸𸮿� ����·� �ٷ����� �ִ��� ���캼 �ʿ䰡�ִ�. 
List �� �ִ�ũ��� 64bit Windows ����, maximum capacity to 2 billion elements ���� �����ɼ��� �ִ� (�ִ� ũ�� = Maximum Capacity in List Class)
Array�� �ٸ��� ����� �ڷ����� ���� �̸� �Էµ� ũ�⿡ ����� ������ ũ�⸦ ���������� ���°��̾ƴ�, 
ũ�⸦ ���Ƿ� �켱 default�� �ǰ��Ͽ� �����ϸ�, (where default = default_Capacity), Count < Capacity ���¸� �����ϱ� ���� 
�迭�� ũ�⸦ �ø��ų� �ٿ����� �������� ���� �ٷ�� �ְ� �Ͽ��ش�. C#������ Array �� ����ϰ�, ���̿� ����ϴ� Count �̻��� ���� ������ ������ ȣ���Ѵٸ� C#��ü���� ������ ����ó���� ���� �����Ѵ�. 

�̷��� �»����� ���̴� �迭�� ã�� �޼��� ������ ����� ���߰� �����ѵ�, Array. Length �� List.Count���ν�,
Array�� ������� ũ�⿡ ���� ���������� ����� �ڷ����� ũ�⿡���� �����ϴ°��̱⿡ �ش� �迭�� �̹� ���� �� ����� ������ ����������, 
List �� Capacity ����, Count ���� ����, ���� �߰��Ҷ����� �����ϴ� ����� �޼��� ���ִ̹�� ������� �ݿ��Ȱ��� �����غ��� �ִ�. ( where Count = ~ Array.Length() ) 

and If count = Capacity, copies the following array internally, before relocating into array with bigger capacity; 

Array �� �������� ������ ����Ǵ� �� �ٸ� ������ ����� Ư�� instance�� ���ؼ� heap ������ ������ �ɶ� frag. ���·� ����ɼ��� ���� �����̱⵵���� ������ ������ ������, �̰� ���ݴ� ã�ƺ���� ���� 

To be Cont, Linked Array 

