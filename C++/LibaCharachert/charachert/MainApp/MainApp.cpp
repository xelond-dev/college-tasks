#include <iostream>
#include <windows.h>
#include <string>
#include <conio.h>

typedef bool(__stdcall* CheckCharactersFunc)(const char*, const char*);

int main() {
    // Запрос строки и символов у пользователя
    std::string inputString, characters;
    std::cout << "Write bro: ";
    std::getline(std::cin, inputString);
    std::cout << "Enter to find: ";
    std::getline(std::cin, characters);

    // Проверка ввода
    std::cout << "Input string: " << inputString << std::endl;
    std::cout << "Characters to find: " << characters << std::endl;

    // Загрузка библиотеки
    HMODULE hLib = LoadLibrary(TEXT("StringChecker.dll"));
    if (hLib == NULL) {
        std::cerr << "Sorry :( Could not load the DLL." << std::endl;
        return 1;
    }
    std::cout << "DLL loaded successfully." << std::endl;

    // Получение адреса функции
    CheckCharactersFunc checkCharacters = (CheckCharactersFunc)GetProcAddress(hLib, "CheckCharacters");
    if (!checkCharacters) {
        std::cerr << "Sorry :( Could not find the function" << std::endl;
        FreeLibrary(hLib);
        return 1;
    }
    std::cout << "Function address retrieved successfully." << std::endl;

    // Вызов функции
    bool result = checkCharacters(inputString.c_str(), characters.c_str());

    // Вывод результата
    if (result) {
        std::cout << "All characters was find." << std::endl;
    }
    else {
        std::cout << "Sorry :( Charachters is not founded." << std::endl;
    }

    FreeLibrary(hLib);

    while (true) {
        if (_kbhit()) {
            int ch = _getch();
            if (ch == 3) {
                break;
            }
        }
    }

    return 0;
}