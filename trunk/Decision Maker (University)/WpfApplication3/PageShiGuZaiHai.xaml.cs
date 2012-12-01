﻿using System;
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
        void yingjiyuan_tag1()
        {
            tag1.Visibility = System.Windows.Visibility.Visible;
            tag2.Visibility = System.Windows.Visibility.Collapsed;
            tag3.Visibility = System.Windows.Visibility.Collapsed;
            tag4.Visibility = System.Windows.Visibility.Collapsed;
            Content_yingjiyuan.Visibility = System.Windows.Visibility.Visible;
            Content_shiguzaihai.Visibility = System.Windows.Visibility.Collapsed;
            Content_lishijilu.Visibility = System.Windows.Visibility.Collapsed;
            Content_zhongdaweixianyuan.Visibility = System.Windows.Visibility.Collapsed;
            Content_anlilianjie.Visibility = System.Windows.Visibility.Collapsed;
        }
        void shiguzaihai_tag1()
        {
            tag1.Visibility = System.Windows.Visibility.Visible;
            tag2.Visibility = System.Windows.Visibility.Collapsed;
            tag3.Visibility = System.Windows.Visibility.Collapsed;
            tag4.Visibility = System.Windows.Visibility.Collapsed;
            Content_shiguzaihai.Visibility = System.Windows.Visibility.Visible;
            Content_yingjiyuan.Visibility = System.Windows.Visibility.Collapsed;
            Content_lishijilu.Visibility = System.Windows.Visibility.Collapsed;
            Content_zhongdaweixianyuan.Visibility = System.Windows.Visibility.Collapsed;
            Content_anlilianjie.Visibility = System.Windows.Visibility.Collapsed;
        }
        private void yingjiyuan_tag1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            yingjiyuan_tag1();
        }

        private void lishijilu_tag2_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            tag2.Visibility = System.Windows.Visibility.Visible;
            tag1.Visibility = System.Windows.Visibility.Collapsed;
            tag3.Visibility = System.Windows.Visibility.Collapsed;
            tag4.Visibility = System.Windows.Visibility.Collapsed;
            Content_yingjiyuan.Visibility = System.Windows.Visibility.Collapsed;
            Content_lishijilu.Visibility = System.Windows.Visibility.Visible;
            Content_zhongdaweixianyuan.Visibility = System.Windows.Visibility.Collapsed;
            Content_anlilianjie.Visibility = System.Windows.Visibility.Collapsed;
            Content_shiguzaihai.Visibility = System.Windows.Visibility.Collapsed;

        }
        private void zhongdaweixian_tag3_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            tag3.Visibility = System.Windows.Visibility.Visible;
            tag2.Visibility = System.Windows.Visibility.Collapsed;
            tag1.Visibility = System.Windows.Visibility.Collapsed;
            tag4.Visibility = System.Windows.Visibility.Collapsed;
            Content_yingjiyuan.Visibility = System.Windows.Visibility.Collapsed;
            Content_lishijilu.Visibility = System.Windows.Visibility.Collapsed;
            Content_zhongdaweixianyuan.Visibility = System.Windows.Visibility.Visible;
            Content_anlilianjie.Visibility = System.Windows.Visibility.Collapsed;
            Content_shiguzaihai.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void anlilianjie_tag4_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            tag4.Visibility = System.Windows.Visibility.Visible;
            tag2.Visibility = System.Windows.Visibility.Collapsed;
            tag3.Visibility = System.Windows.Visibility.Collapsed;
            tag1.Visibility = System.Windows.Visibility.Collapsed;
            Content_yingjiyuan.Visibility = System.Windows.Visibility.Collapsed;
            Content_lishijilu.Visibility = System.Windows.Visibility.Collapsed;
            Content_zhongdaweixianyuan.Visibility = System.Windows.Visibility.Collapsed;
            Content_anlilianjie.Visibility = System.Windows.Visibility.Visible;
            Content_shiguzaihai.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void Huojing_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            Select_green.Margin = new Thickness(0, 55, 0, 0);
        }

        private void Minjing_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            Select_green.Margin = new Thickness(0, 0, 0, 0);
        }

        private void Yiyuan_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            Select_green.Margin = new Thickness(0, 110, 0, 0);
        }

        private void Wuran_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            Select_green.Margin = new Thickness(0, 165, 0, 0);
        }

        private void btn_yibanshiwuzhongdu_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            img_yibanshiwuzhongdu.Visibility = System.Windows.Visibility.Visible;
            img_yanzhongshiwuzhongdu.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void btn_yanzhongshiwuzhongdu_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            img_yibanshiwuzhongdu.Visibility = System.Windows.Visibility.Collapsed;
            img_yanzhongshiwuzhongdu.Visibility = System.Windows.Visibility.Visible;
        }
        void lingdaoceng_unclick()
        {
            lingdaoceng_green.Visibility = System.Windows.Visibility.Collapsed;
            lingdaoceng_branch_green.Visibility = System.Windows.Visibility.Collapsed;
            tongzhilingdao.Foreground = (Brush)Page.Resources["white"];
        }
        void lingdaoceng_click()
        {
            lingdaoceng_green.Visibility = System.Windows.Visibility.Visible;
            lingdaoceng_branch_green.Visibility = System.Windows.Visibility.Visible;
            tongzhilingdao.Foreground = (Brush)Page.Resources["black"];
        }

        void lingdaoceng()
        {
            if (lingdaoceng_green.Visibility == System.Windows.Visibility.Visible)
            {
                lingdaoceng_unclick();
            }
            else
            {
                lingdaoceng_click();
            }
        }
        void yuanrenyuan_unclick()
        {
            lingdaoceng_green1.Visibility = System.Windows.Visibility.Collapsed;
            lingdaoceng_branch_green1.Visibility = System.Windows.Visibility.Collapsed;
            tongzhilingdao1.Foreground = (Brush)Page.Resources["white"];
        }
        void yuanrenyuan_click()
        {
            lingdaoceng_green1.Visibility = System.Windows.Visibility.Visible;
            lingdaoceng_branch_green1.Visibility = System.Windows.Visibility.Visible;
            tongzhilingdao1.Foreground = (Brush)Page.Resources["black"];
        }

        void yuanrenyuan()
        {
            if (lingdaoceng_green1.Visibility == System.Windows.Visibility.Visible)
            {
                yuanrenyuan_unclick();
            }
            else
            {
                yuanrenyuan_click();
            }
        }
        void yuanjigou_unclick()
        {
            lingdaoceng_green2.Visibility = System.Windows.Visibility.Collapsed;
            lingdaoceng_branch_green2.Visibility = System.Windows.Visibility.Collapsed;
            tongzhilingdao2.Foreground = (Brush)Page.Resources["white"];
        }
        void yuanjigou_click()
        {
            lingdaoceng_green2.Visibility = System.Windows.Visibility.Visible;
            lingdaoceng_branch_green2.Visibility = System.Windows.Visibility.Visible;
            tongzhilingdao2.Foreground = (Brush)Page.Resources["black"];
        }

        void yuanjigou()
        {
            if (lingdaoceng_green2.Visibility == System.Windows.Visibility.Visible)
            {
                yuanjigou_unclick();
            }
            else
            {
                yuanjigou_click();
            }
        }

        private void btn_lingdaoceng_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            lingdaoceng();
        }

        private void btn_yuanrenyuan_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            yuanrenyuan();
        }

        private void btn_yuanjigou_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            yuanjigou();
        }
        private void btn_dengji1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            ImgGreen_dengji1.Visibility = System.Windows.Visibility.Visible;
            ImgGreen_dengji2.Visibility = System.Windows.Visibility.Collapsed;
            ImgGreen_dengji3.Visibility = System.Windows.Visibility.Collapsed;
            ImgGreen_dengji4.Visibility = System.Windows.Visibility.Collapsed;
            lingdaoceng_click();
            yuanrenyuan_click();
            yuanjigou_click();

        }
        private void btn_dengji2_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            ImgGreen_dengji1.Visibility = System.Windows.Visibility.Collapsed;
            ImgGreen_dengji3.Visibility = System.Windows.Visibility.Collapsed;
            ImgGreen_dengji2.Visibility = System.Windows.Visibility.Visible;
            ImgGreen_dengji4.Visibility = System.Windows.Visibility.Collapsed;
            lingdaoceng_click();
            yuanrenyuan_click();
            yuanjigou_click();
        }
        private void btn_dengji3_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            ImgGreen_dengji1.Visibility = System.Windows.Visibility.Collapsed;
            ImgGreen_dengji2.Visibility = System.Windows.Visibility.Collapsed;
            ImgGreen_dengji3.Visibility = System.Windows.Visibility.Visible;
            ImgGreen_dengji4.Visibility = System.Windows.Visibility.Collapsed;
            lingdaoceng_unclick();
            yuanrenyuan_click();
            yuanjigou_click();
        }
        private void btn_dengji4_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            ImgGreen_dengji1.Visibility = System.Windows.Visibility.Collapsed;
            ImgGreen_dengji2.Visibility = System.Windows.Visibility.Collapsed;
            ImgGreen_dengji4.Visibility = System.Windows.Visibility.Visible;
            ImgGreen_dengji3.Visibility = System.Windows.Visibility.Collapsed;
            lingdaoceng_unclick();
            yuanrenyuan_unclick();
            yuanjigou_click();
        }
        private void btn_ggws_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            yingjiyuan_tag1();
        }

        private void btn_sgzh_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            shiguzaihai_tag1();

        }

        private void btn_zzss_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            img_huozaiyuan1.Visibility = System.Windows.Visibility.Visible;
            img_huozaiyuan2.Visibility = System.Windows.Visibility.Collapsed;
            img_huozaiyuan3.Visibility = System.Windows.Visibility.Collapsed;

        }

        private void btn_pjbf_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            img_huozaiyuan2.Visibility = System.Windows.Visibility.Visible;
            img_huozaiyuan1.Visibility = System.Windows.Visibility.Collapsed;
            img_huozaiyuan3.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void btn_zysx_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            img_huozaiyuan3.Visibility = System.Windows.Visibility.Visible;
            img_huozaiyuan2.Visibility = System.Windows.Visibility.Collapsed;
            img_huozaiyuan1.Visibility = System.Windows.Visibility.Collapsed;
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
            textBlock_TuFaShiJian_DiTuXinXi.Text = "可调用资源。。。。。。\r\n周边设施。。。。。。";
            radioButton_ZiRanZaiHai_QuanBu.IsChecked = false;
            radioButton_ZiRanZaiHai_HuoJin.IsChecked = true;
            radioButton_ZiRanZaiHai_JiuHu.IsChecked = true;
            radioButton_ZiRanZaiHai_MinJing.IsChecked = false;
            radioButton_ZiRanZaiHai_YiYuan.IsChecked = false;
            btn_ZiRanZaiHai_ZuZhiShiShi_Click(sender, e);
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