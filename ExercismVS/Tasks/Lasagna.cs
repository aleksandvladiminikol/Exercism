
internal class Lasagna
{
    private readonly int ExpectedMinutes = 40;
    private readonly int MinutesPerLayer = 2;

    public Lasagna() { }

    public Lasagna(int ExpectedMinutes, int MinutesPerLayer)
    {
        this.ExpectedMinutes = ExpectedMinutes;
        this.MinutesPerLayer = MinutesPerLayer;
    }

    public int ExpectedMinutesInOven()
    {
        return ExpectedMinutes;
    }

    public int RemainingMinutesInOven(int PastTime)
    {
        return ExpectedMinutes - PastTime;
    }

    public int PreparationTimeInMinutes(int LayerCount)
    {
        return LayerCount * MinutesPerLayer;
    }

    public int ElapsedTimeInMinutes(int LayerCount, int PastTime)
    {
        return PastTime + PreparationTimeInMinutes(LayerCount);
    }

}