using AdvEngine;

MercedesBenz benz = new MercedesBenz()
{
    Cylinders = 6,
    RPM = 2000,
    Power = 200
};

Toyota toyota = new Toyota()
{
    Cylinders = 4,
    RPM = 1000,
    Power = 100
};

int speedBenz = benz.StartingSpeed(3);
int speedToyota = toyota.StartingSpeed(3);
Console.WriteLine($"Benz: {speedBenz}");
Console.WriteLine($"Toyota: {speedToyota}");

var smth = new
{
    Property1 = "1",
    Property2 = 2
};
