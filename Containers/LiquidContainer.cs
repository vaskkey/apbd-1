namespace Containers;

public enum LiquidType
{
    Dangerous,
    Normal
}

public class LiquidContainer(double maxWeight, double height, double depth, double weightNet)
    : Container(maxWeight, height, depth, weightNet, 'L'), IHazardNotifier
{
    
    public void Notify()
    {
        Console.WriteLine($"Danger: {SerialNumber}");
    }

    public override void Fill(double value)
    {
       Fill(value, LiquidType.Normal); 
    }

    public void Fill(double weight, LiquidType type)
    {
        switch (type)
        {
           case LiquidType.Dangerous:
           {
               if (weight > maxWeight * 0.5)
               {
                   throw new OverfillException();
               }

               Weight = weight;
               break;
           }
           case LiquidType.Normal:
           {
               if (weight > maxWeight * 0.9)
               {
                   throw new OverfillException();
               }
               Weight = weight;
               break;
           }
        }
    }
}