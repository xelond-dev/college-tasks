using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using KFC.KFCDataSetTableAdapters;

namespace KFC
{
    public partial class DataSetWindow : Window
    {
        private int selectedTable = 0;
        private int amountOftbxs = 0;

        private OrdersTableAdapter ordersTableAdapter = new OrdersTableAdapter();
        private ProductSellingTableAdapter productSellingAdapter = new ProductSellingTableAdapter();
        private ProductsTableAdapter productsTableAdapter = new ProductsTableAdapter();
        private Payment_MethodsTableAdapter payment_MethodsTableAdapter = new Payment_MethodsTableAdapter();

        private View_OrdersTableAdapter orders = new View_OrdersTableAdapter();
        private View_ProductSellingTableAdapter productSelling = new View_ProductSellingTableAdapter();
        private View_ProductsTableAdapter products = new View_ProductsTableAdapter();
        private View_Payment_MethodsTableAdapter paymentMethods = new View_Payment_MethodsTableAdapter();
        public DataSetWindow()
        {
            InitializeComponent();

            List<string> tables = new List<string>() { "Заказы", "Товары", "Проданные продукты", "Способы оплаты" };
            CurrentTableCbx.ItemsSource = tables;
            CurrentTableCbx.SelectedIndex = 0;

            OrdersGrd.ItemsSource = orders.GetData();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (selectedTable < CurrentTableCbx.Items.Count - 1)
            {
                selectedTable++;
                CurrentTableCbx.SelectedIndex = selectedTable;
            }
            else if (selectedTable == CurrentTableCbx.Items.Count - 1)
            {
                selectedTable = 0;
                CurrentTableCbx.SelectedIndex = 0;
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (selectedTable != 0)
            {
                selectedTable--;
                CurrentTableCbx.SelectedIndex = selectedTable;
            }
            else
            {
                selectedTable = 3;
                CurrentTableCbx.SelectedIndex = 3;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedCbx = CurrentTableCbx.Items[CurrentTableCbx.SelectedIndex] as string;

            switch (selectedCbx)
            {
                case "Заказы":
                    OrdersGrd.ItemsSource = orders.GetData();
                    selectedTable = 0;

                    amountOftbxs = 3;
                    switchFieldsStatus(3);
                    break;

                case "Товары":
                    OrdersGrd.ItemsSource = products.GetData();
                    selectedTable = 1;

                    amountOftbxs = 3;
                    switchFieldsStatus(3);
                    break;

                case "Проданные продукты":
                    OrdersGrd.ItemsSource = productSelling.GetData();
                    selectedTable = 2;

                    amountOftbxs = 2;
                    switchFieldsStatus(2);
                    break;

                case "Способы оплаты":
                    OrdersGrd.ItemsSource = paymentMethods.GetData();
                    selectedTable = 3;

                    amountOftbxs = 1;
                    switchFieldsStatus(1);
                    break;
            }
        }

        private void To_EF_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            string selectedCbx = CurrentTableCbx.Items[CurrentTableCbx.SelectedIndex] as string;

            if (selectedCbx == "Заказы" && tbx1.Text != null && tbx2.Text != null)
            {
                ordersTableAdapter.InsertQuery(Convert.ToInt16(tbx1.Text), tbx2.Text);
                OrdersGrd.ItemsSource = ordersTableAdapter.GetData();
            }
            else if (selectedCbx == "Товары" && tbx1.Text != null && tbx2.Text != null && tbx3.Text != null)
            {
                productSellingAdapter.InsertQuery(Convert.ToInt16(tbx1.Text), Convert.ToInt16(tbx2.Text));
                OrdersGrd.ItemsSource = productSellingAdapter.GetData();
            } 
            else if (selectedCbx == "Продажа продукта" && tbx1.Text != null && tbx2.Text != null)
            {
                productsTableAdapter.InsertQuery(tbx1.Text, Convert.ToInt16(tbx2.Text), Convert.ToInt16(tbx3.Text));
                OrdersGrd.ItemsSource = productsTableAdapter.GetData();
            } 
            else if (selectedCbx == "Способы оплаты" && tbx1.Text != null)
            {
                payment_MethodsTableAdapter.InsertQuery(tbx1.Text);
                OrdersGrd.ItemsSource = paymentMethods.GetData();
            }
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveButtonClick(object sender, RoutedEventArgs e)
        {
            string selectedCbx = CurrentTableCbx.Items[CurrentTableCbx.SelectedIndex] as string;

            if (OrdersGrd.SelectedItem != null)
            {
                object id = (OrdersGrd.SelectedItem as DataRowView).Row[0];

                if (selectedCbx == "Заказы")
                {
                    ordersTableAdapter.DeleteQuery(Convert.ToInt32(id));

                    OrdersGrd.ItemsSource = orders.GetData();
                }
                else if (selectedCbx == "Товары")
                {
                    productsTableAdapter.DeleteQuery(Convert.ToInt32(id));

                    OrdersGrd.ItemsSource = products.GetData();
                }
                else if (selectedCbx == "Продажа продукта")
                {
                    productSellingAdapter.DeleteQuery(Convert.ToInt32(id));

                    OrdersGrd.ItemsSource = productSelling.GetData();
                }
                else if (selectedCbx == "Способы оплаты")
                {
                    payment_MethodsTableAdapter.DeleteQuery(Convert.ToInt32(id));

                    OrdersGrd.ItemsSource = paymentMethods.GetData();
                }
            }
        }

        private void switchFieldsStatus(int tbxsAmount)
        {
            tbx1.IsEnabled = false;
            tbx2.IsEnabled = false;
            tbx3.IsEnabled = false;

            switch (tbxsAmount)
            {
                case 1:
                    tbx1.IsEnabled = true;
                    break;
                case 2:
                    tbx1.IsEnabled = true;
                    tbx2.IsEnabled = true;
                    break;
                case 3:
                    tbx1.IsEnabled = true;
                    tbx2.IsEnabled = true;
                    tbx3.IsEnabled = true;
                    break;
            }

            /*List<TextBox> tbxs = new List<TextBox>() { tbx1, tbx2, tbx3 };

            // Disable tbxs
            for (int i = 0; i < 3; i++)
            {
                tbxs[i].IsEnabled = false;
            }

            // Enable needed tbxs
            for (int i  = 0; i < tbxsAmount || i < 3; i++)
            {
                tbxs[i].IsEnabled = true;
            }*/
        }

        private void Orders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
