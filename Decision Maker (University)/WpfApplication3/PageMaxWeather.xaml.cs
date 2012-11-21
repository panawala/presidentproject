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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for PageMaxWeather.xaml
    /// </summary>
    public partial class PageMaxWeather : Page
    {
        public PageMaxWeather()
        {
            InitializeComponent();
            webBrowsermaxweather.Source = new Uri("http://flash.weather.com.cn/sk2/shikuang.swf?id=101020100");
        }

        private void btn_minweather_Click(object sender, RoutedEventArgs e)
        {
            HomePage m_HomePage = new HomePage();
            this.NavigationService.Navigate(m_HomePage);
        }
    }
}
