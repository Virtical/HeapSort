namespace HeapSort.MassTesting;

public class GeometricProgressionMassTest(
    string experimentName,
    int startLength,
    int maxLength,
    byte repeat,
    byte znamen) : IMassTest
{
    public string ExperimentName { get; } = experimentName;
    public int StartLength { get; } = startLength;
    public int MaxLength { get; } = maxLength;
    public byte Repeat { get; } = repeat;
    
    private readonly byte Znamen = znamen; 
    private readonly Random random = new();

    public void Run()
    {
        var curLength = StartLength;
        
        while (curLength <= MaxLength)
        {
            Console.Write(curLength);
            for (var i = 0; i < Repeat; i++)
            {
                ulong swapCount = 0;
                ulong ifCount = 0;
                var array = GenerateArray(curLength);
            
                HeapSortAlgorithm.Sort(array, ref ifCount, ref swapCount);
                Console.Write(" " + ifCount + " " + swapCount);
            }
            Console.WriteLine();
            curLength *= Znamen;
        }
    }

    private byte[] GenerateArray(int length)
    {
        var array = new byte[length];

        for (var i = 0; i < length; i++)
        {
            array[i] = (byte)random.Next(0, 256);
        }
        
        return array;
    }
}