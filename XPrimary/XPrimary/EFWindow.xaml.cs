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
        public EFWindow()
        {
            InitializeComponent();
        }

        private void CurrentTableCbx_SelectionChanged_Event(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CurrentTableDgr_SelectionChanged_Event(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ReloadButton_Click_Event(object sender, RoutedEventArgs e)
        {

        }

        private void ViewTables_Click_Event(object sender, RoutedEventArgs e)
        {

        }

        private void DataSetMode_Click_Event(object sender, RoutedEventArgs e)
        {
            DataSetWindow DataSetWindowObject = new DataSetWindow();
            DataSetWindowObject.Show();
            Close();
        }
    }
}
