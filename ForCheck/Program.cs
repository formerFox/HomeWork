Console.WriteLine("Введите имя");
string? name = Console.ReadLine();
for (int i = name.Length-1; i >= 0; i--)
{
    Console.Write(name[i]+" ");
}
Console.WriteLine();
foreach (char i in name)
{
    Console.Write(i + " ");
}
