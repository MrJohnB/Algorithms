using LiteBulb.Algorithms.Data.ThreadSafety;

namespace LiteBulb.Algorithms.Data.Extensions
{
    internal static class ListExtensions
    {
        /// <summary>
        /// Shuffle (randomize) the list elements in place using the Fisher-Yates shuffle.
        /// https://stackoverflow.com/questions/273313/randomize-a-listt
        /// https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
        /// </summary>
        /// <typeparam name="T">Type of element in the collection</typeparam>
        /// <param name="list">List to randomize (mutable)</param>
        internal static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = ThreadSafeRandom.RandomThread.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        /// <summary>
        /// Return the element at nth position from end of a list (1 = the last element in the collection).
        /// </summary>
        /// <typeparam name="T">Type of element in the collection</typeparam>
        /// <param name="list">List of elements to search</param>
        /// <param name="n">Nth position ordinal</param>
        /// <returns>Element from the list at the requested position</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        internal static T NthFromEndElement<T>(this IList<T> list, int n)
        {
            if (n < 0) { throw new ArgumentOutOfRangeException(nameof(n), "Value must be greater than 0."); }

            if (n >= list.Count) { throw new ArgumentOutOfRangeException(nameof(n), "Value exceeds the length of the underlying list."); }

            int nthFromEndIndex = list.Count - n;
            var nthFromEndElement = list[nthFromEndIndex];

            return nthFromEndElement;
        }
    }
}
