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

namespace WpfApplication3.Development_performance
{
    /// <summary>
    /// Interaction logic for TalentCultivation.xaml
    /// </summary>
    public partial class TalentCultivation : Page
    {
       
        public TalentCultivation()
        {
            InitializeComponent();
        }

        protected void Page_Loaded(object sender, RoutedEventArgs e)
        {
             List<TeaInformation> TeaInfo = new List<TeaInformation>
            {
                new TeaInformation
                {
                    xingming = "李国豪",
                    zhiwu = "中国科学院院士",
                    biyeshijian = "未知",
                    zhuanye = "桥梁",
                    lianxifangshi = "未知",
                },
                              
                new TeaInformation
                {
                    xingming = "裘法祖",
                    zhiwu = "中国科学院院士",
                    biyeshijian = "未知",
                    zhuanye = "医学",
                    lianxifangshi = "未知",
                },                
                new TeaInformation
                {
                    xingming = "黄志镗",
                    zhiwu = "中国科学院院士",
                    biyeshijian = "未知",
                    zhuanye = "土木",
                    lianxifangshi = "未知",
                },
                new TeaInformation
                {
                    xingming = "郭重庆",
                    zhiwu = "中国工程院院士",
                    biyeshijian = "未知",
                    zhuanye = "诗人",
                    lianxifangshi = "未知",
                },   
                new TeaInformation
                {
                    xingming = "程京",
                    zhiwu = "中国工程院院士",
                    biyeshijian = "未知",
                    zhuanye = "医学",
                    lianxifangshi = "未知",
                },   
                new TeaInformation
                {
                    xingming = "李德仁",
                    zhiwu = "工程院院士",
                    biyeshijian = "未知",
                    zhuanye = "水利",
                    lianxifangshi = "未知",
                }, 
                 new TeaInformation
                {
                    xingming = "普罗迪",
                    zhiwu = "国外院士",
                    biyeshijian = "未知",
                    zhuanye = "文学",
                    lianxifangshi = "未知",
                },   
                 new TeaInformation
                {
                    xingming = "安娜贝蒂琼卡",
                    zhiwu = "国外院士",
                    biyeshijian = "未知",
                    zhuanye = "未知",
                    lianxifangshi = "未知",
                },   
                 new TeaInformation
                {
                    xingming = "冯佛戈",
                    zhiwu = "杰出人文社会科学家",
                    biyeshijian = "未知",
                    zhuanye = "文学",
                    lianxifangshi = "未知",
                },   
                 new TeaInformation
                {
                    xingming = "柔石",
                    zhiwu = "杰出人文社会科学家",
                    biyeshijian = "未知",
                    zhuanye = "文学",
                    lianxifangshi = "未知",
                },   
                 new TeaInformation
                {
                    xingming = "元丰少",
                    zhiwu = "国家级教学名师",
                    biyeshijian = "未知",
                    zhuanye = "建筑",
                    lianxifangshi = "未知",
                },   
                 new TeaInformation
                {
                    xingming = "张晨曦",
                    zhiwu = "国家级教学名师",
                    biyeshijian = "未知",
                    zhuanye = "计算机",
                    lianxifangshi = "未知",
                },   
                 new TeaInformation
                {
                    xingming = "王祖涵",
                    zhiwu = "千人计划入选者",
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
                     xuekedengji = "高校学科创新引智基地（111计划）",
                     xueyuan = "土木",
                     qita = "桥梁抗震",
                     qita1 = "大跨度桥梁"

                 },

                 new SubInformation
                 {
                     zhuanyemingcheng = "海洋地质",
                     xuekedengji = "高校学科创新引智基地（111计划）",
                     xueyuan = "海洋",
                     qita = "古代环境变迁",
                     qita1 = "构造运动与气候变迁"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "建筑学",
                     xuekedengji = "国家一级重点学科",
                     xueyuan = "建筑",
                     qita = "城市发展战略",
                     qita1 = "城市建筑"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "环境工程",
                     xuekedengji = "国家一级重点学科",
                     xueyuan = "环境",
                     qita = "水污染控制理论",
                     qita1 = "固体废物处理"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "材料学",
                     xuekedengji = "国家二级重点学科",
                     xueyuan = "材料",
                     qita = "先进水泥",
                     qita1 = "纳米多孔材料"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "混凝土结构",
                     xuekedengji = "国家二级重点学科",
                     xueyuan = "建筑",
                     qita = "新型混凝土",
                     qita1 = "新型混凝土"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "岩土工程",
                     xuekedengji = "国家重点培育学科",
                     xueyuan = "土木",
                     qita = "土动力学",
                     qita1 = "隧道地下工程"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "机械设计与理论",
                     xuekedengji = "国家重点培育学科",
                     xueyuan = "机械",
                     qita = "机械设计原理",
                     qita1 = "车辆工程"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "汽车设计与制造",
                     xuekedengji = "国家一级重点学科",
                     xueyuan = "汽车",
                     qita = "汽车节能",
                     qita1 = "汽车系统动力学"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "胸心外科",
                     xuekedengji = "国家一级重点学科",
                     xueyuan = "医学院",
                     qita = "心肌保护",
                     qita1 = "复杂先心治疗"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "道路工程",
                     xuekedengji = "博士后流动站",
                     xueyuan = "轨道交通",
                     qita = "道路路面工程",
                     qita1 = "驻极体材料的制备与研究"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "固体力学",
                     xuekedengji = "博士后流动站",
                     xueyuan = "土木",
                     qita = "重大力学问题研究",
                     qita1 = "新材料工程"

                 }
             };

             L_shizishuiping.DataContext = TeaInfo;
             L_shizishuiping.SelectedIndex = 0;

             L_jiaoyujiaoxue.DataContext = SubInfo;
             L_jiaoyujiaoxue.SelectedIndex = 0;

             L_xuekeshuiping.DataContext = SubInfo;
             L_xuekeshuiping.SelectedIndex = 0;

        }

        private void jiaoyujiaoxue_Click(object sender, RoutedEventArgs e)
        {
            jiaoyujiaoxue.Visibility = System.Windows.Visibility.Visible;
            shizishuiping.Visibility = System.Windows.Visibility.Collapsed;
            xuekeshuiping.Visibility = System.Windows.Visibility.Collapsed;
            L_jiaoyujiaoxue.Visibility = System.Windows.Visibility.Visible;
            L_shizishuiping.Visibility = System.Windows.Visibility.Collapsed;
            L_xuekeshuiping.Visibility = System.Windows.Visibility.Collapsed;
            G_jiaoyujiaoxue.Visibility = System.Windows.Visibility.Visible;
            G_shizishuiping.Visibility = System.Windows.Visibility.Collapsed;
            G_xuekeshuiping.Visibility = System.Windows.Visibility.Collapsed;

        }

        private void shizishuiping_Click(object sender, RoutedEventArgs e)
        {
            jiaoyujiaoxue.Visibility = System.Windows.Visibility.Collapsed;
            shizishuiping.Visibility = System.Windows.Visibility.Visible;
            xuekeshuiping.Visibility = System.Windows.Visibility.Collapsed;
            L_jiaoyujiaoxue.Visibility = System.Windows.Visibility.Collapsed;
            L_shizishuiping.Visibility = System.Windows.Visibility.Visible;
            L_xuekeshuiping.Visibility = System.Windows.Visibility.Collapsed;
            G_jiaoyujiaoxue.Visibility = System.Windows.Visibility.Collapsed;
            G_shizishuiping.Visibility = System.Windows.Visibility.Visible;
            G_xuekeshuiping.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void xuekeshuiping_Click(object sender, RoutedEventArgs e)
        {
            jiaoyujiaoxue.Visibility = System.Windows.Visibility.Collapsed;
            shizishuiping.Visibility = System.Windows.Visibility.Collapsed;
            xuekeshuiping.Visibility = System.Windows.Visibility.Visible;
            L_jiaoyujiaoxue.Visibility = System.Windows.Visibility.Collapsed;
            L_shizishuiping.Visibility = System.Windows.Visibility.Collapsed;
            L_xuekeshuiping.Visibility = System.Windows.Visibility.Visible;
            G_jiaoyujiaoxue.Visibility = System.Windows.Visibility.Collapsed;
            G_shizishuiping.Visibility = System.Windows.Visibility.Collapsed;
            G_xuekeshuiping.Visibility = System.Windows.Visibility.Visible;
        }

        protected void S_jiaoyujiaoxue_Click(object sender, RoutedEventArgs e)
        {
            List<SubInformation> SubInfo1 = new List<SubInformation>
             {
                 new SubInformation
                 {
                     zhuanyemingcheng = "桥梁工程",
                     xuekedengji = "高校学科创新引智基地（111计划）",
                     xueyuan = "土木",
                     qita = "桥梁抗震",
                     qita1 = "大跨度桥梁"

                 },

                 new SubInformation
                 {
                     zhuanyemingcheng = "海洋地质",
                     xuekedengji = "高校学科创新引智基地（111计划）",
                     xueyuan = "海洋",
                     qita = "古代环境变迁",
                     qita1 = "构造运动与气候变迁"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "建筑学",
                     xuekedengji = "国家一级重点学科",
                     xueyuan = "建筑",
                     qita = "城市发展战略",
                     qita1 = "城市建筑"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "环境工程",
                     xuekedengji = "国家一级重点学科",
                     xueyuan = "环境",
                     qita = "水污染控制理论",
                     qita1 = "固体废物处理"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "材料学",
                     xuekedengji = "国家二级重点学科",
                     xueyuan = "材料",
                     qita = "先进水泥",
                     qita1 = "纳米多孔材料"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "混凝土结构",
                     xuekedengji = "国家二级重点学科",
                     xueyuan = "建筑",
                     qita = "新型混凝土",
                     qita1 = "新型混凝土"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "岩土工程",
                     xuekedengji = "国家重点培育学科",
                     xueyuan = "土木",
                     qita = "土动力学",
                     qita1 = "隧道地下工程"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "机械设计与理论",
                     xuekedengji = "国家重点培育学科",
                     xueyuan = "机械",
                     qita = "机械设计原理",
                     qita1 = "车辆工程"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "汽车设计与制造",
                     xuekedengji = "国家一级重点学科",
                     xueyuan = "汽车",
                     qita = "汽车节能",
                     qita1 = "汽车系统动力学"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "胸心外科",
                     xuekedengji = "国家一级重点学科",
                     xueyuan = "医学院",
                     qita = "心肌保护",
                     qita1 = "复杂先心治疗"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "道路工程",
                     xuekedengji = "博士后流动站",
                     xueyuan = "轨道交通",
                     qita = "道路路面工程",
                     qita1 = "驻极体材料的制备与研究"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "固体力学",
                     xuekedengji = "博士后流动站",
                     xueyuan = "土木",
                     qita = "重大力学问题研究",
                     qita1 = "新材料工程"

                 }
             };
            L_jiaoyujiaoxue.DataContext = SubInfo1.Where(s => (gaoxiaoxueke1.IsChecked.Equals(true) && s.xuekedengji == "高校学科创新引智基地（111计划）") || (yijizhongdian1.IsChecked.Equals(true) && s.xuekedengji == "国家一级重点学科") || (erjizhongdian1.IsChecked.Equals(true) && s.xuekedengji == "国家二级重点学科") || (zhongdianpeiyu1.IsChecked.Equals(true) && s.xuekedengji == "国家重点培育学科") || (liudongzhan1.IsChecked.Equals(true) && s.xuekedengji == "博士后流动站"));
            L_jiaoyujiaoxue.SelectedIndex = 0;

          
        }
        protected void S_shizishuiping_Click(object sender, RoutedEventArgs e)
        {
            List<TeaInformation> TeaInfo1 = new List<TeaInformation>
            {
                new TeaInformation
                {
                    xingming = "李国豪",
                    zhiwu = "中国科学院院士",
                    biyeshijian = "未知",
                    zhuanye = "桥梁",
                    lianxifangshi = "未知",
                },
                              
                new TeaInformation
                {
                    xingming = "裘法祖",
                    zhiwu = "中国科学院院士",
                    biyeshijian = "未知",
                    zhuanye = "医学",
                    lianxifangshi = "未知",
                },                
                new TeaInformation
                {
                    xingming = "黄志镗",
                    zhiwu = "中国科学院院士",
                    biyeshijian = "未知",
                    zhuanye = "土木",
                    lianxifangshi = "未知",
                },
                new TeaInformation
                {
                    xingming = "郭重庆",
                    zhiwu = "中国工程院院士",
                    biyeshijian = "未知",
                    zhuanye = "诗人",
                    lianxifangshi = "未知",
                },   
                new TeaInformation
                {
                    xingming = "程京",
                    zhiwu = "中国工程院院士",
                    biyeshijian = "未知",
                    zhuanye = "医学",
                    lianxifangshi = "未知",
                },   
                new TeaInformation
                {
                    xingming = "李德仁",
                    zhiwu = "工程院院士",
                    biyeshijian = "未知",
                    zhuanye = "水利",
                    lianxifangshi = "未知",
                }, 
                 new TeaInformation
                {
                    xingming = "普罗迪",
                    zhiwu = "国外院士",
                    biyeshijian = "未知",
                    zhuanye = "文学",
                    lianxifangshi = "未知",
                },   
                 new TeaInformation
                {
                    xingming = "安娜贝蒂琼卡",
                    zhiwu = "国外院士",
                    biyeshijian = "未知",
                    zhuanye = "未知",
                    lianxifangshi = "未知",
                },   
                 new TeaInformation
                {
                    xingming = "冯佛戈",
                    zhiwu = "杰出人文社会科学家",
                    biyeshijian = "未知",
                    zhuanye = "文学",
                    lianxifangshi = "未知",
                },   
                 new TeaInformation
                {
                    xingming = "柔石",
                    zhiwu = "杰出人文社会科学家",
                    biyeshijian = "未知",
                    zhuanye = "文学",
                    lianxifangshi = "未知",
                },   
                 new TeaInformation
                {
                    xingming = "元丰少",
                    zhiwu = "国家级教学名师",
                    biyeshijian = "未知",
                    zhuanye = "建筑",
                    lianxifangshi = "未知",
                },   
                 new TeaInformation
                {
                    xingming = "张晨曦",
                    zhiwu = "国家级教学名师",
                    biyeshijian = "未知",
                    zhuanye = "计算机",
                    lianxifangshi = "未知",
                },   
                 new TeaInformation
                {
                    xingming = "王祖涵",
                    zhiwu = "千人计划入选者",
                    biyeshijian = "未知",
                    zhuanye = "生物",
                    lianxifangshi = "未知",
                }
            };

            L_shizishuiping.DataContext = TeaInfo1.Where(s => (zhongkeyuan.IsChecked.Equals(true) && s.zhiwu == "中国科学院院士") || (zhonggongyuan.IsChecked.Equals(true) && s.zhiwu == "中国工程院院士") || (guowaiyuan.IsChecked.Equals(true) && s.zhiwu == "国外院士") || (renwenshehui.IsChecked.Equals(true) && s.zhiwu == "杰出人文社会科学家") || (jiaoxuemingshi.IsChecked.Equals(true) && s.zhiwu == "国家级教学名师") || (qianrenjihua.IsChecked.Equals(true) && s.zhiwu == "千人计划入选者")); 
            L_shizishuiping.SelectedIndex = 0;
        }
        private void S_xuekeshuiping_Click(object sender, RoutedEventArgs e)
        {
           
            List<SubInformation> SubInfo2 = new List<SubInformation>
             {
                 new SubInformation
                 {
                     zhuanyemingcheng = "桥梁工程",
                     xuekedengji = "高校学科创新引智基地（111计划）",
                     xueyuan = "土木",
                     qita = "桥梁抗震",
                     qita1 = "大跨度桥梁"

                 },

                 new SubInformation
                 {
                     zhuanyemingcheng = "海洋地质",
                     xuekedengji = "高校学科创新引智基地（111计划）",
                     xueyuan = "海洋",
                     qita = "古代环境变迁",
                     qita1 = "构造运动与气候变迁"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "建筑学",
                     xuekedengji = "国家一级重点学科",
                     xueyuan = "建筑",
                     qita = "城市发展战略",
                     qita1 = "城市建筑"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "环境工程",
                     xuekedengji = "国家一级重点学科",
                     xueyuan = "环境",
                     qita = "水污染控制理论",
                     qita1 = "固体废物处理"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "材料学",
                     xuekedengji = "国家二级重点学科",
                     xueyuan = "材料",
                     qita = "先进水泥",
                     qita1 = "纳米多孔材料"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "混凝土结构",
                     xuekedengji = "国家二级重点学科",
                     xueyuan = "建筑",
                     qita = "新型混凝土",
                     qita1 = "新型混凝土"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "岩土工程",
                     xuekedengji = "国家重点培育学科",
                     xueyuan = "土木",
                     qita = "土动力学",
                     qita1 = "隧道地下工程"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "机械设计与理论",
                     xuekedengji = "国家重点培育学科",
                     xueyuan = "机械",
                     qita = "机械设计原理",
                     qita1 = "车辆工程"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "汽车设计与制造",
                     xuekedengji = "国家一级重点学科",
                     xueyuan = "汽车",
                     qita = "汽车节能",
                     qita1 = "汽车系统动力学"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "胸心外科",
                     xuekedengji = "国家一级重点学科",
                     xueyuan = "医学院",
                     qita = "心肌保护",
                     qita1 = "复杂先心治疗"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "道路工程",
                     xuekedengji = "博士后流动站",
                     xueyuan = "轨道交通",
                     qita = "道路路面工程",
                     qita1 = "驻极体材料的制备与研究"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "固体力学",
                     xuekedengji = "博士后流动站",
                     xueyuan = "土木",
                     qita = "重大力学问题研究",
                     qita1 = "新材料工程"

                 }
             };
            L_xuekeshuiping.DataContext = SubInfo2.Where(s => (gaoxiaoxueke.IsChecked.Equals(true) && s.xuekedengji == "高校学科创新引智基地（111计划）")||(yijizhongdian.IsChecked.Equals(true) && s.xuekedengji == "国家一级重点学科")||(erjizhongdian.IsChecked.Equals(true) && s.xuekedengji == "国家二级重点学科")||(zhongdianpeiyu.IsChecked.Equals(true) && s.xuekedengji == "国家重点培育学科")||(liudongzhan.IsChecked.Equals(true) && s.xuekedengji == "博士后流动站"));
            L_xuekeshuiping.SelectedIndex = 0;
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
