#include <iostream>

int main()
{
    float a = 20;
    float b = 10;

    float* prt_a = &a;
    float* prt_b = &b;

    if (*prt_a > *prt_b) {
        *prt_a += 7;
        *prt_b -= 3;
    }
    else if (*prt_a < *prt_b) {
        *prt_b += 7;
        *prt_a -= 3;
    }
    else {
        std::cout << "Числа одинаковы." << std::endl;
    }

    std::cout << "a: " << *prt_a << "\nb: " << *prt_b << std::endl;
}
