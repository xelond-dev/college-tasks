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

namespace XPrimary
{
    /// <summary>
    /// Логика взаимодействия для EFWindow.xaml
    /// </summary>
    public partial class EFWindow : Window
    {
        XPrimaryEntities XPrimaryContext = new XPrimaryEntities();

        private int currentTableIndex = 0;


        // Analytics
        private int ReloadClickCounter = 0;

        public EFWindow()
        {
            InitializeComponent();
            InitializeTablesManagement();

            DeveloperFeature_Debug_Text.Text = CurrentTableDgr.Columns.Count().ToString();
        }

        private void CurrentTableCbx_SelectionChanged_Event(object sender, SelectionChangedEventArgs e)
        {
            SwitchCurrentTable(CurrentTableCbx.SelectedIndex);
        }

        private void CurrentTableDgr_SelectionChanged_Event(object sender, SelectionChangedEventArgs e)
        {
            switch (currentTableIndex)
            {
                case 0:
                    cbx1.ItemsSource = XPrimaryContext.Payment_Methods.ToList();
                    cbx1.DisplayMemberPath = "Payment_Type";
                    break;
                case 1:
                    var selected = CurrentTableDgr.SelectedItem as Products;

                    tbx1.Text = selected.Product_Name;
                    tbx2.Text = selected.Amount_In_Storage.ToString();
                    tbx3.Text = selected.Price.ToString();
                    break;

                case 2:
                    var selected2 = CurrentTableDgr.SelectedItem as ProductSelling;

                    tbx1.Text = selected2.Quantity.ToString();
                    cbx1.ItemsSource = XPrimaryContext.ProductSelling.ToList();
                    cbx1.DisplayMemberPath = "Product_Name";

                    cbx2.ItemsSource = selected2.Orders.ToString();
                    cbx2.DisplayMemberPath = "ID_Order";
                    break;

                case 3:
                    var selected3 = CurrentTableDgr.SelectedItem as Payment_Methods;

                    tbx1.Text = selected3.Payment_Type;
                    break;
            }
        }

        private void ReloadButton_Click_Event(object sender, RoutedEventArgs e)
        {
            InitializeTablesManagement();
        }

        private void InitializeTablesManagement()
        {
            // List of tables
            List<String> tablesList = new List<String> { "Заказы", "Продукты", "Проданные продукты", "Способы платежа" };

            // <df>
            ReloadClickCounter++;

            if (ReloadClickCounter >= 5)
            {
                DeveloperFeatures_Icon.Visibility = Visibility.Visible;

                tablesList.Add("OrdersTableAdapter");
                tablesList.Add("ProductsTableAdapter");
                tablesList.Add("ProductSellingTableAdapter");
                tablesList.Add("Payment_MethodsTableAdapter");
            }

            // Load cbx
            CurrentTableCbx.ItemsSource = tablesList;
            CurrentTableCbx.SelectedIndex = 0;

            // Load dgr
            SwitchCurrentTable(0);
        }

        private void SwitchCurrentTable(int tableIndex)
        {
            currentTableIndex = tableIndex;

            switch (tableIndex)
            {
                case 0:
                    CurrentTableDgr.ItemsSource = XPrimaryContext.Orders.ToList();

                    tbx1.Visibility = Visibility.Hidden;
                    tbx2.Visibility = Visibility.Hidden;
                    tbx3.Visibility = Visibility.Hidden;
                    cbx1.Visibility = Visibility.Visible;
                    cbx2.Visibility = Visibility.Hidden;

                    cbx1.ItemsSource = XPrimaryContext.Payment_Methods.ToList();
                    cbx1.DisplayMemberPath = "Payment_Type";
                    break;

                case 1:
                    CurrentTableDgr.ItemsSource = XPrimaryContext.Products.ToList();

                    tbx1.Visibility = Visibility.Visible;
                    tbx2.Visibility = Visibility.Visible;
                    tbx3.Visibility = Visibility.Visible;
                    cbx1.Visibility = Visibility.Hidden;
                    cbx2.Visibility = Visibility.Hidden;
                    break;

                case 2:
                    CurrentTableDgr.ItemsSource = XPrimaryContext.ProductSelling.ToList();

                    cbx1.ItemsSource = XPrimaryContext.Products.ToList();
                    cbx1.DisplayMemberPath = "Product_Name";

                    cbx2.ItemsSource = XPrimaryContext.Orders.ToList();
                    cbx2.DisplayMemberPath = "ID_Order";

                    tbx1.Visibility = Visibility.Visible;
                    tbx2.Visibility = Visibility.Hidden;
                    tbx3.Visibility = Visibility.Hidden;
                    cbx1.Visibility = Visibility.Visible;
                    cbx2.Visibility = Visibility.Visible;
                    break;

                case 3:
                    CurrentTableDgr.ItemsSource = XPrimaryContext.Payment_Methods.ToList();

                    tbx1.Visibility = Visibility.Visible;
                    tbx2.Visibility = Visibility.Hidden;
                    tbx3.Visibility = Visibility.Hidden;
                    cbx1.Visibility = Visibility.Hidden;
                    cbx2.Visibility = Visibility.Hidden;
                    break;

                // <df>
                case 4:
                    CurrentTableDgr.ItemsSource = XPrimaryContext.Orders.ToList();
                    break;

                case 5:
                    CurrentTableDgr.ItemsSource = XPrimaryContext.Products.ToList();
                    break;

                case 6:
                    CurrentTableDgr.ItemsSource = XPrimaryContext.ProductSelling.ToList();
                    break;

                case 7:
                    CurrentTableDgr.ItemsSource = XPrimaryContext.Payment_Methods.ToList();
                    break;
            }
        }

        private void ViewTables_Click_Event(object sender, RoutedEventArgs e)
        {
            SingleWindow singleWindow = new SingleWindow("ef");
            singleWindow.Show();
        }

        private void DataSetMode_Click_Event(object sender, RoutedEventArgs e)
        {
            DataSetWindow DataSetWindowObject = new DataSetWindow();
            DataSetWindowObject.Show();
            Close();
        }

        private void DisableDeveloperFeatures_Event(object sender, MouseButtonEventArgs e)
        {
            DeveloperFeatures_Icon.Visibility = Visibility.Hidden;
            ReloadClickCounter = int.MinValue;

            InitializeTablesManagement();
        }

        private void Add_Click_Event(object sender, RoutedEventArgs e)
        {
            if (currentTableIndex == 0)
            {
                Orders newOrder = new Orders();
                newOrder.Payment_Method_ID = cbx1.SelectedIndex + 1;
                newOrder.Order_Date = DateTime.Now;
                newOrder.Order_Time = DateTime.Now.TimeOfDay;

                XPrimaryContext.Orders.Add(newOrder);
                XPrimaryContext.SaveChanges();
            } else if (currentTableIndex == 1)
            {
                Products newProduct = new Products();
                newProduct.Product_Name = tbx1.Text;
                newProduct.Amount_In_Storage = Convert.ToInt32(tbx2.Text);
                newProduct.Price = Convert.ToInt32(tbx3.Text);

                XPrimaryContext.Products.Add(newProduct);
                XPrimaryContext.SaveChanges();
            } else if (currentTableIndex == 2)
            {
                ProductSelling productSelling = new ProductSelling();
                productSelling.Product_ID = cbx1.SelectedIndex + 1;
                productSelling.Order_ID = cbx2.SelectedIndex + 1;
                productSelling.Quantity = Convert.ToInt32(tbx1.Text);
                

                XPrimaryContext.ProductSelling.Add(productSelling);
                XPrimaryContext.SaveChanges();
            } else if (currentTableIndex == 3)
            {
                Payment_Methods newPayment = new Payment_Methods();
                newPayment.Payment_Type = tbx1.Text;

                XPrimaryContext.Payment_Methods.Add(newPayment);
                XPrimaryContext.SaveChanges();
            }

            SwitchCurrentTable(currentTableIndex);
        }

        private void Edit_Click_Event(object sender, RoutedEventArgs e)
        {
            if (CurrentTableDgr.SelectedItem != null)
            {
                if (currentTableIndex == 0)
                {
                    Orders newOrder = new Orders();
                    newOrder.Payment_Method_ID = cbx1.SelectedIndex + 1;
                    newOrder.Order_Date = DateTime.Now;
                    newOrder.Order_Time = DateTime.Now.TimeOfDay;

                    XPrimaryContext.Orders.Add(newOrder);
                    XPrimaryContext.SaveChanges();
                }
                else if (currentTableIndex == 1)
                {
                    Products newProduct = new Products();
                    newProduct.Product_Name = tbx1.Text;
                    newProduct.Amount_In_Storage = Convert.ToInt32(tbx2.Text);
                    newProduct.Price = Convert.ToInt32(tbx3.Text);

                    XPrimaryContext.Products.Add(newProduct);
                    XPrimaryContext.SaveChanges();
                }
                else if (currentTableIndex == 2)
                {
                    ProductSelling productSelling = new ProductSelling();
                    productSelling.Product_ID = cbx1.SelectedIndex + 1;
                    productSelling.Order_ID = cbx2.SelectedIndex + 1;
                    productSelling.Quantity = Convert.ToInt32(tbx1.Text);


                    XPrimaryContext.ProductSelling.Add(productSelling);
                    XPrimaryContext.SaveChanges();
                }
                else if (currentTableIndex == 3)
                {
                    Payment_Methods newPayment = new Payment_Methods();
                    newPayment.Payment_Type = tbx1.Text;

                    XPrimaryContext.Payment_Methods.Add(newPayment);
                    XPrimaryContext.SaveChanges();
                }
            }

            XPrimaryContext.SaveChanges();
        }

        private void Remove_Click_Event(object sender, RoutedEventArgs e)
        {

            switch (currentTableIndex)
            {
                case 0:
                    XPrimaryContext.Orders.Remove(CurrentTableDgr.SelectedItem as Orders);
                    XPrimaryContext.SaveChanges();
                    break;

                case 1:
                    XPrimaryContext.Products.Remove(CurrentTableDgr.SelectedItem as Products);
                    XPrimaryContext.SaveChanges();
                    break;

                case 2:
                    XPrimaryContext.ProductSelling.Remove(CurrentTableDgr.SelectedItem as ProductSelling);
                    XPrimaryContext.SaveChanges();
                    break;

                case 3:
                    XPrimaryContext.Payment_Methods.Remove(CurrentTableDgr.SelectedItem as Payment_Methods);
                    XPrimaryContext.SaveChanges();
                    break;
            }

            SwitchCurrentTable(currentTableIndex);

        }
    }
}
