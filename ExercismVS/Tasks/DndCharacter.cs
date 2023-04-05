using System;
using System.Collections;
using System.Collections.Generic;

public class DndCharacter
{
    public int Strength { get; }
    public int Dexterity { get; }
    public int Constitution { get; }
    public int Intelligence { get; }
    public int Wisdom { get; }
    public int Charisma { get; }
    public int Hitpoints { get; }

    public DndCharacter()
    {
        Strength = Ability();
        Dexterity = Ability();
        Constitution = Ability();
        Intelligence = Ability();
        Wisdom = Ability();
        Charisma = Ability();
        Hitpoints = 10 + Modifier(Constitution);
    }
    
    public static int Modifier(int score)
    {
        return (int)Math.Round(((decimal) score - 10) / 2, MidpointRounding.ToNegativeInfinity);
    }

    public static int Ability()
    {
        const int throwsCount = 4;
        var throws = new int[4];
        for (var i = 0; i < throwsCount; i++)
        {
            var rnd = new Random();
            throws[i] = rnd.Next(1, 7);
        }

        return throws.Sum() - throws.Min();
    }

    public static DndCharacter Generate()
    {
        return new DndCharacter();
    }
}