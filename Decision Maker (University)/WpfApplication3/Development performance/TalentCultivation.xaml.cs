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
using Visifire.Charts;
using WpfApplication3.CreateChart;
using System.Data;
using System.Diagnostics;

namespace WpfApplication3.Development_performance
{
    /// <summary>
    /// Interaction logic for TalentCultivation.xaml
    /// </summary>
    public partial class TalentCultivation : Page
    {

        public TalentCultivation(int i)
        {
            InitializeComponent();
            //确定默认选项
            switch (i){
                case 1:
                    tabI_education.IsSelected = true;
                    tabI_teachers.IsSelected = false;
                    tabI_train.IsSelected = false;
                    break;
                case 2:

                    tabI_education.IsSelected = false;
                    tabI_teachers.IsSelected = true;
                    tabI_train.IsSelected = false;
                    break;
                case 3:
                    tabI_education.IsSelected = false;
                    tabI_teachers.IsSelected = false;
                    tabI_train.IsSelected = true;
                    break;
            }
        }

        protected void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<TeaInformation> TeaInfo = new List<TeaInformation>
            {
                new TeaInformation
                {
                    xingming = "戴复东",
                    zhiwu = "中国工程院院士",
                    biyeshijian = "1952年7月",
                    zhuanye = "建筑学与建筑设计",
                    lianxifangshi = "http://gtjuh.tongji.edu.cn/person/intro/new_page_122.htm",
                },
                              
                new TeaInformation
                {
                    xingming = "范立础",
                    zhiwu = "中国工程院院士",
                    biyeshijian = "1955年7月",
                    zhuanye = "桥梁和结构工程",
                    lianxifangshi = "http://gtjuh.tongji.edu.cn/person/intro/new_page_124.htm",
                },                
                new TeaInformation
                {
                    xingming = "郭重庆",
                    zhiwu = "中国工程院院士",
                    biyeshijian = "1957年",
                    zhuanye = "机械制造工艺与设备",
                    lianxifangshi = "http://gtjuh.tongji.edu.cn/person/intro/new_page_123.htm",
                },
                new TeaInformation
                {
                    xingming = "李同保",
                    zhiwu = "中国工程院院士",
                    biyeshijian = "1963年",
                    zhuanye = "测量学",
                    lianxifangshi = "http://gtjuh.tongji.edu.cn/person/intro/new_page_125.htm",
                },   
                new TeaInformation
                {
                    xingming = "卢耀如",
                    zhiwu = "中国工程院院士",
                    biyeshijian = "1953年8月",
                    zhuanye = "地质学",
                    lianxifangshi = "http://gtjuh.tongji.edu.cn/person/intro/new_page_126.htm",
                },   
                new TeaInformation
                {
                    xingming = "马在田",
                    zhiwu = "中国科学院院士",
                    biyeshijian = "1957年",
                    zhuanye = "地球物理学",
                    lianxifangshi = "http://gtjuh.tongji.edu.cn/person/intro/new_page_127.htm",
                }, 
                 new TeaInformation
                {
                    xingming = "沈祖炎",
                    zhiwu = "中国工程院院士",
                    biyeshijian = "1955年",
                    zhuanye = "结构工程钢结构",
                    lianxifangshi = "http://gtjuh.tongji.edu.cn/person/intro/new_page_128.htm",
                },   
                 new TeaInformation
                {
                    xingming = "孙钧",
                    zhiwu = "中国科学院院士",
                    biyeshijian = "1949年6月",
                    zhuanye = "土木工程",
                    lianxifangshi = "http://gtjuh.tongji.edu.cn/person/intro/new_page_129.htm",
                },   
                 new TeaInformation
                {
                    xingming = "汪品先",
                    zhiwu = "中国科学院院士",
                    biyeshijian = "1960年",
                    zhuanye = "海洋与地球科学",
                    lianxifangshi = "http://gtjuh.tongji.edu.cn/person/intro/new_page_130.htm",
                },   
                 new TeaInformation
                {
                    xingming = "项海帆",
                    zhiwu = "中国工程院院士",
                    biyeshijian = "1955年",
                    zhuanye = "桥梁及结构工程",
                    lianxifangshi = "http://gtjuh.tongji.edu.cn/person/intro/new_page_131.htm",
                },   
                 new TeaInformation
                {
                    xingming = "姚熹",
                    zhiwu = "中国科学院院士",
                    biyeshijian = "1957年",
                    zhuanye = "电子陶瓷",
                    lianxifangshi = "http://gtjuh.tongji.edu.cn/person/intro/new_page_132.htm",
                },   
                 new TeaInformation
                {
                    xingming = "郑时龄",
                    zhiwu = "中国科学院院士",
                    biyeshijian = "1965年",
                    zhuanye = "建筑学",
                    lianxifangshi = "http://gtjuh.tongji.edu.cn/person/intro/new_page_133.htm",
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

            D_shizishuiping.ItemsSource = TeaInfo;

            D_jiaoyujiaoxue.ItemsSource = SubInfo;
            D_jiaoyujiaoxue.SelectedIndex = 0;

            D_xuekeshuiping.ItemsSource = SubInfo;
            D_xuekeshuiping.SelectedIndex = 0;

            loadGraph();
            
        }

        protected void loadGraph()
        {
            CreateChart.ChartInformation ci1 = new ChartInformation()
            {
                m_BorderThickness = new Thickness(1.0),
                m_Theme = "Theme1",
                m_View3D = true,
                m_axisXTitle = "教育教学",
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
                                    AxisXLabel = "2001年",
                                    YValue = 15,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2002年",
                                    YValue = 26,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2003年",
                                    YValue = 27,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2004年",
                                    YValue = 28,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2005年",
                                    YValue = 39,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2006年",
                                    YValue = 30,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2007年",
                                    YValue = 41,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2008年",
                                    YValue = 32,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2009年",
                                    YValue = 53,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2010年",
                                    YValue = 34,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2011年",
                                    YValue = 65,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2012年",
                                    YValue = 36,
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
                m_axisXTitle = "师资水平",
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
                                    AxisXLabel = "2001年",
                                    YValue = 25,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2002年",
                                    YValue = 26,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2003年",
                                    YValue = 37,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2004年",
                                    YValue = 28,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2005年",
                                    YValue = 49,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2006年",
                                    YValue = 30,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2007年",
                                    YValue = 51,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2008年",
                                    YValue = 32,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2009年",
                                    YValue = 63,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2010年",
                                    YValue = 34,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2011年",
                                    YValue = 75,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2012年",
                                    YValue = 36,
                                },
                            }
                        },
                    },
            };
            CreateChart.ChartInformation ci3 = new ChartInformation()
            {
                m_BorderThickness = new Thickness(1.0),
                m_Theme = "Theme1",
                m_View3D = true,
                m_axisXTitle = "学科水平",
                m_axisYTitle = "",
                m_axisYMaximum = 100,
                m_axisYInterval = 20,
                dsc = new DataSeriesCollection()
                    {
                        new DataSeries()
                        {
                            LegendText = "",
                            RenderAs = RenderAs.Area,
                            AxisYType = AxisTypes.Primary,
                            DataPoints = new DataPointCollection()
                            {
                                new DataPoint()
                                {
                                    AxisXLabel = "2001年",
                                    YValue = 25,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2002年",
                                    YValue = 26,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2003年",
                                    YValue = 27,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2004年",
                                    YValue = 28,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2005年",
                                    YValue = 29,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2006年",
                                    YValue = 30,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2007年",
                                    YValue = 31,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2008年",
                                    YValue = 32,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2009年",
                                    YValue = 33,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2010年",
                                    YValue = 34,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2011年",
                                    YValue = 35,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2012年",
                                    YValue = 36,
                                },
                            }
                        },
                    },
            };

            ChartHelper ch = new ChartHelper();
            Chart m_chart1 = ch.CreateChart(ci1);
            gridEducation.Children.Clear();
            gridEducation.Children.Add(m_chart1);

            Chart m_chart2 = ch.CreateChart(ci2);
            gridTeaching.Children.Clear();
            gridTeaching.Children.Add(m_chart2);

            Chart m_chart3 = ch.CreateChart(ci3);
            gridAcademic.Children.Clear();
            gridAcademic.Children.Add(m_chart3);
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
            D_jiaoyujiaoxue.ItemsSource = SubInfo1.Where(s => (gaoxiaoxueke1.IsChecked.Equals(true) && s.xuekedengji == "高校学科创新引智基地（111计划）") || (yijizhongdian1.IsChecked.Equals(true) && s.xuekedengji == "国家一级重点学科") || (erjizhongdian1.IsChecked.Equals(true) && s.xuekedengji == "国家二级重点学科") || (zhongdianpeiyu1.IsChecked.Equals(true) && s.xuekedengji == "国家重点培育学科") || (liudongzhan1.IsChecked.Equals(true) && s.xuekedengji == "博士后流动站"));
            D_jiaoyujiaoxue.SelectedIndex = 0;


        }
        protected void S_shizishuiping_Click(object sender, RoutedEventArgs e)
        {
            List<TeaInformation> TeaInfo1 = new List<TeaInformation>
            {
                 new TeaInformation
                {
                    xingming = "戴复东",
                    zhiwu = "中国工程院院士",
                    biyeshijian = "1952年7月",
                    zhuanye = "建筑学与建筑设计",
                    lianxifangshi = "http://gtjuh.tongji.edu.cn/person/intro/new_page_122.htm",
                },
                              
                new TeaInformation
                {
                    xingming = "范立础",
                    zhiwu = "中国工程院院士",
                    biyeshijian = "1955年7月",
                    zhuanye = "桥梁和结构工程",
                    lianxifangshi = "http://gtjuh.tongji.edu.cn/person/intro/new_page_124.htm",
                },                
                new TeaInformation
                {
                    xingming = "郭重庆",
                    zhiwu = "中国工程院院士",
                    biyeshijian = "1957年",
                    zhuanye = "机械制造工艺与设备",
                    lianxifangshi = "http://gtjuh.tongji.edu.cn/person/intro/new_page_123.htm",
                },
                new TeaInformation
                {
                    xingming = "李同保",
                    zhiwu = "中国工程院院士",
                    biyeshijian = "1963年",
                    zhuanye = "测量学",
                    lianxifangshi = "http://gtjuh.tongji.edu.cn/person/intro/new_page_125.htm",
                },   
                new TeaInformation
                {
                    xingming = "卢耀如",
                    zhiwu = "中国工程院院士",
                    biyeshijian = "1953年8月",
                    zhuanye = "地质学",
                    lianxifangshi = "http://gtjuh.tongji.edu.cn/person/intro/new_page_126.htm",
                },   
                new TeaInformation
                {
                    xingming = "马在田",
                    zhiwu = "中国科学院院士",
                    biyeshijian = "1957年",
                    zhuanye = "地球物理学",
                    lianxifangshi = "http://gtjuh.tongji.edu.cn/person/intro/new_page_127.htm",
                }, 
                 new TeaInformation
                {
                    xingming = "沈祖炎",
                    zhiwu = "中国工程院院士",
                    biyeshijian = "1955年",
                    zhuanye = "结构工程钢结构",
                    lianxifangshi = "http://gtjuh.tongji.edu.cn/person/intro/new_page_128.htm",
                },   
                 new TeaInformation
                {
                    xingming = "孙钧",
                    zhiwu = "中国科学院院士",
                    biyeshijian = "1949年6月",
                    zhuanye = "土木工程",
                    lianxifangshi = "http://gtjuh.tongji.edu.cn/person/intro/new_page_129.htm",
                },   
                 new TeaInformation
                {
                    xingming = "汪品先",
                    zhiwu = "中国科学院院士",
                    biyeshijian = "1960年",
                    zhuanye = "海洋与地球科学",
                    lianxifangshi = "http://gtjuh.tongji.edu.cn/person/intro/new_page_130.htm",
                },   
                 new TeaInformation
                {
                    xingming = "项海帆",
                    zhiwu = "中国工程院院士",
                    biyeshijian = "1955年",
                    zhuanye = "桥梁及结构工程",
                    lianxifangshi = "http://gtjuh.tongji.edu.cn/person/intro/new_page_131.htm",
                },   
                 new TeaInformation
                {
                    xingming = "姚熹",
                    zhiwu = "中国科学院院士",
                    biyeshijian = "1957年",
                    zhuanye = "电子陶瓷",
                    lianxifangshi = "http://gtjuh.tongji.edu.cn/person/intro/new_page_132.htm",
                },   
                 new TeaInformation
                {
                    xingming = "郑时龄",
                    zhiwu = "中国科学院院士",
                    biyeshijian = "1965年",
                    zhuanye = "建筑学",
                    lianxifangshi = "http://gtjuh.tongji.edu.cn/person/intro/new_page_133.htm",
                }
            };

            D_shizishuiping.ItemsSource = TeaInfo1.Where(s => (zhongkeyuan.IsChecked.Equals(true) && s.zhiwu == "中国科学院院士") || (zhonggongyuan.IsChecked.Equals(true) && s.zhiwu == "中国工程院院士") || (guowaiyuan.IsChecked.Equals(true) && s.zhiwu == "国外院士") || (renwenshehui.IsChecked.Equals(true) && s.zhiwu == "杰出人文社会科学家") || (jiaoxuemingshi.IsChecked.Equals(true) && s.zhiwu == "国家级教学名师") || (qianrenjihua.IsChecked.Equals(true) && s.zhiwu == "千人计划入选者"));
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
            D_xuekeshuiping.ItemsSource = SubInfo2.Where(s => (gaoxiaoxueke.IsChecked.Equals(true) && s.xuekedengji == "高校学科创新引智基地（111计划）") || (yijizhongdian.IsChecked.Equals(true) && s.xuekedengji == "国家一级重点学科") || (erjizhongdian.IsChecked.Equals(true) && s.xuekedengji == "国家二级重点学科") || (zhongdianpeiyu.IsChecked.Equals(true) && s.xuekedengji == "国家重点培育学科") || (liudongzhan.IsChecked.Equals(true) && s.xuekedengji == "博士后流动站"));
            D_xuekeshuiping.SelectedIndex = 0;
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

        private void gridLittleGraph_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount != 2)
                return;
            UIElement ue = ((Grid)sender).Children[0];
            ((Grid)sender).Children.Clear();
            gridMaxGraph.Children.Add(ue);
            gridContent.Visibility = System.Windows.Visibility.Hidden;
            gridMaxGraph.Visibility = System.Windows.Visibility.Visible;
        }

        private void gridMaxGraph_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount != 2)
                return;
            gridMaxGraph.Visibility = System.Windows.Visibility.Hidden;
            gridContent.Visibility = System.Windows.Visibility.Visible;
            UIElement ue = ((Grid)sender).Children[0];
            ((Grid)sender).Children.Clear();
            if (gridEducation.Children.Count == 0)
                gridEducation.Children.Add(ue);
            else if (gridAcademic.Children.Count == 0)
                gridAcademic.Children.Add(ue);
            else if (gridTeaching.Children.Count == 0)
                gridTeaching.Children.Add(ue);
        }

        private void btn_home_Click(object sender, RoutedEventArgs e)
        {
            Development_performance.ComprehensiveIndex ComprehensiveI = new Development_performance.ComprehensiveIndex();
            this.NavigationService.Navigate(ComprehensiveI);
        }

        private void Hyperlink_Click1(object sender, RoutedEventArgs e)
        {
            /*Hyperlink link = e.OriginalSource as Hyperlink;
            Process.Start(link.NavigateUri.AbsoluteUri);
            */
            TeaInformation tea = (TeaInformation)D_shizishuiping.SelectedItem;

            Teaching m_window = new Teaching(tea.lianxifangshi.ToString());
            try
            {
              m_window.Show();
              Development_performance.TalentCultivation TalentCultivationI = new Development_performance.TalentCultivation(2);
              this.NavigationService.Navigate(TalentCultivationI);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
