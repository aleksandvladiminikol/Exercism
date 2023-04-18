using System;
using System.Linq;
using System.Collections.Generic;
public struct Coord: IEquatable<Coord>, IComparable<Coord>
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }
    

    public bool Equals(Coord other)
    {
        return X == other.X && Y == other.Y;
    }

    public override bool Equals(object? obj)
    {
        return obj is Coord other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
    
    public static bool operator ==(Coord left, Coord right)
    {
        return left.Equals(right);
    }
    
    public static bool operator !=(Coord left, Coord right)
    {
        return !left.Equals(right);
    }
    public static bool operator <(Coord left, Coord right)
    {
        return left.X < right.X && left.Y < right.Y;
    }
    public static bool operator >(Coord left, Coord right)
    {
        return left.X > right.X && left.Y > right.Y;
    }
    public static bool operator <=(Coord left, Coord right)
    {
        return left.X <= right.X && left.Y <= right.Y;
    }
    public static bool operator >=(Coord left, Coord right)
    {
        return left.X >= right.X && left.Y >= right.Y;
    }

    public int CompareTo(Coord other)
    {
        var xComparison = X.CompareTo(other.X);
        if (xComparison != 0) return xComparison;
        return Y.CompareTo(other.Y);
    }
}

public struct Plot : IEquatable<Plot>, IComparable<Plot>
{
    public Plot(Coord east, Coord west, Coord south, Coord north)
    {
        East = east;
        West = west;
        South = south;
        North = north;
    }

    public Coord East { get; }
    public Coord West { get; }
    public Coord South { get; }
    public Coord North { get; }
    public bool Equals(Plot other)
    {
        return East.Equals(other.East) && West.Equals(other.West) && South.Equals(other.South) &&
               North.Equals(other.North);
    }

    public override bool Equals(object? obj)
    {
        return obj is Plot other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(East, West, South, North);
    }

    public static bool operator ==(Plot left, Plot right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Plot left, Plot right)
    {
        return !left.Equals(right);
    }
    public static bool operator >(Plot left, Plot right)
    {
        return left.East > right.East && left.West > right.West && left.South > right.South && left.North > right.North;
    }
    public static bool operator <(Plot left, Plot right)
    {
        return left.East < right.East && left.West < right.West && left.South < right.South && left.North < right.North;
    }
    public static bool operator >=(Plot left, Plot right)
    {
        return left.East >= right.East && left.West >= right.West && left.South >= right.South && left.North >= right.North;
    }
    public static bool operator <=(Plot left, Plot right)
    {
        return left.East <= right.East && left.West <= right.West && left.South <= right.South && left.North <= right.North;
    }


    public int CompareTo(Plot other)
    {
        var eastComparison = East.CompareTo(other.East);
        if (eastComparison != 0) return eastComparison;
        var westComparison = West.CompareTo(other.West);
        if (westComparison != 0) return westComparison;
        var southComparison = South.CompareTo(other.South);
        if (southComparison != 0) return southComparison;
        return North.CompareTo(other.North);
    }
}


public class ClaimsHandler
{
    private List<Plot> stake = new();
    
    public void StakeClaim(Plot plot)
    {
        stake.Add(plot);
    }

    public bool IsClaimStaked(Plot plot)
    {
        var res = stake.Find(p =>
                p.East == plot.East && p.West == plot.West && p.North == plot.North && p.South == plot.South);
        
        return res == plot;
    }

    public bool IsLastClaim(Plot plot)
    {
        return stake[^1] == plot;
    }

    public Plot GetClaimWithLongestSide()
    {
        return stake.MaxBy(p => p);
    }
}