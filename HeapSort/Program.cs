namespace HeapSort;

class Program
{
    public static void Main()
    {
        var array = new[] { 2, 10, 4, 5, 1, 3, 7, 9, 6, 8 };
        var swapCount = 0;
        var ifCount = 0;
        
        var result = HeapSortAlgorithm.Sort(array, ref ifCount, ref swapCount);
        
        Console.WriteLine(string.Join(", ", result));
        Console.WriteLine("ifCount: " + ifCount);
        Console.WriteLine("swapCount: " + swapCount);
    }
}