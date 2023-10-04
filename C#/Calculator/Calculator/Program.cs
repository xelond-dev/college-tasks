using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Define variables
            int userInput = 0;
            int result = 1;
            int firstNumber = 0;
            int secondNumber = 0;

            while (userInput != 9)
            {

                // Define variables
                userInput = 0;
                result = 1;
                firstNumber = 0;
                secondNumber = 0;

                try
                {
                    Console.WriteLine("[1] Сложение\n[2] Вычитание\n[3] Умножение\n[4] Деление\n[5] Степень\n[6] Квадратный корень\n[7] Процент\n[8] Факториал\n[9] Выйти\n");
                    Console.Write("Выберите операцию: ");
                    userInput = Convert.ToInt16(Console.ReadLine());

                    if (userInput == 1 || userInput == 2 || userInput == 3 || userInput == 4 || userInput == 5 || userInput == 6 || userInput == 7 || userInput == 8)
                    {
                        Console.Write("\nВведите первое число: ");
                        firstNumber = Convert.ToInt32(Console.ReadLine());

                        if (userInput != 6 && userInput != 7 && userInput != 8)
                        {
                            Console.Write("Введите второе число: ");
                            secondNumber = Convert.ToInt32(Console.ReadLine());
                        }

                        Console.Write("Результат: ");
                    }
                    else if (userInput != 9)
                    {
                        Console.WriteLine("Операция выбрана неверно.");
                    }

                    switch (userInput)
                    {
                        case 1:
                            Console.WriteLine(firstNumber + secondNumber);
                            break;
                        case 2:
                            Console.WriteLine(firstNumber - secondNumber);
                            break;
                        case 3:
                            Console.WriteLine(firstNumber * secondNumber);
                            break;
                        case 4:
                            Console.WriteLine(firstNumber / secondNumber);
                            break;
                        case 5:
                            for (int i = 1; i <= secondNumber; i++)
                            {
                                result = result * firstNumber;
                            }
                            Console.WriteLine(result);
                            // Console.WriteLine(Math.Pow(firstNumber, secondNumber));
                            break;
                        case 6:
                            Console.WriteLine(Math.Sqrt(firstNumber));
                            break;
                        case 7:
                            Console.WriteLine(firstNumber / 100);
                            break;
                        case 8:
                            for (int i = 1; i <= firstNumber; i++)
                            {
                                result = result * i;
                            }
                            Console.WriteLine(result);
                            break;
                        case 9:
                            break;
                    }
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Введено неверное значение.");
                }
                catch (System.DivideByZeroException)
                {
                    Console.WriteLine("На ноль делить нельзя.");
                }
            }


        }
    }
}
