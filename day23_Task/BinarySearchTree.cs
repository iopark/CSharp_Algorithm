using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_DataStructure
{
    /// <summary>
    /// 해당 이진검색트리는 L < 부모 < 값을 기준으로 나뉘고, 
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class BinarySearchTree<T> where T: IComparable<T>
    {

        public struct Node
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
        }
    }
}
