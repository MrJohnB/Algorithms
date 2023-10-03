using LiteBulb.Algorithms.Data.NthLargestElement;

namespace LiteBulb.Algorithms.Data.Tests.NthLargestElement
{
    [TestClass]
    public class TestDataManagerUnitTests
    {
        [TestMethod]
        [DataRow(1, 500)]
        [DataRow(2, 499)]
        [DataRow(3, 498)]
        [DataRow(4, 497)]
        [DataRow(5, 496)]
        public void GetExpectedResult_ShouldReturn_ExpectedResult(int n, int expectedValue)
        {
            // Act
            var actual = TestDataManager.GetExpectedResult(n);

            // Assert
            Assert.AreEqual(expectedValue, actual.Value);
        }

        [TestMethod]
        public void GetElements_RandomSequenceFalse_SameOrder()
        {
            // Act
            var expected = TestDataManager.GetElements(randomSequence: false) as System.Collections.ICollection;
            var actual = TestDataManager.GetElements(randomSequence: false) as System.Collections.ICollection;

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetElements_RandomSequenceTrue_ShuffledOrder()
        {
            // Act
            var notExpected = TestDataManager.GetElements(randomSequence: false) as System.Collections.ICollection;
            var actual = TestDataManager.GetElements(randomSequence: true) as System.Collections.ICollection;

            // Assert
            CollectionAssert.AreNotEqual(notExpected, actual);
        }
    }
}
