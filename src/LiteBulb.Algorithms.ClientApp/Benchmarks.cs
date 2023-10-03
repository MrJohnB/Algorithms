using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using LiteBulb.Algorithms.Application.Services.NthLargestElement;
using LiteBulb.Algorithms.Data.NthLargestElement;
using LiteBulb.Algorithms.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace LiteBulb.Algorithms.ClientApp
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class Benchmarks
    {
        [AllowNull]
        private static IServiceProvider _serviceProvider;

        private static IReadOnlyCollection<Element> _elements = TestDataManager.GetElements(randomSequence: true);
        private static int _n = 5;
        private static Element _expected = TestDataManager.GetExpectedResult(_n);

        [GlobalSetup]
        public void Setup()
        {
            // Create the service container
            _serviceProvider ??= new ServiceCollection()
                .AddSingleton<SortingStrategy<Element>>()
                .AddSingleton<SortedSetStrategy<Element>>()
                .AddSingleton<SortedListStrategy<Element>>()
                .AddSingleton<SortedListOptimizedStrategy<Element>>()
                .AddSingleton<SortedDictionaryStrategy<Element>>()
                .AddSingleton<QueueStrategy<Element>>()
                .AddSingleton<StackStrategy<Element>>()
                .AddSingleton<UnsortedArrayStrategy<Element>>()
                .AddSingleton<SortedLinkedListStrategy<Element>>()
                .BuildServiceProvider();
        }

        [Benchmark]
        public void SortingStrategy()
        {
            var strategy = _serviceProvider.GetRequiredService<SortingStrategy<Element>>();

            var actual = strategy.Find(_elements, _n);

            Assert(_expected, actual);
        }

        [Benchmark]
        public void SortedSetStrategy()
        {
            var strategy = _serviceProvider.GetRequiredService<SortedSetStrategy<Element>>();

            var actual = strategy.Find(_elements, _n);

            Assert(_expected, actual);
        }

        [Benchmark]
        public void SortedListStrategy()
        {
            var strategy = _serviceProvider.GetRequiredService<SortedListStrategy<Element>>();

            var actual = strategy.Find(_elements, _n);

            Assert(_expected, actual);
        }

        [Benchmark]
        public void SortedListOptimizedStrategy()
        {
            var strategy = _serviceProvider.GetRequiredService<SortedListOptimizedStrategy<Element>>();

            var actual = strategy.Find(_elements, _n);

            Assert(_expected, actual);
        }

        [Benchmark]
        public void SortedDictionaryStrategy()
        {
            var strategy = _serviceProvider.GetRequiredService<SortedDictionaryStrategy<Element>>();

            var actual = strategy.Find(_elements, _n);

            Assert(_expected, actual);
        }

        [Benchmark]
        public void QueueStrategy()
        {
            var strategy = _serviceProvider.GetRequiredService<QueueStrategy<Element>>();

            var actual = strategy.Find(_elements, _n);

            Assert(_expected, actual);
        }

        [Benchmark]
        public void StackStrategy()
        {
            var strategy = _serviceProvider.GetRequiredService<StackStrategy<Element>>();

            var actual = strategy.Find(_elements, _n);

            Assert(expected: _expected, actual);
        }

        [Benchmark]
        public void UnsortedArrayStrategy()
        {
            var strategy = _serviceProvider.GetRequiredService<UnsortedArrayStrategy<Element>>();

            var actual = strategy.Find(_elements, _n);

            Assert(expected: _expected, actual);
        }

        [Benchmark]
        public void SortedLinkedListStrategy()
        {
            var strategy = _serviceProvider.GetRequiredService<SortedLinkedListStrategy<Element>>();

            var actual = strategy.Find(_elements, _n);

            Assert(expected: _expected, actual);
        }

        private static void Assert(Element expected, Element actual)
        {
            if (expected.Value != actual.Value)
            {
                throw new Exception($"Expected result is: {expected.Value} but actual result is: {actual.Value}.");
            }
        }

        [GlobalCleanup]
        public void Cleanup()
        {
        }
    }
}
