using NUnit.Framework;

namespace HeapSort.Tests;

public class HeapifyTests
{
    [Test]
    public void WhenHeapifyCalledOnAlreadyValidHeap_ShouldNotSwap()
    {
        int ifCount = 0, swapCount = 0;
        int[] array = [20, 10, 15];

        var result = HeapSortAlgorithm.Heapify(array, 3, 0, ref ifCount, ref swapCount);

        Assert.That(result, Is.EqualTo(array));
        Assert.That(swapCount, Is.EqualTo(0));
    }
    
    [Test]
    public void WhenLeftChildIsLarger_ShouldSwapWithLeft()
    {
        int ifCount = 0, swapCount = 0;
        int[] array = [5, 10, 3];

        var result = HeapSortAlgorithm.Heapify(array, 3, 0, ref ifCount, ref swapCount);

        Assert.That(result[0], Is.EqualTo(10));
        Assert.That(result[1], Is.EqualTo(5));
        Assert.That(result[2], Is.EqualTo(3));
        Assert.That(swapCount, Is.EqualTo(1));
    }

    [Test]
    public void WhenRightChildIsLarger_ShouldSwapWithRight()
    {
        int ifCount = 0, swapCount = 0;
        int[] array = [5, 3, 10];

        var result = HeapSortAlgorithm.Heapify(array, 3, 0, ref ifCount, ref swapCount);

        Assert.That(result[0], Is.EqualTo(10));
        Assert.That(result[2], Is.EqualTo(5));
        Assert.That(swapCount, Is.EqualTo(1));
    }
    
    [Test]
    public void WhenCalledOnMiddleElement_ShouldOnlyAffectSubtree()
    {
        int ifCount = 0, swapCount = 0;
        int[] array = [30, 5, 10, 2, 8];

        var result = HeapSortAlgorithm.Heapify(array, 5, 1, ref ifCount, ref swapCount);

        Assert.That(result[1], Is.EqualTo(8));
        Assert.That(result[4], Is.EqualTo(5));
        Assert.That(swapCount, Is.EqualTo(1));
    }
    
    [Test]
    public void HeapifyOnLargeArray_ShouldWorkCorrectly()
    {
        int ifCount = 0, swapCount = 0;
        int[] array = [1, 3, 5, 7, 9, 2, 4, 6, 8, 0];

        var result = HeapSortAlgorithm.Heapify(array, array.Length, 0, ref ifCount, ref swapCount);

        Assert.That(result[0], Is.GreaterThanOrEqualTo(result[1]));
        Assert.That(result[0], Is.GreaterThanOrEqualTo(result[2]));
        Assert.That(swapCount, Is.GreaterThan(0));
    }
}