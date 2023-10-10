using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practick2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int userInput = 0;

            while (userInput != 4)
            {
                Console.WriteLine("[1] Игра \"Угадай число\"\n[2] Таблица умножения\n[3] Ввывод делителей числа\n[4] Выход\n");
                userInput = Convert.ToInt16(Console.ReadLine());

                switch (userInput)
                {
                    case 1: randomNumberGame(); break;
                    case 2: multiplicationTable(); break;
                    case 3: divisor(); break;
                    case 4: Environment.Exit(0); break;
                }
            }
        }

        static void randomNumberGame()
        {
            int userInput = 0;

            Random random = new Random();
            int RandomNumber = random.Next(100);

            Console.WriteLine("\nСоздано рандомное число от 0 до 100.");

            while (userInput != RandomNumber)
            {
                Console.Write("Ваше предположение: ");
                userInput = Convert.ToInt16(Console.ReadLine());

                if (userInput != RandomNumber)
                {
                    Console.WriteLine("Неверно.");
                }
            }

            Console.WriteLine("Вы угадали число.\n");
        }

        static void multiplicationTable()
        {           
            int[,] multiplicationTable = new int[11, 11];

            for (int i = 1; i <= 10; i++)
            {
                for (int ii = 1; ii <= 10; ii++)
                {
                    multiplicationTable[i, ii] = i * ii;
                }
            }

            for (int i = 1; i <= 10; i++)
            {
                for (int ii = 1; ii <= 10; ii++)
                {
                    Console.Write("{0, 6}", multiplicationTable[i, ii]);
                }
                Console.WriteLine();
            }
        }

        static void divisor()
        {
            Console.Write("\nВведите число: ");
            long number = Convert.ToInt64(Console.ReadLine());

            Console.Write("Делители числа " + number + ": ");
            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    Console.Write(i + " ");
                }
            }
            Console.Write("\n\n");
        }
    }
}
