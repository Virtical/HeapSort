namespace HeapSort;

public static class HeapSortAlgorithm
{
    public static T[] Sort<T>(T[] array, ref int ifCount, ref int swapCount) where T : IComparable<T>
    {
        for (var i = array.Length / 2 - 1; i >= 0; i--)
        {
            array = Heapify(array, array.Length, i, ref ifCount, ref swapCount);
        }
        
        for (var i= array.Length; i > 1; i--)
        {
            (array[0], array[i-1]) = Swap(array[0], array[i-1], ref swapCount);
            array = Heapify(array, i-1, 0, ref ifCount, ref swapCount);
        }
        
        return array;
    }

    public static T[] Heapify<T>(T[] array, int length, int topIndex, ref int ifCount, ref int swapCount) where T : IComparable<T>
    {
        ifCount += 3;
        
        var largestIndex = topIndex;
        var leftIndex = topIndex * 2 + 1;
        var rightIndex = topIndex * 2 + 2;

        if (leftIndex < length && array[largestIndex].CompareTo(array[leftIndex]) < 0)
        {
            largestIndex = leftIndex;
        }

        if (rightIndex < length && array[largestIndex].CompareTo(array[rightIndex]) < 0)
        {
            largestIndex = rightIndex;
        }
        

        if (largestIndex == topIndex) return array;
        
        (array[topIndex], array[largestIndex]) = Swap(array[topIndex], array[largestIndex], ref swapCount);
        
        return Heapify(array, length, largestIndex, ref ifCount, ref swapCount);
    }

    public static (T, T) Swap<T>(T x, T y, ref int swapCount) where T : IComparable<T>
    {
        swapCount++;
        return (y, x);
    }
}