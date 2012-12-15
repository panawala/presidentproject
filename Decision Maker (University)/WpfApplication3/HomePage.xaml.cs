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
using System.Data;
using WpfZhihui;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Net;

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        string strPATH;
        public HomePage()
        {
            InitializeComponent();
            DirectoryInfo di;
            di = new DirectoryInfo(System.Environment.CurrentDirectory);
            strPATH = di.Parent.Parent.FullName;
            webbrowserEnvironment.Navigate(new Uri(strPATH + @"/html/tufashijian.html", UriKind.RelativeOrAbsolute));
            webbrowserEnvironment1.Navigate(new Uri(strPATH + @"/html/tufashijian1.html", UriKind.RelativeOrAbsolute));
            webbrowserEnvironment2.Navigate(new Uri(strPATH + @"/html/tufashijian2.html", UriKind.RelativeOrAbsolute));

            //webbrowserTraffic.Navigate(new Uri(strPATH + @"/html/Traffic.htm", UriKind.RelativeOrAbsolute));
            webbrowserTraffic.Navigate(new Uri(strPATH + @"/html/xiaoyuanhuodong.htm", UriKind.RelativeOrAbsolute));
            webbrowserTraffic1.Navigate(new Uri(strPATH + @"/html/xiaoyuanhuodong1.htm", UriKind.RelativeOrAbsolute));
            ds = new EmergencyBasic();
            //webbrowserEmergency.Navigate(new Uri(strPATH + @"/html/Emergency.htm", UriKind.RelativeOrAbsolute));
            webbrowserEmergency.Navigate(new Uri(strPATH + @"/html/GreenDetect.htm", UriKind.RelativeOrAbsolute));
            webbrowserEmergency.ObjectForScripting = ds;
            loadWeather();
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

        /// <summary>
        /// 绿色检测,数据契约
        /// </summary>
        [DataContract]
        public class GreenDetect
        {
            [DataMember(Order = 1)]
            public double Longitude { get; set; }
            [DataMember(Order = 2)]
            public double Latitude { get; set; }
            [DataMember(Order = 3)]
            public string Name { get; set; }
            [DataMember(Order = 4)]
            public string Water { get; set; }
            [DataMember(Order = 5)]
            public string Energy { get; set; }
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
                if (strlocation.Equals("绿色监测"))
                {
                    List<GreenDetect> m_greenDetectlist = new List<GreenDetect> { 
                    new GreenDetect{
                    Latitude=31.288236,
                    Longitude=121.508837,
                    Energy="23",
                    Water="23",
                    Name="水耗能耗"
                    },
                    new GreenDetect{
                    Latitude=31.289236,
                    Longitude=121.505837,
                    Energy="23",
                    Water="23",
                    Name="水耗能耗"
                    },
                    new GreenDetect{
                    Latitude=31.288236,
                    Longitude=121.506837,
                    Energy="23",
                    Water="23",
                    Name="水耗能耗"
                    },
                    new GreenDetect{
                    Latitude=31.287236,
                    Longitude=121.508837,
                    Energy="23",
                    Water="23",
                    Name="水耗能耗"
                    },
                    new GreenDetect{
                    Latitude=31.286236,
                    Longitude=121.507837,
                    Energy="23",
                    Water="23",
                    Name="水耗能耗"
                    },
                    };

                    strlocation = ToJsJson(m_greenDetectlist);
                    this.Name = strlocation;
                    return;
                }
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

        public void loadWeather()
        {
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

            //Uri uri = new Uri(imgPath, UriKind.Absolute);
            //BitmapImage bmp = new BitmapImage(uri);
            //w_imageWeather.Source = bmp;
            webbrowserWeather.Source = new Uri("http://flash.weather.com.cn/sk2/shikuang.swf?id=101020100");

            WeatherWebService.WeatherWebServiceSoapClient ws = new WeatherWebService.WeatherWebServiceSoapClient();
            string[] strWeather = ws.getWeatherbyCityName("上海");
            if (strWeather[8] == "")
            {
                MessageBox.Show("天气预报WebService系统维护中...");
                return;
            }
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

        private void btnEnvironmentRefresh_Click(object sender, RoutedEventArgs e)
        {
            if (webbrowserEnvironment.Document != null)
                webbrowserEnvironment.Refresh();
            if (webbrowserEnvironment1.Document != null)
                webbrowserEnvironment1.Refresh();
            if (webbrowserEnvironment2.Document != null)
                webbrowserEnvironment2.Refresh();
        }

        private void btn_maxenvironment_Click(object sender, RoutedEventArgs e)
        {
            PageMaxEnvironment m_PageMaxEnvironment = new PageMaxEnvironment();
            this.NavigationService.Navigate(m_PageMaxEnvironment);
        }

        private void btnTrafficRefresh_Click(object sender, RoutedEventArgs e)
        {
            if (webbrowserTraffic.Document != null)
                webbrowserTraffic.Refresh();
            if (webbrowserTraffic1.Document != null)
                webbrowserTraffic1.Refresh();
        }

        private void btn_maxtraffic_Click(object sender, RoutedEventArgs e)
        {
            PageMaxTraffic m_PageMaxTraffic = new PageMaxTraffic();
            this.NavigationService.Navigate(m_PageMaxTraffic);
        }

        private void btnEmergencyRefresh_Click(object sender, RoutedEventArgs e)
        {
            if (webbrowserEmergency.Document != null)
                webbrowserEmergency.Refresh();
        }

        private void btn_maxemergency_Click(object sender, RoutedEventArgs e)
        {
            PageMaxEmergency m_PageMaxEmergency = new PageMaxEmergency();
            this.NavigationService.Navigate(m_PageMaxEmergency);
        }

        private void btnWeatherRefresh_Click(object sender, RoutedEventArgs e)
        {
            if (webbrowserWeather.Document != null)
                webbrowserWeather.Refresh();
        }

        private void btn_maxweather_Click(object sender, RoutedEventArgs e)
        {
            PageMaxWeather m_PageMaxWeather = new PageMaxWeather();
            this.NavigationService.Navigate(m_PageMaxWeather);
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

    }
}
