package dev.xelond;

import java.io.FileWriter;
import java.io.IOException;
import java.io.Writer;
import java.util.Arrays;
import java.util.Scanner;
import java.util.stream.Stream;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        try (FileWriter writer = new FileWriter("dishes.txt", true)) {
            System.out.print("Введите название блюда: ");
            String dish = scanner.nextLine();

            writer.append("Название блюда - " + dish + "\n");

            System.out.print("Введите ингридиенты через заяпятую, без пробелов: ");
            String[] ingredients = scanner.nextLine().split(",");

            String[] ingredientsWeight = new String[ingredients.length];

            for (int i = 0; i < ingredients.length; i++) {
                System.out.print("Введите количество '" + ingredients[i].replace(" ", "").toLowerCase() + "': ");
                ingredientsWeight[i] = scanner.nextLine();

                writer.append("Количество '" + ingredients[i] + "': " + ingredientsWeight[i] + "\n\n\n");
            }

            writer.flush();
        } catch (IOException e) {
            throw new RuntimeException(e);
        }

    }
}