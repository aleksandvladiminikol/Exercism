using System.Runtime.CompilerServices;

namespace Exercism;

class Programm
{
    static void Main()
    {
        Console.WriteLine(Identifier.Clean("my   Id"));
        Console.WriteLine(Identifier.Clean("my\0Id"));
        Console.WriteLine(Identifier.Clean("à-ḃç"));
        Console.WriteLine(Identifier.Clean("1😀2😀3😀"));
        Console.WriteLine(Identifier.Clean("MyΟβιεγτFinder"));

        
    }
}