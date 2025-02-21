var arr = new int[10];
Random random = new Random();
for (int i = 0; i < arr.Length; i++)
{
    arr[i] = random.Next(-10, 11);
    Console.WriteLine($"arr[{i}] = {arr[i]}");
}

var count = 0;
for (int i = 0; i < arr.Length; i++)
{      if (arr[i] > 0)
        count++;
}

Console.WriteLine($" количество положительных элементов = {count}");
