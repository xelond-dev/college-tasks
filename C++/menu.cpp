#include <iostream>
#include <string>
#include <algorithm>
#include <random>
#include <locale>
#include <cstring>

using namespace std;

// Функция для переворачивания строки задом наперед
std::string reverseLine(const std::string line) {
    std::string reversedLine = line;
    reverse(reversedLine.begin(), reversedLine.end());
    return reversedLine;
}

std::string removeVowels(const std::string line) {
    std::string lineWithoutVowels;
    for (char ch : line) {
        if (!std::strchr("аеёиоуыэюяАЕЁИОУЫЭЮЯ", ch)) {
            lineWithoutVowels += ch;
        }
    }
    return lineWithoutVowels;
}

std::string removeConsonants(const std::string line) {
    std::string lineWithoutConsonants;
    for (char ch : line) {
        if (!std::strchr("йцкнгшщзхфвпрлджчсмтбЙЦКНГШЩЗХФВПРЛДЖЧМТБ", ch)) {
            lineWithoutConsonants += ch;
        }
    }
    return lineWithoutConsonants;
}

std::string shuffleLine(const std::string line) {
    std::string shuffledLine = line;
    std::random_shuffle(shuffledLine.begin(), shuffledLine.end());
    return shuffledLine;
}

int main() {
    setlocale(LC_ALL, "Rus"); // Установка русской локали

    std::cout << "Введите вашу строку - ";
    std::string line;
    std::cin >> line;

    int userChoice;
    std::cout << "Выберите действие:\n";
    std::cout << "[1] Вывести слово задом наперед\n";
    std::cout << "[2] Вывести слово без гласных\n";
    std::cout << "[3] Вывести слово без согласных\n";
    std::cout << "[4] Рандомно раскидывать буквы заданного слова\n";
    std::cin >> userChoice;

    switch (userChoice) {
    case 1:
        std::cout << "Ответ: " << reverseLine(line) << std::endl;
        break;
    case 2:
        std::cout << "Ответ: " << removeVowels(line) << std::endl;
        break;
    case 3:
        std::cout << "Ответ: " << removeConsonants(line) << std::endl;
        break;
    case 4:
        std::cout << "Ответ: " << shuffleLine(line) << std::endl;
        break;
    default:
        std::cout << "Вы выбрали неверный пункт меню." << std::endl;
    }

    return 0;
}
