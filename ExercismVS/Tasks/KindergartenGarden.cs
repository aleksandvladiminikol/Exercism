using System;
using System.Collections.Generic;
using System.Linq;
public enum Plant
{
    Violets = 'V',
    Radishes = 'R',
    Clover = 'C',
    Grass = 'G'
}

public class KindergartenGarden
{
    private static readonly string[] Students = {"Alice", "Bob", "Charlie", "David", "Eve", "Fred", "Ginny", "Harriet", "Ileana", "Joseph", "Kincaid", "Larry"};
    private const int FlowersInRow = 2;
    private string[] _diagram;
    
    public KindergartenGarden(string diagram)
    {
        _diagram = diagram.Split('\n');
    }

    public IEnumerable<Plant> Plants(string student)
    {
        var startIndex = Array.IndexOf(Students, student) * FlowersInRow;
        var endIndex = startIndex + FlowersInRow;
        return _diagram
            .Select(s => s
                .Where((c, i) => i >= startIndex && i < endIndex))
            .SelectMany(s => s
                .Select(_ => (Plant) _))
            .ToArray();
    }
}