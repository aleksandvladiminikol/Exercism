using System;
using System.Linq;
using System.Collections.Generic;

public static class SecretHandshake
{
    private static readonly Dictionary<byte, string> Rules = new()
    {
        [0b1] = "wink",
        [0b10] = "double blink",
        [0b100] = "close your eyes",
        [0b1000] = "jump"
    };
    
    private const byte ForReverse = 0b10000 >> 2;
    
    public static string[] Commands(int commandValue)
    {
        var _commandValue = commandValue;
        var reverse = false;
        var actualRules = Rules;
        var division = commandValue >> ForReverse;
        
        commandValue -= division << ForReverse;
        if (_commandValue == commandValue)
             reverse = true;

        var res = new List<int>();
        var result = new List<string>();

        foreach (var bit in Enumerable.Range(0, 8).Reverse())
        {
            var rem = (commandValue >> bit) << bit;
            commandValue -= rem;
            if (rem != 0)
            {
                actualRules.TryGetValue((byte) rem, out var action);
                result.Add(action);
            }
        }

        return reverse ? result.ToArray().Reverse().ToArray() : result.ToArray();
    }
}