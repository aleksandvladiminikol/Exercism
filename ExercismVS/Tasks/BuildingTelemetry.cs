using System;

public class RemoteControlCar
{
    private int batteryPercentage = 100;
    private int distanceDrivenInMeters = 0;
    private string[] sponsors = new string[0];
    private int latestSerialNum = 0;
    
    
    public void Drive()
    {
        if (batteryPercentage > 0)
        {
            batteryPercentage -= 10;
            distanceDrivenInMeters += 2;
        }
    }

    public void SetSponsors(params string[] sponsors)
    {
        this.sponsors = sponsors;
    }

    public string DisplaySponsor(int sponsorNum)
    {
        return sponsors[sponsorNum];
    }

    public bool GetTelemetryData(ref int serialNum,
        out int batteryPercentage, out int distanceDrivenInMeters)
    {
        if (serialNum <= this.latestSerialNum)
        {
            serialNum = this.latestSerialNum;
            batteryPercentage = -1;
            distanceDrivenInMeters = -1;
            return false;
        }
        else
        {
            batteryPercentage = this.batteryPercentage;
            distanceDrivenInMeters = this.distanceDrivenInMeters;
            this.latestSerialNum = serialNum;
            return true;
        }

    }

    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }
}

public class TelemetryClient
{
    private RemoteControlCar car;

    public TelemetryClient(RemoteControlCar car)
    {
        this.car = car;
    }

    public string GetBatteryUsagePerMeter(int serialNum)
    {
        var res = car.GetTelemetryData(ref serialNum, out int batteryPercentage, out int distanceDrivenInMeters);
        return res && distanceDrivenInMeters != 0 ? $"usage-per-meter={(100 - batteryPercentage) / distanceDrivenInMeters}" : "no data";
    }
}