using FluentAssertions;
using NUnit.Framework;

namespace HeapSort.Tests;

public class HeapifyTests
{
    [Test]
    public void WhenHeapifyCalledOnAlreadyValidHeap_ShouldNotSwap()
    {
        ulong ifCount = 0, swapCount = 0;
        int[] array = [20, 10, 15];

        var result = HeapSortAlgorithm.Heapify(array, 3, 0, ref ifCount, ref swapCount);

        result.Should().Equal(array);
        swapCount.Should().Be(0);
    }
    
    [Test]
    public void WhenLeftChildIsLarger_ShouldSwapWithLeft()
    {
        ulong ifCount = 0, swapCount = 0;
        int[] array = [5, 10, 3];

        var result = HeapSortAlgorithm.Heapify(array, 3, 0, ref ifCount, ref swapCount);

        result[0].Should().Be(10);
        result[1].Should().Be(5);
        result[2].Should().Be(3);
        swapCount.Should().Be(1);
    }

    [Test]
    public void WhenRightChildIsLarger_ShouldSwapWithRight()
    {
        ulong ifCount = 0, swapCount = 0;
        int[] array = [5, 3, 10];

        var result = HeapSortAlgorithm.Heapify(array, 3, 0, ref ifCount, ref swapCount);

        result[0].Should().Be(10);
        result[2].Should().Be(5);
        swapCount.Should().Be(1);
    }
    
    [Test]
    public void WhenCalledOnMiddleElement_ShouldOnlyAffectSubtree()
    {
        ulong ifCount = 0, swapCount = 0;
        int[] array = [30, 5, 10, 2, 8];

        var result = HeapSortAlgorithm.Heapify(array, 5, 1, ref ifCount, ref swapCount);

        result[1].Should().Be(8);
        result[4].Should().Be(5);
        swapCount.Should().Be(1);
    }
    
    [Test]
    public void HeapifyOnLargeArray_ShouldWorkCorrectly()
    {
        ulong ifCount = 0, swapCount = 0;
        int[] array = [1, 3, 5, 7, 9, 2, 4, 6, 8, 0];

        var result = HeapSortAlgorithm.Heapify(array, array.Length, 0, ref ifCount, ref swapCount);

        result[0].Should().BeGreaterThanOrEqualTo(result[1]);
        result[0].Should().BeGreaterThanOrEqualTo(result[2]);
        swapCount.Should().BeGreaterThan(0);
    }
}