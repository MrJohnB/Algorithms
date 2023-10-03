using LiteBulb.Algorithms.Domain.Models;

namespace LiteBulb.Algorithms.Application.Services.NthLargestElement
{
    /// <summary>
    /// O(n^2)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class UnsortedArrayStrategy<T> : IStrategy<T> where T : IHasValue, new()
    {
        public UnsortedArrayStrategy()
        {
        }

        /// <summary>
        /// Find the nth largest element in the collection.
        /// </summary>
        /// <param name="elements">Collection of Element objects</param>
        /// <param name="n">Represents the desired degree (nth) of largest element in the collection</param>
        /// <returns>Element object which is the nth largest in the collection</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public T Find(IReadOnlyCollection<T> elements, int n)
        {
            ArgumentNullException.ThrowIfNull(elements);

            if (n < 1) { throw new ArgumentException("", nameof(n)); }

            if (elements.Count < n) { throw new ArgumentException($"Collection count cannot be less than requested value of {nameof(n)}.", nameof(elements)); }

            var list = new List<T>();

            int indexOfMinValue;

            foreach (var element in elements)
            {
                if (list.Count < n)
                {
                    list.Add(element);
                    continue;
                }

                indexOfMinValue = GetIndexOfMinValue(list);

                // If this value is larger than the smallest value in the list
                if (element.Value > list[indexOfMinValue].Value)
                {
                    // Replace the value at the index of the smallest value
                    // (this index might not have the min value anymore after swap)
                    list[indexOfMinValue] = element;
                }
            }

            indexOfMinValue = GetIndexOfMinValue(list);

            return list[indexOfMinValue];
        }

        /// <summary>
        /// Linear scan of the array to find the index of the min value O(n).
        /// </summary>
        /// <param name="list">Collection to search</param>
        /// <returns>Index of the minimum value</returns>
        private int GetIndexOfMinValue(IList<T> list)
        {
            int indexOfMinValue = 0;

            // Start at index 1 to skip the initial/default value of indexOfMinValue
            // (n is required to be >= 1)
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i].Value < list[indexOfMinValue].Value)
                {
                    indexOfMinValue = i;
                }
            }

            return indexOfMinValue;
        }
    }
}
