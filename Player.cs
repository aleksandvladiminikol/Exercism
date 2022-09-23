namespace Exercism;

using System;

public class Player
{
    private Random _randomizer = new();
    public int RollDie()
    {
        return _randomizer.Next(1, 18);
    }

    public double GenerateSpellStrength()
    {
        return _randomizer.NextDouble() * 100;
    }
}
