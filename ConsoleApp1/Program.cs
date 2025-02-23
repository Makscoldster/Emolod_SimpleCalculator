using System;
using System.Text;

namespace SimpleCalculator
{
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
        static void StandartInput()
        {

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
                    int choice = Input(0);
                    if (choice > -1 && choice < 7)
                    {
                        return choice;
                    }
                    else { Problem(2); }
                }
                catch { Problem(1); }
            } while (true);
        }


        static int Input(int flag)
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
                1 => Addition,
                2 => Subtraction,
                3 => Multiplication,
                4 => Division,
                5 => SquareRootn,
                6 => Exponentiation,

                _ => throw new ArgumentException("Невірний вибір операції")
            };

            operation(first, second);
        }

        static void Addition(int first, int second)
        {
            Console.WriteLine($"{first} + {second} = {first + second}");
        }

        static void Subtraction(int first, int second)
        {
            Console.WriteLine($"{first} - {second} = {first - second}");
        }
        static void Multiplication(int first, int second)
        {
            Console.WriteLine($"{first} * {second} = {first * second}");
        }
        static void Division(int first, int second)
        {
            if(second == 0) Console.WriteLine("Неможливе ділення на нуль!");
            else Console.WriteLine($"{first} / {second} = {first * 1.0 / second}");
        }
        static void SquareRootn(int first, int second)
        {
            if (first < 0) Console.WriteLine("Підкореневий вираз не може бути меншим за нуль");
            else Console.WriteLine($"√{first} = {Math.Sqrt(first)}");
        }
        static void Exponentiation(int first, int second)
        {
            if (second < 0) Console.WriteLine("Показник степеня не може бути меншим за нуль");
            else Console.WriteLine($"{first}^{second} = {Math.Pow(first,second)}");
        }
    }
}
