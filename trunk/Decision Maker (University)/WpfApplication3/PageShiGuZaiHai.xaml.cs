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
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Data;
using WpfZhihui;

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for PageShiGuZaiHai.xaml
    /// </summary>
    public partial class PageShiGuZaiHai : Page
    {

        public PageShiGuZaiHai()
        {
            InitializeComponent();
            
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
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            tbx_ZiRanZaiHai_ShiJianShiShiGengXin.Text = "事件实时更新\r\n发生时间：2012年8月13日，13：56\r\n发生地点：同济大学体育馆工地西北\r\n事件情况：";
            tbx_ZiRanZaiHai_ShiJianQingKuang.Text = "（v1208131359）施工操作不当，引发施工现场起火，火势较大。\r\n（v1208131403）建筑中有工人被困，大约为6-9人。\r\n（v1208131411）第一辆救火车赶到现场，开始进行灭火操作，人员全部安全转移，初步确定无伤亡。\r\n（v1208131417）第二辆救火车和救护车赶到现场\r\n（v1208131422）。。。";
            DirectoryInfo di = new DirectoryInfo(System.Environment.CurrentDirectory);
            string pathEmergency = di.Parent.Parent.FullName;
            ds = new EmergencyBasic();
            webBrowser_ZiRanZaiHai.Navigate(new Uri(pathEmergency + @"/html/ZiRanZaiHai.htm", UriKind.RelativeOrAbsolute));//获取根目录的日历文件
            webBrowser_ZiRanZaiHai.ObjectForScripting = ds;//该对象可由显示在WebBrowser控件中的网页所包含的脚本代码访问
        }
		
        private void dengji1_Selected(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			lingdaoceng.IsChecked=true;
			yuanrenyuan.IsChecked=true;
			yuanjigou.IsChecked=true;
        }

        private void dengji2_Selected(object sender, System.Windows.RoutedEventArgs e)
        {
			lingdaoceng.IsChecked=true;
			yuanrenyuan.IsChecked=true;
			yuanjigou.IsChecked=true;
        }

        private void dengji3_Selected(object sender, System.Windows.RoutedEventArgs e)
        {
			lingdaoceng.IsChecked=false;
			yuanrenyuan.IsChecked=true;
			yuanjigou.IsChecked=true;
        }

        private void dengji4_Selected(object sender, System.Windows.RoutedEventArgs e)
        {
			lingdaoceng.IsChecked=false;
			yuanrenyuan.IsChecked=false;
			yuanjigou.IsChecked=true;
        }

        private void Gridzzss_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
			textBlockzzss.Text = "1、要迅速组织人员逃生，原则是“先救人，后救物”。\r\n2、参加人员：在消防车到来之前，在确保自身安全的情况下均有义务参加扑救。\r\n3、消防车到来之后，要配合消防专业人员扑救或做好辅助工作。\r\n4、使用器具：灭火器、水桶、消防水带等。";
        }

        private void Gridpjff_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            textBlockbjff.Text = "扑救方法内容";
        }

        private void Gridzysx_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            textBlockzysx.Text = "注意事项内容";
        }
    }
}
