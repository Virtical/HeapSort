using NUnit.Framework;

namespace HeapSort.Tests;

public class HeapifyTests
{
    [Test]
    public void WhenHeapifyCalledOnSimpleHeap_ShouldMaintainHeapProperty()
    {
        int ifCount = 0, swapCount = 0;
        int[] array = [10, 15, 5];

        var result = HeapSortAlgorithm.Heapify(array, 3, 0, ref ifCount, ref swapCount);

        Assert.That(result[0], Is.GreaterThanOrEqualTo(result[1]));
        Assert.That(result[0], Is.GreaterThanOrEqualTo(result[2]));
        Assert.That(ifCount, Is.EqualTo(6));
        Assert.That(swapCount, Is.EqualTo(1));
    }
}