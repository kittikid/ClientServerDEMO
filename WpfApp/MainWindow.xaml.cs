using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfApp.Base;

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

        private void CreateList()
        {
            List<Base.Product> products = SourceCore.cutlerysEntities.Product.ToList();
            List<ProductClass> productClasses = new List<ProductClass>();
            SolidColorBrush brush = (SolidColorBrush)new BrushConverter().ConvertFrom("#ffff");
            for (int i = 0; i < products.Count; i++)
            {
                productClasses.Add(new ProductClass()
                {
                    Background = products[i].ProductQuantityInStock > 0 ? (Brush)FindResource("Color1") : (Brush)FindResource("Color2"),
                    ProductArticleNumber = products[i].ProductArticleNumber,
                    ProductDescription = products[i].ProductDescription,
                    ProductCategory = products[i].ProductCategory,
                    //ProductQuantityStock = products[i].ProductQuantityInStock

                }) ;
            }
            productList.ItemsSource = productClasses;
        }
    }
}
