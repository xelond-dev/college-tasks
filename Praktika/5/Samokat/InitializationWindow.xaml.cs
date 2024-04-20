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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Samokat
{
    public partial class InitializationWindow : Window
    {
        private UsersTableAdapter UsersTableAdapter = new UsersTableAdapter();
        private EmployeesTableAdapter EmployeesTableAdapter = new EmployeesTableAdapter();

        private bool EmployeeAuth = false;
        public InitializationWindow()
        {
            InitializeComponent();
        }

        private void Sign_In_Button_Event(object sender, RoutedEventArgs e)
        {
            string username = Username_TextBox.Text;

            if (username != "" && Password_TextBox.Password != "")
            {
                if (EmployeeAuth)
                {
                    int AuthResult = Convert.ToInt16(EmployeesTableAdapter.Auth(username, Security.GetHashString(Password_TextBox.Password)));

                    switch (AuthResult)
                    {
                        case 1:
                            List<SamokatDataSet.EmployeesRow> EmployeeInfo = EmployeesTableAdapter.GetEmployeeInfo(username).ToList();

                            ControlWindow admin = new ControlWindow(EmployeeInfo);
                            admin.Show();
                            Close();
                            break;

                        default:
                            DialogWindow dialogWindow = new DialogWindow("Ошибка авторизации", "Неверное имя пользователя или пароль.");
                            dialogWindow.ShowDialog();
                            break;
                    }
                } else
                {
                    int AuthResult = Convert.ToInt16(UsersTableAdapter.Auth(username, Security.GetHashString(Password_TextBox.Password)));

                    switch (AuthResult)
                    {
                        case 1:
                            List<SamokatDataSet.UsersRow> UserInfo = UsersTableAdapter.GetUserInfo(username).ToList();

                            /*ControlWindow admin = new ControlWindow(UserInfo);
                            admin.Show();
                            Close();*/
                            break;

                        default:
                            DialogWindow dialogWindow = new DialogWindow("Ошибка авторизации", "Неверное имя пользователя или пароль.");
                            dialogWindow.ShowDialog();
                            break;
                    }
                }

            } else
            {
                DialogWindow dialogWindow = new DialogWindow("Ошибка авторизации", "Имя пользователя или пароль не могут быть пустыми.");
                dialogWindow.ShowDialog();
            }
        }

        private void Change_Sign_In_Button_Event(object sender, RoutedEventArgs e)
        {
            switch (EmployeeAuth)
            {
                case true:
                    EmployeeAuth = false;
                    Change_Sign_In_Button.Content = "Войти как сотрудник";
                    break;

                case false:
                    EmployeeAuth = true;
                    Change_Sign_In_Button.Content = "Войти как пользователь";
                    break;
            }
        }
    }
}
