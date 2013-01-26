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

namespace WpfApplication3.Development_performance
{
    /// <summary>
    /// Interaction logic for ScientificResearch.xaml
    /// </summary>
    public partial class ScientificResearch : Page
    {
        public ScientificResearch()
        {
            InitializeComponent();
        }
        protected void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<TeaInformation> TeaInfo = new List<TeaInformation>
            {
                new TeaInformation
                {
                    xingming = "纳米石墨相变储能复合材料制备技术及其应用技术",
                    zhiwu = "973国家重大基础研究项目",
                    biyeshijian = "未知",
                    zhuanye = "材料",
                    lianxifangshi = "未知",
                },
                              
                new TeaInformation
                {
                    xingming = "一种混凝土工程用三萜皂苷引气剂",
                    zhiwu = "973国家重大基础研究项目",
                    biyeshijian = "未知",
                    zhuanye = "材料",
                    lianxifangshi = "未知",
                },                
                new TeaInformation
                {
                    xingming = "建筑用氨基硫酸盐高性能减水剂及其制备方法",
                    zhiwu = "973国家重大基础研究项目",
                    biyeshijian = "未知",
                    zhuanye = "土木",
                    lianxifangshi = "未知",
                },
                new TeaInformation
                {
                    xingming = "高性能水泥基系列快速修补材料",
                    zhiwu = "国家重大科学研究计划项目",
                    biyeshijian = "未知",
                    zhuanye = "诗人",
                    lianxifangshi = "未知",
                },   
                new TeaInformation
                {
                    xingming = "HPE钢结构防腐涂料",
                    zhiwu = "国家重大科学研究计划项目",
                    biyeshijian = "未知",
                    zhuanye = "医学",
                    lianxifangshi = "未知",
                },   
                new TeaInformation
                {
                    xingming = "TJ型系列水质稳定剂",
                    zhiwu = "国家重大科学研究计划项目",
                    biyeshijian = "未知",
                    zhuanye = "水利",
                    lianxifangshi = "未知",
                }, 
                 new TeaInformation
                {
                    xingming = "一种具有植物营养作用的复合材料及其工艺",
                    zhiwu = "国家自然科学基金项目",
                    biyeshijian = "未知",
                    zhuanye = "文学",
                    lianxifangshi = "未知",
                },   
                 new TeaInformation
                {
                    xingming = "新型高效快速无毒复合聚铝铁净水剂",
                    zhiwu = "国家自然科学基金项目",
                    biyeshijian = "未知",
                    zhuanye = "未知",
                    lianxifangshi = "未知",
                },   
                 new TeaInformation
                {
                    xingming = "壳寡糖及其衍生物作为抗HIV-1多肽药物载体的应用",
                    zhiwu = "国家自然科学基金项目",
                    biyeshijian = "未知",
                    zhuanye = "文学",
                    lianxifangshi = "未知",
                },   
                 new TeaInformation
                {
                    xingming = "去甲斑蝥素缓释微球及其制备方法",
                    zhiwu = "国家社会科学基金项目",
                    biyeshijian = "未知",
                    zhuanye = "文学",
                    lianxifangshi = "未知",
                },   
                 new TeaInformation
                {
                    xingming = "4-哌啶基哌啶的生产技术",
                    zhiwu = "国家社会科学基金项目",
                    biyeshijian = "未知",
                    zhuanye = "建筑",
                    lianxifangshi = "未知",
                },   
                 new TeaInformation
                {
                    xingming = "天然气发动机改装与控制关键技术",
                    zhiwu = "国家社会科学基金项目",
                    biyeshijian = "未知",
                    zhuanye = "计算机",
                    lianxifangshi = "未知",
                },   
                 new TeaInformation
                {
                    xingming = "天然气发动机改装与控制关键技术",
                    zhiwu = "国家社会科学基金项目",
                    biyeshijian = "未知",
                    zhuanye = "生物",
                    lianxifangshi = "未知",
                }
            };
            List<SubInformation> SubInfo = new List<SubInformation>
             {
                 new SubInformation
                 {
                     zhuanyemingcheng = "钢结构(钢混结构)多高层节能住宅的成套技术研究",
                     xuekedengji = "973国家重大基础研究项目",
                     xueyuan = "土木",
                     qita = "桥梁抗震",
                     qita1 = "大跨度桥梁"

                 },

                 new SubInformation
                 {
                     zhuanyemingcheng = "地下结构工程防淹密闭隔断装置",
                     xuekedengji = "973国家重大基础研究项目",
                     xueyuan = "海洋",
                     qita = "古代环境变迁",
                     qita1 = "构造运动与气候变迁"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "城市综合防灾减灾技术",
                     xuekedengji = "973国家重大基础研究项目",
                     xueyuan = "建筑",
                     qita = "城市发展战略",
                     qita1 = "城市建筑"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "高性能聚合物水泥基",
                     xuekedengji = "国家重大科学研究计划项目",
                     xueyuan = "环境",
                     qita = "水污染控制理论",
                     qita1 = "固体废物处理"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "智慧城市",
                     xuekedengji = "国家重大科学研究计划项目",
                     xueyuan = "材料",
                     qita = "先进水泥",
                     qita1 = "纳米多孔材料"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "沈阳机床",
                     xuekedengji = "国家重大科学研究计划项目",
                     xueyuan = "建筑",
                     qita = "新型混凝土",
                     qita1 = "新型混凝土"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "大气层图形处理",
                     xuekedengji = "国家自然科学基金项目",
                     xueyuan = "土木",
                     qita = "土动力学",
                     qita1 = "隧道地下工程"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "纳米多孔二氧化硅气凝胶块体",
                     xuekedengji = "国家自然科学基金项目",
                     xueyuan = "机械",
                     qita = "机械设计原理",
                     qita1 = "车辆工程"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "环保节能新型汽车设计与制造",
                     xuekedengji = "国家自然科学基金项目",
                     xueyuan = "汽车",
                     qita = "汽车节能",
                     qita1 = "汽车系统动力学"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "纳米机器人的研究",
                     xuekedengji = "国家社会科学基金项目",
                     xueyuan = "医学院",
                     qita = "心肌保护",
                     qita1 = "复杂先心治疗"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "新型轨道交通工具",
                     xuekedengji = "国家社会科学基金项目",
                     xueyuan = "轨道交通",
                     qita = "道路路面工程",
                     qita1 = "驻极体材料的制备与研究"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "流体力学在轨道交通中的应用",
                     xuekedengji = "国家社会科学基金项目",
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


            loadGraph();
        }

        protected void loadGraph()
        {
            CreateChart.ChartInformation ci1 = new ChartInformation()
            {
                m_BorderThickness = new Thickness(1.0),
                m_Theme = "Theme1",
                m_View3D = true,
                m_axisXTitle = "科研成果",
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
                                    YValue = 25,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2002年",
                                    YValue = 36,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2003年",
                                    YValue = 27,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2004年",
                                    YValue = 48,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2005年",
                                    YValue = 29,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2006年",
                                    YValue = 50,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2007年",
                                    YValue = 31,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2008年",
                                    YValue = 62,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2009年",
                                    YValue = 33,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2010年",
                                    YValue = 74,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2011年",
                                    YValue = 35,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2012年",
                                    YValue = 86,
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
                m_axisXTitle = "科研基地",
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
                                    YValue = 16,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2003年",
                                    YValue = 27,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2004年",
                                    YValue = 48,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2005年",
                                    YValue = 29,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2006年",
                                    YValue = 80,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2007年",
                                    YValue = 31,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2008年",
                                    YValue = 82,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2009年",
                                    YValue = 33,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2010年",
                                    YValue = 94,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2011年",
                                    YValue = 35,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2012年",
                                    YValue = 96,
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
                m_axisXTitle = "科研项目",
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
                                    YValue = 20,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2004年",
                                    YValue = 48,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2005年",
                                    YValue = 29,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2006年",
                                    YValue = 90,
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
                                    YValue = 35,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "2012年",
                                    YValue = 76,
                                },
                            }
                        },
                    },
            };

            ChartHelper ch = new ChartHelper();
            Chart m_chart1 = ch.CreateChart(ci1);
            gridAchievement.Children.Clear();
            gridAchievement.Children.Add(m_chart1);

            Chart m_chart2 = ch.CreateChart(ci2);
            gridBase.Children.Clear();
            gridBase.Children.Add(m_chart2);

            Chart m_chart3 = ch.CreateChart(ci3);
            gridProject.Children.Clear();
            gridProject.Children.Add(m_chart3);

        }

        protected void S_jiaoyujiaoxue_Click(object sender, RoutedEventArgs e)
        {
            List<SubInformation> SubInfo1 = new List<SubInformation>
             {
                 new SubInformation
                 {
                     zhuanyemingcheng = "钢结构(钢混结构)多高层节能住宅的成套技术研究",
                     xuekedengji = "973国家重大基础研究项目",
                     xueyuan = "土木",
                     qita = "桥梁抗震",
                     qita1 = "大跨度桥梁"

                 },

                 new SubInformation
                 {
                     zhuanyemingcheng = "地下结构工程防淹密闭隔断装置",
                     xuekedengji = "973国家重大基础研究项目",
                     xueyuan = "海洋",
                     qita = "古代环境变迁",
                     qita1 = "构造运动与气候变迁"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "城市综合防灾减灾技术",
                     xuekedengji = "973国家重大基础研究项目",
                     xueyuan = "建筑",
                     qita = "城市发展战略",
                     qita1 = "城市建筑"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "高性能聚合物水泥基",
                     xuekedengji = "国家重大科学研究计划项目",
                     xueyuan = "环境",
                     qita = "水污染控制理论",
                     qita1 = "固体废物处理"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "智慧城市",
                     xuekedengji = "国家重大科学研究计划项目",
                     xueyuan = "材料",
                     qita = "先进水泥",
                     qita1 = "纳米多孔材料"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "沈阳机床",
                     xuekedengji = "国家重大科学研究计划项目",
                     xueyuan = "建筑",
                     qita = "新型混凝土",
                     qita1 = "新型混凝土"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "大气层图形处理",
                     xuekedengji = "国家自然科学基金项目",
                     xueyuan = "土木",
                     qita = "土动力学",
                     qita1 = "隧道地下工程"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "纳米多孔二氧化硅气凝胶块体",
                     xuekedengji = "国家自然科学基金项目",
                     xueyuan = "机械",
                     qita = "机械设计原理",
                     qita1 = "车辆工程"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "环保节能新型汽车设计与制造",
                     xuekedengji = "国家自然科学基金项目",
                     xueyuan = "汽车",
                     qita = "汽车节能",
                     qita1 = "汽车系统动力学"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "纳米机器人的研究",
                     xuekedengji = "国家社会科学基金项目",
                     xueyuan = "医学院",
                     qita = "心肌保护",
                     qita1 = "复杂先心治疗"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "新型轨道交通工具",
                     xuekedengji = "国家社会科学基金项目",
                     xueyuan = "轨道交通",
                     qita = "道路路面工程",
                     qita1 = "驻极体材料的制备与研究"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "流体力学在轨道交通中的应用",
                     xuekedengji = "国家社会科学基金项目",
                     xueyuan = "土木",
                     qita = "重大力学问题研究",
                     qita1 = "新材料工程"

                 }
             };
            L_jiaoyujiaoxue.DataContext = SubInfo1.Where(s => (jiuqisan1.IsChecked.Equals(true) && s.xuekedengji == "973国家重大基础研究项目") || (zhongda1.IsChecked.Equals(true) && s.xuekedengji == "国家重大科学研究计划项目") || (ziran1.IsChecked.Equals(true) && s.xuekedengji == "国家自然科学基金项目") || (shehui1.IsChecked.Equals(true) && s.xuekedengji == "国家社会科学基金项目"));
            L_jiaoyujiaoxue.SelectedIndex = 0;


        }
        protected void S_shizishuiping_Click(object sender, RoutedEventArgs e)
        {
            List<TeaInformation> TeaInfo1 = new List<TeaInformation>
            {
                new TeaInformation
                {
                    xingming = "纳米石墨相变储能复合材料制备技术及其应用技术",
                    zhiwu = "973国家重大基础研究项目",
                    biyeshijian = "未知",
                    zhuanye = "材料",
                    lianxifangshi = "未知",
                },
                              
                new TeaInformation
                {
                    xingming = "一种混凝土工程用三萜皂苷引气剂",
                    zhiwu = "973国家重大基础研究项目",
                    biyeshijian = "未知",
                    zhuanye = "材料",
                    lianxifangshi = "未知",
                },                
                new TeaInformation
                {
                    xingming = "建筑用氨基硫酸盐高性能减水剂及其制备方法",
                    zhiwu = "973国家重大基础研究项目",
                    biyeshijian = "未知",
                    zhuanye = "土木",
                    lianxifangshi = "未知",
                },
                new TeaInformation
                {
                    xingming = "高性能水泥基系列快速修补材料",
                    zhiwu = "国家重大科学研究计划项目",
                    biyeshijian = "未知",
                    zhuanye = "诗人",
                    lianxifangshi = "未知",
                },   
                new TeaInformation
                {
                    xingming = "HPE钢结构防腐涂料",
                    zhiwu = "国家重大科学研究计划项目",
                    biyeshijian = "未知",
                    zhuanye = "医学",
                    lianxifangshi = "未知",
                },   
                new TeaInformation
                {
                    xingming = "TJ型系列水质稳定剂",
                    zhiwu = "国家重大科学研究计划项目",
                    biyeshijian = "未知",
                    zhuanye = "水利",
                    lianxifangshi = "未知",
                }, 
                 new TeaInformation
                {
                    xingming = "一种具有植物营养作用的复合材料及其工艺",
                    zhiwu = "国家自然科学基金项目",
                    biyeshijian = "未知",
                    zhuanye = "文学",
                    lianxifangshi = "未知",
                },   
                 new TeaInformation
                {
                    xingming = "新型高效快速无毒复合聚铝铁净水剂",
                    zhiwu = "国家自然科学基金项目",
                    biyeshijian = "未知",
                    zhuanye = "未知",
                    lianxifangshi = "未知",
                },   
                 new TeaInformation
                {
                    xingming = "壳寡糖及其衍生物作为抗HIV-1多肽药物载体的应用",
                    zhiwu = "国家自然科学基金项目",
                    biyeshijian = "未知",
                    zhuanye = "文学",
                    lianxifangshi = "未知",
                },   
                 new TeaInformation
                {
                    xingming = "去甲斑蝥素缓释微球及其制备方法",
                    zhiwu = "国家社会科学基金项目",
                    biyeshijian = "未知",
                    zhuanye = "文学",
                    lianxifangshi = "未知",
                },   
                 new TeaInformation
                {
                    xingming = "4-哌啶基哌啶的生产技术",
                    zhiwu = "国家社会科学基金项目",
                    biyeshijian = "未知",
                    zhuanye = "建筑",
                    lianxifangshi = "未知",
                },   
                 new TeaInformation
                {
                    xingming = "天然气发动机改装与控制关键技术",
                    zhiwu = "国家社会科学基金项目",
                    biyeshijian = "未知",
                    zhuanye = "计算机",
                    lianxifangshi = "未知",
                },   
                 new TeaInformation
                {
                    xingming = "天然气发动机改装与控制关键技术",
                    zhiwu = "国家社会科学基金项目",
                    biyeshijian = "未知",
                    zhuanye = "生物",
                    lianxifangshi = "未知",
                }
            };

            L_shizishuiping.DataContext = TeaInfo1.Where(s => (jiuqisan2.IsChecked.Equals(true) && s.zhiwu == "973国家重大基础研究项目") || (zhongda2.IsChecked.Equals(true) && s.zhiwu == "国家重大科学研究计划项目") || (ziran2.IsChecked.Equals(true) && s.zhiwu == "国家自然科学基金项目") || (shehui2.IsChecked.Equals(true) && s.zhiwu == "国家社会科学基金项目") );
            L_shizishuiping.SelectedIndex = 0;
        }
        private void S_xuekeshuiping_Click(object sender, RoutedEventArgs e)
        {

            List<SubInformation> SubInfo2 = new List<SubInformation>
             {
                 new SubInformation
                 {
                     zhuanyemingcheng = "钢结构(钢混结构)多高层节能住宅的成套技术研究",
                     xuekedengji = "973国家重大基础研究项目",
                     xueyuan = "土木",
                     qita = "桥梁抗震",
                     qita1 = "大跨度桥梁"

                 },

                 new SubInformation
                 {
                     zhuanyemingcheng = "地下结构工程防淹密闭隔断装置",
                     xuekedengji = "973国家重大基础研究项目",
                     xueyuan = "海洋",
                     qita = "古代环境变迁",
                     qita1 = "构造运动与气候变迁"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "城市综合防灾减灾技术",
                     xuekedengji = "973国家重大基础研究项目",
                     xueyuan = "建筑",
                     qita = "城市发展战略",
                     qita1 = "城市建筑"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "高性能聚合物水泥基",
                     xuekedengji = "国家重大科学研究计划项目",
                     xueyuan = "环境",
                     qita = "水污染控制理论",
                     qita1 = "固体废物处理"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "智慧城市",
                     xuekedengji = "国家重大科学研究计划项目",
                     xueyuan = "材料",
                     qita = "先进水泥",
                     qita1 = "纳米多孔材料"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "沈阳机床",
                     xuekedengji = "国家重大科学研究计划项目",
                     xueyuan = "建筑",
                     qita = "新型混凝土",
                     qita1 = "新型混凝土"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "大气层图形处理",
                     xuekedengji = "国家自然科学基金项目",
                     xueyuan = "土木",
                     qita = "土动力学",
                     qita1 = "隧道地下工程"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "纳米多孔二氧化硅气凝胶块体",
                     xuekedengji = "国家自然科学基金项目",
                     xueyuan = "机械",
                     qita = "机械设计原理",
                     qita1 = "车辆工程"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "环保节能新型汽车设计与制造",
                     xuekedengji = "国家自然科学基金项目",
                     xueyuan = "汽车",
                     qita = "汽车节能",
                     qita1 = "汽车系统动力学"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "纳米机器人的研究",
                     xuekedengji = "国家社会科学基金项目",
                     xueyuan = "医学院",
                     qita = "心肌保护",
                     qita1 = "复杂先心治疗"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "新型轨道交通工具",
                     xuekedengji = "国家社会科学基金项目",
                     xueyuan = "轨道交通",
                     qita = "道路路面工程",
                     qita1 = "驻极体材料的制备与研究"

                 },
                                  new SubInformation
                 {
                     zhuanyemingcheng = "流体力学在轨道交通中的应用",
                     xuekedengji = "国家社会科学基金项目",
                     xueyuan = "土木",
                     qita = "重大力学问题研究",
                     qita1 = "新材料工程"

                 }
             };
            L_xuekeshuiping.DataContext = SubInfo2.Where(s => (jiuqisan3.IsChecked.Equals(true) && s.xuekedengji == "973国家重大基础研究项目") || (zhongda3.IsChecked.Equals(true) && s.xuekedengji == "国家重大科学研究计划项目") || (ziran3.IsChecked.Equals(true) && s.xuekedengji == "国家自然科学基金项目") || (shehui3.IsChecked.Equals(true) && s.xuekedengji == "国家社会科学基金项目") );
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
            if (gridAchievement.Children.Count == 0)
                gridAchievement.Children.Add(ue);
            else if (gridProject.Children.Count == 0)
                gridProject.Children.Add(ue);
            else if (gridBase.Children.Count == 0)
                gridBase.Children.Add(ue);
        }
    }
}
