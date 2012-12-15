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
using WpfZhihui;
using System.Xml;
using System.Diagnostics;

namespace WpfApplication3.Development_performance
{
    /// <summary>
    /// Interaction logic for ComprehensiveReputation.xaml
    /// </summary>
    public partial class ComprehensiveReputation : Page
    {

        private List<NewsItem> items = new List<NewsItem>();
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
        
        
            Q_xueshushengyu.Navigate(new Uri(strPATH + @"/html/quxian.htm", UriKind.RelativeOrAbsolute));
            mainWebBrowser.Navigate(new Uri("http://news.hexun.com/2012-12-13/149009551.html", UriKind.RelativeOrAbsolute));
            mainWebBrowser1.Navigate(new Uri("http://news.hexun.com/2012-12-13/149009551.html", UriKind.RelativeOrAbsolute));

        
          
            D_shehuishengyu.Navigate(new Uri(strPATH + @"/html/redu.htm", UriKind.RelativeOrAbsolute));

            List<ShengYu> shengyu = new List<ShengYu>
            {

                new ShengYu
                {
                    title = "同济学子走进宜宾学院 两校学子互享经验促发展",
                    time = "12月11日",
                    description = "四川在线消息 12月12日晚，同济大学广播电视专业的李艺康同学为大家分享了他大学四年努力奋斗的人生经历，化学与化工学院团总支学生会承办。"
                },
                new ShengYu
                {
                    title = "同济大学推多项自主招生新政 专业兴趣列标准首位",
                    time = "12月15日",
                    description = "中新网上海12月12日电(黄艾娇 许婧)改革自主招生选拔评价标准，着力选拔具有明显专业兴趣、学科特长、创新潜质和身心健康的优秀学生；进一步推进按学科大类招生、大类培养；"
                },
                new ShengYu
                {
                    title = "同济大学加强四个体系建设推进创新创业人才培养",
                    time = "12月14日",
                    description = "中国网12月14日讯 教育部网站消息：党的十八大报告指出，要鼓励多渠道多形式就业，促进创业带动就业。近年来，同济大学立足学校实际，积极开展创新创业人才培养的探索与实践，培育激发学生创新创业潜能"
                },
                new ShengYu
                {
                    title = "都匀４１名干部赴同济大学“取经”",
                    time = "12月1日",
                    description = "金黔在线讯　12月11日上午，都匀市2012年城市规划建设管理专题培训班在同济大学开班。来自住建、规划、国土、环保等部门及乡镇办事处等单位共41名领导干部将在这里集中进行9天时间的学习城市规划建设管理等主题课程。"
                },
                new ShengYu
                {
                    title = "同济校长裴钢:大学的社会声誉在于培养了什么样的人",
                    time = "12月13日",
                    description = "浙江在线10月29日讯 昨天同济大学杭州校友会在杭州举行成立仪式。中科院院士、同济大学校长、细胞生物学家裴钢到场祝贺。他说：一流大学的标志，就是卓越人才的培养。"
                }


            };

            Rsslistleft.DataContext = shengyu;
            Rsslistmid.DataContext = shengyu;
            Rsslistright.DataContext = shengyu;

            Rsslistleft1.DataContext = shengyu;
            Rsslistmid1.DataContext = shengyu;
            Rsslistright1.DataContext = shengyu;
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

        public void LoadRss()
        {
            string[] rsspath ={ "http://news.tongji.edu.cn/rss.php?classid=6",
                                   //"http://www.xinhuanet.com/politics/news_politics.xml",
                                   "http://news.tongji.edu.cn/rss.php?classid=7",
                                   "http://news.tongji.edu.cn/rss.php?classid=8"
                                   ,"http://news.tongji.edu.cn/rss.php?classid=10"
                              };//RSS地址
            string[] channeltitle ={"同济大学综合新闻",
                                   //"新华时政",
                                   "同济大学教学新闻",
                                   "同济大学科研新闻"
                                   ,"同济大学外事新闻"
                                   };
            string[] channellink ={"http://news.tongji.edu.cn/classid-176.html",
                                   //"http://www.xinhuanet.com/politics/xw.htm",
                                   "http://news.tongji.edu.cn/classid-176.html",
                                   "http://news.tongji.edu.cn/classid-176.html"
                                   ,"http://news.tongji.edu.cn/classid-176.html"
                                  };
            string[] logopath = {
                                "/Images/logo_tongji.jpg",
                                //"/Images/新华1.jpg",
                                "/Images/logo_tongji.jpg",
                                "/Images/logo_tongji.jpg"
                                ,"/Images/logo_tongji.jpg"
                                };
            for (int cid = 0; cid < 4; cid++)
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
                XmlNode node = list.Item(0);//
                NewsItem item = new NewsItem();
                item = getItem((XmlElement)node);
                item.ChannelLink = channellink[cid];
                item.ChannelTitle = channeltitle[cid];
                item.LogoPath = logopath[cid];
                //加入list
                items.Add(item);
            }

            //添加绑定操作
            this.Rsslistleft.ItemsSource = items;
            this.Rsslistmid.ItemsSource = items;
            this.Rsslistright.ItemsSource = items;
            this.Rsslistleft1.ItemsSource = items;
            this.Rsslistmid1.ItemsSource = items;
            this.Rsslistright1.ItemsSource = items;
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
            string strPATH;
            DirectoryInfo di;
            di = new DirectoryInfo(System.Environment.CurrentDirectory);
            strPATH = di.Parent.Parent.FullName;
    
            mainWebBrowser.Navigate(new Uri(strPATH + @"/html/main.htm", UriKind.RelativeOrAbsolute));

            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;

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
        public class ShengYu
        {
            public string title { get; set; }
            public string time { get; set; }
            public string description { get; set; }
        }
        private void Grid_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Rsslistleft_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string strPATH;
            DirectoryInfo di;
            di = new DirectoryInfo(System.Environment.CurrentDirectory);
            strPATH = di.Parent.Parent.FullName;
            if (Rsslistleft.SelectedIndex == 0)
            {      
                mainWebBrowser.Navigate(new Uri("http://sichuan.scol.com.cn/ybxw/content/2012-12/15/content_4465330.htm?node=949",UriKind.RelativeOrAbsolute));
            }
            else if(Rsslistleft.SelectedIndex == 1)
            {
                mainWebBrowser.Navigate(new Uri("http://www.chinanews.com/edu/2012/12-12/4402457.shtml", UriKind.RelativeOrAbsolute));
            }
            else if (Rsslistleft.SelectedIndex == 2)
            {
                mainWebBrowser.Navigate(new Uri("http://news.china.com.cn/txt/2012-12/14/content_27421302.htm", UriKind.RelativeOrAbsolute));
            }
            else if (Rsslistleft.SelectedIndex == 3)
            {
                mainWebBrowser.Navigate(new Uri("http://news.ifeng.com/gundong/detail_2012_12/12/20070418_0.shtml", UriKind.RelativeOrAbsolute));
            }
            else if (Rsslistleft.SelectedIndex == 4)
            {
                mainWebBrowser.Navigate(new Uri("http://zjnews.zjol.com.cn/05zjnews/system/2012/10/29/018906954.shtml", UriKind.RelativeOrAbsolute));
            }

        }
        private void Rsslistmid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string strPATH;
            DirectoryInfo di;
            di = new DirectoryInfo(System.Environment.CurrentDirectory);
            strPATH = di.Parent.Parent.FullName;
            if (Rsslistmid.SelectedIndex == 0)
            {
                mainWebBrowser.Navigate(new Uri("http://sichuan.scol.com.cn/ybxw/content/2012-12/15/content_4465330.htm?node=949", UriKind.RelativeOrAbsolute));
            }
            else if (Rsslistmid.SelectedIndex == 1)
            {
                mainWebBrowser.Navigate(new Uri("http://www.chinanews.com/edu/2012/12-12/4402457.shtml", UriKind.RelativeOrAbsolute));
            }
            else if (Rsslistmid.SelectedIndex == 2)
            {
                mainWebBrowser.Navigate(new Uri("http://news.china.com.cn/txt/2012-12/14/content_27421302.htm", UriKind.RelativeOrAbsolute));
            }
            else if (Rsslistmid.SelectedIndex == 3)
            {
                mainWebBrowser.Navigate(new Uri("http://news.ifeng.com/gundong/detail_2012_12/12/20070418_0.shtml", UriKind.RelativeOrAbsolute));
            }
            else if (Rsslistmid.SelectedIndex == 4)
            {
                mainWebBrowser.Navigate(new Uri("http://zjnews.zjol.com.cn/05zjnews/system/2012/10/29/018906954.shtml", UriKind.RelativeOrAbsolute));
            }

        }
        private void Rsslistright_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string strPATH;
            DirectoryInfo di;
            di = new DirectoryInfo(System.Environment.CurrentDirectory);
            strPATH = di.Parent.Parent.FullName;
            if (Rsslistright.SelectedIndex == 0)
            {
                mainWebBrowser.Navigate(new Uri("http://sichuan.scol.com.cn/ybxw/content/2012-12/15/content_4465330.htm?node=949", UriKind.RelativeOrAbsolute));
            }
            else if (Rsslistright.SelectedIndex == 1)
            {
                mainWebBrowser.Navigate(new Uri("http://www.chinanews.com/edu/2012/12-12/4402457.shtml", UriKind.RelativeOrAbsolute));
            }
            else if (Rsslistright.SelectedIndex == 2)
            {
                mainWebBrowser.Navigate(new Uri("http://news.china.com.cn/txt/2012-12/14/content_27421302.htm", UriKind.RelativeOrAbsolute));
            }
            else if (Rsslistright.SelectedIndex == 3)
            {
                mainWebBrowser.Navigate(new Uri("http://news.ifeng.com/gundong/detail_2012_12/12/20070418_0.shtml", UriKind.RelativeOrAbsolute));
            }
            else if (Rsslistright.SelectedIndex == 4)
            {
                mainWebBrowser.Navigate(new Uri("http://zjnews.zjol.com.cn/05zjnews/system/2012/10/29/018906954.shtml", UriKind.RelativeOrAbsolute));
            }

        }


        private void Rsslistleft1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string strPATH;
            DirectoryInfo di;
            di = new DirectoryInfo(System.Environment.CurrentDirectory);
            strPATH = di.Parent.Parent.FullName;
            if (Rsslistleft1.SelectedIndex == 0)
            {
                mainWebBrowser1.Navigate(new Uri("http://sichuan.scol.com.cn/ybxw/content/2012-12/15/content_4465330.htm?node=949", UriKind.RelativeOrAbsolute));
            }
            else if (Rsslistleft1.SelectedIndex == 1)
            {
                mainWebBrowser1.Navigate(new Uri("http://www.chinanews.com/edu/2012/12-12/4402457.shtml", UriKind.RelativeOrAbsolute));
            }
            else if (Rsslistleft1.SelectedIndex == 2)
            {
                mainWebBrowser1.Navigate(new Uri("http://news.china.com.cn/txt/2012-12/14/content_27421302.htm", UriKind.RelativeOrAbsolute));
            }
            else if (Rsslistleft1.SelectedIndex == 3)
            {
                mainWebBrowser1.Navigate(new Uri("http://news.ifeng.com/gundong/detail_2012_12/12/20070418_0.shtml", UriKind.RelativeOrAbsolute));
            }
            else if (Rsslistleft1.SelectedIndex == 4)
            {
                mainWebBrowser1.Navigate(new Uri("http://zjnews.zjol.com.cn/05zjnews/system/2012/10/29/018906954.shtml", UriKind.RelativeOrAbsolute));
            }

        }
        private void Rsslistmid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string strPATH;
            DirectoryInfo di;
            di = new DirectoryInfo(System.Environment.CurrentDirectory);
            strPATH = di.Parent.Parent.FullName;
            if (Rsslistmid1.SelectedIndex == 0)
            {
                mainWebBrowser1.Navigate(new Uri("http://sichuan.scol.com.cn/ybxw/content/2012-12/15/content_4465330.htm?node=949", UriKind.RelativeOrAbsolute));
            }
            else if (Rsslistmid1.SelectedIndex == 1)
            {
                mainWebBrowser1.Navigate(new Uri("http://www.chinanews.com/edu/2012/12-12/4402457.shtml", UriKind.RelativeOrAbsolute));
            }
            else if (Rsslistmid1.SelectedIndex == 2)
            {
                mainWebBrowser1.Navigate(new Uri("http://news.china.com.cn/txt/2012-12/14/content_27421302.htm", UriKind.RelativeOrAbsolute));
            }
            else if (Rsslistmid1.SelectedIndex == 3)
            {
                mainWebBrowser1.Navigate(new Uri("http://news.ifeng.com/gundong/detail_2012_12/12/20070418_0.shtml", UriKind.RelativeOrAbsolute));
            }
            else if (Rsslistmid1.SelectedIndex == 4)
            {
                mainWebBrowser1.Navigate(new Uri("http://zjnews.zjol.com.cn/05zjnews/system/2012/10/29/018906954.shtml", UriKind.RelativeOrAbsolute));
            }

        }
        private void Rsslistright1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string strPATH;
            DirectoryInfo di;
            di = new DirectoryInfo(System.Environment.CurrentDirectory);
            strPATH = di.Parent.Parent.FullName;
            if (Rsslistright1.SelectedIndex == 0)
            {
                mainWebBrowser1.Navigate(new Uri("http://sichuan.scol.com.cn/ybxw/content/2012-12/15/content_4465330.htm?node=949", UriKind.RelativeOrAbsolute));
            }
            else if (Rsslistright1.SelectedIndex == 1)
            {
                mainWebBrowser1.Navigate(new Uri("http://www.chinanews.com/edu/2012/12-12/4402457.shtml", UriKind.RelativeOrAbsolute));
            }
            else if (Rsslistright1.SelectedIndex == 2)
            {
                mainWebBrowser1.Navigate(new Uri("http://news.china.com.cn/txt/2012-12/14/content_27421302.htm", UriKind.RelativeOrAbsolute));
            }
            else if (Rsslistright1.SelectedIndex == 3)
            {
                mainWebBrowser1.Navigate(new Uri("http://news.ifeng.com/gundong/detail_2012_12/12/20070418_0.shtml", UriKind.RelativeOrAbsolute));
            }
            else if (Rsslistright1.SelectedIndex == 4)
            {
                mainWebBrowser1.Navigate(new Uri("http://zjnews.zjol.com.cn/05zjnews/system/2012/10/29/018906954.shtml", UriKind.RelativeOrAbsolute));
            }

        }

    }
}
