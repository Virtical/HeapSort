using NUnit.Framework;

namespace HeapSort.Tests;

[TestFixture]
public class SortTests
{
    [Test]
    public void WhenArrayIsUnsorted_ShouldSortCorrectly()
    {
        int ifCount = 0, swapCount = 0;
        int[] array = [4, 10, 3, 5, 1];
        int[] expected = [1, 3, 4, 5, 10];

        var result = HeapSortAlgorithm.Sort(array, ref ifCount, ref swapCount);

        Assert.That(result, Is.EqualTo(expected));
        Assert.That(ifCount, Is.GreaterThan(0));
        Assert.That(swapCount, Is.GreaterThan(0));
    }

    [Test]
    public void WhenArrayIsEmpty_ShouldReturnEmpty()
    {
        int ifCount = 0, swapCount = 0;
        int[] array = [];

        var result = HeapSortAlgorithm.Sort(array, ref ifCount, ref swapCount);

        Assert.That(result, Is.Empty);
        Assert.That(ifCount, Is.EqualTo(0));
        Assert.That(swapCount, Is.EqualTo(0));
    }

    [Test]
    public void WhenArrayHasOneElement_ShouldRemainUnchanged()
    {
        int ifCount = 0, swapCount = 0;
        int[] array = [42];

        var result = HeapSortAlgorithm.Sort(array, ref ifCount, ref swapCount);

        Assert.That(result.Length, Is.EqualTo(1));
        Assert.That(result[0], Is.EqualTo(42));
        Assert.That(swapCount, Is.EqualTo(0));
    }
}