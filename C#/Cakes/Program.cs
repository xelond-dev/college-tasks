using System.Runtime.InteropServices;

namespace Cakes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Cake newCake = new Cake();
            int orderNumber = 10200;
            int price = 0;                

            while (true)
            {
                // Change price
                price = 0;
                switch (newCake.form)
                {
                    case "Круглый": price += 500; break;
                    case "Квадрат": price += 1000; break;
                    case "Ромб": price += 1500; break;
                    case "Треугольник": price += 3000; break;
                    case "Октаидр": price += 429434; break;
                }

                switch (newCake.size)
                {
                    case "Маленький": price += 1000; break;
                    case "Средний": price += 3000; break;
                    case "Большой": price += 5500; break;
                }

                switch (newCake.taste)
                {
                    case "Клубничный": price += 3000; break;
                    case "Ванильный": price += 3000; break;
                    case "Шоколадный": price += 3500; break;
                }

                switch (newCake.glaze)
                {
                    case "Черная": price += 2000; break;
                    case "Белая": price += 2500; break;
                    case "Молочная": price += 3500; break;
                }

                switch (newCake.decor)
                {
                    case "Звезды": price += 2000; break;
                    case "Искры": price += 2000; break;
                    case "Сферы": price += 2500; break;
                    case "Капли": price += 3500; break;
                    case "Золото": price += 8500; break;
                    case "Сложная фигура": price += 10000; break;

                }

                Console.Clear();

                Console.WriteLine("Добро пожаловать на Cakes.ru!\n");
                Console.WriteLine("Давайте создадим ваш новый заказ.\n");
                    
                Console.WriteLine("Заказ №" + orderNumber);
                Console.WriteLine("- - - - - - - - - - - - - -");
                Console.WriteLine("Содержание заказа:");
                Console.WriteLine("[ ] Форма  -  " + newCake.form);
                Console.WriteLine("[ ] Размер  -  " + newCake.size);
                Console.WriteLine("[ ] Вкус  -  " + newCake.taste);
                Console.WriteLine("[ ] Глазурь  -  " + newCake.glaze);
                Console.WriteLine("[ ] Декор  -  " + newCake.decor);
                Console.WriteLine("[ ] Заказать");
                Console.WriteLine("- - - - - - - - - - - - - -");

                Console.WriteLine("\nКоличество: " + newCake.count);
                Console.WriteLine("Итоговая цена: " + price);

                int choice = Menu.Show(6);

                switch (choice)
                {
                    case 1:
                        Console.Clear();

                        Console.WriteLine("Добро пожаловать на Cakes.ru!\n");
                        Console.WriteLine("Давайте создадим ваш новый заказ.\n");

                        Console.WriteLine("Заказ №" + orderNumber);
                        Console.WriteLine("- - - - - - - - - - - - - -");
                        Console.WriteLine("Выберите желаемую форму:");
                        Console.WriteLine("[ ] Круглый - 500 ₽");
                        Console.WriteLine("[ ] Квадрта - 1.000 ₽");
                        Console.WriteLine("[ ] Ромб - 1.500 ₽");
                        Console.WriteLine("[ ] Треугольник - 3.000 ₽");
                        Console.WriteLine("[ ] Октаидр - 429.434 ₽");
                        int formChoice = Menu.Show(5);

                        switch (formChoice)
                        {
                            case 1: newCake.form = "Круглый"; break;
                            case 2: newCake.form = "Квадрат"; break;
                            case 3: newCake.form = "Ромб"; break;
                            case 4: newCake.form = "Треугольник"; break;
                            case 5: newCake.form = "Октаидр"; break;
                        }

                        break;

                    case 2:
                        Console.Clear();

                        Console.WriteLine("Добро пожаловать на Cakes.ru!\n");
                        Console.WriteLine("Давайте создадим ваш новый заказ.\n");

                        Console.WriteLine("Заказ №" + orderNumber);
                        Console.WriteLine("- - - - - - - - - - - - - -");
                        Console.WriteLine("Выберите желаемый размер:");
                        Console.WriteLine("[ ] Маленький - 1.000 ₽");
                        Console.WriteLine("[ ] Средний - 3.000 ₽");
                        Console.WriteLine("[ ] Большой - 5.500 ₽");

                        int sizeChoice = Menu.Show(3);

                        switch (sizeChoice)
                        {
                            case 1: newCake.size = "Маленький"; break;
                            case 2: newCake.size = "Средний"; break;
                            case 3: newCake.size = "Большой"; break;
                        }

                        break;

                    case 3:
                        Console.Clear();

                        Console.WriteLine("Добро пожаловать на Cakes.ru!\n");
                        Console.WriteLine("Давайте создадим ваш новый заказ.\n");

                        Console.WriteLine("Заказ №" + orderNumber);
                        Console.WriteLine("- - - - - - - - - - - - - -");
                        Console.WriteLine("Выберите желаемый размер:");
                        Console.WriteLine("[ ] Клубничный - 3.000 ₽");
                        Console.WriteLine("[ ] Ванильный - 3.000 ₽");
                        Console.WriteLine("[ ] Шоколадный - 3.500 ₽");

                        int tasteChoice = Menu.Show(3);

                        switch (tasteChoice)
                        {
                            case 1: newCake.taste = "Клубничный"; break;
                            case 2: newCake.taste = "Ванильный"; break;
                            case 3: newCake.taste = "Шоколадный"; break;
                        }

                        break;

                    case 4:
                        Console.Clear();

                        Console.WriteLine("Добро пожаловать на Cakes.ru!\n");
                        Console.WriteLine("Давайте создадим ваш новый заказ.\n");

                        Console.WriteLine("Заказ №" + orderNumber);
                        Console.WriteLine("- - - - - - - - - - - - - -");
                        Console.WriteLine("Выберите желаемый размер:");
                        Console.WriteLine("[ ] Черная - 2.000 ₽");
                        Console.WriteLine("[ ] Белая - 2.500 ₽");
                        Console.WriteLine("[ ] Молочная - 3.500 ₽");

                        int glazeChoice = Menu.Show(3);

                        switch (glazeChoice)
                        {
                            case 1: newCake.glaze = "Черная"; break;
                            case 2: newCake.glaze = "Белая"; break;
                            case 3: newCake.glaze = "Молочная"; break;
                        }

                        break;

                    case 5:
                        Console.Clear();

                        Console.WriteLine("Добро пожаловать на Cakes.ru!\n");
                        Console.WriteLine("Давайте создадим ваш новый заказ.\n");

                        Console.WriteLine("Заказ №" + orderNumber);
                        Console.WriteLine("- - - - - - - - - - - - - -");
                        Console.WriteLine("Выберите желаемый размер:");
                        Console.WriteLine("[ ] Звезды - 2.000 ₽");
                        Console.WriteLine("[ ] Искры - 2.000 ₽");
                        Console.WriteLine("[ ] Сферы - 2.500 ₽");
                        Console.WriteLine("[ ] Капли - 3.500 ₽");
                        Console.WriteLine("[ ] Золото - 8.500 ₽");
                        Console.WriteLine("[ ] Сложная фигура - 10.000 ₽");



                        int decorChoice = Menu.Show(6);

                        switch (decorChoice)
                        {
                            case 1: newCake.decor = "Звезды"; break;
                            case 2: newCake.decor = "Искры"; break;
                            case 3: newCake.decor = "Сферы"; break;
                            case 4: newCake.decor = "Капли"; break;
                            case 5: newCake.decor = "Золото"; break;
                            case 6: newCake.decor = "Сложная фигура"; break;
                        }

                        break;

                    case 6:
                        Console.Clear();
                        File.AppendAllText("C:\\Users\\xelond\\Documents\\order_history.txt", "Заказ №" + orderNumber + " от " + DateTime.Now + "\n     Заказ: Форма - " + newCake.form + ", Размер - " + newCake.size + ", Вкус - " + newCake.taste + ", Глазурь - " + newCake.glaze + ", Декор - " + newCake.decor + "\n     Цена: " + price + "\n\n");
                        Console.WriteLine("Заказ №" + orderNumber + " выполнен.");
                        Console.WriteLine("Если вы хотите выполнить заказ еще раз, нажмите Escape.");

                        ConsoleKeyInfo keyReader = Console.ReadKey();
                        if (keyReader.Key == ConsoleKey.Escape)
                        {
                            newCake = new Cake();
                            orderNumber++;
                        }
                        else
                        {
                            System.Environment.Exit(0);
                        }
                    
                        break;
                }

            }
        }
    }
}