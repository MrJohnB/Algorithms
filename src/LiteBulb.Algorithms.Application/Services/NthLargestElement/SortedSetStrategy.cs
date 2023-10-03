﻿using LiteBulb.Algorithms.Domain.Models;

namespace LiteBulb.Algorithms.Application.Services.NthLargestElement
{
    /// <summary>
    /// ???
    /// </summary>
    /// <typeparam name="T">Type of element in collection</typeparam>
    public class SortedSetStrategy<T> : IStrategy<T> where T : IHasValue, new()
    {
        public SortedSetStrategy()
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

            var sortedSet = new SortedSet<int>();

            foreach (var element in elements)
            {
                sortedSet.Add(element.Value);
            }

            var result = sortedSet.ElementAt(sortedSet.Count - n);

            return new T() { Value = result };
        }
    }
}
