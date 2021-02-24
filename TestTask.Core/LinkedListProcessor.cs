using System.Collections.Generic;

namespace TestTask
{
    public class LinkedListProcessor
    {
        public static (Node<T> Head, Node<T> Tail) Reverse<T>(Node<T> node)
        {
            if (node.Next != null)
            {
                var (head, reversed) = Reverse(node.Next);
                reversed.Next = new Node<T>(node.Value);
                return (head, reversed.Next);
            }
            return (node, node);
        }
    }
}