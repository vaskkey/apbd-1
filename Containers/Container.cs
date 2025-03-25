namespace Containers;

public abstract class Container(double maxWeight, double height, double depth, double weightNet, char containerCode)
{
    private static int _currentId = 0;

    private double _weight;
    private string _serialCode = $"KON-{containerCode}-{++_currentId}";

    public double Weight
    {
        get => _weight;
        protected set
        {
            _weight = value;
        }
    }

    public double Height { get; } = height;
    public double WeightNet { get; set; } = weightNet;
    public double Depth { get; set; } = depth;

    public string SerialNumber
    {
        get => _serialCode;
    }

    public virtual void Fill(double value)
    {
        if (value > maxWeight)
        {
            throw new OverfillException();
        }

        Weight = value;
    }

    public virtual void Empty()
    {
        Weight = 0;
    }
    
    public override string ToString()
    {
        return SerialNumber;
    }
}