using System;
using static System.Console;
// Интерфейс логгера
interface ILogger
{
    void LogEvent(string message);
    void LogError(string message);
}

// Реализация логгера с цветным выводом
class ConsoleLogger : ILogger
{
    public void LogEvent(string message)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"[EVENT] {DateTime.Now}: {message}");
        Console.ResetColor();
    }

    public void LogError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"[ERROR] {DateTime.Now}: {message}");
        Console.ResetColor();
    }
}

interface ICalculator
{
    int Addition(int a, int b);
    int Subtraction(int a, int b);
    int Multiplication(int a, int b);
    int Division(int a, int b);
}

class Calculator : ICalculator
{
    private readonly ILogger _logger;

    // Внедрение зависимости через конструктор
    public Calculator(ILogger logger)
    {
        _logger = logger;
    }

    public int Addition(int a, int b)
    {
        int result = a + b;
        _logger.LogEvent($"{a} + {b} = {result}");
        return result;
    }

    public int Subtraction(int a, int b)
    {
        int result = a - b;
        _logger.LogEvent($"{a} - {b} = {result}");
        return result;
    }

    public int Multiplication(int a, int b)
    {
        int result = a * b;
        _logger.LogEvent($"{a} * {b} = {result}");
        return result;
    }

    public int Division(int a, int b)
    {
        if (b == 0)
        {
            _logger.LogError($"Division by zero attempted: {a} / {b}");
            throw new DivideByZeroException("Division by zero is not allowed.");
        }

        int result = a / b;
        _logger.LogEvent($"{a} / {b} = {result}");
        return result;
    }
}

delegate int Operation(int x, int y);

class Program
{
    static void Main(string[] args)
    {
        // Создаем логгер и внедряем его в калькулятор
        ILogger logger = new ConsoleLogger();
        Calculator calculator = new Calculator(logger);
        Console.WriteLine("Введите выражение (например 5 + 3) с целыми числами или 'exit' для выхода:");
        while (true)
        {
            try
            {

                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                    break;

                string[] parts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != 3)
                {
                    logger.LogError("Invalid input format. Use: number operator number");
                    Console.WriteLine("Неправильный формат ввода. Используйте формат: ЧИСЛО оператор ЧИСЛО");
                    continue;
                }

                if (!int.TryParse(parts[0], out int a) || !int.TryParse(parts[2], out int b))
                {
                    logger.LogError("One or both operands are not integers");
                    Console.WriteLine("Ошибка: оба операнда должны быть целыми числами");
                    continue;
                }

                Operation op = parts[1] switch
                {
                    "+" => calculator.Addition,
                    "-" => calculator.Subtraction,
                    "*" => calculator.Multiplication,
                    "/" => calculator.Division,
                    _ => throw new ArgumentException("Неизвестная операция. Допустимые операции: +, -, *, /")
                };

                int result = op(a, b);
                Console.WriteLine($"Результат: {result}");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                WriteLine($"Ошибка: {ex.Message}");
            }

        }
    }
}