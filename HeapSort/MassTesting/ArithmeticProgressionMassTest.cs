using System.Text;

namespace HeapSort.MassTesting;

public class ArithmeticProgressionMassTest(
    string experimentName,
    int startLength,
    int maxLength,
    byte repeat,
    int diff) : IMassTest
{
    public string ExperimentName { get; } = experimentName;
    public int StartLength { get; } = startLength;
    public int MaxLength { get; } = maxLength;
    public byte Repeat { get; } = repeat;

    private readonly int diff = diff;
    private readonly Random random = new();

    public void Run()
    {
        var steps = (MaxLength - StartLength) / diff + 1;
        
        var outputLines = new string[steps];

        Parallel.For(0, steps, step =>
        {
            var curLength = StartLength + step * diff;

            var sb = new StringBuilder();
            sb.Append(curLength);

            for (var i = 0; i < Repeat; i++)
            {
                ulong swapCount = 0;
                ulong ifCount = 0;
                var array = GenerateArray(curLength);

                HeapSortAlgorithm.Sort(array, ref ifCount, ref swapCount);
                sb.Append(' ').Append(ifCount).Append(' ').Append(swapCount);
            }

            outputLines[step] = sb.ToString();
        });
        
        foreach (var line in outputLines)
        {
            Console.WriteLine(line);
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