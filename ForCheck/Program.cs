//Задание 1

// Определяем собственный тип исключения
public class MyCustomException : Exception
{
    public MyCustomException(string message) : base(message) { }
}

class Program
{
    static void Main(string[] args)
    {

        //Задание 1

        // Создаем массив с пятью различными исключениями
        Exception[] exceptions = new Exception[]
        {
                new ArgumentNullException("Сообщение об ошибке ArgumentNullException."),
                new DivideByZeroException("Сообщение об ошибке DivideByZeroException."),
                new InvalidOperationException("Сообщение об ошибке InvalidOperationException."),
                new IndexOutOfRangeException("Сообщение об ошибке IndexOutOfRangeException."),
                new MyCustomException("Собственное исключение.")
        };

        // Обрабатываем каждый тип исключения с помощью блока Try-Catch-Finally
        foreach (var ex in exceptions)
        {
            try
            {
                // Искусственно вызываем исключение
                throw ex;
            }
            catch (MyCustomException customEx)
            {
                Console.WriteLine($"{customEx.Message}");
            }
            catch (ArgumentNullException argNullEx)
            {
                Console.WriteLine($"{argNullEx.Message}");
            }
            catch (DivideByZeroException divideByZeroEx)
            {
                Console.WriteLine($"{divideByZeroEx.Message}");
            }
            catch (InvalidOperationException invalidOpEx)
            {
                Console.WriteLine($"{invalidOpEx.Message}");
            }
            catch (IndexOutOfRangeException indexOutEx)
            {
                Console.WriteLine($"{indexOutEx.Message}");
            }
            /*finally
            {
                Console.WriteLine("Finally block executed.\n");
            }*/
        }

        //Задание 2
        List<string> surnames = new List<string>
        {
            "Петров",
            "Иванов",
            "Сидоров",
            "Кузнецов",
            "Алексеев"
        };

        Sorter sorter = new Sorter();
        sorter.SortEvent += (sortedSurnames) =>
        {
            Console.WriteLine("Фамилии отсортированы:");
            foreach (var surname in sortedSurnames)
            {
                Console.WriteLine(surname);
            }
        };

        try
        {
            sorter.SortList(surnames);
        }
        catch (MyCustomException customEx)
        {
            Console.WriteLine($"{customEx.Message}");
        }

    }
}


//Задание 2

// Делегат для события сортировки фамилий
public delegate void SortEventHandler(List<string> surnames);
class Sorter
{
    // Событие для сортировки
    public event SortEventHandler SortEvent;

    public void SortList(List<string> list)
    {
        int choice = 0; // по умолчанию
        while (true)
        {
            Console.WriteLine($"Если хотите отсортировать от А до Я - введите 1, от Я до А - 2:");
            string? count = Console.ReadLine();
            if (int.TryParse(count, out choice) && choice == 1 || choice == 2) break;
            else Console.WriteLine("Некорректный ввод! Пожалуйста, введите число 1 или 2.");
        }

        if (list != null)
            switch (choice)
            {
                case 1:
                    Console.WriteLine($"Выбрана сортировка от А до Я!");
                    list.Sort();
                    foreach (var item in list) Console.WriteLine(item.ToString());
                    break;
                case 2:
                    Console.WriteLine($"Выбрана сортировка от Я до А!");
                    list.Sort();
                    list.Reverse();
                    foreach (var item in list) Console.WriteLine(item.ToString());
                    break;
            };

        Console.WriteLine($"");
    }
}


