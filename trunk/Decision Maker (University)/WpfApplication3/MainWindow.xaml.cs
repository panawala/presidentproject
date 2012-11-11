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
using System.Diagnostics;
using System.Xml;
using WpfZhihui;
using System.IO;
using System.Net;
using System.Data;
using System.Runtime.Serialization.Json;
//using System.Web;
using System.Runtime.Serialization;
using mshtml;
using System.Windows.Threading;
using WpfApplication3;
//using ESRI.ArcGIS.ADF.CATIDs;
//using ESRI.ArcGIS.Controls;
//using ESRI.ArcGIS.Geometry;
//using ESRI.ArcGIS.Display;
//using ESRI.ArcGIS.Carto;
//using ESRI.ArcGIS.ADF.BaseClasses;
//using ESRI.ArcGIS.esriSystem;
using System.Threading;
using WpfApplication3.EggModel;
//using ESRI.ArcGIS.Geodatabase;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.ComponentModel;



namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // 回调句柄定义
        static AnyChatCoreSDK.NotifyMessage_CallBack OnNotifyMessageCallback = new
            AnyChatCoreSDK.NotifyMessage_CallBack(NotifyMessage_CallBack);

        static AnyChatCoreSDK.VideoData_CallBack OnVideoDataCallback = new
            AnyChatCoreSDK.VideoData_CallBack(VideoData_CallBack);

        // 委托句柄定义
        public static AnyChatCoreSDK.NotifyMessage_CallBack NotifyMessageHandler = null;
        public static AnyChatCoreSDK.VideoData_CallBack VideoDataHandler = null;

        public static int g_selfUserId = -1;
        public static int g_otherUserId = -1;
        //AxMapControl mapControl;
        //AxToolbarControl toolbarControl;
        static int LENGTH = 1000;
        private List<NewsItem> items = new List<NewsItem>();
        string strPATH;
        public MainWindow()
        {
            this.InitializeComponent();

            DirectoryInfo di;
            di = new DirectoryInfo(System.Environment.CurrentDirectory);
            strPATH = di.Parent.Parent.FullName;
            ///导入RSS推送信息
            // Insert code required on object creation below this point.

            string pathTraffic = di.Parent.Parent.FullName;
            wbTraffic.Navigate(new Uri(pathTraffic + @"/html/Traffic.htm", UriKind.RelativeOrAbsolute));
            //wbTraffic.Document.documentElement.style.overflow = "hidden"; //隐藏浏览器的滚动条
            string pathEmergency = di.Parent.Parent.FullName;
            ds = new EmergencyBasic();
            wbEmergency.Navigate(new Uri(pathEmergency + @"/html/Emergency.htm", UriKind.RelativeOrAbsolute));//获取根目录的日历文件
            wbEmergency.ObjectForScripting = ds;//该对象可由显示在WebBrowser控件中的网页所包含的脚本代码访问
            wb_weibo.Navigate(new Uri(pathEmergency + @"/html/weibo.htm"));
            wbenvironment.Navigate(new Uri(pathEmergency + @"/html/PM25.htm", UriKind.RelativeOrAbsolute));
            /*string pathEnvironment = di.Parent.Parent.FullName;
            ds1 = new EnvironmentBasic();
            wbenvironment.Navigate(new Uri(pathEnvironment + @"/html/Environment.htm", UriKind.RelativeOrAbsolute));//获取根目录的日历文件
            wbenvironment.ObjectForScripting = ds1;//该对象可由显示在WebBrowser控件中的网页所包含的脚本代码访问*/
            LoadRss();
            //建立线程动态更新时间
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

        public void HideEveryContent()
        {
            gridSendCopy.Visibility = System.Windows.Visibility.Hidden;
            btnSendCopy.IsEnabled = false;
            mainContent.Visibility = System.Windows.Visibility.Hidden;
            mainContent2.Visibility = System.Windows.Visibility.Hidden;
            mainContent3.Visibility = System.Windows.Visibility.Hidden;
            mainContent4.Visibility = System.Windows.Visibility.Hidden;
            mainContent5.Visibility = System.Windows.Visibility.Hidden;
            mainContent6.Visibility = System.Windows.Visibility.Hidden;
            mainContent7.Visibility = System.Windows.Visibility.Hidden;
            mainContent8_ZiRanZaiHai.Visibility = System.Windows.Visibility.Hidden;
            Emergency.Visibility = System.Windows.Visibility.Hidden;
            Traffic.Visibility = System.Windows.Visibility.Hidden;
            Environment.Visibility = System.Windows.Visibility.Hidden;
            Weather.Visibility = System.Windows.Visibility.Hidden;
            WeatherInfo.Visibility = System.Windows.Visibility.Hidden;
            GridCalender.Visibility = System.Windows.Visibility.Hidden;
            MaxEmergency.Visibility = System.Windows.Visibility.Hidden;
            MaxWeather.Visibility = System.Windows.Visibility.Hidden;
            MaxTraffic.Visibility = System.Windows.Visibility.Hidden;
            MaxEnvironment.Visibility = System.Windows.Visibility.Hidden;
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

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadWeather();
        }

        public void loadWeather()
        {
            WeatherWebService.WeatherWebServiceSoapClient ws = new WeatherWebService.WeatherWebServiceSoapClient();
            string[] strWeather = ws.getWeatherbyCityName("上海");
            BitmapImage image = new BitmapImage(new Uri(strPATH + @"/weatherlogo/a_" + strWeather[8], UriKind.RelativeOrAbsolute));
            w_image1.Source = image;
            w_label1.Content = (strWeather[6].Split(' '))[1];
            w_label0.Content = (strWeather[6].Split(' '))[0];
            string str = (strWeather[10].Split('；'))[0];
            w_label2.Content = (str.Split('：'))[2];
            w_label3.Content = "上次监测：" + (strWeather[4].Split(' '))[1];
            w_label4.Content = (strWeather[10].Split('；'))[2];
            w_label5.Content = (strWeather[10].Split('；'))[1];
            w_label6.Content = (strWeather[10].Split('；'))[3];
            w_label7.Content = (strWeather[10].Split('；'))[4];

            w_label8.Content = (strWeather[6].Split(' '))[0];
            w_label9.Content = (strWeather[13].Split(' '))[0];
            w_label10.Content = (strWeather[18].Split(' '))[0];
            image = new BitmapImage(new Uri(strPATH + @"/weatherlogo/b_" + strWeather[8], UriKind.RelativeOrAbsolute));
            w_image2.Source = image;
            image = new BitmapImage(new Uri(strPATH + @"/weatherlogo/b_" + strWeather[15], UriKind.RelativeOrAbsolute));
            w_image3.Source = image;
            image = new BitmapImage(new Uri(strPATH + @"/weatherlogo/b_" + strWeather[20], UriKind.RelativeOrAbsolute));
            w_image4.Source = image;
            w_label11.Content = strWeather[5];
            w_label12.Content = strWeather[12];
            w_label13.Content = strWeather[17];

            System.Net.WebClient wc = new System.Net.WebClient();

            DateTime nowtime = DateTime.Now;
            string timeStr = nowtime.ToString("yyyyMMddHHmm");
            string minute = DateTime.Now.Minute.ToString();
            int minuteInt = Convert.ToInt32(minute);
            int model = minuteInt - minuteInt % 6 + 2;
            string modelstr = model.ToString("D2");
            timeStr = timeStr.Substring(0, 10) + modelstr;
            string imgPath = @"http://www.soweather.com/PicFiles/wd" + timeStr + @".png";

            while (!RemoteFileExists(imgPath))
            {
                nowtime = nowtime.AddMinutes(-6);
                timeStr = nowtime.ToString("yyyyMMddHHmm");
                minute = nowtime.Minute.ToString();
                minuteInt = Convert.ToInt32(minute);
                model = minuteInt - minuteInt % 6 + 2;
                modelstr = model.ToString("D2");
                timeStr = timeStr.Substring(0, 10) + modelstr;
                imgPath = @"http://www.soweather.com/PicFiles/wd" + timeStr + @".png";
            }
            /*
            wc.DownloadFile(new Uri(imgPath), timeStr + @".png");
            FileInfo fileInfo = new FileInfo(timeStr + @".png");

            DirectoryInfo diDebug = new DirectoryInfo(System.Environment.CurrentDirectory);
            string strPATH = diDebug.FullName;
            image1.Source = new BitmapImage(new Uri(diDebug+@"\"+timeStr+@".png", UriKind.RelativeOrAbsolute));
            */

            Uri uri = new Uri(imgPath, UriKind.Absolute);
            BitmapImage bmp = new BitmapImage(uri);
            w_imageWeather.Source = bmp;
            w_webBrowser1.Source = new Uri("http://flash.weather.com.cn/sk2/shikuang.swf?id=101020100");

        }
        private bool RemoteFileExists(string fileUri)
        {
            bool result = false;//下载结果

            WebResponse response = null;
            try
            {
                WebRequest req = WebRequest.Create(fileUri);

                response = req.GetResponse();

                result = response == null ? false : true;

            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
            }

            return result;
        }

        public static string ToJsJson(object item)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(item.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, item);
                StringBuilder sb = new StringBuilder();
                sb.Append(Encoding.UTF8.GetString(ms.ToArray()));
                return sb.ToString();
            }
        }
        /// <summary>
        /// 数据格式，定义好数据的序列化细节
        /// </summary>
        [DataContract]
        public class Location
        {
            [DataMember(Order = 1)]
            public double Longitude { get; set; }
            [DataMember(Order = 2)]
            public double Latitude { get; set; }
            [DataMember(Order = 3)]
            public string Name { get; set; }
            [DataMember(Order = 4)]
            public string Description { get; set; }
            [DataMember(Order = 5)]
            public string Tel { get; set; }

        }
        public EmergencyBasic ds;
        [System.Runtime.InteropServices.ComVisibleAttribute(true)]//将该类设置为com可访问
        public class EmergencyBasic
        {
            public static string name;
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public void ClickEvent(string strlocation)
            {
                int ijudge = 0;
                if (strlocation == "突发事件")
                    ijudge = 1;
                else if (strlocation == "自然灾害")
                    ijudge = 2;
                DataTable dt = new DataTable();
                SQLHelper.getPointsByCategory(ijudge, out dt);
                List<Location> m_list = new List<Location>();

                for (int ix = 0; ix < dt.Rows.Count; ix++)
                {
                    Location new_Location = new Location();
                    new_Location.Name = dt.Rows[ix]["Name"].ToString();
                    new_Location.Description = dt.Rows[ix]["Description"].ToString();
                    new_Location.Tel = dt.Rows[ix]["Tel"].ToString();
                    new_Location.Longitude = (double)dt.Rows[ix]["ilng"];
                    new_Location.Latitude = (double)dt.Rows[ix]["ilat"];

                    m_list.Add(new_Location);
                }
                strlocation = ToJsJson(m_list);
                this.Name = strlocation;
            }

        }
        /*public EnvironmentBasic ds1;
        [System.Runtime.InteropServices.ComVisibleAttribute(true)]//将该类设置为com可访问
        public class EnvironmentBasic
        {
            public static string name;
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public void ClickEventEnv(string strEnv)
            {
                int ijudge = 0;
                if (strEnv == "环境污染")
                {

                    ijudge = 4;
                }
                DataTable dtEnv = new DataTable();
                SQLHelper.getPointsByCategory(ijudge, out dtEnv);
                List<Location> m_listEnv = new List<Location>();

                for (int ix = 0; ix < dtEnv.Rows.Count; ix++)
                {
                    Location new_Location = new Location();
                    new_Location.Name = dtEnv.Rows[ix]["Name"].ToString();
                    new_Location.Description = dtEnv.Rows[ix]["Description"].ToString();
                    new_Location.Tel = dtEnv.Rows[ix]["Tel"].ToString();
                    new_Location.Longitude = (double)dtEnv.Rows[ix]["ilng"];
                    new_Location.Latitude = (double)dtEnv.Rows[ix]["ilat"];

                    m_listEnv.Add(new_Location);
                }
                strEnv = ToJsJson(m_listEnv);
                this.Name = strEnv;
            }
        }*/

        private void wbEmergency_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            mshtml.HTMLDocument dom = (mshtml.HTMLDocument)wbEmergency.Document; //定义HTML
            dom.documentElement.style.overflow = "hidden"; //隐藏浏览器的滚动条
            dom.body.setAttribute("scroll", "no"); //禁用浏览器的滚动条
            mshtml.HTMLDocument dom2 = (mshtml.HTMLDocument)wbenvironment.Document; //定义HTML
            dom2.documentElement.style.overflow = "hidden"; //隐藏浏览器的滚动条
            dom2.body.setAttribute("scroll", "no"); //禁用浏览器的滚动条
            mshtml.HTMLDocument dom3 = (mshtml.HTMLDocument)wbTraffic.Document; //定义HTML
            dom3.documentElement.style.overflow = "hidden"; //隐藏浏览器的滚动条
            dom3.body.setAttribute("scroll", "no"); //禁用浏览器的滚动条
            mshtml.HTMLDocument dom4 = (mshtml.HTMLDocument)w_webBrowser1.Document; //定义HTML
            dom4.documentElement.style.overflow = "hidden"; //隐藏浏览器的滚动条
            dom4.body.setAttribute("scroll", "no"); //禁用浏览器的滚动条
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

        private void btn_emergency_Click(object sender, RoutedEventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(System.Environment.CurrentDirectory);
            string pathEmergency = di.Parent.Parent.FullName;
            ds = new EmergencyBasic();
            wbEmergency.Navigate(new Uri(pathEmergency + @"/html/Emergency.htm", UriKind.RelativeOrAbsolute));//获取根目录的日历文件
            wbEmergency.ObjectForScripting = ds;//该对象可由显示在WebBrowser控件中的网页所包含的脚本代码访问
        }

        private void btn_typhoon_Click(object sender, RoutedEventArgs e)
        {
            wbEmergency.Source = new Uri("http://typhoon.zjwater.gov.cn/");
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            HideEveryContent();
            mainContent.Visibility = System.Windows.Visibility.Visible;
            //mainContent2.Visibility = System.Windows.Visibility.Hidden;
            //mainContent3.Visibility = System.Windows.Visibility.Hidden;
            //mainContent4.Visibility = System.Windows.Visibility.Hidden;
            //Emergency.Visibility = System.Windows.Visibility.Hidden;
            //Traffic.Visibility = System.Windows.Visibility.Hidden;
            //Environment.Visibility = System.Windows.Visibility.Hidden;
            //Weather.Visibility = System.Windows.Visibility.Hidden;
            //MaxEmergency.Visibility = System.Windows.Visibility.Hidden;
            //MaxWeather.Visibility = System.Windows.Visibility.Hidden;
            //MaxTraffic.Visibility = System.Windows.Visibility.Hidden;
            //MaxEnvironment.Visibility = System.Windows.Visibility.Hidden;
            loadProgressBars();
        }
        private void MenuItemEggModel_Click(object sender, RoutedEventArgs e)
        {
            WpfApplication3.Enum.MapState mapState = WpfApplication3.Enum.MapState.Egg2;
            if (mapState == WpfApplication3.Enum.MapState.Egg)
            {
                string city = "金华市";
                string name = "佛堂镇";
                int currentYear = 2007;
                CxEggModel eggModel = new CxEggModel(name, city, currentYear);
                //eggModel.titleBar.Text = name;
                //eggModel.SetOnePlace(name, city, currentYear);
                if (city == "金华市")
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Foreground = System.Windows.Media.Brushes.Black; ;
                    item.Content = name.ToString();
                    item.Tag = name;
                    eggModel.titleBar.Items.Add(item);
                    ComboBoxItem item1 = new ComboBoxItem();
                    item1.Foreground = System.Windows.Media.Brushes.Black;
                    item1.Content = "义乌市";
                    item1.Tag = "义乌市";
                    eggModel.titleBar.Items.Add(item1);
                }
                else
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Foreground = System.Windows.Media.Brushes.Black; ;
                    item.Content = name.ToString();
                    item.Tag = name;
                    eggModel.titleBar.Items.Add(item);
                    ComboBoxItem item1 = new ComboBoxItem();
                    item1.Foreground = System.Windows.Media.Brushes.Black; ;
                    item1.Content = "南充市";
                    item1.Tag = "南充市";
                    eggModel.titleBar.Items.Add(item1);

                }
                eggModel.titleBar.SelectedIndex = 0;
            }
            else if (mapState == WpfApplication3.Enum.MapState.Egg2)
            {
                string city = "金华市";
                string name = "佛堂镇";
                CxEggModel eggModel = new CxEggModel(name, city);
                //eggModel.titleBar.Text = name;
                //eggModel.SetAllPlace(name, city);
                if (city == "金华市")
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Foreground = System.Windows.Media.Brushes.Black; ;
                    item.Content = name.ToString();
                    item.Tag = name;
                    eggModel.titleBar.Items.Add(item);
                    ComboBoxItem item1 = new ComboBoxItem();
                    item1.Foreground = System.Windows.Media.Brushes.Black;
                    item1.Content = "义乌市";
                    item1.Tag = "义乌市";
                    eggModel.titleBar.Items.Add(item1);
                }
                else
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Foreground = System.Windows.Media.Brushes.Black; ;
                    item.Content = name.ToString();
                    item.Tag = name;
                    eggModel.titleBar.Items.Add(item);
                    ComboBoxItem item1 = new ComboBoxItem();
                    item1.Foreground = System.Windows.Media.Brushes.Black; ;
                    item1.Content = "南充市";
                    item1.Tag = "南充市";
                    eggModel.titleBar.Items.Add(item1);
                }
                eggModel.titleBar.SelectedIndex = 0;
            }
        }

        private void loadProgressBars()
        {
            this.R1.Width = 0;
            this.R2.Width = 0;
            tick = 0;
            if (firstBarOri.Left == 0 && firstBarOri.Top == 0 && firstBarOri.Right == 0 && firstBarOri.Bottom == 0)
            {
                firstBarOri = this.L1.Margin;
            }
            else
            {
                this.L1.Margin = firstBarOri;
            }
            if (secondBarOri.Left == 0 && secondBarOri.Top == 0 && secondBarOri.Right == 0 && secondBarOri.Bottom == 0)
            {
                secondBarOri = this.L2.Margin;
            }
            else
            {
                this.L2.Margin = secondBarOri;
            }
            // 注释此句将百分比将会一直在进度条头部显示
            this.L1.Margin = new Thickness(this.L1.Margin.Left - 2, this.L1.Margin.Top, this.L1.Margin.Right, this.L1.Margin.Bottom);
            this.L2.Margin = new Thickness(this.L2.Margin.Left - 2, this.L2.Margin.Top, this.L2.Margin.Right, this.L2.Margin.Bottom);
            BrushProcessBar();
        }
        Thickness firstBarOri;
        Thickness secondBarOri;
        private DispatcherTimer dt_Bar;
        private int tick = 1;
        private void BrushProcessBar()
        {
            dt_Bar = new DispatcherTimer();
            dt_Bar.Interval = new TimeSpan(0, 0, 0, 0, 1);
            dt_Bar.Tick += new EventHandler(dt_firstTick);
            dt_Bar.Tick += new EventHandler(dt_secondTick);
            dt_Bar.Start();
        }
        protected void dt_firstTick(object sender, EventArgs e)
        {
            tick += 2;
            this.R1.Width = tick;
            this.L1.Margin = new Thickness(this.L1.Margin.Left + 2, this.L1.Margin.Top, this.L1.Margin.Right, this.L1.Margin.Bottom);
            this.L1.Content = Decimal.Round(((decimal)tick) / LENGTH * 100, 1) + "%";
            if (tick == 1 * LENGTH)
            {
                dt_Bar.Stop();
            }
        }
        protected void dt_secondTick(object sender, EventArgs e)
        {
            if (tick <= 0.6 * LENGTH)
            {
                this.R2.Width = tick;
                this.L2.Margin = new Thickness(this.L2.Margin.Left + 2, this.L2.Margin.Top, this.L2.Margin.Right, this.L2.Margin.Bottom);
                this.L2.Content = Decimal.Round(((decimal)tick) / LENGTH * 100, 1) + "%";

            }
        }


        private void Home_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            HideEveryContent();
            Emergency.Visibility = System.Windows.Visibility.Visible;
            wbEmergency.Visibility = System.Windows.Visibility.Visible;
            Traffic.Visibility = System.Windows.Visibility.Visible;
            wbTraffic.Visibility = System.Windows.Visibility.Visible;
            Environment.Visibility = System.Windows.Visibility.Visible;
            wbenvironment.Visibility = System.Windows.Visibility.Visible;
            Weather.Visibility = System.Windows.Visibility.Visible;
            w_webBrowser1.Visibility = System.Windows.Visibility.Visible;
            WeatherInfo.Visibility = System.Windows.Visibility.Visible;
            GridCalender.Visibility = System.Windows.Visibility.Visible;
            btn_maxtraffic.Visibility = System.Windows.Visibility.Visible;
            btn_maxemergency.Visibility = System.Windows.Visibility.Visible;
            btn_maxenvironment.Visibility = System.Windows.Visibility.Visible;
            btn_maxweather.Visibility = System.Windows.Visibility.Visible;


        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void btnVideoRemote_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.

            Window1 w1 = new Window1();
            w1.Show();
        }

        private void weibo_topic_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // TODO: Add event handler implementation here.
            weibo_topic.Text = "";

        }

        private void weibo_topic_GotMouseCapture(object sender, System.Windows.Input.MouseEventArgs e)
        {
            // TODO: Add event handler implementation here.
            weibo_topic.Text = "";
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

        private void weibo_search_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            string topic = weibo_topic.Text;
            WeiboHelper weibohelper = new WeiboHelper();
            weibohelper.settopic(topic);
            wb_weibo.Navigate(new Uri(strPATH + @"/bin/Debug/weibo.htm"));
        }

        //private void CreateEngineControls()
        //{
        //    mapControl = new AxMapControl();
        //    mapHost.Child = mapControl;
        //    toolbarControl = new AxToolbarControl();
        //    toolbarHost.Child = toolbarControl;
        //}

        //private void LoadMap()
        //{

        //    //将TOC控件、Toolbar控件和地图控件绑定
        //    toolbarControl.SetBuddyControl(this.mapControl);


        //    //添加放大、缩小、打开地图文档等命令到Toolbar工具栏
        //    toolbarControl.AddItem("esriControls.ControlsOpenDocCommand");
        //    toolbarControl.AddItem("esriControls.ControlsMapNavigationToolbar");
        //    toolbarControl.AddItem("esriControls.ControlsMapIdentifyTool");

        //    this.mapControl.LoadMxFile(strPATH + @"\ArcGIS_Map\NanChong\NanChong.mxd");
        //    //设置工具栏的外观
        //    //toolbarControl.BackColor = Color.FromArgb();
        //    this.mapControl.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(mapControl_OnMouseDown);
        //}
        //private void mapControl_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        //{
        //    IPoint pPoint;
        //    ITopologicalOperator pTopo;
        //    IGeometry pGeometry;
        //    IFeature pFeature;
        //    IFeatureLayer pFeatureLayer;
        //    IFeatureCursor pCursor;
        //    ISpatialFilter pFilter;
        //    if (e.button == 1)//鼠标左键单击
        //    {
        //        pPoint = new ESRI.ArcGIS.Geometry.Point();
        //        pPoint.PutCoords(e.mapX, e.mapY);
        //        pTopo = pPoint as ITopologicalOperator;
        //        pGeometry = pTopo.Buffer(100.0);

        //        pFilter = new SpatialFilter();
        //        pFilter.GeometryField = "shape";
        //        pFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
        //        pFilter.Geometry = pGeometry;
        //        pFeatureLayer = mapControl.Map.get_Layer(6) as IFeatureLayer;
        //        //MessageBox.Show(pFeatureLayer.Name);
        //        pCursor = pFeatureLayer.Search(pFilter, false);
        //        pFeature = pCursor.NextFeature();
        //        if (pFeature != null)
        //        {
        //            drawEggTenYears(Convert.ToString(pFeature.get_Value(4)), "南充市");
        //        }
        //        else
        //        {
        //            MessageBox.Show("没有对应的要素！");
        //        }
        //    }
        //}

        private void btn_maxemergency_Click(object sender, RoutedEventArgs e)
        {
            DirectoryInfo di;
            di = new DirectoryInfo(System.Environment.CurrentDirectory);
            string pathEmergency = di.Parent.Parent.FullName;
            HideEveryContent();
            //mainContent.Visibility = System.Windows.Visibility.Hidden;
            //mainContent2.Visibility = System.Windows.Visibility.Hidden;
            //mainContent3.Visibility = System.Windows.Visibility.Hidden;
            //mainContent4.Visibility = System.Windows.Visibility.Hidden;
            //wbEmergency.Visibility = System.Windows.Visibility.Hidden;
            //wbTraffic.Visibility = System.Windows.Visibility.Hidden;
            //wbenvironment.Visibility = System.Windows.Visibility.Hidden;
            //w_webBrowser1.Visibility = System.Windows.Visibility.Hidden;
            //WeatherInfo.Visibility = System.Windows.Visibility.Hidden;
            webBrowsermaxmap.Navigate(new Uri(strPATH + @"/html/MaxEmergency.htm", UriKind.RelativeOrAbsolute));
            webBrowsermaxmap.ObjectForScripting = ds;
            MaxEmergency.Visibility = System.Windows.Visibility.Visible;
            //btn_maxtraffic.Visibility = System.Windows.Visibility.Hidden;
        }

        private void btn_minemergency_Click(object sender, RoutedEventArgs e)
        {
            HideEveryContent();
            Home_Click(sender, e);
        }

        private void btn_maxtraffic_Click(object sender, RoutedEventArgs e)
        {
            HideEveryContent();
            //mainContent.Visibility = System.Windows.Visibility.Hidden;
            //mainContent2.Visibility = System.Windows.Visibility.Hidden;
            //mainContent3.Visibility = System.Windows.Visibility.Hidden;
            //mainContent4.Visibility = System.Windows.Visibility.Hidden;
            //wbEmergency.Visibility = System.Windows.Visibility.Hidden;
            //wbTraffic.Visibility = System.Windows.Visibility.Hidden;
            //wbenvironment.Visibility = System.Windows.Visibility.Hidden;
            //w_webBrowser1.Visibility = System.Windows.Visibility.Hidden;
            //WeatherInfo.Visibility = System.Windows.Visibility.Hidden;
            webBrowsermaxtraffic.Navigate(new Uri(strPATH + @"/html/Traffic.htm", UriKind.RelativeOrAbsolute));
            MaxTraffic.Visibility = System.Windows.Visibility.Visible;
            btn_maxtraffic.Visibility = System.Windows.Visibility.Hidden;
        }

        private void btn_mintraffic_Click(object sender, RoutedEventArgs e)
        {
            HideEveryContent();
            Home_Click(sender, e);
        }
        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            // 设置回调函数
            AnyChatCoreSDK.SetNotifyMessageCallBack(OnNotifyMessageCallback, 0);
            AnyChatCoreSDK.SetVideoDataCallBack(AnyChatCoreSDK.PixelFormat.BRAC_PIX_FMT_RGB24, OnVideoDataCallback, 0);

            ulong dwFuncMode = AnyChatCoreSDK.BRAC_FUNC_VIDEO_CBDATA | AnyChatCoreSDK.BRAC_FUNC_AUDIO_AUTOPLAY | AnyChatCoreSDK.BRAC_FUNC_CHKDEPENDMODULE
                | AnyChatCoreSDK.BRAC_FUNC_AUDIO_VOLUMECALC | AnyChatCoreSDK.BRAC_FUNC_NET_SUPPORTUPNP | AnyChatCoreSDK.BRAC_FUNC_FIREWALL_OPEN
                | AnyChatCoreSDK.BRAC_FUNC_AUDIO_AUTOVOLUME | AnyChatCoreSDK.BRAC_FUNC_CONFIG_LOCALINI;

            // 初始化SDK
            AnyChatCoreSDK.InitSDK(IntPtr.Zero, dwFuncMode);
            AnyChatCoreSDK.Connect("demo.anychat.cn", 8906);
            AnyChatCoreSDK.Login("WFP", "", 0);
            AnyChatCoreSDK.EnterRoom(1, "", 0);


            NotifyMessageHandler = new AnyChatCoreSDK.NotifyMessage_CallBack(NotifyMessageCallbackDelegate);
            VideoDataHandler = new AnyChatCoreSDK.VideoData_CallBack(VideoDataCallbackDelegate);
        }
        // 关闭窗口时释放资源
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AnyChatCoreSDK.LeaveRoom(-1);
            AnyChatCoreSDK.Logout();
            AnyChatCoreSDK.Release();
        }


        // AnyChat 内核回调，不能操作界面
        public static void NotifyMessage_CallBack(int dwNotifyMsg, int wParam, int lParam, int userValue)
        {
            if (NotifyMessageHandler != null)
                NotifyMessageHandler(dwNotifyMsg, wParam, lParam, userValue);
        }

        // 委托，可以操作界面
        public void NotifyMessageCallbackDelegate(int dwNotifyMsg, int wParam, int lParam, int userValue)
        {

            switch (dwNotifyMsg)
            {
                case AnyChatCoreSDK.WM_GV_CONNECT:
                    if (wParam != 0)
                        msglabel.Content = "连接服务器成功";
                    else
                        msglabel.Content = "连接服务器失败";
                    break;
                case AnyChatCoreSDK.WM_GV_LOGINSYSTEM:
                    if (lParam == 0)
                    {
                        g_selfUserId = wParam;
                        msglabel.Content = "登录成功";
                    }
                    else
                    {
                        msglabel.Content = "登录失败, ErrorCode:" + lParam;
                    }
                    break;
                case AnyChatCoreSDK.WM_GV_ENTERROOM:
                    if (lParam == 0)
                    {
                        msglabel.Content = "进入房间成功";
                        AnyChatCoreSDK.UserSpeakControl(-1, true);
                        AnyChatCoreSDK.UserCameraControl(-1, true);
                    }
                    else
                        msglabel.Content = "进入房间失败, ErrorCode:" + lParam;
                    break;
                case AnyChatCoreSDK.WM_GV_ONLINEUSER:
                    OpenRemoteUserVideo();
                    break;
                case AnyChatCoreSDK.WM_GV_USERATROOM:
                    if (lParam != 0)     // 其它用户进入房间
                    {
                        OpenRemoteUserVideo();
                    }
                    else                // 其它用户离开房间
                    {
                        if (wParam == g_otherUserId)
                        {
                            g_otherUserId = -1;
                            OpenRemoteUserVideo();
                        }
                    }
                    break;
                case AnyChatCoreSDK.WM_GV_LINKCLOSE:
                    msglabel.Content = "网络连接关闭, ErrorCode:" + lParam;
                    break;
                default:
                    break;
            }
        }

        // AnyChat内核回调
        public static void VideoData_CallBack(int userId, IntPtr buf, int len, AnyChatCoreSDK.BITMAPINFOHEADER bitMap, int userValue)
        {
            if (VideoDataHandler != null)
                VideoDataHandler(userId, buf, len, bitMap, userValue);
        }

        // 静态委托
        public void VideoDataCallbackDelegate(int userId, IntPtr buf, int len, AnyChatCoreSDK.BITMAPINFOHEADER bitMap, int userValue)
        {
            int stride = bitMap.biWidth * 3;
            BitmapSource bs = BitmapSource.Create(bitMap.biWidth, bitMap.biHeight, 96, 96, PixelFormats.Bgr24, null, buf, len, stride);
            // 将图像进行翻转
            TransformedBitmap RotateBitmapr = new TransformedBitmap();
            RotateBitmapr.BeginInit();
            RotateBitmapr.Source = bs;
            //RotateBitmapr.Transform = new RotateTransform(180);
            RotateBitmapr.EndInit();
            RotateBitmapr.Freeze();

            TransformedBitmap RotateBitmapl = new TransformedBitmap();
            RotateBitmapl.BeginInit();
            RotateBitmapl.Source = bs;
            RotateBitmapl.Transform = new RotateTransform(180);
            RotateBitmapl.EndInit();
            RotateBitmapl.Freeze();

            // 异步操作
            Action action = new Action(delegate()
            {
                Dispatcher.BeginInvoke(new Action(delegate()
                {
                    if (userId == g_selfUserId)
                        localVideoImage.Source = RotateBitmapl;
                    else if (userId == g_otherUserId)
                        remoteVideoImage.Source = RotateBitmapr;
                }), null);
            });
            action.BeginInvoke(null, null);
        }

        // 打开远程用户的音频、视频
        public void OpenRemoteUserVideo()
        {
            if (g_otherUserId != -1)
                return;
            // 获取当前房间用户列表
            int usercount = 0;
            AnyChatCoreSDK.GetOnlineUser(null, ref usercount);
            if (usercount > 0)
            {
                int[] useridarray = new int[usercount];
                AnyChatCoreSDK.GetOnlineUser(useridarray, ref usercount);
                for (int i = 0; i < usercount; i++)
                {
                    // 判断该用户的视频是否已打开
                    int usercamerastatus = 0;
                    if (AnyChatCoreSDK.QueryUserState(useridarray[i], AnyChatCoreSDK.BRAC_USERSTATE_CAMERA, ref usercamerastatus, sizeof(int)) != 0)
                        continue;
                    if (usercamerastatus == 2)
                    {
                        AnyChatCoreSDK.UserSpeakControl(useridarray[i], true);
                        AnyChatCoreSDK.UserCameraControl(useridarray[i], true);
                        g_otherUserId = useridarray[i];
                        break;
                    }
                }
            }
        }

        private void btn_maxenvironment_Click(object sender, RoutedEventArgs e)
        {
            HideEveryContent();
            webBrowsermaxenvironment.Navigate(new Uri(strPATH + @"/html/PM25.htm", UriKind.RelativeOrAbsolute));
            MaxEnvironment.Visibility = System.Windows.Visibility.Visible;
            btn_maxtraffic.Visibility = System.Windows.Visibility.Hidden;
        }
        private void btn_minenvironment_Click(object sender, RoutedEventArgs e)
        {
            HideEveryContent();
            Home_Click(sender, e);
        }
        private void btn_maxweather_Click(object sender, RoutedEventArgs e)
        {
            HideEveryContent();
            webBrowsermaxweather.Navigate(new Uri("http://flash.weather.com.cn/sk2/shikuang.swf?id=101020100", UriKind.RelativeOrAbsolute));
            MaxWeather.Visibility = System.Windows.Visibility.Visible;
            btn_maxtraffic.Visibility = System.Windows.Visibility.Hidden;
        }
        private void btn_minweather_Click(object sender, RoutedEventArgs e)
        {
            HideEveryContent();
            Home_Click(sender, e);
        }

        private void buttonfullscreen_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            int largewidth, smallwidth;
            largewidth = 1300;
            smallwidth = 290;
            smallwidth++;
            if (this.Video.Width != largewidth)
            {
                this.Video.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                this.Video.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                Thickness marginlarge;
                marginlarge = new Thickness(300, 8, 0, 0);
                this.Video.Margin = marginlarge;
                this.Video.Width = 1300;
                this.Video.Height = 1040;
                this.bgvideo1.Visibility = System.Windows.Visibility.Visible;
                this.remotevideo.Width = 1300;
                this.remotevideo.Height = 990;
                this.localvideo.Width = 300;
                this.localvideo.Height = 200;
                HideEveryContent();
            }

            else
            {
                this.Video.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                this.Video.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                Thickness marginsmall;
                marginsmall = new Thickness(18, 620, 0, 0);
                this.Video.Margin = marginsmall;
                this.Video.Width = 254;
                this.Video.Height = 211.167;
                this.bgvideo1.Visibility = System.Windows.Visibility.Collapsed;
                this.remotevideo.Width = 254;
                this.remotevideo.Height = 181;
                this.localvideo.Width = 75;
                this.localvideo.Height = 50;
                HideEveryContent();
                Emergency.Visibility = System.Windows.Visibility.Visible;
                Traffic.Visibility = System.Windows.Visibility.Visible;
                Environment.Visibility = System.Windows.Visibility.Visible;
                Weather.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void buttonSwitch_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            VerticalAlignment vt;
            vt = this.remotevideo.VerticalAlignment;
            this.remotevideo.VerticalAlignment = this.localvideo.VerticalAlignment;
            this.localvideo.VerticalAlignment = vt;
            HorizontalAlignment ht;
            ht = this.remotevideo.HorizontalAlignment;
            this.remotevideo.HorizontalAlignment = this.localvideo.HorizontalAlignment;
            this.localvideo.HorizontalAlignment = ht;
            //Thickness marginswitch;
            //marginswitch=new Thickness(300,8,0,0);
            //this.Video.Margin = marginlarge;
            double widthswitch;
            widthswitch = this.remotevideo.Width;
            this.remotevideo.Width = this.localvideo.Width;
            this.localvideo.Width = widthswitch;
            double heightswitch;
            heightswitch = this.remotevideo.Height;
            this.remotevideo.Height = this.localvideo.Height;
            this.localvideo.Height = heightswitch;

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void drawEggTenYears(string _place, string _city)
        {
            string city = _city;
            string name = _place;
            CxEggModel eggModel = new CxEggModel(name, city);
            //eggModel.titleBar.Text = name;
            //eggModel.SetAllPlace(name, city);

            ComboBoxItem item = new ComboBoxItem();
            item.Foreground = System.Windows.Media.Brushes.Black; ;
            item.Content = name.ToString();
            item.Tag = name;
            eggModel.titleBar.Items.Add(item);
            eggModel.titleBar.SelectedIndex = 0;
        }

        private void drawEggOneYear(string _place, string _city, int _year)
        {
            string city = _city;
            string name = _place;
            int currentYear = _year;
            CxEggModel eggModel = new CxEggModel(name, city, currentYear);
            //eggModel.titleBar.Text = name;
            //eggModel.SetOnePlace(name, city, currentYear);

            ComboBoxItem item = new ComboBoxItem();
            item.Foreground = System.Windows.Media.Brushes.Black; ;
            item.Content = name.ToString();
            item.Tag = name;
            eggModel.titleBar.Items.Add(item);

            eggModel.titleBar.SelectedIndex = 0;
        }

        private void btnTestCity1_Click(object sender, RoutedEventArgs e)
        {
            drawEggTenYears("蓬安县", "南充市");
        }

        private void btnTestCity2_Click(object sender, RoutedEventArgs e)
        {
            drawEggOneYear("佛堂镇", "金华市", 2009);
        }

        private void MenuItem_Xiafawenjian_Click(object sender, RoutedEventArgs e)
        {
            HideEveryContent();
            mainContent3.Visibility = System.Windows.Visibility.Visible;
            gridSendCopy.Visibility = System.Windows.Visibility.Visible;
        }

        private void MenuItem_Shenqingpishi_Click(object sender, RoutedEventArgs e)
        {
            HideEveryContent();
            mainContent4.Visibility = System.Windows.Visibility.Visible;
            gridSendCopy.Visibility = System.Windows.Visibility.Visible;
        }

        private void tabItemXingZhengGongWen_Loaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<DataXingZhengGongWen> Datas = new ObservableCollection<DataXingZhengGongWen>();
            DataXingZhengGongWen dt = new DataXingZhengGongWen();
            dt.Name = "关于切实做好重大节假日免收小型客车通行费有关工作的通知";
            dt.Key = "主题词：交通 通知";
            dt.Number = "通知文号：湘政办发〔2012〕91号";
            dt.Division = "责任部门：省政府办公厅";
            dt.Date = "签署日期：2012-9-18";
            dt.Comment = "已批示";
            Datas.Add(dt);
            dt = new DataXingZhengGongWen();
            dt.Name = "省2012年“出生人口性别比重点治理年”行动方案";
            dt.Key = "主题词：卫生 计划生育 方案";
            dt.Number = "通知文号：湘人口发〔2005〕31号";
            dt.Division = "责任部门：市政府法制办公室";
            dt.Date = "签署日期：2012-9-10";
            dt.Comment = "未批示";
            Datas.Add(dt);
            dt = new DataXingZhengGongWen();
            dt.Name = "关于转发省政府工作会议纪要的通知";
            dt.Key = "主题词：卫生 劳动保障 方案";
            dt.Number = "通知文号：湘政办发〔2012〕87号";
            dt.Division = "责任部门：市政府法制办公室";
            dt.Date = "签署日期：2012-8-06"; 
            dt.Comment = "未批示";
            Datas.Add(dt);
            dt = new DataXingZhengGongWen();
            dt.Name = "中共湖南省委办公厅、湖南省人民政府办公厅关于成立绿色湖南建设领导小组的通知";
            dt.Key = "主题词：绿色湖南 领导小组";
            dt.Number = "通知文号：湘政办发〔2012〕79号";
            dt.Division = "责任部门：市政府办公室";
            dt.Date = "签署日期：2012-7-29";
            dt.Comment = "未批示";
            Datas.Add(dt);
            dt = new DataXingZhengGongWen();
            dt.Name = "关于转发省政府工作会议纪要的通知";
            dt.Key = "主题词：卫生 劳动保障 方案";
            dt.Number = "通知文号：湘政办发〔2012〕87号";
            dt.Division = "责任部门：市政府法制办公室";
            dt.Date = "签署日期：2012-8-06";
            dt.Comment = "未批示";
            Datas.Add(dt);
            dt = new DataXingZhengGongWen();
            dt.Name = "中共湖南省委办公厅、湖南省人民政府办公厅关于成立绿色湖南建设领导小组的通知";
            dt.Key = "主题词：绿色湖南 领导小组";
            dt.Number = "通知文号：湘政办发〔2012〕79号";
            dt.Division = "责任部门：市政府办公室";
            dt.Date = "签署日期：2012-7-29";
            dt.Comment = "未批示";
            Datas.Add(dt);
            listBoxXingZhengGongWen.ItemsSource = Datas;
        }

        public class DataXingZhengGongWen
        {
            public string Name { get; set; }
            public string Key { get; set; }
            public string Number { get; set; }
            public string Division { get; set; }
            public string Date { get; set; }
            public string Comment { get; set; }
        }

        private void tabItem6_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            DataColumn col = new DataColumn("col1", typeof(string));
            dt.Columns.Add(col);
            col = new DataColumn("col2", typeof(string));
            dt.Columns.Add(col);
            col = new DataColumn("col3", typeof(string));
            dt.Columns.Add(col);

            DataRow dr = dt.NewRow();
            dr[0] = "第五届上海高等学校教学名师奖的通知";
            dr[1] = "2012/8/15";
            dr[2] = "";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "本市高校卫生管理及相关工作的通知";
            dr[1] = "2012/8/14";
            dr[2] = "";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "上海市教育委员会文件";
            dr[1] = "2012/8/13";
            dr[2] = "紧急通知";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "沪教委高44号";
            dr[1] = "2012/11/7";
            dr[2] = "";
            dt.Rows.Add(dr);

            this.dg2.ItemsSource = dt.DefaultView;
        }
        private void dg2_HyperlinkColumn_Click(object sender, RoutedEventArgs e)
        {
            if (this.dg2.SelectedItem == null)
            {
                return;
            }
            if (e.OriginalSource.GetType() != typeof(System.Windows.Documents.Hyperlink))
                return;
            string strCommand = ((System.Windows.Documents.Hyperlink)e.OriginalSource).NavigateUri.ToString();
            if (strCommand != "下载")
            {
                string fileName = ((DataRowView)this.dg2.SelectedItem)[0].ToString() + ".pdf";
                if (System.IO.File.Exists(fileName))
                {
                    //Process.Start(fileName);
                    AdobeReaderControl pdfCl = new AdobeReaderControl(fileName);
                    this.wfhPDF2.Child = pdfCl;
                    this.gridPDF2.Visibility = Visibility.Visible;
                    btnSendCopy.IsEnabled = true;
                    fileName = ((DataRowView)this.dg2.SelectedItem)[0].ToString() + ".isf";
                    if (System.IO.File.Exists(fileName))
                    {
                        System.IO.FileStream fs = new System.IO.FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                        this.InkCanvasAnnotation2.Strokes = new System.Windows.Ink.StrokeCollection(fs);
                    }
                    else
                        this.InkCanvasAnnotation2.Strokes = new System.Windows.Ink.StrokeCollection();

                    dg2.Visibility = Visibility.Hidden;
                }
                else
                {
                    MessageBox.Show("无法找到该文件");
                }
            }
            else
            {
                //下载
            }
        }
        private void tabItem7_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnWeatherRefresh_Click(object sender, RoutedEventArgs e)
        {
            if (w_webBrowser1.Document != null)
                w_webBrowser1.Refresh();
        }

        private void btnTrafficRefresh_Click(object sender, RoutedEventArgs e)
        {
            if (wbTraffic.Document != null)
                wbTraffic.Refresh();
        }

        private void btnEmergencyRefresh_Click(object sender, RoutedEventArgs e)
        {
            if (wbEmergency.Document != null)
                wbEmergency.Refresh();
        }

        private void btnEnvironmentRefresh_Click(object sender, RoutedEventArgs e)
        {
            if (wbenvironment.Document != null)
                wbenvironment.Refresh();
        }

        private void btnClear1_Click(object sender, RoutedEventArgs e)
        {
            InkCanvasAnnotation1.Strokes.Clear();
        }

        private void btnOK1_Click(object sender, RoutedEventArgs e)
        {
            int i = listBoxXingZhengGongWen.SelectedIndex;
            ObservableCollection<DataXingZhengGongWen> Datas = (ObservableCollection<DataXingZhengGongWen>)listBoxXingZhengGongWen.ItemsSource;
            string filename = ((DataXingZhengGongWen)Datas[i]).Name;
            System.IO.FileStream fs = new System.IO.FileStream(filename + ".isf", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            this.InkCanvasAnnotation1.Strokes.Save(fs);
            fs.Close();
            if (this.InkCanvasAnnotation1.Strokes.Count == 0)
            {
                MessageBox.Show("批示清除成功！");
                Datas[i].Comment = "未批示";
                listBoxXingZhengGongWen.ItemsSource = null;
                listBoxXingZhengGongWen.ItemsSource = Datas;
            }
            else
            {
                MessageBox.Show("批示保存成功！");
                Datas[i].Comment = "已批示";
                listBoxXingZhengGongWen.ItemsSource = null;
                listBoxXingZhengGongWen.ItemsSource = Datas;
            }
            listBoxXingZhengGongWen.SelectedIndex = -1;
        }

        private void btnCancel1_Click(object sender, RoutedEventArgs e)
        {
            this.gridPDF1.Visibility = Visibility.Hidden;
            btnSendCopy.IsEnabled = false;
            gridXingZhengGongWen.Visibility = System.Windows.Visibility.Visible;
            listBoxXingZhengGongWen.SelectedIndex = -1;
        }

        private void btnClear2_Click(object sender, RoutedEventArgs e)
        {
            InkCanvasAnnotation2.Strokes.Clear();
        }

        private void btnOK2_Click(object sender, RoutedEventArgs e)
        {
            string filename = ((DataRowView)this.dg2.SelectedItem)[0].ToString();
            System.IO.FileStream fs = new System.IO.FileStream(filename + ".isf", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            this.InkCanvasAnnotation2.Strokes.Save(fs);
            fs.Close();
            if (this.InkCanvasAnnotation2.Strokes.Count == 0)
                MessageBox.Show("批示清除成功！");
            else
                MessageBox.Show("批示保存成功！");
        }

        private void btnCancel2_Click(object sender, RoutedEventArgs e)
        {
            this.gridPDF2.Visibility = Visibility.Hidden;
            btnSendCopy.IsEnabled = false;
            dg2.Visibility = Visibility.Visible;
        }


        private void btnSendCopy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tabControl2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (this.tabControl2.SelectedIndex)
            {
                case 0:
                    {
                        btnSendCopy.IsEnabled = gridPDF1.Visibility==System.Windows.Visibility.Visible;
                        break;
                    }
                case 1:
                    {
                        btnSendCopy.IsEnabled = gridPDF2.Visibility==System.Windows.Visibility.Visible;
                        break;
                    }
                case 2:
                    {
                        btnSendCopy.IsEnabled = false;
                        break;
                    }
                default:
                    break;
            }
        }

        private void listBoxXingZhengGongWen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = listBoxXingZhengGongWen.SelectedIndex;
            if (i < 0)
                return;
            ObservableCollection<DataXingZhengGongWen> Datas = (ObservableCollection<DataXingZhengGongWen>)listBoxXingZhengGongWen.ItemsSource;
            string strFileName = ((DataXingZhengGongWen)Datas[i]).Name + ".pdf";
            if (System.IO.File.Exists(strFileName))
            {
                //Process.Start(fileName);
                AdobeReaderControl pdfCl = new AdobeReaderControl(strFileName);
                this.wfhPDF1.Child = pdfCl;
                this.gridPDF1.Visibility = Visibility.Visible;
                btnSendCopy.IsEnabled = true;
                strFileName = ((DataXingZhengGongWen)Datas[i]).Name + ".isf";
                if (System.IO.File.Exists(strFileName))
                {
                    System.IO.FileStream fs = new System.IO.FileStream(strFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    this.InkCanvasAnnotation1.Strokes = new System.Windows.Ink.StrokeCollection(fs);
                }
                else
                    this.InkCanvasAnnotation1.Strokes = new System.Windows.Ink.StrokeCollection();

                gridXingZhengGongWen.Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("无法找到该文件");
            }
        }




        private void tabItemYiPiShi_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            DataColumn col = new DataColumn("col0", typeof(string));
            dt.Columns.Add(col);
            col = new DataColumn("col1", typeof(string));
            dt.Columns.Add(col);
            col = new DataColumn("col2", typeof(string));
            dt.Columns.Add(col);
            col = new DataColumn("col3", typeof(string));
            dt.Columns.Add(col);
            col = new DataColumn("col4", typeof(string));
            dt.Columns.Add(col);

            DataRow dr = dt.NewRow();
            dr[0] = "发电站项目可行性研究及立项申请";
            dr[1] = "2012/5/13";
            dr[2] = "已批示";
            dr[3] = "国家发改委";
            dr[4] = "2012/7/20";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "2012城市重大工程专项经费申请";
            dr[1] = "2012/6/18";
            dr[2] = "已批示";
            dr[3] = "省财政局";
            dr[4] = "2012/8/2";
            dt.Rows.Add(dr);

            this.dgYiPiShi.ItemsSource = dt.DefaultView;
        }

        private void tabItemDaiPiShi_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            DataColumn col = new DataColumn("col0", typeof(string));
            dt.Columns.Add(col);
            col = new DataColumn("col1", typeof(string));
            dt.Columns.Add(col);
            col = new DataColumn("col2", typeof(string));
            dt.Columns.Add(col);
            col = new DataColumn("col3", typeof(string));
            dt.Columns.Add(col);
            col = new DataColumn("col4", typeof(string));
            dt.Columns.Add(col);

            DataRow dr = dt.NewRow();
            dr[0] = "市沿海边防治安管理办法";
            dr[1] = "2012/8/2";
            dr[2] = "未批示";
            dr[3] = "——";
            dr[4] = "——";
            dt.Rows.Add(dr);

            this.dgDaiPiShi.ItemsSource = dt.DefaultView;
        }

        private void tabItemDaiTiJiao_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            DataColumn col = new DataColumn("col0", typeof(string));
            dt.Columns.Add(col);
            col = new DataColumn("col1", typeof(string));
            dt.Columns.Add(col);
            col = new DataColumn("col2", typeof(string));
            dt.Columns.Add(col);

            DataRow dr = dt.NewRow();
            dr[0] = "市绿色生态城区示范基地的申请";
            dr[1] = "待提交";
            dr[2] = "住建部、财政部";
            dt.Rows.Add(dr);

            this.dgDaiTiJiao.ItemsSource = dt.DefaultView;

        }

        private void btnShenQingPiShiSendCopy_Click(object sender, RoutedEventArgs e)
        {
            //抄送
        }

        private void dgYiPiShi_Click(object sender, RoutedEventArgs e)
        {
            if (this.dgYiPiShi.SelectedItem == null)
            {
                return;
            }
            if (e.OriginalSource.GetType() != typeof(System.Windows.Documents.Hyperlink))
                return;
            string strCommand = ((System.Windows.Documents.Hyperlink)e.OriginalSource).NavigateUri.ToString();
            if (strCommand != "下载")
            {
                string fileName = ((DataRowView)this.dgYiPiShi.SelectedItem)[0].ToString() + ".pdf";
                if (System.IO.File.Exists(fileName))
                {
                    //Process.Start(fileName);
                    AdobeReaderControl pdfCl = new AdobeReaderControl(fileName);
                    this.wfhPDFYiPiShi.Child = pdfCl;
                    this.gridPDFYiPiShi.Visibility = Visibility.Visible;
                    btnSendCopy.IsEnabled = true;

                    dgYiPiShi.Visibility = Visibility.Hidden;
                }
                else
                {
                    MessageBox.Show("无法找到该文件");
                }
            }
            else
            {
                //下载
            }
        }

        private void dgDaiPiShi_Click(object sender, RoutedEventArgs e)
        {
            if (this.dgDaiPiShi.SelectedItem == null)
            {
                return;
            }
            if (e.OriginalSource.GetType() != typeof(System.Windows.Documents.Hyperlink))
                return;
            string strCommand = ((System.Windows.Documents.Hyperlink)e.OriginalSource).NavigateUri.ToString();
            if (strCommand != "下载")
            {
                string fileName = ((DataRowView)this.dgDaiPiShi.SelectedItem)[0].ToString() + ".pdf";
                if (System.IO.File.Exists(fileName))
                {
                    //Process.Start(fileName);
                    AdobeReaderControl pdfCl = new AdobeReaderControl(fileName);
                    this.wfhPDFDaiPiShi.Child = pdfCl;
                    this.gridPDFDaiPiShi.Visibility = Visibility.Visible;
                    btnSendCopy.IsEnabled = true;

                    dgDaiPiShi.Visibility = Visibility.Hidden;
                }
                else
                {
                    MessageBox.Show("无法找到该文件");
                }
            }
            else
            {
                //下载
            }
        }

        private void dgDaiTiJiao_Click(object sender, RoutedEventArgs e)
        {
            if (this.dgDaiTiJiao.SelectedItem == null)
            {
                return;
            }
            if (e.OriginalSource.GetType() != typeof(System.Windows.Documents.Hyperlink))
                return;
            string strCommand = ((System.Windows.Documents.Hyperlink)e.OriginalSource).NavigateUri.ToString();
            if (strCommand != "下载")
            {
                string fileName = ((DataRowView)this.dgDaiTiJiao.SelectedItem)[0].ToString() + ".pdf";
                if (System.IO.File.Exists(fileName))
                {
                    //Process.Start(fileName);
                    AdobeReaderControl pdfCl = new AdobeReaderControl(fileName);
                    this.wfhPDFDaiTiJiao.Child = pdfCl;
                    this.gridPDFDaiTiJiao.Visibility = Visibility.Visible;
                    btnSendCopy.IsEnabled = true;

                    dgDaiTiJiao.Visibility = Visibility.Hidden;
                }
                else
                {
                    MessageBox.Show("无法找到该文件");
                }
            }
            else
            {
                //下载
            }
        }

        private void tabControl1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    {
                        btnSendCopy.IsEnabled = gridPDFYiPiShi.Visibility == System.Windows.Visibility.Visible;
                        break;
                    }
                case 1:
                    {
                        btnSendCopy.IsEnabled = gridPDFDaiPiShi.Visibility == System.Windows.Visibility.Visible;
                        break;
                    }
                case 2:
                    {
                        btnSendCopy.IsEnabled = gridPDFDaiTiJiao.Visibility == System.Windows.Visibility.Visible;
                        break;
                    }
                default:
                    break;
            }
        }

        private void btnBackYiPiShi_Click(object sender, RoutedEventArgs e)
        {
            this.gridPDFYiPiShi.Visibility = Visibility.Hidden;
            btnSendCopy.IsEnabled = false;
            this.dgYiPiShi.Visibility = Visibility.Visible;
        }

        private void btnBackDaiPiShi_Click(object sender, RoutedEventArgs e)
        {
            this.gridPDFDaiPiShi.Visibility = System.Windows.Visibility.Hidden;
            btnSendCopy.IsEnabled = false;
            this.dgDaiPiShi.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnBackDaiTiJiao_Click(object sender, RoutedEventArgs e)
        {
            this.gridPDFDaiTiJiao.Visibility = System.Windows.Visibility.Hidden;
            btnSendCopy.IsEnabled = false;
            this.dgDaiTiJiao.Visibility = System.Windows.Visibility.Visible;

        }

        private void checkBoxSendCopy1_1_Click(object sender, RoutedEventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            if (chk.IsChecked == true)
            {
                listBoxSendCopy.Items.Add(chk.Content);
            }
            else
            {
                listBoxSendCopy.Items.Remove(chk.Content);
            }
        }

        ////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////
        public DataSet_Case.T_CaseDataTable dtSource;
        private void MenuItem_ChengShiFaZhanAnLiKu_Click(object sender, RoutedEventArgs e)
        {
            HideEveryContent();
            mainContent5.Visibility = System.Windows.Visibility.Visible;
            label_JingYanYinJian_Title.Content = "城市发展案例库";
            dtSource = null;
            gridJingYanYinJian_Menu_ChengShiFaZhanAnLiKu.Visibility = System.Windows.Visibility.Visible;
            gridJingYanYinJian_Menu_ChengShiBaiKeZhiShiKu.Visibility = System.Windows.Visibility.Hidden;
            gridJingYanYinJian_Menu_ChengShiShuJuZhiShiKu.Visibility = System.Windows.Visibility.Hidden;

            gridJingYanYinJian_Search.Visibility = System.Windows.Visibility.Visible;
            gridJingYanYinJian_Show.Visibility = System.Windows.Visibility.Hidden;
            DataSet_CaseTableAdapters.T_CaseTableAdapter adapter = new DataSet_CaseTableAdapters.T_CaseTableAdapter();
            dtSource = adapter.GetDataFromChengShiFaZhanAnLiKu();
            DataBind_JingYanYinJian_Search(20, 1);

        }

        private void btn_JingYanYinJian_Search_Click(object sender, RoutedEventArgs e)
        {
            if (tbx_JianYanYinJian_Search.Text == null || tbx_JianYanYinJian_Search.Text == "")
                return;
            DataSet_CaseTableAdapters.T_CaseTableAdapter adapter = new DataSet_CaseTableAdapters.T_CaseTableAdapter();
            dtSource = adapter.GetDataByKey(tbx_JianYanYinJian_Search.Text);
            DataBind_JingYanYinJian_Search(20, 1);

        }

        private void btn_JingYanYinJian_PageGo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int pageNum = int.Parse(tbx_JingYanYinJian_PageNum.Text);
                int total = int.Parse(tbk_JingYanYinJian_Total.Text); //总页数  
                if (pageNum >= 1 && pageNum <= total)
                {
                    DataBind_JingYanYinJian_Search(20, pageNum);     //调用分页方法  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_JingYanYinJian_PageUp_Click(object sender, RoutedEventArgs e)
        {
            int currentsize = int.Parse(tbk_JingYanYinJian_Currentsize.Text); //获取当前页数  
            if (currentsize > 1)
            {
                DataBind_JingYanYinJian_Search(20, currentsize - 1);   //调用分页方法  
            }
        }

        private void btn_JingYanYinJian_PageNext_Click(object sender, RoutedEventArgs e)
        {
            int total = int.Parse(tbk_JingYanYinJian_Total.Text); //总页数  
            int currentsize = int.Parse(tbk_JingYanYinJian_Currentsize.Text); //当前页数  
            if (currentsize < total)
            {
                DataBind_JingYanYinJian_Search(20, currentsize + 1);   //调用分页方法  
            }
        }

        private void DataBind_JingYanYinJian_Search(int number, int currentSize)
        {
            if (dtSource == null)
            {
                return;
            }
            int iPageSize;
            //DataSetCityCaseTableAdapters.T_CaseTableAdapter adapter = new DataSetCityCaseTableAdapters.T_CaseTableAdapter();
            //DataSetCityCase.T_CaseDataTable dt = adapter.SearchByKeyValue(tbx_JianYanYinJian_Search.Text);
            int count = dtSource.Count;
            if (count % number == 0)
                iPageSize = count / number;
            else
                iPageSize = count / number + 1;
            tbk_JingYanYinJian_Total.Text = iPageSize.ToString();
            tbk_JingYanYinJian_Currentsize.Text = currentSize.ToString();
            dataGridJingYanYinJian_SearchResult.ItemsSource = dtSource.Skip(number * (currentSize - 1)).Take(number).ToList();
        }
        private void gridJingYanYinJian_Menu_ChengShiFaZhanAnLiKu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource.GetType() != typeof(TextBlock))
                return;
            string strMenu = ((TextBlock)(e.OriginalSource)).Text;
            DataSet_CaseTableAdapters.T_CaseTableAdapter adapter = new DataSet_CaseTableAdapters.T_CaseTableAdapter();
            dtSource = null;
            dtSource = adapter.GetDataByMenu(strMenu);
            DataBind_JingYanYinJian_Search(20, 1);
        }

        private void MenuItem_ChengShiBaiKeZhiShiKu_Click(object sender, RoutedEventArgs e)
        {
            HideEveryContent();
            mainContent5.Visibility = System.Windows.Visibility.Visible;
            label_JingYanYinJian_Title.Content = "城市百科知识库";
            dtSource = null;
            gridJingYanYinJian_Menu_ChengShiFaZhanAnLiKu.Visibility = System.Windows.Visibility.Hidden;
            gridJingYanYinJian_Menu_ChengShiBaiKeZhiShiKu.Visibility = System.Windows.Visibility.Visible;
            gridJingYanYinJian_Menu_ChengShiShuJuZhiShiKu.Visibility = System.Windows.Visibility.Hidden;
            DataSet_CaseTableAdapters.T_CaseTableAdapter adapter = new DataSet_CaseTableAdapters.T_CaseTableAdapter();
            dtSource = adapter.GetDataFromChengShiBaiKeZhiShiKu();
            DataBind_JingYanYinJian_Search(20, 1);
        }

        private void gridJingYanYinJian_Menu_ChengShiBaiKeZhiShiKu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource.GetType() != typeof(TextBlock))
                return;
            string strMenu = ((TextBlock)(e.OriginalSource)).Text;
            DataSet_CaseTableAdapters.T_CaseTableAdapter adapter = new DataSet_CaseTableAdapters.T_CaseTableAdapter();
            dtSource = null;
            dtSource = adapter.GetDataByMenu(strMenu);
            DataBind_JingYanYinJian_Search(20, 1);
        }


        private void MenuItem_ChengShiShuJuZhiShiKu_Click(object sender, RoutedEventArgs e)
        {
            HideEveryContent();
            mainContent5.Visibility = System.Windows.Visibility.Visible;
            label_JingYanYinJian_Title.Content = "城市数据知识库";
            dtSource = null;
            gridJingYanYinJian_Menu_ChengShiFaZhanAnLiKu.Visibility = System.Windows.Visibility.Hidden;
            gridJingYanYinJian_Menu_ChengShiBaiKeZhiShiKu.Visibility = System.Windows.Visibility.Hidden;
            gridJingYanYinJian_Menu_ChengShiShuJuZhiShiKu.Visibility = System.Windows.Visibility.Visible;
            DataSet_CaseTableAdapters.T_CaseTableAdapter adapter = new DataSet_CaseTableAdapters.T_CaseTableAdapter();
            dtSource = adapter.GetDataFromChengShiShuJuZhiShiKu();
            DataBind_JingYanYinJian_Search(20, 1);
        }

        private void gridJingYanYinJian_Menu_ChengShiShuJuZhiShiKu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource.GetType() != typeof(TextBlock))
                return;
            string strMenu = ((TextBlock)(e.OriginalSource)).Text;
            DataSet_CaseTableAdapters.T_CaseTableAdapter adapter = new DataSet_CaseTableAdapters.T_CaseTableAdapter();
            dtSource = null;
            dtSource = adapter.GetDataByMenu(strMenu);
            DataBind_JingYanYinJian_Search(20, 1);
        }

        private void dataGridJingYanYinJian_SearchResult_Click(object sender, RoutedEventArgs e)
        {
            if (this.dataGridJingYanYinJian_SearchResult.SelectedItem == null)
            {
                return;
            }
            if (e.OriginalSource.GetType() != typeof(System.Windows.Documents.Hyperlink))
                return;
            //todo:
            gridJingYanYinJian_Search.Visibility = System.Windows.Visibility.Hidden;
            gridJingYanYinJian_Show.Visibility = System.Windows.Visibility.Visible;
            int i = dataGridJingYanYinJian_SearchResult.SelectedIndex;
            DataSet_Case.T_CaseRow ThisCase = dataGridJingYanYinJian_SearchResult.SelectedItem as DataSet_Case.T_CaseRow;
            label_JingYanYinJian_Show_CaseTitle.Content = ThisCase.CaseTitle;
            label_JingYanYinJian_Show_CaseCity.Content = ThisCase.CaseCity;
            label_JingYanYinJian_Show_CaseProvince.Content = ThisCase.CaseProvince;
            label_JingYanYinJian_Show_CaseCountry.Content = ThisCase.CaseCountry;
            label_JingYanYinJian_Show_StarLevel.Content = ThisCase.StarLevel;
            label_JingYanYinJian_Show_CaseTopic.Content = ThisCase.CaseTopic;
            label_JingYanYinJian_Show_CaseCompany.Content = ThisCase.CaseCompany;
            label_JingYanYinJian_Show_CaseManager.Content = ThisCase.CaseManager;
            label_JingYanYinJian_Show_CreateTime.Content = ThisCase.CreateTime;
            label_JingYanYinJian_Show_UpdateTime.Content = ThisCase.UpdateTime;

            string strFileName = ThisCase.CasePDF;
            if (System.IO.File.Exists(strFileName))
            {
                //Process.Start(fileName);
                AdobeReaderControl pdfCl = new AdobeReaderControl(strFileName);
                this.wfh_JingYanYinJie.Child = pdfCl;
            }
            else
            {
                MessageBox.Show("无法找到该文件");
            }
        }

        private void btn_JingYanYinJie_Show_Back_Click(object sender, RoutedEventArgs e)
        {
            gridJingYanYinJian_Search.Visibility = System.Windows.Visibility.Visible;
            gridJingYanYinJian_Show.Visibility = System.Windows.Visibility.Hidden;
        }

        //////////////////////////////////////////////////////////////////////////////////
        private void MenuItem_KongJianZiYuan_Click(object sender, RoutedEventArgs e)
        {
            HideEveryContent();
            mainContent6.Visibility = System.Windows.Visibility.Visible;
            grid_ZiYuanTongChou_KongJianZiYuan.Visibility = System.Windows.Visibility.Visible;
            grid_ZiYuanTongChou_RenLiZiYuan.Visibility = System.Windows.Visibility.Hidden;
            grid_ZiYuanTongChou_CaiZhengZiYuan.Visibility = System.Windows.Visibility.Hidden;
            grid_ZiYuanTongChou_WenHuaZiYuan.Visibility = System.Windows.Visibility.Hidden;

            GoogleMapHelper m_GoogleMapHelper = new GoogleMapHelper();
            m_GoogleMapHelper.setMap(0, "31.22924594193164", "121.48104309082031");
            webBrowser_KongJianZiYuan_GoogleMap.Navigate(new Uri(strPATH + @"/html/GoogleMap.htm"));
        }
        private void MenuItem_RenLiZiYuan_Click(object sender, RoutedEventArgs e)
        {
            HideEveryContent();
            mainContent6.Visibility = System.Windows.Visibility.Visible;
            grid_ZiYuanTongChou_KongJianZiYuan.Visibility = System.Windows.Visibility.Hidden;
            grid_ZiYuanTongChou_RenLiZiYuan.Visibility = System.Windows.Visibility.Visible;
            grid_ZiYuanTongChou_CaiZhengZiYuan.Visibility = System.Windows.Visibility.Hidden;
            grid_ZiYuanTongChou_WenHuaZiYuan.Visibility = System.Windows.Visibility.Hidden;
        }

        private void MenuItem_CaiZhengZiYuan_Click(object sender, RoutedEventArgs e)
        {
            HideEveryContent();
            mainContent6.Visibility = System.Windows.Visibility.Visible;
            grid_ZiYuanTongChou_KongJianZiYuan.Visibility = System.Windows.Visibility.Hidden;
            grid_ZiYuanTongChou_RenLiZiYuan.Visibility = System.Windows.Visibility.Hidden;
            grid_ZiYuanTongChou_CaiZhengZiYuan.Visibility = System.Windows.Visibility.Visible;
            grid_ZiYuanTongChou_WenHuaZiYuan.Visibility = System.Windows.Visibility.Hidden;
        }

        private void MenuItem_WenHuaZiYuan_Click(object sender, RoutedEventArgs e)
        {
            HideEveryContent();
            mainContent6.Visibility = System.Windows.Visibility.Visible;
            grid_ZiYuanTongChou_KongJianZiYuan.Visibility = System.Windows.Visibility.Hidden;
            grid_ZiYuanTongChou_RenLiZiYuan.Visibility = System.Windows.Visibility.Hidden;
            grid_ZiYuanTongChou_CaiZhengZiYuan.Visibility = System.Windows.Visibility.Hidden;
            grid_ZiYuanTongChou_WenHuaZiYuan.Visibility = System.Windows.Visibility.Visible;
        }
        private void btn_KongJianZiYuan_Satellite_Click(object sender, RoutedEventArgs e)
        {
            GoogleMapHelper m_GoogleMapHelper = new GoogleMapHelper();
            m_GoogleMapHelper.setMap(0, "31.22924594193164", "121.48104309082031");
            webBrowser_KongJianZiYuan_GoogleMap.Navigate(new Uri(strPATH + @"/html/GoogleMap.htm"));
        }

        private void btn_KongJianZiYuan_Roadmap_Click(object sender, RoutedEventArgs e)
        {
            GoogleMapHelper m_GoogleMapHelper = new GoogleMapHelper();
            m_GoogleMapHelper.setMap(1, "31.22924594193164", "121.48104309082031");
            webBrowser_KongJianZiYuan_GoogleMap.Navigate(new Uri(strPATH + @"/html/GoogleMap.htm"));
        }

        private void btn_KongJianZiYuan_Terrain_Click(object sender, RoutedEventArgs e)
        {
            GoogleMapHelper m_GoogleMapHelper = new GoogleMapHelper();
            m_GoogleMapHelper.setMap(2, "31.22924594193164", "121.48104309082031");
            webBrowser_KongJianZiYuan_GoogleMap.Navigate(new Uri(strPATH + @"/html/GoogleMap.htm"));
        }
        private void tabControl_KongJianZiYuan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (tabControl_KongJianZiYuan.SelectedIndex)
            {
                case 0:
                    tbx_KongJianZiYuan.Text = "城市濒临沅水，江北柳叶湖、占天湖紧临城区，德山开发区山峦起伏植被茂盛。城区主要街道干净整洁，空气新鲜，湖水明净。河洑森林公园、太阳山森林公园、德山森林公园环城而立，桃花源、花岩溪风景区也在1小时车程之内。\r\n一城三镇，特色鲜明。常德中心城区由江北城区、德山开发区和江南城区组成。江北是主城，市政府所在地，地势较低，东濒柳叶湖，北望太阳山，南滨沅江。\r\n建设用地比较分散，整个城市具有一城三镇的特点，其中每一镇区的建设用地又相对分散。因此人均建设用地达到102.24平方米，相对较大。\r\n现状建设用地面积29.82平方公里，城市人口29.76 万；德山经济技术开发区是工业区，地质条件较好，地势较高，不受洪水威胁，又是石长铁路的货运站和长常高速公路的终点。现状建设用地面积10.69平方公里，城市人口8.73万人。江南城区为原武陵县城，现为鼎城区政府所在地。这里大型专业批发市场发达，商贸繁荣，但地势低洼，最易受洪水威胁。现状建设用地面积7.79平方公里，城市人口8.76万人。";
                    break;
                case 1:
                    tbx_KongJianZiYuan.Text = "中心城区总人口：至2015年，中心城区总人口120万人以内；至2020年，中心城区总人口135万人以内；至2030年，中心城区总人口180万人以内。城市人口规模：至2015年，中心城区城市人口100万人以内；至2020年，中心城区城市人口115万人以内；至2030年，中心城区城市人口155万人以内。\r\n城市建设用地规模：2015年城市建设用地105平方公里以内；2020年城市建设用地118平方公里以内，2030年城市建设用地160平方公里以内，人均建设用地控制在104平方米以内。";
                    break;
                default:
                    break;
            }
        }
        private void calendar_CaiZhengZiYuan_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            //image_CaiZhengZiYuan.Source = 
        }

        private void tabControl_WenHuaZiYuan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (tabControl_WenHuaZiYuan.SelectedIndex)
            {
                case 0:
                    tbx_WenHuaZiYuan_LiShiHuiGu.Text = "名称由来\r\n1988年元月，国务院批准，撤销常德地区，建立省辖常德市，实行市领导县体制。\r\n原始社会\r\n30万年前，常德地区就有原始人群在沅、澧二水流域的平原山川生活、聚居。澧县澧南乡、张公庙镇、津市市窑坡乡、石门渫水下游一带以及鼎城区灌溪镇岗市等处有旧石器时代的遗迹40多处，经挖掘出土的石器有石片、石锤、石球、尖状器、砍砸器等。原始人利用这些简陋的原始工具采集果实，猎取野兽。\r\n澧县城头山遗址的发掘证明，距今9000年前，常德开始进入新石器时代，这时期的原始人已掌握了石器磨制和陶器制作技术。距今7000多年的石门皂市下层文化是中国新石器早期文化的代表之一。这时期生产工具已有河卵石加工磨制的斧、凿等砍伐用具和鱼网坠，并已掌握了原始制陶技术，生产简单的饮食器皿。\r\n距今6500多年的安乡汤家岗遗址，反映了常德当时以母性为主导地位的母系氏族社会的繁荣生活。距今5000多年的安乡划城岗遗址，是常德进入父系氏族社会的有力证明。这时期生产工\r\n\r\n常德市美图1 衡阳市刘安中拍(20张)具大为改进，石器钻孔、切割和抛光技术比较成熟，陶器普遍采用慢轮修整。\r\n封建社会\r\n公元前277年（秦昭襄王三十年）蜀守张若“伐取巫郡及江南”，在今武陵区城东建筑城池，设黔中郡，迄今2200多年历史。史称武陵、朗州、鼎州，曾是七朝郡治、七朝军府、七代藩封之地，辖区远及湘西北、鄂西南、黔东北、桂东北，素有“西楚唇齿”、“黔川咽喉”之称。\r\n近现代\r\n1914年，湖南省政府废除府、厅、州，保留“道”，岳常澧道改为武陵道，原常德府、直隶澧州各县由武陵道直辖，道治常德。公元1922年，湖南省撤消“道”制，仅存省与县两级，常德各县直属省管辖。\r\n1935年，国民政府在沅陵县设立湘西绥靖处，将19个县绥靖县划为5个行政督察区，设行政督察专员，专员兼任驻地县长。\r\n1936年，国民政府正式设立专员公署，石门、临澧、澧县划在第二区。\r\n1937年湖南省普遍设立行政督察区，第二区辖常德、华容、南县、安乡、沅江、汉寿、澧县、临澧、石门、慈利、桃源等11个县，专员公署治所由慈利县迁往常德县。\r\n1938年11月，第四区从常德迁往澧县，第四行政督察区专员公署也称常澧区专员公署。\r\n1940年，湖南省调整行政区划，行政督察区第二区改为第四区。\r\n1949年7月中旬至8月初，第四行政督察区各县先后获得解放。8月4日，南下途中组建的常澧区行政专员公署及全体工作人员抵达常德城。常澧专署为湖南省人民政府的派出机构，辖常德、华容、南县、安乡、澧县、临澧、慈利、桃源9县。8月中旬，各县相继成立人民政府，并分别于8月5日和8月15日建立常德市、津市市，成立人民政府。8月28日，常澧区更名为“湖南省人民政府常德区行政专员公署”（简称常德专署）。\r\n1955年2月16日，根据省人民政府已改为省人民委员会的通知，湖南省人民政府常德区专员公署改为湖南省常德专员公署。随后，各县市人民政府都改为人民委员会。\r\n1962年12月30日，国务院424号文件批准，恢复益阳专区，益阳市及益阳、桃江、南县、沅江、华容、安化六县划归益阳专署管辖。\r\n1966年3月，常德专区生产领导小组成立，代替常德专署行使职权。4月10日，专区生产领导小组撤消，成立常德专区抓革命促生产指挥部。11月，其名称改为常德地区抓革命促生产领导小组。1968年2月28日，常德地区革命委员会成立，行使原专署职权。3月至9月，各县（市）先后成立革命委员会，取代人民委员会。\r\n1979年3月24日，常德地区革命委员会撤消，常德地区行政公署成立。1979年11月至1980年12月，各县（市）撤消革命委员会，恢复县（市）人民政府。\r\n1988年元月，国务院以国函[1988]18号文件批准，撤消常德地区，建立省辖常德市，实行市领导县体制。4月18日，湖南省人民政府以湘政函[1988]22号文件通知，撤消常德地区和常德县，设两区，原常德市改为武陵区，原常德县改为鼎城区，两区行政区域不变，津市市为省辖县级市，省政府委托常德市代管。6月20日至24日，常德市召开第一届人民代表大会，正式成立常德市人民政府，选出正副市长。\r\n截至2002年，常德市辖2个市辖区、6个县，代管1个县级市；全市共有10个街道、104个镇、105个乡；434个居委会、4004个村委会。\r\n截至2004年12月31日，常德市辖2个市辖区、6个县，代管1个县级市；全市共有10个街道、104个镇、106个乡。　\r\n截至2005年12月31日，常德市辖2个市辖区、6个县，代管1个县级市；全市共有10个街道、104个镇、99个乡、4个民族乡。";
                    break;
                case 1:
                    break;
                case 2:
                    tbx_WenHuaZiYuan_FeiWuZhiBaoZang1.Text = "方言\r\n常德方言属于北方方言的次方言——西南官话。这与历史上大规模的移民密切相关。据史料记载：秦汉以来，不断有北方居民南迁。西晋末年的永嘉丧乱，引起北方人口第一次大南迁，大量人口沿汉水流域南下，渡江到达洞庭流域，这次大迁徙一直延续到南北朝。唐朝的安史之乱，曾使“襄邓(湖北襄阳和河南南阳)百姓，两京衣冠(长安、洛阳贵族)尽投江湘，故荆南井邑，十倍其初。”北方居民迁徙规模大，人数多，地域集中，使其语言不仅难以被本地土著语言所同化，反而给当地土著语言以巨大的冲击，这是常德话与北方话产生亲缘关系的历史渊源。另外，从唐朝至南宋末年，澧朗二州(今常德)一直归人以荆州(江陵府)为中心的政区，客观上促使了常德话与北方话的交流、融合、同化。可以说，常德方言自古以来一直受到北方话的浸润、冲刷，最后终于与之融为一体。尽管明清以来，大量的江西居民迁至常德，但由于规模较小，地域、时间不够集中，因而并没有对常德方言产生大的冲击，最终被常德方言所同化。r\n\r\n习俗\r\n常德城乡概以大米饭为主食，无论老少，有嗜辣习惯，爱吃糌辣椒、油炸辣椒、辣子酱、白辣椒。有腌制坛子菜、腌腊鱼腊肉的习惯。\r\n常德盛产稻米，久而久之，形成了以大米为主要原料的大众化小吃食品。在80年代后，米粉逐渐成为常德城镇居民早餐的主食。发糕，油粑粑，煎米茶，作为早餐，一般是边吃油粑粑，边喝煎米茶。\r\n常德人喝茶很讲究，除一般泡茶外，还盛行擂茶待客。相传喝擂茶起源于东汉初年。当时马援征“五溪蛮”，兵困壶头山，瘟疫流行。土人教以用生姜、盐、茶叶、煎米制作此茶，饮后瘟疫即除，遂沿袭至今\r\n\r\n全国围棋之乡\r\n2012年9月13日晚，在第三届世界围棋名人争霸战闭幕式上，赛事举办方常德市被中国围棋协会授予“全国围棋之乡”，成为湖南省首个获此殊荣的城市。";
                    tbx_WenHuaZiYuan_FeiWuZhiBaoZang2.Text = "城市名片\r\n桃花源里的城市\r\n全国文明城市[6]\r\n国家卫生城市\r\n中国优秀旅游城市\r\n国家园林城市\r\n中华诗词之市\r\n中国魅力城市\r\n国际花园城市\r\n全国文明创建模范城市\r\n全国交通管理模范市\r\n中国最佳人居环境城市\r\n国家社会治安综合治理先进城市\r\n国家科技进步先进市";
                    tbx_WenHuaZiYuan_FeiWuZhiBaoZang3.Text = "友好城市\r\n东近江市日本2005年7月27日缔结\r\n安妮阿伦德尔县美国2005年1月27日缔结\r\n季米特洛夫格勒市（Dimitrovgrad） 俄罗斯2006年11月7日缔结\r\n伊普斯维奇市（Ipswich） 澳大利亚2007年7月12日结\r\n海口市 中国 2003年12月7日缔结\r\n汉诺威市 德国 2010年7月10日缔结\r\n无锡 中国 2007年缔结  ";
                    break;
                case 3:
                    break;
                default:
                    break;
            }
        }
        //////////////////////////////////////////////////////////////////////////////////

        public void maincontent2()
        {
            HideEveryContent();
            //mainContent.Visibility = System.Windows.Visibility.Hidden;
            mainContent2.Visibility = System.Windows.Visibility.Visible;
            //mainContent3.Visibility = System.Windows.Visibility.Hidden;
            //mainContent4.Visibility = System.Windows.Visibility.Hidden;
            //wbEmergency.Visibility = System.Windows.Visibility.Hidden;
            //wbTraffic.Visibility = System.Windows.Visibility.Hidden;
            //wbenvironment.Visibility = System.Windows.Visibility.Hidden;
            //w_webBrowser1.Visibility = System.Windows.Visibility.Hidden;
            //MaxEmergency.Visibility = System.Windows.Visibility.Hidden;
            //CreateEngineControls();
            //LoadMap();
        }


        private void checkBoxShenQingPiShiSendCopy1_1_Click(object sender, RoutedEventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            if (chk.IsChecked == true)
            {
                listBoxSendCopy.Items.Add(chk.Content);
            }
            else
            {
                listBoxSendCopy.Items.Remove(chk.Content);
            }
        }

        private void tabItem_RenLiZiYuan_ShiZhengFuZuZhiJiGou_Loaded(object sender, RoutedEventArgs e)
        {
            DataSet_HumanResourceTableAdapters.T_HumanResourceTableAdapter adapter = new DataSet_HumanResourceTableAdapters.T_HumanResourceTableAdapter();
            DataSet_HumanResource.T_HumanResourceDataTable dt = adapter.GetDataByClassTag("市政府组织机构");
            dataGrid_RenLiZiYuan_ShiZhengFuZuZhiJiGou.ItemsSource = dt;
        }

        private void tabItem_RenLiZiYuan_ShiWeiQunTuanDangPai_Loaded(object sender, RoutedEventArgs e)
        {
            DataSet_HumanResourceTableAdapters.T_HumanResourceTableAdapter adapter = new DataSet_HumanResourceTableAdapters.T_HumanResourceTableAdapter();
            DataSet_HumanResource.T_HumanResourceDataTable dt = adapter.GetDataByClassTag("市委、群团、党派");
            dataGrid_RenLiZiYuan_ShiWeiQunTuanDangPai.ItemsSource = dt;
        }

        private void tabItem_RenLiZiYuan_ZhengFaJiGou_Loaded(object sender, RoutedEventArgs e)
        {
            DataSet_HumanResourceTableAdapters.T_HumanResourceTableAdapter adapter = new DataSet_HumanResourceTableAdapters.T_HumanResourceTableAdapter();
            DataSet_HumanResource.T_HumanResourceDataTable dt = adapter.GetDataByClassTag("政法机构");
            dataGrid_RenLiZiYuan_ZhengFaJiGou.ItemsSource = dt;
        }

        private void tabItem_RenLiZiYuan_ShengGuanDanWei_Loaded(object sender, RoutedEventArgs e)
        {
            DataSet_HumanResourceTableAdapters.T_HumanResourceTableAdapter adapter = new DataSet_HumanResourceTableAdapters.T_HumanResourceTableAdapter();
            DataSet_HumanResource.T_HumanResourceDataTable dt = adapter.GetDataByClassTag("省管单位");
            dataGrid_RenLiZiYuan_ShengGuanDanWei.ItemsSource = dt;
        }

        private void tabItem_RenLiZiYuan_QuXianGuanLiChu_Loaded(object sender, RoutedEventArgs e)
        {
            DataSet_HumanResourceTableAdapters.T_HumanResourceTableAdapter adapter = new DataSet_HumanResourceTableAdapters.T_HumanResourceTableAdapter();
            DataSet_HumanResource.T_HumanResourceDataTable dt = adapter.GetDataByClassTag("区县、管理处");
            dataGrid_RenLiZiYuan_QuXianGuanLiChu.ItemsSource = dt;
        }

        private void MenuItem_RiChengAnPai_Click(object sender, RoutedEventArgs e)
        {
            HideEveryContent();
            mainContent7.Visibility = System.Windows.Visibility.Visible;
            grid_RiChangJueCe_RiChengAnPai.Visibility = System.Windows.Visibility.Visible;
            webBrowser_GoogleCalendar.Navigate(new Uri(strPATH + @"/html/GoogleCalendar.htm", UriKind.RelativeOrAbsolute));
        }

        private void calendar1_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            textBox_Calendar.Clear();
            string str = ((DateTime)calendar1.SelectedDate).ToShortDateString();
            DataSetCalendarTableAdapters.T_CalendarTableAdapter adapter = new DataSetCalendarTableAdapters.T_CalendarTableAdapter();
            DataSetCalendar.T_CalendarDataTable dt = adapter.GetDataByDate(str);
            if (dt.Rows.Count != 0)
            {
                textBox_Calendar.Text = dt[0].calendar_tbx;
            }
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
                MenuBg6.Fill = (Brush)Window.Resources["leftcontentmenu2"];
                Menutext6.Foreground = (Brush)Window.Resources["white"];
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
                MenuBg6.Fill = (Brush)Window.Resources["leftcontentmenu1"];
                Menutext6.Foreground = (Brush)Window.Resources["black"];
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

        private void mainContent8_ZiRanZaiHai_Loaded(object sender, RoutedEventArgs e)
        {
            //tbx_YingJiYuAn.Text = "火灾应急预案\r\n一、组织实施：\r\n１、要迅速组织人员逃生，原则是“先救人，后救物”。\r\n２、参加人员：在消防车到来之前，在确保自身安全的情况下均有义务参加扑救。\r\n３、消防车到来之后，要配合消防专业人员扑救或做好辅助工作。\r\n４、使用器具：灭火器、水桶、消防水带等。\r\n二、扑救方法：\r\n１、扑救固体物品火灾，如木制品，棉织品等，可使用各类灭火器具。\r\n２、扑救液体物品火灾，如汽油、柴油、食用油等，只能使用灭火器、沙土、浸湿的棉被等，绝对不能用水扑救。\r\n３、如系电力系统引发的火灾，应当先切断电源，而后组织扑救。切断电源前，不得使用水等导电性物质灭火。\r\n三、注意事项：\r\n１、火灾事故首要的一条是保护人员安全，扑救要在确保人员不受伤害的前提下进行。\r\n２、火灾第一发现人应判断原因，立即切断电源。\r\n３、火灾发生后应掌握的原则是边救火，边报警。\r\n４、人是第一可宝贵的，在生命和财产之间，首先保全生命，采取一切必要措施，避免人员伤亡。 ";
            tbx_ZiRanZaiHai_ShiJianShiShiGengXin.Text = "事件实时更新\r\n发生时间：2012年8月13日，13：56\r\n发生地点：同济大学体育馆工地西北\r\n事件情况：";
            tbx_ZiRanZaiHai_ShiJianQingKuang.Text = "（v1208131359）施工操作不当，引发施工现场起火，火势较大。\r\n（v1208131403）建筑中有工人被困，大约为6-9人。\r\n（v1208131411）第一辆救火车赶到现场，开始进行灭火操作，人员全部安全转移，初步确定无伤亡。\r\n（v1208131417）第二辆救火车和救护车赶到现场\r\n（v1208131422）。。。";
            DirectoryInfo di = new DirectoryInfo(System.Environment.CurrentDirectory);
            string pathEmergency = di.Parent.Parent.FullName;
            ds = new EmergencyBasic();
            webBrowser_ZiRanZaiHai.Navigate(new Uri(pathEmergency + @"/html/ZiRanZaiHai.htm", UriKind.RelativeOrAbsolute));//获取根目录的日历文件
            webBrowser_ZiRanZaiHai.ObjectForScripting = ds;//该对象可由显示在WebBrowser控件中的网页所包含的脚本代码访问
            textBlock_TuFaShiJian_DiTuXinXi.Text = "可调用资源。。。。。。\r\n周边设施。。。。。。";
            radioButton_ZiRanZaiHai_QuanBu.IsChecked = false;
            radioButton_ZiRanZaiHai_HuoJin.IsChecked = true;
            radioButton_ZiRanZaiHai_JiuHu.IsChecked = true;
            radioButton_ZiRanZaiHai_MinJing.IsChecked = false;
            radioButton_ZiRanZaiHai_YiYuan.IsChecked = false;
            btn_ZiRanZaiHai_ZuZhiShiShi_Click(sender, e);
        }

        private void MenuItem_TuFaShiJian_ZiRanZaiHai_Click(object sender, RoutedEventArgs e)
        {
            HideEveryContent();
            mainContent8_ZiRanZaiHai.Visibility = System.Windows.Visibility.Visible;
        }

        private void btn_ZiRanZaiHai_ZuZhiShiShi_Click(object sender, RoutedEventArgs e)
        {
            label_ZiRanZaiHai_YingJiYuAn_Subtitle.Content = "一、组织实施";
            textBlock_ZiRanZaiHai_YingJiYuAn.Text = "1、要迅速组织人员逃生，原则是“先救人，后救物”。\r\n2、参加人员：在消防车到来之前，在确保自身安全的情况下均有义务参加扑救。\r\n3、消防车到来之后，要配合消防专业人员扑救或做好辅助工作。\r\n4、使用器具：灭火器、水桶、消防水带等。";
        }

        private void btn_ZiRanZaiHai_PuJiuFangFa_Click(object sender, RoutedEventArgs e)
        {
            label_ZiRanZaiHai_YingJiYuAn_Subtitle.Content = "二、扑救方法";
            textBlock_ZiRanZaiHai_YingJiYuAn.Text = "扑救方法内容";
        }

        private void btn_ZiRanZaiHai_ZhuYiShiXiang_Click(object sender, RoutedEventArgs e)
        {
            label_ZiRanZaiHai_YingJiYuAn_Subtitle.Content = "三、注意事项";
            textBlock_ZiRanZaiHai_YingJiYuAn.Text = "注意事项内容";
        }


    }
}