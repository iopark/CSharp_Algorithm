using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07._BinarySearchTree
{
    internal class BinarySearchTree<T> where T : IComparable<T> // where T can be string, int, or any datatype that can be placed on comparison may be applicable for this class 
    {
        private Node root; // 탐색을 할때의 처음 기준에 따라서 L/R 으로 갈지 결정나기 때문에, 기준을 제시하는 노드값또한 필요하다 

        public BinarySearchTree ()
        {
            this.root = null; //처음 생성시 아무것도 없기 때문에 맴버변수또한 null로 만들어 준다. 
        }

        public void Add(T item)
        {
            Node newNode = new Node(item, null, null, null);

         
            if (root == null) // 맨처음에는 루트 값이 null 이기 때문에, 
            {
                root = newNode;
                return;
            }
            Node current = root; // 비교대상 설정, 최초 비교값은 루트값으로 설정하며 조상노드부터 비교하며 내려간다. 
            while (current != null) // 비교가 가능한 루트값이 있을때는, 
            {
                // 새로운값 CompareTo (비교대상의 item 값) 비교해서 더 작은 경우, 
                if (item.CompareTo(current.item) < 0) // 값이 더 작다면 negative value 반환 in CompareTo 
                {
                    if (current.left != null)
                    {
                        // 왼쪽자식과 비교하기 위해 current 를 왼쪽 자식으로 설정 
                        current = current.left;
                    }
                    else // 비교자식 없으면 그장소로 할당 되겠다. 
                    {
                        current.left = newNode;
                        newNode.parent = current;
                        return; // 해당함수 탈출 
                    }
                }
                // 새로운값이 비교해서 더 큰 경우에는, 
                else if (item.CompareTo(current.item) > 0)
                {
                    if (current.right != null) // 오른쪽 값이 비어있지 않는다면, 
                    {
                        current = current.right;
                    }
                    else    //만약 비교대상의 오른쪽 값이 비었다면, 
                            // 신입의 자리는 배정된다. 
                    {       // 따라서 위치되는 값에 대해서 노드의 관계를 성립하여주면 된다. 
                        current.right = newNode;
                        newNode.parent = current;
                        return;
                    }
                }
                // 동일한 값에 대해서는, 
                // Source:https://learn.microsoft.com/ko-kr/dotnet/api/system.collections.generic.sortedset-1.add?view=net-7.0
                // 클래스는 SortedSet<T>에서는 중복 요소를 허용하지 않습니다. 집합에 이미 있는 경우 item 이 메서드는 예외를 반환 false 하고 throw하지 않습니다.
                else
                {
                    return;
                }
            }
        }

        public bool TryGetValue (T Item, out T outValue)
        {
            if (root == null) // Add와 비슷하게 해당 리스트가 비어있을 경우를 위한 대비책/ Base case 
            {
                outValue = default(T);
                return false; 
            }

            Node current = root; // Add 와 비슷하게 비교이후 해당값이 있다면 true, 그리고 값에 대해서 외부에서 설정이 가능하게 해준다. 
            // 계속 검색을 했는데 도착지점이 null이라면, 찾는 값이 없다고 귀결할수 있겠다. 
            while (current != null)
            {
                // 현재 노드의 값이 찾고자 하는 값보다 작은 경우 
                if (Item.CompareTo(current.item) < 0) // CompareTo returns negative val if x < y =  x.CompareTo(y)
                {
                    current = current.left; 
                }
                // 현재 노드의 값이 찾고자 하는 값보다 큰 경우 
                else if (Item.CompareTo (current.item) > 0)
                {
                    current = current.right; 
                }
                else // 작거나, 크지도 않은 상태면 같은 상태이기때문에, 찾는 값이 있는 조건문으로 행동문 생성 가능 
                {
                    outValue = Item; 
                    return true; 
                }

            }
            outValue = default(T);
            return false; 
        }
        public bool TryGetValue(T item, out T outValue, int overload = 0) // using FindNode 
        {
            Node findNode = FindNode(item); 
            if (findNode == null)
            {
                outValue = default(T);
                return false;
            }
            else
            {
                outValue = findNode.item;
                return true;
            }
        }
        private Node FindNode (T item)
        {
            if (root == null)
                return null;

            Node current = root;
            while (current != null)
            {
                if (item.CompareTo(current.item) < 0)
                {
                    current = current.left;
                }
                else if (item.CompareTo(current.item) > 0)
                {
                    current = current.right;
                }
                else
                {
                    return current;
                }
            }
            return null; 
        }

        public bool Remove(T item)
        {
            Node findNode = FindNode(item); 

            if (findNode == null)
            {
                return false;
            }
            else
            {
                EraseNode(findNode);
                return true; 
            }

        }
        // Note: BinarySearchTree remove algorithm 

        private void EraseNode(Node node) 
        { 
            // 삭제의 조건 
            // 1. 자식이 없는경우 (both L, R )
            if (node.HasNochild)
            {
                if (node.IsLeftChild)
                    node.parent.left = null;
                else if (node.IsRightChild)
                    node.parent.right = null;
                else
                    root = null; // Child가 아닌경우는 root밖에 없기 때문에, 이와같이 선언하여준다. 
            }
            // 2. 자식이 (L, R) _하나_가 있는경우 
            else if (node.HasLeftChild || node.HasRightChild)
            {
                Node parent = node.parent;
                Node child = node.HasLeftChild ? node.left : node.right; 

                if (node.IsLeftChild)// 삭제 하는 대상이 부모의 왼쪽 자식값이었다면,
                {                    // 1. 삭제하는 대상의 자식의 부모를 재정립하여주고, 
                                     // 2. 부모의 왼쪽 자식값에 관계를 재정립하여 준다.

                    parent.left = child; // 2. 
                    child.parent = parent; // 1. 
                }
                else if (node.IsRightChild) // 삭제 하는 대상이 부모의 오른쪽 자식값이었다면,
                                            // 1. 삭제하는 대상의 자식의 부모를 재정립하여주고, 
                                            // 2. 부모의 오른쪽 자식값에 관계를 재정립하여 준다. 
                {
                    parent.right = child; //  2. 
                    child.parent = parent;  // 1.  
                }
                else // if 해당 노드가 자식이 아니라면, == 해당 트리의 루트값이었기에,
                     // 1. 루트의 남은 자식을 루트로 생성하여 주며,
                     // 2. 자식의 부모에 대한 관계를 재정립하여 준다. 
                {
                    root = child; // 1. 
                    child.parent = null; // 2.  
                }
            }
            // 3. **자식이 (L, R) _둘_  다 있는경우** DIFFICULTY => EXPONENTIAL GROWTH
            else // 위의 2 조건문에 해당하지 않는다는것은 = HasBothChild = true
                 // 이진탐색 트리는 L < 부모< R 관계 이기 때문에, 해당 규칙을 활용하며 값을 재정리 하여 준다.
                 // 활용하는 방법은 삭제노드의 왼쪽값의 자식 노드중, 가장 높은값을 부모로 설정하여주면 이진탐색트리 규칙을 지킬수 있다. 
            {
                // L < 부모 < R 이용 케이스 1 번 
                Node replaceNode = node.left; 
                while (replaceNode.right != null) // 삭제될 노드의 왼쪽 자식의 오른쪽 자식들중 마지막 자식을 찾는다
                                                  // 이는 L < Item < R 을 이용한 케이스중 1번 케이스다. 
                {
                    replaceNode = replaceNode.right;
                }
                node.item = replaceNode.item;
                EraseNode(replaceNode); 

                // L < 부모 < R 이용 케이스 2 번 
                // 삭제될 값의 오른쪽 자식의 최종 왼쪽 자식을 이용하여도 규칙에 위배되지 않게 된다. 
                /* Node replaceNode = node.right; 
                 * while (replaceNode.left != null) { 
                 * replaceNode = replaceNode.left; 
                 * } 
                 * node.item = replaceNode.item; 
                 * EraseNode(replaceNode); 
                 */
                // 해당 2케이스가 작동하는 원리는 삽입또한 L < 부모 < R 원칙을 지키기 때문이며, 
                // 해당 이진검색트리에서는 L < 부모 < R 원칙을 이뤄줌으로써 장점들이 이렇게 발생한다. 
            }
        } 

        public void Print()
        { // 매개변수가 없을경우, 루트먼저 프린트를 하게 된다. 
            Print(root); 
        }
        public void Print(Node node) // Recursion 적용 
        {
            if (node.left != null) 
                Print(node.left); // left == null 일때까지 계속해서 해당 함수 호출한다. 
            Console.WriteLine(node.item);
            if (node.right != null)
                Print(node.right); 
        }

        public class Node // 이렇게 클래스안에 클래스를 생성하게 되면 internal 의 맴버변수를 지정하여도 상위 클래스는 사용이 가능하게 된다. 
        {
            //이진트리자료구조는 애초에 거대한 자료구조형에 있어서 계층에 따른 값에 대한 정립 및 탐색에 특화되어있기에, 노드로써 구성하는게 옳다 
            // 정확히는, 배열로 강제하여 힙 영역에 대해서 GC 과부화를 최소화 하기에는, 애초에 배열이나 리스트로 구현하기에 형태로써 구현할수가 없겠다. 
            // 
            internal T item; // 노드는 부모를 가리키는 키, 왼쪽 자식값, 오른쪽 자식값로 3가지 키가 있으며 마지막으로 값자체를 지니고 있다. 
            internal Node parent;
            internal Node left;
            internal Node right; 

            public Node(T item, Node parent, Node left, Node right)
            {
                this.item = item;
                this.parent = parent;
                this.left = left;
                this.right = right;
            }
            public bool IsRootNode { get { return parent == null; } }
            public bool IsLeftChild { get { return parent != null && parent.left == this; } }
            public bool IsRightChild { get { return parent != null && parent.right == this; } }
            public bool HasNochild { get { return left == null && right == null; } }
            public bool HasLeftChild { get { return left != null && right == null; } }

            public bool HasRightChild { get { return left == null && right != null; } }
            public bool HasBothChild { get { return left != null && right != null; } }
        }
    }
}
