using NUnit.Framework;

namespace HeapSort.Tests
{
    public class SwapTests
    {
        [Test]
        public void WhenCallingSwap_ShouldSwapAndIncrementSwapCount()
        {
            var swapCount = 0;

            var result = HeapSortAlgorithm.Swap(1, 2, ref swapCount);

            Assert.That(result.Item1, Is.EqualTo(2));
            Assert.That(result.Item2, Is.EqualTo(1));
            Assert.That(swapCount, Is.EqualTo(1));
        }
        
        [Test]
        public void SwapSameValues_ShouldStillIncrementSwapCount()
        {
            var swapCount = 0;

            var result = HeapSortAlgorithm.Swap(5, 5, ref swapCount);

            Assert.That(result.Item1, Is.EqualTo(5));
            Assert.That(result.Item2, Is.EqualTo(5));
            Assert.That(swapCount, Is.EqualTo(1));
        }
        
        [Test]
        public void MultipleSwaps_ShouldAccumulateSwapCount()
        {
            var swapCount = 0;

            HeapSortAlgorithm.Swap(1, 2, ref swapCount);
            HeapSortAlgorithm.Swap(3, 4, ref swapCount);
            HeapSortAlgorithm.Swap(5, 6, ref swapCount);

            Assert.That(swapCount, Is.EqualTo(3));
        }
    }
}