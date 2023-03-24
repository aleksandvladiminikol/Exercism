using System;
using System.Linq;
using System.Collections.Generic;
public enum Allergen
{
    Eggs = 1,
    Peanuts = 2,
    Shellfish = 4,
    Strawberries = 8,
    Tomatoes = 16,
    Chocolate = 32,
    Pollen = 64,
    Cats = 128
}

public class Allergies
{
    private Allergen[] _allergens;
    public Allergies(int mask)
    {
        var _bit = 8;
        while (mask > 255)
        {
            mask -= (mask >> _bit) << _bit;
            _bit++;
        }

        var allergens = new List<Allergen>();
        
        for (var bit = 7; bit >= 0; bit--)
        {
            var div = mask >> bit;
            if (div <= 0) continue;
            var allergenNum = div << bit;
            var allergen = (Allergen) allergenNum;
            allergens.Add(allergen);
            mask -= allergenNum;
        }

        _allergens = allergens.ToArray().Reverse().ToArray();

    }

    public bool IsAllergicTo(Allergen allergen) => _allergens.Any(_ => _ == allergen);

    public Allergen[] List() => _allergens;
}