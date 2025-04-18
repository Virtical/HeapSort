using HeapSort.MassTesting;

namespace HeapSort;

class Program
{
    public static void Main()
    {
        var massTests = MassTestsLoader.LoadFromXml(@"C:\Users\Virtical\Desktop\HeapSort\HeapSort\MassTesting\MassTestingTask.xml");

        foreach (var test in massTests)
        {
            test.Run();
        }
    }
}