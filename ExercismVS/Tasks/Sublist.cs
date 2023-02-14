using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public enum SublistType
{
    Equal,
    Unequal,
    Superlist,
    Sublist
}

public static class Sublist
{
    public static SublistType Classify<T>(List<T> list1, List<T> list2)
        where T : IComparable
    {
        SublistType result = SublistType.Unequal;

        var sublist = IsSublist<T>(list1, list2);
        var superlist = IsSublist<T>(list2, list1);

        if (sublist && superlist)
            result = SublistType.Equal;

        else if (!sublist && superlist)
            result = SublistType.Superlist;

        else if (!superlist && sublist)
            result = SublistType.Sublist;

        return result;
    }

    public static bool IsEqual<T>(List<T> list1, List<T> list2)
        where T : IComparable
    {
        foreach (var x in list1)
        {

        }
        return list1 == list2;
    }

    public static bool IsSublist<T>(List<T> list1, List<T> list2, int startSearchPos = 0)
        where T : IComparable
    {

        var itemsLen = list1.Count;

        if (itemsLen > list2.Count)
            return false;

        if (list2.Count == 0)
            return true;

        var currentIndex = 0;
        int? prevFindIndex = null;

        foreach (var item in list1)
        {
            currentIndex = list2.IndexOf(item, startSearchPos);
            if (currentIndex == -1)
            {
                return false;
            }
            if (prevFindIndex == null)
            {
                startSearchPos = currentIndex+1;
                prevFindIndex = currentIndex;
                continue;
            }

            if (currentIndex != prevFindIndex+1)
            {
                return IsSublist<T>(list1, list2, startSearchPos);
            }
            prevFindIndex = currentIndex;
        }

        return true;
    }

}