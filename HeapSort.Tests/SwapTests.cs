using FluentAssertions;
using NUnit.Framework;

namespace HeapSort.Tests;

public class SwapTests
{
    [Test]
    public void WhenCallingSwap_ShouldSwapAndIncrementSwapCount()
    {
        var swapCount = 0;

        var result = HeapSortAlgorithm.Swap(1, 2, ref swapCount);

        result.Item1.Should().Be(2);
        result.Item2.Should().Be(1);
        swapCount.Should().Be(1);
    }
        
    [Test]
    public void SwapSameValues_ShouldStillIncrementSwapCount()
    {
        var swapCount = 0;

        var result = HeapSortAlgorithm.Swap(5, 5, ref swapCount);

        result.Item1.Should().Be(5);
        result.Item2.Should().Be(5);
        swapCount.Should().Be(1);
    }
        
    [Test]
    public void MultipleSwaps_ShouldAccumulateSwapCount()
    {
        var swapCount = 0;

        HeapSortAlgorithm.Swap(1, 2, ref swapCount);
        HeapSortAlgorithm.Swap(3, 4, ref swapCount);
        HeapSortAlgorithm.Swap(5, 6, ref swapCount);

        swapCount.Should().Be(3);
    }
}