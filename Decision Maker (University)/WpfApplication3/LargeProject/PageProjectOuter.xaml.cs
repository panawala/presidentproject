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
    public partial class PageProjectGym : Page
    {
        public PageProjectGym()
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
            ImageSolution.Source = new BitmapImage(new Uri("/Images/outer.jpg", UriKind.Relative));
            //image_ProjectOrg.Source=new BitmapImage(new Uri("/Images/projectorg.jpg",UriKind.Relative));

            TextProject.Text = "都柏林大学位于爱尔兰都柏林市郊南面一片广袤而美丽的土地上，距市中心只有5公里。都柏林大学（UCD）是一所朝气蓬勃的现代大学，也是爱尔兰规模最大的大学，课程设置包括人文、工商、社会学、医学、兽医学和自然科学等学士学位课程及研究生课程。都柏林大学致力于提供一流的教学和科研教育。";


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
