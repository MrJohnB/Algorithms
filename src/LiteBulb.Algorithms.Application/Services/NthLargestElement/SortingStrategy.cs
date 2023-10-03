using LiteBulb.Algorithms.Domain.Models;

namespace LiteBulb.Algorithms.Application.Services.NthLargestElement
{
    /// <summary>
    /// ???
    /// </summary>
    /// <typeparam name="T">Type of element in collection</typeparam>
    public class SortingStrategy<T> : IStrategy<T> where T : IHasValue
    {
        public SortingStrategy()
        {
        }

        /// <summary>
        /// Find the nth largest element in the collection.
        /// </summary>
        /// <param name="elements">Collection of objects</param>
        /// <param name="n">Represents the desired degree (nth) of largest value in the collection</param>
        /// <returns>Object which is the nth largest in the collection</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public T Find(IReadOnlyCollection<T> elements, int n)
        {
            ArgumentNullException.ThrowIfNull(elements);

            if (n < 1) { throw new ArgumentException("", nameof(n)); }

            if (elements.Count < n) { throw new ArgumentException($"Collection count cannot be less than requested value of {nameof(n)}.", nameof(elements)); }

            var sorted = elements.OrderByDescending(x => x.Value).ToArray();
            
            var result = sorted[n - 1];

            return result;
        }
    }
}
