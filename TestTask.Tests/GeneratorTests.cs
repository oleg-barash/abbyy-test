using System.Linq;
using NUnit.Framework;

namespace TestTask.Tests
{
    [TestFixture]
    public class GeneratorTests
    {
        [Test]
        public void Generator_GeneratesCorrectLength([Values(104, 5, byte.MaxValue)]byte n)
        {
            var arr = Generator.GenerateArray(n);
            var lenght = arr.Generated.Count();
            Assert.IsTrue(lenght == n-1);
        }
        
        [Test]
        public void Generator_ThereAreNoRepeats([Values(104, 5, byte.MaxValue)]byte n)
        {
            var arr = Generator.GenerateArray(n);
            Assert.IsTrue(arr.Generated.GroupBy(x => x).Count(g => g.Count() > 1) == 0);
        }
        
        [Test]
        public void Generator_ArrayHasEveryNumberExceptSkipped([Values(104, 5, byte.MaxValue)]byte n)
        {
            var arr = Generator.GenerateArray(n);
            for (byte i = 0; i < n; i++)
            {
                if (arr.Skipped.Any(s => s == i)) continue;
                if (arr.Generated.Any(x => x == i)) continue;
                Assert.Fail();
                return;
            }
            Assert.Pass();
        }
    }
}