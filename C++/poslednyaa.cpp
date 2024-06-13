#include <iostream>
#include <vector>
#include <thread>

class MergeSorter {
public:
    void Execute(std::vector<int>& data) {
        if (data.size() > 1) {
            std::vector<int> leftPart(data.begin(), data.begin() + data.size() / 2);
            std::vector<int> rightPart(data.begin() + data.size() / 2, data.end());

            std::thread leftThread(&MergeSorter::Execute, this, std::ref(leftPart));
            std::thread rightThread(&MergeSorter::Execute, this, std::ref(rightPart));

            leftThread.join();
            rightThread.join();

            Combine(data, leftPart, rightPart);
        }
    }

private:
    void Combine(std::vector<int>& data, const std::vector<int>& leftPart, const std::vector<int>& rightPart) {
        size_t leftIndex = 0, rightIndex = 0, mergeIndex = 0;

        while (leftIndex < leftPart.size() && rightIndex < rightPart.size()) {
            if (leftPart[leftIndex] < rightPart[rightIndex]) {
                data[mergeIndex++] = leftPart[leftIndex++];
            } else {
                data[mergeIndex++] = rightPart[rightIndex++];
            }
        }

        while (leftIndex < leftPart.size()) {
            data[mergeIndex++] = leftPart[leftIndex++];
        }

        while (rightIndex < rightPart.size()) {
            data[mergeIndex++] = rightPart[rightIndex++];
        }
    }
};

std::vector<int> getUserInput(int size) {
    std::vector<int> data(size);
    std::cout << "Введите " << size << " чисел, пожалуйста:" << std::endl;
    for (int& num : data) {
        std::cin >> num;
    }
    return data;
}

void displayArray(const std::vector<int>& data) {
    for (const int& num : data) {
        std::cout << num << " ";
    }
    std::cout << std::endl;
}

int main() {
    std::vector<int> data = getUserInput(10);

    MergeSorter mergeSorter;

    auto executeSort = [&mergeSorter](std::vector<int>& arr) {
        mergeSorter.Execute(arr);
    };

    std::thread sortThread(executeSort, std::ref(data));

    sortThread.join();

    std::cout << "Отсортированный массив:" << std::endl;
    displayArray(data);

    return 0;
}
