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

namespace WpfApplication3.Development_performance
{
    /// <summary>
    /// Interaction logic for GreenCampus.xaml
    /// </summary>
    public partial class GreenCampus : Page
    {
        public GreenCampus()
        {
            InitializeComponent();
        }

        protected void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string strPATH;
            DirectoryInfo di;
            di = new DirectoryInfo(System.Environment.CurrentDirectory);
            strPATH = di.Parent.Parent.FullName;
            ds = new EmergencyBasic();
            W_xiaohao.Navigate(new Uri(strPATH + @"/html/GreenDetect.htm", UriKind.RelativeOrAbsolute));
            W_xiaohao.ObjectForScripting = ds;
            W_huanjing.Navigate(new Uri(strPATH + @"/html/GreenDetect.htm", UriKind.RelativeOrAbsolute));
            W_huanjing.ObjectForScripting = ds;
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
        private void Button_xiaohao_Click(object sender, RoutedEventArgs e)
        {
            xiaohao.Visibility = System.Windows.Visibility.Visible;
            huanjing.Visibility = System.Windows.Visibility.Collapsed;
            W_xiaohao.Visibility = System.Windows.Visibility.Visible;
            W_huanjing.Visibility = System.Windows.Visibility.Collapsed;
            shishishuju1.Visibility = System.Windows.Visibility.Visible;
            shishishuju2.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void Button_huanjing_Click(object sender, RoutedEventArgs e)
        {
            xiaohao.Visibility = System.Windows.Visibility.Collapsed;
            huanjing.Visibility = System.Windows.Visibility.Visible;
            W_xiaohao.Visibility = System.Windows.Visibility.Collapsed;
            W_huanjing.Visibility = System.Windows.Visibility.Visible;
            shishishuju1.Visibility = System.Windows.Visibility.Collapsed;
            shishishuju2.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
