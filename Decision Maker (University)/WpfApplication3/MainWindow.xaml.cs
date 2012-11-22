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
using System.Windows.Shapes;
using System.IO;
using System.Windows.Threading;
using System.Diagnostics;
using System.Xml;
using WpfZhihui;
using WpfApplication3.LargeProject;

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string strPATH;
        private List<NewsItem> items = new List<NewsItem>();
        //-------------------------------------------------------------
        public MainWindow()
        {
            InitializeComponent();
            DirectoryInfo di;
            di = new DirectoryInfo(System.Environment.CurrentDirectory);
            strPATH = di.Parent.Parent.FullName;
            wb_weibo.Navigate(new Uri(strPATH + @"/html/weibo.htm"));
            LoadRss();
            DispatcherTimer timer = new DispatcherTimer();
            //设置间隔1秒
            timer.Interval = new TimeSpan(0, 0, 1);
            //创建事件处理
            timer.Tick += new EventHandler(timer_Tick);
            //开始计时
            timer.Start();


            Home_Click(new object(), new RoutedEventArgs());
        }
        void timer_Tick(object sender, EventArgs e)
        {
            DateHelper datehelper = new DateHelper();
            labe_time.Content = datehelper.getTime();
            label_day.Content = datehelper.getDay();
            label_dayofweek.Content = datehelper.getDayofWeek();
            label_month.Content = datehelper.getMonth();
            label_dayofweek_zh.Content = datehelper.getDayofWeekzh();
            label_month.Content = datehelper.getMonth();
            label_month_zh.Content = datehelper.getMonthzh();
        }

        private void Menu1Btn1_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            if (Menu_1_1_1.Visibility == System.Windows.Visibility.Collapsed)
            {
                Menu_1_1_1.Visibility = System.Windows.Visibility.Visible;
                Menu_1_2.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_3.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_4.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_5.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_6.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_7.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_8.Visibility = System.Windows.Visibility.Collapsed;
                MenuBg1.Fill = (Brush)Window.Resources["leftcontentmenu2"];
                Menutext1.Foreground = (Brush)Window.Resources["white"];
            }

            else
            {
                Menu_1_1_1.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_2.Visibility = System.Windows.Visibility.Visible;
                Menu_1_3.Visibility = System.Windows.Visibility.Visible;
                Menu_1_4.Visibility = System.Windows.Visibility.Visible;
                Menu_1_5.Visibility = System.Windows.Visibility.Visible;
                Menu_1_6.Visibility = System.Windows.Visibility.Visible;
                Menu_1_7.Visibility = System.Windows.Visibility.Visible;
                Menu_1_8.Visibility = System.Windows.Visibility.Visible;
                MenuBg1.Fill = (Brush)Window.Resources["leftcontentmenu1"];
                Menutext1.Foreground = (Brush)Window.Resources["black"];
            }
        }
        private void Menu1Btn2_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            if (Menu_1_2_1.Visibility == System.Windows.Visibility.Collapsed)
            {
                Menu_1_2_1.Visibility = System.Windows.Visibility.Visible;
                Menu_1_1.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_3.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_4.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_5.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_6.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_7.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_8.Visibility = System.Windows.Visibility.Collapsed;
                MenuBg2.Fill = (Brush)Window.Resources["leftcontentmenu2"];
                Menutext2.Foreground = (Brush)Window.Resources["white"];
            }

            else
            {
                Menu_1_2_1.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_1.Visibility = System.Windows.Visibility.Visible;
                Menu_1_3.Visibility = System.Windows.Visibility.Visible;
                Menu_1_4.Visibility = System.Windows.Visibility.Visible;
                Menu_1_5.Visibility = System.Windows.Visibility.Visible;
                Menu_1_6.Visibility = System.Windows.Visibility.Visible;
                Menu_1_7.Visibility = System.Windows.Visibility.Visible;
                Menu_1_8.Visibility = System.Windows.Visibility.Visible;
                MenuBg2.Fill = (Brush)Window.Resources["leftcontentmenu1"];
                Menutext2.Foreground = (Brush)Window.Resources["black"];
            }
        }
        private void Menu1Btn3_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            if (Menu_1_3_1.Visibility == System.Windows.Visibility.Collapsed)
            {
                Menu_1_3_1.Visibility = System.Windows.Visibility.Visible;
                Menu_1_1.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_2.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_4.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_5.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_6.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_7.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_8.Visibility = System.Windows.Visibility.Collapsed;
                MenuBg3.Fill = (Brush)Window.Resources["leftcontentmenu2"];
                Menutext3.Foreground = (Brush)Window.Resources["white"];
            }

            else
            {
                Menu_1_3_1.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_1.Visibility = System.Windows.Visibility.Visible;
                Menu_1_2.Visibility = System.Windows.Visibility.Visible;
                Menu_1_4.Visibility = System.Windows.Visibility.Visible;
                Menu_1_5.Visibility = System.Windows.Visibility.Visible;
                Menu_1_6.Visibility = System.Windows.Visibility.Visible;
                Menu_1_7.Visibility = System.Windows.Visibility.Visible;
                Menu_1_8.Visibility = System.Windows.Visibility.Visible;
                MenuBg3.Fill = (Brush)Window.Resources["leftcontentmenu1"];
                Menutext3.Foreground = (Brush)Window.Resources["black"];
            }
        }
        private void Menu1Btn4_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            if (Menu_1_4_1.Visibility == System.Windows.Visibility.Collapsed)
            {
                Menu_1_4_1.Visibility = System.Windows.Visibility.Visible;
                Menu_1_1.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_2.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_3.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_5.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_6.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_7.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_8.Visibility = System.Windows.Visibility.Collapsed;
                MenuBg4.Fill = (Brush)Window.Resources["leftcontentmenu2"];
                Menutext4.Foreground = (Brush)Window.Resources["white"];
            }

            else
            {
                Menu_1_4_1.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_1.Visibility = System.Windows.Visibility.Visible;
                Menu_1_2.Visibility = System.Windows.Visibility.Visible;
                Menu_1_3.Visibility = System.Windows.Visibility.Visible;
                Menu_1_5.Visibility = System.Windows.Visibility.Visible;
                Menu_1_6.Visibility = System.Windows.Visibility.Visible;
                Menu_1_7.Visibility = System.Windows.Visibility.Visible;
                Menu_1_8.Visibility = System.Windows.Visibility.Visible;
                MenuBg4.Fill = (Brush)Window.Resources["leftcontentmenu1"];
                Menutext4.Foreground = (Brush)Window.Resources["black"];
            }
        }
        private void Menu1Btn5_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            if (Menu_1_5_1.Visibility == System.Windows.Visibility.Collapsed)
            {
                Menu_1_5_1.Visibility = System.Windows.Visibility.Visible;
                Menu_1_1.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_2.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_3.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_4.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_6.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_7.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_8.Visibility = System.Windows.Visibility.Collapsed;
                MenuBg5.Fill = (Brush)Window.Resources["leftcontentmenu2"];
                Menutext5.Foreground = (Brush)Window.Resources["white"];
            }

            else
            {
                Menu_1_5_1.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_2.Visibility = System.Windows.Visibility.Visible;
                Menu_1_3.Visibility = System.Windows.Visibility.Visible;
                Menu_1_4.Visibility = System.Windows.Visibility.Visible;
                Menu_1_1.Visibility = System.Windows.Visibility.Visible;
                Menu_1_6.Visibility = System.Windows.Visibility.Visible;
                Menu_1_7.Visibility = System.Windows.Visibility.Visible;
                Menu_1_8.Visibility = System.Windows.Visibility.Visible;
                MenuBg5.Fill = (Brush)Window.Resources["leftcontentmenu1"];
                Menutext5.Foreground = (Brush)Window.Resources["black"];
            }
        }
        private void Menu1Btn6_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            if (Menu_1_6_1.Visibility == System.Windows.Visibility.Collapsed)
            {
                Menu_1_6_1.Visibility = System.Windows.Visibility.Visible;
                Menu_1_1.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_2.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_4.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_5.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_3.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_7.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_8.Visibility = System.Windows.Visibility.Collapsed;

            }

            else
            {
                Menu_1_6_1.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_1.Visibility = System.Windows.Visibility.Visible;
                Menu_1_2.Visibility = System.Windows.Visibility.Visible;
                Menu_1_4.Visibility = System.Windows.Visibility.Visible;
                Menu_1_5.Visibility = System.Windows.Visibility.Visible;
                Menu_1_3.Visibility = System.Windows.Visibility.Visible;
                Menu_1_7.Visibility = System.Windows.Visibility.Visible;
                Menu_1_8.Visibility = System.Windows.Visibility.Visible;
            }
        }
        private void Menu1Btn7_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            if (Menu_1_7_1.Visibility == System.Windows.Visibility.Collapsed)
            {
                Menu_1_7_1.Visibility = System.Windows.Visibility.Visible;
                Menu_1_1.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_2.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_3.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_5.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_6.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_4.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_8.Visibility = System.Windows.Visibility.Collapsed;
                MenuBg7.Fill = (Brush)Window.Resources["leftcontentmenu2"];
                Menutext7.Foreground = (Brush)Window.Resources["white"];
            }

            else
            {
                Menu_1_7_1.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_1.Visibility = System.Windows.Visibility.Visible;
                Menu_1_2.Visibility = System.Windows.Visibility.Visible;
                Menu_1_3.Visibility = System.Windows.Visibility.Visible;
                Menu_1_5.Visibility = System.Windows.Visibility.Visible;
                Menu_1_6.Visibility = System.Windows.Visibility.Visible;
                Menu_1_4.Visibility = System.Windows.Visibility.Visible;
                Menu_1_8.Visibility = System.Windows.Visibility.Visible;
                MenuBg7.Fill = (Brush)Window.Resources["leftcontentmenu1"];
                Menutext7.Foreground = (Brush)Window.Resources["black"];
            }
        }
        private void Menu1Btn8_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            if (Menu_1_8_1.Visibility == System.Windows.Visibility.Collapsed)
            {
                Menu_1_8_1.Visibility = System.Windows.Visibility.Visible;
                Menu_1_1.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_2.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_3.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_4.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_6.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_7.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_5.Visibility = System.Windows.Visibility.Collapsed;
                MenuBg8.Fill = (Brush)Window.Resources["leftcontentmenu2"];
                Menutext8.Foreground = (Brush)Window.Resources["white"];
            }

            else
            {
                Menu_1_8_1.Visibility = System.Windows.Visibility.Collapsed;
                Menu_1_2.Visibility = System.Windows.Visibility.Visible;
                Menu_1_3.Visibility = System.Windows.Visibility.Visible;
                Menu_1_4.Visibility = System.Windows.Visibility.Visible;
                Menu_1_1.Visibility = System.Windows.Visibility.Visible;
                Menu_1_6.Visibility = System.Windows.Visibility.Visible;
                Menu_1_7.Visibility = System.Windows.Visibility.Visible;
                Menu_1_5.Visibility = System.Windows.Visibility.Visible;
                MenuBg8.Fill = (Brush)Window.Resources["leftcontentmenu1"];
                Menutext8.Foreground = (Brush)Window.Resources["black"];
            }
        }

        private void imageTVCover_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Dongfangweishi.IsSelected = true;
        }
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string ix = (e.AddedItems[0].ToString().Split(' '))[1];
            if (ix == "东方卫视")
            {
                imageTVCover.Visibility = Visibility.Hidden;
                WebBrowserTV.Visibility = Visibility.Visible;
                WebBrowserTV.Navigate(new Uri(strPATH + @"/html/zhiboDongfangweishi.htm", UriKind.RelativeOrAbsolute));

            }
            else if (ix == "CCTV新闻")
            {
                imageTVCover.Visibility = Visibility.Hidden;
                WebBrowserTV.Visibility = Visibility.Visible;

                DirectoryInfo di;
                di = new DirectoryInfo(System.Environment.CurrentDirectory);
                string strpath = di.Parent.Parent.FullName;
                WebBrowserTV.Navigate(new Uri(strpath + @"/html/zhiboCCTV13.htm", UriKind.RelativeOrAbsolute));
            }
            else if (ix == "CCTV体育")
            {
                imageTVCover.Visibility = Visibility.Hidden;
                WebBrowserTV.Visibility = Visibility.Visible;
                WebBrowserTV.Navigate(new Uri(strPATH + @"/html/zhiboCCTV5.htm", UriKind.RelativeOrAbsolute));
            }
            else if (ix == "五星体育")
            {
                imageTVCover.Visibility = Visibility.Hidden;
                WebBrowserTV.Visibility = Visibility.Visible;
                WebBrowserTV.Navigate(new Uri(strPATH + @"/html/zhiboWuxingtiyu.htm", UriKind.RelativeOrAbsolute));
            }

        }

        public void LoadRss()
        {
            string[] rsspath ={ "http://news.tongji.edu.cn/rss.php?classid=6",
                                   //"http://www.xinhuanet.com/politics/news_politics.xml",
                                   "http://news.tongji.edu.cn/rss.php?classid=7",
                                   "http://news.tongji.edu.cn/rss.php?classid=8"
                                   ,"http://news.tongji.edu.cn/rss.php?classid=10"
                              };//RSS地址
            string[] channeltitle ={"同济大学综合新闻",
                                   //"新华时政",
                                   "同济大学教学新闻",
                                   "同济大学科研新闻"
                                   ,"同济大学外事新闻"
                                   };
            string[] channellink ={"http://news.tongji.edu.cn/classid-176.html",
                                   //"http://www.xinhuanet.com/politics/xw.htm",
                                   "http://news.tongji.edu.cn/classid-176.html",
                                   "http://news.tongji.edu.cn/classid-176.html"
                                   ,"http://news.tongji.edu.cn/classid-176.html"
                                  };
            string[] logopath = {
                                "/Images/网易2.png",
                                //"/Images/新华1.jpg",
                                "/Images/百度.png",
                                "/Images/上海热线.jpg"
                                ,"/Images/sina.png"
                                };
            for (int cid = 0; cid < 4; cid++)
            {
                XmlDocument doc = new XmlDocument();//创建文档对象
                try
                {
                    doc.Load(rsspath[cid]);//加载XML 包括HTTP：// 和本地
                }
                catch (Exception)
                {
                    //异常处理
                }
                //初始化Rss 
                XmlNodeList list = doc.GetElementsByTagName("item"); //获得项   
                XmlNode node = list.Item(0);//
                NewsItem item = new NewsItem();
                item = getItem((XmlElement)node);
                item.ChannelLink = channellink[cid];
                item.ChannelTitle = channeltitle[cid];
                item.LogoPath = logopath[cid];
                //加入list
                items.Add(item);
            }

            //添加绑定操作
            this.Rsslist.ItemsSource = items;
        }
        private NewsItem getItem(XmlElement ele)
        {
            NewsItem item = new NewsItem();
            item.Title = ele.GetElementsByTagName("title")[0].InnerText;//获得标题
            item.Link = ele.GetElementsByTagName("link")[0].InnerText;//获得联接
            string des = ele.GetElementsByTagName("description")[0].InnerText;//获得简介
            if (des.Length > 80)
            {
                des = des.Substring(0, 80) + "……";
            }
            item.Description = des;
            //item.PubDate = ele.GetElementsByTagName("pubDate")[0].InnerText;//获得发布日期
            return item;
        }

        private void weibo_topic_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string topic = weibo_topic.Text;
                WeiboHelper weibohelper = new WeiboHelper();
                weibohelper.settopic(topic);
                wb_weibo.Navigate(new Uri(strPATH + @"/bin/Debug/weibo.htm"));
            }
        }
        private void weibo_topic_GotMouseCapture(object sender, System.Windows.Input.MouseEventArgs e)
        {
            // TODO: Add event handler implementation here.
            weibo_topic.Text = "";
        }
        private void weibo_search_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            string topic = weibo_topic.Text;
            WeiboHelper weibohelper = new WeiboHelper();
            weibohelper.settopic(topic);
            wb_weibo.Navigate(new Uri(strPATH + @"/bin/Debug/weibo.htm"));
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;

        }

        private void Home_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            HomePage m_HomePage = new HomePage();
            FrameMiddleContent.Navigate(m_HomePage);
        }

        private void btn_sgzh_Click(object sender, RoutedEventArgs e)
        {
            PageShiGuZaiHai m_PageShiGuZaiHai = new PageShiGuZaiHai();
            FrameMiddleContent.Navigate(m_PageShiGuZaiHai);
        }

        private void Btn_Design_Click(object sender, RoutedEventArgs e)
        {
            PageProject m_PageProject = new PageProject();
            FrameMiddleContent.Navigate(m_PageProject);
        }


    }
}
