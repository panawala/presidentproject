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
using System.Web;
using System.Runtime.Serialization;

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<NewsItem> items = new List<NewsItem>();
        public MainWindow()
        {
            this.InitializeComponent();
            LoadRss();
            // Insert code required on object creation below this point.
            DirectoryInfo di = new DirectoryInfo(System.Environment.CurrentDirectory);
            string pathTraffic = di.Parent.Parent.FullName;
            wbTraffic.Navigate(new Uri(pathTraffic + @"/html/Traffic.htm", UriKind.RelativeOrAbsolute));
            string pathEmergency = di.Parent.Parent.FullName;
            ds = new EmergencyBasic();
            wbEmergency.Navigate(new Uri(pathEmergency + @"/html/Emergency.htm", UriKind.RelativeOrAbsolute));//获取根目录的日历文件
            wbEmergency.ObjectForScripting = ds;//该对象可由显示在WebBrowser控件中的网页所包含的脚本代码访问

            string pathEnvironment = di.Parent.Parent.FullName;
            ds1 = new EnvironmentBasic();
            wbenvironment.Navigate(new Uri(pathEnvironment + @"/html/Environment.htm", UriKind.RelativeOrAbsolute));//获取根目录的日历文件
            wbenvironment.ObjectForScripting = ds1;//该对象可由显示在WebBrowser控件中的网页所包含的脚本代码访问
        }
        public void LoadRss()
        {
            //string channeltitle = "网易头条";
            //string  channellink ="http://news.163.com/";
            //string rsspath = "http://news.163.com/special/00011K6L/rss_newstop.xml";//RSS地址
            string[] rsspath ={ "http://news.163.com/special/00011K6L/rss_newstop.xml",
                                   "http://www.xinhuanet.com/politics/news_politics.xml",
                                   "http://news.baidu.com/n?cmd=1&class=civilnews&tn=rss&sub=0",
                                   "http://www.shanghai.gov.cn/shanghai/node27041/node27044/index.xml",
                                   "http://news.online.sh.cn/news/gb/special/news.xml",
                                   "http://rss.sina.com.cn/news/china/focus15.xml"};//RSS地址
            string[] channeltitle ={"网易头条",
                                   "新华时政",
                                   "百度国内焦点",
                                   "中国上海",
                                   "上海新闻热线",
                                   "新浪新闻"};
            string[] channellink ={"http://news.163.com/",
                                   "http://www.xinhuanet.com/politics/xw.htm",
                                   "http://news.baidu.com",
                                   "http://www.shanghai.gov.cn/shanghai/node2314/index.html",
                                   "http://news.online.sh.cn/news/gb/node/news_default.htm",
                                   "http://news.sina.com.cn"};
            string[] logopath = {
                                "/Images/网易.jpg",
                                "/Images/新华.jpg",
                                "/Images/百度.jpg",
                                "/Images/中国上海.jpg",
                                "/Images/上海热线.jpg",
                                "/Images/新浪.jpg"};
            for (int cid = 0; cid < 6; cid++)
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
                XmlNode node = list.Item(1);//
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
            DirectoryInfo di = new DirectoryInfo(System.Environment.CurrentDirectory);
            string strPath = di.Parent.Parent.FullName;
            BitmapImage image = new BitmapImage(new Uri(strPath + @"/weatherlogo/a_" + strWeather[8], UriKind.RelativeOrAbsolute));
            w_image1.Source = image;
            w_label1.Content = strWeather[6];
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
            image = new BitmapImage(new Uri(strPath + @"/weatherlogo/b_" + strWeather[8], UriKind.RelativeOrAbsolute));
            w_image2.Source = image;
            image = new BitmapImage(new Uri(strPath + @"/weatherlogo/b_" + strWeather[15], UriKind.RelativeOrAbsolute));
            w_image3.Source = image;
            image = new BitmapImage(new Uri(strPath + @"/weatherlogo/b_" + strWeather[20], UriKind.RelativeOrAbsolute));
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
            string strPath = diDebug.FullName;
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
            catch (Exception ex)
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
                if (strlocation == "火灾")
                {

                    ijudge = 1;
                }
                if (strlocation == "突发事件")
                {
                    ijudge = 2;
                }
                DataTable dt = new DataTable();
                SQLHelper.getPointsByCategory(ijudge, out dt);
                List<Location> m_list = new List<Location>();

                for (int ix = 0; ix < dt.Rows.Count; ix++)
                {
                    Location new_Location = new Location();
                    new_Location.Name = dt.Rows[ix]["Name"].ToString();
                    new_Location.Description = dt.Rows[ix]["Description"].ToString();
                    new_Location.Longitude = (double)dt.Rows[ix]["ilng"];
                    new_Location.Latitude = (double)dt.Rows[ix]["ilat"];

                    m_list.Add(new_Location);
                }
                strlocation = ToJsJson(m_list);
                this.Name = strlocation;
            }

        }
        public EnvironmentBasic ds1;
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
                    new_Location.Longitude = (double)dtEnv.Rows[ix]["ilng"];
                    new_Location.Latitude = (double)dtEnv.Rows[ix]["ilat"];

                    m_listEnv.Add(new_Location);
                }
                strEnv = ToJsJson(m_listEnv);
                this.Name = strEnv;
            }
        }




        private void imageTVCover_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Dongfangweishi.IsSelected = true;
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string ix = (e.AddedItems[0].ToString().Split(' '))[1];
            DirectoryInfo di;
            string strPath;
            if (ix == "东方卫视")
            {
                imageTVCover.Visibility = Visibility.Hidden;
                WebBrowserTV.Visibility = Visibility.Visible;
                di = new DirectoryInfo(System.Environment.CurrentDirectory);
                strPath = di.Parent.Parent.FullName;
                WebBrowserTV.Navigate(new Uri(strPath + @"/html/zhiboDongfangweishi.htm", UriKind.RelativeOrAbsolute));

            }
            else if (ix == "CCTV新闻")
            {
                imageTVCover.Visibility = Visibility.Hidden;
                WebBrowserTV.Visibility = Visibility.Visible;
                di = new DirectoryInfo(System.Environment.CurrentDirectory);
                strPath = di.Parent.Parent.FullName;
                WebBrowserTV.Navigate(new Uri(strPath + @"/html/zhiboCCTV13.htm", UriKind.RelativeOrAbsolute));
            }
            else if(ix=="CCTV体育")
            {
                imageTVCover.Visibility = Visibility.Hidden;
                WebBrowserTV.Visibility = Visibility.Visible;
                di = new DirectoryInfo(System.Environment.CurrentDirectory);
                strPath = di.Parent.Parent.FullName;
                WebBrowserTV.Navigate(new Uri(strPath + @"/html/zhiboCCTV5.htm", UriKind.RelativeOrAbsolute));
            }
            else if (ix == "五星体育")
            {
                imageTVCover.Visibility = Visibility.Hidden;
                WebBrowserTV.Visibility = Visibility.Visible;
                di = new DirectoryInfo(System.Environment.CurrentDirectory);
                strPath = di.Parent.Parent.FullName;
                WebBrowserTV.Navigate(new Uri(strPath + @"/html/zhiboWuxingtiyu.htm", UriKind.RelativeOrAbsolute));
            }

        }
    }
}