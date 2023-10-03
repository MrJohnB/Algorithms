namespace LiteBulb.Algorithms.Application.Services.NthLargestElement
{
    /// <summary>
    /// Service to find the nth largest element in a collection.
    /// </summary>
    /// <typeparam name="T">Type of element in collection</typeparam>
    public interface IStrategy<T>
    {
        /// <summary>
        /// Find the nth largest element in the collection.
        /// </summary>
        /// <param name="elements">Collection of objects</param>
        /// <param name="n">Represents the desired degree (nth) of largest value in the collection</param>
        /// <returns>Object which is the nth largest in the collection</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        T Find(IReadOnlyCollection<T> elements, int n);
    }
}