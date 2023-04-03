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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Database = new Base.CutlerysEntities();
            CreateList();
        }

        private Base.CutlerysEntities Database;

        private void BackAuthButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.AuthorizationWindow authorizationWindow = new Windows.AuthorizationWindow();
            authorizationWindow.Show();
            this.Close();
        }

        private void SelectionChanged(object sender, RoutedEventArgs e) 
        {

        }

        private void CreateList()
        {
            productList.Items.Add(Database.Product.Where(t => t.ProductDescription == "Набор столовых вилок Davinci, 20 см 6 шт."));
        }
    }
}
