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
    /// Interaction logic for PageOrganizationStructure.xaml
    /// </summary>
    public partial class PageOrganizationStructure : Page
    {
        public PageOrganizationStructure()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            PageFacultyStructureMenu m_PageFacultyStructureMenu = new PageFacultyStructureMenu();
            frame1.Navigate(m_PageFacultyStructureMenu);
        }

        private void tabControlOrganizationStructure_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                switch (tabControlOrganizationStructure.SelectedIndex)
                {
                    case 0:
                        if (frame1 != null)
                        {
                            PageFacultyStructureMenu m_page = new PageFacultyStructureMenu();
                            frame1.Navigate(m_page);
                        }
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    default:
                        break;
                }
            }
        }

    }
}
