using LiteBulb.Algorithms.Domain.Models;

namespace LiteBulb.Algorithms.Application.Services.NthLargestElement
{
    /// <summary>
    /// Note: this algorithm allows duplicate values in collection.
    /// </summary>
    /// <typeparam name="T">Type of element in collection</typeparam>
    public class SortedLinkedListStrategy<T> : IStrategy<T> where T : IHasValue, new()
    {
        public SortedLinkedListStrategy()
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

            // This linked list will be sorted in descending order
            var first = elements.First();
            Node head = new Node(first);
            Node tail = head;

            foreach (var element in elements.Skip(1))
            {
                if (element.Value > head.Element.Value)
                {
                    var next = head;
                    head = new Node(element);
                    head.Next = next;
                }
                else if (element.Value < tail.Element.Value)
                {
                    tail.Next = new Node(element);
                    tail = tail.Next;
                }
                else
                {
                    AddInDescendingOrder(head, element);
                }
            }

            Node current = head;

            for (int i = 0; i < n; i++)
            {
                if (i == n - 1)
                {
                    return current.Element;
                }

                current = current.Next;
            }

            throw new NotImplementedException();
        }

        private Node AddInDescendingOrder(Node head, T element)
        {
            if (head.Next is null)
            {
                throw new NotImplementedException("Shouldn't happen.");
            }

            if (element.Value >= head.Next.Element.Value)
            {
                var next = new Node(element);
                next.Next = head.Next;
                head.Next = next;
                return next;
            }

            return AddInDescendingOrder(head.Next, element);
        }

        public class Node
        {
            public Node(T element)
            {
                Element = element;
            }

            public T Element { get; }

            public Node? Next { get; set; }
        }
    }
}
