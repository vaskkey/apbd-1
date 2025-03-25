namespace Containers;

public class Ship(double maxWeight, double maxSpeed, int maxContainers)
{
    public List<Container> Containers { get; } = [];
    public List<IHazardNotifier> Notifiers { get; } = [];

    public double TotalWeight
    {
        get
        {
            double weight = 0;
            foreach (var container in Containers)
            {
                weight += container.Weight;
            }

            return weight;
        }
    }

    public void Notify()
    {
        Notifiers.ForEach(notifier => notifier.Notify());
    }

    public void AddNotifier(IHazardNotifier notifier)
    {
       Notifiers.Add(notifier);
    }

    public void AddContainer(Container container)
    {
        if (Containers.Count + 1 > maxContainers)
        {
            throw new ShipAtMaximumCapacityException();
        }
        
        if (TotalWeight + container.Weight > maxWeight)
        {
            throw new ShipAtMaximumCapacityException();
        }
        
        Containers.Add(container);
    }
    
    public void AddContainers(List<Container> containers)
    {
        containers.ForEach(AddContainer);
    }

    public void Remove(Container container)
    {
        container.Empty();
        Containers.Remove(container);
    }
    
    public void Remove(string id)
    {
        var container = Containers.Find(cont => cont.SerialNumber.Equals(id));
        if (container == null) return;
        
        Remove(container);
    }

    public void Empty()
    {
        Containers.ForEach(container => container.Empty());
        Containers.Clear();
    }

    public void ReplaceContainer(Container from, Container to)
    {
        Containers.Remove(from);
        try
        {
            Containers.Add(to);
        }
        catch (ShipAtMaximumCapacityException e)
        {
            Containers.Add(from);
        }
    }

    public override string ToString()
    {
        var conts = "";

        foreach (var cont in Containers)
        {
            if ("".Equals(conts))
            {
                conts = cont.ToString();
                continue;
            }
            conts = $"{conts}\n{cont}";
        }

        return $"Max speed {maxSpeed}, max weight {maxWeight} max containers {maxContainers}. Containers: \n{conts}";
    }
}