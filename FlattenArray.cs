using System;
using System.Collections;

public static class FlattenArray
{
    public static IEnumerable Flatten(IEnumerable input)
    {
        var result = new List<object?>();
        foreach (var item in input)
        {
            if (item is IEnumerable)
            {
                foreach (var nestedItem in Flatten((IEnumerable) item))
                {
                    result.Add(nestedItem);
                }
            }
            else if (item is not null)
                result.Add(item);
        }

        return result.ToArray();
    }
}