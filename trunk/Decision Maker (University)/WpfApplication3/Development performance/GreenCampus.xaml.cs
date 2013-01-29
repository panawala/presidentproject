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
using WpfApplication3.CreateChart;
using Visifire.Charts;

namespace WpfApplication3.Development_performance
{
    /// <summary>
    /// Interaction logic for GreenCampus.xaml
    /// </summary>
    public partial class GreenCampus : Page
    {

        MainWindow controlmenu;
        public GreenCampus(int defaultTabItem, MainWindow p)
        {
            InitializeComponent();
            controlmenu = p;
            switch (defaultTabItem){
                case 1:
                    tabI_resource.IsSelected = true;

                    break;
                case 2:
                    tabI_environment.IsSelected = true;
                    break;
            }
        }

        protected void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string strPATH;
            DirectoryInfo di;
            di = new DirectoryInfo(System.Environment.CurrentDirectory);
            strPATH = di.Parent.Parent.FullName;
            ds = new EmergencyBasic();
            W_xiaohao.Navigate(new Uri(strPATH + @"/html/GreenDetect1.htm", UriKind.RelativeOrAbsolute));
            W_xiaohao.ObjectForScripting = ds;
            W_huanjing.Navigate(new Uri(strPATH + @"/html/GreenDetect.htm", UriKind.RelativeOrAbsolute));
            W_huanjing.ObjectForScripting = ds;

            CreateChart.ChartInformation ci1 = new ChartInformation()
            {
                m_BorderThickness = new Thickness(1.0),
                m_Theme = "Theme1",
                m_View3D = true,
                m_axisXTitle = "水耗",
                m_axisYTitle = "",
                m_axisYMaximum = 100,
                m_axisYInterval = 20,
                dsc = new DataSeriesCollection()
                    {
                        new DataSeries()
                        {
                            LegendText = "",
                            RenderAs = RenderAs.Column,
                            AxisYType = AxisTypes.Primary,
                            DataPoints = new DataPointCollection()
                            {
                                new DataPoint()
                                {
                                    AxisXLabel = "1月",
                                    YValue = 25,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2月",
                                    YValue = 18,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "3月",
                                    YValue = 35,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "4月",
                                    YValue = 25,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "5月",
                                    YValue = 25,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "6月",
                                    YValue = 18,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "7月",
                                    YValue = 35,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "8月",
                                    YValue = 25,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "9月",
                                    YValue = 25,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "10月",
                                    YValue = 18,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "11月",
                                    YValue = 35,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "12月",
                                    YValue = 25,
                                },
                            }
                        },
                    },
            };
            CreateChart.ChartInformation ci2 = new ChartInformation()
            {
                m_BorderThickness = new Thickness(1.0),
                m_Theme = "Theme1",
                m_View3D = true,
                m_axisXTitle = "能耗",
                m_axisYTitle = "",
                m_axisYMaximum = 100,
                m_axisYInterval = 20,
                dsc = new DataSeriesCollection()
                    {
                        new DataSeries()
                        {
                            LegendText = "",
                            RenderAs = RenderAs.Line,
                            AxisYType = AxisTypes.Primary,
                            DataPoints = new DataPointCollection()
                            {
                                new DataPoint()
                                {
                                    AxisXLabel = "1月",
                                    YValue = 25,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2月",
                                    YValue = 18,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "3月",
                                    YValue = 35,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "4月",
                                    YValue = 25,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "5月",
                                    YValue = 25,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "6月",
                                    YValue = 18,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "7月",
                                    YValue = 35,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "8月",
                                    YValue = 25,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "9月",
                                    YValue = 25,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "10月",
                                    YValue = 18,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "11月",
                                    YValue = 35,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "12月",
                                    YValue = 25,
                                },
                            }
                        },
                    },
            };

            ChartHelper ch = new ChartHelper();
            Chart m_chart1 = ch.CreateChart(ci1);
            gridGraph1.Children.Clear();
            gridGraph1.Children.Add(m_chart1);

            Chart m_chart2 = ch.CreateChart(ci2);
            gridGraph2.Children.Clear();
            gridGraph2.Children.Add(m_chart2);

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
                    Energy="12",
                    Water="33",
                    Name="水耗能耗"
                    },
                    new GreenDetect{
                    Latitude=31.289236,
                    Longitude=121.505837,
                    Energy="8",
                    Water="14",
                    Name="水耗能耗"
                    },
                    new GreenDetect{
                    Latitude=31.288236,
                    Longitude=121.506837,
                    Energy="15",
                    Water="21",
                    Name="水耗能耗"
                    },
                    new GreenDetect{
                    Latitude=31.287236,
                    Longitude=121.508837,
                    Energy="33",
                    Water="9",
                    Name="水耗能耗"
                    },
                    new GreenDetect{
                    Latitude=31.286236,
                    Longitude=121.507837,
                    Energy="41",
                    Water="35",
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

        public EmergencyBasic1 ds1;
        [System.Runtime.InteropServices.ComVisibleAttribute(true)]//将该类设置为com可访问



        public class EmergencyBasic1
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
                    Water="45",
                    Name="水耗能耗"
                    },
                    new GreenDetect{
                    Latitude=31.289236,
                    Longitude=121.505837,
                    Energy="55",
                    Water="46",
                    Name="水耗能耗"
                    },
                    new GreenDetect{
                    Latitude=31.288236,
                    Longitude=121.506837,
                    Energy="76",
                    Water="82",
                    Name="水耗能耗"
                    },
                    new GreenDetect{
                    Latitude=31.287236,
                    Longitude=121.508837,
                    Energy="22",
                    Water="52",
                    Name="水耗能耗"
                    },
                    new GreenDetect{
                    Latitude=31.286236,
                    Longitude=121.507837,
                    Energy="12",
                    Water="47",
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
        public EmergencyBasic2 ds2;
        [System.Runtime.InteropServices.ComVisibleAttribute(true)]//将该类设置为com可访问



        public class EmergencyBasic2
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
                    Energy="107",
                    Water="155",
                    Name="水耗能耗"
                    },
                    new GreenDetect{
                    Latitude=31.289236,
                    Longitude=121.505837,
                    Energy="256",
                    Water="146",
                    Name="水耗能耗"
                    },
                    new GreenDetect{
                    Latitude=31.288236,
                    Longitude=121.506837,
                    Energy="89",
                    Water="109",
                    Name="水耗能耗"
                    },
                    new GreenDetect{
                    Latitude=31.287236,
                    Longitude=121.508837,
                    Energy="79",
                    Water="117",
                    Name="水耗能耗"
                    },
                    new GreenDetect{
                    Latitude=31.286236,
                    Longitude=121.507837,
                    Energy="114",
                    Water="205",
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

        private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        { 
            string strPATH;
            DirectoryInfo di;
            di = new DirectoryInfo(System.Environment.CurrentDirectory);
            strPATH = di.Parent.Parent.FullName;

            if((slider1.Value == 0)||(slider1.Value == 3)||(slider1.Value == 6)||(slider1.Value == 9))
            {
               
                ds = new EmergencyBasic();
                W_xiaohao.Navigate(new Uri(strPATH + @"/html/GreenDetect1.htm", UriKind.RelativeOrAbsolute));
                W_xiaohao.ObjectForScripting = ds;
                W_huanjing.Navigate(new Uri(strPATH + @"/html/GreenDetect.htm", UriKind.RelativeOrAbsolute));
                W_huanjing.ObjectForScripting = ds;
            }
            else if ((slider1.Value == 1) || (slider1.Value == 4) || (slider1.Value == 7) || (slider1.Value == 10))
            {
                ds1 = new EmergencyBasic1();
                W_xiaohao.Navigate(new Uri(strPATH + @"/html/GreenDetect1.htm", UriKind.RelativeOrAbsolute));
                W_xiaohao.ObjectForScripting = ds1;
                W_huanjing.Navigate(new Uri(strPATH + @"/html/GreenDetect.htm", UriKind.RelativeOrAbsolute));
                W_huanjing.ObjectForScripting = ds1;
            }
            else if ((slider1.Value == 2) || (slider1.Value == 8) || (slider1.Value == 11))
            {
                ds2 = new EmergencyBasic2();
                W_xiaohao.Navigate(new Uri(strPATH + @"/html/GreenDetect1.htm", UriKind.RelativeOrAbsolute));
                W_xiaohao.ObjectForScripting = ds2;
                W_huanjing.Navigate(new Uri(strPATH + @"/html/GreenDetect.htm", UriKind.RelativeOrAbsolute));
                W_huanjing.ObjectForScripting = ds2;
            }
        }

        private void btn_home_Click(object sender, RoutedEventArgs e)
        {
            Development_performance.ComprehensiveIndex ComprehensiveI = new Development_performance.ComprehensiveIndex(controlmenu);
            controlmenu.menu1_1.IsSelected = false;
            controlmenu.menu1_2.IsSelected = false;
            controlmenu.menu1_3.IsSelected = false;
            controlmenu.menu1_4.IsSelected = false;
            this.NavigationService.Navigate(ComprehensiveI);
        }
    }
}
