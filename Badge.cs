using System.Text;

namespace Exercism;

public class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        department ??= "OWNER";
        var strlist = new List<string?>();
        
        if (id != null){strlist.Add($"[{id}]");}
        
        strlist.Add($"{name}");
        strlist.Add($"{department}".ToUpper());
        return string.Join(" - ", strlist);

    }
}