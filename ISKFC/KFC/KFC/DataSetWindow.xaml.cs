using System;
using System.Collections.Generic;
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

        private View_OrdersTableAdapter orders = new View_OrdersTableAdapter();
        private View_OrdersTableAdapter productSelling = new View_OrdersTableAdapter();
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
                    break;

                case "Товары":
                    OrdersGrd.ItemsSource = products.GetData();
                    selectedTable = 1;
                    break;

                case "Проданные продукты":
                    OrdersGrd.ItemsSource = productSelling.GetData();
                    selectedTable = 2;
                    break;

                case "Способы оплаты":
                    OrdersGrd.ItemsSource = paymentMethods.GetData();
                    selectedTable = 3;
                    break;
            }
        }

        private void To_EF_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void Orders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
