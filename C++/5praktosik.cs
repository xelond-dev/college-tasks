#include <iostream>
#include <string>
#include <Windows.h>

using namespace std;

class BankAccount {

private:
    int NumberOfAccount;
    double Balance;
    double Rate;
public:
    BankAccount(int accNum, double initialBalance) : NumberOfAccount(accNum), Balance(initialBalance), Rate(0) {
        setlocale(LC_ALL, "Russian");
        if (initialBalance < 0) {
            throw invalid_argument("Баланс не может быть меньше 0.");
        }
    }

    void deposit(double amount) {
        setlocale(LC_ALL, "Russian");
        if (amount <= 0) {
            throw invalid_argument("Сумма ведена неверно.");
        }
        Balance += amount;
        cout << "Перевод выполнен! Остаток на счете: " << Balance << endl;
    }

    void withdraw(double amount) {
        setlocale(LC_ALL, "Russian");
        if (amount <= 10) {
            throw invalid_argument("Сумма для снятия не может быть меньше или равна 10 рублей.");
        }
        if (amount > Balance) {
            throw invalid_argument("Недостаточно средств на карте.");
        }
        Balance -= amount;
        cout << "Перевод выполнен. Остаток на счете: " << Balance << endl;
    }

    double getBalance() {
        setlocale(LC_ALL, "Russian");
        return Balance;
    }

    double getInterest() {
        setlocale(LC_ALL, "Russian");
        return Balance * Rate * (1.0 / 12.0);
    }

    void setInterestRate(double rate) {
        setlocale(LC_ALL, "Russian");
        Rate = rate;
    }

    int getAccountNumber() {
        setlocale(LC_ALL, "Russian");
        return NumberOfAccount;
    }

    friend bool transfer(BankAccount& from, BankAccount& to, double amount) {
        setlocale(LC_ALL, "Russian");
        try {
            from.withdraw(amount);
            to.deposit(amount);
            return true;
        }
        catch (const invalid_argument& e) {
            cerr << "Ошибка перевода - " << e.what() << endl;
            return false;
        }
    }
};

int main() {
    setlocale(LC_ALL, "RUS");
    try {
        BankAccount account1(1, 0);
        BankAccount account2(2, 0);

        int choice;
        double amount;
        bool success;
        setlocale(LC_ALL, "Russian");

        while (true) {
            cout << "Выберите действие:\n"
                "1. Пополнить счет\n"
                "2. Снять деньги\n"
                "3. Изменить процентную ставку\n"
                "4. Перевод\n"
                "5. Узнать текущую процентную ставку\n"
                "6. Получить номер банковского счета\n"
                "7. Выход из программы\n";
            cin >> choice;

            switch (choice) {
            case 1:
                cout << "Введите сумму пополнения: ";
                cin >> amount;
                account1.deposit(amount);
                break;
            case 2:
                cout << "Введите сумму для снятия: ";
                cin >> amount;
                account1.withdraw(amount);
                break;
            case 3:
                cout << "Введите новую процентную ставку: ";
                cin >> amount;
                account1.setInterestRate(amount);
                break;
            case 4:
                cout << "Перевод между счетами\n";
                cout << "Введите сумму для перевода: ";
                cin >> amount;
                success = transfer(account1, account2, amount);
                if (success) {
                    cout << "Перевод выполнен успешно." << endl;
                }
                break;
            case 5:
                cout << "Текущая процентная ставка: " << account1.getInterest() << "%" << endl;
                break;
            case 6:
                cout << "Номер банковского счета: " << account1.getAccountNumber() << endl;
                break;
            case 7:
                cout << "Выход из программы." << endl;
                return 0;
            default:
                cout << "Ошибка: Неверный выбор. Выберите действие из списка." << endl;
            }
        }
    }
    catch (const invalid_argument& e) {
        cerr << "Ошибка: " << e.what() << endl;
    }


    return 0;
}
