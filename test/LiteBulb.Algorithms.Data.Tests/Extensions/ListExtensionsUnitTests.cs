using LiteBulb.Algorithms.Data.Extensions;
using LiteBulb.Algorithms.Domain.Models;

namespace LiteBulb.Algorithms.Data.Tests.Extensions
{
    [TestClass]
    public class ListExtensionsUnitTests
    {
        [TestMethod]
        public void Shuffle_ShouldMutateList_ReorderList()
        {
            // Arrange
            var elements = new List<Element>()
            {
                new Element() { Value = 1 },
                new Element() { Value = 2 },
                new Element() { Value = 3 },
                new Element() { Value = 4 },
                new Element() { Value = 5 },
                new Element() { Value = 6 },
                new Element() { Value = 7 },
                new Element() { Value = 8 },
                new Element() { Value = 9 },
                new Element() { Value = 10 }
            };

            var notExpected = 1;

            // Act
            ListExtensions.Shuffle(elements);

            var actual = elements[0];

            // Assert
            Assert.AreNotEqual(notExpected, actual);
        }

        [TestMethod]
        [DataRow(1, 10)]
        [DataRow(2, 9)]
        [DataRow(3, 8)]
        [DataRow(4, 7)]
        [DataRow(5, 6)]
        public void NthFromEndElement_ShouldReturn_ExpectedResult(int n, int expectedValue)
        {
            // Arrange
            var elements = new List<Element>()
            {
                new Element() { Value = 1 },
                new Element() { Value = 2 },
                new Element() { Value = 3 },
                new Element() { Value = 4 },
                new Element() { Value = 5 },
                new Element() { Value = 6 },
                new Element() { Value = 7 },
                new Element() { Value = 8 },
                new Element() { Value = 9 },
                new Element() { Value = 10 }
            };

            // Act
            var actual = ListExtensions.NthFromEndElement(elements, n);

            // Assert
            Assert.AreEqual(expectedValue, actual.Value);
        }
    }
}
