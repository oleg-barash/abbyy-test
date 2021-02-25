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
        private LinkedListProcessor<char> _processor;

        private string longText = @"Where does it come from?
Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, 
looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. 
Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, 
very popular during the Renaissance. The first line of Lorem Ipsum, orem ipsum dolor sit amet.., comes from a line in section 1.10.32. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. 
Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.";
        [SetUp]
        public void WarmUp()
        {
            _processor = new LinkedListProcessor<char>();
        }
        
        [Test]
        public void OptimizedReverse_Works()
        {
            var sentence = longText;
            var head = GenerateList(sentence);
            // Old method doesnt work anymore in this test
            // _processor.Reverse(head); 
            _processor.ReverseOptimized(head, null);
            var array = sentence.ToCharArray();
            Array.Reverse(array);
            var reversedString = ReversedString(sentence);
            Assert.AreEqual( string.Join(string.Empty, array), reversedString);
        }
        

        private string ReversedString(string sentence)
        {
            var reversedString = new StringBuilder(sentence.Length);
            var reversedHead = _processor.Head;
            do
            {
                reversedString.Append(reversedHead.Value);
                reversedHead = reversedHead.Next;
            } while (reversedHead != null);

            return reversedString.ToString();
        }

        private static Node<char> GenerateList(string sentence)
        {
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

            return head;
        }
    }
}