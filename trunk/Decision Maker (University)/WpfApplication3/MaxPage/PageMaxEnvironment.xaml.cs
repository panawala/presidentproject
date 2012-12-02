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
    /// Interaction logic for Page_MaxEnvironment.xaml
    /// </summary>
    public partial class PageMaxEnvironment : Page
    {
        string strPATH;
        public PageMaxEnvironment()
        {
            InitializeComponent();
            DirectoryInfo di;
            di = new DirectoryInfo(System.Environment.CurrentDirectory);
            strPATH = di.Parent.Parent.FullName;
            //webBrowsermaxenvironment.Navigate(new Uri(strPATH + @"/html/PM25.htm", UriKind.RelativeOrAbsolute));
            webBrowsermaxenvironment.Navigate(new Uri(strPATH + @"/html/tufashijian.html", UriKind.RelativeOrAbsolute));
        }

        private void btn_minenvironment_Click(object sender, RoutedEventArgs e)
        {
            HomePage m_HomePage = new HomePage();
            this.NavigationService.Navigate(m_HomePage);
        }
    }
}
