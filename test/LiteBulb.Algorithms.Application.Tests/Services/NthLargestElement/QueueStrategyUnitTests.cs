using LiteBulb.Algorithms.Application.Services.NthLargestElement;
using LiteBulb.Algorithms.Data.NthLargestElement;
using LiteBulb.Algorithms.Domain.Models;
using System.Diagnostics.CodeAnalysis;

namespace LiteBulb.Algorithms.Application.Tests.Services.NthLargestElement
{
    [TestClass]
    public class QueueStrategyUnitTests
    {
        [AllowNull]
        private static IStrategy<Element> _strategy;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _strategy = new QueueStrategy<Element>();
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        [DataRow(11)]
        [DataRow(12)]
        [DataRow(13)]
        [DataRow(14)]
        [DataRow(15)]
        [DataRow(91)]
        [DataRow(92)]
        [DataRow(93)]
        [DataRow(94)]
        [DataRow(95)]
        public void Find_ShouldReturn_ExpectedResult(int n)
        {
            // Arrange
            var elements = TestDataManager.GetElements(randomSequence: true);
            var expected = TestDataManager.GetExpectedResult(n);

            // Act
            var actual = _strategy.Find(elements, n);

            // Assert
            Assert.AreEqual(expected.Value, actual.Value);
        }
    }
}
