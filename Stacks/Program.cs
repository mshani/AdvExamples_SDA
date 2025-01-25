string s = Console.ReadLine();
int value = Int32.Parse(s);
//58641
Stack<int> stack = new Stack<int>();
while (value > 0)
{
    int remainder = value % 10;
    stack.Push(remainder);
    value = value / 10;
}

int counter = 1;
foreach (int element in stack)
{
    if (counter == stack.Count)
    {
        Console.Write($"{element}");
    }
    else
    {
        Console.Write($"{element} - ");
    }
    counter++;
}

