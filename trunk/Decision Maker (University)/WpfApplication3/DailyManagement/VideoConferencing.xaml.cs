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
          
            webBrower1.Navigate(new Uri(pdfFile, UriKind.RelativeOrAbsolute));

        }
        public void showPDF2(string pdfFile)
        {
        
            webBrower2.Navigate(new Uri(pdfFile, UriKind.RelativeOrAbsolute));
        }
     

        protected void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DirectoryInfo dii = new DirectoryInfo(System.Environment.CurrentDirectory);
            string pathPDF = dii.Parent.Parent.FullName;
            List<Information> infos = new List<Information>
            {
                           new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月项目经费使用情况报告",
                    Type="项目经费",
                    Address=pathPDF + @"/PDF/" + "2012年5月项目经费使用情况报告.pdf"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月项目经费使用情况报告",
                    Type="项目经费",
                    Address=pathPDF + @"/PDF/" + "2012年5月项目经费使用情况报告.pdf"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月项目经费使用情况报告",
                    Type="项目经费",
                    Address=pathPDF + @"/PDF/" + "2012年5月项目经费使用情况报告.pdf"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月项目经费使用情况报告",
                    Type="项目经费",
                    Address=pathPDF + @"/PDF/" + "2012年5月项目经费使用情况报告.pdf"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月内部文件情况报告",
                    Type="内部文件",
                    Address=pathPDF + @"/PDF/" + "2012年5月内部文件情况报告.pdf"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月内部文件情况报告",
                    Type="内部文件",
                    Address=pathPDF + @"/PDF/" + "2012年5月内部文件情况报告.pdf"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月内部文件情况报告",
                    Type="内部文件",
                    Address=pathPDF + @"/PDF/" + "2012年5月内部文件情况报告.pdf"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月内部文件情况报告",
                    Type="内部文件",
                    Address=pathPDF + @"/PDF/" + "2012年5月内部文件情况报告.pdf"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月内部文件情况报告",
                    Type="内部文件",
                    Address=pathPDF + @"/PDF/" + "2012年5月内部文件情况报告.pdf"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月内部文件情况报告",
                    Type="内部文件",
                    Address=pathPDF + @"/PDF/" + "2012年5月内部文件情况报告.pdf"
                },
                 new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月内部文件情况报告",
                    Type="内部文件",
                    Address=pathPDF + @"/PDF/" + "2012年5月内部文件情况报告.pdf"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月媒体报道情况报告",
                    Type="媒体报道",
                    Address=pathPDF + @"/PDF/" + "2012年5月媒体报道情况报告.pdf"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月媒体报道情况报告",
                    Type="媒体报道",
                    Address=pathPDF + @"/PDF/" + "2012年5月媒体报道情况报告.pdf"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月媒体报道情况报告",
                    Type="媒体报道",
                    Address=pathPDF + @"/PDF/" + "2012年5月媒体报道情况报告.pdf"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月媒体报道情况报告",
                    Type="媒体报道",
                    Address=pathPDF + @"/PDF/" + "2012年5月媒体报道情况报告.pdf"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月媒体报道情况报告",
                    Type="媒体报道",
                    Address=pathPDF + @"/PDF/" + "2012年5月媒体报道情况报告.pdf"
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
            showPDF2(content);
        }
        private void Button_FaYan(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button btn = sender as System.Windows.Controls.Button;
            string content = btn.Content as string;
            showPDF1(content);
        }
        private void Button_Share(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button btn = sender as System.Windows.Controls.Button;
            string content = btn.Content as string;
            System.Windows.MessageBox.Show("分享成功！");
        }
        private void Button_ChooseFile(object sender, System.EventArgs e)
        {
            string file = null;
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "PDF files (*.pdf)|*.pdf|Word files (*.doc;*.docx)|*.doc;*.docx|Text files (*.txt)|*.txt";
            if (fileDialog.ShowDialog() == DialogResult.OK) 
            {
              file = fileDialog.FileName;
               

            }
            else return;
            string filename = file.Substring(file.LastIndexOf(@"\") + 1, file.LastIndexOf(".") - file.LastIndexOf(@"\") - 1);

            DirectoryInfo di = new DirectoryInfo(System.Environment.CurrentDirectory);
            string pathPDF = di.Parent.Parent.FullName;
      

            List<Information> infos = new List<Information>
            {
                              new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-12-26",
                    Title=filename,
                    Type="项目经费",
                    Address=file
                },
                     new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-12-26",
                    Title=filename,
                    Type="内部文件",
                    Address=file
                },
                     new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-12-26",
                    Title=filename,
                    Type="媒体报道",
                    Address=file
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月项目经费使用情况报告",
                    Type="项目经费",
                    Address=pathPDF + @"/PDF/" + "2012年5月项目经费使用情况报告.pdf"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月项目经费使用情况报告",
                    Type="项目经费",
                    Address=pathPDF + @"/PDF/" + "2012年5月项目经费使用情况报告.pdf"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月项目经费使用情况报告",
                    Type="项目经费",
                    Address=pathPDF + @"/PDF/" + "2012年5月项目经费使用情况报告.pdf"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月项目经费使用情况报告",
                    Type="项目经费",
                    Address=pathPDF + @"/PDF/" + "2012年5月项目经费使用情况报告.pdf"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月内部文件情况报告",
                    Type="内部文件",
                    Address=pathPDF + @"/PDF/" + "2012年5月内部文件情况报告.pdf"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月内部文件情况报告",
                    Type="内部文件",
                    Address=pathPDF + @"/PDF/" + "2012年5月内部文件情况报告.pdf"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月内部文件情况报告",
                    Type="内部文件",
                    Address=pathPDF + @"/PDF/" + "2012年5月内部文件情况报告.pdf"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月内部文件情况报告",
                    Type="内部文件",
                    Address=pathPDF + @"/PDF/" + "2012年5月内部文件情况报告.pdf"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月内部文件情况报告",
                    Type="内部文件",
                    Address=pathPDF + @"/PDF/" + "2012年5月内部文件情况报告.pdf"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月内部文件情况报告",
                    Type="内部文件",
                    Address=pathPDF + @"/PDF/" + "2012年5月内部文件情况报告.pdf"
                },
                 new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月内部文件情况报告",
                    Type="内部文件",
                    Address=pathPDF + @"/PDF/" + "2012年5月内部文件情况报告.pdf"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月媒体报道情况报告",
                    Type="媒体报道",
                    Address=pathPDF + @"/PDF/" + "2012年5月媒体报道情况报告.pdf"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月媒体报道情况报告",
                    Type="媒体报道",
                    Address=pathPDF + @"/PDF/" + "2012年5月媒体报道情况报告.pdf"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月媒体报道情况报告",
                    Type="媒体报道",
                    Address=pathPDF + @"/PDF/" + "2012年5月媒体报道情况报告.pdf"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月媒体报道情况报告",
                    Type="媒体报道",
                    Address=pathPDF + @"/PDF/" + "2012年5月媒体报道情况报告.pdf"
                },
                new Information
                {
                    ImageSource="/Images/cone.png",
                    FileDate="2012-11-22",
                    Title="2012年5月媒体报道情况报告",
                    Type="媒体报道",
                    Address=pathPDF + @"/PDF/" + "2012年5月媒体报道情况报告.pdf"
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
        class Information
        {
            public string ImageSource { get; set; }
            public string FileDate { get; set; }
            public string Title { get; set; }
            public string Type { get; set; }
            public string Address { get; set; }
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
    

     


