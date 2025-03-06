using System;

static (string name, string surname, int age, bool havePets, List<string> petNames, List<string> colors) GetPersonInfo()
{

    Console.WriteLine("Введите имя:");
    string name = Console.ReadLine();

    Console.WriteLine("Введите фамилию:");
    string surname = Console.ReadLine();

    int age = 0;
    while (true)
    {
        Console.WriteLine("Введите возраст:");
        string? ageInput = Console.ReadLine();
        if (int.TryParse(ageInput, out age) && age > 0) break;
        else Console.WriteLine("Некорректный возраст, попробуйте еще раз!");
    }

    Console.WriteLine("У вас есть питомцы(да/нет):");
    string petInput = Console.ReadLine();
    bool havePets = petInput.ToUpper() == "ДА" || petInput.ToUpper() == "YES";

    List<string> petNames = new List<string>();

    //метод в методе
    void checkList(string a, string b, List<string> list)
    {
        while (true)
        {
            Console.WriteLine(a);
            string? countInput = Console.ReadLine();
            if (int.TryParse(countInput, out int count) && count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine(b);
                    list.Add(Console.ReadLine());
                }
                break;
            }
            else Console.WriteLine("Некорректно введено число, попробуйте еще раз!");
        }

    }

    if (havePets)
    {
        checkList("Сколько питомцев:", "Имя питомца:", petNames);
    }

    List<string> colors = new List<string>();
    checkList("Сколько любимых цветов:", "Любимый цвет:", colors);

    return (name, surname, age, havePets, petNames, colors);
}

//Использование
(string name, string surname, int age, bool hasPets, List<string> petNames, List<string> colors) personInfo = GetPersonInfo();

Console.WriteLine($"Имя: {personInfo.name}");
Console.WriteLine($"Фамилия: {personInfo.surname}");
Console.WriteLine($"Возраст: {personInfo.age}");

Console.WriteLine($"Есть питомцы: {(personInfo.hasPets ? "Да" : "Нет")}");

if (personInfo.hasPets)
{
    Console.WriteLine("Имена питомцев:");
    foreach (string petName in personInfo.petNames)
    {
        Console.WriteLine(petName);
    }
}

if (personInfo.colors.Count > 0)
{
    Console.WriteLine("Любимые цвета:");
    foreach (string color in personInfo.colors)
    {
        Console.WriteLine(color);
    }
}
