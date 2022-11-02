namespace Exercism;

using System;

class RemoteControlCar
{

    private readonly int _speed;
    private readonly int _batteryDrain;
    private int drivenDistance;
    private int currentBattery;

    public RemoteControlCar(int speed, int batteryDrain)
    {
        _speed = speed;
        _batteryDrain = batteryDrain;
        currentBattery = 100;
    }

    public bool BatteryDrained()
    {
        return (currentBattery < _batteryDrain);
    }

    public int DistanceDriven()
    {
        return drivenDistance;
    }

    public void Drive()
    {
        if (!BatteryDrained())
        {
            drivenDistance += _speed;
            currentBattery -= _batteryDrain;
            currentBattery = Math.Max(currentBattery, 0);
        }
    }

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(50, 4);
    }
}

class RaceTrack
{
    private readonly int _distance;

    public RaceTrack(int distance)
    {
        _distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        while (!car.BatteryDrained() && _distance > car.DistanceDriven())
        {
            car.Drive();
        }

        return _distance <= car.DistanceDriven();
    }
}
