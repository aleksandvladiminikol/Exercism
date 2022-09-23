namespace Exercism;

using System;

public class SpaceAge
{
    private int _seconds;
    private const int SecondsInYear = 31557600;

    private static class OrbitalPeriods
    {
        public const double Mercury = 0.2408467;
        public const double Venus = 0.61519726;
        public const double Mars = 1.8808158;
        public const double Jupiter = 11.862615;
        public const double Saturn = 29.447498;
        public const double Uranus = 84.016846;
        public const double Neptune = 164.79132;
    }
    
    public SpaceAge(int seconds)
    {
        _seconds = seconds;
    }

    public double OnEarth()
    {
        return (double) _seconds / SecondsInYear ;
    }

    public double OnMercury()
    {
        return OnEarth() / OrbitalPeriods.Mercury;
    }

    public double OnVenus()
    {
        return OnEarth() / OrbitalPeriods.Venus;
    }

    public double OnMars()
    {
        return OnEarth() / OrbitalPeriods.Mars;
    }

    public double OnJupiter()
    {
        return OnEarth() / OrbitalPeriods.Jupiter;
    }

    public double OnSaturn()
    {
        return OnEarth() / OrbitalPeriods.Saturn;
    }

    public double OnUranus()
    {
        return OnEarth() / OrbitalPeriods.Uranus;
    }

    public double OnNeptune()
    {
        return OnEarth() / OrbitalPeriods.Neptune;
    }
}