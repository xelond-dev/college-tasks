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
using XPrimary.XPrimaryDataSetTableAdapters;

namespace XPrimary
{
    /// <summary>
    /// Логика взаимодействия для SingleWindow.xaml
    /// </summary>
    public partial class SingleWindow : Window
    {
        private XPrimaryEntities XPrimaryContext = new XPrimaryEntities();
        private ProductSellingTableAdapter productSelling = new ProductSellingTableAdapter();

        private string CurrentDBType;

        public SingleWindow(string DBType)
        {
            InitializeComponent();

            FilterCbx.ItemsSource = XPrimaryContext.Payment_Methods.ToList();
            FilterCbx.DisplayMemberPath = "Payment_Type";

            CurrentDBType = DBType;
            InitializeGrd();
        }

        private void ReloadButton_Click_Event(object sender, RoutedEventArgs e)
        {

        }

        private void CurrentTableDgr_SelectionChanged_Event(object sender, SelectionChangedEventArgs e)
        {

        }

        private void InitializeGrd()
        {
            if (CurrentDBType == "ef")
            {
                CurrentTableDgr.ItemsSource = XPrimaryContext.ProductSelling.ToList();

            }
            else if (CurrentDBType == "dataset")
            {
                CurrentTableDgr.ItemsSource = productSelling.GetData();
            }
        }

        private void ChangeDBType_Click_Event(object sender, RoutedEventArgs e)
        {
            switch (CurrentDBType)  
            {
                case "ef":
                    CurrentDBType = "dataset";
                    InitializeGrd();
                    break;

                case "dataset":
                    CurrentDBType = "ef";
                    InitializeGrd();
                    break;
            }
        }
        

        private void Close_Click_Event(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Search_Click_Event(object sender, RoutedEventArgs e)
        {
            if (CurrentDBType == "ef")
            {
                CurrentTableDgr.ItemsSource = XPrimaryContext.ProductSelling.ToList().Where(item => item.Products.Product_Name.Contains(SearchBox.Text));
            }
        }

        private void FilterCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FilterCbx.SelectedItem != null)
            {
                var selected = FilterCbx.SelectedItem as Payment_Methods;
                CurrentTableDgr.ItemsSource = XPrimaryContext.ProductSelling.ToList().Where(item => item.Orders.Payment_Methods == selected);
            }
        }

        private void Clear_Click_Event(object sender, RoutedEventArgs e)
        {
            CurrentTableDgr.ItemsSource = XPrimaryContext.ProductSelling.ToList();
            SearchBox.Text = "";
        }
    }
}
