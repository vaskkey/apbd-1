namespace Containers;

public class GasContainer (double maxWeight, double height, double depth, double weightNet)
                                         : Container(maxWeight, height, depth, weightNet, 'G'), IHazardNotifier
{
    public void Notify()
    {
        Console.WriteLine($"Gas Danger: {SerialNumber}");
    }

    public override void Empty()
    {
        Weight *= 0.05;
    }
}