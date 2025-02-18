string name = "Chris";
byte age = 26;
bool havingPet = false;
int size = 38;
Console.WriteLine($"My name - {name}");
Console.WriteLine($"I'm {age} years");
Console.WriteLine($"Do i have a pat? {havingPet}");
Console.WriteLine($"My foot size - {size}");
//Console.ReadKey();

double result = (double)5 / 2;
Console.WriteLine("5 / 2 = {0}", result);

result = 10 % 3;
Console.WriteLine(result);

enum TrafficLightColor : int
{
    Red = 100,
    Yellow = 200,
    Green = 300
}