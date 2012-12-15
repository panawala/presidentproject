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

namespace WpfApplication3.ResourcesAndManpower
{
    /// <summary>
    /// Interaction logic for PageFacultyStructureMenu.xaml
    /// </summary>
    public partial class PageFacultyStructureMenu : Page
    {
        public PageFacultyStructureMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            PageFacultyStructure m_PageFacultyStructure = new PageFacultyStructure("建筑与城市规划学院");
            this.NavigationService.Navigate(m_PageFacultyStructure);
        }
    }
}
