using System.Text;
using System.Text.RegularExpressions;

namespace Exercism.Tasks;

public static class IsbnVerifier
{
    public static bool IsValid(string number, int size = 10)
    {
        var numberInt = 0;
        number = number.Replace("-", String.Empty);

        var isbn = String.Empty;
        var isbn_size = 0;
        
        switch (number.Length)
        {
            case 10: 
                isbn = Regex.Match(number, @"^\d{9}[\d|X]$").Value;
                isbn_size = 10;
                break;
            case 13: 
                isbn = Regex.Match(number, @"^(978|979)\d{9}$").Value;
                isbn_size = 13;
                break; 
            default:
                return false;
        };

        var checksum = 0;
        for (int i = 0; i < isbn.Length; i++)
        {
            var value = 0;
            if (!int.TryParse(isbn[i].ToString(), out value))
            {
                value = 10;
            }
            checksum += value * isbn_size;
            isbn_size--;
        }
        
        return (checksum % 11 == 0 && checksum != 0);
    }
    
}