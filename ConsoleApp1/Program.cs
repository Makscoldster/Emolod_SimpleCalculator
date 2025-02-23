using System.Text;
namespace SimpleCalculator;

internal class Program
{
    delegate void Operation(int first, int second);

    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.Unicode;
        Console.InputEncoding = Encoding.Unicode;

        while (true)
        {
            int choice = Choose();

            if (choice == 0) { return; }

            (int firstNumber, int secondNumber) = StandartInput(choice);

            Selection(choice, firstNumber, secondNumber);
        }
    }

    static int Choose()
    {
        Console.WriteLine("Виберіть арифметичну операцію:\n" +
                        "1 - Додавання\n" +
                        "2 - Віднімання\n" +
                        "3 - Множення\n" +
                        "4 - Ділення\n" +
                        "5 - Корінь квадратний\n" +
                        "6 - Піднесення до степеня\n" +
                        "0 - Вихід з програми");

        do
        {
            try
            {
                int choice = Input();
                if (choice > -1 && choice < 7)
                {
                    return choice;
                }
                else { Problem(2); }
            }
            catch { Problem(1); }
        } while (true);
    }


    static int Input(int flag = 0)
    {
        if (flag == 1) Console.WriteLine("Введіть перше число для операцій");
        if (flag == 2) Console.WriteLine("Введіть друге число для операцій");

        do
        {
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch
            {
                Problem(1);
            }
        } while (true);

    }

    static (int, int) StandartInput(int choice)
    {
        if (choice == 5)
        {
            return (Input(1), 0);
        }
        else
        {
            return (Input(1), Input(2));
        }
    }
    static void Problem(int flag)
    {
        if (flag == 1) Console.WriteLine("Введено не коректне число!");
        else if (flag == 2) Console.WriteLine("Оберіть операцію");
    }

    static void Selection(int choice, int first, int second)
    {
        Operation operation = choice switch // switch expression 
        {
            1 => Operations.Addition,
            2 => Operations.Subtraction,
            3 => Operations.Multiplication,
            4 => Operations.Division,
            5 => Operations.SquareRootn,
            6 => Operations.Exponentiation,

            _ => throw new ArgumentException("Невірний вибір операції")
        };

        operation(first, second);
    }

}
static class Operations
{
    static public void Addition(int first, int second)
    {
        Console.WriteLine($"{first} + {second} = {first + second}");
    }

    static public void Subtraction(int first, int second)
    {
        Console.WriteLine($"{first} - {second} = {first - second}");
    }
    static public void Multiplication(int first, int second)
    {
        Console.WriteLine($"{first} * {second} = {first * second}");
    }
    static public void Division(int first, int second)
    {
        if (second == 0) Console.WriteLine("Неможливе ділення на нуль!");
        else Console.WriteLine($"{first} / {second} = {first * 1.0 / second}");
    }
    static public void SquareRootn(int first, int second)
    {
        if (first < 0) Console.WriteLine("Підкореневий вираз не може бути меншим за нуль");
        else Console.WriteLine($"√{first} = {Math.Sqrt(first)}");
    }
    static public void Exponentiation(int first, int second)
    {
         Console.WriteLine($"{first}^{second} = {Math.Pow(first, second)}");
    }
}

