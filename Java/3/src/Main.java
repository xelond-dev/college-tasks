import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        while (true) {
            System.out.println("Введите строку:");
            String stroka = scanner.nextLine();
            stroka = stroka.replaceAll("\\s+", "").toLowerCase();
            String reversedStroka = "";

            for (int i = stroka.length() - 1; i >= 0; i--) {
                reversedStroka += (stroka.charAt(i));
            }

            if (stroka.equals(reversedStroka)) {
                System.out.println("Введенная строка является палиндромом.");
            } else {
                System.out.println("Введенная строка не является палиндромом.");
            }
        }
    }
}