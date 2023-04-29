using Xunit;

public class RemoteControlCleanupTests
{
    [Fact]
    public void ShowSponsor()
    {
        var car = new RemoteControlCar_();
        string expected = "Walker Industries Inc.";
        car.Telemetry.ShowSponsor(expected);
        Assert.Equal(expected, car.CurrentSponsor);
    }

    [Fact]
    public void ShowSpeed()
    {
        var car = new RemoteControlCar_();
        string expected = "100 meters per second";
        car.Telemetry.SetSpeed(100, "mps");
        Assert.Equal(expected, car.GetSpeed());
    }
}
