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
    /// Interaction logic for PageFacultyStructure.xaml
    /// </summary>
    public partial class PageFacultyStructure : Page
    {
        string strCollegeName;
        public PageFacultyStructure(string College)
        {
            InitializeComponent();
            strCollegeName = College;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            lblCollegeName.Content = strCollegeName;
            DataSetFacultyStructureTableAdapters.T_FacultyStructureTableAdapter adapter = new DataSetFacultyStructureTableAdapters.T_FacultyStructureTableAdapter();
            DataSetFacultyStructure.T_FacultyStructureDataTable dt = adapter.GetDataByCollegeAndMenu(strCollegeName,"现任领导");
            listbox0.ItemsSource = dt;
            dt = adapter.GetDataByCollegeAndMenu(strCollegeName, "教学机构");
            listbox1.ItemsSource = dt;
            dt = adapter.GetDataByCollegeAndMenu(strCollegeName, "研究机构");
            listbox2.ItemsSource = dt;
            dt = adapter.GetDataByCollegeAndMenu(strCollegeName, "配套机构");
            listbox3.ItemsSource = dt;
            dt = adapter.GetDataByCollegeAndMenu(strCollegeName, "管理机构");
            listbox4.ItemsSource = dt;
            dt = adapter.GetDataByCollegeAndMenu(strCollegeName, "学术刊物");
            listbox5.ItemsSource = dt;
            dt = adapter.GetDataByCollegeAndMenu(strCollegeName, "国际机构");
            listbox6.ItemsSource = dt;
            
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            object obj = listbox0.ContainerFromElement((Hyperlink)sender);
            int iCurrentItem = listbox0.Items.IndexOf(((ListBoxItem)obj).Content);
            DataSetFacultyStructureTableAdapters.T_FacultyStructureTableAdapter adapter = new DataSetFacultyStructureTableAdapters.T_FacultyStructureTableAdapter();
            DataSetFacultyStructure.T_FacultyStructureDataTable dt = adapter.GetDataByCollegeAndMenu(strCollegeName,"现任领导");
            int PK_FacultyMember = dt[iCurrentItem].Id;
            WindowFacultyMember m_window = new WindowFacultyMember(PK_FacultyMember);
            m_window.Show();

        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            string str = ((Hyperlink)sender).NavigateUri.ToString();
        }
    }
}
