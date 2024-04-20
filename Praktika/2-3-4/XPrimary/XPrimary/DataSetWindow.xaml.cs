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
using System.Windows.Navigation;
using System.Windows.Shapes;
using XPrimary.XPrimaryDataSetTableAdapters;

namespace XPrimary
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public partial class DataSetWindow : Window
    {
        // Таблицы
        private ProductSellingTableAdapter adp_ProductSelling = new ProductSellingTableAdapter();
        private OrdersTableAdapter adp_Orders = new OrdersTableAdapter();
        private ProductsTableAdapter adp_Products = new ProductsTableAdapter();
        private Payment_MethodsTableAdapter adp_Payment_Methods = new Payment_MethodsTableAdapter();

        // Вьюхи
        private vw_ProductSellingTableAdapter vw_ProductSelling = new vw_ProductSellingTableAdapter();
        private vw_OrdersTableAdapter vw_Orders = new vw_OrdersTableAdapter();
        private vw_ProductsTableAdapter vw_Products = new vw_ProductsTableAdapter();
        private vw_Payment_MethodsTableAdapter vw_Payment_Methods = new vw_Payment_MethodsTableAdapter();

        private int currentTableIndex = 0;

        // Analytics
        private int ReloadClickCounter = 0;
         
        public DataSetWindow()
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
                    CurrentTableDgr.ItemsSource = adp_Orders.GetData().ToList();

                    tbx1.Visibility = Visibility.Hidden;
                    tbx2.Visibility = Visibility.Hidden;
                    tbx3.Visibility = Visibility.Hidden;
                    cbx1.Visibility = Visibility.Visible;
                    cbx2.Visibility = Visibility.Hidden;

                    cbx1.ItemsSource = adp_Payment_Methods.GetData().ToList();
                    cbx1.DisplayMemberPath = "Payment_Type";
                    break;

                case 1:
                    CurrentTableDgr.ItemsSource = adp_Products.GetData().ToList();

                    tbx1.Visibility = Visibility.Visible;
                    tbx2.Visibility = Visibility.Visible;
                    tbx3.Visibility = Visibility.Visible;
                    cbx1.Visibility = Visibility.Hidden;
                    cbx2.Visibility = Visibility.Hidden;
                    break;

                case 2:
                    CurrentTableDgr.ItemsSource = adp_ProductSelling.GetData().ToList();

                    cbx1.ItemsSource = adp_Products.GetData().ToList();
                    cbx1.DisplayMemberPath = "Product_Name";

                    cbx2.ItemsSource = adp_Orders.GetData().ToList();
                    cbx2.DisplayMemberPath = "ID_Order";

                    tbx1.Visibility = Visibility.Visible;
                    tbx2.Visibility = Visibility.Hidden;
                    tbx3.Visibility = Visibility.Hidden;
                    cbx1.Visibility = Visibility.Visible;
                    cbx2.Visibility = Visibility.Visible;
                    break;

                case 3:
                    CurrentTableDgr.ItemsSource = adp_Payment_Methods.GetData().ToList();

                    tbx1.Visibility = Visibility.Visible;
                    tbx2.Visibility = Visibility.Hidden;
                    tbx3.Visibility = Visibility.Hidden;
                    cbx1.Visibility = Visibility.Hidden;
                    cbx2.Visibility = Visibility.Hidden;
                    break;

                // <df>
                case 4:
                    CurrentTableDgr.ItemsSource = adp_Orders.GetData().ToList();
                    break;

                case 5:
                    CurrentTableDgr.ItemsSource = adp_Products.GetData().ToList();
                    break;

                case 6:
                    CurrentTableDgr.ItemsSource = adp_ProductSelling.GetData().ToList();
                    break;

                case 7:
                    CurrentTableDgr.ItemsSource = adp_Payment_Methods.GetData().ToList();
                    break;
            }
        }

        private void ViewTables_Click_Event(object sender, RoutedEventArgs e)
        {
            SingleWindow singleWindow = new SingleWindow("dataset");
            singleWindow.Show();
        }

        private void EFMode_Click_Event(object sender, RoutedEventArgs e)
        {
            EFWindow EFWindowObject = new EFWindow();
            EFWindowObject.Show();
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

            switch (currentTableIndex)
            {
                case 0:
                    adp_Orders.InsertQuery(cbx1.SelectedIndex + 1, DateTime.Now.ToString(), DateTime.Now.ToString());
                    break;

                case 1:
                    adp_Products.InsertQuery(tbx1.Text, Convert.ToInt32(tbx2.Text), Convert.ToInt32(tbx3.Text));
                    break;

                case 2:
                    adp_ProductSelling.InsertQuery(cbx1.SelectedIndex + 1, cbx2.SelectedIndex + 1, Convert.ToInt32(tbx1.Text));
                    break;

                case 3:
                    adp_Payment_Methods.InsertQuery(tbx1.Text);
                    break;
            }

            SwitchCurrentTable(currentTableIndex);

        }

        private void Edit_Click_Event(object sender, RoutedEventArgs e)
        {
            if (CurrentTableDgr.SelectedItem != null)
            {
                object id = (CurrentTableDgr.SelectedItem as DataRowView).Row[0];


                switch (currentTableIndex)
                {
                    case 0:
                        adp_Orders.UpdateQuery(cbx1.SelectedIndex + 1, DateTime.Now.ToString(), DateTime.Now.ToString(), Convert.ToInt32(id));
                        break;

                    case 1:
                        adp_Products.UpdateQuery(tbx1.Text, Convert.ToInt32(tbx2), Convert.ToInt32(tbx3), Convert.ToInt32(id));
                        break;

                    case 2:
                        adp_ProductSelling.UpdateQuery(cbx1.SelectedIndex + 1, cbx2.SelectedIndex + 1, Convert.ToInt32(tbx1.Text), Convert.ToInt32(id));
                        break;

                    case 3:
                        adp_Payment_Methods.UpdateQuery(tbx1.Text, Convert.ToInt32(id));
                        break;

                }

                SwitchCurrentTable(currentTableIndex);
            }
        }

        private void Remove_Click_Event(object sender, RoutedEventArgs e)
        {
            if (CurrentTableDgr.SelectedItem != null)
            {
                object id = (CurrentTableDgr.SelectedItem as DataRowView).Row[0];


                switch (currentTableIndex)
                {
                    case 0:
                        adp_Orders.DeleteQuery(Convert.ToInt32(id));
                        break;

                    case 1:
                        adp_Products.DeleteQuery(Convert.ToInt32(id));  
                        break;

                    case 2:
                       adp_ProductSelling.DeleteQuery(Convert.ToInt32(id)); 
                        break;

                    case 3:
                        adp_Payment_Methods.DeleteQuery(Convert.ToInt32(id));   
                        break;
                }

                SwitchCurrentTable(currentTableIndex);
            }
        }
    }
}
