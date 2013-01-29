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

namespace WpfApplication3.Development_performance
{
    /// <summary>
    /// Teaching.xaml 的交互逻辑
    /// </summary>
    public partial class Teaching : Window
    {
        public Teaching(String str)
        {
            InitializeComponent();
            try
            {
                webBrowser1.Navigate(new Uri(str, UriKind.Absolute));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }
        private void Window_Deactivated(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
