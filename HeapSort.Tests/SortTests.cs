using FluentAssertions;
using NUnit.Framework;

namespace HeapSort.Tests;

[TestFixture]
public class SortTests
{
    [Test]
    public void WhenArrayIsUnsorted_ShouldSortCorrectly()
    {
        ulong ifCount = 0, swapCount = 0;
        int[] array = [4, 10, 3, 5, 1];
        int[] expected = [1, 3, 4, 5, 10];

        var result = HeapSortAlgorithm.Sort(array, ref ifCount, ref swapCount);

        result.Should().Equal(expected);
        ifCount.Should().BeGreaterThan(0);
        swapCount.Should().BeGreaterThan(0);
    }

    [Test]
    public void WhenArrayIsEmpty_ShouldReturnEmpty()
    {
        ulong ifCount = 0, swapCount = 0;
        int[] array = [];

        var result = HeapSortAlgorithm.Sort(array, ref ifCount, ref swapCount);

        result.Should().BeEmpty();
        ifCount.Should().Be(0);
        swapCount.Should().Be(0);
    }

    [Test]
    public void WhenArrayHasOneElement_ShouldRemainUnchanged()
    {
        ulong ifCount = 0, swapCount = 0;
        int[] array = [42];

        var result = HeapSortAlgorithm.Sort(array, ref ifCount, ref swapCount);

        result.Should().ContainSingle().Which.Should().Be(42);
        swapCount.Should().Be(0);
    }
}