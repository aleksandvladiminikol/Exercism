namespace Exercism;

class Programm
{
    static void Main()
    {
        Console.WriteLine(LogAnalysis.SubstringAfter(": "));
        Console.WriteLine(LogAnalysis.SubstringBetween("[", "]"));
        
        Console.WriteLine(LogAnalysis.Message());
        
        Console.WriteLine(LogAnalysis.LogLevel());
        
    }
}