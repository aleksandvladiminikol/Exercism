using System;
using System.Collections.Generic;

public interface IRemoteControlCar
{
    int DistanceTravelled { get; }
    void Drive();
}


public class ProductionRemoteControlCar: IRemoteControlCar, IComparable<ProductionRemoteControlCar>, IEquatable<ProductionRemoteControlCar>
{
    public int DistanceTravelled { get; private set; }
    public int NumberOfVictories { get; set; }

    public void Drive()
    {
        DistanceTravelled += 10;
    }
    public int CompareTo(ProductionRemoteControlCar other)
    {
        if (NumberOfVictories == other.NumberOfVictories)
        {
            if (DistanceTravelled > other.DistanceTravelled)
                return 1;
            else
                return -1;
        }
        else if (NumberOfVictories > other.NumberOfVictories)
            return 1;
        else
            return -1;
    }

    public bool Equals(ProductionRemoteControlCar? other)
    {
        if (other == null)
            return false;
        return this.NumberOfVictories == other.NumberOfVictories;
    }
}

public class ExperimentalRemoteControlCar: IRemoteControlCar
{
    public int DistanceTravelled { get; private set; }

    public void Drive()
    {
        DistanceTravelled += 20;
    }
}

public static class TestTrack
{
    public static void Race(IRemoteControlCar car)
    {
        car.Drive();
    }

    public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar prc1,
        ProductionRemoteControlCar prc2)
    {
        var result = new List<ProductionRemoteControlCar>();
        result.Add(prc1);
        result.Add(prc2);
        result.Sort();
        
        return result;
    }
}
