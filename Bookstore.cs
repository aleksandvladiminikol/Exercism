using System.Collections.Immutable;
using System.Linq;
namespace Exercism;

public static class BookStore
{
    private static decimal[] price = { 0m, 8m, 15.2m, 21.6m, 25.6m, 30m};
    public static decimal Total(IEnumerable<int> books)
    {
        var aGroups = new List<HashSet<int>>();
        var bGroups = new List<HashSet<int>>();
        foreach (var book in books)
        {
            var aGroup = aGroups.Where(p => !p.Contains(book)).OrderByDescending(i => i.Count).FirstOrDefault();
            var bGroup = bGroups.Where(p => !p.Contains(book)).OrderBy(i => i.Count).FirstOrDefault(); 
            if (aGroup == null)
            {
                aGroup = new HashSet<int>();
                aGroups.Add(aGroup);
            }
            if (bGroup == null)
            {
                bGroup = new HashSet<int>();
                bGroups.Add(bGroup);
            }
            aGroup.Add(book);
            bGroup.Add(book);
        }
        return Math.Min(aGroups.Sum(p => price[p.Count]), bGroups.Sum(p => price[p.Count]));
    }
}