using System.Collections.Generic;

namespace TestTask
{
    public class LinkedListProcessor<T>
    {
        public Node<T> Head;
        public Node<T> ReverseOptimized(Node<T> node, Node<T> previous)
        {
            if (node.Next == null)
            {
                Head = node;
                Head.Next = previous;
                return node;
            }
            var next = node.Next;
            node.Next = previous;
            return ReverseOptimized(next, node);
        }
        
        public Node<T> Reverse(Node<T> node)
        {
            if (node.Next == null)
            {
                Head = node;
                return node;
            }
            var reversed = Reverse(node.Next);
            reversed.Next = new Node<T>(node.Value);
            return Reverse(node.Next);
        }
        
    }
}