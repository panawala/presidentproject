using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for PDFReader.xaml
    /// </summary>
    public partial class PDFReader : Window
    {
        public PDFReader()
        {
            InitializeComponent();
        }
        public void showPdf(string pdfFile)
        {
            DirectoryInfo di = new DirectoryInfo(System.Environment.CurrentDirectory);
            string pathPDF = di.Parent.Parent.FullName;
            webBrower1.Navigate(new Uri(pathPDF + @"/PDF/"+pdfFile, UriKind.RelativeOrAbsolute));//获取根目录的日历文件
            Show();
        }
    }

}
