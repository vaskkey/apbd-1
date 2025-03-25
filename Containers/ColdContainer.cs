namespace Containers;

public enum Product
{
    Banana,
    Chocolate,
    Fish
}

public class ColdContainer (double maxWeight, double height, double depth, double weightNet) : Container(maxWeight, height, depth, weightNet, 'C')
{
    private static readonly Dictionary<Product, float> Temperatures = new()
    {
        { Product.Banana, 13.3f },
        { Product.Chocolate, 18f },
        { Product.Fish, 2 }
    };
    
    public Product? Type { get; private set; }
    public float Temperature { get; private set; }

    public override void Fill(double value)
    {
        throw new NotImplementedException(); // No products without type
    }

    public void Fill(double value, Product type)
    {
        if (Type != null && Type != type)
        {
            throw new InvalidroductTypeException();
        }

        Weight = value;
        Temperature = Temperatures[type];
    }

    public override void Empty()
    {
        Type = null;
        Weight = 0;
    }
}