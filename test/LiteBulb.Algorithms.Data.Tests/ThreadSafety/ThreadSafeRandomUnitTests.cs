using LiteBulb.Algorithms.Data.ThreadSafety;

namespace LiteBulb.Algorithms.Data.Tests.ThreadSafety
{
    [TestClass]
    public class ThreadSafeRandomUnitTests
    {
        [TestMethod]
        public void RandomThread_ShouldReturn_NonNull()
        {
            // Act
            var randomThread = ThreadSafeRandom.RandomThread;

            // Assert
            Assert.IsNotNull(randomThread);
        }

        [TestMethod]
        public void RandomThread_ShouldReturn_SameRandomEveryInvocation()
        {
            // It's like a singleton

            // Act
            var randomThread1 = ThreadSafeRandom.RandomThread;
            var randomThread2 = ThreadSafeRandom.RandomThread;

            // Assert
            Assert.AreEqual(randomThread1, randomThread2);
        }
    }
}
