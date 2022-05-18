using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism;

public static class Dominoes
{

    public static List<(int, int)> copyList(IEnumerable<(int, int)> list)
    {
        List<(int, int)> copy = new();
        foreach (var element in list)
        {
            copy.Add(element);
        }
        return copy;
    }

    public static bool CanChain(IEnumerable<(int, int)> dominoes)
    {
        List<(int, int)> dominoesList = new();
        foreach (var domino in dominoes)
        {
            dominoesList.Add(domino);
        }
        return Solve(dominoesList);

    }
    public static bool Solve(List<(int, int)> dominoes, int begin = 0, int end = 0)

    {
        if (dominoes.Count() == 0)
        {
            return (begin == end);
        }
        foreach (var domino in dominoes)
        {
            if (begin == 0)
            {
                List<(int, int)> copy = copyList(dominoes);
                copy.RemoveAt(copy.IndexOf(domino));
                return Solve(copy, domino.Item1, domino.Item2);
                break;
            }
            else
            {
                if (domino.Item1 == begin)
                {
                    begin = domino.Item2;
                }
                else if (domino.Item2 == begin)
                {
                    begin = domino.Item1;
                }
                else
                    continue;

                List<(int, int)> copy = copyList(dominoes);
                copy.RemoveAt(copy.IndexOf(domino));
                if (Solve(copy, begin, end))
                    return true;
            }
        }


        return false;
    }
}