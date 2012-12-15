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
using System.IO;

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for PageMaxTraffic.xaml
    /// </summary>
    public partial class PageMaxTraffic : Page
    {
        string strPATH;
        public PageMaxTraffic()
        {
            InitializeComponent();
            DirectoryInfo di;
            di = new DirectoryInfo(System.Environment.CurrentDirectory);
            strPATH = di.Parent.Parent.FullName;
            //webbrowserMaxTraffic.Navigate(new Uri(strPATH + @"/html/Traffic.htm", UriKind.RelativeOrAbsolute));
            webbrowserMaxTraffic.Navigate(new Uri(strPATH + @"/html/xiaoyuanhuodong.htm", UriKind.RelativeOrAbsolute));
            webbrowserMaxTraffic1.Navigate(new Uri(strPATH + @"/html/xiaoyuanhuodong1.htm", UriKind.RelativeOrAbsolute));
       
        }

        private void btn_minTraffic_Click(object sender, RoutedEventArgs e)
        {
            HomePage m_HomePage = new HomePage();
            this.NavigationService.Navigate(m_HomePage);
        }
    }
}
