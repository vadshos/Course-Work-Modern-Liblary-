using System;
using System.Collections.Generic;
using System.IO;
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

namespace Course_work_Library
{
    /// <summary>
    /// Interaction logic for PDF_View.xaml
    /// </summary>
    public partial class PDF_View : Window
    {
        public PDF_View()
        {

        }
        public PDF_View(string path)
        {
            InitializeComponent();
            PDF.ItemSource = new FileStream(path, FileMode.OpenOrCreate);
        }
    }
}
