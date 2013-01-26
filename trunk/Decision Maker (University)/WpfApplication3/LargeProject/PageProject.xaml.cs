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
        public PageProject(int projectId)
        {
            InitializeComponent();
            projectID = projectId;
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
        private double constructPercent = 0.6d;
        private double planPercent = 0.8d;
        private double buildPercent = 0.4d;
        private int projectID;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            percentList = new List<double> { 0.3, 0.4, 0.2, 0.1 };
            actualPercentList = new List<double> { 0.2, 0.2, 0.1, 0.05 };

            BitmapImage image = new BitmapImage(new Uri("/Images/sence" + projectID + ".jpg", UriKind.Relative));
            

            CurrentSence.Source = image;
            ImageSolution.Source = new BitmapImage(new Uri("/Images/solute" + projectID + ".jpg", UriKind.Relative));
            //image_ProjectOrg.Source=new BitmapImage(new Uri("/Images/projectorg.jpg",UriKind.Relative));
            switch (projectID)
            {
                case 1:
                    TextProject.Text = "2009年5月26日，设计创意学院成立。全国人大常委、原教育部副部长吴启迪，杨浦区委书记陈安杰、区长宗明，我校党委书记周家伦、校长裴钢、常务副校长李永盛，副校长陈小龙、伍江、董琦，瑞安集团主席罗康瑞，我校董事会董事陈经纬、张松，以及十多所国内外知名设计院校负责人等出席学院成立仪式。";
                    break;
                case 2:
                    TextProject.Text = "同济大学新建四平路校区体育场馆及地下附属设施项目。该为新建一幢精装修体育馆，设有地下车库。总建筑面积39500平方米,其中地上8500平方米,地下31000平方米。一项综合发展,总建筑面积39,500平方米,包括:两层高的体育场馆两层高的地下停车库辅助用房主体结构:钢结构,外墙材料:石材幕墙,空调系统:大型中央空调,门窗系统:铝合金门窗,电梯系统:未透露供暖系统:不使用装修情况：精装修建筑 同济大学新建四平路校区体育场馆及地下附属设施项目";
                    break;
                case 3:
                    TextProject.Text = "同济大学国际文化交流学院成立于1998年，是专门从事对外汉语教学和科研的二级学院。目前共有来自108个国家的六百多名外国留学生在院学习汉语，其中汉语言本科留学生近百名。学院拥有一支年龄结构，学科结构较为合理的师资队伍。学院现任院长为陈强教授。同济大学开展对外汉语教学的历史始于20世纪70年代，学校恢复招收外国留学生以后，即专门安排汉语教师为进入专业学习的外国留学生开设专业汉语课。1987年起，开设汉语言短训班，招收汉语言短期生，从1993年起，学校开始自行承担外国留学生进入专业前的汉语培训任务，从2002年起，学院招收汉语言专业本科留学生，2006年7月首届本科生顺利毕业。在长达30多年的对外汉语教学实践中，我校依托城市建设，建筑历史，旅游文化，经济管理等学科优势，走对外汉语教学与专业交融之路，受到外国留学生的欢迎。";        
                    break;
                case 4:
                    TextProject.Text = "同济大学是中国教育部直属全国重点高校，国家“211工程”和“985工程”重点建设高校，创建于1907年，取名“同济”意蕴合作共济。经过百年奋斗，同济大学已发展成为已拥有理、工、医、文、法、哲、经济、管理、教育九大学科门类的综合性大学。   同济大学现有建筑与城市规划、土木工程、经济与管理、电子与信息工程、环境科学与工程等。目前学校共有74个本科专业、263个硕士点、14个硕士专业学位授权点，博士授权点144个，19个博士后流动站，各类学生近5万人，教学科研人员6000多人，其中有中科院院士6人，工程院院士7人，教授等正高级职称者860多人，副教授等副高级职称者1380多人。作为国家重要的科研中心之一，学校有国家级和省部级重点实验室和工程研究中心30个。学校还设有6个附属医院和3所附属学校。同济大学已建成的校园占地面积3857亩，分四个校区。";
                    break;
                case 5:
                    TextProject.Text = "意大利是闻名世界的创意设计强国，佛罗伦萨则是文艺复兴的发源地，众多世界名校在此设立海外校区已有近百年的传统。近年来，在两国政府的支持下，中国和意大利在设计创意方面的合作呈现快速发展的趋势，以设计为主题的交流合作十分活跃。2011年4月，中国科技部部长万钢与意大利创新部共同在同济大学成立“中意设计创新中心”，并与意大利托斯卡纳大区就创新合作签署了协议。在此背景下，经过一年多的考察与洽谈，以“上海－佛罗伦萨中意设计交流中心”为依托，我校与佛罗伦萨市政府和托斯卡纳大区政府就设立同济大学佛罗伦萨校区达成协议。      我校将通过佛罗伦萨海外校区积极推动与佛罗伦萨大学等意大利大学及欧洲、美国等在佛罗伦萨的教育机构之间的合作，多方面引进整合国际化教育资源，在艺术、设计、建筑、时尚、文化遗产保护等学科领域开设各类长短期课程，并辅以人文学科，如西方艺术史、文艺复兴研究、国际政治等领域的通识课，打造我校在意大利乃至欧洲的高水平人才交流培训基地，为推动实施“3个600”国际化人才培养战略创造更好的境外学习条件，打造同济特色的海外学习课程平台。";
                    break;
                case 6:
                    TextProject.Text = "上海张江高科技园区自1992年成立以来，一直被国际同行称为“The Silicon and Medicine Valley in China”而享中国的硅谷与药谷誉世界，经过近二十年的开发， 园区构筑了生物医药创新链，集成电路产业链和软件产业链的框架。目前，园区建有国家上海生物医药科技产业基地、国家信息产业基地、国家集成电路产业基地、国家半导体照明产业基地、国家863信息安全成果产业化（东部）基地、国家软件产业基地、国家软件出口基地、国家文化产业示范基地、国家网游动漫产业发展基地等多个国家级基地。在科技创新方面，园区拥有多模式、多类型的孵化器，建有国家火炬创业园、国家留学人员创业园，一批新经济企业实现了大踏步的飞跃，目前的张江正向着世界级高科技园区的愿景目标阔步前进。";
                    break;
            }
           
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
            label6.Content = "完成情况：" + constructPercent * 100 + "%";
            lb_build.Content = "建设完成度：" + buildPercent * 100 + "%";
            lb_plan.Content = "规划完成度：" + planPercent * 100 + "%";
            label5.Content = "使用情况：" + totalPercent * 100 + "%";
            drawConsAni();

        }



        void drawConsAni()
        {
            this.Name = "PageProject";
            rectangle4.Name = "rectangle4";

            NameScope.SetNameScope(this, new NameScope());
            this.RegisterName(rectangle4.Name, rectangle4);

            this.RegisterName(rect_plan2.Name, rect_plan2);
            this.RegisterName(rect_build2.Name, rect_build2);
            //完成情况/
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 0;
            myDoubleAnimation.To = constructPercent * rectangle0.ActualHeight;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(5));
            Storyboard.SetTargetName(myDoubleAnimation, rectangle4.Name);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Rectangle.HeightProperty));
            //规划部分
            DoubleAnimation myPlanAnimation = new DoubleAnimation();
            myPlanAnimation.From = 0;
            myPlanAnimation.To = planPercent * rect_plan1.ActualHeight;
            myPlanAnimation.Duration = new Duration(TimeSpan.FromSeconds(5));
            Storyboard.SetTargetName(myPlanAnimation, rect_plan2.Name);
            Storyboard.SetTargetProperty(myPlanAnimation, new PropertyPath(Rectangle.HeightProperty));
            //建设部分
            
            DoubleAnimation myBuildAnimation = new DoubleAnimation();
            myBuildAnimation.From = 0;
            myBuildAnimation.To = buildPercent * rect_build1.ActualHeight;
            myBuildAnimation.Duration = new Duration(TimeSpan.FromSeconds(5));
            Storyboard.SetTargetName(myBuildAnimation, rect_build2.Name);
            Storyboard.SetTargetProperty(myBuildAnimation, new PropertyPath(Rectangle.HeightProperty));

            Storyboard myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myDoubleAnimation);
            myStoryboard.Children.Add(myPlanAnimation);
            myStoryboard.Children.Add(myBuildAnimation);
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


    class Information
    {
        public string ImageSource { get; set; }
        public string FileDate { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
    }

}
