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
using System.Windows.Forms;
namespace WpfApplication3.DailyManagement
{
    /// <summary>
    /// Interaction logic for VideoConferencing.xaml
    /// </summary>
    public partial class VideoConferencing : Page
    {
        public VideoConferencing()
        {
            InitializeComponent();
        }
        public void showPDF1(string pdfFile)
        {
            DirectoryInfo di = new DirectoryInfo(System.Environment.CurrentDirectory);
            string pathPDF = di.Parent.Parent.FullName;
            webBrower1.Navigate(new Uri(pathPDF + @"/PDF/" + pdfFile, UriKind.RelativeOrAbsolute));//获取根目录的日历文件

        }
        public void showPDF2(string pdfFile)
        {
            DirectoryInfo di = new DirectoryInfo(System.Environment.CurrentDirectory);
            string pathPDF = di.Parent.Parent.FullName;
            webBrower2.Navigate(new Uri(pathPDF + @"/PDF/" + pdfFile, UriKind.RelativeOrAbsolute));//获取根目录的日历文件

        }


        protected void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<Information> infos = new List<Information>
            {
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月项目经费使用情况报告",
                    Type="项目经费"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月项目经费使用情况报告",
                    Type="项目经费"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月项目经费使用情况报告",
                    Type="项目经费"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月项目经费使用情况报告",
                    Type="项目经费"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月内部文件情况报告",
                    Type="内部文件"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月内部文件情况报告",
                    Type="内部文件"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月内部文件情况报告",
                    Type="内部文件"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月内部文件情况报告",
                    Type="内部文件"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月内部文件情况报告",
                    Type="内部文件"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月内部文件情况报告",
                    Type="内部文件"
                },
                 new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月内部文件情况报告",
                    Type="内部文件"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月媒体报道情况报告",
                    Type="媒体报道"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月媒体报道情况报告",
                    Type="媒体报道"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月媒体报道情况报告",
                    Type="媒体报道"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月媒体报道情况报告",
                    Type="媒体报道"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月媒体报道情况报告",
                    Type="媒体报道"
                }
            };

            listBox1.DataContext = infos.Where(s => s.Type == "项目经费");
            listBox1.SelectedIndex = 0;

            listBox2.DataContext = infos.Where(s => s.Type == "内部文件");
            listBox2.SelectedIndex = 0;

            listBox3.DataContext = infos.Where(s => s.Type == "媒体报道");
            listBox3.SelectedIndex = 0;

            listBox4.DataContext = infos.Where(s => s.Type == "媒体报道");
            listBox4.SelectedIndex = 0;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button btn = sender as System.Windows.Controls.Button;
            string content = btn.Content as string;
            showPDF2(content + ".pdf");
        }
        private void Button_FaYan(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button btn = sender as System.Windows.Controls.Button;
            string content = btn.Content as string;
            showPDF1(content + ".pdf");
        }
        private void Button_Share(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button btn = sender as System.Windows.Controls.Button;
            string content = btn.Content as string;
        }
        private void Button_ChooseFile(object sender, System.EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog(); fileDialog.Multiselect = true; fileDialog.Title = "请选择文件"; fileDialog.Filter = "所有文件(*.*)|*.*"; if (fileDialog.ShowDialog() == DialogResult.OK) { string file = fileDialog.FileName; }
        }
        class Information
        {
            public string ImageSource { get; set; }
            public string FileDate { get; set; }
            public string Title { get; set; }
            public string Type { get; set; }
        }


    }
}
    

     


