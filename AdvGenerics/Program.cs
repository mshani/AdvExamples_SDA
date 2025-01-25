using AdvGenerics;

var group = new Group<string>();
group.Elements.Add("Monday");

var group2 = new Group<int>();
group2.Elements.Add(2);

//Swapper<T>
    //Prop1 <T> Ana
    //Prop2 <T> Andi
    //Swap<T>()

Swapper<int> swapper = new Swapper<int>
{
    Prop1 = 5,
    Prop2 = 10
};
Console.WriteLine($"Pre swap Prop1 {swapper.Prop1}");
Console.WriteLine($"Pre swap Prop2 {swapper.Prop2}");

swapper.Swap();

Console.WriteLine($"Prop1 {swapper.Prop1}");
Console.WriteLine($"Prop2 {swapper.Prop2}");

Swapper<string> stringSwapper = new Swapper<string>
{
    Prop1 = "Ana",
    Prop2 = "Andi"
};

Console.WriteLine($"Pre swap Prop1 {stringSwapper.Prop1}");
Console.WriteLine($"Pre swap Prop2 {stringSwapper.Prop2}");

stringSwapper.Swap();
stringSwapper.Swap();

Console.WriteLine($"Prop1 {stringSwapper.Prop1}");
Console.WriteLine($"Prop2 {stringSwapper.Prop2}");