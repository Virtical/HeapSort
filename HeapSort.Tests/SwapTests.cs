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
    }
}