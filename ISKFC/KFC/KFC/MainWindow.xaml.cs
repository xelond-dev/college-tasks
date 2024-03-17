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
        private int amountOftbxs = 0;

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

                    amountOftbxs = 2;
                    switchFieldsStatus(2);
                    break;

                case "Товары":
                    OrdersGrd.ItemsSource = context.View_Products.ToList();
                    selectedTable = 1;

                    amountOftbxs = 3;
                    switchFieldsStatus(3);
                    break;

                case "Проданные продукты":
                    OrdersGrd.ItemsSource = context.View_ProductSelling.ToList();
                    selectedTable = 2;

                    amountOftbxs = 2;
                    switchFieldsStatus(2);
                    break;

                case "Способы оплаты":
                    OrdersGrd.ItemsSource = context.View_Payment_Methods.ToList();
                    selectedTable = 3;

                    amountOftbxs = 1;
                    switchFieldsStatus(1);
                    break;
            }
        }
        private void To_DataSet_Click(object sender, RoutedEventArgs e)
        {
            DataSetWindow dataSetWindow = new DataSetWindow();
            dataSetWindow.Show();
            Close();
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            string selectedCbx = CurrentTableCbx.Items[CurrentTableCbx.SelectedIndex] as string;

            if (selectedCbx == "Заказы" && tbx1.Text != null && tbx2.Text != null)
            {
                Orders order = new Orders();

                order.Payment_Method_ID = Convert.ToInt16(tbx1.Text);
                order.Order_Date = Convert.ToDateTime(tbx2.Text);

                context.Orders.Add(order);
                context.SaveChanges();

                OrdersGrd.ItemsSource = context.Orders.ToList();
            } 
            else if (selectedCbx == "Товары" && tbx1.Text != null && tbx2.Text != null && tbx3.Text != null)
            {
                Products products = new Products();

                products.Product_Name = tbx1.Text;
                products.Amount_In_Storage = Convert.ToInt16(tbx2.Text);
                products.Price = Convert.ToInt16(tbx3.Text);

                context.Products.Add(products);
                context.SaveChanges();

                OrdersGrd.ItemsSource = context.Products.ToList();
            } 
            else if (selectedCbx == "Продажа продукта" && tbx1.Text != null && tbx2.Text != null)
            {
                ProductSelling productSelling = new ProductSelling();

                productSelling.Product_ID = Convert.ToInt16(tbx1.Text);
                productSelling.Order_ID = Convert.ToInt16(tbx2.Text);

                context.ProductSelling.Add(productSelling);
                context.SaveChanges();

                OrdersGrd.ItemsSource = context.ProductSelling.ToList();
            } 
            else if (selectedCbx == "Способы оплаты" && tbx1.Text != null)
            {
                Payment_Methods payment_Methods = new Payment_Methods();

                payment_Methods.Payment_Type = tbx1.Text;

                context.Payment_Methods.Add(payment_Methods);
                context.SaveChanges();

                OrdersGrd.ItemsSource = context.Payment_Methods.ToList();
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
                if (selectedCbx == "Заказы")
                {
                    context.Orders.Remove(OrdersGrd.SelectedItem as Orders);
                    context.SaveChanges();

                    OrdersGrd.ItemsSource = context.Orders.ToList();
                }
                else if (selectedCbx == "Товары")
                {
                    context.Products.Remove(OrdersGrd.SelectedItem as Products);
                    context.SaveChanges();

                    OrdersGrd.ItemsSource = context.Products.ToList();
                }
                else if (selectedCbx == "Продажа продукта")
                {
                    context.ProductSelling.Remove(OrdersGrd.SelectedItem as ProductSelling);
                    context.SaveChanges();

                    OrdersGrd.ItemsSource = context.ProductSelling.ToList();
                }
                else if (selectedCbx == "Способы оплаты")
                {
                    context.Payment_Methods.Remove(OrdersGrd.SelectedItem as Payment_Methods);
                    context.SaveChanges();

                    OrdersGrd.ItemsSource = context.Payment_Methods.ToList();
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
        }

        private void Orders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
