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
    public partial class PageProjectOuter : Page
    {
        public PageProjectOuter()
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
            CurrentSence.Source = new BitmapImage(new Uri("/Images/gymsecene.jpg", UriKind.Relative));
            ImageSolution.Source = new BitmapImage(new Uri("/Images/gym.jpg", UriKind.Relative));
            //image_ProjectOrg.Source=new BitmapImage(new Uri("/Images/projectorg.jpg",UriKind.Relative));

            TextProject.Text = "吉安体育馆位于吉安市城南新区，始建于2005年7月，2009年12月全面竣工并投入使用。体育馆建筑构造为钢网架结构，总建筑面积为20695平方米，馆内篮球场地面积为2300平方米，体育馆总投资达7300万元。馆内中央为比赛大厅，观众座位有5194个，其中移动座位有829个，北面观众看台设有主席台和贵宾席。馆内首层设有贵宾休息室、运动员休息室、会议室、医务室、兴奋剂检测室、新闻发布中心、检录大厅、转播间等34个房间，二楼有12个进出口，观众出入方便。馆内通风透光合理，装修实用大方，体育馆以现代化、标准化要求安装了中央空调、音响系统与电子计时计分系统，现场灯光达1500勒克斯，还配置了宽频光纤信息网，能实现电脑联网信息资信共享和电视拍摄、转播及播放录像、影蝶、图文信息。吉安体育馆将承办“七城会” U16男子篮球赛，是吉安唯一一座集体育、休闲、健身、娱乐于一体的综合性场馆。 ";


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

                if (i == 0)
                {
                    rectangle11.Name = "rectangle11";
                    rectangle11.Fill = Brushes.CadetBlue;
                    rectangle11.VerticalAlignment = VerticalAlignment.Top;
                    rectangle11.Height = percentHeight;
                    rectangle11.Width = 14;
                    rectangle11.Margin = new Thickness(0, nowTop, 0, 0);
                    NameScope.SetNameScope(this, new NameScope());
                    this.RegisterName(rectangle11.Name, rectangle11);
                }
                else if (i == 1)
                {
                    rectangle12.Name = "rectangle12";
                    rectangle12.Fill = Brushes.CadetBlue;
                    rectangle12.VerticalAlignment = VerticalAlignment.Top;
                    rectangle12.Height = percentHeight;
                    rectangle12.Width = 14;
                    rectangle12.Margin = new Thickness(0, nowTop, 0, 0);
                    this.RegisterName(rectangle12.Name, rectangle12);
                }
                else if (i == 2)
                {
                    rectangle13.Name = "rectangle13";
                    rectangle13.Fill = Brushes.CadetBlue;
                    rectangle13.VerticalAlignment = VerticalAlignment.Top;
                    rectangle13.Height = percentHeight;
                    rectangle13.Width = 14;
                    rectangle13.Margin = new Thickness(0, nowTop, 0, 0);
                    this.RegisterName(rectangle13.Name, rectangle13);
                }
                else if (i == 3)
                {
                    rectangle14.Name = "rectangle14";
                    rectangle14.Fill = Brushes.CadetBlue;
                    rectangle14.VerticalAlignment = VerticalAlignment.Top;
                    rectangle14.Height = percentHeight;
                    rectangle14.Width = 14;
                    rectangle14.Margin = new Thickness(0, nowTop, 0, 0);
                    this.RegisterName(rectangle14.Name, rectangle14);
                }


                //Rectangle rect = createRectangle(nowTop, percentHeight, Brushes.CadetBlue , Brushes.Transparent);
                //rect.Name="myName"+i;

                //FeeGrid.Children.Add(rect);
                //rect.SetValue(Grid.ColumnProperty, 0);                  //设置按钮所在Grid控件的列
                //FeeGrid.RegisterName("myName" + i, rect);


                DoubleAnimation myDoubleAnimation = new DoubleAnimation();
                myDoubleAnimation.From = 0;
                myDoubleAnimation.To = percentHeight;
                myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(5));
                if(i==0)
                    Storyboard.SetTargetName(myDoubleAnimation, rectangle11.Name);
                else if(i==1)
                    Storyboard.SetTargetName(myDoubleAnimation, rectangle12.Name);
                else if (i == 2)
                    Storyboard.SetTargetName(myDoubleAnimation, rectangle13.Name);
                else if (i == 3)
                    Storyboard.SetTargetName(myDoubleAnimation, rectangle14.Name);
                Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Rectangle.HeightProperty));
                Storyboard myStoryboard = new Storyboard();
                myStoryboard.Children.Add(myDoubleAnimation);
                myStoryboard.AutoReverse = false;
                myStoryboard.Begin(this);


                
              
                //当前进度条的上部margin
                nowTop = nowTop + percentList[i] * rectangle0.ActualHeight;

                //以下用来绘制圆点
                //Ellipse ellipse = createEllipse(nowTop, percentHeight, Brushes.CadetBlue , Brushes.Transparent);
                //FeeGrid.Children.Add(ellipse);
                //ellipse.SetValue(Grid.ColumnProperty, 0);                  //设置按钮所在Grid控件的列
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
                    //if (!isChoosen)
                    //{
                    //    drawFeePercentList();
                    //    isChoosen = false;
                    //}
                    drawFeePercentList();
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


}
