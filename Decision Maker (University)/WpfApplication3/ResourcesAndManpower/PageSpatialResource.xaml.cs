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
                ImageUrl="Image/sdf",
                BuildingIntro="BuildingIntro",
                CurrentUse="CurrentUse",
                Organization="vOrganization",
                RecentActivity="RecentActivity"
            },
             new SpatialNode
            {
                Name="西北四楼",
                Type="教学办公用楼",
                ImageUrl="Image/sdf",
                BuildingIntro="BuildingIntro",
                CurrentUse="CurrentUse",
                Organization="vOrganization",
                RecentActivity="RecentActivity"
            },
             new SpatialNode
            {
                Name="图书馆",
                Type="设施与实验室",
                ImageUrl="Image/sdf",
                BuildingIntro="BuildingIntro",
                CurrentUse="CurrentUse",
                Organization="vOrganization",
                RecentActivity="RecentActivity"
            },
             new SpatialNode
            {
                Name="游泳馆",
                Type="体育用楼",
                ImageUrl="Image/sdf",
                BuildingIntro="BuildingIntro",
                CurrentUse="CurrentUse",
                Organization="vOrganization",
                RecentActivity="RecentActivity"
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
    }

}
