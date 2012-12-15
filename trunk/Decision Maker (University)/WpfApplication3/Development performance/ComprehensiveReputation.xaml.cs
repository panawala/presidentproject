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

namespace WpfApplication3.Development_performance
{
    /// <summary>
    /// Interaction logic for ComprehensiveReputation.xaml
    /// </summary>
    public partial class ComprehensiveReputation : Page
    {
        public ComprehensiveReputation()
        {
            InitializeComponent();
        }

        protected void Page_Loaded(object sender, RoutedEventArgs e)
        {

            string strPATH;
            DirectoryInfo di;
            di = new DirectoryInfo(System.Environment.CurrentDirectory);
            strPATH = di.Parent.Parent.FullName;
            leftWebBrowser.Navigate(new Uri(strPATH + @"/html/left.htm", UriKind.RelativeOrAbsolute));
            midWebBrowser.Navigate(new Uri(strPATH + @"/html/mid.htm", UriKind.RelativeOrAbsolute));
            rightWebBrowser.Navigate(new Uri(strPATH + @"/html/right.htm", UriKind.RelativeOrAbsolute));
            mainWebBrowser.Navigate(new Uri(strPATH + @"/html/main.htm", UriKind.RelativeOrAbsolute));
            Q_xueshushengyu.Navigate(new Uri(strPATH + @"/html/quxian.htm", UriKind.RelativeOrAbsolute));
            D_xueshushengyu.Navigate(new Uri(strPATH + @"/html/redu.htm", UriKind.RelativeOrAbsolute));
            leftWebBrowser1.Navigate(new Uri(strPATH + @"/html/left.htm", UriKind.RelativeOrAbsolute));
            midWebBrowser1.Navigate(new Uri(strPATH + @"/html/mid.htm", UriKind.RelativeOrAbsolute));
            rightWebBrowser1.Navigate(new Uri(strPATH + @"/html/right.htm", UriKind.RelativeOrAbsolute));
            mainWebBrowser1.Navigate(new Uri(strPATH + @"/html/main.htm", UriKind.RelativeOrAbsolute));
            Q_shehuishengyu.Navigate(new Uri(strPATH + @"/html/quxian.htm", UriKind.RelativeOrAbsolute));
            D_shehuishengyu.Navigate(new Uri(strPATH + @"/html/redu.htm", UriKind.RelativeOrAbsolute));
            List<TeaInformation> TeaInfo = new List<TeaInformation>
            {
                new TeaInformation
                {
                    xingming = "李国豪",
                    zhiwu = "杰出科学家",
                    biyeshijian = "未知",
                    zhuanye = "桥梁",
                    lianxifangshi = "未知",
                },
                              
                new TeaInformation
                {
                    xingming = "裘法祖",
                    zhiwu = "杰出科学家",
                    biyeshijian = "未知",
                    zhuanye = "医学",
                    lianxifangshi = "未知",
                },                
                new TeaInformation
                {
                    xingming = "黄志镗",
                    zhiwu = "杰出科学家",
                    biyeshijian = "未知",
                    zhuanye = "土木",
                    lianxifangshi = "未知",
                },
                new TeaInformation
                {
                    xingming = "郭重庆",
                    zhiwu = "杰出政治家",
                    biyeshijian = "未知",
                    zhuanye = "诗人",
                    lianxifangshi = "未知",
                },   
                new TeaInformation
                {
                    xingming = "程京",
                    zhiwu = "杰出政治家",
                    biyeshijian = "未知",
                    zhuanye = "医学",
                    lianxifangshi = "未知",
                },   
                new TeaInformation
                {
                    xingming = "李德仁",
                    zhiwu = "杰出政治家",
                    biyeshijian = "未知",
                    zhuanye = "水利",
                    lianxifangshi = "未知",
                }, 
                 new TeaInformation
                {
                    xingming = "普罗迪",
                    zhiwu = "杰出企业家",
                    biyeshijian = "未知",
                    zhuanye = "文学",
                    lianxifangshi = "未知",
                },   
                 new TeaInformation
                {
                    xingming = "安娜贝蒂琼卡",
                    zhiwu = "杰出企业家",
                    biyeshijian = "未知",
                    zhuanye = "未知",
                    lianxifangshi = "未知",
                },   
                 new TeaInformation
                {
                    xingming = "冯佛戈",
                    zhiwu = "杰出企业家",
                    biyeshijian = "未知",
                    zhuanye = "文学",
                    lianxifangshi = "未知",
                },   
                 new TeaInformation
                {
                    xingming = "柔石",
                    zhiwu = "其他杰出校友",
                    biyeshijian = "未知",
                    zhuanye = "文学",
                    lianxifangshi = "未知",
                },   
                 new TeaInformation
                {
                    xingming = "元丰少",
                    zhiwu = "其他杰出校友",
                    biyeshijian = "未知",
                    zhuanye = "建筑",
                    lianxifangshi = "未知",
                },   
                 new TeaInformation
                {
                    xingming = "张晨曦",
                    zhiwu = "其他杰出校友",
                    biyeshijian = "未知",
                    zhuanye = "计算机",
                    lianxifangshi = "未知",
                },   
                 new TeaInformation
                {
                    xingming = "王祖涵",
                    zhiwu = "其他杰出校友",
                    biyeshijian = "未知",
                    zhuanye = "生物",
                    lianxifangshi = "未知",
                }
            };
            List<SubInformation> SubInfo = new List<SubInformation>
             {
                 new SubInformation
                 {
                     zhuanyemingcheng = "桥梁工程",
                     xuekedengji = "企业捐赠",
                     xueyuan = "土木",
                     qita = "桥梁抗震",
                     qita1 = "大跨度桥梁"

                 },

                 new SubInformation
                 {
                     zhuanyemingcheng = "海洋地质",
                     xuekedengji = "企业捐赠",
                     xueyuan = "海洋",
                     qita = "古代环境变迁",
                     qita1 = "构造运动与气候变迁"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "建筑学",
                     xuekedengji = "企业捐赠",
                     xueyuan = "建筑",
                     qita = "城市发展战略",
                     qita1 = "城市建筑"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "环境工程",
                     xuekedengji = "基金捐赠",
                     xueyuan = "环境",
                     qita = "水污染控制理论",
                     qita1 = "固体废物处理"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "材料学",
                     xuekedengji = "基金捐赠",
                     xueyuan = "材料",
                     qita = "先进水泥",
                     qita1 = "纳米多孔材料"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "混凝土结构",
                     xuekedengji = "基金捐赠",
                     xueyuan = "建筑",
                     qita = "新型混凝土",
                     qita1 = "新型混凝土"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "岩土工程",
                     xuekedengji = "海外捐赠",
                     xueyuan = "土木",
                     qita = "土动力学",
                     qita1 = "隧道地下工程"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "机械设计与理论",
                     xuekedengji = "海外捐赠",
                     xueyuan = "机械",
                     qita = "机械设计原理",
                     qita1 = "车辆工程"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "汽车设计与制造",
                     xuekedengji = "海外捐赠",
                     xueyuan = "汽车",
                     qita = "汽车节能",
                     qita1 = "汽车系统动力学"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "胸心外科",
                     xuekedengji = "个人捐赠",
                     xueyuan = "医学院",
                     qita = "心肌保护",
                     qita1 = "复杂先心治疗"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "道路工程",
                     xuekedengji = "个人捐赠",
                     xueyuan = "轨道交通",
                     qita = "道路路面工程",
                     qita1 = "驻极体材料的制备与研究"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "固体力学",
                     xuekedengji = "个人捐赠",
                     xueyuan = "土木",
                     qita = "重大力学问题研究",
                     qita1 = "新材料工程"

                 }
             };

            L_jiechuxiaoyou.DataContext = TeaInfo;
            L_jiechuxiaoyou.SelectedIndex = 0;

            L_shehuijuanzeng.DataContext = SubInfo;
            L_shehuijuanzeng.SelectedIndex = 0;

         

        }

        private void xueshushengyu_Click(object sender, RoutedEventArgs e)
        {
            G_xueshushengyu.Visibility = System.Windows.Visibility.Visible;
            G_shehuishengyu.Visibility = System.Windows.Visibility.Collapsed;
            G_jiechuxiaoyou.Visibility = System.Windows.Visibility.Collapsed;
            G_shehuijuanzeng.Visibility = System.Windows.Visibility.Collapsed;
            G_R_xueshushengyu.Visibility = System.Windows.Visibility.Visible;
            G_R_shehuishengyu.Visibility = System.Windows.Visibility.Collapsed;
            G_R_jiechuxiaoyou.Visibility = System.Windows.Visibility.Collapsed;
            G_R_shehuijuanzeng.Visibility = System.Windows.Visibility.Collapsed;

        }

        private void shehuishengyu_Click(object sender, RoutedEventArgs e)
        {
            G_xueshushengyu.Visibility = System.Windows.Visibility.Collapsed;
            G_shehuishengyu.Visibility = System.Windows.Visibility.Visible;
            G_jiechuxiaoyou.Visibility = System.Windows.Visibility.Collapsed;
            G_shehuijuanzeng.Visibility = System.Windows.Visibility.Collapsed;
            G_R_xueshushengyu.Visibility = System.Windows.Visibility.Collapsed;
            G_R_shehuishengyu.Visibility = System.Windows.Visibility.Visible;
            G_R_jiechuxiaoyou.Visibility = System.Windows.Visibility.Collapsed;
            G_R_shehuijuanzeng.Visibility = System.Windows.Visibility.Collapsed;

        }

        private void jiechuxiaoyou_Click(object sender, RoutedEventArgs e)
        {
            G_xueshushengyu.Visibility = System.Windows.Visibility.Collapsed;
            G_shehuishengyu.Visibility = System.Windows.Visibility.Collapsed;
            G_jiechuxiaoyou.Visibility = System.Windows.Visibility.Visible;
            G_shehuijuanzeng.Visibility = System.Windows.Visibility.Collapsed;
            G_R_xueshushengyu.Visibility = System.Windows.Visibility.Collapsed;
            G_R_shehuishengyu.Visibility = System.Windows.Visibility.Collapsed;
            G_R_jiechuxiaoyou.Visibility = System.Windows.Visibility.Visible;
            G_R_shehuijuanzeng.Visibility = System.Windows.Visibility.Collapsed;

        }
        private void shehuijuanzeng_Click(object sender, RoutedEventArgs e)
        {
            G_xueshushengyu.Visibility = System.Windows.Visibility.Collapsed;
            G_shehuishengyu.Visibility = System.Windows.Visibility.Collapsed;
            G_jiechuxiaoyou.Visibility = System.Windows.Visibility.Collapsed;
            G_shehuijuanzeng.Visibility = System.Windows.Visibility.Visible;
            G_R_xueshushengyu.Visibility = System.Windows.Visibility.Collapsed;
            G_R_shehuishengyu.Visibility = System.Windows.Visibility.Collapsed;
            G_R_jiechuxiaoyou.Visibility = System.Windows.Visibility.Collapsed;
            G_R_shehuijuanzeng.Visibility = System.Windows.Visibility.Visible;

        }

    
        protected void S_jiechuxiaoyou_Click(object sender, RoutedEventArgs e)
        {
            List<TeaInformation> TeaInfo1 = new List<TeaInformation>
            {
               new TeaInformation
                {
                    xingming = "李国豪",
                    zhiwu = "杰出科学家",
                    biyeshijian = "未知",
                    zhuanye = "桥梁",
                    lianxifangshi = "未知",
                },
                              
                new TeaInformation
                {
                    xingming = "裘法祖",
                    zhiwu = "杰出科学家",
                    biyeshijian = "未知",
                    zhuanye = "医学",
                    lianxifangshi = "未知",
                },                
                new TeaInformation
                {
                    xingming = "黄志镗",
                    zhiwu = "杰出科学家",
                    biyeshijian = "未知",
                    zhuanye = "土木",
                    lianxifangshi = "未知",
                },
                new TeaInformation
                {
                    xingming = "郭重庆",
                    zhiwu = "杰出政治家",
                    biyeshijian = "未知",
                    zhuanye = "诗人",
                    lianxifangshi = "未知",
                },   
                new TeaInformation
                {
                    xingming = "程京",
                    zhiwu = "杰出政治家",
                    biyeshijian = "未知",
                    zhuanye = "医学",
                    lianxifangshi = "未知",
                },   
                new TeaInformation
                {
                    xingming = "李德仁",
                    zhiwu = "杰出政治家",
                    biyeshijian = "未知",
                    zhuanye = "水利",
                    lianxifangshi = "未知",
                }, 
                 new TeaInformation
                {
                    xingming = "普罗迪",
                    zhiwu = "杰出企业家",
                    biyeshijian = "未知",
                    zhuanye = "文学",
                    lianxifangshi = "未知",
                },   
                 new TeaInformation
                {
                    xingming = "安娜贝蒂琼卡",
                    zhiwu = "杰出企业家",
                    biyeshijian = "未知",
                    zhuanye = "未知",
                    lianxifangshi = "未知",
                },   
                 new TeaInformation
                {
                    xingming = "冯佛戈",
                    zhiwu = "杰出企业家",
                    biyeshijian = "未知",
                    zhuanye = "文学",
                    lianxifangshi = "未知",
                },   
                 new TeaInformation
                {
                    xingming = "柔石",
                    zhiwu = "其他杰出校友",
                    biyeshijian = "未知",
                    zhuanye = "文学",
                    lianxifangshi = "未知",
                },   
                 new TeaInformation
                {
                    xingming = "元丰少",
                    zhiwu = "其他杰出校友",
                    biyeshijian = "未知",
                    zhuanye = "建筑",
                    lianxifangshi = "未知",
                },   
                 new TeaInformation
                {
                    xingming = "张晨曦",
                    zhiwu = "其他杰出校友",
                    biyeshijian = "未知",
                    zhuanye = "计算机",
                    lianxifangshi = "未知",
                },   
                 new TeaInformation
                {
                    xingming = "王祖涵",
                    zhiwu = "其他杰出校友",
                    biyeshijian = "未知",
                    zhuanye = "生物",
                    lianxifangshi = "未知",
                }
           
            };

            L_jiechuxiaoyou.DataContext = TeaInfo1.Where(s => (gaoxiaoxueke.IsChecked.Equals(true) && s.zhiwu == "杰出政治家") || (yijizhongdian.IsChecked.Equals(true) && s.zhiwu == "杰出科学家") || (erjizhongdian.IsChecked.Equals(true) && s.zhiwu == "杰出企业家") || (zhongdianpeiyu.IsChecked.Equals(true) && s.zhiwu == "其他杰出校友") );
            L_jiechuxiaoyou.SelectedIndex = 0;
        }
        private void S_shehuijuanzeng_Click(object sender, RoutedEventArgs e)
        {

            List<SubInformation> SubInfo2 = new List<SubInformation>
             {
                 new SubInformation
                 {
                     zhuanyemingcheng = "桥梁工程",
                     xuekedengji = "企业捐赠",
                     xueyuan = "土木",
                     qita = "桥梁抗震",
                     qita1 = "大跨度桥梁"

                 },

                 new SubInformation
                 {
                     zhuanyemingcheng = "海洋地质",
                     xuekedengji = "企业捐赠",
                     xueyuan = "海洋",
                     qita = "古代环境变迁",
                     qita1 = "构造运动与气候变迁"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "建筑学",
                     xuekedengji = "企业捐赠",
                     xueyuan = "建筑",
                     qita = "城市发展战略",
                     qita1 = "城市建筑"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "环境工程",
                     xuekedengji = "基金捐赠",
                     xueyuan = "环境",
                     qita = "水污染控制理论",
                     qita1 = "固体废物处理"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "材料学",
                     xuekedengji = "基金捐赠",
                     xueyuan = "材料",
                     qita = "先进水泥",
                     qita1 = "纳米多孔材料"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "混凝土结构",
                     xuekedengji = "基金捐赠",
                     xueyuan = "建筑",
                     qita = "新型混凝土",
                     qita1 = "新型混凝土"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "岩土工程",
                     xuekedengji = "海外捐赠",
                     xueyuan = "土木",
                     qita = "土动力学",
                     qita1 = "隧道地下工程"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "机械设计与理论",
                     xuekedengji = "海外捐赠",
                     xueyuan = "机械",
                     qita = "机械设计原理",
                     qita1 = "车辆工程"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "汽车设计与制造",
                     xuekedengji = "海外捐赠",
                     xueyuan = "汽车",
                     qita = "汽车节能",
                     qita1 = "汽车系统动力学"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "胸心外科",
                     xuekedengji = "个人捐赠",
                     xueyuan = "医学院",
                     qita = "心肌保护",
                     qita1 = "复杂先心治疗"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "道路工程",
                     xuekedengji = "个人捐赠",
                     xueyuan = "轨道交通",
                     qita = "道路路面工程",
                     qita1 = "驻极体材料的制备与研究"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "固体力学",
                     xuekedengji = "个人捐赠",
                     xueyuan = "土木",
                     qita = "重大力学问题研究",
                     qita1 = "新材料工程"

                 }
             };
            L_shehuijuanzeng.DataContext = SubInfo2.Where(s => (zhongkeyuan.IsChecked.Equals(true) && s.xuekedengji == "企业捐赠") || (zhonggongyuan.IsChecked.Equals(true) && s.xuekedengji == "基金捐赠") || (guowaiyuan.IsChecked.Equals(true) && s.xuekedengji == "海外捐赠") || (renwenshehui.IsChecked.Equals(true) && s.xuekedengji == "个人捐赠"));
            L_shehuijuanzeng.SelectedIndex = 0;
        }
        private void S_xueshushengyu_Click(object sender, RoutedEventArgs e)
        {
 
        }
        private void S_shehuishengyu_Click(object sender, RoutedEventArgs e)
        {

        }
        public class TeaInformation
        {
            public string xingming { get; set; }
            public string zhiwu { get; set; }
            public string biyeshijian { get; set; }
            public string zhuanye { get; set; }
            public string lianxifangshi { get; set; }
        }
        public class SubInformation
        {
            public string zhuanyemingcheng { get; set; }
            public string xuekedengji { get; set; }
            public string xueyuan { get; set; }
            public string qita { get; set; }
            public string qita1 { get; set; }
        }

    }
}
