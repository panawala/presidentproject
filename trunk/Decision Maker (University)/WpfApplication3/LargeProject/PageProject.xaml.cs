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
using System.Windows.Media.Animation;

namespace WpfApplication3.LargeProject
{
    /// <summary>
    /// Interaction logic for PageProject.xaml
    /// </summary>
    public partial class PageProject : Page
    {
        public PageProject()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 保存各项所占的比例
        /// </summary>
        private List<double> percentList = new List<double>();
        /// <summary>
        /// 保存各项所占的真实比例
        /// </summary>
        private List<double> actualPercentList = new List<double>();
        /// <summary>
        /// 建设比例
        /// </summary>
        private double constructPercent = 0.45d;


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            percentList = new List<double> { 0.3, 0.4, 0.2, 0.1 };
            actualPercentList = new List<double> { 0.2, 0.2, 0.1, 0.05 };

            ConstructImg.Source = new BitmapImage(new Uri("/Images/construct.jpg", UriKind.Relative));
            CurrentSence.Source = new BitmapImage(new Uri("/Images/sence.png", UriKind.Relative));
            ImageSolution.Source = new BitmapImage(new Uri("/Images/solute.png", UriKind.Relative));
            //image_ProjectOrg.Source=new BitmapImage(new Uri("/Images/projectorg.jpg",UriKind.Relative));

            TextProject.Text = "上海国际设计一场”的前身是巴士一汽停车场，占地面积约120亩。在上海市高校布局新一轮调整中，该停车场划归同济大学。杨浦区政府与同济大学决定联手，在此建设集设计教育、设计研发、国际交流、活动展览等多种功能于一体的“上海国际设计一场”，将其建设成为国际化的高端设计创意平台、同济大学设计创意教育与实践基地、环同济设计创意产业的航空母舰、知识杨浦国际化的高端平台，以及上海创意之都的核心引擎项目。";


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


            for (int i = 0; i < percentList.Count; i++)
            {
                totalPercent += actualPercentList[i];
            }
            label6.Content = "完成情况：" +constructPercent  * 100 + "%";
            label5.Content = "使用情况：" + totalPercent * 100 + "%";
            drawConsAni();

        }

        void drawConstructPercentList()
        {
            double totalHeight = constructPercent * rectangle0.ActualHeight;


            Rectangle rectRight = createRectangle(rectangle0.Margin.Top, constructPercent * rectangle0.ActualHeight, Brushes.Red, Brushes.Pink);
            ConstrutGrid.Children.Add(rectRight);
            rectRight.SetValue(Grid.ColumnProperty, 1);                  //设置按钮所在Grid控件的列
        }


        void drawConsAni()
        {
            this.Name = "PageProject";
            rectangle4.Name = "rectangle4";

            NameScope.SetNameScope(this, new NameScope());
            this.RegisterName(rectangle4.Name, rectangle4);

            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 0;
            myDoubleAnimation.To = constructPercent * rectangle0.ActualHeight;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(5));
            Storyboard.SetTargetName(myDoubleAnimation, rectangle4.Name);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Rectangle.HeightProperty));


            Storyboard myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myDoubleAnimation);
            myStoryboard.AutoReverse = false;
            myStoryboard.Begin(this);

        }

        void drawFeeAni()
        {
            this.Name = "PageProject";
            rectangle3.Name = "rectangle3";

            NameScope.SetNameScope(this, new NameScope());
            this.RegisterName(rectangle3.Name, rectangle3);

            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 0;
            myDoubleAnimation.To = totalPercent * rectangle0.ActualHeight;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(5));
            Storyboard.SetTargetName(myDoubleAnimation, rectangle3.Name);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Rectangle.HeightProperty));


            Storyboard myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myDoubleAnimation);
            myStoryboard.AutoReverse = false;

            myStoryboard.Begin(this);
        

        }

        double totalPercent = 0d;
        void drawFeePercentList()
        {
            double nowTop = rectangle0.Margin.Top;

            for (int i = 0; i < percentList.Count;i++ )
            {
                //当前进度的高度
                double percentHeight = actualPercentList[i] * rectangle0.ActualHeight;
                Rectangle rect = createRectangle(nowTop, percentHeight, Brushes.CadetBlue , Brushes.Transparent);
                FeeGrid.Children.Add(rect);
                rect.SetValue(Grid.ColumnProperty, 0);                  //设置按钮所在Grid控件的列
              
                //当前进度条的上部margin
                nowTop = nowTop + percentList[i] * rectangle0.ActualHeight;

                Ellipse ellipse = createEllipse(nowTop, percentHeight, Brushes.CadetBlue , Brushes.Transparent);
                FeeGrid.Children.Add(ellipse);
                ellipse.SetValue(Grid.ColumnProperty, 0);                  //设置按钮所在Grid控件的列
            }

        }


        
        /// <summary>
        /// 绘制矩形
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="fillBrush"></param>
        /// <param name="strokeBrush"></param>
        /// <returns></returns>
        Rectangle createRectangle(double top,double height,Brush fillBrush,Brush strokeBrush)
        {
            // Create a Rectangle
            Rectangle rectangle = new Rectangle();
            rectangle.Height = height;
            rectangle.Width = 14 ;

            rectangle.Margin = new Thickness(0, top, 0, 0);

            // Set Rectangle's width and color
            rectangle.StrokeThickness =0;
            rectangle.Stroke = strokeBrush;
            // Fill rectangle with blue color
            rectangle.Fill = fillBrush;
            rectangle.VerticalAlignment = VerticalAlignment.Top;

            rectangle.RadiusX = 5;
            rectangle.RadiusY = 5;

            return rectangle;
        }


        Ellipse createEllipse(double top, double height, Brush fillBrush, Brush strokeBrush)
        {
            // Create a Rectangle
            Ellipse ellipse = new Ellipse();
            ellipse.Height = 10;
            ellipse.Width = 14;

            ellipse.Margin = new Thickness(0, top-5, 0, 0);

            // Set Rectangle's width and color
            ellipse.StrokeThickness = 0;
            ellipse.Stroke = strokeBrush;
            // Fill rectangle with blue color
            ellipse.Fill = fillBrush;
            ellipse.VerticalAlignment = VerticalAlignment.Top;
            return ellipse;
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                //do work when tab is changed
                string selected = (TabProject.SelectedItem as TabItem).Header.ToString();
                if (selected.Equals("建设情况"))
                {
                    drawConsAni();
                }
                else if (selected.Equals("经费使用"))
                {
                    if (!isChoosen)
                    {
                        drawFeePercentList();
                        isChoosen = true;
                    }

                    drawFeeAni();
                }
            }


        }

        private bool isChoosen = false;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string content = btn.Content as string;
            PDFReader pdfReader = new PDFReader();
            pdfReader.showPdf(content + ".pdf");
        }


    }


    class Information
    {
        public string ImageSource { get; set; }
        public string FileDate { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
    }

}
