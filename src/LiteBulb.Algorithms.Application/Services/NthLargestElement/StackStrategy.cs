using LiteBulb.Algorithms.Domain.Models;

namespace LiteBulb.Algorithms.Application.Services.NthLargestElement
{
    /// <summary>
    /// Does not pass all unit tests.
    /// </summary>
    /// <typeparam name="T">Type of element in collection</typeparam>
    public class StackStrategy<T> : IStrategy<T> where T : IHasValue
    {
        public StackStrategy()
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

            var stack = new Stack<T>();

            int largest = int.MinValue;

            foreach (var element in elements)
            {
                if (element.Value > largest)
                {
                    stack.Push(element);

                    largest = element.Value;
                }
            }

            for (int i = 1; i < n; i++)
            {
                stack.Pop();
            }

            return stack.Pop();
        }
    }
}
