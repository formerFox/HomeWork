Console.Write("Your name - ");
string name = Console.ReadLine();
Console.Write("Age - ");
byte age = (byte)int.Parse(Console.ReadLine());
Console.WriteLine($"Your name - {name} and age is {age}");
Console.Write("What is your favorite day of week?(number)");
DayOfWeek day = (DayOfWeek)int.Parse(Console.ReadLine());
Console.WriteLine($"Your favorite day is - {day}");

enum DayOfWeek : byte
{
    Monday = 1,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}