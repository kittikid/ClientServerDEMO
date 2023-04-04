using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfApp
{
    public class ProductClass
    {
        public Brush Background { get; set; }
        public int Id { get; set; }
        public string ProductArticleNumber { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCategory { get; set; }
        public ImageSource ProductPhoto { get; set; } 
        public int ProductQuantityStock { get; set; }
    }
}
