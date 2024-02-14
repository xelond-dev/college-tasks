package dev.xelond;

import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Ваш вес (кг.) - ");
        float weight = scanner.nextFloat();

        System.out.print("Ваш рост (м.) - ");
        float height = scanner.nextFloat();

        System.out.print("Сколько вам лет? - ");
        int age = scanner.nextInt();

        float IMT = getIMT(weight, height);
        float idealWeight = getIdealWeight(height);
        float BMR = getBMR(weight, height, age);

        if (IMT > 24.9) {
            System.out.println("\nРекомендуется снизить вес для достижения идеального веса.");
            System.out.println("Идеальный вес: " + idealWeight + " кг.");
            System.out.println("Необходимо сбросить: " + (weight - idealWeight) + " кг.");
            System.out.println("Рекомендуемый дневной прием калорий: " + BMR);
        } else if (IMT < 18.5) {
            System.out.println("\nРекомендуется увеличить потребление пищи для набора веса.");
            System.out.println("Идеальный вес: " + idealWeight + " кг.");
            System.out.println("Необходимо набрать: " + (idealWeight - weight) + " кг.");
            System.out.println("Рекомендуемый дневной прием калорий: " + BMR);
        } else {
            System.out.println("\nВаш вес находится в пределах нормы.");
        }
    }

    private static float getIMT(float weight, float height) {
        return weight / (height * 2);
    }

    private static float getIdealWeight(float height) {
        return (float) (24.9 * height * 2);
    }

    private static float getBMR(float weight, float height, int age) {
        return (float) (88.36 + (13.4 * weight) + (4.8 * height) - (5.7 * age));
    }
}