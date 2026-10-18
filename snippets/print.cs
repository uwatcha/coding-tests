static void Print(string label, object value)
{
    Console.WriteLine(label + ": " + value);
}

static void PrintElements(string label, IEnumerable values)

{
    string valueText = string.Join(", ", values);
    Console.WriteLine(label + ": " + valueText);
}
