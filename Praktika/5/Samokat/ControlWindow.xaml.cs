using Samokat.SamokatDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Samokat
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class ControlWindow : Window
    {
        public ControlWindow(List<SamokatDataSet.EmployeesRow> EmployeeInfo)
        {
            InitializeComponent();

            List<string> tables = new List<string> { };

            for (int i = 1; i <= EmployeeInfo[0].ID_Position; i++)
            {
                switch (i)
                {
                    case 1:
                        tables = tables.Concat(new List<string> { "Адреса", "Категории Товаров", "Статусы Заказов", "Заказы", "Контекст Заказов", "Чеки" }).ToList();
                        Create_User_Employee_Button.Visibility = Visibility.Hidden;
                        break;

                    case 2:
                        tables = tables.Concat(new List<string> { "Методы Оплаты", "Бренды Товаров", "Товары", "Отзывы О Доставщиках" }).ToList();
                        Create_User_Employee_Button.Visibility = Visibility.Hidden;
                        break;

                    case 3:
                        tables = tables.Concat(new List<string> { "Пользователи", "Должности Сотрудников", "Сотрудники" }).ToList();
                        Create_User_Employee_Button.Visibility = Visibility.Visible;
                        break;
                }
            }

            Tables_Combobox.ItemsSource = tables;

            //List<string> tables = new List<string> { "Табличка", "Табличка2" };
            //Tables_Combobox.ItemsSource = new List<string> { "Методы Оплаты", "Пользователи", "Адреса", "Категории Товаров", "Бренды Товаров", "Товары", "Отзывы О Товарах", "Статусы Заказов", "Должности Сотрудников", "Сотрудники", "Заказы", "Контекст Заказов", "Отзывы О Доставщиках", "Покупочные Квитанции" };

            
        }

        private void ViewTable_ClickEvent(object sender, RoutedEventArgs e)
        {
            if (Tables_Combobox.SelectedItem != null)
            {
                TableView tableViewer = new TableView(Tables_Combobox.Items[Tables_Combobox.SelectedIndex].ToString());
                tableViewer.Show();
            }
        }

        private void Tables_Combobox_ChangeEvent(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Create_User_Employee_Button_ClickEvent(object sender, RoutedEventArgs e)
        {
            Create_User_Employee_Window create_User_Employee_Window = new Create_User_Employee_Window();
            create_User_Employee_Window.ShowDialog();
        }

        private void Logout_Button_Event(object sender, RoutedEventArgs e)
        {
            InitializationWindow initializationWindow = new InitializationWindow();
            initializationWindow.Show();
            Close();
        }

    }
}
