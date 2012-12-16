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

namespace WpfApplication3.ResourcesAndManpower
{
    /// <summary>
    /// Interaction logic for PageSpatialResource.xaml
    /// </summary>
    public partial class PageSpatialResource : Page
    {

        List<SpatialNode> spatialNodes = new List<SpatialNode>
        {
            new SpatialNode
            {
                Name="文远楼",
                Type="教学办公用楼",
                ImageUrl=@"\Images\文远楼.jpg",
                BuildingIntro="BuildingIntro",
                CurrentUse="CurrentUse",
                Organization="vOrganization",
                RecentActivity="RecentActivity",
                Top=221,
                Left=540
            },
             new SpatialNode
            {
                Name="西北四楼",
                Type="食宿用楼",
                ImageUrl=@"\Images\西北四楼.jpg",
                BuildingIntro="BuildingIntro",
                CurrentUse="CurrentUse",
                Organization="vOrganization",
                RecentActivity="RecentActivity",
                Top=111,
                Left=243
            },
             new SpatialNode
            {
                Name="图书馆",
                Type="设施和实验室",
                ImageUrl=@"\Images\图书馆.jpg",
                BuildingIntro="BuildingIntro",
                CurrentUse="CurrentUse",
                Organization="vOrganization",
                RecentActivity="RecentActivity",
                Top=308,
                Left=509
            },
             new SpatialNode
            {
                Name="游泳馆",
                Type="体育场馆",
                ImageUrl=@"\Images\游泳馆.jpg",
                BuildingIntro="BuildingIntro",
                CurrentUse="CurrentUse",
                Organization="vOrganization",
                RecentActivity="RecentActivity",
                Top=498,
                Left=343
            }
        };

        public PageSpatialResource()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 根据类型数组返回建筑信息
        /// </summary>
        /// <param name="types">类型数组</param>
        /// <returns>建筑信息</returns>
        private List<SpatialNode> getSpatialNodesByTypes(string[] types)
        {
            var returnSpatialNodes = spatialNodes
                .Where(s => types.Contains(s.Type))
                .ToList();
            if (returnSpatialNodes != null && returnSpatialNodes.Count() != 0)
                return returnSpatialNodes;
            else
                return null;
        }

        /// <summary>
        /// 根据名字返回建筑信息
        /// </summary>
        /// <param name="name">名字</param>
        /// <returns>建筑信息</returns>
        private SpatialNode getSpatialNodeByName(string name)
        {
            var returnSpatialNode = spatialNodes
                          .Where(s => s.Name == name)
                          .First();
            if (returnSpatialNode != null)
                return returnSpatialNode;
            else
                return null;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string strCollegeName = btn.Content.ToString();
            SpatialNode node = getSpatialNodeByName(strCollegeName);
            DirectoryInfo di = new DirectoryInfo(System.Environment.CurrentDirectory);
            string strPath = di.Parent.Parent.FullName;
            if (System.IO.File.Exists(strPath + node.ImageUrl))
            {
                BitmapImage image = new BitmapImage(new Uri(strPath + node.ImageUrl));
                imageBuilding.Source = image;
            }
            TextBlock1.Text = node.BuildingIntro;
            TextBlock2.Text = node.CurrentUse;
            TextBlock3.Text = node.Organization;
            TextBlock4.Text = node.RecentActivity;
        }

        private void btnAll_Click(object sender, RoutedEventArgs e)
        {
            foreach (Button btn in canvasMap.Children)
            {
                btn.IsEnabled = true;
            }
        }

        private void btnTeachingOffice_Click(object sender, RoutedEventArgs e)
        {
            foreach (Button btn in canvasMap.Children)
            {
                if (getSpatialNodeByName(btn.Content.ToString()).Type == "教学办公用楼")
                    btn.IsEnabled = true;
                else
                    btn.IsEnabled = false;
            }


        }

        private void btnAccommodation_Click(object sender, RoutedEventArgs e)
        {
            foreach (Button btn in canvasMap.Children)
            {
                if (getSpatialNodeByName(btn.Content.ToString()).Type == "食宿用楼")
                    btn.IsEnabled = true;
                else
                    btn.IsEnabled = false;
            }
        }

        private void btnFacilitiesAndLaboratories_Click(object sender, RoutedEventArgs e)
        {
            foreach (Button btn in canvasMap.Children)
            {
                if (getSpatialNodeByName(btn.Content.ToString()).Type == "设施和实验室")
                    btn.IsEnabled = true;
                else
                    btn.IsEnabled = false;
            }
        }

        private void btnStadium_Click(object sender, RoutedEventArgs e)
        {
            foreach (Button btn in canvasMap.Children)
            {
                if (getSpatialNodeByName(btn.Content.ToString()).Type == "体育场馆")
                    btn.IsEnabled = true;
                else
                    btn.IsEnabled = false;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (SpatialNode node in spatialNodes)
            {
                Button btn = new Button();
                btn.Width = 75;
                btn.Height = 23;
                btn.Content = node.Name;
                btn.Click += button_Click;
                canvasMap.Children.Add(btn);
				btn.SetResourceReference(Button.StyleProperty,"ButtonSpatial");
                canvasMap.RegisterName("btn" + node.Name, btn);
                Canvas.SetLeft(btn, node.Left);
                Canvas.SetTop(btn, node.Top);
            }
        }





    }


    class SpatialNode
    {
        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 建筑类型
        /// </summary>
        public string Type { get; set; }
        public string ImageUrl { get; set; }
        public string BuildingIntro { get; set; }
        public string CurrentUse { get; set; }
        public string Organization { get; set; }
        public string RecentActivity { get; set; }
        public int Top { get; set; }
        public int Left { get; set; }
    }

}
