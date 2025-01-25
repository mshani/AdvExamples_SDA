using AdvShape;

Rectangle rectangle = new Rectangle()
{
    Base = 2,
    Height = 3
};

double rPerimeter = rectangle.CalculatePerimeter();
double rSurface = rectangle.CalculateSurface();
Console.WriteLine($"p:{rPerimeter}");
Console.WriteLine($"s: {rSurface}");

Cicle cicle = new Cicle()
{
    Radius = 3
};

double cPerimeter = cicle.CalculatePerimeter();
double cSurface = cicle.CalculateSurface();
Console.WriteLine($"p:{cPerimeter}");
Console.WriteLine($"s: {cSurface}");
