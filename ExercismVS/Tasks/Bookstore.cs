using System.Collections.Immutable;
using System.Linq;
namespace Exercism;

public static class BookStore
{
    private const int _cost = 8;
    private static readonly Dictionary<int, int> _saleRules = new()
    {
        {1, 0},
        {2, 5},
        {3, 10},
        {4, 20},
        {5, 25}
    };

   
    private static Dictionary<int, int> GetBooks(IEnumerable<int> books)
    {
        var result = new Dictionary<int, int>();
        var count = 0;
        foreach (var book in books)
        {
            result.TryGetValue(book, out count);
            if (result.TryAdd(book, count + 1) == false)
            {
                result[book] = count + 1;
            }
        }
          
        return SortDictionary(result);
    }

    private static Dictionary<int, int> SortDictionary(Dictionary<int, int> toSort)
    {
        var result = new Dictionary<int, int>();

        foreach (KeyValuePair<int, int> pair in toSort.OrderByDescending(key => key.Value))
        {
            result.TryAdd(pair.Key, pair.Value);
        }

        return result;
    }

    private static void UpdateBooks(this Dictionary<int, int> books, int limit)
    {
        var deletingKeys = new List<int>();

        var counter = 0;
        
        foreach (var key in books.Keys)
        {
            books[key] = books[key] - 1;
            if (books[key] == 0)
            {
                deletingKeys.Add(key);
            }

            counter++;
            
            if (counter >= limit)
                break;
            
        }
        
        foreach (var key in deletingKeys)
        {
            books.Remove(key);
        }
    }
    
    public static decimal Total(IEnumerable<int> books)
    {
        var results = new List<decimal>();
        var boughtBooks = GetBooks(books);
        
        for (var i = 5; i > 1; i--)
        {
            var booksCopy = boughtBooks.ToDictionary(pair => pair.Key , pair => pair.Value);
            
            
            decimal result = 0;
            decimal unpaidBooks = Math.Min(booksCopy.Count(), i);
            while (unpaidBooks > 0)
            {
                int sale = 0;
                _saleRules.TryGetValue((int) unpaidBooks, out sale);

                decimal currentCost = unpaidBooks * _cost * (1 - (decimal) sale / 100);
                result += currentCost;
                UpdateBooks(booksCopy, i);
                unpaidBooks = booksCopy.Count();
                booksCopy = SortDictionary(booksCopy);

            }
            if (result != 0)
                results.Add(result);
        }

        return results.Min();
    }
    
}