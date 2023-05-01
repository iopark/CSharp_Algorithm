using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_DataStructure
{
     /*1. 이진탐색트리 탐색, 추가, 삭제 구현
      */
    /// <summary>
    /// 해당 이진검색트리는 L < 부모 < 값을 기준으로 나뉘고, 
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class BinarySearchTree<T> where T: IComparable<T>
    {
        //어떤 트리던 최초 조상값은 루트로 지정하는것이 정배이다 
        private Node root; 

        public BinarySearchTree()
        {
            this.root = null; 
        }
        /// <summary>
        /// 노드를 추가할때는 조상값부터 시작하며, 만약 조상값을 기준으로 L < 부모 < R
        /// 이 성립될수있도록 값을 추가하여주는것이 Binary Search Tree의 성립 기준일것이다. 
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            Node newNode = new Node(item, null, null, null); // 아직 부모, 자식 노드들에대해서 구현이 되지 않았으니 
            if (root == null)
            {
                root = newNode;
                return;
            }
            Node current = root;
            // 추가의 조건: 자식이 없을때 까지 L < Node < R 을 기반으로 접근하게 한다. 
            while (current != null)
            {
                if (item.CompareTo(current.item) < 0) // 만약 신입이 비교대상보다 작다면, 
                {
                    if (current.left != null)
                    {
                        current = current.left; 
                    }
                    else // 없다면 해당 왼쪽 자식에 새로운 노드를 지정하여 주고 관계를 재정립하여 준다. 
                    {
                        current.left = newNode;
                        newNode.parent = current;
                        return;
                    }

                }
                else if (item.CompareTo(current.item) > 0)// 만약 신입이 비교대상보다 크다면, 
                {
                    if (current.right != null) // 오른쪽의 자식이 존재한다면, 
                    {
                        current = current.right; 
                    }
                    else // 없다면 해당 오른쪽 자식에 새로운 노드를 지정하여 주고 관계를 재정립하여 준다. 
                    {
                        current.right = newNode;
                        newNode.parent = current;
                        return;
                    }
                }
                else
                {   // MSDN 기준, 이진탐색트리를 기준으로 값의 중복은 허용하지 않는다. 
                    // 이진탐색트리는 계층으로 분류가 가능한 값에 대해서 분류하고, 값을 다루는것에 대해서 List 대비 효율적인 자료구조형태이다 
                    return; 
                }
            }
            
        }

        public bool TryGetValue(T item, out T value)
        {
            Node target = FindNode(item); 
            if (target == null)
            {
                value = default(T);
                return false; 
            }
            else
            {
                value = target.item;
                return true; 
            }
        }
        /// <summary>
        /// 해당 트리에서 노드를 찾아주는 것으로, 만약 없다면 null값을 반환합니다. 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Node FindNode(T item)
        { // 트리는 기본적으로 조상님부터 탐문합니다. 
            // 이전의 Add와 비슷하게 L < 노드 < R 을 기반으로, 검색하는것이 원리입니다. 
            if (root == null)
                return null; 

            Node current = root; 
            while (current != null) // 만약 null 값이 나올때까지 안나온다면, 그건 없는것이므로, 이때까지 반복하며 검색하게 명령합니다. 
            {
                //탐색 조건문
                // 1. 만약 탐색하고자 하는 값이 타겟에 대비 작다면, 
                
                
                if (item.CompareTo(current.item) < 0)
                {
                    if (current.left != null)
                    {
                        current = current.left;
                    }
                    else
                    {
                        return null; 
                    }
                }
                // 2. 만약 탐색하고자 하는 값이 크다면 
                else if (item.CompareTo(current.item) > 0)
                {
                    if (current.right != null)
                    {
                        current = current.right;
                    }
                    else
                        return null;
                }
                // 3. 같다면으로 찾는값이라 귀결할수 있을까..? yes. 
                else
                {
                    return current; 
                }
            }
            return null;
        }

        public bool Remove(Node node)
        {
            if (node == null)
            {
                return false;
            }
            else
            {
                EraseNode(node);
                return true;
            }
        }
        public bool Remove(T item) 
        {
            Node target = FindNode(item); 
            if (target == null)
            {
                return false;
            }
            else
            {
                EraseNode(target);
                return true;
            }
            
        }
        /// <summary>
        /// 삭제의 미학 
        /// </summary>
        /// <param name="node"></param>
        private void EraseNode(Node node) 
        {
            // 삭제의 미학에서 까다로운것은 노드의 관계정리가 1번이고, 
            // 2번은 L < Node < R 현상의 유지를 하는것에 있다. 
            // 조건 1. 만약 자식이 없다면:
            if (node.HasNoChild)
            {
                //만약 삭제되는 노드가 부모가 있다면, 
                // 부모의 관계를 재정립하여준다. 
                if (node.IsLeftChild)
                    node.parent.left = null;
                else if (node.IsRightChild)
                    node.parent.right = null; 
                else //부모가 없다면 그것은 루트였기에, 루트를 재설정하여줌으로써 끝을 맺는다. 
                {
                    root = null; 
                }
            }
            // 조건 2. 만약 자식이 L, R 중 하나만 있다면 
            else if (node.HasLeftChild || node.HasRightChild)
            { //왼쪽자식이 있다면, 오른쪽자식은 없다는것을 전제로 노드의 관계를 재정립하여준다. 
                if (node.HasLeftChild) 
                {
                    node.parent.left = node.left; // 부모쪽의 관계 재정립 
                    node.left.parent = node.parent; // 왼쪽 자식의 관계 재정립 
                    // 더이상 오갈때 없는 해당 노드는 자연스래 삭제 
                }
                else if(node.HasRightChild)// node.HasRightchild
                {
                    node.parent.right = node.right; // 부모쪽의 관계 재정립 
                    node.right.parent = node.parent; // 오른쪽 자식의 관계 재정립 
                }
            }
            // 조건 3. EXPONENTIALLY MORE DIFFICULT: 자식이 둘다 있다면 
            else
            {
                // 해당 조건부에서 이진탐색트리의 규칙을 유지하며 삭제하는 방법론은 크게 2가지가 있다. 
                // 1. 왼쪽 자식의 오른쪽 Leaf 로 Replace 한다. 
                // 2. 오른쪽 자식의 왼쪽 Leaf 로 Replace 한다. 
                // 2번이 더 자주쓰이며, 이유는 아직 모르니 2번 구현으로 집중하여 본다. 
                Node replace = node.right;
                while (replace.left != null)
                {
                    replace = replace.left;
                }
                node.item = replace.item;
                EraseNode(replace); // 교체를 한후, 해당값은 삭제한다. 
                //replace.parent = node.parent; 그저 불필요, 더 나은 방법은 대부분 존재한다. 
                //replace.right = node.right;

            }
        }

        public void Print()
        {
            Print(root);
        }

        public void Print(Node node)
        {
            if (node.left != null)
            {
                Print(node.left);
            }
            Console.WriteLine(node.item); 
            if (node.right != null)
                Print(node.right);
        }

        // 
        public class Node
        {
            internal T item;
            internal Node parent;
            internal Node left;
            internal Node right; 

            public Node (T item, Node parent, Node left, Node right)
            {
                this.item = item;
                this.parent = parent;
                this.left = left;
                this.right = right; 
            }

            public bool HasNoChild {  get { return left == null && right == null; } }
            public bool HasBothChild { get { return left != null && right != null; } }
            public bool HasLeftChild { get { return left != null && right == null; } }
            public bool HasRightChild { get { return left == null && right != null; } }
            public bool IsLeftChild { get { return parent.left == this; } }
            public bool IsRightChild { get { return parent.right == this; } }


            public bool HasParent { get { return parent != null; } }
        }
    }
}
