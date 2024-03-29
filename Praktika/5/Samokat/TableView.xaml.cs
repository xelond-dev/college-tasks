using MaterialDesignThemes.Wpf;
using Samokat.SamokatDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class TableView : Window
    {
        public string TableToView;

        // Объявления адаптеров данных
        Payment_MethodsTableAdapter payment_MethodsTableAdapter = new Payment_MethodsTableAdapter();
        UsersTableAdapter usersTableAdapter = new UsersTableAdapter();
        AddressesTableAdapter addressesTableAdapter = new AddressesTableAdapter();
        Product_CategoriesTableAdapter productCategoriesTableAdapter = new Product_CategoriesTableAdapter();
        Product_BrandsTableAdapter productBrandsTableAdapter = new Product_BrandsTableAdapter();
        ProductsTableAdapter productsTableAdapter = new ProductsTableAdapter();
        Product_ReviewsTableAdapter productReviewsTableAdapter = new Product_ReviewsTableAdapter();
        Order_StatusesTableAdapter orderStatusesTableAdapter = new Order_StatusesTableAdapter();
        Employee_PositionsTableAdapter employeePositionsTableAdapter = new Employee_PositionsTableAdapter();
        EmployeesTableAdapter employeesTableAdapter = new EmployeesTableAdapter();
        OrdersTableAdapter ordersTableAdapter = new OrdersTableAdapter();
        Orders_ContextTableAdapter orderContextTableAdapter = new Orders_ContextTableAdapter();
        Deliverer_ReviewsTableAdapter deliveryReviewsTableAdapter = new Deliverer_ReviewsTableAdapter();
        Purchase_ReceiptsTableAdapter purchaseReceiptsTableAdapter = new Purchase_ReceiptsTableAdapter();

        public TableView(string tableToView)
        {
            InitializeComponent();

            TableToView = tableToView;
            UpdateTables();
        }

        public void UpdateTables()
        {
            switch (TableToView)
            {
                case "Методы Оплаты":
                    DataGrd.ItemsSource = payment_MethodsTableAdapter.GetData();

                    tbx1.SetValue(HintAssist.HintProperty, "Способ оплаты");
                    tbx2.Visibility = Visibility.Hidden;
                    tbx3.Visibility = Visibility.Hidden;
                    tbx4.Visibility = Visibility.Hidden;
                    tbx5.Visibility = Visibility.Hidden;
                    tbx6.Visibility = Visibility.Hidden;
                    tbx7.Visibility = Visibility.Hidden;
                    tbx8.Visibility = Visibility.Hidden;

                    cbx1.Visibility = Visibility.Hidden;
                    cbx2.Visibility = Visibility.Hidden;
                    cbx3.Visibility = Visibility.Hidden;
                    cbx4.Visibility = Visibility.Hidden;
                    cbx5.Visibility = Visibility.Hidden;
                    
                    
                    break;
                case "Пользователи":
                    DataGrd.ItemsSource = usersTableAdapter.GetData();

                    tbx1.SetValue(HintAssist.HintProperty, "Логин");
                    tbx2.SetValue(HintAssist.HintProperty, "Пароль");
                    tbx3.SetValue(HintAssist.HintProperty, "Имя");
                    tbx4.Visibility = Visibility.Hidden;
                    tbx5.Visibility = Visibility.Hidden;
                    tbx6.Visibility = Visibility.Hidden;
                    tbx7.Visibility = Visibility.Hidden;
                    tbx8.Visibility = Visibility.Hidden;

                    cbx1.Visibility = Visibility.Hidden;
                    cbx2.Visibility = Visibility.Hidden;
                    cbx3.Visibility = Visibility.Hidden;
                    cbx4.Visibility = Visibility.Hidden;
                    cbx5.Visibility = Visibility.Hidden;
                    
                        
                    break;
                case "Адреса":
                    DataGrd.ItemsSource = addressesTableAdapter.GetData();

                    tbx1.SetValue(HintAssist.HintProperty, "Город");
                    tbx2.SetValue(HintAssist.HintProperty, "Улица");
                    tbx3.SetValue(HintAssist.HintProperty, "Номер дома");
                    tbx4.SetValue(HintAssist.HintProperty, "Подъезд");
                    tbx5.SetValue(HintAssist.HintProperty, "Домофон");
                    tbx6.SetValue(HintAssist.HintProperty, "Этаж");
                    tbx7.SetValue(HintAssist.HintProperty, "Квартира");
                    tbx8.SetValue(HintAssist.HintProperty, "Почтовый индекс");

                    cbx1.Visibility = Visibility.Hidden;
                    cbx2.Visibility = Visibility.Hidden;
                    cbx3.Visibility = Visibility.Hidden;
                    cbx4.Visibility = Visibility.Hidden;
                    cbx5.Visibility = Visibility.Hidden;
                    
                    
                    break;
                case "Категории Товаров":
                    DataGrd.ItemsSource = productCategoriesTableAdapter.GetData();

                    tbx1.SetValue(HintAssist.HintProperty, "Категория товара");
                    tbx2.Visibility = Visibility.Hidden;
                    tbx3.Visibility = Visibility.Hidden;
                    tbx4.Visibility = Visibility.Hidden;
                    tbx5.Visibility = Visibility.Hidden;
                    tbx6.Visibility = Visibility.Hidden;
                    tbx7.Visibility = Visibility.Hidden;
                    tbx8.Visibility = Visibility.Hidden;

                    cbx1.Visibility = Visibility.Hidden;
                    cbx2.Visibility = Visibility.Hidden;
                    cbx3.Visibility = Visibility.Hidden;
                    cbx4.Visibility = Visibility.Hidden;
                    cbx5.Visibility = Visibility.Hidden;
                    
                    
                    break;
                case "Бренды Товаров":
                    DataGrd.ItemsSource = productBrandsTableAdapter.GetData();

                    tbx1.SetValue(HintAssist.HintProperty, "Бренд товара");
                    tbx2.Visibility = Visibility.Hidden;
                    tbx3.Visibility = Visibility.Hidden;
                    tbx4.Visibility = Visibility.Hidden;
                    tbx5.Visibility = Visibility.Hidden;
                    tbx6.Visibility = Visibility.Hidden;
                    tbx7.Visibility = Visibility.Hidden;
                    tbx8.Visibility = Visibility.Hidden;

                    cbx1.Visibility = Visibility.Hidden;
                    cbx2.Visibility = Visibility.Hidden;
                    cbx3.Visibility = Visibility.Hidden;
                    cbx4.Visibility = Visibility.Hidden;
                    cbx5.Visibility = Visibility.Hidden;
                    
                    
                    break;
                case "Товары":
                    DataGrd.ItemsSource = productsTableAdapter.GetData();

                    tbx1.SetValue(HintAssist.HintProperty, "Название продуктов");
                    tbx2.SetValue(HintAssist.HintProperty, "Количество на складе");
                    tbx3.SetValue(HintAssist.HintProperty, "Описание продуктов");
                    tbx4.SetValue(HintAssist.HintProperty, "Цена");
                    tbx5.Visibility = Visibility.Hidden;
                    tbx6.Visibility = Visibility.Hidden;
                    tbx7.Visibility = Visibility.Hidden;
                    tbx8.Visibility = Visibility.Hidden;

                    cbx1.SetValue(HintAssist.HintProperty, "Категория товара");
                    cbx2.SetValue(HintAssist.HintProperty, "Бренд товара");
                    cbx3.Visibility = Visibility.Hidden;
                    cbx4.Visibility = Visibility.Hidden;
                    cbx5.Visibility = Visibility.Hidden;
                    
                    

                    cbx1.ItemsSource = productCategoriesTableAdapter.GetData();
                    cbx1.DisplayMemberPath = "Category_Name";

                    cbx2.ItemsSource = productBrandsTableAdapter.GetData();
                    cbx2.DisplayMemberPath = "Brand_Name";
                    break;
                case "Отзывы О Товарах":
                    DataGrd.ItemsSource = productReviewsTableAdapter.GetData();

                    tbx1.SetValue(HintAssist.HintProperty, "Оценка");
                    tbx2.Visibility = Visibility.Hidden;
                    tbx3.Visibility = Visibility.Hidden;
                    tbx4.Visibility = Visibility.Hidden;
                    tbx5.Visibility = Visibility.Hidden;
                    tbx6.Visibility = Visibility.Hidden;
                    tbx7.Visibility = Visibility.Hidden;
                    tbx8.Visibility = Visibility.Hidden;

                    cbx1.SetValue(HintAssist.HintProperty, "Пользователь");
                    cbx2.SetValue(HintAssist.HintProperty, "Товар");
                    cbx3.Visibility = Visibility.Hidden;
                    cbx4.Visibility = Visibility.Hidden;
                    cbx5.Visibility = Visibility.Hidden;
                    
                    

                    cbx1.ItemsSource = employeesTableAdapter.GetData();
                    cbx1.DisplayMemberPath = "Username";

                    cbx2.ItemsSource = productsTableAdapter.GetData();
                    cbx2.DisplayMemberPath = "Product_Name";
                    break;
                case "Статусы Заказов":
                    DataGrd.ItemsSource = orderStatusesTableAdapter.GetData();

                    tbx1.SetValue(HintAssist.HintProperty, "Статус заказа");
                    tbx2.Visibility = Visibility.Hidden;
                    tbx3.Visibility = Visibility.Hidden;
                    tbx4.Visibility = Visibility.Hidden;
                    tbx5.Visibility = Visibility.Hidden;
                    tbx6.Visibility = Visibility.Hidden;
                    tbx7.Visibility = Visibility.Hidden;
                    tbx8.Visibility = Visibility.Hidden;

                    cbx1.Visibility = Visibility.Hidden;
                    cbx2.Visibility = Visibility.Hidden;
                    cbx3.Visibility = Visibility.Hidden;
                    cbx4.Visibility = Visibility.Hidden;
                    cbx5.Visibility = Visibility.Hidden;
                    
                    
                    break;
                case "Должности Сотрудников":
                    DataGrd.ItemsSource = employeePositionsTableAdapter.GetData();

                    tbx1.SetValue(HintAssist.HintProperty, "Должность");
                    tbx2.Visibility = Visibility.Hidden;
                    tbx3.Visibility = Visibility.Hidden;
                    tbx4.Visibility = Visibility.Hidden;
                    tbx5.Visibility = Visibility.Hidden;
                    tbx6.Visibility = Visibility.Hidden;
                    tbx7.Visibility = Visibility.Hidden;
                    tbx8.Visibility = Visibility.Hidden;

                    cbx1.Visibility = Visibility.Hidden;
                    cbx2.Visibility = Visibility.Hidden;
                    cbx3.Visibility = Visibility.Hidden;
                    cbx4.Visibility = Visibility.Hidden;
                    cbx5.Visibility = Visibility.Hidden;
                    
                    
                    break;
                case "Сотрудники":
                    DataGrd.ItemsSource = employeesTableAdapter.GetData();

                    tbx1.SetValue(HintAssist.HintProperty, "Фамилия");
                    tbx2.SetValue(HintAssist.HintProperty, "Имя");
                    tbx3.SetValue(HintAssist.HintProperty, "Отчество");
                    tbx4.SetValue(HintAssist.HintProperty, "Логин");
                    tbx5.SetValue(HintAssist.HintProperty, "Пароль");
                    tbx6.SetValue(HintAssist.HintProperty, "Возраст");
                    tbx7.SetValue(HintAssist.HintProperty, "Опыт работы");
                    tbx8.Visibility = Visibility.Hidden;


                    cbx1.SetValue(HintAssist.HintProperty, "Должность");
                    cbx2.Visibility = Visibility.Hidden;
                    cbx3.Visibility = Visibility.Hidden;
                    cbx4.Visibility = Visibility.Hidden;
                    cbx5.Visibility = Visibility.Hidden;
                    
                    

                    cbx1.ItemsSource = employeePositionsTableAdapter.GetData();
                    cbx1.DisplayMemberPath = "Position";
                    break;
                case "Заказы":
                    DataGrd.ItemsSource = ordersTableAdapter.GetData();

                    tbx1.SetValue(HintAssist.HintProperty, "Комментарий");
                    tbx2.SetValue(HintAssist.HintProperty, "Итоговая цена");
                    tbx3.SetValue(HintAssist.HintProperty, "Дата");
                    tbx4.Visibility = Visibility.Hidden;
                    tbx5.Visibility = Visibility.Hidden;
                    tbx6.Visibility = Visibility.Hidden;
                    tbx7.Visibility = Visibility.Hidden;
                    tbx8.Visibility = Visibility.Hidden;

                    cbx1.SetValue(HintAssist.HintProperty, "Пользователь");
                    cbx2.SetValue(HintAssist.HintProperty, "Адресс");
                    cbx3.SetValue(HintAssist.HintProperty, "Способ оплаты");
                    cbx4.SetValue(HintAssist.HintProperty, "Статус заказа");
                    cbx5.SetValue(HintAssist.HintProperty, "Курьер");
                    
                    

                    cbx1.ItemsSource = usersTableAdapter.GetData();
                    cbx1.DisplayMemberPath = "Username";

                    cbx2.ItemsSource = addressesTableAdapter.GetData();
                    cbx2.DisplayMemberPath = "City";

                    cbx3.ItemsSource = payment_MethodsTableAdapter.GetData();
                    cbx3.DisplayMemberPath = "Payment_Method";

                    cbx4.ItemsSource = payment_MethodsTableAdapter.GetData();
                    cbx4.DisplayMemberPath = "Payment_Method";

                    cbx5.ItemsSource = employeesTableAdapter.GetDeliverer();
                    cbx5.DisplayMemberPath = "Username";
                    break;
                case "Контекст Заказов":
                    DataGrd.ItemsSource = orderContextTableAdapter.GetData();

                    tbx1.Visibility = Visibility.Hidden;
                    tbx2.Visibility = Visibility.Hidden;
                    tbx3.Visibility = Visibility.Hidden;
                    tbx4.Visibility = Visibility.Hidden;
                    tbx5.Visibility = Visibility.Hidden;
                    tbx6.Visibility = Visibility.Hidden;
                    tbx7.Visibility = Visibility.Hidden;
                    tbx8.Visibility = Visibility.Hidden;

                    cbx1.SetValue(HintAssist.HintProperty, "Номер заказа");
                    cbx2.SetValue(HintAssist.HintProperty, "Товар");
                    cbx3.Visibility = Visibility.Hidden;
                    cbx4.Visibility = Visibility.Hidden;
                    cbx5.Visibility = Visibility.Hidden;
                    
                    

                    cbx1.ItemsSource = ordersTableAdapter.GetData();
                    cbx1.DisplayMemberPath = "ID";

                    cbx2.ItemsSource = productsTableAdapter.GetData();
                    cbx2.DisplayMemberPath = "Product_Name";
                    break;
                case "Отзывы О Доставщиках":
                    DataGrd.ItemsSource = deliveryReviewsTableAdapter.GetData();

                    tbx1.SetValue(HintAssist.HintProperty, "Оценка");
                    tbx2.Visibility = Visibility.Hidden;
                    tbx3.Visibility = Visibility.Hidden;
                    tbx4.Visibility = Visibility.Hidden;
                    tbx5.Visibility = Visibility.Hidden;
                    tbx6.Visibility = Visibility.Hidden;
                    tbx7.Visibility = Visibility.Hidden;
                    tbx8.Visibility = Visibility.Hidden;

                    cbx1.SetValue(HintAssist.HintProperty, "Пользователь");
                    cbx2.SetValue(HintAssist.HintProperty, "Курьер");
                    cbx3.Visibility = Visibility.Hidden;
                    cbx4.Visibility = Visibility.Hidden;
                    cbx5.Visibility = Visibility.Hidden;
                    
                    

                    cbx1.ItemsSource = usersTableAdapter.GetData();
                    cbx1.DisplayMemberPath = "Username";

                    cbx2.ItemsSource = employeesTableAdapter.GetDeliverer();
                    cbx2.DisplayMemberPath = "Username";
                    break;
                case "Чеки":
                    DataGrd.ItemsSource = purchaseReceiptsTableAdapter.GetData();

                    tbx1.SetValue(HintAssist.HintProperty, "Дата");
                    tbx2.Visibility = Visibility.Hidden;
                    tbx3.Visibility = Visibility.Hidden;
                    tbx4.Visibility = Visibility.Hidden;
                    tbx5.Visibility = Visibility.Hidden;
                    tbx6.Visibility = Visibility.Hidden;
                    tbx7.Visibility = Visibility.Hidden;
                    tbx8.Visibility = Visibility.Hidden;

                    cbx1.SetValue(HintAssist.HintProperty, "Номер заказа");
                    cbx2.SetValue(HintAssist.HintProperty, "Способ платежа");
                    cbx3.Visibility = Visibility.Hidden;
                    cbx4.Visibility = Visibility.Hidden;
                    cbx5.Visibility = Visibility.Hidden;
                    
                    

                    cbx1.ItemsSource = ordersTableAdapter.GetData();
                    cbx1.DisplayMemberPath = "ID";

                    cbx2.ItemsSource = payment_MethodsTableAdapter.GetData();
                    cbx2.DisplayMemberPath = "Payment_Method";
                    break;
            }
        }


        private void Add_Button_Event(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (TableToView)
                {
                    case "Методы Оплаты":
                        payment_MethodsTableAdapter.InsertQuery(tbx1.Text);
                        break;
                    case "Пользователи":
                        usersTableAdapter.InsertQuery(tbx1.Text, Security.GetHashString(tbx2.Text), tbx3.Text);
                        break;
                    case "Адреса":
                        addressesTableAdapter.InsertQuery(tbx1.Text, tbx2.Text, Convert.ToInt32(tbx3.Text), Convert.ToInt32(tbx4.Text), tbx5.Text, Convert.ToInt32(tbx6.Text), Convert.ToInt32(tbx7.Text), Convert.ToInt32(tbx8.Text));
                        break;
                    case "Категории Товаров":
                        productCategoriesTableAdapter.InsertQuery(tbx1.Text);
                        break;
                    case "Бренды Товаров":
                        productBrandsTableAdapter.InsertQuery(tbx1.Text);
                        break;
                    case "Товары":
                        productsTableAdapter.InsertQuery(tbx1.Text, cbx1.SelectedIndex + 1, cbx2.SelectedIndex + 1, Convert.ToInt32(tbx2.Text), tbx3.Text, Convert.ToInt32(tbx4.Text));
                        break;
                    case "Отзывы О Товарах":
                        productReviewsTableAdapter.InsertQuery(cbx1.SelectedIndex + 1, cbx2.SelectedIndex + 1, Convert.ToInt32(tbx1.Text));
                        break;
                    case "Статусы Заказов":
                        orderStatusesTableAdapter.InsertQuery(tbx1.Text);
                        break;
                    case "Должности Сотрудников":
                        employeePositionsTableAdapter.InsertQuery(tbx1.Text);
                        break;
                    case "Сотрудники":
                        employeesTableAdapter.InsertQuery(tbx1.Text, tbx2.Text, tbx3.Text, tbx4.Text, Security.GetHashString(tbx5.Text), cbx1.SelectedIndex + 1, Convert.ToInt32(tbx6.Text), Convert.ToInt32(tbx7.Text));
                        break;
                    case "Заказы":
                        ordersTableAdapter.InsertQuery(cbx1.SelectedIndex + 1, cbx2.SelectedIndex + 1, cbx3.SelectedIndex + 1, cbx4.SelectedIndex + 1, tbx1.Text, cbx5.SelectedIndex + 1, Convert.ToInt32(tbx2.Text), DateTime.Now.ToString());
                        break;
                    case "Контекст Заказов":
                        orderContextTableAdapter.InsertQuery(cbx1.SelectedIndex + 1, cbx2.SelectedIndex + 1);
                        break;
                    case "Отзывы О Доставщиках":
                        deliveryReviewsTableAdapter.InsertQuery(cbx1.SelectedIndex + 1, cbx2.SelectedIndex + 1, Convert.ToInt32(tbx1.Text));
                        break;
                    case "Покупочные Квитанции":
                        purchaseReceiptsTableAdapter.InsertQuery(cbx1.SelectedIndex + 1, cbx2.SelectedIndex + 1, DateTime.Now.ToString());
                        break;
                }

                UpdateTables();
            } catch (System.FormatException)
            {
                DialogWindow dialogWindow = new DialogWindow("Ошибка добавление данных", "Хотя бы одно или несколько полей не имеют значений.");
                dialogWindow.ShowDialog();
            }
        }

        private void Edit_Button_Event(object sender, RoutedEventArgs e)
        {
            if (DataGrd.SelectedItem != null)
            {
                int id = Convert.ToInt32((DataGrd.SelectedItem as DataRowView).Row[0]);

                try
                {

                    switch (TableToView)
                    {
                        case "Методы Оплаты":
                            payment_MethodsTableAdapter.UpdateQuery(tbx1.Text, id);
                            break;
                        case "Пользователи":
                            usersTableAdapter.UpdateQuery(tbx1.Text, Security.GetHashString(tbx2.Text), tbx3.Text, id);
                            break;
                        case "Адреса":
                            addressesTableAdapter.UpdateQuery(tbx1.Text, tbx2.Text, Convert.ToInt32(tbx3.Text), Convert.ToInt32(tbx4.Text), tbx5.Text, Convert.ToInt32(tbx6.Text), Convert.ToInt32(tbx7.Text), Convert.ToInt32(tbx8.Text), id);
                            break;
                        case "Категории Товаров":
                            productCategoriesTableAdapter.UpdateQuery(tbx1.Text, id);
                            break;
                        case "Бренды Товаров":
                            productBrandsTableAdapter.UpdateQuery(tbx1.Text, id);
                            break;
                        case "Товары":
                            productsTableAdapter.UpdateQuery(tbx1.Text, cbx1.SelectedIndex + 1, cbx2.SelectedIndex + 1, Convert.ToInt32(tbx2.Text), tbx3.Text, Convert.ToInt32(tbx4.Text), id);
                            break;
                        case "Отзывы О Товарах":
                            productReviewsTableAdapter.UpdateQuery(cbx1.SelectedIndex + 1, cbx2.SelectedIndex + 1, Convert.ToInt32(tbx1.Text), id);
                            break;
                        case "Статусы Заказов":
                            orderStatusesTableAdapter.UpdateQuery(tbx1.Text, id);
                            break;
                        case "Должности Сотрудников":
                            employeePositionsTableAdapter.UpdateQuery(tbx1.Text, id);
                            break;
                        case "Сотрудники":
                            employeesTableAdapter.UpdateQuery(tbx1.Text, tbx2.Text, tbx3.Text, tbx4.Text, Security.GetHashString(tbx5.Text), cbx1.SelectedIndex + 1, Convert.ToInt32(tbx6.Text), Convert.ToInt32(tbx7.Text), id);
                            break;
                        case "Заказы":
                            ordersTableAdapter.UpdateQuery(cbx1.SelectedIndex + 1, cbx2.SelectedIndex + 1, cbx3.SelectedIndex + 1, cbx4.SelectedIndex + 1, tbx1.Text, cbx5.SelectedIndex + 1, Convert.ToInt32(tbx2.Text), DateTime.Now.ToString(), id);
                            break;
                        case "Контекст Заказов":
                            orderContextTableAdapter.UpdateQuery(cbx1.SelectedIndex + 1, cbx2.SelectedIndex + 1, id);
                            break;
                        case "Отзывы О Доставщиках":
                            deliveryReviewsTableAdapter.UpdateQuery(cbx1.SelectedIndex + 1, cbx2.SelectedIndex + 1, Convert.ToInt32(tbx1.Text), id);
                            break;
                        case "Покупочные Квитанции":
                            purchaseReceiptsTableAdapter.UpdateQuery(cbx1.SelectedIndex + 1, cbx2.SelectedIndex + 1, DateTime.Now.ToString(), id);
                            break;
                    }


                    UpdateTables();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    DialogWindow dialogWindow = new DialogWindow("Ошибка изменения данных", "Хотя бы одно или несколько полей не имеют значений.");
                    dialogWindow.ShowDialog();
                }
            }
        }

        private void Remove_Button_Event(object sender, RoutedEventArgs e)
        {
            if (DataGrd.SelectedItem != null)
            {
                int id = Convert.ToInt32((DataGrd.SelectedItem as DataRowView).Row[0]);

                switch (TableToView)
                {
                    case "Методы Оплаты":
                        payment_MethodsTableAdapter.DeleteQuery(id);
                        break;
                    case "Пользователи":
                        usersTableAdapter.DeleteQuery(id);
                        break;
                    case "Адреса":
                        addressesTableAdapter.DeleteQuery(id);
                        break;
                    case "Категории Товаров":
                        productCategoriesTableAdapter.DeleteQuery(id);
                        break;
                    case "Бренды Товаров":
                        productBrandsTableAdapter.DeleteQuery(id);
                        break;
                    case "Товары":
                        productsTableAdapter.DeleteQuery(id);
                        break;
                    case "Отзывы О Товарах":
                        productReviewsTableAdapter.DeleteQuery(id);
                        break;
                    case "Статусы Заказов":
                        orderStatusesTableAdapter.DeleteQuery(id);
                        break;
                    case "Должности Сотрудников":
                        employeePositionsTableAdapter.DeleteQuery(id);
                        break;
                    case "Сотрудники":
                        employeesTableAdapter.DeleteQuery(id);
                        break;
                    case "Заказы":
                        ordersTableAdapter.DeleteQuery(id);
                        break;
                    case "Контекст Заказов":
                        orderContextTableAdapter.DeleteQuery(id);
                        break;
                    case "Отзывы О Доставщиках":
                        deliveryReviewsTableAdapter.DeleteQuery(id);
                        break;
                    case "Покупочные Квитанции":
                        purchaseReceiptsTableAdapter.DeleteQuery(id);
                        break;
                }

                UpdateTables();
            } else
            {
                DialogWindow dialogWindow = new DialogWindow("Ошибка удаление данных", "Для начала выберите поле.");
                dialogWindow.ShowDialog();
            }
        }

        private void DataGrd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrd.SelectedItem != null)
            {
                try
                {
                    switch (TableToView)
                    {
                        case "Методы Оплаты":
                            tbx1.Text = (DataGrd.SelectedItem as DataRowView).Row[1].ToString();
                            break;
                        case "Пользователи":
                            tbx1.Text = (DataGrd.SelectedItem as DataRowView).Row[1].ToString();
                            tbx3.Text = (DataGrd.SelectedItem as DataRowView).Row[3].ToString();
                            break;
                        case "Адреса":
                            tbx1.Text = (DataGrd.SelectedItem as DataRowView).Row[1].ToString();
                            tbx2.Text = (DataGrd.SelectedItem as DataRowView).Row[2].ToString();
                            tbx3.Text = (DataGrd.SelectedItem as DataRowView).Row[3].ToString();
                            tbx4.Text = (DataGrd.SelectedItem as DataRowView).Row[4].ToString();
                            tbx5.Text = (DataGrd.SelectedItem as DataRowView).Row[5].ToString();
                            tbx6.Text = (DataGrd.SelectedItem as DataRowView).Row[6].ToString();
                            tbx7.Text = (DataGrd.SelectedItem as DataRowView).Row[7].ToString();
                            tbx8.Text = (DataGrd.SelectedItem as DataRowView).Row[8].ToString();
                            break;
                        case "Категории Товаров":
                            tbx1.Text = (DataGrd.SelectedItem as DataRowView).Row[1].ToString();
                            break;
                        case "Бренды Товаров":
                            tbx1.Text = (DataGrd.SelectedItem as DataRowView).Row[1].ToString();
                            break;
                        case "Товары":
                            tbx1.Text = (DataGrd.SelectedItem as DataRowView).Row[1].ToString();
                            tbx2.Text = (DataGrd.SelectedItem as DataRowView).Row[4].ToString();
                            tbx3.Text = (DataGrd.SelectedItem as DataRowView).Row[5].ToString();
                            tbx4.Text = (DataGrd.SelectedItem as DataRowView).Row[6].ToString();

                            cbx1.SelectedIndex = Convert.ToInt32((DataGrd.SelectedItem as DataRowView).Row[2]);
                            cbx1.SelectedIndex = Convert.ToInt32((DataGrd.SelectedItem as DataRowView).Row[3]);
                            break;
                        case "Отзывы О Товарах":
                            tbx1.Text = (DataGrd.SelectedItem as DataRowView).Row[3].ToString();

                            cbx1.SelectedIndex = Convert.ToInt32((DataGrd.SelectedItem as DataRowView).Row[1]);
                            cbx1.SelectedIndex = Convert.ToInt32((DataGrd.SelectedItem as DataRowView).Row[2]);

                            break;
                        case "Статусы Заказов":
                            tbx1.Text = (DataGrd.SelectedItem as DataRowView).Row[1].ToString();
                            break;
                        case "Должности Сотрудников":
                            tbx1.Text = (DataGrd.SelectedItem as DataRowView).Row[1].ToString();
                            break;
                        case "Сотрудники":
                            tbx1.Text = (DataGrd.SelectedItem as DataRowView).Row[1].ToString();
                            tbx2.Text = (DataGrd.SelectedItem as DataRowView).Row[2].ToString();
                            tbx3.Text = (DataGrd.SelectedItem as DataRowView).Row[3].ToString();
                            tbx4.Text = (DataGrd.SelectedItem as DataRowView).Row[4].ToString();
                            tbx5.Text = (DataGrd.SelectedItem as DataRowView).Row[7].ToString();
                            tbx6.Text = (DataGrd.SelectedItem as DataRowView).Row[8].ToString();

                            cbx1.SelectedIndex = Convert.ToInt32((DataGrd.SelectedItem as DataRowView).Row[6]);
                            break;
                        case "Заказы":
                            tbx1.Text = (DataGrd.SelectedItem as DataRowView).Row[5].ToString();
                            tbx2.Text = (DataGrd.SelectedItem as DataRowView).Row[7].ToString();
                            tbx3.Text = (DataGrd.SelectedItem as DataRowView).Row[8].ToString();

                            cbx1.SelectedIndex = Convert.ToInt32((DataGrd.SelectedItem as DataRowView).Row[1]);
                            cbx2.SelectedIndex = Convert.ToInt32((DataGrd.SelectedItem as DataRowView).Row[2]);
                            cbx3.SelectedIndex = Convert.ToInt32((DataGrd.SelectedItem as DataRowView).Row[3]);
                            cbx4.SelectedIndex = Convert.ToInt32((DataGrd.SelectedItem as DataRowView).Row[4]);
                            cbx5.SelectedIndex = Convert.ToInt32((DataGrd.SelectedItem as DataRowView).Row[6]);
                            break;
                        case "Контекст Заказов":
                            cbx1.SelectedIndex = Convert.ToInt32((DataGrd.SelectedItem as DataRowView).Row[1]);
                            cbx2.SelectedIndex = Convert.ToInt32((DataGrd.SelectedItem as DataRowView).Row[2]);
                            break;
                        case "Отзывы О Доставщиках":
                            tbx1.Text = (DataGrd.SelectedItem as DataRowView).Row[3].ToString();

                            cbx1.SelectedIndex = Convert.ToInt32((DataGrd.SelectedItem as DataRowView).Row[1]);
                            cbx1.SelectedIndex = Convert.ToInt32((DataGrd.SelectedItem as DataRowView).Row[2]);
                            break;
                        case "Чеки":
                            tbx1.Text = (DataGrd.SelectedItem as DataRowView).Row[3].ToString();

                            cbx1.SelectedIndex = Convert.ToInt32((DataGrd.SelectedItem as DataRowView).Row[1]);
                            cbx1.SelectedIndex = Convert.ToInt32((DataGrd.SelectedItem as DataRowView).Row[2]);
                            break;
                    }
                } catch (System.NullReferenceException) { }
            }
        }

        private void Text_PreviewTextInput(object sender, RoutedEventArgs e)
        {
            // я попытался

            TextBox textBox = (TextBox)sender;
            //string selectedSwitchItem = (string)Switch.SelectedItem;
            //string inputText = e.Text;  
        }

        private void Close_Button_Event(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
