namespace LiteBulb.Algorithms.Data.ThreadSafety
{
    internal class ThreadSafeRandom
    {
        [ThreadStatic]
        private static Random? Local;

        public static Random RandomThread => Local
            ??= new Random(unchecked(Environment.TickCount * 31 + Environment.CurrentManagedThreadId));
    }
}
