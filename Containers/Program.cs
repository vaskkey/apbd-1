// See https://aka.ms/new-console-template for more information

using Containers;

var ship = new Ship(12, 500, 3);

var gas = new GasContainer(4, 1200, 1600, 1);
var liquid = new LiquidContainer(4, 1200, 1600, 1);
var freezer = new ColdContainer(4, 1200, 1600, 1);

ship.AddContainers([gas, liquid, freezer]);
ship.AddNotifier(gas);
ship.AddNotifier(liquid);

gas.Fill(3);
liquid.Fill(3);
freezer.Fill(3, Product.Banana);

try
{
    gas.Fill(5);
}
catch (OverfillException _e)
{
    Console.WriteLine("Filling too much");
}

try
{
    ship.AddContainer(new ColdContainer(10, 1200, 1600, 1));
}
catch (ShipAtMaximumCapacityException e)
{
    Console.WriteLine("Ship at maximum capacity");
}

Console.WriteLine(ship);

ship.Remove("KON-G-1");

Console.WriteLine(ship);

ship.ReplaceContainer(liquid, new ColdContainer(2, 1200, 1600, 1));

Console.WriteLine(ship);

ship.Notify();