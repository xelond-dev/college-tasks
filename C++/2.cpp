#include <iostream>
#include <math.h>

using namespace std;

int main()
{
    setlocale(LC_ALL, "Russian");
    int firstNumber, secondNumber, operation;

    std::cout << "Добро пожаловать в калькулятор X space 3000!!\n";

    std::cout << "Выберите операцию из списка: \n";
    std::cout << "1.Сложение\n2.Вычитание\n3.Частное\n4.Произвденеи\n5.Возведение в степень\n6.Нахождения квадратного корня\n7.Нахождение 1 процента от числа \n8.Найти факториал числа\n9.Выйти из программы.";
    std::cin >> operation;

    if (operation == 9) {
        exit(0);
    }


    std::cout << "Введите первое число: ";
    std::cin >> firstNumber;


    if (operation != 6 && operation != 7 && operation != 8) {
        std::cout << "Введите второе число: ";
        std::cin >> secondNumber;
    }

    std::cout << "Ответ: ";

    switch (operation) {
    case 1:
        std::cout << firstNumber + secondNumber;
        break;
    case 2:
        std::cout << firstNumber - secondNumber;
        break;
    case 3:
        std::cout << firstNumber / secondNumber;
        break;
    case 4:
        std::cout << firstNumber * secondNumber;
        break;
    case 5:
        std::cout << pow(firstNumber, secondNumber);
        break;
    case 6:
        std::cout << sqrt(firstNumber);
        break;
    case 7:
        std::cout << firstNumber / 100;
        break;
    case 8:
        int result;
        result = 1;

        for (int i = 1; i <= firstNumber; i++) {
            result *= i;
        }

        std::cout << result;
        break;
    }
}