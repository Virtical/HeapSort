namespace HeapSort.MassTesting;

public interface IMassTest
{
    string ExperimentName { get; }
    int StartLength { get; }
    int MaxLength { get; }
    byte Repeat { get; }
    
    public void Run();
}