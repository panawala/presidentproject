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
namespace WpfApplication3.DailyManagement
{
    /// <summary>
    /// Interaction logic for Schedule.xaml
    /// </summary>
    public partial class Schedule : Page
    {
        public Schedule()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string strPATH;
            DirectoryInfo di;
            di = new DirectoryInfo(System.Environment.CurrentDirectory);
            strPATH = di.Parent.Parent.FullName;
            webBrowser_GoogleCalendar.Navigate(new Uri(strPATH + @"/html/GoogleCalendar.htm", UriKind.RelativeOrAbsolute));
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            ComboBox m_ComboBox = (ComboBox)sender;
            for (int i = 1; i < m_ComboBox.Items.Count - 1; i++)
            {
                CheckBox m_CheckBox = (CheckBox)m_ComboBox.Items[i];
                if ((bool)m_CheckBox.IsChecked && listboxSend.Items.IndexOf(m_CheckBox.Content.ToString()) == -1)
                    listboxSend.Items.Add(m_CheckBox.Content.ToString());
                else if (!(bool)m_CheckBox.IsChecked && listboxSend.Items.IndexOf(m_CheckBox.Content.ToString()) != -1)
                    listboxSend.Items.Remove(m_CheckBox.Content.ToString());
            }

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ComboBox m_ComboBox = (ComboBox)((CheckBox)sender).Parent;
            for (int i = 1; i < m_ComboBox.Items.Count - 1; i++)
            {
                ((CheckBox)m_ComboBox.Items[i]).IsChecked = true;
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ComboBox m_ComboBox = (ComboBox)((CheckBox)sender).Parent;
            for (int i = 1; i < m_ComboBox.Items.Count - 1; i++)
            {
                ((CheckBox)m_ComboBox.Items[i]).IsChecked = false;
            }
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("发送成功！");
        }
   
    }
}
