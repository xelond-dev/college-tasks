using MaterialDesignThemes.Wpf;
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
    /// Логика взаимодействия для Create_User_Employee_Window.xaml
    /// </summary>
    public partial class Create_User_Employee_Window : Window
    {
        private static Payment_MethodsTableAdapter payment_MethodsTableAdapter = new Payment_MethodsTableAdapter();
        private static Employee_PositionsTableAdapter employee_PositionsTable = new Employee_PositionsTableAdapter();

        private static UsersTableAdapter usersTableAdapter = new UsersTableAdapter();
        private static EmployeesTableAdapter employeesTableAdapter = new EmployeesTableAdapter();

        public Create_User_Employee_Window()
        {
            InitializeComponent();

            Type_Of_ComboBox.ItemsSource = new List<string> { "Пользователь", "Сотрудник" };
            Type_Of_ComboBox.SelectedIndex = 0;

            Priority_Payment_Method_ComboBox.ItemsSource = payment_MethodsTableAdapter.GetData();
            Priority_Payment_Method_ComboBox.DisplayMemberPath = "Payment_Method";

            Position_ComboBox.ItemsSource = employee_PositionsTable.GetData();
            Position_ComboBox.DisplayMemberPath = "Position";

        }

        private void Type_Of_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (Type_Of_ComboBox.SelectedIndex)
            {
                case 0:
                    LastName_TextBox.IsEnabled = false;
                    MiddleName_TextBox.IsEnabled = false;
                    Position_ComboBox.IsEnabled = false;
                    Age_TextBox.IsEnabled = false;
                    Experience_TextBox.IsEnabled = false;

                    Priority_Payment_Method_ComboBox.IsEnabled = true;

                    break;

                case 1:
                    LastName_TextBox.IsEnabled = true;
                    MiddleName_TextBox.IsEnabled = true;
                    Position_ComboBox.IsEnabled = true;
                    Age_TextBox.IsEnabled = true;
                    Experience_TextBox.IsEnabled = true;

                    Priority_Payment_Method_ComboBox.IsEnabled = false;
                    break;
            }
        }

        private void Create_User_Employee_Button_ClickEvent(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (Type_Of_ComboBox.SelectedIndex)
                {
                    case 0:
                        usersTableAdapter.CreateUser(FirstName_TextBox.Text, Username_TextBox.Text, Security.GetHashString(Password_PasswordBox.Password), Priority_Payment_Method_ComboBox.SelectedIndex + 1);
                        break;

                    case 1:
                        employeesTableAdapter.CreateEmployee(LastName_TextBox.Text, FirstName_TextBox.Text, MiddleName_TextBox.Text, Username_TextBox.Text, Security.GetHashString(Password_PasswordBox.Password), Position_ComboBox.SelectedIndex + 1, Convert.ToInt32(Age_TextBox.Text), Convert.ToInt32(Experience_TextBox.Text));
                        break;
                }

                DialogWindow dialogWindow = new DialogWindow("Успешное создание пользователя", Type_Of_ComboBox.Items[Type_Of_ComboBox.SelectedIndex] + " '" + LastName_TextBox.Text + "' успешно создан.");
                dialogWindow.ShowDialog();
            } catch (System.Data.SqlClient.SqlException)
            {
                DialogWindow dialogWindow = new DialogWindow("Ошибка добавление данных", "Хотя бы одно или несколько полей не имеют значений.");
                dialogWindow.ShowDialog();
            }
            catch (System.FormatException)
            {
                DialogWindow dialogWindow = new DialogWindow("Ошибка добавление данных", "Хотя бы одно или несколько полей не имеют значений.");
                dialogWindow.ShowDialog();
            }
        }

        private void Close_Button_Event(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
