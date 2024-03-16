using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Documents.DocumentStructures;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KFC
{
    public partial class MainWindow : Window
    {

        private int selectedTable = 0;

        private KFCEntities context = new KFCEntities();
        public MainWindow()
        {
            InitializeComponent();

            List<string> tables = new List<string>() { "Заказы", "Товары", "Проданные продукты", "Способы оплаты" };
            CurrentTableCbx.ItemsSource = tables;
            CurrentTableCbx.SelectedIndex = 0;
            
            OrdersGrd.ItemsSource = context.View_Orders.ToList();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (selectedTable < CurrentTableCbx.Items.Count - 1)
            {
                selectedTable++;
                CurrentTableCbx.SelectedIndex = selectedTable;
            } else if (selectedTable == CurrentTableCbx.Items.Count - 1)
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
                    OrdersGrd.ItemsSource = context.View_Orders.ToList();
                    selectedTable = 0;
                    break;

                case "Товары":
                    OrdersGrd.ItemsSource = context.View_Products.ToList();
                    selectedTable = 1;
                    break;

                case "Проданные продукты":
                    OrdersGrd.ItemsSource = context.View_ProductSelling.ToList();
                    selectedTable = 2;
                    break;

                case "Способы оплаты":
                    OrdersGrd.ItemsSource = context.View_Payment_Methods.ToList();
                    selectedTable = 3;
                    break;
            }
        }
        private void To_DataSet_Click(object sender, RoutedEventArgs e)
        {
            DataSetWindow dataSetWindow = new DataSetWindow();
            dataSetWindow.Show();
            Close();
        }

        private void Orders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
