using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TestTask.Tests
{
    [TestFixture]
    public class ReverseTests
    {
        [Test]
        public void Reverse_Works([Values("test_one", "test_two")]string sentence)
        {
            // Linked list generating
            var index = 0;
            var node = new Node<char>(sentence[0]);
            var head = node;
            while (index < sentence.Length - 1)
            {
                index += 1;
                var next = new Node<char>(sentence[index]);
                node.Next = next;
                node = next;
            }

            // Reverse linked list
            var reversed = LinkedListProcessor.Reverse(head);
            var array = sentence.ToCharArray();
            Array.Reverse(array);

            // Compare results
            var reversedString = new StringBuilder(sentence.Length);
            var reversedHead = reversed.Head;
            do
            {
                reversedString.Append(reversedHead.Value);
                reversedHead = reversedHead.Next;
            } while (reversedHead != null);

            Assert.AreEqual( string.Join(string.Empty, array), reversedString.ToString());

        }
    }
}