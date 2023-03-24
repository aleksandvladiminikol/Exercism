using System;

public class WeighingMachine
{
    private double _weight;
    public int Precision { get; }
    public double Weight
    {
        get => _weight;
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException();
            _weight = value;
        }
    }

    public string DisplayWeight => $"{string.Format($"{{0:F{Precision}}}", Weight - TareAdjustment)} kg".Replace(',', '.');
        
    public double TareAdjustment { get; set; } = 5;
    
    public WeighingMachine(int precision)
    {
        Precision = precision;
    }
}
